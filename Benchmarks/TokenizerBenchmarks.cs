using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LLMSharp.Anthropic.Tokenizer;
using LLMSharp.OpenAi.Tokenizer;

namespace Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net70, baseline:true)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)