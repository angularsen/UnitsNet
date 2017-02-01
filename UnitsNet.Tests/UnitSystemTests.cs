// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
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
using System.Threading;
using NUnit.Framework;
using UnitsNet.Units;

#if WINDOWS_UWP
using Culture=System.String;
#else
using Culture=System.IFormatProvider;
#endif

namespace UnitsNet.Tests
{
    [TestFixture]
    public class UnitSystemTests
    {
        [SetUp]
        public void Setup()
        {
            // We want to have a consistent test setup without being affected by the environment we are running in.
            // These tests will fail if this is not done:
            // PositiveInfinityFormatting
            // NegativeInfinityFormatting
            _originalUiCulture = Thread.CurrentThread.CurrentUICulture;
            _originalCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TearDown]
        public void Teardown()
        {
            Thread.CurrentThread.CurrentUICulture = _originalUiCulture;
            Thread.CurrentThread.CurrentCulture = _originalCulture;
        }

        private CultureInfo _originalCulture;
        private CultureInfo _originalUiCulture;

        // The default, parameterless ToString() method uses 2 sigifnificant digits after the radix point.
        [TestCase(0, Result = "0 m")]
        [TestCase(0.1, Result = "0.1 m")]
        [TestCase(0.11, Result = "0.11 m")]
        [TestCase(0.111234, Result = "0.11 m")]
        [TestCase(0.115, Result = "0.12 m")]
        public string DefaultToStringFormatting(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        private enum CustomUnit
        {
            // ReSharper disable UnusedMember.Local
            Undefined = 0,
            Unit1,
            Unit2
            // ReSharper restore UnusedMember.Local
        }

        private UnitSystem GetCachedUnitSystem()
        {
            Culture culture = GetCulture("en-US");
            UnitSystem unitSystem = UnitSystem.GetCached(culture);
            return unitSystem;
        }

        private static IEnumerable<object> GetUnitTypesWithMissingAbbreviations<TUnit>(string cultureName,
            IEnumerable<TUnit> unitValues)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            UnitSystem unitSystem = UnitSystem.GetCached(GetCulture(cultureName));

            var unitsMissingAbbreviations = new List<TUnit>();
            foreach (TUnit unit in unitValues)
            {
                try
                {
#if WINDOWS_UWP
                    unitSystem.GetDefaultAbbreviation(unit.GetType(), Convert.ToInt32(unit));
#else
                    unitSystem.GetDefaultAbbreviation(unit);
#endif
                }
                catch
                {
                    unitsMissingAbbreviations.Add(unit);
                }
            }

            return unitsMissingAbbreviations.Cast<object>();
        }

        // These cultures all use a comma for the radix point
        [TestCase("de-DE")]
        [TestCase("da-DK")]
        [TestCase("es-AR")]
        [TestCase("es-ES")]
        [TestCase("it-IT")]
        public void CommaRadixPointCultureFormatting(string culture)
        {
            Assert.AreEqual("0,12 m", Length.FromMeters(0.12).ToString(LengthUnit.Meter, GetCulture(culture)));
        }

        // These cultures all use a decimal point for the radix point
        [TestCase("en-CA")]
        [TestCase("en-US")]
        [TestCase("ar-EG")]
        [TestCase("en-GB")]
        [TestCase("es-MX")]
        public void DecimalRadixPointCultureFormatting(string culture)
        {
            Assert.AreEqual("0.12 m", Length.FromMeters(0.12).ToString(LengthUnit.Meter, GetCulture(culture)));
        }

