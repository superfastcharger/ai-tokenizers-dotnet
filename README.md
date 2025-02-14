# AI Tokenizers for .NET

[![build and test](https://github.com/superfastcharger/ai-tokenizers-dotnet/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/superfastcharger/ai-tokenizers-dotnet/actions/workflows/build-and-test.yml) [![CodeQL](https://github.com/superfastcharger/ai-tokenizers-dotnet/actions/workflows/codeql.yml/badge.svg)](https://github.com/superfastcharger/ai-tokenizers-dotnet/actions/workflows/codeql.yml)

- **Tokenizer.Anthropic** : Unofficial implementation of tokenizer for Anthropic claude in dotnet. Install this nuget package for Encoding using Claude Tokenizer.
- **Tokenizer.OpenAi** : Unofficial implementation of tokenizer for GPT-3.5/GPT-4 models in dotnet. Install this nuget package for Encoding using GPT Chat Completions Model Tokenizer.

## Usage

- Install the latest version of nuget package

```
dotnet add package Tokenizer.Anthropic

dotnet add package Tokenizer.OpenAi
```

- Create an instance of the tokenizer

```csharp
// Claude Tokenizer
using Tokenizer.Anthropic;

var tokenizer = new ClaudeTokenizer();


// OpenAi ChatCompletion Models Tokenizer
using Tokenizer.OpenAi;

var tokenizer = new OpenAiChatCompletionsTokenizer();
```

- **Encode** : tokenizes a given text, this is the default implementation that throws an exception if the text contains any special tokens

```csharp
var encodedTokens = tokenizer.Encode("hello world");
```

- **CountTokens** : count tokens in a given text, this is the default implementation that throws an exception if the text contains any special tokens

```csharp
var tokenCount = tokenizer.CountTokens("hello world");
```

- **EncodeWithSpecialTokens** : tokenizes a given text, including all or specific special tokens

```csharp
// passing 'null' for allowedSpecial , will help tokenize all special tokens
var encodedBytes = tokenizer.EncodeWithSpecialTokens(
    text:"<META_START>some data<META_END>",
    allowedSpecial: null,
    disallowedSpecial: null);


// passing an array of strings for allowedSpecial , will help tokenize only those special tokens
// any other special tokens found in the text will throw an exception
var encodedBytes = tokenizer.EncodeWithSpecialTokens(
    text:"<META_START>some data<META_END>",
    allowedSpecial: new string[]{"<META_START>", "<META_END>"},
    disallowedSpecial: null);
```

- **CountWithSpecialTokens** : count tokens in a given text, including all or specific special tokens

```csharp
var tokenCount = tokenizer.CountWithSpecialTokens(
    text:"<META_START>some data<META_END>",
    allowedSpecial: new string[]{"<META_START>", "<META_END>"},
    disallowedSpecial: null);
```

## Benchmarks

Encoding and CountTokens for 4200 tokens (~16 KB) of text

Detailed benchmark results are provided in the following tables for Linux, macOS, and Windows platforms. 