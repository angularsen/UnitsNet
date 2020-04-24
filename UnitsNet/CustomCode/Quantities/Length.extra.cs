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
    public partial struct Length
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
        public static Length FromFeetInches(double feet, double inches)
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
        public static Length ParseFeetInches([NotNull] string str, IFormatProvider formatProvider = null)
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
        public static bool TryParseFeetInches([CanBeNull] string str, out Length result, IFormatProvider formatProvider = null)
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

                if(negativeSignGroup.Length > 0)
                    result = -result;

                return true;
            }

            result = default;
            return false;
        }

        /// <summary>Get <see cref="Speed"/> from <see cref="Length"/> divided by <see cref="TimeSpan"/>.</summary>
        public static Speed operator /(Length length, TimeSpan timeSpan)
        {
            return Speed.FromMetersPerSecond(length.Meters/timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Speed"/> from <see cref="Length"/> divided by <see cref="Duration"/>.</summary>
        public static Speed operator /(Length length, Duration duration)
        {
            return Speed.FromMetersPerSecond(length.Meters/duration.Seconds);
        }

        /// <summary>Get <see cref="Duration"/> from <see cref="Length"/> divided by <see cref="Speed"/>.</summary>
        public static Duration operator /(Length length, Speed speed)
        {
            return Duration.FromSeconds(length.Meters/speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="Length"/> times <see cref="Length"/>.</summary>
        public static Area operator *(Length length1, Length length2)
        {
            return Area.FromSquareMeters(length1.Meters*length2.Meters);
        }

        /// <summary>Get <see cref="Volume"/> from <see cref="Area"/> times <see cref="Length"/>.</summary>
        public static Volume operator *(Area area, Length length)
        {
            return Volume.FromCubicMeters(area.SquareMeters*length.Meters);
        }

        /// <summary>Get <see cref="Volume"/> from <see cref="Length"/> times <see cref="Area"/>.</summary>
        public static Volume operator *(Length length, Area area)
        {
            return Volume.FromCubicMeters(area.SquareMeters*length.Meters);
        }

        /// <summary>Get <see cref="Torque"/> from <see cref="Force"/> times <see cref="Length"/>.</summary>
        public static Torque operator *(Force force, Length length)
        {
            return Torque.FromNewtonMeters(force.Newtons*length.Meters);
        }

        /// <summary>Get <see cref="Torque"/> from <see cref="Length"/> times <see cref="Force"/>.</summary>
        public static Torque operator *(Length length, Force force)
        {
            return Torque.FromNewtonMeters(force.Newtons*length.Meters);
        }

        /// <summary>Get <see cref="KinematicViscosity"/> from <see cref="Length"/> times <see cref="Speed"/>.</summary>
        public static KinematicViscosity operator *(Length length, Speed speed)
        {
            return KinematicViscosity.FromSquareMetersPerSecond(length.Meters*speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Pressure"/> from <see cref="Length"/> times <see cref="SpecificWeight"/>.</summary>
        public static Pressure operator *(Length length, SpecificWeight specificWeight)
        {
            return new Pressure(length.Meters * specificWeight.NewtonsPerCubicMeter, PressureUnit.Pascal);
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
        public string ToString([CanBeNull] IFormatProvider cultureInfo)
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
