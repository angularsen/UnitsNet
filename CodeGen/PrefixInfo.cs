using System;
using System.Collections.Generic;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen
{
    /// <summary>
    ///     Information about a unit prefix and a static dictionary to look up prefixes.
    /// </summary>
    internal class PrefixInfo
    {
        private const string Chinese = "zh-CN";
        private const string French = "fr-FR";
        private const string Russian = "ru-RU";

        public static readonly IReadOnlyDictionary<Prefix, PrefixInfo> Entries = new[]
        {
            // Need to append 'd' suffix for double in order to later search/replace "d" with "m"
            // when creating decimal conversion functions in CodeGen.Generator.FixConversionFunctionsForDecimalValueTypes.

            // SI prefixes
            new PrefixInfo(Prefix.Yocto, "1e-24d", "y", (Russian,null,"йоктог"), (Chinese, "夭",null)),
            new PrefixInfo(Prefix.Zepto, "1e-21d", "z", (Russian,null,"зептог"), (Chinese, "仄",null)),
            new PrefixInfo(Prefix.Atto, "1e-18d", "a", (Russian, "а","аттог"), (Chinese, "阿",null)),
            new PrefixInfo(Prefix.Femto, "1e-15d", "f", (Russian, "ф","фемтог"), (Chinese, "飞",null)),
            new PrefixInfo(Prefix.Pico, "1e-12d", "p", (Russian, "п","пиког"), (Chinese, "皮",null)),
            new PrefixInfo(Prefix.Nano, "1e-9d", "n", (Russian, "н","наног"), (Chinese, "纳",null)),
            new PrefixInfo(Prefix.Micro, "1e-6d", "µ", (Russian, "мк","микрог"), (Chinese, "微",null)),
            new PrefixInfo(Prefix.Milli, "1e-3d", "m", (Russian, "м","Миллиг"), (Chinese, "毫",null)),
            new PrefixInfo(Prefix.Centi, "1e-2d", "c", (Russian, "с","сантиг"), (Chinese, "厘",null)),
            new PrefixInfo(Prefix.Deci, "1e-1d", "d", (Russian, "д","дециг"), (Chinese, "分",null), (French,null,"Déci")),
            new PrefixInfo(Prefix.Deca, "1e1d", "da", (Russian, "да","декаг"), (Chinese, "十",null), (French,null,"Déca")),
            new PrefixInfo(Prefix.Hecto, "1e2d", "h", (Russian, "г","гектог"), (Chinese, "百",null)),
            new PrefixInfo(Prefix.Kilo, "1e3d", "k", (Russian, "к","килог"), (Chinese, "千",null)),
            new PrefixInfo(Prefix.Mega, "1e6d", "M", (Russian, "М","мегаг"), (Chinese, "兆",null), (French,null,"Méga")),
            new PrefixInfo(Prefix.Giga, "1e9d", "G", (Russian, "Г","гигаг"), (Chinese, "吉",null)),
            new PrefixInfo(Prefix.Tera, "1e12d", "T", (Russian, "Т","тераг"), (Chinese, "太",null), (French,null,"Téra")),
            new PrefixInfo(Prefix.Peta, "1e15d", "P", (Russian, "П","петаг"), (Chinese, "拍",null)),
            new PrefixInfo(Prefix.Exa, "1e18d", "E", (Russian, "Э","экзаг"), (Chinese, "艾",null)),
            new PrefixInfo(Prefix.Zetta, "1e21d", "Z", (Russian, null,"Зеттаг"),(Chinese, "泽",null)),
            new PrefixInfo(Prefix.Yotta, "1e24d", "Y", (Russian, null,"Йоттаг"),(Chinese, "尧",null)),

            // Binary prefixes
            new PrefixInfo(Prefix.Kibi, "1024d", "Ki"),
            new PrefixInfo(Prefix.Mebi, "(1024d * 1024)", "Mi"),
            new PrefixInfo(Prefix.Gibi, "(1024d * 1024 * 1024)", "Gi"),
            new PrefixInfo(Prefix.Tebi, "(1024d * 1024 * 1024 * 1024)", "Ti"),
            new PrefixInfo(Prefix.Pebi, "(1024d * 1024 * 1024 * 1024 * 1024)", "Pi"),
            new PrefixInfo(Prefix.Exbi, "(1024d * 1024 * 1024 * 1024 * 1024 * 1024)", "Ei")
        }.ToDictionary(prefixInfo => prefixInfo.Prefix);

        private PrefixInfo(Prefix prefix, string factor, string siPrefix, params(string cultureName, string? shortPrefix,string? longPrefix)[] cultureToPrefix)
        {
            Prefix = prefix;
            SiPrefix = siPrefix;
            CultureToPrefix = cultureToPrefix;
            Factor = factor;
        }

        /// <summary>
        ///     The unit prefix.
        /// </summary>
        public Prefix Prefix { get; }


        /// <summary>
        ///     C# expression for the multiplier to prefix the conversion function.
        /// </summary>
        /// <example>Kilo has "1e3" in order to multiply by 1000.</example>
        public string Factor { get; }

        /// <summary>
        ///     The unit prefix abbreviation, such as "k" for kilo or "m" for milli.
        /// </summary>
        private string SiPrefix { get; }

        /// <summary>
        ///     Mapping from culture name to localized prefix abbreviation.
        /// </summary>
        private (string cultureName, string? shortPrefix, string? longPrefix)[] CultureToPrefix { get; }


        /// <summary>
        ///     Gets the localized prefix if configured, otherwise <see cref="SiPrefix" />.
        /// </summary>
        /// <param name="cultureName">Culture name, such as "en-US" or "ru-RU".</param>
        public string GetPrefixForCultureOrSiPrefix(string cultureName)
        {
            if (cultureName == null) throw new ArgumentNullException(nameof(cultureName));

            var localizedPrefix = CultureToPrefix
                .Where(x => string.Equals(x.cultureName, cultureName, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.shortPrefix).FirstOrDefault();

            return localizedPrefix ?? SiPrefix;
        }

        /// <summary>
        ///     Gets the localized prefix name if configured, otherwise <see cref="SiPrefix" />.
        /// </summary>
        /// <param name="cultureName">Culture name, such as "en-US" or "ru-RU".</param>
        public string GetPrefixNameForCultureOrSiPrefix(string cultureName)
        {
            if (cultureName == null) throw new ArgumentNullException(nameof(cultureName));

            var localizedPrefix = CultureToPrefix
                .Where(x => string.Equals(x.cultureName, cultureName, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.longPrefix).FirstOrDefault();

            return localizedPrefix ?? Prefix.ToString();
        }
    }
}
