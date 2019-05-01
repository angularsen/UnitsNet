// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Newtonsoft.Json.Linq;

namespace CodeGen.JsonTypes
{
    internal class Localization
    {
        // 0649 Field is never assigned to
#pragma warning disable 0649

        public string[] Abbreviations = Array.Empty<string>();

        /// <summary>
        /// Unit abbreviations for prefixes of a unit.
        /// Typically, this is used for languages or units abbreviations where the default SI prefix ("k" for kilo etc) cannot simply be prepended
        /// to the abbreviations defined in <see cref="Localization.Abbreviations"/>.
        /// </summary>
        /// <example>
        /// Duration.Second unit for Russian culture has "Abbreviations": [ "с", "сек" ] and "AbbreviationsForPrefixes": { "Nano": ["нс", "нсек"], "Micro": ["мкс", "мксек"], "Milli": ["мс", "мсек"] }
        /// </example>
        /// <remarks>One or more of properties with <see cref="Prefix"/> names should be assigned a string or a string[].</remarks>
        public JObject AbbreviationsForPrefixes;

        public string Culture;

        // 0649 Field is never assigned to
#pragma warning restore 0649

        public bool TryGetAbbreviationsForPrefix(Prefix prefix, out string[] unitAbbreviations)
        {
            if (AbbreviationsForPrefixes == null ||
                !AbbreviationsForPrefixes.TryGetValue(prefix.ToString(), out JToken value))
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
                    throw new NotSupportedException($"Expected AbbreviationsForPrefixes.{prefix} to be a string or an array of strings.");
            }
        }
    }
}
