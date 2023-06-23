﻿using LLMSharp.Tokenizers.Shared;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LLMSharp.OpenAi.Tokenizer
{
    /// <summary>
    /// TikTokenizer implementation for OpenAi GPT ChatCompletion models (GPT 3.5/GPT 4)
    /// </summary>
    public class OpenAiChatCompletionsTokenizer: ILLMSharpTokenizer
    {
        private readonly TikTokenizer tokenizer;

        /// <summary>
        /// Creates an instance of OpenAi chat completions Tokenizer
        /// Reads the binary serialized bpe rank maps and regex pattern string
        /// Uses rankmaps and pattern string to create an instance of tiktokenizer
        /// </summary>
        public OpenAiChatCompletionsTokenizer()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("LLMSharp.OpenAi.Tokenizer.gpt-chatcompletions-token-maps.bin"))
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
        /// <param name="text">text to encode using openai chat completions tokenizer</param>
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
        /// For more granular control of counting special tokens use 'CountWithSpecialTokens'
        /// </summary>
        /// <param name="text">text input for counting tokens using gpt chatcompletions tokenizer</param>
        /// <returns>number of tokens in the given text</returns>
        /// <exception cref="InvalidOperationException">thrown when any of the disallowed special tokens are found in the text</exception>
        public int CountTokens(string text)
        {
            return this.tokenizer.CountTokens(text, new HashSet<string>(), null);
        }

        /// <summary>
        /// Encodes a string into tokens using openai chat completions bpe rank