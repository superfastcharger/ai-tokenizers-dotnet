
﻿using LLMSharp.OpenAi.Tokenizer;

namespace LLMSharp.Tokenizers.Tests
{
    [TestClass]
    public class OpenAiChatCmplTokenizerTests
    {
        private readonly OpenAiChatCompletionsTokenizer chatCompletionsTokenizer;

        public OpenAiChatCmplTokenizerTests() { this.chatCompletionsTokenizer = new OpenAiChatCompletionsTokenizer(); }

        [TestMethod]
        public void TestEncoding()
        {
            foreach (var test in TestData.GptChatCompletionsStrings)
            {
                var encodedBytes = chatCompletionsTokenizer.Encode(test.Value);
                var decodedText = chatCompletionsTokenizer.Decode(encodedBytes);
                Assert.AreEqual(decodedText, test.Value, $"Encoding for {test.Key} failed");
            }
        }

        [TestMethod]