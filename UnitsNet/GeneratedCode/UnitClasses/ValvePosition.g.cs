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
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Valve position is the current position of the damper relative to the perpendicular cross-section of the pipeline. Full throttle cross section perpendicular to the pipe. Fully closed damper coincides section of the pipeline.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct ValvePosition : IComparable, IComparable<ValvePosition>
    {
        /// <summary>
        ///     Base unit of ValvePosition.
        /// </summary>
        private readonly double _openPercentages;

        public ValvePosition(double openpercentages) : this()
        {
            _openPercentages = openpercentages;
        }

        #region Properties

        /// <summary>
        ///     Get ValvePosition in ClosePercentages.
        /// </summary>
        public double ClosePercentages
        {
            get { return 100 - _openPercentages; }
        }

        /// <summary>
        ///     Get ValvePosition in Degrees.
        /// </summary>
        public double Degrees
        {
            get { return _openPercentages * 0.9; }
        }

        /// <summary>
        ///     Get ValvePosition in OpenPercentages.
        /// </summary>
        public double OpenPercentages
        {
            get { return _openPercentages; }
        }

        #endregion

        #region Static 

        public static ValvePosition Zero
        {
            get { return new ValvePosition(); }
        }

        /// <summary>
        ///     Get ValvePosition from ClosePercentages.
        /// </summary>
        public static ValvePosition FromClosePercentages(double closepercentages)
        {
            return new ValvePosition(100 - closepercentages);
        }

        /// <summary>
        ///     Get ValvePosition from Degrees.
        /// </summary>
        public static ValvePosition FromDegrees(double degrees)
        {
            return new ValvePosition(degrees / 0.9);
        }

        /// <summary>
        ///     Get ValvePosition from OpenPercentages.
        /// </summary>
        public static ValvePosition FromOpenPercentages(double openpercentages)
        {
            return new ValvePosition(openpercentages);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ValvePositionUnit" /> to <see cref="ValvePosition" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ValvePosition unit value.</returns>
        public static ValvePosition From(double value, ValvePositionUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ValvePositionUnit.ClosePercentage:
                    return FromClosePercentages(value);
                case ValvePositionUnit.Degree:
                    return FromDegrees(value);
                case ValvePositionUnit.OpenPercentage:
                    return FromOpenPercentages(value);

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
        public static string GetAbbreviation(ValvePositionUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static ValvePosition operator -(ValvePosition right)
        {
            return new ValvePosition(-right._openPercentages);
        }

        public static ValvePosition operator +(ValvePosition left, ValvePosition right)
        {
            return new ValvePosition(left._openPercentages + right._openPercentages);
        }

        public static ValvePosition operator -(ValvePosition left, ValvePosition right)
        {
            return new ValvePosition(left._openPercentages - right._openPercentages);
        }

        public static ValvePosition operator *(double left, ValvePosition right)
        {
            return new ValvePosition(left*right._openPercentages);
        }

        public static ValvePosition operator *(ValvePosition left, double right)
        {
            return new ValvePosition(left._openPercentages*(double)right);
        }

        public static ValvePosition operator /(ValvePosition left, double right)
        {
            return new ValvePosition(left._openPercentages/(double)right);
        }

        public static double operator /(ValvePosition left, ValvePosition right)
        {
            return Convert.ToDouble(left._openPercentages/right._openPercentages);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is ValvePosition)) throw new ArgumentException("Expected type ValvePosition.", "obj");
            return CompareTo((ValvePosition) obj);
        }

        public int CompareTo(ValvePosition other)
        {
            return _openPercentages.CompareTo(other._openPercentages);
        }

        public static bool operator <=(ValvePosition left, ValvePosition right)
        {
            return left._openPercentages <= right._openPercentages;
        }

        public static bool operator >=(ValvePosition left, ValvePosition right)
        {
            return left._openPercentages >= right._openPercentages;
        }

        public static bool operator <(ValvePosition left, ValvePosition right)
        {
            return left._openPercentages < right._openPercentages;
        }

        public static bool operator >(ValvePosition left, ValvePosition right)
        {
            return left._openPercentages > right._openPercentages;
        }

        public static bool operator ==(ValvePosition left, ValvePosition right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._openPercentages == right._openPercentages;
        }

        public static bool operator !=(ValvePosition left, ValvePosition right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._openPercentages != right._openPercentages;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _openPercentages.Equals(((ValvePosition) obj)._openPercentages);
        }

        public override int GetHashCode()
        {
            return _openPercentages.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(ValvePositionUnit unit)
        {
            switch (unit)
            {
                case ValvePositionUnit.ClosePercentage:
                    return ClosePercentages;
                case ValvePositionUnit.Degree:
                    return Degrees;
                case ValvePositionUnit.OpenPercentage:
                    return OpenPercentages;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in" 
        /// </exception>
        public static ValvePosition Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

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
            return quantities.Aggregate((x, y) => x + y);
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<ValvePosition> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<ValvePosition>();

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
                    ValvePositionUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch (Exception ex)
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
        public static ValvePositionUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<ValvePositionUnit>(str.Trim());

            if (unit == ValvePositionUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ValvePositionUnit.");
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
            return ToString(ValvePositionUnit.OpenPercentage);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(ValvePositionUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(ValvePositionUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
