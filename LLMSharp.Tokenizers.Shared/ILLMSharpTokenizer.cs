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
        /// encode will raise an error if it encounters text that corresponds
        /// to a special token.
        /// </summary>
        /// <param name="text">text input for counting number of tokens</param>        
        /// <returns>list of byte pair encoded tokens for the text</returns>
        /// <exception cref="InvalidOperationException">thrown when any of the disallowed special tokens are found in the text</exception>
        IReadOnlyList<int> Encode(string text);

        /// <summary>
        /// Counts number of byte pair encoded tokens for the given text input
        /// Special tokens are artificial tokens used to unlock capabilities from a model,
        /// such as fill-in-the-middle.So we want to be careful about accidentally encoding special
        /// tokens, since they can be used