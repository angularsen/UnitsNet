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

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitSystemTests
    {
        [Test]
        public void AllUnitAbbreviationsImplemented([Values("", "en-US", "nb-NO", "ru-RU")]string cultureName)
        {
            IEnumerable<Unit> unitValues = Enum.GetValues(typeof (Unit)).Cast<Unit>();
            UnitSystem unitSystem = UnitSystem.Create(new CultureInfo(cultureName));

            var unitsMissingAbbreviations = new List<Unit>();
            foreach (Unit unit in unitValues)
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
            
            Assert.IsEmpty(unitsMissingAbbreviations,
                "Units missing abbreviations: " + string.Join(", ", unitsMissingAbbreviations));
        }

        [Test]
        public void ToStringRoundsToTwoDecimals()
        {
            var originalCulture = Thread.CurrentThread.CurrentUICulture;
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
                Thread.CurrentThread.CurrentUICulture = originalCulture;
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
                Assert.AreEqual("1 m³/s", Flow.FromCubicMeterPerSecond(1).ToString());
                Assert.AreEqual("1 N", Force.FromNewtons(1).ToString());
                Assert.AreEqual("1 m", Length.FromMeters(1).ToString());
                Assert.AreEqual("1 kg", Mass.FromKilograms(1).ToString());
                Assert.AreEqual("1 Pa", Pressure.FromPascals(1).ToString());
                Assert.AreEqual("1 r/s", RotationalSpeed.FromRevolutionsPerSecond(1).ToString());
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
                Assert.AreEqual("1 m³/s", Flow.FromCubicMeterPerSecond(1).ToString());
                Assert.AreEqual("1 N", Force.FromNewtons(1).ToString());
                Assert.AreEqual("1 m", Length.FromMeters(1).ToString());
                Assert.AreEqual("1 kg", Mass.FromKilograms(1).ToString());
                Assert.AreEqual("1 Pa", Pressure.FromPascals(1).ToString());
                Assert.AreEqual("1 r/s", RotationalSpeed.FromRevolutionsPerSecond(1).ToString());
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
                Assert.AreEqual("1 м³/с", Flow.FromCubicMeterPerSecond(1).ToString());
                Assert.AreEqual("1 Н", Force.FromNewtons(1).ToString());
                Assert.AreEqual("1 м", Length.FromMeters(1).ToString());
                Assert.AreEqual("1 кг", Mass.FromKilograms(1).ToString());
                Assert.AreEqual("1 Па", Pressure.FromPascals(1).ToString());
                Assert.AreEqual("1 об/с", RotationalSpeed.FromRevolutionsPerSecond(1).ToString());
                Assert.AreEqual("1 Н·м", Torque.FromNewtonmeters(1).ToString());
                Assert.AreEqual("1 м³", Volume.FromCubicMeters(1).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }
    }
}