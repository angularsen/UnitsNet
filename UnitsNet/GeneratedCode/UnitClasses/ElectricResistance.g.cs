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
    ///     The electrical resistance of an electrical conductor is the opposition to the passage of an electric current through that conductor.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class ElectricResistance
#else
    public partial struct ElectricResistance : IComparable, IComparable<ElectricResistance>
#endif
    {
        /// <summary>
        ///     Base unit of ElectricResistance.
        /// </summary>
        private readonly double _ohms;

#if WINDOWS_UWP
        public ElectricResistance() : this(0)
        {
        }
#endif

        public ElectricResistance(double ohms)
        {
            _ohms = Convert.ToDouble(ohms);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        ElectricResistance(long ohms)
        {
            _ohms = Convert.ToDouble(ohms);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        ElectricResistance(decimal ohms)
        {
            _ohms = Convert.ToDouble(ohms);
        }

        #region Properties

        public static ElectricResistanceUnit BaseUnit
        {
            get { return ElectricResistanceUnit.Ohm; }
        }

        /// <summary>
        ///     Get ElectricResistance in Kiloohms.
        /// </summary>
        public double Kiloohms
        {
            get { return (_ohms) / 1e3d; }
        }

        /// <summary>
        ///     Get ElectricResistance in Megaohms.
        /// </summary>
        public double Megaohms
        {
            get { return (_ohms) / 1e6d; }
        }

        /// <summary>
        ///     Get ElectricResistance in Ohms.
        /// </summary>
        public double Ohms
        {
            get { return _ohms; }
        }

        #endregion

        #region Static

        public static ElectricResistance Zero
        {
            get { return new ElectricResistance(); }
        }

        /// <summary>
        ///     Get ElectricResistance from Kiloohms.
        /// </summary>
        public static ElectricResistance FromKiloohms(double kiloohms)
        {
            return new ElectricResistance((kiloohms) * 1e3d);
        }

        /// <summary>
        ///     Get ElectricResistance from Megaohms.
        /// </summary>
        public static ElectricResistance FromMegaohms(double megaohms)
        {
            return new ElectricResistance((megaohms) * 1e6d);
        }

        /// <summary>
        ///     Get ElectricResistance from Ohms.
        /// </summary>
        public static ElectricResistance FromOhms(double ohms)
        {
            return new ElectricResistance(ohms);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable ElectricResistance from nullable Kiloohms.
        /// </summary>
        public static ElectricResistance? FromKiloohms(double? kiloohms)
        {
            if (kiloohms.HasValue)
            {
                return FromKiloohms(kiloohms.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ElectricResistance from nullable Megaohms.
        /// </summary>
        public static ElectricResistance? FromMegaohms(double? megaohms)
        {
            if (megaohms.HasValue)
            {
                return FromMegaohms(megaohms.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ElectricResistance from nullable Ohms.
        /// </summary>
        public static ElectricResistance? FromOhms(double? ohms)
        {
            if (ohms.HasValue)
            {
                return FromOhms(ohms.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricResistanceUnit" /> to <see cref="ElectricResistance" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricResistance unit value.</returns>
        public static ElectricResistance From(double val, ElectricResistanceUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ElectricResistanceUnit.Kiloohm:
                    return FromKiloohms(val);
                case ElectricResistanceUnit.Megaohm:
                    return FromMegaohms(val);
                case ElectricResistanceUnit.Ohm:
                    return FromOhms(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricResistanceUnit" /> to <see cref="ElectricResistance" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricResistance unit value.</returns>
        public static ElectricResistance? From(double? value, ElectricResistanceUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case ElectricResistanceUnit.Kiloohm:
                    return FromKiloohms(value.Value);
                case ElectricResistanceUnit.Megaohm:
                    return FromMegaohms(value.Value);
                case ElectricResistanceUnit.Ohm:
                    return FromOhms(value.Value);

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
        public static string GetAbbreviation(ElectricResistanceUnit unit)
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
        public static string GetAbbreviation(ElectricResistanceUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static ElectricResistance operator -(ElectricResistance right)
        {
            return new ElectricResistance(-right._ohms);
        }

        public static ElectricResistance operator +(ElectricResistance left, ElectricResistance right)
        {
            return new ElectricResistance(left._ohms + right._ohms);
        }

        public static ElectricResistance operator -(ElectricResistance left, ElectricResistance right)
        {
            return new ElectricResistance(left._ohms - right._ohms);
        }

        public static ElectricResistance operator *(double left, ElectricResistance right)
        {
            return new ElectricResistance(left*right._ohms);
        }

        public static ElectricResistance operator *(ElectricResistance left, double right)
        {
            return new ElectricResistance(left._ohms*(double)right);
        }

        public static ElectricResistance operator /(ElectricResistance left, double right)
        {
            return new ElectricResistance(left._ohms/(double)right);
        }

        public static double operator /(ElectricResistance left, ElectricResistance right)
        {
            return Convert.ToDouble(left._ohms/right._ohms);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is ElectricResistance)) throw new ArgumentException("Expected type ElectricResistance.", "obj");
            return CompareTo((ElectricResistance) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(ElectricResistance other)
        {
            return _ohms.CompareTo(other._ohms);
        }

#if !WINDOWS_UWP
        public static bool operator <=(ElectricResistance left, ElectricResistance right)
        {
            return left._ohms <= right._ohms;
        }

        public static bool operator >=(ElectricResistance left, ElectricResistance right)
        {
            return left._ohms >= right._ohms;
        }

        public static bool operator <(ElectricResistance left, ElectricResistance right)
        {
            return left._ohms < right._ohms;
        }

        public static bool operator >(ElectricResistance left, ElectricResistance right)
        {
            return left._ohms > right._ohms;
        }

        public static bool operator ==(ElectricResistance left, ElectricResistance right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._ohms == right._ohms;
        }

        public static bool operator !=(ElectricResistance left, ElectricResistance right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._ohms != right._ohms;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _ohms.Equals(((ElectricResistance) obj)._ohms);
        }

        public override int GetHashCode()
        {
            return _ohms.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(ElectricResistanceUnit unit)
        {
            switch (unit)
            {
                case ElectricResistanceUnit.Kiloohm:
                    return Kiloohms;
                case ElectricResistanceUnit.Megaohm:
                    return Megaohms;
                case ElectricResistanceUnit.Ohm:
                    return Ohms;

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
        public static ElectricResistance Parse(string str)
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
        public static ElectricResistance Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => ElectricResistance.FromOhms(x.Ohms + y.Ohms));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<ElectricResistance> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<ElectricResistance>();

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
                    ElectricResistanceUnit unit = ParseUnit(unitString, formatProvider);
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
        public static ElectricResistanceUnit ParseUnit(string str)
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
        public static ElectricResistanceUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static ElectricResistanceUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<ElectricResistanceUnit>(str.Trim());

            if (unit == ElectricResistanceUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ElectricResistanceUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Ohm
        /// </summary>
        public static ElectricResistanceUnit ToStringDefaultUnit { get; set; } = ElectricResistanceUnit.Ohm;

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
        public string ToString(ElectricResistanceUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(ElectricResistanceUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(ElectricResistanceUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(ElectricResistanceUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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

        /// <summary>
        /// Represents the largest possible value of ElectricResistance
        /// </summary>
        public static ElectricResistance MaxValue
        {
            get
            {
                return new ElectricResistance(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of ElectricResistance
        /// </summary>
        public static ElectricResistance MinValue
        {
            get
            {
                return new ElectricResistance(double.MinValue);
            }
        }
    }
}
