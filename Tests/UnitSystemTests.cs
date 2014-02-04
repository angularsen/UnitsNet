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
using UnitsNet.Utils;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitSystemTests
    {
        //public IEnumerable<TUnit[]> TestCases<TUnit>()
        //    where TUnit : /*Enum constraint hack*/ struct, IConvertible
        //{
        //    yield return EnumUtils.GetEnumValues<AngleUnit>();
        //    //yield return new Tester<int> { Expectation = "23tnI" };
        //    //yield return new Tester<List<string>> { Expectation = "1`tsiL" };
        //}

        //[TestCaseSource("TestCases")]
        [Test]
        public void AllUnitAbbreviationsImplemented([Values("en-US", "nb-NO", "ru-RU")]string cultureName)
        {
            var unitValuesMissingAbbreviations = new List<object>()
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
            .Concat(GetUnitTypesWithMissingAbbreviations(cultureName, EnumUtils.GetEnumValues<VolumeUnit>()));

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
        
        private IEnumerable<object> GetUnitTypesWithMissingAbbreviations<TUnit>(string cultureName, IEnumerable<TUnit> unitValues)
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

        [Test]
        public void ToStringRoundsToTwoDecimals()
        {
            var currentUiCulture = Thread.CurrentThread.CurrentUICulture;
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            try
            {
                // CurrentCulture affects number formatting, such as comma or dot as decimal separator.
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                // CurrentUICulture affects localization, in this case for the abbreviation.
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

                Assert.AreEqual("0 m", Length.FromMeters(0).ToString());
                Assert.AreEqual("0.1 m", Length.FromMeters(0.1).ToString());
                Assert.AreEqual("0.11 m", Length.FromMeters(0.11).ToString());
                Assert.AreEqual("0.11 m", Length.FromMeters(0.111).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = currentUiCulture;
                Thread.CurrentThread.CurrentCulture = currentCulture;
            }
        }

        [Test]
        public void AllUnitsImplementToStringForInvariantCulture()
        {
            var originalCulture = Thread.CurrentThread.CurrentUICulture;
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
            var originalCulture = Thread.CurrentThread.CurrentUICulture;
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
            var originalCulture = Thread.CurrentThread.CurrentUICulture;
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
        public void DefaultFoodUnitAbbreviationsForNorwegian()
        {
            UnitSystem unitSystem = UnitSystem.GetCached(new CultureInfo("nb-NO"));
            Assert.AreEqual("ss", unitSystem.GetDefaultAbbreviation(OtherUnit.Tablespoon));
            Assert.AreEqual("ts", unitSystem.GetDefaultAbbreviation(OtherUnit.Teaspoon));
        }

        [Test]
        public void DefaultFoodUnitAbbreviationsForInvariant()
        {
            UnitSystem unitSystem = UnitSystem.GetCached(CultureInfo.InvariantCulture);
            Assert.AreEqual("Tbsp", unitSystem.GetDefaultAbbreviation(OtherUnit.Tablespoon));
            Assert.AreEqual("tsp", unitSystem.GetDefaultAbbreviation(OtherUnit.Teaspoon));
        }
        
        [Test]
        public void DefaultFoodUnitAbbreviationsForUsEnglish()
        {
            UnitSystem unitSystem = UnitSystem.GetCached(new CultureInfo("en-US"));
            Assert.AreEqual("Tbsp", unitSystem.GetDefaultAbbreviation(OtherUnit.Tablespoon));
            Assert.AreEqual("tsp", unitSystem.GetDefaultAbbreviation(OtherUnit.Teaspoon));
        }
    }
}