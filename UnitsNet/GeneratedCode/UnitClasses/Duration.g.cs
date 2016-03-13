// Copyright © 2007 by Initial Force AS.  All rights reserved.
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
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

#if WINDOWS_UWP
using Culture = System.String;
#else
using Culture = System.IFormatProvider;
#endif

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Time is a dimension in which events can be ordered from the past through the present into the future, and also the measure of durations of events and the intervals between them.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Duration
#else
    public partial struct Duration : IComparable, IComparable<Duration>
#endif
    {
        /// <summary>
        ///     Base unit of Duration.
        /// </summary>
        private readonly double _seconds;

#if WINDOWS_UWP
        public Duration() : this(0)
        {
        }
#endif

        public Duration(double seconds)
        {
            _seconds = Convert.ToDouble(seconds);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Duration(long seconds)
        {
            _seconds = Convert.ToDouble(seconds);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Duration(decimal seconds)
        {
            _seconds = Convert.ToDouble(seconds);
        }

        #region Properties

        public static DurationUnit BaseUnit
        {
            get { return DurationUnit.Second; }
        }

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

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Duration from nullable Days.
        /// </summary>
        public static Duration? FromDays(double? days)
        {
            if (days.HasValue)
            {
                return FromDays(days.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Hours.
        /// </summary>
        public static Duration? FromHours(double? hours)
        {
            if (hours.HasValue)
            {
                return FromHours(hours.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Microseconds.
        /// </summary>
        public static Duration? FromMicroseconds(double? microseconds)
        {
            if (microseconds.HasValue)
            {
                return FromMicroseconds(microseconds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Milliseconds.
        /// </summary>
        public static Duration? FromMilliseconds(double? milliseconds)
        {
            if (milliseconds.HasValue)
            {
                return FromMilliseconds(milliseconds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Minutes.
        /// </summary>
        public static Duration? FromMinutes(double? minutes)
        {
            if (minutes.HasValue)
            {
                return FromMinutes(minutes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Months.
        /// </summary>
        public static Duration? FromMonths(double? months)
        {
            if (months.HasValue)
            {
                return FromMonths(months.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Nanoseconds.
        /// </summary>
        public static Duration? FromNanoseconds(double? nanoseconds)
        {
            if (nanoseconds.HasValue)
            {
                return FromNanoseconds(nanoseconds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Seconds.
        /// </summary>
        public static Duration? FromSeconds(double? seconds)
        {
            if (seconds.HasValue)
            {
                return FromSeconds(seconds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Weeks.
        /// </summary>
        public static Duration? FromWeeks(double? weeks)
        {
            if (weeks.HasValue)
            {
                return FromWeeks(weeks.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Duration from nullable Years.
        /// </summary>
        public static Duration? FromYears(double? years)
        {
            if (years.HasValue)
            {
                return FromYears(years.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="DurationUnit" /> to <see cref="Duration" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Duration unit value.</returns>
        public static Duration From(double val, DurationUnit fromUnit)
        {
            switch (fromUnit)
            {
                case DurationUnit.Day:
                    return FromDays(val);
                case DurationUnit.Hour:
                    return FromHours(val);
                case DurationUnit.Microsecond:
                    return FromMicroseconds(val);
                case DurationUnit.Millisecond:
                    return FromMilliseconds(val);
                case DurationUnit.Minute:
                    return FromMinutes(val);
                case DurationUnit.Month:
                    return FromMonths(val);
                case DurationUnit.Nanosecond:
                    return FromNanoseconds(val);
                case DurationUnit.Second:
                    return FromSeconds(val);
                case DurationUnit.Week:
                    return FromWeeks(val);
                case DurationUnit.Year:
                    return FromYears(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="DurationUnit" /> to <see cref="Duration" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Duration unit value.</returns>
        public static Duration? From(double? value, DurationUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case DurationUnit.Day:
                    return FromDays(value.Value);
                case DurationUnit.Hour:
                    return FromHours(value.Value);
                case DurationUnit.Microsecond:
                    return FromMicroseconds(value.Value);
                case DurationUnit.Millisecond:
                    return FromMilliseconds(value.Value);
                case DurationUnit.Minute:
                    return FromMinutes(value.Value);
                case DurationUnit.Month:
                    return FromMonths(value.Value);
                case DurationUnit.Nanosecond:
                    return FromNanoseconds(value.Value);
                case DurationUnit.Second:
                    return FromSeconds(value.Value);
                case DurationUnit.Week:
                    return FromWeeks(value.Value);
                case DurationUnit.Year:
                    return FromYears(value.Value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
#endif

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(DurationUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(DurationUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
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
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Duration)) throw new ArgumentException("Expected type Duration.", "obj");
            return CompareTo((Duration) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Duration other)
        {
            return _seconds.CompareTo(other._seconds);
        }

#if !WINDOWS_UWP
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
#endif

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
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static Duration Parse(string str)
        {
            return Parse(str, null);
        }

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="culture">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static Duration Parse(string str, [CanBeNull] Culture culture)
        {
            if (str == null) throw new ArgumentNullException("str");

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var exponentialRegex = @"(?:[eE][-+]?\d+)?)";
            var regexString = string.Format(@"(?:\s*(?<value>[-+]?{0}{1}{2}{3})?{4}{5}",
                            numRegex,                // capture base (integral) Quantity value
                            exponentialRegex,        // capture exponential (if any), end of Quantity capturing
                            @"\s?",                  // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>[^\s\d,]+)",   // capture Unit (non-whitespace) input
                            @"(and)?,?",             // allow "and" & "," separators between quantities
                            @"(?<invalid>[a-z]*)?"); // capture invalid input

            var quantities = ParseWithRegex(regexString, str, formatProvider);
            if (quantities.Count == 0)
            {
                throw new ArgumentException(
                    "Expected string to have at least one pair of quantity and unit in the format"
                    + " \"&lt;quantity&gt; &lt;unit&gt;\". Eg. \"5.5 m\" or \"1ft 2in\"");
            }
            return quantities.Aggregate((x, y) => Duration.FromSeconds(x.Seconds + y.Seconds));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Duration> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Duration>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;
                if (groups["invalid"].Value != "")
                {
                    var newEx = new UnitsNetException("Invalid string detected: " + groups["invalid"].Value);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
                if (valueString == "" && unitString == "") continue;

                try
                {
                    DurationUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch(AmbiguousUnitParseException)
                {
                    throw;
                }
                catch(Exception ex)
                {
                    var newEx = new UnitsNetException("Error parsing string.", ex);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
            }
            return converted;
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static DurationUnit ParseUnit(string str)
        {
            return ParseUnit(str, (IFormatProvider)null);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static DurationUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            return ParseUnit(str, cultureName == null ? null : new CultureInfo(cultureName));
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static DurationUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<DurationUnit>(str.Trim());

            if (unit == DurationUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized DurationUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Second
        /// </summary>
        public static DurationUnit ToStringDefaultUnit { get; set; } = DurationUnit.Second;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(ToStringDefaultUnit);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(DurationUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(DurationUnit unit, [CanBeNull] Culture culture)
        {
            return ToString(unit, culture, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(DurationUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
        {
            double value = As(unit);
            string format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(unit, culture, format);
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
        public string ToString(DurationUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
            [NotNull] params object[] args)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            double value = As(unit);
            object[] formatArgs = UnitFormatter.GetFormatArgs(unit, value, formatProvider, args);
            return string.Format(formatProvider, format, formatArgs);
        }
    }
}