        // These cultures all use a comma in digit grouping
        [TestCase("en-CA")]
        [TestCase("en-US")]
        [TestCase("ar-EG")]
        [TestCase("en-GB")]
        [TestCase("es-MX")]
        public void CommaDigitGroupingCultureFormatting(string cultureName)
        {
            Culture culture = GetCulture(cultureName);
            Assert.AreEqual("1,111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, culture));

            // Feet/Inch and Stone/Pound combinations are only used (customarily) in the US, UK and maybe Ireland - all English speaking countries.
            // FeetInches returns a whole number of feet, with the remainder expressed (rounded) in inches. Same for SonePounds.
            Assert.AreEqual("2,222 ft 3 in",
                Length.FromFeetInches(2222, 3).FeetInches.ToString(culture));
            Assert.AreEqual("3,333 st 7 lb",
                Mass.FromStonePounds(3333, 7).StonePounds.ToString(culture));
        }

        // These cultures use a thin space in digit grouping
        [TestCase("nn-NO")]
        [TestCase("fr-FR")]
        public void SpaceDigitGroupingCultureFormatting(string culture)
        {
            // Note: the space used in digit groupings is actually a "thin space" Unicode character U+2009
            Assert.AreEqual("1 111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, GetCulture(culture)));
        }

        // Switzerland uses an apostrophe for digit grouping
//        [Ignore("Fails on Win 8.1 and Win10 due to a bug in .NET framework.")]
//        [TestCase("fr-CH")]
//        public void ApostropheDigitGroupingCultureFormatting(string culture)
//        {
//            Assert.AreEqual("1'111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, new CultureInfo(culture)));
//        }

        // These cultures all use a decimal point in digit grouping
        [TestCase("de-DE")]
        [TestCase("da-DK")]
        [TestCase("es-AR")]
        [TestCase("es-ES")]
        [TestCase("it-IT")]
        public void DecimalPointDigitGroupingCultureFormatting(string culture)
        {
            Assert.AreEqual("1.111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, GetCulture(culture)));
        }

#if !WINDOWS_UWP
        [TestCase("m^2", Result = AreaUnit.SquareMeter)]
        [TestCase("cm^2", Result = AreaUnit.Undefined)]
        public AreaUnit Parse_ReturnsUnitMappedByCustomAbbreviationOrUndefined(string unitAbbreviationToParse)
        {
            UnitSystem unitSystem = GetCachedUnitSystem();
            unitSystem.MapUnitToAbbreviation(AreaUnit.SquareMeter, "m^2");
            return unitSystem.Parse<AreaUnit>(unitAbbreviationToParse);
        }
#endif

        [TestCase(1, Result = "1.1 m")]
        [TestCase(2, Result = "1.12 m")]
        [TestCase(3, Result = "1.123 m")]
        [TestCase(4, Result = "1.1235 m")]
        [TestCase(5, Result = "1.12346 m")]
        [TestCase(6, Result = "1.123457 m")]
        public string CustomNumberOfSignificantDigitsAfterRadixFormatting(int significantDigitsAfterRadix)
        {
            return Length.FromMeters(1.123456789).ToString(LengthUnit.Meter, null, significantDigitsAfterRadix);
        }

        // Due to rounding, the values will result in the same string representation regardless of the number of significant digits (up to a certain point)
        [TestCase(0.819999999999, 2, Result = "0.82 m")]
        [TestCase(0.819999999999, 4, Result = "0.82 m")]
        [TestCase(0.00299999999, 2, Result = "0.003 m")]
        [TestCase(0.00299999999, 4, Result = "0.003 m")]
        [TestCase(0.0003000001, 2, Result = "3e-04 m")]
        [TestCase(0.0003000001, 4, Result = "3e-04 m")]
        public string RoundingErrorsWithSignificantDigitsAfterRadixFormatting(double value,
            int maxSignificantDigitsAfterRadix)
        {
            return Length.FromMeters(value).ToString(LengthUnit.Meter, null, maxSignificantDigitsAfterRadix);
        }

        // Any value in the interval (-inf ≤ x < 1e-03] is formatted in scientific notation
        [TestCase(double.MinValue, Result = "-1.8e+308 m")]
        [TestCase(1.23e-120, Result = "1.23e-120 m")]
        [TestCase(0.0000111, Result = "1.11e-05 m")]
        [TestCase(1.99e-4, Result = "1.99e-04 m")]
        public string ScientificNotationLowerInterval(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        // Any value in the interval [1e-03 ≤ x < 1e+03] is formatted in fixed point notation.
        [TestCase(1e-3, Result = "0.001 m")]
        [TestCase(1.1, Result = "1.1 m")]
        [TestCase(999.99, Result = "999.99 m")]
        public string FixedPointNotationIntervalFormatting(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        // Any value in the interval [1e+03 ≤ x < 1e+06] is formatted in fixed point notation with digit grouping.
        [TestCase(1000, Result = "1,000 m")]
        [TestCase(11000, Result = "11,000 m")]
        [TestCase(111000, Result = "111,000 m")]
        [TestCase(999999.99, Result = "999,999.99 m")]
        public string FixedPointNotationWithDigitGroupingIntervalFormatting(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        // Any value in the interval [1e+06 ≤ x ≤ +inf) is formatted in scientific notation.
        [TestCase(1e6, Result = "1e+06 m")]
        [TestCase(11100000, Result = "1.11e+07 m")]
        [TestCase(double.MaxValue, Result = "1.8e+308 m")]
        public string ScientificNotationUpperIntervalFormatting(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        [Test]
        public void ShouldUseCorrectMicroSign()
        {
            // "\u00b5" = Micro sign
            Assert.AreEqual(AccelerationUnit.MicrometerPerSecondSquared, Acceleration.ParseUnit("\u00b5m/s²"));
            Assert.AreEqual(AmplitudeRatioUnit.DecibelMicrovolt, AmplitudeRatio.ParseUnit("dB\u00b5V"));
            Assert.AreEqual(AngleUnit.Microdegree, Angle.ParseUnit("\u00b5°"));
            Assert.AreEqual(AngleUnit.Microradian, Angle.ParseUnit("\u00b5rad"));
            Assert.AreEqual(AreaUnit.SquareMicrometer, Area.ParseUnit("\u00b5m²"));
            Assert.AreEqual(DurationUnit.Microsecond, Duration.ParseUnit("\u00b5s"));
            Assert.AreEqual(ElectricCurrentUnit.Microampere, ElectricCurrent.ParseUnit("\u00b5A"));
            Assert.AreEqual(ElectricPotentialUnit.Microvolt, ElectricPotential.ParseUnit("\u00b5V"));
            Assert.AreEqual(FlowUnit.MicrolitersPerMinute, Flow.ParseUnit("\u00b5LPM"));
            Assert.AreEqual(ForceChangeRateUnit.MicronewtonPerSecond, ForceChangeRate.ParseUnit("\u00b5N/s"));
            Assert.AreEqual(ForcePerLengthUnit.MicronewtonPerMeter, ForcePerLength.ParseUnit("\u00b5N/m"));
            Assert.AreEqual(KinematicViscosityUnit.Microstokes, KinematicViscosity.ParseUnit("\u00b5St"));
            Assert.AreEqual(LengthUnit.Microinch, Length.ParseUnit("\u00b5in"));
            Assert.AreEqual(LengthUnit.Micrometer, Length.ParseUnit("\u00b5m"));
            Assert.AreEqual(MassFlowUnit.MicrogramPerSecond, MassFlow.ParseUnit("\u00b5g/S"));
            Assert.AreEqual(MassUnit.Microgram, Mass.ParseUnit("\u00b5g"));
            Assert.AreEqual(PowerUnit.Microwatt, Power.ParseUnit("\u00b5W"));
            Assert.AreEqual(PressureUnit.Micropascal, Pressure.ParseUnit("\u00b5Pa"));
            Assert.AreEqual(RotationalSpeedUnit.MicrodegreePerSecond, RotationalSpeed.ParseUnit("\u00b5°/s"));
            Assert.AreEqual(RotationalSpeedUnit.MicroradianPerSecond, RotationalSpeed.ParseUnit("\u00b5rad/s"));
            Assert.AreEqual(SpeedUnit.MicrometerPerMinute, Speed.ParseUnit("\u00b5m/min"));
            Assert.AreEqual(SpeedUnit.MicrometerPerSecond, Speed.ParseUnit("\u00b5m/s"));
            Assert.AreEqual(TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond, TemperatureChangeRate.ParseUnit("\u00b5°C/s"));
            Assert.AreEqual(VolumeUnit.Microliter, Volume.ParseUnit("\u00b5l"));
            Assert.AreEqual(VolumeUnit.CubicMicrometer, Volume.ParseUnit("\u00b5m³"));

            // "\u03bc" = Lower case greek letter 'Mu' 
            Assert.Throws<UnitsNetException>(() => Acceleration.ParseUnit("\u03bcm/s²"));
            Assert.Throws<UnitsNetException>(() => AmplitudeRatio.ParseUnit("dB\u03bcV"));
            Assert.Throws<UnitsNetException>(() => Angle.ParseUnit("\u03bc°"));
            Assert.Throws<UnitsNetException>(() => Angle.ParseUnit("\u03bcrad"));
            Assert.Throws<UnitsNetException>(() => Area.ParseUnit("\u03bcm²"));
            Assert.Throws<UnitsNetException>(() => Duration.ParseUnit("\u03bcs"));
            Assert.Throws<UnitsNetException>(() => ElectricCurrent.ParseUnit("\u03bcA"));
            Assert.Throws<UnitsNetException>(() => ElectricPotential.ParseUnit("\u03bcV"));
            Assert.Throws<UnitsNetException>(() => Flow.ParseUnit("\u03bcLPM"));
            Assert.Throws<UnitsNetException>(() => ForceChangeRate.ParseUnit("\u03bcN/s"));
            Assert.Throws<UnitsNetException>(() => ForcePerLength.ParseUnit("\u03bcN/m"));
            Assert.Throws<UnitsNetException>(() => KinematicViscosity.ParseUnit("\u03bcSt"));
            Assert.Throws<UnitsNetException>(() => Length.ParseUnit("\u03bcin"));
            Assert.Throws<UnitsNetException>(() => Length.ParseUnit("\u03bcm"));
            Assert.Throws<UnitsNetException>(() => MassFlow.ParseUnit("\u03bcg/S"));
            Assert.Throws<UnitsNetException>(() => Mass.ParseUnit("\u03bcg"));
            Assert.Throws<UnitsNetException>(() => Power.ParseUnit("\u03bcW"));
            Assert.Throws<UnitsNetException>(() => Pressure.ParseUnit("\u03bcPa"));
            Assert.Throws<UnitsNetException>(() => RotationalSpeed.ParseUnit("\u03bc°/s"));
            Assert.Throws<UnitsNetException>(() => RotationalSpeed.ParseUnit("\u03bcrad/s"));
            Assert.Throws<UnitsNetException>(() => Speed.ParseUnit("\u03bcm/min"));
            Assert.Throws<UnitsNetException>(() => Speed.ParseUnit("\u03bcm/s"));
            Assert.Throws<UnitsNetException>(() => TemperatureChangeRate.ParseUnit("\u03bc°C/s"));
            Assert.Throws<UnitsNetException>(() => Volume.ParseUnit("\u03bcl"));
            Assert.Throws<UnitsNetException>(() => Volume.ParseUnit("\u03bcm³"));
        }

        [Test]
        public void AllUnitAbbreviationsImplemented([Values("en-US", "nb-NO", "ru-RU")] string cultureName)
        {
            List<object> unitValuesMissingAbbreviations = new List<object>()
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<AngleUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<AreaUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<DurationUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName,
                    EnumUtils.GetEnumValues<ElectricPotentialUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<FlowUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<ForceUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<LengthUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<MassUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<PressureUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<RotationalSpeedUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<SpeedUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<TemperatureUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<TorqueUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<VolumeUnit>()))
                .ToList();

            // We want to flag if any localizations are missing, but not break the build
            // or flag an error for pull requests. For now they are not considered 
            // critical and it is cumbersome to have a third person review the pull request
            // and add in any translations before merging it in.
            if (unitValuesMissingAbbreviations.Any())
            {
                string message = "Units missing abbreviations: " +
                                 string.Join(", ",
                                     unitValuesMissingAbbreviations.Select(
                                         unitValue => unitValue.GetType().Name + "." + unitValue).ToArray());

                Assert.Inconclusive("Failed, but skipping error for localization: " + message);
            }
            //Assert.IsEmpty(unitsMissingAbbreviations, message);
        }

        [Test]
        public void AllUnitsImplementToStringForInvariantCulture()
        {
            Assert.AreEqual("1 °", Angle.FromDegrees(1).ToString());
            Assert.AreEqual("1 m²", Area.FromSquareMeters(1).ToString());
            Assert.AreEqual("1 V", ElectricPotential.FromVolts(1).ToString());
            Assert.AreEqual("1 m³/s", Flow.FromCubicMetersPerSecond(1).ToString());
            Assert.AreEqual("1 N", Force.FromNewtons(1).ToString());
            Assert.AreEqual("1 m", Length.FromMeters(1).ToString());
            Assert.AreEqual("1 kg", Mass.FromKilograms(1).ToString());
            Assert.AreEqual("1 Pa", Pressure.FromPascals(1).ToString());
            Assert.AreEqual("1 rad/s", RotationalSpeed.FromRadiansPerSecond(1).ToString());
            Assert.AreEqual("1 K", Temperature.FromKelvins(1).ToString());
            Assert.AreEqual("1 N·m", Torque.FromNewtonMeters(1).ToString());
            Assert.AreEqual("1 m³", Volume.FromCubicMeters(1).ToString());

            Assert.AreEqual("2 ft 3 in", Length.FromFeetInches(2, 3).FeetInches.ToString());
            Assert.AreEqual("3 st 7 lb", Mass.FromStonePounds(3, 7).StonePounds.ToString());
        }

        [Test]
        public void AllUnitsImplementToStringForNorwegian()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("nb-NO");

            Assert.AreEqual("1 °", Angle.FromDegrees(1).ToString());
            Assert.AreEqual("1 m²", Area.FromSquareMeters(1).ToString());
            Assert.AreEqual("1 V", ElectricPotential.FromVolts(1).ToString());
            Assert.AreEqual("1 m³/s", Flow.FromCubicMetersPerSecond(1).ToString());
            Assert.AreEqual("1 N", Force.FromNewtons(1).ToString());
            Assert.AreEqual("1 m", Length.FromMeters(1).ToString());
            Assert.AreEqual("1 kg", Mass.FromKilograms(1).ToString());
            Assert.AreEqual("1 Pa", Pressure.FromPascals(1).ToString());
            Assert.AreEqual("1 rad/s", RotationalSpeed.FromRadiansPerSecond(1).ToString());
            Assert.AreEqual("1 K", Temperature.FromKelvins(1).ToString());
            Assert.AreEqual("1 N·m", Torque.FromNewtonMeters(1).ToString());
            Assert.AreEqual("1 m³", Volume.FromCubicMeters(1).ToString());
        }

        [Test]
        public void AllUnitsImplementToStringForRussian()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

            Assert.AreEqual("1 °", Angle.FromDegrees(1).ToString());
            Assert.AreEqual("1 м²", Area.FromSquareMeters(1).ToString());
            Assert.AreEqual("1 В", ElectricPotential.FromVolts(1).ToString());
            Assert.AreEqual("1 м³/с", Flow.FromCubicMetersPerSecond(1).ToString());
            Assert.AreEqual("1 Н", Force.FromNewtons(1).ToString());
            Assert.AreEqual("1 м", Length.FromMeters(1).ToString());
            Assert.AreEqual("1 кг", Mass.FromKilograms(1).ToString());
            Assert.AreEqual("1 Па", Pressure.FromPascals(1).ToString());
            Assert.AreEqual("1 рад/с", RotationalSpeed.FromRadiansPerSecond(1).ToString());
            Assert.AreEqual("1 K", Temperature.FromKelvins(1).ToString());
            Assert.AreEqual("1 Н·м", Torque.FromNewtonMeters(1).ToString());
            Assert.AreEqual("1 м³", Volume.FromCubicMeters(1).ToString());
        }

        [Test]
        public void GetDefaultAbbreviationFallsBackToDefaultStringIfNotSpecified()
        {
            UnitSystem usUnits = UnitSystem.GetCached(GetCulture("en-US"));

#if WINDOWS_UWP
            string abbreviation = usUnits.GetDefaultAbbreviation(typeof(CustomUnit), (int)CustomUnit.Unit1);
            Assert.AreEqual("(no abbreviation for CustomUnit with numeric value 1)", abbreviation);
#else
            string abbreviation = usUnits.GetDefaultAbbreviation(CustomUnit.Unit1);
            Assert.AreEqual("(no abbreviation for CustomUnit.Unit1)", abbreviation);
#endif
        }

#if !WINDOWS_UWP
        [Test]
        public void GetDefaultAbbreviationFallsBackToUsEnglishCulture()
        {
            // CurrentCulture affects number formatting, such as comma or dot as decimal separator.
            // CurrentUICulture affects localization, in this case the abbreviation.
            // Zulu (South Africa)
            CultureInfo zuluCulture = CultureInfo.GetCultureInfo("zu-ZA");
            UnitSystem zuluUnits = UnitSystem.GetCached(zuluCulture);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = zuluCulture;

            UnitSystem usUnits = UnitSystem.GetCached(CultureInfo.GetCultureInfo("en-US"));
            usUnits.MapUnitToAbbreviation(CustomUnit.Unit1, "US english abbreviation for Unit1");

            // Act
            string abbreviation = zuluUnits.GetDefaultAbbreviation(CustomUnit.Unit1);

            // Assert
            Assert.AreEqual("US english abbreviation for Unit1", abbreviation);
        }
#endif

#if !WINDOWS_UWP
        [Test]
        public void MapUnitToAbbreviation_AddCustomUnit_DoesNotOverrideDefaultAbbreviationForAlreadyMappedUnits()
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");
            UnitSystem unitSystem = UnitSystem.GetCached(cultureInfo);
            unitSystem.MapUnitToAbbreviation(AreaUnit.SquareMeter, "m^2");

            Assert.AreEqual("m²", unitSystem.GetDefaultAbbreviation(AreaUnit.SquareMeter));
        }
#endif

        [Test]
        public void NegativeInfinityFormatting()
        {
            Assert.That(Length.FromMeters(double.NegativeInfinity).ToString(),
                Is.EqualTo("-Infinity m"));
        }

        [Test]
        public void NotANumberFormatting()
        {
            Assert.That(Length.FromMeters(double.NaN).ToString(),
                Is.EqualTo("NaN m"));
        }

#if !WINDOWS_UWP
        [Test]
        public void Parse_AmbiguousUnitsThrowsException()
        {
            UnitSystem unitSystem = GetCachedUnitSystem();

            // Act 1
            Assert.Throws<AmbiguousUnitParseException>(() => unitSystem.Parse<VolumeUnit>("tsp"));

            // Act 2
            Assert.Throws<AmbiguousUnitParseException>(() => Volume.Parse("1 tsp"));
        }
#endif

        [Test]
        public void Parse_UnambiguousUnitsDoesNotThrow()
        {
            Volume unit = Volume.Parse("1 l");

            Assert.AreEqual(Volume.FromLiters(1), unit);
        }

        [Test]
        public void PositiveInfinityFormatting()
        {
            Assert.That(Length.FromMeters(double.PositiveInfinity).ToString(),
                Is.EqualTo("Infinity m"));
        }

        /// <summary>
        ///     Convenience method to use the proper culture parameter type.
        ///     The UWP lib uses culture name string instead of CultureInfo.
        /// </summary>
        private static Culture GetCulture(string cultureName)
        {
#if WINDOWS_UWP
            return cultureName;
#else
            return new CultureInfo(cultureName);
#endif
        }
    }
}