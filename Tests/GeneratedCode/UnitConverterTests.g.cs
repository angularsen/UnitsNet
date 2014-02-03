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
using UnitsNet.Units;
using UnitsNet.Tests.net35.CustomCode;

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitConverterTests
    {
        private const double Delta = 1E-5;

            [Test]
            public void DegreeToAngleUnits()
            {
                var t = new AngleTests();
                Assert.AreEqual(t.DegreesInOneDegree, Angle.From(1, AngleUnit.Degree).Convert(AngleUnit.Degree), Delta);
                Assert.AreEqual(t.GradiansInOneDegree, Angle.From(1, AngleUnit.Degree).Convert(AngleUnit.Gradian), Delta);
                Assert.AreEqual(t.RadiansInOneDegree, Angle.From(1, AngleUnit.Degree).Convert(AngleUnit.Radian), Delta);
            }
            [Test]
            public void SquareMeterToAreaUnits()
            {
                var t = new AreaTests();
                Assert.AreEqual(t.SquareCentimetersInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareCentimeter), Delta);
                Assert.AreEqual(t.SquareDecimetersInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareDecimeter), Delta);
                Assert.AreEqual(t.SquareFeetInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareFoot), Delta);
                Assert.AreEqual(t.SquareInchesInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareInch), Delta);
                Assert.AreEqual(t.SquareKilometersInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareKilometer), Delta);
                Assert.AreEqual(t.SquareMetersInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareMeter), Delta);
                Assert.AreEqual(t.SquareMilesInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareMile), Delta);
                Assert.AreEqual(t.SquareMillimetersInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareMillimeter), Delta);
                Assert.AreEqual(t.SquareYardsInOneSquareMeter, Area.From(1, AreaUnit.SquareMeter).Convert(AreaUnit.SquareYard), Delta);
            }
            [Test]
            public void SecondToDurationUnits()
            {
                var t = new DurationTests();
                Assert.AreEqual(t.DaysInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Day), Delta);
                Assert.AreEqual(t.HoursInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Hour), Delta);
                Assert.AreEqual(t.MicrosecondsInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Microsecond), Delta);
                Assert.AreEqual(t.MillisecondsInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Millisecond), Delta);
                Assert.AreEqual(t.MinutesInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Minute), Delta);
                Assert.AreEqual(t.Month30DayssInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Month30Days), Delta);
                Assert.AreEqual(t.NanosecondsInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Nanosecond), Delta);
                Assert.AreEqual(t.SecondsInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Second), Delta);
                Assert.AreEqual(t.WeeksInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Week), Delta);
                Assert.AreEqual(t.Year365DayssInOneSecond, Duration.From(1, DurationUnit.Second).Convert(DurationUnit.Year365Days), Delta);
            }
            [Test]
            public void VoltToElectricPotentialUnits()
            {
                var t = new ElectricPotentialTests();
                Assert.AreEqual(t.VoltsInOneVolt, ElectricPotential.From(1, ElectricPotentialUnit.Volt).Convert(ElectricPotentialUnit.Volt), Delta);
            }
            [Test]
            public void CubicMeterPerSecondToFlowUnits()
            {
                var t = new FlowTests();
                Assert.AreEqual(t.CubicMetersPerHourInOneCubicMeterPerSecond, Flow.From(1, FlowUnit.CubicMeterPerSecond).Convert(FlowUnit.CubicMeterPerHour), Delta);
                Assert.AreEqual(t.CubicMetersPerSecondInOneCubicMeterPerSecond, Flow.From(1, FlowUnit.CubicMeterPerSecond).Convert(FlowUnit.CubicMeterPerSecond), Delta);
            }
            [Test]
            public void NewtonToForceUnits()
            {
                var t = new ForceTests();
                Assert.AreEqual(t.DyneInOneNewton, Force.From(1, ForceUnit.Newton).Convert(ForceUnit.Dyn), Delta);
                Assert.AreEqual(t.KilogramsForceInOneNewton, Force.From(1, ForceUnit.Newton).Convert(ForceUnit.KilogramForce), Delta);
                Assert.AreEqual(t.KilonewtonsInOneNewton, Force.From(1, ForceUnit.Newton).Convert(ForceUnit.Kilonewton), Delta);
                Assert.AreEqual(t.KiloPondsInOneNewton, Force.From(1, ForceUnit.Newton).Convert(ForceUnit.KiloPond), Delta);
                Assert.AreEqual(t.NewtonsInOneNewton, Force.From(1, ForceUnit.Newton).Convert(ForceUnit.Newton), Delta);
                Assert.AreEqual(t.PoundalsInOneNewton, Force.From(1, ForceUnit.Newton).Convert(ForceUnit.Poundal), Delta);
                Assert.AreEqual(t.PoundForcesInOneNewton, Force.From(1, ForceUnit.Newton).Convert(ForceUnit.PoundForce), Delta);
            }
            [Test]
            public void MeterToLengthUnits()
            {
                var t = new LengthTests();
                Assert.AreEqual(t.CentimetersInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Centimeter), Delta);
                Assert.AreEqual(t.DecimetersInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Decimeter), Delta);
                Assert.AreEqual(t.FeetInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Foot), Delta);
                Assert.AreEqual(t.InchesInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Inch), Delta);
                Assert.AreEqual(t.KilometersInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Kilometer), Delta);
                Assert.AreEqual(t.MetersInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Meter), Delta);
                Assert.AreEqual(t.MicroinchesInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Microinch), Delta);
                Assert.AreEqual(t.MicrometersInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Micrometer), Delta);
                Assert.AreEqual(t.MilsInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Mil), Delta);
                Assert.AreEqual(t.MilesInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Mile), Delta);
                Assert.AreEqual(t.MillimetersInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Millimeter), Delta);
                Assert.AreEqual(t.NanometersInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Nanometer), Delta);
                Assert.AreEqual(t.YardsInOneMeter, Length.From(1, LengthUnit.Meter).Convert(LengthUnit.Yard), Delta);
            }
            [Test]
            public void KilogramToMassUnits()
            {
                var t = new MassTests();
                Assert.AreEqual(t.CentigramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Centigram), Delta);
                Assert.AreEqual(t.DecagramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Decagram), Delta);
                Assert.AreEqual(t.DecigramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Decigram), Delta);
                Assert.AreEqual(t.GramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Gram), Delta);
                Assert.AreEqual(t.HectogramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Hectogram), Delta);
                Assert.AreEqual(t.KilogramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Kilogram), Delta);
                Assert.AreEqual(t.KilotonnesInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Kilotonne), Delta);
                Assert.AreEqual(t.LongTonsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.LongTon), Delta);
                Assert.AreEqual(t.MegatonnesInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Megatonne), Delta);
                Assert.AreEqual(t.MicrogramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Microgram), Delta);
                Assert.AreEqual(t.MilligramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Milligram), Delta);
                Assert.AreEqual(t.NanogramsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Nanogram), Delta);
                Assert.AreEqual(t.PoundsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Pound), Delta);
                Assert.AreEqual(t.ShortTonsInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.ShortTon), Delta);
                Assert.AreEqual(t.TonnesInOneKilogram, Mass.From(1, MassUnit.Kilogram).Convert(MassUnit.Tonne), Delta);
            }
            [Test]
            public void PascalToPressureUnits()
            {
                var t = new PressureTests();
                Assert.AreEqual(t.AtmospheresInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.Atmosphere), Delta);
                Assert.AreEqual(t.BarsInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.Bar), Delta);
                Assert.AreEqual(t.KilogramForcePerSquareCentimeterInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.KilogramForcePerSquareCentimeter), Delta);
                Assert.AreEqual(t.KilopascalsInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.Kilopascal), Delta);
                Assert.AreEqual(t.MegapascalsInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.Megapascal), Delta);
                Assert.AreEqual(t.NewtonsPerSquareCentimeterInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.NewtonPerSquareCentimeter), Delta);
                Assert.AreEqual(t.NewtonsPerSquareMeterInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.NewtonPerSquareMeter), Delta);
                Assert.AreEqual(t.NewtonsPerSquareMillimeterInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.NewtonPerSquareMillimeter), Delta);
                Assert.AreEqual(t.PascalsInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.Pascal), Delta);
                Assert.AreEqual(t.PsiInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.Psi), Delta);
                Assert.AreEqual(t.TechnicalAtmospheresInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.TechnicalAtmosphere), Delta);
                Assert.AreEqual(t.TorrsInOnePascal, Pressure.From(1, PressureUnit.Pascal).Convert(PressureUnit.Torr), Delta);
            }
            [Test]
            public void RevolutionPerSecondToRotationalSpeedUnits()
            {
                var t = new RotationalSpeedTests();
                Assert.AreEqual(t.RevolutionsPerMinuteInOneRevolutionPerSecond, RotationalSpeed.From(1, RotationalSpeedUnit.RevolutionPerSecond).Convert(RotationalSpeedUnit.RevolutionPerMinute), Delta);
                Assert.AreEqual(t.RevolutionsPerSecondInOneRevolutionPerSecond, RotationalSpeed.From(1, RotationalSpeedUnit.RevolutionPerSecond).Convert(RotationalSpeedUnit.RevolutionPerSecond), Delta);
            }
            [Test]
            public void MeterPerSecondToSpeedUnits()
            {
                var t = new SpeedTests();
                Assert.AreEqual(t.FeetPerSecondInOneMeterPerSecond, Speed.From(1, SpeedUnit.MeterPerSecond).Convert(SpeedUnit.FootPerSecond), Delta);
                Assert.AreEqual(t.KilometersPerHourInOneMeterPerSecond, Speed.From(1, SpeedUnit.MeterPerSecond).Convert(SpeedUnit.KilometerPerHour), Delta);
                Assert.AreEqual(t.KnotsInOneMeterPerSecond, Speed.From(1, SpeedUnit.MeterPerSecond).Convert(SpeedUnit.Knot), Delta);
                Assert.AreEqual(t.MetersPerSecondInOneMeterPerSecond, Speed.From(1, SpeedUnit.MeterPerSecond).Convert(SpeedUnit.MeterPerSecond), Delta);
                Assert.AreEqual(t.MilesPerHourInOneMeterPerSecond, Speed.From(1, SpeedUnit.MeterPerSecond).Convert(SpeedUnit.MilePerHour), Delta);
            }
            [Test]
            public void KelvinToTemperatureUnits()
            {
                var t = new TemperatureTests();
                Assert.AreEqual(t.DegreesCelsiusInOneKelvin, Temperature.From(1, TemperatureUnit.Kelvin).Convert(TemperatureUnit.DegreeCelsius), Delta);
                Assert.AreEqual(t.DegreesDelisleInOneKelvin, Temperature.From(1, TemperatureUnit.Kelvin).Convert(TemperatureUnit.DegreeDelisle), Delta);
                Assert.AreEqual(t.DegreesFahrenheitInOneKelvin, Temperature.From(1, TemperatureUnit.Kelvin).Convert(TemperatureUnit.DegreeFahrenheit), Delta);
                Assert.AreEqual(t.DegreesNewtonInOneKelvin, Temperature.From(1, TemperatureUnit.Kelvin).Convert(TemperatureUnit.DegreeNewton), Delta);
                Assert.AreEqual(t.DegreesRankineInOneKelvin, Temperature.From(1, TemperatureUnit.Kelvin).Convert(TemperatureUnit.DegreeRankine), Delta);
                Assert.AreEqual(t.DegreesReaumurInOneKelvin, Temperature.From(1, TemperatureUnit.Kelvin).Convert(TemperatureUnit.DegreeReaumur), Delta);
                Assert.AreEqual(t.DegreesRoemerInOneKelvin, Temperature.From(1, TemperatureUnit.Kelvin).Convert(TemperatureUnit.DegreeRoemer), Delta);
                Assert.AreEqual(t.KelvinsInOneKelvin, Temperature.From(1, TemperatureUnit.Kelvin).Convert(TemperatureUnit.Kelvin), Delta);
            }
            [Test]
            public void NewtonmeterToTorqueUnits()
            {
                var t = new TorqueTests();
                Assert.AreEqual(t.NewtonmetersInOneNewtonmeter, Torque.From(1, TorqueUnit.Newtonmeter).Convert(TorqueUnit.Newtonmeter), Delta);
            }
            [Test]
            public void CubicMeterToVolumeUnits()
            {
                var t = new VolumeTests();
                Assert.AreEqual(t.CentilitersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.Centiliter), Delta);
                Assert.AreEqual(t.CubicCentimetersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicCentimeter), Delta);
                Assert.AreEqual(t.CubicDecimetersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicDecimeter), Delta);
                Assert.AreEqual(t.CubicFeetInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicFoot), Delta);
                Assert.AreEqual(t.CubicInchesInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicInch), Delta);
                Assert.AreEqual(t.CubicKilometersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicKilometer), Delta);
                Assert.AreEqual(t.CubicMetersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicMeter), Delta);
                Assert.AreEqual(t.CubicMilesInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicMile), Delta);
                Assert.AreEqual(t.CubicMillimetersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicMillimeter), Delta);
                Assert.AreEqual(t.CubicYardsInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.CubicYard), Delta);
                Assert.AreEqual(t.DecilitersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.Deciliter), Delta);
                Assert.AreEqual(t.HectolitersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.Hectoliter), Delta);
                Assert.AreEqual(t.ImperialGallonsInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.ImperialGallon), Delta);
                Assert.AreEqual(t.ImperialOuncesInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.ImperialOunce), Delta);
                Assert.AreEqual(t.LitersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.Liter), Delta);
                Assert.AreEqual(t.MillilitersInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.Milliliter), Delta);
                Assert.AreEqual(t.UsGallonsInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.UsGallon), Delta);
                Assert.AreEqual(t.UsOuncesInOneCubicMeter, Volume.From(1, VolumeUnit.CubicMeter).Convert(VolumeUnit.UsOunce), Delta);
            }
    }
} 

