// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
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
using System.Diagnostics;
using System.Globalization;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Extension to the generated Length struct.
    ///     Makes it easier to work with Feet/Inches combinations, which are customarily used in the US and UK
    ///     to express body height. For example, someone is 5 feet 3 inches tall.
    /// </summary>
    public partial struct Length
    {
        private const double FeetToInches = 12;

        /// <summary>
        ///     Converts the length to a customary feet/inches combination.
        /// </summary>
        public FeetInches FeetInches
        {
            get
            {
                double totalInches = Inches;
                double wholeFeet = Math.Floor(totalInches/FeetToInches);
                double inches = totalInches%FeetToInches;

                return new FeetInches(wholeFeet, inches);
            }
        }

        /// <summary>
        ///     Get length from combination of feet and inches.
        /// </summary>
        public static Length FromFeetInches(double feet, double inches)
        {
            return FromInches(FeetToInches*feet + inches);
        }

        public static Speed operator /(Length length, TimeSpan timeSpan)
        {
            return Speed.FromMetersPerSecond(length.Meters/timeSpan.TotalSeconds);
        }

        public static Speed operator /(Length length, Duration duration)
        {
            return Speed.FromMetersPerSecond(length.Meters/duration.Seconds);
        }

        public static Duration operator /(Length length, Speed speed)
        {
            return Duration.FromSeconds(length.Meters / speed.MetersPerSecond);
        }

        public static Area operator *(Length length1, Length length2)
        {
            return Area.FromSquareMeters(length1.Meters*length2.Meters);
        }

        public static Volume operator *(Area area, Length length)
        {
            return Volume.FromCubicMeters(area.SquareMeters*length.Meters);
        }

        public static Volume operator *(Length length, Area area)
        {
            return Volume.FromCubicMeters(area.SquareMeters*length.Meters);
        }

        public static Torque operator *(Force force, Length length)
        {
            return Torque.FromNewtonMeters(force.Newtons*length.Meters);
        }

        public static Torque operator *(Length length, Force force)
        {
            return Torque.FromNewtonMeters(force.Newtons*length.Meters);
        }

        public static KinematicViscosity operator *(Length length, Speed speed)
        {
            return KinematicViscosity.FromSquareMetersPerSecond(length.Meters * speed.MetersPerSecond);
        }
    }

    public class FeetInches
    {
        public FeetInches(double feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public double Feet { get; }
        public double Inches { get; }

        public string ToString(IFormatProvider cultureInfo = null)
        {
            // Note that it isn't customary to use fractions - one wouldn't say "I am 5 feet and 4.5 inches".
            // So inches are rounded when converting from base units to feet/inches.

            UnitSystem unitSystem = UnitSystem.GetCached(cultureInfo);
            string footUnit = unitSystem.GetDefaultAbbreviation(LengthUnit.Foot);
            string inchUnit = unitSystem.GetDefaultAbbreviation(LengthUnit.Inch);

            return string.Format(cultureInfo == null ? CultureInfo.CurrentCulture : cultureInfo, "{0:n0} {1} {2:n0} {3}",
                Feet, footUnit, Math.Round(Inches), inchUnit);
        }
    }
}