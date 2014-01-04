// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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

using NUnit.Framework;
using UnitsNet.Tests.net35.CustomCode;

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitConverterTests
    {
        private const double Delta = 1E-5;

            [Test]
            public void MeterToLengthUnits()
            {
                var t = new LengthTests();
                Assert.AreEqual(t.KilometersInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Kilometer), Delta);
                Assert.AreEqual(t.MetersInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Meter), Delta);
                Assert.AreEqual(t.DecimetersInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Decimeter), Delta);
                Assert.AreEqual(t.CentimetersInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Centimeter), Delta);
                Assert.AreEqual(t.MillimetersInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Millimeter), Delta);
                Assert.AreEqual(t.MicrometersInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Micrometer), Delta);
                Assert.AreEqual(t.NanometersInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Nanometer), Delta);
                Assert.AreEqual(t.MilesInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Mile), Delta);
                Assert.AreEqual(t.YardsInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Yard), Delta);
                Assert.AreEqual(t.FeetInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Foot), Delta);
                Assert.AreEqual(t.InchesInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Inch), Delta);
                Assert.AreEqual(t.MilsInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Mil), Delta);
                Assert.AreEqual(t.MicroinchesInOneMeter, UnitConverter.Convert(1, Unit.Meter, Unit.Microinch), Delta);
            }
            [Test]
            public void KilogramToMassUnits()
            {
                var t = new MassTests();
                Assert.AreEqual(t.MegatonnesInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Megatonne), Delta);
                Assert.AreEqual(t.KilotonnesInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Kilotonne), Delta);
                Assert.AreEqual(t.TonnesInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Tonne), Delta);
                Assert.AreEqual(t.KilogramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Kilogram), Delta);
                Assert.AreEqual(t.HectogramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Hectogram), Delta);
                Assert.AreEqual(t.DecagramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Decagram), Delta);
                Assert.AreEqual(t.GramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Gram), Delta);
                Assert.AreEqual(t.DecigramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Decigram), Delta);
                Assert.AreEqual(t.CentigramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Centigram), Delta);
                Assert.AreEqual(t.MilligramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Milligram), Delta);
                Assert.AreEqual(t.MicrogramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Microgram), Delta);
                Assert.AreEqual(t.NanogramsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.Nanogram), Delta);
                Assert.AreEqual(t.ShortTonsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.ShortTon), Delta);
                Assert.AreEqual(t.LongTonsInOneKilogram, UnitConverter.Convert(1, Unit.Kilogram, Unit.LongTon), Delta);
            }
            [Test]
            public void PascalToPressureUnits()
            {
                var t = new PressureTests();
                Assert.AreEqual(t.NewtonsPerSquareMillimeterInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.NewtonPerSquareMillimeter), Delta);
                Assert.AreEqual(t.NewtonsPerSquareCentimeterInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.NewtonPerSquareCentimeter), Delta);
                Assert.AreEqual(t.NewtonsPerSquareMeterInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.NewtonPerSquareMeter), Delta);
                Assert.AreEqual(t.KilogramForcePerSquareCentimeterInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.KilogramForcePerSquareCentimeter), Delta);
                Assert.AreEqual(t.AtmospheresInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.Atmosphere), Delta);
                Assert.AreEqual(t.TechnicalAtmospheresInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.TechnicalAtmosphere), Delta);
                Assert.AreEqual(t.PsiInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.Psi), Delta);
                Assert.AreEqual(t.TorrsInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.Torr), Delta);
                Assert.AreEqual(t.BarsInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.Bar), Delta);
                Assert.AreEqual(t.MegapascalsInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.Megapascal), Delta);
                Assert.AreEqual(t.KilopascalsInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.Kilopascal), Delta);
                Assert.AreEqual(t.PascalsInOnePascal, UnitConverter.Convert(1, Unit.Pascal, Unit.Pascal), Delta);
            }
            [Test]
            public void NewtonToForceUnits()
            {
                var t = new ForceTests();
                Assert.AreEqual(t.KilonewtonsInOneNewton, UnitConverter.Convert(1, Unit.Newton, Unit.Kilonewton), Delta);
                Assert.AreEqual(t.KilogramsForceInOneNewton, UnitConverter.Convert(1, Unit.Newton, Unit.KilogramForce), Delta);
                Assert.AreEqual(t.NewtonsInOneNewton, UnitConverter.Convert(1, Unit.Newton, Unit.Newton), Delta);
                Assert.AreEqual(t.DyneInOneNewton, UnitConverter.Convert(1, Unit.Newton, Unit.Dyn), Delta);
                Assert.AreEqual(t.KiloPondsInOneNewton, UnitConverter.Convert(1, Unit.Newton, Unit.KiloPond), Delta);
                Assert.AreEqual(t.PoundForcesInOneNewton, UnitConverter.Convert(1, Unit.Newton, Unit.PoundForce), Delta);
                Assert.AreEqual(t.PoundalsInOneNewton, UnitConverter.Convert(1, Unit.Newton, Unit.Poundal), Delta);
            }
            [Test]
            public void SquareMeterToAreaUnits()
            {
                var t = new AreaTests();
                Assert.AreEqual(t.SquareKilometersInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareKilometer), Delta);
                Assert.AreEqual(t.SquareMetersInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareMeter), Delta);
                Assert.AreEqual(t.SquareDecimetersInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareDecimeter), Delta);
                Assert.AreEqual(t.SquareCentimetersInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareCentimeter), Delta);
                Assert.AreEqual(t.SquareMillimetersInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareMillimeter), Delta);
                Assert.AreEqual(t.SquareMilesInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareMile), Delta);
                Assert.AreEqual(t.SquareYardsInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareYard), Delta);
                Assert.AreEqual(t.SquareFeetInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareFoot), Delta);
                Assert.AreEqual(t.SquareInchesInOneSquareMeter, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareInch), Delta);
            }
            [Test]
            public void DegreeToAngleUnits()
            {
                var t = new AngleTests();
                Assert.AreEqual(t.RadiansInOneDegree, UnitConverter.Convert(1, Unit.Degree, Unit.Radian), Delta);
                Assert.AreEqual(t.DegreesInOneDegree, UnitConverter.Convert(1, Unit.Degree, Unit.Degree), Delta);
                Assert.AreEqual(t.GradiansInOneDegree, UnitConverter.Convert(1, Unit.Degree, Unit.Gradian), Delta);
            }
            [Test]
            public void CubicMeterToVolumeUnits()
            {
                var t = new VolumeTests();
                Assert.AreEqual(t.CubicKilometersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicKilometer), Delta);
                Assert.AreEqual(t.CubicMetersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicMeter), Delta);
                Assert.AreEqual(t.CubicDecimetersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicDecimeter), Delta);
                Assert.AreEqual(t.CubicCentimetersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicCentimeter), Delta);
                Assert.AreEqual(t.CubicMillimetersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicMillimeter), Delta);
                Assert.AreEqual(t.HectolitersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Hectoliter), Delta);
                Assert.AreEqual(t.LitersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Liter), Delta);
                Assert.AreEqual(t.DecilitersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Deciliter), Delta);
                Assert.AreEqual(t.CentilitersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Centiliter), Delta);
                Assert.AreEqual(t.MillilitersInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Milliliter), Delta);
                Assert.AreEqual(t.CubicMilesInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicMile), Delta);
                Assert.AreEqual(t.CubicYardsInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicYard), Delta);
                Assert.AreEqual(t.CubicFeetInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicFoot), Delta);
                Assert.AreEqual(t.CubicInchesInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicInch), Delta);
                Assert.AreEqual(t.ImperialGallonsInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.ImperialGallon), Delta);
                Assert.AreEqual(t.UsGallonsInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.UsGallon), Delta);
                Assert.AreEqual(t.UsOuncesInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.UsOunce), Delta);
                Assert.AreEqual(t.ImperialOuncesInOneCubicMeter, UnitConverter.Convert(1, Unit.CubicMeter, Unit.ImperialOunce), Delta);
            }
            [Test]
            public void NewtonmeterToTorqueUnits()
            {
                var t = new TorqueTests();
                Assert.AreEqual(t.NewtonmetersInOneNewtonmeter, UnitConverter.Convert(1, Unit.Newtonmeter, Unit.Newtonmeter), Delta);
            }
            [Test]
            public void VoltToElectricPotentialUnits()
            {
                var t = new ElectricPotentialTests();
                Assert.AreEqual(t.VoltsInOneVolt, UnitConverter.Convert(1, Unit.Volt, Unit.Volt), Delta);
            }
            [Test]
            public void CubicMeterPerSecondToFlowUnits()
            {
                var t = new FlowTests();
                Assert.AreEqual(t.CubicMetersPerSecondInOneCubicMeterPerSecond, UnitConverter.Convert(1, Unit.CubicMeterPerSecond, Unit.CubicMeterPerSecond), Delta);
                Assert.AreEqual(t.CubicMetersPerHourInOneCubicMeterPerSecond, UnitConverter.Convert(1, Unit.CubicMeterPerSecond, Unit.CubicMeterPerHour), Delta);
            }
            [Test]
            public void RevolutionPerSecondToRotationalSpeedUnits()
            {
                var t = new RotationalSpeedTests();
                Assert.AreEqual(t.RevolutionsPerSecondInOneRevolutionPerSecond, UnitConverter.Convert(1, Unit.RevolutionPerSecond, Unit.RevolutionPerSecond), Delta);
                Assert.AreEqual(t.RevolutionsPerMinuteInOneRevolutionPerSecond, UnitConverter.Convert(1, Unit.RevolutionPerSecond, Unit.RevolutionPerMinute), Delta);
            }
            [Test]
            public void MeterPerSecondToSpeedUnits()
            {
                var t = new SpeedTests();
                Assert.AreEqual(t.FeetPerSecondInOneMeterPerSecond, UnitConverter.Convert(1, Unit.MeterPerSecond, Unit.FootPerSecond), Delta);
                Assert.AreEqual(t.KilometersPerHourInOneMeterPerSecond, UnitConverter.Convert(1, Unit.MeterPerSecond, Unit.KilometerPerHour), Delta);
                Assert.AreEqual(t.KnotsInOneMeterPerSecond, UnitConverter.Convert(1, Unit.MeterPerSecond, Unit.Knot), Delta);
                Assert.AreEqual(t.MetersPerSecondInOneMeterPerSecond, UnitConverter.Convert(1, Unit.MeterPerSecond, Unit.MeterPerSecond), Delta);
                Assert.AreEqual(t.MilesPerHourInOneMeterPerSecond, UnitConverter.Convert(1, Unit.MeterPerSecond, Unit.MilePerHour), Delta);
            }
            [Test]
            public void KelvinToTemperatureUnits()
            {
                var t = new TemperatureTests();
                Assert.AreEqual(t.DegreesCelsiusInOneKelvin, UnitConverter.Convert(1, Unit.Kelvin, Unit.DegreeCelsius), Delta);
                Assert.AreEqual(t.DegreesDelisleInOneKelvin, UnitConverter.Convert(1, Unit.Kelvin, Unit.DegreeDelisle), Delta);
                Assert.AreEqual(t.DegreesFahrenheitInOneKelvin, UnitConverter.Convert(1, Unit.Kelvin, Unit.DegreeFahrenheit), Delta);
                Assert.AreEqual(t.KelvinsInOneKelvin, UnitConverter.Convert(1, Unit.Kelvin, Unit.Kelvin), Delta);
                Assert.AreEqual(t.DegreesNewtonInOneKelvin, UnitConverter.Convert(1, Unit.Kelvin, Unit.DegreeNewton), Delta);
                Assert.AreEqual(t.DegreesRankineInOneKelvin, UnitConverter.Convert(1, Unit.Kelvin, Unit.DegreeRankine), Delta);
                Assert.AreEqual(t.DegreesReaumurInOneKelvin, UnitConverter.Convert(1, Unit.Kelvin, Unit.DegreeReaumur), Delta);
                Assert.AreEqual(t.DegreesRoemerInOneKelvin, UnitConverter.Convert(1, Unit.Kelvin, Unit.DegreeRoemer), Delta);
            }
    }
} 

