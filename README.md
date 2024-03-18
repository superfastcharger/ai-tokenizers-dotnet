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
`