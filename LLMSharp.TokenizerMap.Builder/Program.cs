namespace LLMSharp.TokenizerMap.Builder
{
    internal class Program
    {
        private const string TokenizeClaude = "claude";
        private const string TokenizeGptChat = "gptchat";

        static async Task Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            if(args.Length == 0)
            {
                await TokenizeAndSerialize(string.Empty, cts.Token);
            }
            else
            {
                await TokenizeAndSerialize(args[0], cts.Token);
            }
        }

        static async Task TokenizeAndSerialize(string model, CancellationToken cancellationToken)
        {
            TokenizerMapSerializer serializer = new();
            
            if (string.IsNullOrEmpty(model))
            {
                var tokenizeAnthropic = serializer.SerializeClaudeTokenMapsAsync(cancellationToken);
                var tokenizeGpt = serializer.SerializeGptTokenMapsAsync(cancellationToke