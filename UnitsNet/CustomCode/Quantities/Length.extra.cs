// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using Fractions;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Length
    {
        private const int InchesInOneFoot = 12;

        /// <summary>
        ///     Converts the length to a customary feet/inches combination.
        /// </summary>
        public FeetInches FeetInches
        {
            get
            {
                var inInches = Inches;
                var feet = Math.Truncate((inInches / InchesInOneFoot).ToDouble()); // TODO?
                var inches = inInches % InchesInOneFoot;

                return new FeetInches(Fraction.FromDoubleRounded(feet), inches);
            }
        }

        /// <summary>
        ///     Get length from combination of feet and inches.
        /// </summary>
        public static Length FromFeetInches(Fraction feet, Fraction inches)
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

            // This succeeds if only feet or inches are given, not both
            if (TryParse(str, formatProvider, out result))
                return true;

            var quantityParser = QuantityParser.Default;
            string footRegex = quantityParser.CreateRegexPatternForUnit(LengthUnit.Foot, formatProvider, matchEntireString: false);
            string inchRegex = quantityParser.CreateRegexPatternForUnit(LengthUnit.Inch, formatProvider, matchEntireString: false);

            // Match entire string exactly
            string pattern = $@"^(?<negativeSign>\-?)(?<feet>{footRegex})\s?(?<inches>{inchRegex})$";

            var match = new Regex(pattern, RegexOptions.Singleline).Match(str);
            if (!match.Success)
                return false;

            var negativeSignGroup = match.Groups["negativeSign"];
            var feetGroup = match.Groups["feet"];
            var inchesGroup = match.Groups["inches"];

            if (TryParse(feetGroup.Value, formatProvider, out Length feet) &&
                TryParse(inchesGroup.Value, formatProvider, out Length inches))
            {
                result = feet + inches;

                if (negativeSignGroup.Length > 0)
                    result = -result;

                return true;
            }

            result = default;
            return false;
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
        public FeetInches(Fraction feet, Fraction inches)
        {
            Feet = feet;
            Inches = inches;
        }

        /// <summary>
        ///     The feet value it was constructed with.
        /// </summary>
        public Fraction Feet { get; }

        /// <summary>
        ///     The inches value it was constructed with.
        /// </summary>
        public Fraction Inches { get; }

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
            cultureInfo = cultureInfo ?? CultureInfo.CurrentCulture;

            var footUnit = Length.GetAbbreviation(LengthUnit.Foot, cultureInfo);
            var inchUnit = Length.GetAbbreviation(LengthUnit.Inch, cultureInfo);

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
                int GreatestCommonDivisor(int a, int b)
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
