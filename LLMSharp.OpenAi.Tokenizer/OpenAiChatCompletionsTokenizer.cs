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
            using (var stream = assembly.GetManifestResourceStream("LLMSharp.OpenAi.Tokenizer.gpt-chatcompletions-token-