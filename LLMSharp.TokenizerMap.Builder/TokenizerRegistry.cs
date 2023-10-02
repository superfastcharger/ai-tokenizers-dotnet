using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LLMSharp.TokenizerMap.Builder
{
    public class TokenizerRegistry
    {
        [JsonPropertyName("explicit_n_vocab")]
        public int Expl