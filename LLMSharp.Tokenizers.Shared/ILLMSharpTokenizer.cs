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
        /// tokens, since they can be used to trick a model into doing something we don't want it to do.
        /// CountTokens will raise an error if it encounters text that corresponds
        /// to a special token.
        /// </summary>
        /// <param name="text">text input for counting number of tokens</param>
        /// <param name="allowedSpecial">special tokens that are allowed for tokenization. If null, all the special tokens supported by the model are allowed. If empty, none of the special tokens are allowed.</param>
        /// <param name="disallowedSpecial">special tokens that should be disallowed for tokenization. If null, any special token that is not allowed will be considered disallowed.</param>
        /// <returns>number of tokens for the given text</returns>
        /// <exception cref="InvalidOperationExc