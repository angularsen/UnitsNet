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
    /// Time is a dimension in which events can be ordered from the past through the present into the future, and also the measure of durations of events and the intervals between them.
    /// </summary>
    public partial struct Duration : IComparable, IComparable<Duration>
    {
        /// <summary>
        /// Base unit of Duration.
        /// </summary>
        public readonly double Seconds;

        public Duration(double seconds) : this()
        {
            Seconds = seconds;
        }

        #region Properties

        /// <summary>
        /// Get Duration in Days.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Days and y is value in base unit Seconds.</remarks>
        public double Days
        { 
            get { return Seconds / 86400; }
        }

        /// <summary>
        /// Get Duration in Hours.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Hours and y is value in base unit Seconds.</remarks>
        public double Hours
        { 
            get { return Seconds / 3600; }
        }

        /// <summary>
        /// Get Duration in Microseconds.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Microseconds and y is value in base unit Seconds.</remarks>
        public double Microseconds
        { 
            get { return Seconds / 1E-06; }
        }

        /// <summary>
        /// Get Duration in Milliseconds.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Milliseconds and y is value in base unit Seconds.</remarks>
        public double Milliseconds
        { 
            get { return Seconds / 0.001; }
        }

        /// <summary>
        /// Get Duration in Minutes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Minutes and y is value in base unit Seconds.</remarks>
        public double Minutes
        { 
            get { return Seconds / 60; }
        }

        /// <summary>
        /// Get Duration in Month30Dayss.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Month30Dayss and y is value in base unit Seconds.</remarks>
        public double Month30Dayss
        { 
            get { return Seconds / 2592000; }
        }

        /// <summary>
        /// Get Duration in Nanoseconds.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Nanoseconds and y is value in base unit Seconds.</remarks>
        public double Nanoseconds
        { 
            get { return Seconds / 1E-09; }
        }

        /// <summary>
        /// Get Duration in Weeks.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Weeks and y is value in base unit Seconds.</remarks>
        public double Weeks
        { 
            get { return Seconds / 604800; }
        }

        /// <summary>
        /// Get Duration in Year365Dayss.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Year365Dayss and y is value in base unit Seconds.</remarks>
        public double Year365Dayss
        { 
            get { return Seconds / 31536000; }
        }

        #endregion

        #region Static 

        public static Duration Zero
        {
            get { return new Duration(); }
        }
        
        /// <summary>
        /// Get Duration from Days.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Days and y is value in base unit Seconds.</remarks>
        public static Duration FromDays(double days)
        { 
            return new Duration(86400 * days);
        }

        /// <summary>
        /// Get Duration from Hours.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Hours and y is value in base unit Seconds.</remarks>
        public static Duration FromHours(double hours)
        { 
            return new Duration(3600 * hours);
        }

        /// <summary>
        /// Get Duration from Microseconds.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Microseconds and y is value in base unit Seconds.</remarks>
        public static Duration FromMicroseconds(double microseconds)
        { 
            return new Duration(1E-06 * microseconds);
        }

        /// <summary>
        /// Get Duration from Milliseconds.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Milliseconds and y is value in base unit Seconds.</remarks>
        public static Duration FromMilliseconds(double milliseconds)
        { 
            return new Duration(0.001 * milliseconds);
        }

        /// <summary>
        /// Get Duration from Minutes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Minutes and y is value in base unit Seconds.</remarks>
        public static Duration FromMinutes(double minutes)
        { 
            return new Duration(60 * minutes);
        }

        /// <summary>
        /// Get Duration from Month30Dayss.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Month30Dayss and y is value in base unit Seconds.</remarks>
        public static Duration FromMonth30Dayss(double month30dayss)
        { 
            return new Duration(2592000 * month30dayss);
        }

        /// <summary>
        /// Get Duration from Nanoseconds.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Nanoseconds and y is value in base unit Seconds.</remarks>
        public static Duration FromNanoseconds(double nanoseconds)
        { 
            return new Duration(1E-09 * nanoseconds);
        }

        /// <summary>
        /// Get Duration from Seconds.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Seconds and y is value in base unit Seconds.</remarks>
        public static Duration FromSeconds(double seconds)
        { 
            return new Duration(1 * seconds);
        }

        /// <summary>
        /// Get Duration from Weeks.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Weeks and y is value in base unit Seconds.</remarks>
        public static Duration FromWeeks(double weeks)
        { 
            return new Duration(604800 * weeks);
        }

        /// <summary>
        /// Get Duration from Year365Dayss.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Year365Dayss and y is value in base unit Seconds.</remarks>
        public static Duration FromYear365Dayss(double year365dayss)
        { 
            return new Duration(31536000 * year365dayss);
        }

        /// <summary>
        /// Try to dynamically convert from Duration to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Duration unit value.</returns> 
        public static Duration From(double value, DurationUnit fromUnit)
        {
            switch (fromUnit)
            {
                case DurationUnit.Day:
                    return FromDays(value);
                case DurationUnit.Hour:
                    return FromHours(value);
                case DurationUnit.Microsecond:
                    return FromMicroseconds(value);
                case DurationUnit.Millisecond:
                    return FromMilliseconds(value);
                case DurationUnit.Minute:
                    return FromMinutes(value);
                case DurationUnit.Month30Days:
                    return FromMonth30Dayss(value);
                case DurationUnit.Nanosecond:
                    return FromNanoseconds(value);
                case DurationUnit.Second:
                    return FromSeconds(value);
                case DurationUnit.Week:
                    return FromWeeks(value);
                case DurationUnit.Year365Days:
                    return FromYear365Dayss(value);

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
        public static string GetAbbreviation(DurationUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Duration operator -(Duration right)
        {
            return new Duration(-right.Seconds);
        }

        public static Duration operator +(Duration left, Duration right)
        {
            return new Duration(left.Seconds + right.Seconds);
        }

        public static Duration operator -(Duration left, Duration right)
        {
            return new Duration(left.Seconds - right.Seconds);
        }

        public static Duration operator *(double left, Duration right)
        {
            return new Duration(left*right.Seconds);
        }

        public static Duration operator *(Duration left, double right)
        {
            return new Duration(left.Seconds*right);
        }

        public static Duration operator /(Duration left, double right)
        {
            return new Duration(left.Seconds/right);
        }

        public static double operator /(Duration left, Duration right)
        {
            return left.Seconds/right.Seconds;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Duration)) throw new ArgumentException("Expected type Duration.", "obj");
            return CompareTo((Duration) obj);
        }

        public int CompareTo(Duration other)
        {
            return Seconds.CompareTo(other.Seconds);
        }

        public static bool operator <=(Duration left, Duration right)
        {
            return left.Seconds <= right.Seconds;
        }

        public static bool operator >=(Duration left, Duration right)
        {
            return left.Seconds >= right.Seconds;
        }

        public static bool operator <(Duration left, Duration right)
        {
            return left.Seconds < right.Seconds;
        }

        public static bool operator >(Duration left, Duration right)
        {
            return left.Seconds > right.Seconds;
        }

        public static bool operator ==(Duration left, Duration right)
        {
            return left.Seconds == right.Seconds;
        }

        public static bool operator !=(Duration left, Duration right)
        {
            return left.Seconds != right.Seconds;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Seconds.Equals(((Duration) obj).Seconds);
        }

        public override int GetHashCode()
        {
            return Seconds.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Duration to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(DurationUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case DurationUnit.Day:
                    newValue = Days;
                    return true;
                case DurationUnit.Hour:
                    newValue = Hours;
                    return true;
                case DurationUnit.Microsecond:
                    newValue = Microseconds;
                    return true;
                case DurationUnit.Millisecond:
                    newValue = Milliseconds;
                    return true;
                case DurationUnit.Minute:
                    newValue = Minutes;
                    return true;
                case DurationUnit.Month30Days:
                    newValue = Month30Dayss;
                    return true;
                case DurationUnit.Nanosecond:
                    newValue = Nanoseconds;
                    return true;
                case DurationUnit.Second:
                    newValue = Seconds;
                    return true;
                case DurationUnit.Week:
                    newValue = Weeks;
                    return true;
                case DurationUnit.Year365Days:
                    newValue = Year365Dayss;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Duration to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(DurationUnit toUnit)
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
        public string ToString(DurationUnit unit, CultureInfo culture = null)
        {
            return ToString(culture, unit, "{0:0.##} {1}", Seconds);
        }

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        public string ToString(CultureInfo culture, DurationUnit unit, string format, params object[] args)
        {
            string abbreviation = UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {Seconds, abbreviation}
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
            return ToString(DurationUnit.Second);
        }
    }
} 
