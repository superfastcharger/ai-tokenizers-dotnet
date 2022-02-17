using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LLMSharp.Anthropic.Tokenizer;
using LLMSharp.OpenAi.Tokenizer;

namespace Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net70, baseline:true)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [HideColumns("Error", "StdDev", "StdDev", "RatioSD")]
    public class TokenizerBenchmarks
    {
        private OpenAiChatCompletionsTokenizer? openAiChatCompletionsTokenizer;
        private ClaudeTokenizer? claudeTokenizer;

        [Params(Con