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
    ///     Class for dynamically converting between units.
    /// </summary>
    public static class UnitConverter
    {
        /// <summary>
        ///     A general method for converting a value in a given metric unit domain to the respective value in a compatible unit domain,
        ///     such as converting from millimeters to meters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromUnit"></param>
        /// <param name="toUnit"></param>
        /// <returns></returns>
        public static double Convert(double value, Unit fromUnit, Unit toUnit)
        {
            if (fromUnit == toUnit)
                return value;

            double newValue;
            if (TryConvertLength(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertVolume(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertMass(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertPressure(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertForce(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertTorque(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertTime(value, fromUnit, toUnit, out newValue)) return newValue;

            throw new Exception(
                string.Format("Conversion from unit [{0}] to [{1}] is either not valid or not yet implemented.",
                              fromUnit, toUnit));
        }

        /// <summary>
        ///     A general method for converting a value in a given metric unit domain to the respective value in a compatible unit domain,
        ///     such as converting from millimeters to meters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromUnit"></param>
        /// <param name="toUnit"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static bool TryConvert(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            if (fromUnit == toUnit)
            {
                newValue = value;
                return true;
            }

            if (TryConvertLength(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertVolume(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertMass(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertPressure(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertForce(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertTorque(value, fromUnit, toUnit, out newValue)) return true;
            if (TryConvertTime(value, fromUnit, toUnit, out newValue)) return true;

            return false;
        }

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

        private static bool TryConvertTorque(double value, Unit fromUnit, Unit toUnit, out double newValue)
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

        private static bool TryConvertForce(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Kilonewton:
                    return TryConvert(Force.FromKilonewtons(value), toUnit, out newValue);
                case Unit.Newton:
                    return TryConvert(Force.FromNewtons(value), toUnit, out newValue);
                case Unit.KilogramForce:
                    return TryConvert(Force.FromKilogramForce(value), toUnit, out newValue);
                case Unit.Dyn:
                    return TryConvert(Force.FromDyne(value), toUnit, out newValue);
                case Unit.KiloPond:
                    return TryConvert(Force.FromKiloPonds(value), toUnit, out newValue);
                case Unit.PoundForce:
                    return TryConvert(Force.FromPoundForce(value), toUnit, out newValue);
                case Unit.Poundal:
                    return TryConvert(Force.FromPoundal(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvertPressure(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Pascal:
                    return TryConvert(Pressure.FromPascals(value), toUnit, out newValue);
                case Unit.KiloPascal:
                    return TryConvert(Pressure.FromKiloPascals(value), toUnit, out newValue);
                case Unit.Psi:
                    return TryConvert(Pressure.FromPsi(value), toUnit, out newValue);
                case Unit.NewtonPerSquareCentimeter:
                    return TryConvert(Pressure.FromNewtonsPerSquareCentimeter(value), toUnit, out newValue);
                case Unit.NewtonPerSquareMillimeter:
                    return TryConvert(Pressure.FromNewtonsPerSquareMillimeter(value), toUnit, out newValue);
                case Unit.NewtonPerSquareMeter:
                    return TryConvert(Pressure.FromNewtonsPerSquareMeter(value), toUnit, out newValue);
                case Unit.Bar:
                    return TryConvert(Pressure.FromBars(value), toUnit, out newValue);
                case Unit.TechnicalAtmosphere:
                    return TryConvert(Pressure.FromTechnicalAtmosphere(value), toUnit, out newValue);
                case Unit.Atmosphere:
                    return TryConvert(Pressure.FromAtmosphere(value), toUnit, out newValue);
                case Unit.Torr:
                    return TryConvert(Pressure.FromTorr(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvertLength(double value, Unit fromUnit, Unit toUnit, out double newValue)
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

                case Unit.Mile:
                    return TryConvert(Length.FromMiles(value), toUnit, out newValue);
                case Unit.Yard:
                    return TryConvert(Length.FromYards(value), toUnit, out newValue);
                case Unit.Foot:
                    return TryConvert(Length.FromFeet(value), toUnit, out newValue);
                case Unit.Inch:
                    return TryConvert(Length.FromInches(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvertVolume(double value, Unit fromUnit, Unit toUnit, out double newValue)
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

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvertMass(double value, Unit fromUnit, Unit toUnit, out double newValue)
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
                    //case Unit.Microgram:
                    //case Unit.Nanogram:

                case Unit.ShortTon:
                    return TryConvert(Mass.FromShortTons(value), toUnit, out newValue);
                case Unit.LongTon:
                    return TryConvert(Mass.FromLongTons(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvert(Length l, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Kilometer:
                    newValue = l.Kilometers;
                    return true;
                case Unit.Meter:
                    newValue = l.Meters;
                    return true;
                case Unit.Decimeter:
                    newValue = l.Decimeters;
                    return true;
                case Unit.Centimeter:
                    newValue = l.Centimeters;
                    return true;
                case Unit.Millimeter:
                    newValue = l.Millimeters;
                    return true;
                case Unit.Micrometer:
                    newValue = l.Micrometers;
                    return true;
                case Unit.Nanometer:
                    newValue = l.Nanometers;
                    return true;

                case Unit.Mile:
                    newValue = l.Miles;
                    return true;
                case Unit.Yard:
                    newValue = l.Yards;
                    return true;
                case Unit.Foot:
                    newValue = l.Feet;
                    return true;
                case Unit.Inch:
                    newValue = l.Inches;
                    return true;
                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvert(Volume volume, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.CubicKilometer:
                    newValue = volume.CubicKilometers;
                    return true;
                case Unit.CubicMeter:
                    newValue = volume.CubicMeters;
                    return true;
                case Unit.CubicDecimeter:
                    newValue = volume.CubicDecimeters;
                    return true;
                case Unit.CubicCentimeter:
                    newValue = volume.CubicCentimeters;
                    return true;
                case Unit.CubicMillimeter:
                    newValue = volume.CubicMillimeters;
                    return true;
                case Unit.Hectoliter:
                    newValue = volume.Hectoliters;
                    return true;
                case Unit.Liter:
                    newValue = volume.Liters;
                    return true;
                case Unit.Deciliter:
                    newValue = volume.Deciliters;
                    return true;
                case Unit.Centiliter:
                    newValue = volume.Centiliters;
                    return true;
                case Unit.Milliliter:
                    newValue = volume.Milliliters;
                    return true;

                default:
                    throw new Exception(
                        string.Format(
                            "Conversion from volume to unit [{0}] is either not valid or not yet implemented.", toUnit));
            }
        }

        private static bool TryConvert(Mass m, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Megatonne:
                    newValue = m.Megatonnes;
                    return true;
                case Unit.Kilotonne:
                    newValue = m.Kilotonnes;
                    return true;
                case Unit.Tonne:
                    newValue = m.Tonnes;
                    return true;
                case Unit.Kilogram:
                    newValue = m.Kilograms;
                    return true;
                case Unit.Hectogram:
                    newValue = m.Hectograms;
                    return true;
                case Unit.Decagram:
                    newValue = m.Decagrams;
                    return true;
                case Unit.Gram:
                    newValue = m.Grams;
                    return true;
                case Unit.Decigram:
                    newValue = m.Decigrams;
                    return true;
                case Unit.Centigram:
                    newValue = m.Centigrams;
                    return true;
                case Unit.Milligram:
                    newValue = m.Milligrams;
                    return true;
                    //case Unit.Microgram:
                    //             newValue = m.Micrograms;
                    //return true;
                    //case Unit.Nanogram:
                    //             newValue = m.Nanograms;
                    //return true;

                case Unit.ShortTon:
                    newValue = m.ShortTons;
                    return true;
                case Unit.LongTon:
                    newValue = m.LongTons;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvert(Pressure p, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Pascal:
                    newValue = p.Pascals;
                    return true;
                case Unit.KiloPascal:
                    newValue = p.KiloPascals;
                    return true;
                case Unit.Psi:
                    newValue = p.Psi;
                    return true;
                case Unit.NewtonPerSquareCentimeter:
                    newValue = p.NewtonsPerSquareCentimeter;
                    return true;
                case Unit.NewtonPerSquareMillimeter:
                    newValue = p.NewtonsPerSquareMeter;
                    return true;
                case Unit.NewtonPerSquareMeter:
                    newValue = p.NewtonsPerSquareMillimeter;
                    return true;
                case Unit.Bar:
                    newValue = p.Bars;
                    return true;
                case Unit.TechnicalAtmosphere:
                    newValue = p.TechnicalAtmosphere;
                    return true;
                case Unit.Atmosphere:
                    newValue = p.Atmosphere;
                    return true;
                case Unit.Torr:
                    newValue = p.Torr;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvert(Force f, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Kilonewton:
                    newValue = f.Kilonewtons;
                    return true;
                case Unit.Newton:
                    newValue = f.Newtons;
                    return true;
                case Unit.KilogramForce:
                    newValue = f.KilogramForce;
                    return true;
                case Unit.Dyn:
                    newValue = f.Dyne;
                    return true;
                case Unit.KiloPond:
                    newValue = f.KiloPonds;
                    return true;
                case Unit.PoundForce:
                    newValue = f.PoundForce;
                    return true;
                case Unit.Poundal:
                    newValue = f.Poundal;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        private static bool TryConvert(Torque t, Unit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case Unit.Newtonmeter:
                    newValue = t.Newtonmeters;
                    return true;

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
    }
}