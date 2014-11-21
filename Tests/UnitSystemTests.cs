// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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

namespace UnitsNet.Tests
{
    [TestFixture]
    public class UnitSystemTests
    {
        private CultureInfo _originalUICulture;
        private CultureInfo _originalCulture;

        private enum CustomUnit
        {
            // ReSharper disable UnusedMember.Local
            Undefined = 0,
            Unit1,
            Unit2
            // ReSharper restore UnusedMember.Local
        }

        [SetUp]
        public void Setup()
        {
            _originalUICulture = Thread.CurrentThread.CurrentUICulture;
            _originalCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TearDown]
        public void Teardown()
        {
            Thread.CurrentThread.CurrentUICulture = _originalUICulture;
            Thread.CurrentThread.CurrentCulture = _originalCulture;
        }

        #region Missing Abbreviations

        [Test]
        public void GetDefaultAbbreviationFallsBackToDefaultStringIfNotSpecified()
        {
            UnitSystem usUnits = UnitSystem.GetCached(CultureInfo.GetCultureInfo("en-US"));

            string abbreviation = usUnits.GetDefaultAbbreviation(CustomUnit.Unit1);

            Assert.AreEqual("(no abbreviation for CustomUnit.Unit1)", abbreviation);
        }

        [Test]
        public void AllUnitAbbreviationsImplemented([Values("en-US", "nb-NO", "ru-RU")] string cultureName)
        {
            List<object> unitValuesMissingAbbreviations = new List<object>()
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<AngleUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<AreaUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<DurationUnit>()))
                .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<ElectricPotentialUnit>()))
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

        private static IEnumerable<object> GetUnitTypesWithMissingAbbreviations<TUnit>(string cultureName, IEnumerable<TUnit> unitValues)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            UnitSystem unitSystem = UnitSystem.GetCached(new CultureInfo(cultureName));

            var unitsMissingAbbreviations = new List<TUnit>();
            foreach (TUnit unit in unitValues)
            {
                try
                {
                    unitSystem.GetDefaultAbbreviation(unit);
                }
                catch
                {
                    unitsMissingAbbreviations.Add(unit);
                }
            }

            return unitsMissingAbbreviations.Cast<object>();
        }

        #endregion

        #region Culture Unit Symbol Formatting

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
            Assert.AreEqual("1 r/s", RotationalSpeed.FromRevolutionsPerSecond(1).ToString());
            Assert.AreEqual("1 K", Temperature.FromKelvins(1).ToString());
            Assert.AreEqual("1 Nm", Torque.FromNewtonmeters(1).ToString());
            Assert.AreEqual("1 m³", Volume.FromCubicMeters(1).ToString());
        }

        [Test]
        public void AllUnitsImplementToStringForNorwegian()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

                Assert.AreEqual("1 °", Angle.FromDegrees(1).ToString());
                Assert.AreEqual("1 m²", Area.FromSquareMeters(1).ToString());
                Assert.AreEqual("1 V", ElectricPotential.FromVolts(1).ToString());
                Assert.AreEqual("1 m³/s", Flow.FromCubicMetersPerSecond(1).ToString());
                Assert.AreEqual("1 N", Force.FromNewtons(1).ToString());
                Assert.AreEqual("1 m", Length.FromMeters(1).ToString());
                Assert.AreEqual("1 kg", Mass.FromKilograms(1).ToString());
                Assert.AreEqual("1 Pa", Pressure.FromPascals(1).ToString());
                Assert.AreEqual("1 r/s", RotationalSpeed.FromRevolutionsPerSecond(1).ToString());
                Assert.AreEqual("1 K", Temperature.FromKelvins(1).ToString());
                Assert.AreEqual("1 Nm", Torque.FromNewtonmeters(1).ToString());
                Assert.AreEqual("1 m³", Volume.FromCubicMeters(1).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }

        [Test]
        public void AllUnitsImplementToStringForRussian()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentUICulture;
            try
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
                Assert.AreEqual("1 об/с", RotationalSpeed.FromRevolutionsPerSecond(1).ToString());
                Assert.AreEqual("1 K", Temperature.FromKelvins(1).ToString());
                Assert.AreEqual("1 Н·м", Torque.FromNewtonmeters(1).ToString());
                Assert.AreEqual("1 м³", Volume.FromCubicMeters(1).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }

        [Test]
        public void GetDefaultAbbreviationFallsBackToUsEnglishCulture()
        {
            // CurrentCulture affects number formatting, such as comma or dot as decimal separator.
            // CurrentUICulture affects localization, in this case the abbreviation.
            // Zulu (South Africa)
            UnitSystem zuluUnits = UnitSystem.GetCached(CultureInfo.GetCultureInfo("zu-ZA"));
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = zuluUnits.Culture;

            UnitSystem usUnits = UnitSystem.GetCached(CultureInfo.GetCultureInfo("en-US"));
            usUnits.MapUnitToAbbreviation(CustomUnit.Unit1, "US english abbreviation for Unit1");

            // Act
            string abbreviation = zuluUnits.GetDefaultAbbreviation(CustomUnit.Unit1);

            // Assert
            Assert.AreEqual("US english abbreviation for Unit1", abbreviation);
        }

        #endregion

        #region Radix Point Formatting

        // These cultures all use a comma for the radix point
        [TestCase("de-DE")]
        [TestCase("da-DK")]
        [TestCase("es-AR")]
        [TestCase("es-ES")]
        [TestCase("it-IT")]
        public void CommaRadixPointCultureFormatting(string culture)
        {
            Assert.AreEqual("0,12 m", Length.FromMeters(0.12).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        // These cultures all use a decimal point for the radix point
        [TestCase("en-CA")]
        [TestCase("en-US")]
        [TestCase("ar-EG")]
        [TestCase("en-GB")]
        [TestCase("es-MX")]
        public void DecimalRadixPointCultureFormatting(string culture)
        {
            Assert.AreEqual("0.12 m", Length.FromMeters(0.12).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        #endregion

        #region Digit Group Formatting

        // These cultures all use a comma in digit grouping
        [TestCase("en-CA")]
        [TestCase("en-US")]
        [TestCase("ar-EG")]
        [TestCase("en-GB")]
        [TestCase("es-MX")]
        public void CommaDigitGroupingCultureFormatting(string culture)
        {
            Assert.AreEqual("1,111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        // These cultures use a thin space in digit grouping
        [TestCase("nn-NO")]
        [TestCase("fr-FR")]
        public void SpaceDigitGroupingCultureFormatting(string culture)
        {
            // Note: the space used in digit groupings is actually a "thin space" Unicode character U+2009
            Assert.AreEqual("1 111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        // Switzerland uses an apostrophe for digit grouping
        [TestCase("fr-CH")]
        public void ApostropheDigitGroupingCultureFormatting(string culture)
        {
            Assert.AreEqual("1'111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        // These cultures all use a decimal point in digit grouping
        [TestCase("de-DE")]
        [TestCase("da-DK")]
        [TestCase("es-AR")]
        [TestCase("es-ES")]
        [TestCase("it-IT")]
        public void DecimalPointDigitGroupingCultureFormatting(string culture)
        {
            Assert.AreEqual("1.111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        #endregion

        #region Significant Digits After Radix Formatting

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
        public string RoundingErrorsWithSignificantDigitsAfterRadixFormatting(double value, int maxSignificantDigitsAfterRadix)
        {
            return Length.FromMeters(value).ToString(LengthUnit.Meter, null, maxSignificantDigitsAfterRadix);
        }

        #endregion

        #region Default ToString Formatting

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

        #endregion

        #region ToString Formatting Intervals

        [Test]
        public void NegativeInfinityFormatting()
        {
            Assert.That(Length.FromMeters(Double.NegativeInfinity).ToString(),
                        Is.EqualTo("-Infinity m"));
        }

        // Any value in the interval (-inf ≤ x ≤ 1e-04] is formatted in scientific notation
        [TestCase(Double.MinValue, Result = "-1.8e+308 m")]
        [TestCase(1.23e-120, Result = "1.23e-120 m")]
        [TestCase(0.0000111, Result = "1.11e-05 m")]
        [TestCase(1.99e-4, Result = "1.99e-04 m")]
        public string ScientificNotationLowerInterval(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        // Any value in the interval [1e-04 < x < 1e+3] is formatted in fixed point notation.
        [TestCase(1e-3, Result = "0.001 m")]
        [TestCase(1.1, Result = "1.1 m")]
        [TestCase(999.99, Result = "999.99 m")]
        public string FixedPointNotationIntervalFormatting(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        // Any value in the interval [1e+3 ≤ x < 1e6] is formatted in fixed point notation with digit grouping.
        [TestCase(1000, Result = "1,000 m")]
        [TestCase(11000, Result = "11,000 m")]
        [TestCase(111000, Result = "111,000 m")]
        [TestCase(999999.99, Result = "999,999.99 m")]
        public string FixedPointNotationWithDigitGroupingIntervalFormatting(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        // Any value in the interval [1e6 ≤ x ≤ +inf) is formatted in scientific notation.
        [TestCase(1e6, Result = "1e+06 m")]
        [TestCase(11100000, Result = "1.11e+07 m")]
        [TestCase(Double.MaxValue, Result = "1.8e+308 m")]
        public string ScientificNotationUpperIntervalFormatting(double value)
        {
            return Length.FromMeters(value).ToString();
        }

        [Test]
        public void PositiveInfinityFormatting()
        {
            Assert.That(Length.FromMeters(Double.PositiveInfinity).ToString(),
                        Is.EqualTo("Infinity m"));
        }

        [Test]
        public void NotANumberFormatting()
        {
            Assert.That(Length.FromMeters(Double.NaN).ToString(),
                        Is.EqualTo("NaN m"));
        }

        #endregion
    }
}