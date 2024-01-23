
﻿using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LLMSharp.Tokenizers.Shared
{
    /// <summary>
    /// TikToken implementation in C#, an experimental implementation
    /// Inspired by the original source at : https://github.com/openai/tiktoken/tree/main
    /// </summary>
    public class TikTokenizer
    {
        private readonly TokenizerMaps tokenMaps;
        private readonly Regex patternStringRegex;

        public TikTokenizer(TokenizerMaps modelTokenMaps, Regex modelPatternString)
        {
            this.tokenMaps = modelTokenMaps;
            this.patternStringRegex = modelPatternString;
        }

        /// <summary>
        /// Byte Pair Encodes a string into tokens
        /// Special tokens are artificial tokens used to unlock capabilities from a model,
        /// such as fill-in-the-middle.So we want to be careful about accidentally encoding special
        /// tokens, since they can be used to trick a model into doing something we don't want it to do.
        /// Hence, by default, encode will raise an error if it encounters text that corresponds
        /// to a special token.This can be controlled on a per-token level using the `allowed_special`
        /// and `disallowed_special` parameters.In particular:
        /// Setting 'disallowedSpecial' to null will prevent this function from raising errors and
        /// cause all text corresponding to special tokens to be encoded as natural text.
        /// Setting 'allowedSpecial' to null will cause this function to treat all text
        /// corresponding to special tokens to be encoded as special tokens.
        /// </summary>
        /// <param name="text">text input for counting number of tokens</param>
        /// <param name="allowedSpecial">special tokens that are allowed for tokenization. If null, all the special tokens supported by the model are allowed. If empty, none of the special tokens are allowed.</param>
        /// <param name="disallowedSpecial">special tokens that should be disallowed for tokenization. If null, any special token that is not allowed will be considered disallowed.</param>
        /// <returns>list of byte pair encoded tokens for the text</returns>
        /// <exception cref="InvalidOperationException">thrown when any of the disallowed special tokens are found in the text</exception>
        public IReadOnlyList<int> Encode(
            string text,
            HashSet<string> allowedSpecial,
            HashSet<string> disallowedSpecial
            )
        {
            HashSet<string> allowedSpecialSet = new HashSet<string>(tokenMaps.SpecialTokens.Keys);
            HashSet<string> disallowedSpecialSet = disallowedSpecial;

            if (allowedSpecial != null)
            {
                allowedSpecialSet.IntersectWith(allowedSpecial);
            }
            
            if(disallowedSpecialSet == null)
            {
                disallowedSpecialSet = new HashSet<string>(tokenMaps.SpecialTokens.Keys.Where(k => !allowedSpecialSet.Contains(k)));
            }

            Regex specialTokenRegex = tokenMaps.SpecialTokens.Keys.CreateRegexFromTokens();

            // validate if the text contains a disallowed special token
            if (disallowedSpecialSet.Count > 0)
            {
                Regex disallowedSpecailRegex = disallowedSpecialSet.CreateRegexFromTokens();
                Match disallowedSpecialMatch = disallowedSpecailRegex.Match(text);

                if (disallowedSpecialMatch.Success)
                {
                    throw new InvalidOperationException($"The text contains a special token that is not allowed: {disallowedSpecialMatch.Value}");
                }
            }

            // assuming each token is approximately 4 bytes, let's declare an initial capacity
            List<int> result = new List<int>(text.Length / 4);
            int start = 0;

            /**
             * We will perform the following in a loop till the end of string
             * 1. Identify the slice of string between two special tokens
             * 2. Run that slice through the pattern matching string regex to obtain matches
             * 3. Pass those matches and their corresponding ranks from tokenMap to BPE algorithm
             * 4. Get the corresponding compressed representation as tokens, append to our result
             */
            while (true)
            {
                int startFind = start;
                Match nextSpecial = null;

                // 1. Identify the index of next special token to slice
                while (true)
                {
                    nextSpecial = specialTokenRegex.Match(text, startFind);

                    // we didn't find any special token or the special token we found is allowed. Then break
                    if (!nextSpecial.Success || allowedSpecialSet.Contains(nextSpecial.Value)) break;
                    startFind = nextSpecial.Index + 1;
                }

                int end = (nextSpecial?.Success == true) ? nextSpecial.Index : text.Length;                

                // 2. Run the slice of the string through pattern matching
                foreach (Match match in patternStringRegex.Matches(text.Substring(start, end - start)))
                {
                    var matchBytes = ByteString.CopyFromUtf8(match.Value);

                    // if there is rank available for this slice, add it to result. If not perform BPE
                    if (tokenMaps.RankMap.TryGetValue(matchBytes.ToBase64(), out int rank))
                    {
                        result.Add(rank);
                        continue;
                    }

                    result.AddRange(BytePairEncode(matchBytes));
                }

                if (nextSpecial?.Success != true) break;
                result.Add(tokenMaps.SpecialTokens[nextSpecial.Value]);
                start = nextSpecial.Index + nextSpecial.Length;
            }

            return result;
        }

        /// <summary>
        /// Counts number of byte pair encoded tokens for the given text input
        /// Special tokens are artificial tokens used to unlock capabilities from a model,
        /// such as fill-in-the-middle.So we want to be careful about accidentally encoding special
        /// tokens, since they can be used to trick a model into doing something we don't want it to do.
        /// Hence, by default, encode will raise an error if it encounters text that corresponds