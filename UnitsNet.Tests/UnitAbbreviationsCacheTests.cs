// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
            string actual = Length.FromMeters(value).ToUnit(LengthUnit.Meter).ToString(AmericanCulture);
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
            Assert.Equal("0,12 m", Length.FromMeters(0.12).ToUnit(LengthUnit.Meter).ToString(GetCulture(culture)));
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
            Assert.Equal("0.12 m", Length.FromMeters(0.12).ToUnit(LengthUnit.Meter).ToString(GetCulture(culture)));
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
            Assert.Equal("1,111 m", Length.FromMeters(1111).ToUnit(LengthUnit.Meter).ToString(culture));

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
            Assert.Equal("1 111 m", Length.FromMeters(1111).ToUnit(LengthUnit.Meter).ToString(GetCulture(culture)));
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
            Assert.Equal("1.111 m", Length.FromMeters(1111).ToUnit(LengthUnit.Meter).ToString(GetCulture(culture)));
        }

        // Due to rounding, the values will result in the same string representation regardless of the number of significant digits (up to a certain point)
        [Theory]
        [InlineData(0.819999999999, "s2", "0.82 m")]
        [InlineData(0.819999999999, "s4", "0.82 m")]
        [InlineData(0.00299999999, "s2", "0.003 m")]
        [InlineData(0.00299999999, "s4", "0.003 m")]
        [InlineData(0.0003000001, "s2", "3e-04 m")]
        [InlineData(0.0003000001, "s4", "3e-04 m")]
        public void RoundingErrorsWithSignificantDigitsAfterRadixFormatting(double value,
            string significantDigitsAfterRadixFormatString, string expected)
        {
            string actual = Length.FromMeters(value).ToUnit(LengthUnit.Meter).ToString(significantDigitsAfterRadixFormatString, AmericanCulture);
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
            string actual = Length.FromMeters(value).ToUnit(LengthUnit.Meter).ToString(AmericanCulture);
            Assert.Equal(expected, actual);
        }

        // Any value in the interval [1e-03 ≤ x < 1e+03] is formatted in fixed point notation.
        [Theory]
        [InlineData(1e-3, "0.001 m")]
        [InlineData(1.1, "1.1 m")]
        [InlineData(999.99, "999.99 m")]
        public void FixedPointNotationIntervalFormatting(double value, string expected)
        {
            string actual = Length.FromMeters(value).ToUnit(LengthUnit.Meter).ToString(AmericanCulture);
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
            string actual = Length.FromMeters(value).ToUnit(LengthUnit.Meter).ToString(AmericanCulture);
            Assert.Equal(expected, actual);
        }

        // Any value in the interval [1e+06 ≤ x ≤ +inf) is formatted in scientific notation.
        [Theory]
        [InlineData(1e6, "1e+06 m")]
        [InlineData(11100000, "1.11e+07 m")]
        [InlineData(double.MaxValue, "1.8e+308 m")]
        public void ScientificNotationUpperIntervalFormatting(double value, string expected)
        {
            string actual = Length.FromMeters(value).ToUnit(LengthUnit.Meter).ToString(AmericanCulture);
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
            Assert.Equal("1 °", Angle.FromDegrees(1).ToUnit(AngleUnit.Degree).ToString(NorwegianCulture));
            Assert.Equal("1 m²", Area.FromSquareMeters(1).ToUnit(AreaUnit.SquareMeter).ToString(NorwegianCulture));
            Assert.Equal("1 V", ElectricPotential.FromVolts(1).ToUnit(ElectricPotentialUnit.Volt).ToString(NorwegianCulture));
            Assert.Equal("1 m³/s", VolumeFlow.FromCubicMetersPerSecond(1).ToUnit(VolumeFlowUnit.CubicMeterPerSecond).ToString(NorwegianCulture));
            Assert.Equal("1 N", Force.FromNewtons(1).ToUnit(ForceUnit.Newton).ToString(NorwegianCulture));
            Assert.Equal("1 m", Length.FromMeters(1).ToUnit(LengthUnit.Meter).ToString(NorwegianCulture));
            Assert.Equal("1 kg", Mass.FromKilograms(1).ToUnit(MassUnit.Kilogram).ToString(NorwegianCulture));
            Assert.Equal("1 Pa", Pressure.FromPascals(1).ToUnit(PressureUnit.Pascal).ToString(NorwegianCulture));
            Assert.Equal("1 rad/s", RotationalSpeed.FromRadiansPerSecond(1).ToUnit(RotationalSpeedUnit.RadianPerSecond).ToString(NorwegianCulture));
            Assert.Equal("1 K", Temperature.FromKelvins(1).ToUnit(TemperatureUnit.Kelvin).ToString(NorwegianCulture));
            Assert.Equal("1 N·m", Torque.FromNewtonMeters(1).ToUnit(TorqueUnit.NewtonMeter).ToString(NorwegianCulture));
            Assert.Equal("1 m³", Volume.FromCubicMeters(1).ToUnit(VolumeUnit.CubicMeter).ToString(NorwegianCulture));
        }

        [Fact]
        public void ToString_WithRussianCulture()
        {
            Assert.Equal("1 °", Angle.FromDegrees(1).ToUnit(AngleUnit.Degree).ToString(RussianCulture));
            Assert.Equal("1 м²", Area.FromSquareMeters(1).ToUnit(AreaUnit.SquareMeter).ToString(RussianCulture));
            Assert.Equal("1 В", ElectricPotential.FromVolts(1).ToUnit(ElectricPotentialUnit.Volt).ToString(RussianCulture));
            Assert.Equal("1 м³/с", VolumeFlow.FromCubicMetersPerSecond(1).ToUnit(VolumeFlowUnit.CubicMeterPerSecond).ToString(RussianCulture));
            Assert.Equal("1 Н", Force.FromNewtons(1).ToUnit(ForceUnit.Newton).ToString(RussianCulture));
            Assert.Equal("1 м", Length.FromMeters(1).ToUnit(LengthUnit.Meter).ToString(RussianCulture));
            Assert.Equal("1 кг", Mass.FromKilograms(1).ToUnit(MassUnit.Kilogram).ToString(RussianCulture));
            Assert.Equal("1 Па", Pressure.FromPascals(1).ToUnit(PressureUnit.Pascal).ToString(RussianCulture));
            Assert.Equal("1 рад/с", RotationalSpeed.FromRadiansPerSecond(1).ToUnit(RotationalSpeedUnit.RadianPerSecond).ToString(RussianCulture));
            Assert.Equal("1 K", Temperature.FromKelvins(1).ToUnit(TemperatureUnit.Kelvin).ToString(RussianCulture));
            Assert.Equal("1 Н·м", Torque.FromNewtonMeters(1).ToUnit(TorqueUnit.NewtonMeter).ToString(RussianCulture));
            Assert.Equal("1 м³", Volume.FromCubicMeters(1).ToUnit(VolumeUnit.CubicMeter).ToString(RussianCulture));
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

                var abbreviationsCache = new UnitAbbreviationsCache();
                abbreviationsCache.MapUnitToAbbreviation(CustomUnit.Unit1, AmericanCulture, "US english abbreviation for Unit1");

                // Act
                string abbreviation = abbreviationsCache.GetDefaultAbbreviation(CustomUnit.Unit1, zuluCulture);

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
            var cache = new UnitAbbreviationsCache();
            cache.MapUnitToAbbreviation(AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m²", cache.GetDefaultAbbreviation(AreaUnit.SquareMeter));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_GivenUnitAndCulture_SetsDefaultAbbreviationForUnitAndCulture()
        {
            var cache = new UnitAbbreviationsCache();
            cache.MapUnitToDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m^2", cache.GetDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_GivenCustomAbbreviation_SetsAbbreviationUsedByQuantityToString()
        {
            // Use a distinct culture here so that we don't mess up other tests that may rely on the default cache.
            var newZealandCulture = GetCulture("en-NZ");
            UnitAbbreviationsCache.Default.MapUnitToDefaultAbbreviation(AreaUnit.SquareMeter, newZealandCulture, "m^2");

            Assert.Equal("1 m^2", Area.FromSquareMeters(1).ToString(newZealandCulture));
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
