// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;

namespace UnitsNet.Serialization.JsonNet
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Truncates a string to the given length, with truncation suffix.
        /// </summary>
        /// <param name="value">The string.</param>
        /// <param name="maxLength">The max length, including <paramref name="truncationSuffix"/>.</param>
        /// <param name="truncationSuffix">Suffix to append if truncated, defaults to "…".</param>
        /// <returns>The truncated string if longer, otherwise the original string.</returns>
        [return: NotNullIfNotNull("value")]
        public static string? Truncate(this string? value, int maxLength, string truncationSuffix = "…")
        {
            return value?.Length > maxLength
                ? value.Substring(0, maxLength - truncationSuffix.Length) + truncationSuffix
                : value;
        }
    }
}
