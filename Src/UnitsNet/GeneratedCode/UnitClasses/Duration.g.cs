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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Time is a dimension in which events can be ordered from the past through the present into the future, and also the measure of durations of events and the intervals between them.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Duration : IComparable, IComparable<Duration>
    {
        /// <summary>
        ///     Base unit of Duration.
        /// </summary>
        private readonly double _seconds;

        public Duration(double seconds) : this()
        {
            _seconds = seconds;
        }

        #region Properties

        /// <summary>
        ///     Get Duration in Days.
        /// </summary>
        public double Days
        {
            get { return _seconds/(24*3600); }
        }

        /// <summary>
        ///     Get Duration in Hours.
        /// </summary>
        public double Hours
        {
            get { return _seconds/3600; }
        }

        /// <summary>
        ///     Get Duration in Microseconds.
        /// </summary>
        public double Microseconds
        {
            get { return _seconds*1e6; }
        }

        /// <summary>
        ///     Get Duration in Milliseconds.
        /// </summary>
        public double Milliseconds
        {
            get { return _seconds*1e3; }
        }

        /// <summary>
        ///     Get Duration in Minutes.
        /// </summary>
        public double Minutes
        {
            get { return _seconds/60; }
        }

        /// <summary>
        ///     Get Duration in Months.
        /// </summary>
        public double Months
        {
            get { return _seconds/(30*24*3600); }
        }

        /// <summary>
        ///     Get Duration in Nanoseconds.
        /// </summary>
        public double Nanoseconds
        {
            get { return _seconds*1e9; }
        }

        /// <summary>
        ///     Get Duration in Seconds.
        /// </summary>
        public double Seconds
        {
            get { return _seconds; }
        }

        /// <summary>
        ///     Get Duration in Weeks.
        /// </summary>
        public double Weeks
        {
            get { return _seconds/(7*24*3600); }
        }

        /// <summary>
        ///     Get Duration in Years.
        /// </summary>
        public double Years
        {
            get { return _seconds/(365*24*3600); }
        }

        #endregion

        #region Static 

        public static Duration Zero
        {
            get { return new Duration(); }
        }

        /// <summary>
        ///     Get Duration from Days.
        /// </summary>
        public static Duration FromDays(double days)
        {
            return new Duration(days*24*3600);
        }

        /// <summary>
        ///     Get Duration from Hours.
        /// </summary>
        public static Duration FromHours(double hours)
        {
            return new Duration(hours*3600);
        }

        /// <summary>
        ///     Get Duration from Microseconds.
        /// </summary>
        public static Duration FromMicroseconds(double microseconds)
        {
            return new Duration(microseconds/1e6);
        }

        /// <summary>
        ///     Get Duration from Milliseconds.
        /// </summary>
        public static Duration FromMilliseconds(double milliseconds)
        {
            return new Duration(milliseconds/1e3);
        }

        /// <summary>
        ///     Get Duration from Minutes.
        /// </summary>
        public static Duration FromMinutes(double minutes)
        {
            return new Duration(minutes*60);
        }

        /// <summary>
        ///     Get Duration from Months.
        /// </summary>
        public static Duration FromMonths(double months)
        {
            return new Duration(months*30*24*3600);
        }

        /// <summary>
        ///     Get Duration from Nanoseconds.
        /// </summary>
        public static Duration FromNanoseconds(double nanoseconds)
        {
            return new Duration(nanoseconds/1e9);
        }

        /// <summary>
        ///     Get Duration from Seconds.
        /// </summary>
        public static Duration FromSeconds(double seconds)
        {
            return new Duration(seconds);
        }

        /// <summary>
        ///     Get Duration from Weeks.
        /// </summary>
        public static Duration FromWeeks(double weeks)
        {
            return new Duration(weeks*7*24*3600);
        }

        /// <summary>
        ///     Get Duration from Years.
        /// </summary>
        public static Duration FromYears(double years)
        {
            return new Duration(years*365*24*3600);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="DurationUnit" /> to <see cref="Duration" />.
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
                case DurationUnit.Month:
                    return FromMonths(value);
                case DurationUnit.Nanosecond:
                    return FromNanoseconds(value);
                case DurationUnit.Second:
                    return FromSeconds(value);
                case DurationUnit.Week:
                    return FromWeeks(value);
                case DurationUnit.Year:
                    return FromYears(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(DurationUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Duration operator -(Duration right)
        {
            return new Duration(-right._seconds);
        }

        public static Duration operator +(Duration left, Duration right)
        {
            return new Duration(left._seconds + right._seconds);
        }

        public static Duration operator -(Duration left, Duration right)
        {
            return new Duration(left._seconds - right._seconds);
        }

        public static Duration operator *(double left, Duration right)
        {
            return new Duration(left*right._seconds);
        }

        public static Duration operator *(Duration left, double right)
        {
            return new Duration(left._seconds*(double)right);
        }

        public static Duration operator /(Duration left, double right)
        {
            return new Duration(left._seconds/(double)right);
        }

        public static double operator /(Duration left, Duration right)
        {
            return Convert.ToDouble(left._seconds/right._seconds);
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
            return _seconds.CompareTo(other._seconds);
        }

        public static bool operator <=(Duration left, Duration right)
        {
            return left._seconds <= right._seconds;
        }

        public static bool operator >=(Duration left, Duration right)
        {
            return left._seconds >= right._seconds;
        }

        public static bool operator <(Duration left, Duration right)
        {
            return left._seconds < right._seconds;
        }

        public static bool operator >(Duration left, Duration right)
        {
            return left._seconds > right._seconds;
        }

        public static bool operator ==(Duration left, Duration right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._seconds == right._seconds;
        }

        public static bool operator !=(Duration left, Duration right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._seconds != right._seconds;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _seconds.Equals(((Duration) obj)._seconds);
        }

        public override int GetHashCode()
        {
            return _seconds.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(DurationUnit unit)
        {
            switch (unit)
            {
                case DurationUnit.Day:
                    return Days;
                case DurationUnit.Hour:
                    return Hours;
                case DurationUnit.Microsecond:
                    return Microseconds;
                case DurationUnit.Millisecond:
                    return Milliseconds;
                case DurationUnit.Minute:
                    return Minutes;
                case DurationUnit.Month:
                    return Months;
                case DurationUnit.Nanosecond:
                    return Nanoseconds;
                case DurationUnit.Second:
                    return Seconds;
                case DurationUnit.Week:
                    return Weeks;
                case DurationUnit.Year:
                    return Years;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected 2 words. Input string needs to be in the format "&lt;quantity&gt; &lt;unit
        ///     &gt;".
        /// </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static Duration Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format("{0}{1}{2}{3}",
                                @"[\d., ",                        // allows digits, dots, commas, and spaces in the number by default
                                numFormat.NumberGroupSeparator,   // adds provided (or current) culture's group separator
                                numFormat.NumberDecimalSeparator, // adds provided (or current) culture's decimal separator
                                @"]*\d");                         // ensures quantity ends in digit
            var regexString = string.Format("{0}{1}{2}{3}{4}",
                                @"(?<value>[-+]?",                // start capturing Quantity
                                numRegex,                         // parse base (integral) Quantity value
                                @"(?:[eE][-+]?\d+)?)",            // capture Quantity exponential (if any), end capturing Quantity
                                @"\s?",                           // ignore whitespace (allows both "1kg", "1 kg")
                                @"(?<unit>\S+)");                 // capture Unit (non-whitespace) input

            var regex = new Regex(regexString);
            GroupCollection groups = regex.Match(str.Trim()).Groups;

            var valueString = groups["value"].Value;
            var unitString = groups["unit"].Value;

            if (valueString == "" || unitString == "")
            {
                var ex = new ArgumentException(
                    "Expected valid quantity and unit. Input string needs to be in the format \"<quantity><unit> or <quantity> <unit>\".", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }

            try
            {
                DurationUnit unit = ParseUnit(unitString, formatProvider);
                double value = double.Parse(valueString, formatProvider);

                return From(value, unit);
            }
            catch (Exception e)
            {
                var newEx = new UnitsNetException("Error parsing string.", e);
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static DurationUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<DurationUnit>(str.Trim());

            if (unit == DurationUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized DurationUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(DurationUnit.Second);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(DurationUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
        {
            return ToString(unit, culture, UnitFormatter.GetFormat(As(unit), significantDigitsAfterRadix));
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(DurationUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
