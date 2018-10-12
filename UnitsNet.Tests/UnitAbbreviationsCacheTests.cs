// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnitsNet.Units;
using Xunit;
using Xunit.Abstractions;

namespace UnitsNet.Tests
{
    [Collection(nameof(UnitAbbreviationsCacheFixture))]
    public class UnitAbbreviationsCacheTests
    {
        private readonly ITestOutputHelper _output;
        private const string AmericanCultureName = "en-US";
        private const string RussianCultureName = "ru-RU";
        private const string NorwegianCultureName = "nb-NO";

        private static readonly IFormatProvider AmericanCulture = new CultureInfo(AmericanCultureName);
        private static readonly IFormatProvider NorwegianCulture = new CultureInfo(NorwegianCultureName);
        private static readonly IFormatProvider RussianCulture = new CultureInfo(RussianCultureName);

        public UnitAbbreviationsCacheTests(ITestOutputHelper output)
        {
            _output = output;
        }

        // The default, parameterless ToString() method uses 2 sigifnificant digits after the radix point.
        [Theory]
        [InlineData(0, "0 m")]
        [InlineData(0.1, "0.1 m")]
        [InlineData(0.11, "0.11 m")]
        [InlineData(0.111234, "0.11 m")]
        [InlineData(0.115, "0.12 m")]
        public void DefaultToStringFormatting(double value, string expected)
        {
            string actual = Length.FromMeters(value).ToString(LengthUnit.Meter, AmericanCulture);
            Assert.Equal(expected, actual);
        }

        private enum CustomUnit
        {
            // ReSharper disable UnusedMember.Local
            Undefined = 0,
            Unit1,
            Unit2
            // ReSharper restore UnusedMember.Local
        }

        // These cultures all use a comma for the radix point
        [Theory]
        [InlineData("de-DE")]
        [InlineData("da-DK")]
        [InlineData("es-AR")]
        [InlineData("es-ES")]
        [InlineData("it-IT")]
        public void CommaRadixPointCultureFormatting(string culture)
        {
            Assert.Equal("0,12 m", Length.FromMeters(0.12).ToString(LengthUnit.Meter, GetCulture(culture)));
        }

        // These cultures all use a decimal point for the radix point
        [Theory]
        [InlineData("en-CA")]
        [InlineData("en-US")]
        [InlineData("ar-EG")]
        [InlineData("en-GB")]
        [InlineData("es-MX")]
        public void DecimalRadixPointCultureFormatting(string culture)
        {
            Assert.Equal("0.12 m", Length.FromMeters(0.12).ToString(LengthUnit.Meter, GetCulture(culture)));
        }

