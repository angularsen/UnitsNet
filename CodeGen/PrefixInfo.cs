using System.Collections.Generic;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen
{
    /// <summary>
    /// Information about a unit prefix and a static dictionary to look up prefixes.
    /// </summary>
    internal class PrefixInfo
    {
        /// <summary>
        /// The unit prefix.
        /// </summary>
        public Prefix Prefix { get; }

        /// <summary>
        /// The unit prefix abbreviation, such as "k" for kilo or "m" for milli.
        /// </summary>
        public string Abbreviation { get; }

        /// <summary>
        /// C# expression for the multiplier to prefix the conversion function.
        /// </summary>
        /// <example>Kilo has "1e3" in order to multiply by 1000.</example>
        public string Factor { get; }

        public static readonly IReadOnlyDictionary<Prefix, PrefixInfo> Entries = new[]
        {
            // Need to append 'd' suffix for double in order to later search/replace "d" with "m"
            // when creating decimal conversion functions in CodeGen.Generator.FixConversionFunctionsForDecimalValueTypes.

            // SI prefixes
            new PrefixInfo(Prefix.Yocto, "y", "1e-24d"),
            new PrefixInfo(Prefix.Zepto, "z", "1e-21d"),
            new PrefixInfo(Prefix.Atto, "a", "1e-18d"),
            new PrefixInfo(Prefix.Femto, "f", "1e-15d"),
            new PrefixInfo(Prefix.Pico, "p", "1e-12d"),
            new PrefixInfo(Prefix.Nano, "n", "1e-9d"),
            new PrefixInfo(Prefix.Micro, "µ", "1e-6d"),
            new PrefixInfo(Prefix.Milli, "m", "1e-3d"),
            new PrefixInfo(Prefix.Centi, "c", "1e-2d"),
            new PrefixInfo(Prefix.Deci, "d", "1e-1d"),
            new PrefixInfo(Prefix.Deca, "da", "1e1d"),
            new PrefixInfo(Prefix.Hecto, "h", "1e2d"),
            new PrefixInfo(Prefix.Kilo, "k", "1e3d"),
            new PrefixInfo(Prefix.Mega, "M", "1e6d"),
            new PrefixInfo(Prefix.Giga, "G", "1e9d"),
            new PrefixInfo(Prefix.Tera, "T", "1e12d"),
            new PrefixInfo(Prefix.Peta, "P", "1e15d"),
            new PrefixInfo(Prefix.Exa, "E", "1e18d"),
            new PrefixInfo(Prefix.Zetta, "Z", "1e21d"),
            new PrefixInfo(Prefix.Yotta, "Y", "1e24d"),

            // Binary prefixes
            new PrefixInfo(Prefix.Kibi, "Ki", $"1024d"),
            new PrefixInfo(Prefix.Mebi, "Mi", $"(1024d * 1024)"),
            new PrefixInfo(Prefix.Gibi, "Gi", $"(1024d * 1024 * 1024)"),
            new PrefixInfo(Prefix.Tebi, "Ti", $"(1024d * 1024 * 1024 * 1024)"),
            new PrefixInfo(Prefix.Pebi, "Pi", $"(1024d * 1024 * 1024 * 1024 * 1024)"),
            new PrefixInfo(Prefix.Exbi, "Ei", $"(1024d * 1024 * 1024 * 1024 * 1024 * 1024)"),
        }.ToDictionary(prefixInfo => prefixInfo.Prefix);

        private PrefixInfo(Prefix prefix, string abbreviation, string factor)
        {
            Prefix = prefix;
            Abbreviation = abbreviation;
            Factor = factor;
        }
    }
}
