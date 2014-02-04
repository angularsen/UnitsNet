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
using System.Globalization;
using System.Linq;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// In everyday use and in kinematics, the speed of an object is the magnitude of its velocity (the rate of change of its position); it is thus a scalar quantity.[1] The average speed of an object in an interval of time is the distance travelled by the object divided by the duration of the interval;[2] the instantaneous speed is the limit of the average speed as the duration of the time interval approaches zero.
    /// </summary>
    public partial struct Speed : IComparable, IComparable<Speed>
    {
        /// <summary>
        /// Base unit of Speed.
        /// </summary>
        public readonly double MetersPerSecond;

        public Speed(double meterspersecond) : this()
        {
            MetersPerSecond = meterspersecond;
        }

        #region Properties

        /// <summary>
        /// Get Speed in FeetPerSecond.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in FeetPerSecond and y is value in base unit MetersPerSecond.</remarks>
        public double FeetPerSecond
        { 
            get { return MetersPerSecond / 0.3048; }
        }

        /// <summary>
        /// Get Speed in KilometersPerHour.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in KilometersPerHour and y is value in base unit MetersPerSecond.</remarks>
        public double KilometersPerHour
        { 
            get { return MetersPerSecond / 0.277777777777778; }
        }

        /// <summary>
        /// Get Speed in Knots.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Knots and y is value in base unit MetersPerSecond.</remarks>
        public double Knots
        { 
            get { return MetersPerSecond / 0.514444; }
        }

        /// <summary>
        /// Get Speed in MilesPerHour.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in MilesPerHour and y is value in base unit MetersPerSecond.</remarks>
        public double MilesPerHour
        { 
            get { return MetersPerSecond / 0.44704; }
        }

        #endregion

        #region Static 

        public static Speed Zero
        {
            get { return new Speed(); }
        }
        
        /// <summary>
        /// Get Speed from FeetPerSecond.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in FeetPerSecond and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromFeetPerSecond(double feetpersecond)
        { 
            return new Speed(0.3048 * feetpersecond);
        }

        /// <summary>
        /// Get Speed from KilometersPerHour.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in KilometersPerHour and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromKilometersPerHour(double kilometersperhour)
        { 
            return new Speed(0.277777777777778 * kilometersperhour);
        }

        /// <summary>
        /// Get Speed from Knots.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Knots and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromKnots(double knots)
        { 
            return new Speed(0.514444 * knots);
        }

        /// <summary>
        /// Get Speed from MetersPerSecond.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in MetersPerSecond and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromMetersPerSecond(double meterspersecond)
        { 
            return new Speed(1 * meterspersecond);
        }

        /// <summary>
        /// Get Speed from MilesPerHour.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in MilesPerHour and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromMilesPerHour(double milesperhour)
        { 
            return new Speed(0.44704 * milesperhour);
        }

        /// <summary>
        /// Try to dynamically convert from Speed to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Speed unit value.</returns> 
        public static Speed From(double value, SpeedUnit fromUnit)
        {
            switch (fromUnit)
            {
                case SpeedUnit.FootPerSecond:
                    return FromFeetPerSecond(value);
                case SpeedUnit.KilometerPerHour:
                    return FromKilometersPerHour(value);
                case SpeedUnit.Knot:
                    return FromKnots(value);
                case SpeedUnit.MeterPerSecond:
                    return FromMetersPerSecond(value);
                case SpeedUnit.MilePerHour:
                    return FromMilesPerHour(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        /// Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(SpeedUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Speed operator -(Speed right)
        {
            return new Speed(-right.MetersPerSecond);
        }

        public static Speed operator +(Speed left, Speed right)
        {
            return new Speed(left.MetersPerSecond + right.MetersPerSecond);
        }

        public static Speed operator -(Speed left, Speed right)
        {
            return new Speed(left.MetersPerSecond - right.MetersPerSecond);
        }

        public static Speed operator *(double left, Speed right)
        {
            return new Speed(left*right.MetersPerSecond);
        }

        public static Speed operator *(Speed left, double right)
        {
            return new Speed(left.MetersPerSecond*right);
        }

        public static Speed operator /(Speed left, double right)
        {
            return new Speed(left.MetersPerSecond/right);
        }

        public static double operator /(Speed left, Speed right)
        {
            return left.MetersPerSecond/right.MetersPerSecond;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Speed)) throw new ArgumentException("Expected type Speed.", "obj");
            return CompareTo((Speed) obj);
        }

        public int CompareTo(Speed other)
        {
            return MetersPerSecond.CompareTo(other.MetersPerSecond);
        }

        public static bool operator <=(Speed left, Speed right)
        {
            return left.MetersPerSecond <= right.MetersPerSecond;
        }

        public static bool operator >=(Speed left, Speed right)
        {
            return left.MetersPerSecond >= right.MetersPerSecond;
        }

        public static bool operator <(Speed left, Speed right)
        {
            return left.MetersPerSecond < right.MetersPerSecond;
        }

        public static bool operator >(Speed left, Speed right)
        {
            return left.MetersPerSecond > right.MetersPerSecond;
        }

        public static bool operator ==(Speed left, Speed right)
        {
            return left.MetersPerSecond == right.MetersPerSecond;
        }

        public static bool operator !=(Speed left, Speed right)
        {
            return left.MetersPerSecond != right.MetersPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return MetersPerSecond.Equals(((Speed) obj).MetersPerSecond);
        }

        public override int GetHashCode()
        {
            return MetersPerSecond.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Speed to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(SpeedUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case SpeedUnit.FootPerSecond:
                    newValue = FeetPerSecond;
                    return true;
                case SpeedUnit.KilometerPerHour:
                    newValue = KilometersPerHour;
                    return true;
                case SpeedUnit.Knot:
                    newValue = Knots;
                    return true;
                case SpeedUnit.MeterPerSecond:
                    newValue = MetersPerSecond;
                    return true;
                case SpeedUnit.MilePerHour:
                    newValue = MilesPerHour;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Speed to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(SpeedUnit toUnit)
        {
            double newValue;
            if (!TryConvert(toUnit, out newValue))
                throw new NotImplementedException("toUnit: " + toUnit);

            return newValue;
        }

        #endregion

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(SpeedUnit unit, CultureInfo culture = null)
        {
            return ToString(unit, culture, "{0:0.##} {1}");
        }

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        public string ToString(SpeedUnit unit, CultureInfo culture, string format, params object[] args)
        {
            string abbreviation = UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {Convert(unit), abbreviation}
                .Concat(args)
                .ToArray();

            return string.Format(culture, format, finalArgs);
        }

        /// <summary>
        /// Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(SpeedUnit.MeterPerSecond);
        }
    }
} 