        // These cultures all use a comma in digit grouping
        [Theory]
        [InlineData("en-CA")]
        [InlineData("en-US")]
        [InlineData("ar-EG")]
        [InlineData("en-GB")]
        [InlineData("es-MX")]
        public void CommaDigitGroupingCultureFormatting(string cultureName)
        {
            CultureInfo culture = GetCulture(cultureName);
            Assert.Equal("1,111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, culture));

            // Feet/Inch and Stone/Pound combinations are only used (customarily) in the US, UK and maybe Ireland - all English speaking countries.
            // FeetInches returns a whole number of feet, with the remainder expressed (rounded) in inches. Same for SonePounds.
            Assert.Equal("2,222 ft 3 in",
                Length.FromFeetInches(2222, 3).FeetInches.ToString(culture));
            Assert.Equal("3,333 st 7 lb",
                Mass.FromStonePounds(3333, 7).StonePounds.ToString(culture));
        }

        // These cultures use a thin space in digit grouping
        [Theory]
        [InlineData("nn-NO")]
        [InlineData("fr-FR")]
        public void SpaceDigitGroupingCultureFormatting(string culture)
        {
            // Note: the space used in digit groupings is actually a "thin space" Unicode character U+2009
            Assert.Equal("1 111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, GetCulture(culture)));
        }

        // These cultures all use a decimal point in digit grouping
        [Theory]
        [InlineData("de-DE")]
        [InlineData("da-DK")]
        [InlineData("es-AR")]
        [InlineData("es-ES")]
        [InlineData("it-IT")]
        public void DecimalPointDigitGroupingCultureFormatting(string culture)
        {
            Assert.Equal("1.111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, GetCulture(culture)));
        }

        [Theory]
        [InlineData(1, "1.1 m")]
        [InlineData(2, "1.12 m")]
        [InlineData(3, "1.123 m")]
        [InlineData(4, "1.1235 m")]
        [InlineData(5, "1.12346 m")]
        [InlineData(6, "1.123457 m")]
        public void CustomNumberOfSignificantDigitsAfterRadixFormatting(int significantDigitsAfterRadix, string expected)
        {
            string actual = Length.FromMeters(1.123456789).ToString(LengthUnit.Meter, AmericanCulture, significantDigitsAfterRadix);
            Assert.Equal(expected, actual);
        }

        // Due to rounding, the values will result in the same string representation regardless of the number of significant digits (up to a certain point)
        [Theory]
        [InlineData(0.819999999999, 2, "0.82 m")]
        [InlineData(0.819999999999, 4, "0.82 m")]
        [InlineData(0.00299999999, 2, "0.003 m")]
        [InlineData(0.00299999999, 4, "0.003 m")]
        [InlineData(0.0003000001, 2, "3e-04 m")]
        [InlineData(0.0003000001, 4, "3e-04 m")]
        public void RoundingErrorsWithSignificantDigitsAfterRadixFormatting(double value,
            int maxSignificantDigitsAfterRadix, string expected)
        {
            string actual = Length.FromMeters(value).ToString(LengthUnit.Meter, AmericanCulture, maxSignificantDigitsAfterRadix);
            Assert.Equal(expected, actual);
        }

        // Any value in the interval (-inf ≤ x < 1e-03] is formatted in scientific notation
        [Theory]
        [InlineData(double.MinValue, "-1.8e+308 m")]
        [InlineData(1.23e-120, "1.23e-120 m")]
        [InlineData(0.0000111, "1.11e-05 m")]
        [InlineData(1.99e-4, "1.99e-04 m")]
        public void ScientificNotationLowerInterval(double value, string expected)
        {
            string actual = Length.FromMeters(value).ToString(LengthUnit.Meter, AmericanCulture);
            Assert.Equal(expected, actual);
        }

        // Any value in the interval [1e-03 ≤ x < 1e+03] is formatted in fixed point notation.
        [Theory]
        [InlineData(1e-3, "0.001 m")]
        [InlineData(1.1, "1.1 m")]
        [InlineData(999.99, "999.99 m")]
        public void FixedPointNotationIntervalFormatting(double value, string expected)
        {
            string actual = Length.FromMeters(value).ToString(LengthUnit.Meter, AmericanCulture);
            Assert.Equal(expected, actual);
        }

        // Any value in the interval [1e+03 ≤ x < 1e+06] is formatted in fixed point notation with digit grouping.
        [Theory]
        [InlineData(1000, "1,000 m")]
        [InlineData(11000, "11,000 m")]
        [InlineData(111000, "111,000 m")]
        [InlineData(999999.99, "999,999.99 m")]
        public void FixedPointNotationWithDigitGroupingIntervalFormatting(double value, string expected)
        {
            string actual = Length.FromMeters(value).ToString(LengthUnit.Meter, AmericanCulture);
            Assert.Equal(expected, actual);
        }

        // Any value in the interval [1e+06 ≤ x ≤ +inf) is formatted in scientific notation.
        [Theory]
        [InlineData(1e6, "1e+06 m")]
        [InlineData(11100000, "1.11e+07 m")]
        [InlineData(double.MaxValue, "1.8e+308 m")]
        public void ScientificNotationUpperIntervalFormatting(double value, string expected)
        {
            string actual = Length.FromMeters(value).ToString(LengthUnit.Meter, AmericanCulture);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllUnitsImplementToStringForInvariantCulture()
        {
            Assert.Equal("1 °", Angle.FromDegrees(1).ToString());
            Assert.Equal("1 m²", Area.FromSquareMeters(1).ToString());
            Assert.Equal("1 V", ElectricPotential.FromVolts(1).ToString());
            Assert.Equal("1 N", Force.FromNewtons(1).ToString());
            Assert.Equal("1 m", Length.FromMeters(1).ToString());
            Assert.Equal("1 kg", Mass.FromKilograms(1).ToString());
            Assert.Equal("1 Pa", Pressure.FromPascals(1).ToString());
            Assert.Equal("1 rad/s", RotationalSpeed.FromRadiansPerSecond(1).ToString());
            Assert.Equal("1 K", Temperature.FromKelvins(1).ToString());
            Assert.Equal("1 N·m", Torque.FromNewtonMeters(1).ToString());
            Assert.Equal("1 m³", Volume.FromCubicMeters(1).ToString());
            Assert.Equal("1 m³/s", VolumeFlow.FromCubicMetersPerSecond(1).ToString());

            Assert.Equal("2 ft 3 in", Length.FromFeetInches(2, 3).FeetInches.ToString());
            Assert.Equal("3 st 7 lb", Mass.FromStonePounds(3, 7).StonePounds.ToString());
        }

        [Fact]
        public void ToString_WithNorwegianCulture()
        {
            Assert.Equal("1 °", Angle.FromDegrees(1).ToString(AngleUnit.Degree, NorwegianCulture));
            Assert.Equal("1 m²", Area.FromSquareMeters(1).ToString(AreaUnit.SquareMeter, NorwegianCulture));
            Assert.Equal("1 V", ElectricPotential.FromVolts(1).ToString(ElectricPotentialUnit.Volt, NorwegianCulture));
            Assert.Equal("1 m³/s", VolumeFlow.FromCubicMetersPerSecond(1).ToString(VolumeFlowUnit.CubicMeterPerSecond, NorwegianCulture));
            Assert.Equal("1 N", Force.FromNewtons(1).ToString(ForceUnit.Newton, NorwegianCulture));
            Assert.Equal("1 m", Length.FromMeters(1).ToString(LengthUnit.Meter, NorwegianCulture));
            Assert.Equal("1 kg", Mass.FromKilograms(1).ToString(MassUnit.Kilogram, NorwegianCulture));
            Assert.Equal("1 Pa", Pressure.FromPascals(1).ToString(PressureUnit.Pascal, NorwegianCulture));
            Assert.Equal("1 rad/s", RotationalSpeed.FromRadiansPerSecond(1).ToString(RotationalSpeedUnit.RadianPerSecond, NorwegianCulture));
            Assert.Equal("1 K", Temperature.FromKelvins(1).ToString(TemperatureUnit.Kelvin, NorwegianCulture));
            Assert.Equal("1 N·m", Torque.FromNewtonMeters(1).ToString(TorqueUnit.NewtonMeter, NorwegianCulture));
            Assert.Equal("1 m³", Volume.FromCubicMeters(1).ToString(VolumeUnit.CubicMeter, NorwegianCulture));
        }

        [Fact]
        public void ToString_WithRussianCulture()
        {
            Assert.Equal("1 °", Angle.FromDegrees(1).ToString(AngleUnit.Degree, RussianCulture));
            Assert.Equal("1 м²", Area.FromSquareMeters(1).ToString(AreaUnit.SquareMeter, RussianCulture));
            Assert.Equal("1 В", ElectricPotential.FromVolts(1).ToString(ElectricPotentialUnit.Volt, RussianCulture));
            Assert.Equal("1 м³/с", VolumeFlow.FromCubicMetersPerSecond(1).ToString(VolumeFlowUnit.CubicMeterPerSecond, RussianCulture));
            Assert.Equal("1 Н", Force.FromNewtons(1).ToString(ForceUnit.Newton, RussianCulture));
            Assert.Equal("1 м", Length.FromMeters(1).ToString(LengthUnit.Meter, RussianCulture));
            Assert.Equal("1 кг", Mass.FromKilograms(1).ToString(MassUnit.Kilogram, RussianCulture));
            Assert.Equal("1 Па", Pressure.FromPascals(1).ToString(PressureUnit.Pascal, RussianCulture));
            Assert.Equal("1 рад/с", RotationalSpeed.FromRadiansPerSecond(1).ToString(RotationalSpeedUnit.RadianPerSecond, RussianCulture));
            Assert.Equal("1 K", Temperature.FromKelvins(1).ToString(TemperatureUnit.Kelvin, RussianCulture));
            Assert.Equal("1 Н·м", Torque.FromNewtonMeters(1).ToString(TorqueUnit.NewtonMeter, RussianCulture));
            Assert.Equal("1 м³", Volume.FromCubicMeters(1).ToString(VolumeUnit.CubicMeter, RussianCulture));
        }

        [Fact]
        public void GetDefaultAbbreviationThrowsNotImplementedExceptionIfNoneExist()
        {
            var unitAbbreviationCache = new UnitAbbreviationsCache();
            Assert.Throws<NotImplementedException>(() => unitAbbreviationCache.GetDefaultAbbreviation(CustomUnit.Unit1));
        }

        [Fact]
        public void GetDefaultAbbreviationFallsBackToUsEnglishCulture()
        {
            var oldCurrentCulture = CultureInfo.CurrentCulture;
            var oldCurrentUICulture = CultureInfo.CurrentUICulture;

            try
            {
                // CurrentCulture affects number formatting, such as comma or dot as decimal separator.
                // CurrentUICulture affects localization, in this case the abbreviation.
                // Zulu (South Africa)
                var zuluCulture = new CultureInfo("zu-ZA");
                CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = zuluCulture;

                UnitAbbreviationsCache.Default.MapUnitToAbbreviation(CustomUnit.Unit1, AmericanCulture, "US english abbreviation for Unit1");

                // Act
                string abbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(CustomUnit.Unit1, zuluCulture);

                // Assert
                Assert.Equal("US english abbreviation for Unit1", abbreviation);
            }
            finally
            {
                CultureInfo.CurrentCulture = oldCurrentCulture;
                CultureInfo.CurrentUICulture = oldCurrentUICulture;
            }
        }

        [Fact]
        public void MapUnitToAbbreviation_AddCustomUnit_DoesNotOverrideDefaultAbbreviationForAlreadyMappedUnits()
        {
            UnitAbbreviationsCache.Default.MapUnitToAbbreviation(AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m²", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(AreaUnit.SquareMeter));
        }

        /// <summary>
        ///     Convenience method to the proper culture parameter type.
        /// </summary>
        private static CultureInfo GetCulture(string cultureName)
        {
            return new CultureInfo(cultureName);
        }
    }
}
