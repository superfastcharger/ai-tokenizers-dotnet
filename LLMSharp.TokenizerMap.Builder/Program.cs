namespace LLMSharp.TokenizerMap.Builder
{
    internal class Program
    {
        private const string TokenizeClaude = "claude";
        private const string TokenizeGptChat = "gptchat";

        static async Task Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            Console.CancelKeyPres