// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using JetBrains.Annotations;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Length<T>
    {
        private const double InchesInOneFoot = 12;

        /// <summary>
        ///     Converts the length to a customary feet/inches combination.
        /// </summary>
        public FeetInches FeetInches
        {
            get
            {
                var inInches = Inches;
                var feet = Math.Truncate(inInches / InchesInOneFoot);
                var inches = inInches % InchesInOneFoot;

                return new FeetInches(feet, inches);
            }
        }

        /// <summary>
        ///     Get length from combination of feet and inches.
        /// </summary>
        public static Length<T> FromFeetInches(double feet, double inches)
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
        public static Length<T> ParseFeetInches([NotNull] string str, IFormatProvider? formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            if (!TryParseFeetInches(str, out Length<T> result, formatProvider))
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
        public static bool TryParseFeetInches(string? str, out Length<T> result, IFormatProvider? formatProvider = null)
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

            if (TryParse(feetGroup.Value, formatProvider, out Length<T> feet ) &&
                TryParse(inchesGroup.Value, formatProvider, out Length<T> inches ))
            {
                result = feet + inches;

                if(negativeSignGroup.Length > 0)
                    result = -result;

                return true;
            }

            result = default;
            return false;
        }

        /// <summary>Get <see cref="Speed{T}"/> from <see cref="Length{T}"/> divided by <see cref="TimeSpan"/>.</summary>
        public static Speed<T> operator /(Length<T> length, TimeSpan timeSpan)
        {
            return Speed<T>.FromMetersPerSecond(length.Meters/timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Speed{T}"/> from <see cref="Length{T}"/> divided by <see cref="Duration{T}"/>.</summary>
        public static Speed<T> operator /(Length<T> length, Duration<T> duration )
        {
            return Speed<T>.FromMetersPerSecond(length.Meters/duration.Seconds);
        }

        /// <summary>Get <see cref="Duration{T}"/> from <see cref="Length{T}"/> divided by <see cref="Speed{T}"/>.</summary>
        public static Duration<T> operator /(Length<T> length, Speed<T> speed )
        {
            return Duration<T>.FromSeconds(length.Meters/speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Area{T}"/> from <see cref="Length{T}"/> times <see cref="Length{T}"/>.</summary>
        public static Area<T> operator *(Length<T> length1, Length<T> length2 )
        {
            return Area<T>.FromSquareMeters(length1.Meters*length2.Meters);
        }

        /// <summary>Get <see cref="Volume{T}"/> from <see cref="Area{T}"/> times <see cref="Length{T}"/>.</summary>
        public static Volume<T> operator *(Area<T> area, Length<T> length )
        {
            return Volume<T>.FromCubicMeters(area.SquareMeters*length.Meters);
        }

        /// <summary>Get <see cref="Volume{T}"/> from <see cref="Length{T}"/> times <see cref="Area{T}"/>.</summary>
        public static Volume<T> operator *(Length<T> length, Area<T> area )
        {
            return Volume<T>.FromCubicMeters(area.SquareMeters*length.Meters);
        }

        /// <summary>Get <see cref="Torque{T}"/> from <see cref="Force{T}"/> times <see cref="Length{T}"/>.</summary>
        public static Torque<T> operator *(Force<T> force, Length<T> length )
        {
            return Torque<T>.FromNewtonMeters(force.Newtons*length.Meters);
        }

        /// <summary>Get <see cref="Torque{T}"/> from <see cref="Length{T}"/> times <see cref="Force{T}"/>.</summary>
        public static Torque<T> operator *(Length<T> length, Force<T> force )
        {
            return Torque<T>.FromNewtonMeters(force.Newtons*length.Meters);
        }

        /// <summary>Get <see cref="KinematicViscosity{T}"/> from <see cref="Length{T}"/> times <see cref="Speed{T}"/>.</summary>
        public static KinematicViscosity<T> operator *(Length<T> length, Speed<T> speed )
        {
            return KinematicViscosity<T>.FromSquareMetersPerSecond(length.Meters*speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Pressure{T}"/> from <see cref="Length{T}"/> times <see cref="SpecificWeight{T}"/>.</summary>
        public static Pressure<T> operator *(Length<T> length, SpecificWeight<T> specificWeight )
        {
            return new Pressure<T>( length.Meters * specificWeight.NewtonsPerCubicMeter, PressureUnit.Pascal);
        }
    }

    /// <summary>
    ///     Representation of feet and inches, used to preserve the original values when constructing <see cref="Length{T}"/> by
    ///     <see cref="Length{T}.FromFeetInches"/> and later output them unaltered with <see cref="ToString()"/>.
    /// </summary>
    public sealed class FeetInches
    {
        /// <summary>
        ///     Construct from feet and inches.
        /// </summary>
        public FeetInches(double feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        /// <summary>
        ///     The feet value it was constructed with.
        /// </summary>
        public double Feet { get; }

        /// <summary>
        ///     The inches value it was constructed with.
        /// </summary>
        public double Inches { get; }

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
        ///     If null, defaults to <see cref="Thread.CurrentUICulture"/>.
        /// </param>
        public string ToString(IFormatProvider? cultureInfo)
        {
            cultureInfo = cultureInfo ?? CultureInfo.CurrentUICulture;

            var footUnit = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(LengthUnit.Foot, cultureInfo);
            var inchUnit = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(LengthUnit.Inch, cultureInfo);

            // Note that it isn't customary to use fractions - one wouldn't say "I am 5 feet and 4.5 inches".
            // So inches are rounded when converting from base units to feet/inches.
            return string.Format(cultureInfo, "{0:n0} {1} {2:n0} {3}", Feet, footUnit, Math.Round(Inches), inchUnit);
        }
    }
}
