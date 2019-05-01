// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Newtonsoft.Json.Linq;

namespace CodeGen.JsonTypes
{
    /// <summary>
    ///     Localization of a unit, such as unit abbreviations in different languages.
    /// </summary>
    internal class Localization
    {
        /// <summary>
        ///     Gets the unit abbreviations for a prefix, if configured.
        /// </summary>
        /// <param name="prefix">The SI prefix.</param>
        /// <param name="unitAbbreviations">The configured unit abbreviations. Null if not configured.</param>
        /// <returns>True if configured, otherwise false.</returns>
        /// <exception cref="NotSupportedException">Unit abbreviations must be a string or an array of strings.</exception>
        public bool TryGetAbbreviationsForPrefix(Prefix prefix, out string[] unitAbbreviations)
        {
            if (AbbreviationsForPrefixes == null ||
                !AbbreviationsForPrefixes.TryGetValue(prefix.ToString(), out var value))
            {
                unitAbbreviations = default;
                return false;
            }

            switch (value.Type)
            {
                case JTokenType.String:
                {
                    unitAbbreviations = new[] {value.ToObject<string>()};
                    return true;
                }
                case JTokenType.Array:
                {
                    unitAbbreviations = value.ToObject<string[]>();
                    return true;
                }
                default:
                    throw new NotSupportedException($"AbbreviationsForPrefixes.{prefix} must be a string or an array of strings, but was {value.Type}.");
            }
        }
        // 0649 Field is never assigned to
#pragma warning disable 0649

        /// <summary>
        ///     The unit abbreviations. Can be empty for dimensionless units like Ratio.DecimalFraction.
        /// </summary>
        public string[] Abbreviations = Array.Empty<string>();

        /// <summary>
        ///     Explicit configuration of unit abbreviations for prefixes.
        ///     This is typically used for languages or special unit abbreviations where you cannot simply prepend SI prefixes like
        ///     "k" for kilo
        ///     to the abbreviations defined in <see cref="Localization.Abbreviations" />.
        /// </summary>
        /// <example>
        ///     Energy.ThermEc unit has "Abbreviations": "th (E.C.)" and "AbbreviationsForPrefixes": { "Deca": "Dth (E.C.)" } since
        ///     the SI prefix for Deca is "Da" and "Dath (E.C.)" is not the conventional form.
        /// </example>
        /// <remarks>
        ///     The unit abbreviation value can either be a string or an array of strings. Typically the number of abbreviations
        ///     for a prefix matches that of "Abbreviations" array, but this is not required.
        /// </remarks>
        public JObject AbbreviationsForPrefixes;

        /// <summary>
        ///     The name of the culture this is a localization for.
        /// </summary>
        public string Culture;

        // 0649 Field is never assigned to
#pragma warning restore 0649
    }
}
