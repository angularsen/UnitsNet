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

using System;

namespace UnitsNet
{
    /// <summary>
    /// Dynamically convert between compatible units only known at runtime.
    /// </summary>
    public static class UnitConverter
    {
        /// <summary>
        /// Dynamically convert between two compatible units only known at runtime, such as converting from millimeters to meters.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit.</returns> 
        /// <exception cref="Exception">If the two units are not compatible.</exception>
        public static double Convert(double value, Unit fromUnit, Unit toUnit)
        {
            if (fromUnit == toUnit)
                return value;

            double newValue;
            if (TryConvertFromAngle(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromArea(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromElectricPotential(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromFlow(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromForce(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromLength(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromMass(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromPressure(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromRotationalSpeed(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromTemperature(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromTorque(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertFromVolume(value, fromUnit, toUnit, out newValue)) return newValue;

            throw new Exception(
                string.Format("Conversion from unit [{0}] to [{1}] is either not valid or not yet implemented.",
                              fromUnit, toUnit));
        }

        /// <summary>
        /// Dynamically convert between two compatible units only known at runtime, such as converting from millimeters to meters.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public static bool TryConvert(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            if (fromUnit == toUnit)
            {
                newValue = value;
                return true;
            }
 
            if (TryConvertFromAngle(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromArea(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromElectricPotential(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromFlow(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromForce(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromLength(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromMass(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromPressure(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromRotationalSpeed(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromTemperature(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromTorque(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertFromVolume(value, fromUnit, toUnit, out newValue)) return true;

            return false;
        }

        #region Private


        /// <summary>
        /// Try to dynamically convert from Angle to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromAngle(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Radian:
                    return TryConvert(Angle.FromRadians(value), toUnit, out newValue);
                case Unit.Degree:
                    return TryConvert(Angle.FromDegrees(value), toUnit, out newValue);
                case Unit.Gradian:
                    return TryConvert(Angle.FromGradians(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Area to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromArea(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.SquareKilometer:
                    return TryConvert(Area.FromSquareKilometers(value), toUnit, out newValue);
                case Unit.SquareMeter:
                    return TryConvert(Area.FromSquareMeters(value), toUnit, out newValue);
                case Unit.SquareDecimeter:
                    return TryConvert(Area.FromSquareDecimeters(value), toUnit, out newValue);
                case Unit.SquareCentimeter:
                    return TryConvert(Area.FromSquareCentimeters(value), toUnit, out newValue);
                case Unit.SquareMillimeter:
                    return TryConvert(Area.FromSquareMillimeters(value), toUnit, out newValue);
                case Unit.SquareMile:
                    return TryConvert(Area.FromSquareMiles(value), toUnit, out newValue);
                case Unit.SquareYard:
                    return TryConvert(Area.FromSquareYards(value), toUnit, out newValue);
                case Unit.SquareFoot:
                    return TryConvert(Area.FromSquareFeet(value), toUnit, out newValue);
                case Unit.SquareInch:
                    return TryConvert(Area.FromSquareInches(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from ElectricPotential to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromElectricPotential(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Volt:
                    return TryConvert(ElectricPotential.FromVolts(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Flow to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromFlow(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.CubicMeterPerSecond:
                    return TryConvert(Flow.FromCubicMetersPerSecond(value), toUnit, out newValue);
                case Unit.CubicMeterPerHour:
                    return TryConvert(Flow.FromCubicMetersPerHour(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Force to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromForce(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Kilonewton:
                    return TryConvert(Force.FromKilonewtons(value), toUnit, out newValue);
                case Unit.KilogramForce:
                    return TryConvert(Force.FromKilogramsForce(value), toUnit, out newValue);
                case Unit.Newton:
                    return TryConvert(Force.FromNewtons(value), toUnit, out newValue);
                case Unit.Dyn:
                    return TryConvert(Force.FromDyne(value), toUnit, out newValue);
                case Unit.KiloPond:
                    return TryConvert(Force.FromKiloPonds(value), toUnit, out newValue);
                case Unit.PoundForce:
                    return TryConvert(Force.FromPoundForces(value), toUnit, out newValue);
                case Unit.Poundal:
                    return TryConvert(Force.FromPoundals(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Length to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromLength(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Kilometer:
                    return TryConvert(Length.FromKilometers(value), toUnit, out newValue);
                case Unit.Meter:
                    return TryConvert(Length.FromMeters(value), toUnit, out newValue);
                case Unit.Decimeter:
                    return TryConvert(Length.FromDecimeters(value), toUnit, out newValue);
                case Unit.Centimeter:
                    return TryConvert(Length.FromCentimeters(value), toUnit, out newValue);
                case Unit.Millimeter:
                    return TryConvert(Length.FromMillimeters(value), toUnit, out newValue);
                case Unit.Micrometer:
                    return TryConvert(Length.FromMicrometers(value), toUnit, out newValue);
                case Unit.Nanometer:
                    return TryConvert(Length.FromNanometers(value), toUnit, out newValue);
                case Unit.Mile:
                    return TryConvert(Length.FromMiles(value), toUnit, out newValue);
                case Unit.Yard:
                    return TryConvert(Length.FromYards(value), toUnit, out newValue);
                case Unit.Foot:
                    return TryConvert(Length.FromFeet(value), toUnit, out newValue);
                case Unit.Inch:
                    return TryConvert(Length.FromInches(value), toUnit, out newValue);
                case Unit.Mil:
                    return TryConvert(Length.FromMils(value), toUnit, out newValue);
                case Unit.Microinch:
                    return TryConvert(Length.FromMicroinches(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Mass to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromMass(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Megatonne:
                    return TryConvert(Mass.FromMegatonnes(value), toUnit, out newValue);
                case Unit.Kilotonne:
                    return TryConvert(Mass.FromKilotonnes(value), toUnit, out newValue);
                case Unit.Tonne:
                    return TryConvert(Mass.FromTonnes(value), toUnit, out newValue);
                case Unit.Kilogram:
                    return TryConvert(Mass.FromKilograms(value), toUnit, out newValue);
                case Unit.Hectogram:
                    return TryConvert(Mass.FromHectograms(value), toUnit, out newValue);
                case Unit.Decagram:
                    return TryConvert(Mass.FromDecagrams(value), toUnit, out newValue);
                case Unit.Gram:
                    return TryConvert(Mass.FromGrams(value), toUnit, out newValue);
                case Unit.Decigram:
                    return TryConvert(Mass.FromDecigrams(value), toUnit, out newValue);
                case Unit.Centigram:
                    return TryConvert(Mass.FromCentigrams(value), toUnit, out newValue);
                case Unit.Milligram:
                    return TryConvert(Mass.FromMilligrams(value), toUnit, out newValue);
                case Unit.ShortTon:
                    return TryConvert(Mass.FromShortTons(value), toUnit, out newValue);
                case Unit.LongTon:
                    return TryConvert(Mass.FromLongTons(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Pressure to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromPressure(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.NewtonPerSquareMillimeter:
                    return TryConvert(Pressure.FromNewtonsPerSquareMillimeter(value), toUnit, out newValue);
                case Unit.NewtonPerSquareCentimeter:
                    return TryConvert(Pressure.FromNewtonsPerSquareCentimeter(value), toUnit, out newValue);
                case Unit.NewtonPerSquareMeter:
                    return TryConvert(Pressure.FromNewtonsPerSquareMeter(value), toUnit, out newValue);
                case Unit.KilogramForcePerSquareCentimeter:
                    return TryConvert(Pressure.FromKilogramForcePerSquareCentimeter(value), toUnit, out newValue);
                case Unit.Atmosphere:
                    return TryConvert(Pressure.FromAtmospheres(value), toUnit, out newValue);
                case Unit.TechnicalAtmosphere:
                    return TryConvert(Pressure.FromTechnicalAtmospheres(value), toUnit, out newValue);
                case Unit.Psi:
                    return TryConvert(Pressure.FromPsi(value), toUnit, out newValue);
                case Unit.Torr:
                    return TryConvert(Pressure.FromTorrs(value), toUnit, out newValue);
                case Unit.Bar:
                    return TryConvert(Pressure.FromBars(value), toUnit, out newValue);
                case Unit.Megapascal:
                    return TryConvert(Pressure.FromMegapascals(value), toUnit, out newValue);
                case Unit.Kilopascal:
                    return TryConvert(Pressure.FromKilopascals(value), toUnit, out newValue);
                case Unit.Pascal:
                    return TryConvert(Pressure.FromPascals(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from RotationalSpeed to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromRotationalSpeed(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.RevolutionPerSecond:
                    return TryConvert(RotationalSpeed.FromRevolutionsPerSecond(value), toUnit, out newValue);
                case Unit.RevolutionPerMinute:
                    return TryConvert(RotationalSpeed.FromRevolutionsPerMinute(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Temperature to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromTemperature(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.DegreeCelsius:
                    return TryConvert(Temperature.FromDegreesCelsius(value), toUnit, out newValue);
                case Unit.DegreeDelisle:
                    return TryConvert(Temperature.FromDegreesDelisle(value), toUnit, out newValue);
                case Unit.DegreeFahrenheit:
                    return TryConvert(Temperature.FromDegreesFahrenheit(value), toUnit, out newValue);
                case Unit.Kelvin:
                    return TryConvert(Temperature.FromKelvins(value), toUnit, out newValue);
                case Unit.DegreeNewton:
                    return TryConvert(Temperature.FromDegreesNewton(value), toUnit, out newValue);
                case Unit.DegreeRankine:
                    return TryConvert(Temperature.FromDegreesRankine(value), toUnit, out newValue);
                case Unit.DegreeReaumur:
                    return TryConvert(Temperature.FromDegreesReaumur(value), toUnit, out newValue);
                case Unit.DegreeRoemer:
                    return TryConvert(Temperature.FromDegreesRoemer(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Torque to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromTorque(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Newtonmeter:
                    return TryConvert(Torque.FromNewtonmeters(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Volume to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromVolume(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.CubicKilometer:
                    return TryConvert(Volume.FromCubicKilometers(value), toUnit, out newValue);
                case Unit.CubicMeter:
                    return TryConvert(Volume.FromCubicMeters(value), toUnit, out newValue);
                case Unit.CubicDecimeter:
                    return TryConvert(Volume.FromCubicDecimeters(value), toUnit, out newValue);
                case Unit.CubicCentimeter:
                    return TryConvert(Volume.FromCubicCentimeters(value), toUnit, out newValue);
                case Unit.CubicMillimeter:
                    return TryConvert(Volume.FromCubicMillimeters(value), toUnit, out newValue);
                case Unit.Hectoliter:
                    return TryConvert(Volume.FromHectoliters(value), toUnit, out newValue);
                case Unit.Liter:
                    return TryConvert(Volume.FromLiters(value), toUnit, out newValue);
                case Unit.Deciliter:
                    return TryConvert(Volume.FromDeciliters(value), toUnit, out newValue);
                case Unit.Centiliter:
                    return TryConvert(Volume.FromCentiliters(value), toUnit, out newValue);
                case Unit.Milliliter:
                    return TryConvert(Volume.FromMilliliters(value), toUnit, out newValue);
                case Unit.CubicMile:
                    return TryConvert(Volume.FromCubicMiles(value), toUnit, out newValue);
                case Unit.CubicYard:
                    return TryConvert(Volume.FromCubicYards(value), toUnit, out newValue);
                case Unit.CubicFoot:
                    return TryConvert(Volume.FromCubicFeet(value), toUnit, out newValue);
                case Unit.CubicInch:
                    return TryConvert(Volume.FromCubicInches(value), toUnit, out newValue);
                case Unit.ImperialGallon:
                    return TryConvert(Volume.FromImperialGallons(value), toUnit, out newValue);
                case Unit.UsGallon:
                    return TryConvert(Volume.FromUsGallons(value), toUnit, out newValue);
                case Unit.UsOunce:
                    return TryConvert(Volume.FromUsOunces(value), toUnit, out newValue);
                case Unit.ImperialOunce:
                    return TryConvert(Volume.FromImperialOunces(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Angle to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Angle value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Radian:
                    newValue = value.Radians;
                    return true;
                case Unit.Degree:
                    newValue = value.Degrees;
                    return true;
                case Unit.Gradian:
                    newValue = value.Gradians;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Area to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Area value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.SquareKilometer:
                    newValue = value.SquareKilometers;
                    return true;
                case Unit.SquareMeter:
                    newValue = value.SquareMeters;
                    return true;
                case Unit.SquareDecimeter:
                    newValue = value.SquareDecimeters;
                    return true;
                case Unit.SquareCentimeter:
                    newValue = value.SquareCentimeters;
                    return true;
                case Unit.SquareMillimeter:
                    newValue = value.SquareMillimeters;
                    return true;
                case Unit.SquareMile:
                    newValue = value.SquareMiles;
                    return true;
                case Unit.SquareYard:
                    newValue = value.SquareYards;
                    return true;
                case Unit.SquareFoot:
                    newValue = value.SquareFeet;
                    return true;
                case Unit.SquareInch:
                    newValue = value.SquareInches;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from ElectricPotential to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(ElectricPotential value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Volt:
                    newValue = value.Volts;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Flow to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Flow value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.CubicMeterPerSecond:
                    newValue = value.CubicMetersPerSecond;
                    return true;
                case Unit.CubicMeterPerHour:
                    newValue = value.CubicMetersPerHour;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Force to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Force value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Kilonewton:
                    newValue = value.Kilonewtons;
                    return true;
                case Unit.KilogramForce:
                    newValue = value.KilogramsForce;
                    return true;
                case Unit.Newton:
                    newValue = value.Newtons;
                    return true;
                case Unit.Dyn:
                    newValue = value.Dyne;
                    return true;
                case Unit.KiloPond:
                    newValue = value.KiloPonds;
                    return true;
                case Unit.PoundForce:
                    newValue = value.PoundForces;
                    return true;
                case Unit.Poundal:
                    newValue = value.Poundals;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Length to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Length value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Kilometer:
                    newValue = value.Kilometers;
                    return true;
                case Unit.Meter:
                    newValue = value.Meters;
                    return true;
                case Unit.Decimeter:
                    newValue = value.Decimeters;
                    return true;
                case Unit.Centimeter:
                    newValue = value.Centimeters;
                    return true;
                case Unit.Millimeter:
                    newValue = value.Millimeters;
                    return true;
                case Unit.Micrometer:
                    newValue = value.Micrometers;
                    return true;
                case Unit.Nanometer:
                    newValue = value.Nanometers;
                    return true;
                case Unit.Mile:
                    newValue = value.Miles;
                    return true;
                case Unit.Yard:
                    newValue = value.Yards;
                    return true;
                case Unit.Foot:
                    newValue = value.Feet;
                    return true;
                case Unit.Inch:
                    newValue = value.Inches;
                    return true;
                case Unit.Mil:
                    newValue = value.Mils;
                    return true;
                case Unit.Microinch:
                    newValue = value.Microinches;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Mass to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Mass value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Megatonne:
                    newValue = value.Megatonnes;
                    return true;
                case Unit.Kilotonne:
                    newValue = value.Kilotonnes;
                    return true;
                case Unit.Tonne:
                    newValue = value.Tonnes;
                    return true;
                case Unit.Kilogram:
                    newValue = value.Kilograms;
                    return true;
                case Unit.Hectogram:
                    newValue = value.Hectograms;
                    return true;
                case Unit.Decagram:
                    newValue = value.Decagrams;
                    return true;
                case Unit.Gram:
                    newValue = value.Grams;
                    return true;
                case Unit.Decigram:
                    newValue = value.Decigrams;
                    return true;
                case Unit.Centigram:
                    newValue = value.Centigrams;
                    return true;
                case Unit.Milligram:
                    newValue = value.Milligrams;
                    return true;
                case Unit.ShortTon:
                    newValue = value.ShortTons;
                    return true;
                case Unit.LongTon:
                    newValue = value.LongTons;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Pressure to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Pressure value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.NewtonPerSquareMillimeter:
                    newValue = value.NewtonsPerSquareMillimeter;
                    return true;
                case Unit.NewtonPerSquareCentimeter:
                    newValue = value.NewtonsPerSquareCentimeter;
                    return true;
                case Unit.NewtonPerSquareMeter:
                    newValue = value.NewtonsPerSquareMeter;
                    return true;
                case Unit.KilogramForcePerSquareCentimeter:
                    newValue = value.KilogramForcePerSquareCentimeter;
                    return true;
                case Unit.Atmosphere:
                    newValue = value.Atmospheres;
                    return true;
                case Unit.TechnicalAtmosphere:
                    newValue = value.TechnicalAtmospheres;
                    return true;
                case Unit.Psi:
                    newValue = value.Psi;
                    return true;
                case Unit.Torr:
                    newValue = value.Torrs;
                    return true;
                case Unit.Bar:
                    newValue = value.Bars;
                    return true;
                case Unit.Megapascal:
                    newValue = value.Megapascals;
                    return true;
                case Unit.Kilopascal:
                    newValue = value.Kilopascals;
                    return true;
                case Unit.Pascal:
                    newValue = value.Pascals;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from RotationalSpeed to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(RotationalSpeed value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.RevolutionPerSecond:
                    newValue = value.RevolutionsPerSecond;
                    return true;
                case Unit.RevolutionPerMinute:
                    newValue = value.RevolutionsPerMinute;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Temperature to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Temperature value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.DegreeCelsius:
                    newValue = value.DegreesCelsius;
                    return true;
                case Unit.DegreeDelisle:
                    newValue = value.DegreesDelisle;
                    return true;
                case Unit.DegreeFahrenheit:
                    newValue = value.DegreesFahrenheit;
                    return true;
                case Unit.Kelvin:
                    newValue = value.Kelvins;
                    return true;
                case Unit.DegreeNewton:
                    newValue = value.DegreesNewton;
                    return true;
                case Unit.DegreeRankine:
                    newValue = value.DegreesRankine;
                    return true;
                case Unit.DegreeReaumur:
                    newValue = value.DegreesReaumur;
                    return true;
                case Unit.DegreeRoemer:
                    newValue = value.DegreesRoemer;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Torque to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Torque value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Newtonmeter:
                    newValue = value.Newtonmeters;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }


        /// <summary>
        /// Try to dynamically convert from Volume to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Volume value, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.CubicKilometer:
                    newValue = value.CubicKilometers;
                    return true;
                case Unit.CubicMeter:
                    newValue = value.CubicMeters;
                    return true;
                case Unit.CubicDecimeter:
                    newValue = value.CubicDecimeters;
                    return true;
                case Unit.CubicCentimeter:
                    newValue = value.CubicCentimeters;
                    return true;
                case Unit.CubicMillimeter:
                    newValue = value.CubicMillimeters;
                    return true;
                case Unit.Hectoliter:
                    newValue = value.Hectoliters;
                    return true;
                case Unit.Liter:
                    newValue = value.Liters;
                    return true;
                case Unit.Deciliter:
                    newValue = value.Deciliters;
                    return true;
                case Unit.Centiliter:
                    newValue = value.Centiliters;
                    return true;
                case Unit.Milliliter:
                    newValue = value.Milliliters;
                    return true;
                case Unit.CubicMile:
                    newValue = value.CubicMiles;
                    return true;
                case Unit.CubicYard:
                    newValue = value.CubicYards;
                    return true;
                case Unit.CubicFoot:
                    newValue = value.CubicFeet;
                    return true;
                case Unit.CubicInch:
                    newValue = value.CubicInches;
                    return true;
                case Unit.ImperialGallon:
                    newValue = value.ImperialGallons;
                    return true;
                case Unit.UsGallon:
                    newValue = value.UsGallons;
                    return true;
                case Unit.UsOunce:
                    newValue = value.UsOunces;
                    return true;
                case Unit.ImperialOunce:
                    newValue = value.ImperialOunces;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

 
        #endregion

        #region Not implemented as unit class yet, no UnitAttribute for these

        private static bool TryConvertTime(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Year365Days:
                    return TryConvert(TimeSpan.FromDays(365*value), toUnit, out newValue);
                case Unit.Month30Days:
                    return TryConvert(TimeSpan.FromDays(30*value), toUnit, out newValue);
                case Unit.Week:
                    return TryConvert(TimeSpan.FromDays(7*value), toUnit, out newValue);
                case Unit.Day:
                    return TryConvert(TimeSpan.FromDays(value), toUnit, out newValue);
                case Unit.Hour:
                    return TryConvert(TimeSpan.FromHours(value), toUnit, out newValue);
                case Unit.Minute:
                    return TryConvert(TimeSpan.FromMinutes(value), toUnit, out newValue);
                case Unit.Second:
                    return TryConvert(TimeSpan.FromSeconds(value), toUnit, out newValue);
                case Unit.Millisecond:
                    return TryConvert(TimeSpan.FromMilliseconds(value), toUnit, out newValue);
                case Unit.Microsecond:
                    return TryConvert(TimeSpan.FromTicks(System.Convert.ToInt64(value*10)), toUnit, out newValue);
                case Unit.Nanosecond:
                    return TryConvert(TimeSpan.FromSeconds(System.Convert.ToInt64(value/100)), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvert(TimeSpan t, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Year365Days:
                    newValue = t.TotalDays/365;
                    return true;
                case Unit.Month30Days:
                    newValue = t.TotalDays/30;
                    return true;
                case Unit.Week:
                    newValue = t.TotalDays/7;
                    return true;
                case Unit.Day:
                    newValue = t.TotalDays;
                    return true;
                case Unit.Hour:
                    newValue = t.TotalHours;
                    return true;
                case Unit.Minute:
                    newValue = t.TotalMinutes;
                    return true;
                case Unit.Second:
                    newValue = t.TotalSeconds;
                    return true;
                case Unit.Millisecond:
                    newValue = t.TotalMilliseconds;
                    return true;
                case Unit.Microsecond:
                    newValue = t.Ticks/10.0;
                    return true;
                case Unit.Nanosecond:
                    newValue = t.Ticks*100;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        #endregion
    }
}

