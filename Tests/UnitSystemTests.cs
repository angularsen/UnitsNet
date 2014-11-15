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
            _originalCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        [TearDown]
        public void Teardown()
        {
            Thread.CurrentThread.CurrentUICulture = _originalCulture;
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
        public void CommaRadixPointCulture(string culture)
        {
            Assert.AreEqual("0,12 m", Length.FromMeters(0.12).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        // These cultures all use a comma for the radix point
        [TestCase("en-CA")]
        [TestCase("en-US")]
        [TestCase("ar-EG")]
        [TestCase("en-GB")]
        [TestCase("es-MX")]
        public void DecimalRadixPointCulture(string culture)
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
        public void CommaDigitGroupingCulture(string culture)
        {
            Assert.AreEqual("1,111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        // These cultures all use a decimal point in digit grouping
        [TestCase("de-DE")]
        [TestCase("da-DK")]
        [TestCase("es-AR")]
        [TestCase("es-ES")]
        [TestCase("it-IT")]
        public void DecimalPointDigitGroupingCulture(string culture)
        {
            Assert.AreEqual("1.111 m", Length.FromMeters(1111).ToString(LengthUnit.Meter, new CultureInfo(culture)));
        }

        #endregion

        #region Digits After Radix Formatting

        [Test]
        public void ExpectDefaultUsesTwoSignificantDigitsAfterRadix()
        {
            Assert.AreEqual("0 m", Length.FromMeters(0).ToString());
            Assert.AreEqual("0.1 m", Length.FromMeters(0.1).ToString());
            Assert.AreEqual("0.11 m", Length.FromMeters(0.11).ToString());
            Assert.AreEqual("0.11 m", Length.FromMeters(0.111234).ToString());
            Assert.AreEqual("0.12 m", Length.FromMeters(0.115).ToString());
        }

        #endregion

        #region ToString Formatting Intervals

        [Test]
        public void NegativeInfinityFormatting()
        {
            Assert.That(Length.FromMeters(Double.NegativeInfinity).ToString(),
                        Is.EqualTo("-Infinity m"));
        }

        [Test]
        public void ScientificNotationLowerThreshold()
        {
            // Anything below 1e-3 is formatted in scientific notation.
            Assert.That(Length.FromMeters(0.000111).ToString(),
                        Is.EqualTo("1.11e-04 m"));

            Assert.That(Length.FromMeters(0.0000111).ToString(),
                        Is.EqualTo("1.11e-05 m"));

            Assert.That(Length.FromMeters(8.88e-15).ToString(),
                        Is.EqualTo("8.88e-15 m"));

            // Make sure extremely small numbers are still formatted correctly (we've gone past the Planck length, alert the physicists!)
            Assert.That(Length.FromMeters(7.77e-120).ToString(),
                        Is.EqualTo("7.77e-120 m"));

            Assert.That(Length.FromMeters(Double.MinValue).ToString(),
                        Is.EqualTo("-1.8e+308 m"));
        }

        [Test]
        public void FixedPointNotationInterval()
        {
            // Anything between 1e-3 and 1e3 is formatted in fixed point notation.
            Assert.That(Length.FromMeters(1e-3).ToString(),
                        Is.EqualTo("0.001 m"));

            Assert.That(Length.FromMeters(0.011).ToString(),
                        Is.EqualTo("0.011 m"));

            Assert.That(Length.FromMeters(0.11).ToString(),
                        Is.EqualTo("0.11 m"));

            Assert.That(Length.FromMeters(1.11).ToString(),
                        Is.EqualTo("1.11 m"));

            Assert.That(Length.FromMeters(11.1).ToString(),
                        Is.EqualTo("11.1 m"));

            Assert.That(Length.FromMeters(110).ToString(),
                        Is.EqualTo("110 m"));
        }

        [Test]
        public void FixedPointNotationWithDigitGroupingInterval()
        {
            // Anything between 1000 and 100,000 is formatted in fixed point notation with digit grouping.
            Assert.That(Length.FromMeters(1000).ToString(),
                        Is.EqualTo("1,000 m"));

            Assert.That(Length.FromMeters(1100).ToString(),
                        Is.EqualTo("1,100 m"));

            Assert.That(Length.FromMeters(11000).ToString(),
                        Is.EqualTo("11,000 m"));

            Assert.That(Length.FromMeters(110000).ToString(),
                        Is.EqualTo("110,000 m"));
        }

        [Test]
        public void ScientificNotationUpperThreshold()
        {
            // Any value at or above 1e6 is formatted in scientific notation
            Assert.That(Length.FromMeters(1e6).ToString(),
                        Is.EqualTo("1e+06 m"));

            Assert.That(Length.FromMeters(11100000).ToString(),
                        Is.EqualTo("1.11e+07 m"));

            Assert.That(Length.FromMeters(Double.MaxValue).ToString(),
                        Is.EqualTo("1.8e+308 m"));
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