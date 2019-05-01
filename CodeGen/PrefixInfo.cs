using System;
using System.Collections.Generic;
using CodeGen.JsonTypes;

namespace CodeGen
{
    /// <summary>
    /// Information about a unit prefix and a static dictionary to look up prefixes.
    /// </summary>
    internal class PrefixInfo
    {
        /// <summary>
        /// The unit prefix abbreviation, such as "k" for kilo or "m" for milli.
        /// </summary>
        public string Abbreviation { get; }

        /// <summary>
        /// C# expression for the multiplier to prefix the conversion function.
        /// </summary>
        /// <example>Kilo has "1e3" in order to multiply by 1000.</example>
        public string Factor { get; }

        public static readonly IReadOnlyDictionary<Prefix, PrefixInfo> Entries = new Dictionary<Prefix, PrefixInfo>
        {
            // NOTE: Need to append 'd' suffix for double in order to later search/replace "d" with "m"
            // when creating decimal conversion functions in CodeGen.Generator.FixConversionFunctionsForDecimalValueTypes.

            // SI prefixes
            { Prefix.Yocto, new PrefixInfo("y", "1e-24d") },
            { Prefix.Zepto, new PrefixInfo("z", "1e-21d") },
            { Prefix.Atto, new PrefixInfo("a", "1e-18d") },
            { Prefix.Femto, new PrefixInfo("f", "1e-15d") },
            { Prefix.Pico, new PrefixInfo("p", "1e-12d") },
            { Prefix.Nano, new PrefixInfo("n", "1e-9d") },
            { Prefix.Micro, new PrefixInfo("µ", "1e-6d") },
            { Prefix.Milli, new PrefixInfo("m", "1e-3d") },
            { Prefix.Centi, new PrefixInfo("c", "1e-2d") },
            { Prefix.Deci, new PrefixInfo("d", "1e-1d") },
            { Prefix.Deca, new PrefixInfo("da", "1e1d") },
            { Prefix.Hecto, new PrefixInfo("h", "1e2d") },
            { Prefix.Kilo, new PrefixInfo("k", "1e3d") },
            { Prefix.Mega, new PrefixInfo("M", "1e6d") },
            { Prefix.Giga, new PrefixInfo("G", "1e9d") },
            { Prefix.Tera, new PrefixInfo("T", "1e12d") },
            { Prefix.Peta, new PrefixInfo("P", "1e15d") },
            { Prefix.Exa, new PrefixInfo("E", "1e18d") },
            { Prefix.Zetta, new PrefixInfo("Z", "1e21d") },
            { Prefix.Yotta, new PrefixInfo("Y", "1e24d") },

            // Binary prefixes
            { Prefix.Kibi, new PrefixInfo("Ki", $"1024d") },
            { Prefix.Mebi, new PrefixInfo("Mi", $"(1024d * 1024)") },
            { Prefix.Gibi, new PrefixInfo("Gi", $"(1024d * 1024 * 1024)") },
            { Prefix.Tebi, new PrefixInfo("Ti", $"(1024d * 1024 * 1024 * 1024)") },
            { Prefix.Pebi, new PrefixInfo("Pi", $"(1024d * 1024 * 1024 * 1024 * 1024)") },
            { Prefix.Exbi, new PrefixInfo("Ei", $"(1024d * 1024 * 1024 * 1024 * 1024 * 1024)") },
        };

        private PrefixInfo(string abbreviation, string factor)
        {
            Abbreviation = abbreviation;
            Factor = factor;
        }
    }
}
