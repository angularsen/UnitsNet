// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Length
    {
        private static readonly QuantityValue InchesInOneFoot = 12;

        /// <summary>
        ///     Converts the length to a customary feet/inches combination.
        /// </summary>
        public FeetInches FeetInches
        {
            get
            {
                QuantityValue totalInches = Inches;
                return new FeetInches((BigInteger) (totalInches / InchesInOneFoot), totalInches % InchesInOneFoot);
            }
        }

        /// <summary>
        ///     Get length from combination of feet and inches.
        /// </summary>
        public static Length FromFeetInches(QuantityValue feet, QuantityValue inches)
        {
            return FromInches(InchesInOneFoot*feet + inches);
        }

        /// <summary>
        /// Special parsing of feet/inches strings, commonly used.
        /// 2 feet 4 inches is sometimes denoted as 2′−4″, 2′ 4″, 2′4″, 2 ft 4 in.
        /// The apostrophe can be ′ and '.
        /// The double prime can be ″ and ".
        /// https://en.wikipedia.org/wiki/Foot_(unit)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="formatProvider">Optionally specify the culture format numbers and localize unit abbreviations. Defaults to thread's culture.</param>
        /// <returns>Parsed length.</returns>
        public static Length ParseFeetInches(string str, IFormatProvider? formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            if (!TryParseFeetInches(str, out Length result, formatProvider))
            {
                // A bit lazy, but I didn't want to duplicate this edge case implementation just to get more narrow exception descriptions.
                throw new FormatException("Unable to parse feet and inches. Expected format \"2' 4\"\" or \"2 ft 4 in\". Whitespace is optional.");
            }

            return result;
        }

        /// <summary>
        /// Special parsing of feet/inches strings, commonly used.
        /// 2 feet 4 inches is sometimes denoted as 2′−4″, 2′ 4″, 2′4″, 2 ft 4 in.
        /// The apostrophe can be ′ and '.
        /// The double prime can be ″ and ".
        /// https://en.wikipedia.org/wiki/Foot_(unit)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="result">Parsed length.</param>
        /// <param name="formatProvider">Optionally specify the culture format numbers and localize unit abbreviations. Defaults to thread's culture.</param>
        public static bool TryParseFeetInches(string? str, out Length result, IFormatProvider? formatProvider = null)
        {
            if (str == null)
            {
                result = default;
                return false;
            }

            str = str.Trim();

            if (TryParseFeetInchesCombination(str, formatProvider, out result))
                return true;

            // This succeeds if only feet or inches are given, not both.
            return TryParse(str, formatProvider, out result);
        }

        private static bool TryParseFeetInchesCombination(string str, IFormatProvider? formatProvider, out Length result)
        {
            QuantityParser quantityParser = QuantityParser.Default;
            var footRegex = new Regex(quantityParser.CreateRegexPatternForUnit(LengthUnit.Foot, formatProvider), RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var inchRegex = new Regex(quantityParser.CreateRegexPatternForUnit(LengthUnit.Inch, formatProvider), RegexOptions.Singleline | RegexOptions.IgnoreCase);

            bool isNegative = str.StartsWith("-", StringComparison.Ordinal);
            if (isNegative)
                str = str.Substring(1).TrimStart();

            // Prefer the rightmost foot abbreviation so "1'000' 6\"" treats grouping apostrophes as part of
            // the feet value, then keep walking left if that split does not leave valid feet and inches parts.
            IReadOnlyList<string> footAbbreviations = UnitAbbreviationsCache.Default.GetUnitAbbreviations(LengthUnit.Foot, formatProvider);
            foreach (int splitEndIndex in GetPossibleUnitSplitEndIndexes(str, footAbbreviations))
            {
                string feetPart = str.Substring(0, splitEndIndex).TrimEnd();
                string inchesPart = str.Substring(splitEndIndex).TrimStart();
                if (inchesPart.Length == 0)
                    continue;

                if (!TryParseSpecificUnit(feetPart, footRegex, formatProvider, out Length feet) ||
                    !TryParseSpecificUnit(inchesPart, inchRegex, formatProvider, out Length inches))
                    continue;

                result = feet + inches;

                if (isNegative)
                    result = -result;

                return true;
            }

            result = default;
            return false;
        }

        private static IEnumerable<int> GetPossibleUnitSplitEndIndexes(string str, IReadOnlyList<string> abbreviations)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                foreach (string abbreviation in abbreviations)
                {
                    if (abbreviation.Length == 0 || i + abbreviation.Length > str.Length)
                        continue;

                    if (string.Compare(str, i, abbreviation, 0, abbreviation.Length, StringComparison.OrdinalIgnoreCase) == 0)
                        yield return i + abbreviation.Length;
                }
            }
        }

        private static bool TryParseSpecificUnit(string str, Regex unitRegex, IFormatProvider? formatProvider, out Length result)
        {
            if (!unitRegex.IsMatch(str))
            {
                result = default;
                return false;
            }

            return TryParse(str, formatProvider, out result);
        }
    }

    /// <summary>
    ///     Representation of feet and inches, used to preserve the original values when constructing <see cref="Length"/> by
    ///     <see cref="Length.FromFeetInches"/> and later output them unaltered with <see cref="ToString()"/>.
    /// </summary>
    public sealed class FeetInches
    {
        /// <summary>
        ///     Construct from feet and inches.
        /// </summary>
        public FeetInches(BigInteger feet, QuantityValue inches)
        {
            Feet = feet;
            Inches = inches;
        }

        /// <summary>
        ///     The feet value it was constructed with.
        /// </summary>
        public BigInteger Feet { get; }

        /// <summary>
        ///     The inches value it was constructed with.
        /// </summary>
        public QuantityValue Inches { get; }

        /// <inheritdoc cref="ToString(IFormatProvider)"/>
        public override string ToString()
        {
            return ToString(null);
        }

        /// <summary>
        ///     Outputs feet and inches on the format: {feetValue} {feetUnit} {inchesValue} {inchesUnit}
        /// </summary>
        /// <example>Length.FromFeetInches(3,2).FeetInches.ToString() outputs: "3 ft 2 in"</example>
        /// <param name="cultureInfo">
        ///     Optional culture to format number and localize unit abbreviations.
        ///     If null, defaults to <see cref="Thread.CurrentCulture"/>.
        /// </param>
        public string ToString(IFormatProvider? cultureInfo)
        {
            if (cultureInfo is not CultureInfo unitLocalizationCulture)
            {
                cultureInfo = unitLocalizationCulture = CultureInfo.CurrentCulture;
            }

            var footUnit = Length.GetAbbreviation(LengthUnit.Foot, unitLocalizationCulture);
            var inchUnit = Length.GetAbbreviation(LengthUnit.Inch, unitLocalizationCulture);

            // Note that it isn't customary to use fractions - one wouldn't say "I am 5 feet and 4.5 inches".
            // So inches are rounded when converting from base units to feet/inches.
            return string.Format(cultureInfo, "{0:n0} {1} {2:n0} {3}", Feet, footUnit, Math.Round(Inches.ToDouble()), inchUnit);
        }

        /// <summary>
        ///     Outputs feet and inches on the format: {feetValue}' - {inchesValueIntegral}[ / {inchesValueFractional}]"
        ///     The inches are rounded to the nearest fraction of the fractionDenominator argument and reduced over the greatest common divisor.
        ///     The fractional inch value is omitted if the numerator is 0 after rounding, or if the provided denominator is 1.
        /// </summary>
        /// <param name="fractionDenominator">The maximum precision to express the rounded inch fraction part. Use 1 to round to nearest integer, with no fraction.</param>
        /// <example>
        /// <code>
        /// var length = Length.FromFeetInches(3, 2.6);
        /// length.ToArchitecturalString(1)   => 3' - 3"
        /// length.ToArchitecturalString(2)   => 3' - 2 1/2"
        /// length.ToArchitecturalString(4)   => 3' - 2 1/2"
        /// length.ToArchitecturalString(8)   => 3' - 2 5/8"
        /// length.ToArchitecturalString(16)  => 3' - 2 5/8"
        /// length.ToArchitecturalString(32)  => 3' - 2 19/32"
        /// length.ToArchitecturalString(128) => 3' - 2 77/128"
        /// </code>
        /// </example>
        /// <exception cref="ArgumentOutOfRangeException">Denominator for fractional inch must be greater than zero.</exception>
        public string ToArchitecturalString(int fractionDenominator)
        {
            if (fractionDenominator < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(fractionDenominator), "Denominator for fractional inch must be greater than zero.");
            }
            
            // TODO this could probably be done better with the fractions
            var inchTrunc = (int)Math.Truncate(Inches.ToDouble());
            var numerator = (int)Math.Round((Inches - inchTrunc).ToDouble() * fractionDenominator); 

            if (numerator == fractionDenominator)
            {
                inchTrunc++;
                numerator = 0;
            }

            var inchPart = new System.Text.StringBuilder();

            if (inchTrunc != 0 || numerator == 0)
            {
                inchPart.Append(inchTrunc);
            }

            if (numerator > 0)
            {
                static int GreatestCommonDivisor(int a, int b)
                {
                    while (a != 0 && b != 0)
                    {
                        if (a > b)
                            a %= b;
                        else
                            b %= a;
                    }

                    return a | b;
                }

                int gcd = GreatestCommonDivisor(numerator, fractionDenominator);

                if (inchPart.Length > 0)
                {
                    inchPart.Append(' ');
                }

                inchPart.Append($"{numerator / gcd}/{fractionDenominator / gcd}");
            }

            inchPart.Append('"');

            if (Feet == 0)
            {
                return inchPart.ToString();
            }

            return $"{Feet}' - {inchPart}";
        }
    }
}
