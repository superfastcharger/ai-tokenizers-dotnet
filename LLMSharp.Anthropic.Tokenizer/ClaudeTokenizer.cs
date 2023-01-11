using LLMSharp.Tokenizers.Shared;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LLMSharp.Anthropic.Tokenizer
{
    /// <summary>
    /// Unofficial implementation of Anthropic Claude Tokenizer in dotnet    
    /// </summary>
    public class ClaudeTokenizer: ILLMSharpTokenizer
    {
        private readonly TikTokenizer tokenizer;

        /// <summary>
        /// Creates an instance of Claude Tokenizer
        /// Reads the binary serialized bpe rank maps and regex pattern string
        /// Uses rankmaps and pattern string to create an instance of tiktokenizer
        /// </summary>
        public ClaudeTokenizer() 
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("LLMSharp.Anthropic.Tokenizer.claude-token-maps.bin"))
            {
                var tokenMaps = TokenizerMaps.Parser.ParseFrom(stream);
                var regexes = new Regex(tokenMaps.RegexPattern, RegexOptions.Compiled | RegexOptions.ECMAScript | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

                tokenizer = new TikTokenizer(tokenMaps, regexes);
            }                
        }

        /// <summary>
        /// Encodes a string into tokens
        /// Special tokens are artificial tokens used to unlock capabilities from a model,
        /// such as fill-in-the-middle.So we want to be careful about accidentally encoding special
        /// tokens, since they can be used to trick a model into doing something we don't want it to do.
        /// This method uses the default implementation and throws an error if the text contains any valid special tokens.
        /// For more granular control of encoding special tokens use 'EncodeWithSpecialTokens'
        /// </summary>
        /// <param name="text">text to encode using claude tokenizer</param>
        /// <returns>encoded tokens list of input text</returns>
        public IReadOnlyList<int> Encode(string text)
        {
            return this.tokenizer.Encode(text, new HashSet<string>(), null);
        }

        /// <summary>
        /// Counts number of byte pair encoded tokens for the given text input
        /// Special tokens are artificial tokens used to unlock capabilities from a model,
        /// such as fill-in-the-middle.So we want to be careful about accidentally encoding special
        /// tokens, since they can be used to trick a model into doing something we don't want it to do.
        /// This method uses the default implementation and throws an error if the text contains any valid special tokens.
        /// For more granular control of encoding special tokens use 'EncodeWithSpecialTokens'
        /// </summary>
        /// <param name="text">text input for counting tokens using claude tokenizer</param>
        /// <returns>number of tokens in the given text</returns>
        public int CountTokens(string text)
        {
            return this.tokenizer.CountTokens(text, new HashSet<string>(), null);
        }

        /// <summary>
        /// Encodes a string into tokens using claude bpe ranks
        /// Special tokens are artificial tokens used to unlock capabilities from a model,
        /// such as fill-in-the-middle.So we want to be careful about acciden