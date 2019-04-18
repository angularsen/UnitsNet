// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace CodeGen.Helpers
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Returns true if string is not null and not whitespace.
        /// </summary>
        public static bool HasText(this string str) => !string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// Example: "Kilo" + ToCamelCase("NewtonPerMeter") => "KilonewtonPerMeter"
        /// </summary>
        public static string ToCamelCase(this string str)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
    }
}
