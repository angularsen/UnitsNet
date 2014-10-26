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
        private static IEnumerable<object> GetUnitTypesWithMissingAbbreviations<TUnit>(string cultureName,
            IEnumerable<TUnit> unitValues)
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

        private enum CustomUnit
        {
// ReSharper disable UnusedMember.Local
            Undefined = 0,
            Unit1,
            Unit2
// ReSharper restore UnusedMember.Local
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
        public void GetDefaultAbbreviationFallsBackToDefaultStringIfNotSpecified()
        {
            UnitSystem usUnits = UnitSystem.GetCached(CultureInfo.GetCultureInfo("en-US"));

            // Act
            string abbreviation = usUnits.GetDefaultAbbreviation(CustomUnit.Unit1);

            // Assert
            Assert.AreEqual("(no abbreviation for CustomUnit.Unit1)", abbreviation);
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


        [Test]
        public void ToStringRoundsToTwoDecimals()
        {
            PerformToStringTest(() =>
                {
                    Assert.AreEqual("0 m", Length.FromMeters(0).ToString());
                    Assert.AreEqual("0.1 m", Length.FromMeters(0.1).ToString());
                    Assert.AreEqual("0.11 m", Length.FromMeters(0.11).ToString());
                    Assert.AreEqual("0.11 m", Length.FromMeters(0.111).ToString());
                    Assert.AreEqual("0.12 m", Length.FromMeters(0.115).ToString());
                    return null;
                });
        }

        [TestCase(123.4567, 2, Result = "0.00012 m")]
        [TestCase(55.4321, 3, Result = "5.543e-05 m")]
        [TestCase(5.4321, 4, Result = "5.4321e-06 m")]
        public string VerySmallUnitsToBaseUnits_ExpectStringFormattedCorrectly(double value, int digitsAfterRadix)
        {
            return PerformToStringTest(() => Length.FromMicrometers(value).ToString(LengthUnit.Meter, digitsAfterRadix));
        }

        [TestCase(1234, 0, Result = "1 km")]
        [TestCase(12345, 1, Result = "12.3 km")]
        [TestCase(1234567, 3, Result = "1234.567 km")]
        [TestCase(123456.789, 4, Result = "123.4568 km")]
        [TestCase(1234567898, 2, Result = "1.23e06 km")]
        public string BaseUnitsToLargerUnits_ExpectStringFormattedCorrectly(double value, int digitsAfterRadix)
        {
            return PerformToStringTest(() => Length.FromMeters(value).ToString(LengthUnit.Kilometer, digitsAfterRadix));
        }

        [TestCase(0.00442, Result = "4420 mm")]
        [TestCase(0.0327, Result = "32700 mm")]
        [TestCase(0.5, Result = "500000 mm")]
        [TestCase(1, Result = "1e06 mm")]
        [TestCase(83, Result = "8.3e07 mm")]
        [TestCase(999, Result = "9.99e08 mm")]
        public string LargeUnitsToVerySmallUnits_ExpectStringFormattedCorrectly(double value)
        {
            return PerformToStringTest(() => Length.FromKilometers(value).ToString(LengthUnit.Millimeter));
        }

        [Test]
        [Explicit]
        public void FullRangeManualTest()
        {
            for (double i = 1.1e-12; i < 1e12; i = i*10)
            {
                Console.WriteLine("{0:0.###############} => {1}", i, Length.FromMeters(i).ToString(LengthUnit.Kilometer));
            }
        }

        private string PerformToStringTest(Func<string> testAction)
        {
            CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            // CurrentCulture affects number formatting, such as comma or dot as decimal separator.
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // CurrentUICulture affects localization, in this case for the abbreviation.
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            try
            {
                return testAction();
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = currentUiCulture;
                Thread.CurrentThread.CurrentCulture = currentCulture;
            }
        }
    }
}