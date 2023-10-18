using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LLMSharp.Tokenizers.Shared
{
    /// <summary>
    /// Helpful extensions for string manipulation
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Escapes any special chracters in the input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns the string with special characters escaped</returns>
        internal static string EscapeRegex(this string input)
        {
            return Regex.Replace(input, @"[\\^$*+?.()|[\]{}]", "\\$&");
        }


    