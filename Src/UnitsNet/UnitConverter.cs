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
        ///     such as converting from milimeters to meters.
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
            if (TryConvertMass(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertPressure(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertForce(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertTorque(value, fromUnit, toUnit, out newValue)) return newValue;
            if (TryConvertTime(value, fromUnit, toUnit, out newValue)) return newValue;

            throw new Exception(
                string.Format("Conversion from unit [{0}] to [{1}] is either not valid or not yet implemented.",
                              fromUnit, toUnit));
        }

        private static bool TryConvertTime(double value, Unit fromUnit, Unit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case Unit.Year365Days:
                    newValue = Convert(TimeSpan.FromDays(365*value), toUnit);
                    return true;
                case Unit.Month30Days:
                    newValue = Convert(TimeSpan.FromDays(30*value), toUnit);
                    return true;
                case Unit.Week:
                    newValue = Convert(TimeSpan.FromDays(7*value), toUnit);
                    return true;
                case Unit.Day:
                    newValue = Convert(TimeSpan.FromDays(value), toUnit);
                    return true;
                case Unit.Hour:
                    newValue = Convert(TimeSpan.FromHours(value), toUnit);
                    return true;
                case Unit.Minute:
                    newValue = Convert(TimeSpan.FromMinutes(value), toUnit);
                    return true;
                case Unit.Second:
                    newValue = Convert(TimeSpan.FromSeconds(value), toUnit);
                    return true;
                case Unit.Millisecond:
                    newValue = Convert(TimeSpan.FromMilliseconds(value), toUnit);
                    return true;
                case Unit.Microsecond:
                    newValue = Convert(TimeSpan.FromTicks(System.Convert.ToInt64(value*10)), toUnit);
                    return true;
                case Unit.Nanosecond:
                    newValue = Convert(TimeSpan.FromSeconds(System.Convert.ToInt64(value/100)), toUnit);
                    return true;

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
                    newValue = Convert(Torque.FromNewtonmeters(value), toUnit);
                    return true;

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
                    newValue = Convert(Force.FromKilonewtons(value), toUnit);
                    return true;
                case Unit.Newton:
                    newValue = Convert(Force.FromNewtons(value), toUnit);
                    return true;
                case Unit.KilogramForce:
                    newValue = Convert(Force.FromKilogramForce(value), toUnit);
                    return true;
                case Unit.Dyn:
                    newValue = Convert(Force.FromDyne(value), toUnit);
                    return true;
                case Unit.KiloPond:
                    newValue = Convert(Force.FromKiloPonds(value), toUnit);
                    return true;
                case Unit.PoundForce:
                    newValue = Convert(Force.FromPoundForce(value), toUnit);
                    return true;
                case Unit.Poundal:
                    newValue = Convert(Force.FromPoundal(value), toUnit);
                    return true;

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
                    newValue = Convert(Pressure.FromPascals(value), toUnit);
                    return true;
                case Unit.KiloPascal:
                    newValue = Convert(Pressure.FromKiloPascals(value), toUnit);
                    return true;
                case Unit.Psi:
                    newValue = Convert(Pressure.FromPsi(value), toUnit);
                    return true;
                case Unit.NewtonPerSquareCentimeter:
                    newValue = Convert(Pressure.FromNewtonsPerSquareCentimeter(value), toUnit);
                    return true;
                case Unit.NewtonPerSquareMillimeter:
                    newValue = Convert(Pressure.FromNewtonsPerSquareMillimeter(value), toUnit);
                    return true;
                case Unit.NewtonPerSquareMeter:
                    newValue = Convert(Pressure.FromNewtonsPerSquareMeter(value), toUnit);
                    return true;
                case Unit.Bar:
                    newValue = Convert(Pressure.FromBars(value), toUnit);
                    return true;
                case Unit.TechnicalAtmosphere:
                    newValue = Convert(Pressure.FromTechnicalAtmosphere(value), toUnit);
                    return true;
                case Unit.Atmosphere:
                    newValue = Convert(Pressure.FromAtmosphere(value), toUnit);
                    return true;
                case Unit.Torr:
                    newValue = Convert(Pressure.FromTorr(value), toUnit);
                    return true;

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
                    newValue = Convert(Length.FromKilometers(value), toUnit);
                    return true;
                case Unit.Meter:
                    newValue = Convert(Length.FromMeters(value), toUnit);
                    return true;
                case Unit.Decimeter:
                    newValue = Convert(Length.FromDecimeters(value), toUnit);
                    return true;
                case Unit.Centimeter:
                    newValue = Convert(Length.FromCentimeters(value), toUnit);
                    return true;
                case Unit.Millimeter:
                    newValue = Convert(Length.FromMillimeters(value), toUnit);
                    return true;

                case Unit.Mile:
                    newValue = Convert(Length.FromMiles(value), toUnit);
                    return true;
                case Unit.Yard:
                    newValue = Convert(Length.FromYards(value), toUnit);
                    return true;
                case Unit.Foot:
                    newValue = Convert(Length.FromFeet(value), toUnit);
                    return true;
                case Unit.Inch:
                    newValue = Convert(Length.FromInches(value), toUnit);
                    return true;

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
                    newValue = Convert(Mass.FromMegatonnes(value), toUnit);
                    return true;
                case Unit.Kilotonne:
                    newValue = Convert(Mass.FromKilotonnes(value), toUnit);
                    return true;
                case Unit.Tonne:
                    newValue = Convert(Mass.FromTonnes(value), toUnit);
                    return true;
                case Unit.Kilogram:
                    newValue = Convert(Mass.FromKilograms(value), toUnit);
                    return true;
                case Unit.Hectogram:
                    newValue = Convert(Mass.FromHectograms(value), toUnit);
                    return true;
                case Unit.Decagram:
                    newValue = Convert(Mass.FromDecagrams(value), toUnit);
                    return true;
                case Unit.Gram:
                    newValue = Convert(Mass.FromGrams(value), toUnit);
                    return true;
                case Unit.Decigram:
                    newValue = Convert(Mass.FromDecigrams(value), toUnit);
                    return true;
                case Unit.Centigram:
                    newValue = Convert(Mass.FromCentigrams(value), toUnit);
                    return true;
                case Unit.Milligram:
                    newValue = Convert(Mass.FromMilligrams(value), toUnit);
                    return true;
                    //case Unit.Microgram:
                    //case Unit.Nanogram:

                case Unit.ShortTon:
                    newValue = Convert(Mass.FromShortTons(value), toUnit);
                    return true;
                case Unit.LongTon:
                    newValue = Convert(Mass.FromLongTons(value), toUnit);
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        public static double Convert(Length l, Unit toUnit)
        {
            switch (toUnit)
            {
                case Unit.Kilometer:
                    return l.Kilometers;
                case Unit.Meter:
                    return l.Meters;
                case Unit.Decimeter:
                    return l.Decimeters;
                case Unit.Centimeter:
                    return l.Centimeters;
                case Unit.Millimeter:
                    return l.Millimeters;
                case Unit.Micrometer:
                    return l.Micrometers;
                case Unit.Nanometer:
                    return l.Nanometers;

                case Unit.Mile:
                    return l.Miles;
                case Unit.Yard:
                    return l.Yards;
                case Unit.Foot:
                    return l.Feet;
                case Unit.Inch:
                    return l.Inches;
                default:
                    throw new Exception(
                        string.Format(
                            "Conversion from length to unit [{0}] is either not valid or not yet implemented.", toUnit));
            }
        }

        private static double Convert(Mass m, Unit toUnit)
        {
            switch (toUnit)
            {
                case Unit.Megatonne:
                    return m.Megatonnes;
                case Unit.Kilotonne:
                    return m.Kilotonnes;
                case Unit.Tonne:
                    return m.Tonnes;
                case Unit.Kilogram:
                    return m.Kilograms;
                case Unit.Hectogram:
                    return m.Hectograms;
                case Unit.Decagram:
                    return m.Decagrams;
                case Unit.Gram:
                    return m.Grams;
                case Unit.Decigram:
                    return m.Decigrams;
                case Unit.Centigram:
                    return m.Centigrams;
                case Unit.Milligram:
                    return m.Milligrams;
                    //case Unit.Microgram:
                    //             return m.Micrograms;
                    //case Unit.Nanogram:
                    //             return m.Nanograms;

                case Unit.ShortTon:
                    return m.ShortTons;
                case Unit.LongTon:
                    return m.LongTons;

                default:
                    throw new Exception(
                        string.Format("Conversion from mass to unit [{0}] is either not valid or not yet implemented.",
                                      toUnit));
            }
        }

        public static double Convert(Pressure p, Unit toUnit)
        {
            switch (toUnit)
            {
                case Unit.Pascal:
                    return p.Pascals;
                case Unit.KiloPascal:
                    return p.KiloPascals;
                case Unit.Psi:
                    return p.Psi;
                case Unit.NewtonPerSquareCentimeter:
                    return p.NewtonsPerSquareCentimeter;
                case Unit.NewtonPerSquareMillimeter:
                    return p.NewtonsPerSquareMeter;
                case Unit.NewtonPerSquareMeter:
                    return p.NewtonsPerSquareMillimeter;
                case Unit.Bar:
                    return p.Bars;
                case Unit.TechnicalAtmosphere:
                    return p.TechnicalAtmosphere;
                case Unit.Atmosphere:
                    return p.Atmosphere;
                case Unit.Torr:
                    return p.Torr;

                default:
                    throw new Exception(
                        string.Format(
                            "Conversion from pressure to unit [{0}] is either not valid or not yet implemented.", toUnit));
            }
        }

        public static double Convert(Force f, Unit toUnit)
        {
            switch (toUnit)
            {
                case Unit.Kilonewton:
                    return f.Kilonewtons;
                case Unit.Newton:
                    return f.Newtons;
                case Unit.KilogramForce:
                    return f.KilogramForce;
                case Unit.Dyn:
                    return f.Dyne;
                case Unit.KiloPond:
                    return f.KiloPonds;
                case Unit.PoundForce:
                    return f.PoundForce;
                case Unit.Poundal:
                    return f.Poundal;

                default:
                    throw new Exception(
                        string.Format(
                            "Conversion from force to unit [{0}] is either not valid or not yet implemented.", toUnit));
            }
        }

        // public static double Convert(Volume v, Unit toUnit)
        // {
        //     switch (toUnit)
        //     {
        //case Unit.CubicMeter:
        //             retunr
        //case Unit.CubicDecimeter:
        //case Unit.CubicCentimeter:
        //case Unit.CubicMillimeter:
        //case Unit.Liter:
        //case Unit.Deciliter:
        //case Unit.Centiliter:
        //case Unit.Milliliter:
        ////case Unit.Gallon:

        //         default:
        //             throw new Exception(
        //                 string.Format(
        //                     "Conversion from volume to unit [{0}] is either not valid or not yet implemented.", toUnit));
        //     }
        // }

        public static double Convert(Torque t, Unit toUnit)
        {
            switch (toUnit)
            {
                case Unit.Newtonmeter:
                    return t.Newtonmeters;

                default:
                    throw new Exception(
                        string.Format(
                            "Conversion from torque to unit [{0}] is either not valid or not yet implemented.", toUnit));
            }
        }

        public static double Convert(TimeSpan t, Unit toUnit)
        {
            switch (toUnit)
            {
                case Unit.Year365Days:
                    return t.TotalDays/365;
                case Unit.Month30Days:
                    return t.TotalDays/30;
                case Unit.Week:
                    return t.TotalDays/7;
                case Unit.Day:
                    return t.TotalDays;
                case Unit.Hour:
                    return t.TotalHours;
                case Unit.Minute:
                    return t.TotalMinutes;
                case Unit.Second:
                    return t.TotalSeconds;
                case Unit.Millisecond:
                    return t.TotalMilliseconds;
                case Unit.Microsecond:
                    return t.Ticks/10.0;
                case Unit.Nanosecond:
                    return t.Ticks*100;

                default:
                    throw new Exception(
                        string.Format(
                            "Conversion from time to unit [{0}] is either not valid or not yet implemented.", toUnit));
            }
        }
    }
}