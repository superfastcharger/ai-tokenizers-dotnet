using System.Collections.Generic;

namespace LLMSharp.Tokenizers.Shared
{
    /// <summary>
    /// A common interface definition for any LLMSharpTokenizer to implement
    /// </summary>
    public interface ILLMSharpTokenizer
    {
        /// <summary>
        /// Byte Pair Encodes a string into tokens
        /// Special tokens are artificial tokens used to unlock capabilities from a model,
        /// such as fill-in-the-middle.So we want to be careful about accidentally encoding special
        /// tokens, since they can be used to trick a model into doing something we don't want it to do.
        /// encode w