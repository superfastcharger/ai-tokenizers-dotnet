
using LLMSharp.Anthropic.Tokenizer;

namespace LLMSharp.Tokenizers.Tests
{
    [TestClass]
    public class ClaudeTokenizerTests
    {
        private readonly ClaudeTokenizer claudeTokenizer;

        public ClaudeTokenizerTests() { this.claudeTokenizer = new ClaudeTokenizer(); }

        [TestMethod]
        public void TestEncoding()
        {
            foreach (var test in TestData.ClaudeStrings)
            {
                var encodedBytes = claudeTokenizer.Encode(test.Value);
                var decodedText = claudeTokenizer.Decode(encodedBytes);
                Assert.AreEqual(decodedText, test.Value, $"Encoding for {test.Key} failed");
            }
        }

        [TestMethod]
        public void TestCountTokens()
        {
            foreach (var test in TestData.ClaudeStrings)
            {
                var encodedBytes = claudeTokenizer.Encode(test.Value);
                var tokenCount = claudeTokenizer.CountTokens(test.Value);
                Assert.AreEqual(encodedBytes.Count, tokenCount, $"Count Tokens for {test.Key} failed");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSpecialTokensWithDefaultEncoding_Should_Throw_Exception()
        {
            claudeTokenizer.Encode(TestData.AnthropicClaudeSpecialCharacters);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSpecialTokensWithDefaultCountTokens_Should_Throw_Exception()
        {
            claudeTokenizer.CountTokens(TestData.AnthropicClaudeSpecialCharacters);
        }

        [TestMethod]
        public void ShouldEncodeSpecialTokens_WhenUsing_EncodeWithSpecialTokens()
        {
            var encodedBytes = claudeTokenizer.EncodeWithSpecialTokens(TestData.AnthropicClaudeSpecialCharacters, null, null);
            var decodedText = claudeTokenizer.Decode(encodedBytes);
            Assert.AreEqual(decodedText, TestData.AnthropicClaudeSpecialCharacters);
        }