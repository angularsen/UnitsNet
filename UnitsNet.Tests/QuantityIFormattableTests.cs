// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityIFormattableTests
    {
        private static readonly Length MyLength = Length.FromFeet(1.2345678);
        
        private static readonly CultureInfo AmericanCulture = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo NorwegianCulture = CultureInfo.GetCultureInfo("nb-NO");
        private static readonly CultureInfo RussianCulture = CultureInfo.GetCultureInfo("ru-RU");

        [Fact]
        public void FormattingApisIdentifyNumericFormatSyntax()
        {
            MethodInfo quantityToString = typeof(Length).GetMethod(
                nameof(Length.ToString),
                [typeof(string), typeof(IFormatProvider)])!;
            MethodInfo quantityValueToString = typeof(QuantityValue).GetMethod(
                nameof(QuantityValue.ToString),
                [typeof(string), typeof(IFormatProvider)])!;
            MethodInfo formatter = typeof(QuantityFormatter)
                .GetMethods()
                .Single(method => method.Name == nameof(QuantityFormatter.Format) && method is { IsStatic: false, IsGenericMethod: true });

            AssertNumericFormat(quantityToString.GetParameters()[0]);
            AssertNumericFormat(quantityValueToString.GetParameters()[0]);
            AssertNumericFormat(formatter.GetParameters()[1]);
            Assert.Equal(
                StringSyntaxAttribute.NumericFormat,
                typeof(DisplayAsUnitAttribute).GetProperty(nameof(DisplayAsUnitAttribute.Format))!
                    .GetCustomAttribute<StringSyntaxAttribute>()?.Syntax);
        }

        private static void AssertNumericFormat(ParameterInfo parameter)
        {
            StringSyntaxAttribute? syntax = parameter.GetCustomAttribute<StringSyntaxAttribute>();
            Assert.Equal(StringSyntaxAttribute.NumericFormat, syntax?.Syntax);
        }

        [Fact]
        public void GFormatStringEqualsToString()
        {
            Assert.Equal(MyLength.ToString("G"), MyLength.ToString());
        }

        [Fact]
        public void EmptyOrNullFormatStringEqualsGFormat()
        {
            Assert.Equal(MyLength.ToString("G"), MyLength.ToString(format: string.Empty));
            Assert.Equal(MyLength.ToString("G"), MyLength.ToString(format: null!));
        }

        [Fact]
        public void ExplicitAbbreviationApisReplaceAFormat()
        {
            UnitAbbreviationsCache abbreviations = UnitsNetSetup.Default.UnitAbbreviations;

            Assert.Equal("ft", Length.GetAbbreviation(MyLength.Unit, CultureInfo.InvariantCulture));
            Assert.Equal("ft", abbreviations.GetDefaultAbbreviation(MyLength.Unit, CultureInfo.InvariantCulture));
            Assert.Equal(
                ["ft", "'", "′"],
                abbreviations.GetUnitAbbreviations(MyLength.Unit, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("A0")]
        [InlineData("s")]
        [InlineData("S2")]
        public void RemovedQuantitySpecificFormatThrowsWithMigrationGuidance(string format)
        {
            FormatException exception = Assert.Throws<FormatException>(
                () => MyLength.ToString(format, CultureInfo.InvariantCulture));

            Assert.Contains("no longer supported", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public void UnsupportedFormatStringThrowsException()
        {
            Assert.Throws<FormatException>(() => MyLength.ToString("z"));
        }
        
        // The default, parameterless ToString() method represents the result with all significant digits, without a group separator.
        [Theory]
        #if NET
        [InlineData(double.MinValue, "-1.797693134862315E+308 m")]
        #else
        [InlineData(double.MinValue, "-1.79769313486232E+308 m")]
        #endif
        [InlineData(-0.819999999999, "-0.819999999999 m")]
        [InlineData(-0.111234, "-0.111234 m")]
        [InlineData(-0.1, "-0.1 m")]
        [InlineData(-0.0000012345, "-1.2345E-06 m")]
        [InlineData(-0.000001, "-1E-06 m")]
        [InlineData(0, "0 m")]
        [InlineData(0.000001, "1E-06 m")]
        [InlineData(0.0000012345, "1.2345E-06 m")]
        [InlineData(0.1, "0.1 m")]
        [InlineData(0.111234, "0.111234 m")]
        [InlineData(0.819999999999, "0.819999999999 m")]
        #if NET
        [InlineData(double.MaxValue, "1.797693134862315E+308 m")]
        #else
        [InlineData(double.MaxValue, "1.79769313486232E+308 m")]
        #endif
        public void DefaultToStringFormatting(double value, string expected)
        {
            string actual = Length.FromMeters(value).ToString(AmericanCulture);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("de-DE")]
        [InlineData("da-DK")]
        [InlineData("es-AR")]
        [InlineData("es-ES")]
        [InlineData("it-IT")]
        [InlineData("en-CA")]
        [InlineData("en-US")]
        [InlineData("ar-EG")]
        [InlineData("en-GB")]
        [InlineData("es-MX")]
        public void RadixPointCultureFormatting(string cultureName)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);
            string ds = culture.NumberFormat.NumberDecimalSeparator;
            Assert.Equal($"0{ds}12 m", Length.FromMeters(0.12).ToString(culture));
        }

        [Theory]
        [InlineData("en-CA")]
        [InlineData("en-GB")]
        [InlineData("en-US")]
        [InlineData("ar-EG")]
        [InlineData("es-MX")]
        [InlineData("nn-NO")]
        [InlineData("fr-FR")]
        [InlineData("de-DE")]
        [InlineData("da-DK")]
        [InlineData("es-AR")]
        [InlineData("es-ES")]
        [InlineData("it-IT")]
        public void ToString_WithCultureWithoutGroupingSeparator(string cultureName)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);
            Assert.Equal("1111 m", Length.FromMeters(1111).ToString(culture));
        }

        [Theory]
        [InlineData("en-CA")]
        [InlineData("en-GB")]
        [InlineData("en-US")]
        [InlineData("ar-EG")]
        [InlineData("es-MX")]
        [InlineData("nn-NO")]
        [InlineData("fr-FR")]
        [InlineData("de-DE")]
        [InlineData("da-DK")]
        [InlineData("es-AR")]
        [InlineData("es-ES")]
        [InlineData("it-IT")]
        public void FeetInches_UseGroupingSeparator_ForCulture(string cultureName)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);
            string gs = culture.NumberFormat.NumberGroupSeparator;
            
            // Feet/Inch and Stone/Pound combinations are only used (customarily) in the US, UK and maybe Ireland - all English speaking countries.
            // FeetInches returns a whole number of feet, with the remainder expressed (rounded) in inches. Same for StonePounds.
            Assert.Equal($"3{gs}333 st 7 lb", Mass.FromStonePounds(3333, 7).StonePounds.ToString(culture));
        }

        [Theory]
        [InlineData("en-CA")]
        [InlineData("en-GB")]
        [InlineData("en-US")]
        [InlineData("ar-EG")]
        [InlineData("es-MX")]
        [InlineData("nn-NO")]
        [InlineData("fr-FR")]
        [InlineData("de-DE")]
        [InlineData("da-DK")]
        [InlineData("es-AR")]
        [InlineData("es-ES")]
        [InlineData("it-IT")]
        public void StonePounds_UseGroupingSeparator_ForCulture(string cultureName)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);
            string gs = culture.NumberFormat.NumberGroupSeparator;
            
            // Feet/Inch and Stone/Pound combinations are only used (customarily) in the US, UK and maybe Ireland - all English speaking countries.
            // FeetInches returns a whole number of feet, with the remainder expressed (rounded) in inches. Same for StonePounds.
            Assert.Equal($"3{gs}333 st 7 lb", Mass.FromStonePounds(3333, 7).StonePounds.ToString(culture));
        }
        
        [Fact]
        public void AllUnitsImplementToStringForInvariantCulture()
        {
            Assert.Equal("1 °", Angle.FromDegrees(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 m²", Area.FromSquareMeters(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 V", ElectricPotential.FromVolts(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 N", Force.FromNewtons(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 m", Length.FromMeters(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 kg", Mass.FromKilograms(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 Pa", Pressure.FromPascals(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 rad/s", RotationalSpeed.FromRadiansPerSecond(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 K", Temperature.FromKelvins(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 N·m", Torque.FromNewtonMeters(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 m³", Volume.FromCubicMeters(1).ToString(CultureInfo.InvariantCulture));
            Assert.Equal("1 m³/s", VolumeFlow.FromCubicMetersPerSecond(1).ToString(CultureInfo.InvariantCulture));

            Assert.Equal("2 ft 3 in", Length.FromFeetInches(2, 3).FeetInches.ToString(CultureInfo.InvariantCulture));
            Assert.Equal("3 st 7 lb", Mass.FromStonePounds(3, 7).StonePounds.ToString(CultureInfo.InvariantCulture));
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
    }
}
