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
using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     The strength of a signal expressed in decibels (dB) relative to one volt RMS.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
	[DataContract]
    public partial struct AmplitudeRatio : IComparable, IComparable<AmplitudeRatio>
    {
        /// <summary>
        ///     Base unit of AmplitudeRatio.
        /// </summary>
		[DataMember]
        private readonly double _decibelVolts;

        public AmplitudeRatio(double decibelvolts) : this()
        {
            _decibelVolts = decibelvolts;
        }

        #region Properties

        public static AmplitudeRatioUnit BaseUnit
        {
            get { return AmplitudeRatioUnit.DecibelVolt; }
        }

        /// <summary>
        ///     Get AmplitudeRatio in DecibelMicrovolts.
        /// </summary>
        public double DecibelMicrovolts
        {
            get { return _decibelVolts + 120; }
        }

        /// <summary>
        ///     Get AmplitudeRatio in DecibelMillivolts.
        /// </summary>
        public double DecibelMillivolts
        {
            get { return _decibelVolts + 60; }
        }

        /// <summary>
        ///     Get AmplitudeRatio in DecibelVolts.
        /// </summary>
        public double DecibelVolts
        {
            get { return _decibelVolts; }
        }

        #endregion

        #region Static 

        public static AmplitudeRatio Zero
        {
            get { return new AmplitudeRatio(); }
        }

        /// <summary>
        ///     Get AmplitudeRatio from DecibelMicrovolts.
        /// </summary>
        public static AmplitudeRatio FromDecibelMicrovolts(double decibelmicrovolts)
        {
            return new AmplitudeRatio(decibelmicrovolts - 120);
        }

        /// <summary>
        ///     Get AmplitudeRatio from DecibelMillivolts.
        /// </summary>
        public static AmplitudeRatio FromDecibelMillivolts(double decibelmillivolts)
        {
            return new AmplitudeRatio(decibelmillivolts - 60);
        }

        /// <summary>
        ///     Get AmplitudeRatio from DecibelVolts.
        /// </summary>
        public static AmplitudeRatio FromDecibelVolts(double decibelvolts)
        {
            return new AmplitudeRatio(decibelvolts);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AmplitudeRatioUnit" /> to <see cref="AmplitudeRatio" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>AmplitudeRatio unit value.</returns>
        public static AmplitudeRatio From(double value, AmplitudeRatioUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AmplitudeRatioUnit.DecibelMicrovolt:
                    return FromDecibelMicrovolts(value);
                case AmplitudeRatioUnit.DecibelMillivolt:
                    return FromDecibelMillivolts(value);
                case AmplitudeRatioUnit.DecibelVolt:
                    return FromDecibelVolts(value);

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
        public static string GetAbbreviation(AmplitudeRatioUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Logarithmic Arithmetic Operators

        public static AmplitudeRatio operator -(AmplitudeRatio right)
        {
            return new AmplitudeRatio(-right._decibelVolts);
        }

        public static AmplitudeRatio operator +(AmplitudeRatio left, AmplitudeRatio right)
        {
            // Logarithmic addition
            // Formula: 20*log10(10^(x/20) + 10^(y/20))
            return new AmplitudeRatio(20*Math.Log10(Math.Pow(10, left._decibelVolts/20) + Math.Pow(10, right._decibelVolts/20)));
        }

        public static AmplitudeRatio operator -(AmplitudeRatio left, AmplitudeRatio right)
        {
            // Logarithmic subtraction 
            // Formula: 20*log10(10^(x/20) - 10^(y/20))
            return new AmplitudeRatio(20*Math.Log10(Math.Pow(10, left._decibelVolts/20) - Math.Pow(10, right._decibelVolts/20)));
        }

        public static AmplitudeRatio operator *(double left, AmplitudeRatio right)
        {
            // Logarithmic multiplication = addition
            return new AmplitudeRatio(left + right._decibelVolts);
        }

        public static AmplitudeRatio operator *(AmplitudeRatio left, double right)
        {
            // Logarithmic multiplication = addition
            return new AmplitudeRatio(left._decibelVolts + (double)right);
        }

        public static AmplitudeRatio operator /(AmplitudeRatio left, double right)
        {
            // Logarithmic division = subtraction
            return new AmplitudeRatio(left._decibelVolts - (double)right);
        }

        public static double operator /(AmplitudeRatio left, AmplitudeRatio right)
        {
            // Logarithmic division = subtraction
            return Convert.ToDouble(left._decibelVolts - right._decibelVolts);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is AmplitudeRatio)) throw new ArgumentException("Expected type AmplitudeRatio.", "obj");
            return CompareTo((AmplitudeRatio) obj);
        }

        public int CompareTo(AmplitudeRatio other)
        {
            return _decibelVolts.CompareTo(other._decibelVolts);
        }

        public static bool operator <=(AmplitudeRatio left, AmplitudeRatio right)
        {
            return left._decibelVolts <= right._decibelVolts;
        }

        public static bool operator >=(AmplitudeRatio left, AmplitudeRatio right)
        {
            return left._decibelVolts >= right._decibelVolts;
        }

        public static bool operator <(AmplitudeRatio left, AmplitudeRatio right)
        {
            return left._decibelVolts < right._decibelVolts;
        }

        public static bool operator >(AmplitudeRatio left, AmplitudeRatio right)
        {
            return left._decibelVolts > right._decibelVolts;
        }

        public static bool operator ==(AmplitudeRatio left, AmplitudeRatio right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decibelVolts == right._decibelVolts;
        }

        public static bool operator !=(AmplitudeRatio left, AmplitudeRatio right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decibelVolts != right._decibelVolts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _decibelVolts.Equals(((AmplitudeRatio) obj)._decibelVolts);
        }

        public override int GetHashCode()
        {
            return _decibelVolts.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AmplitudeRatioUnit unit)
        {
            switch (unit)
            {
                case AmplitudeRatioUnit.DecibelMicrovolt:
                    return DecibelMicrovolts;
                case AmplitudeRatioUnit.DecibelMillivolt:
                    return DecibelMillivolts;
                case AmplitudeRatioUnit.DecibelVolt:
                    return DecibelVolts;

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
        public static AmplitudeRatio Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<AmplitudeRatio> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<AmplitudeRatio>();

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
                    AmplitudeRatioUnit unit = ParseUnit(unitString, formatProvider);
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
        public static AmplitudeRatioUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<AmplitudeRatioUnit>(str.Trim());

            if (unit == AmplitudeRatioUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized AmplitudeRatioUnit.");
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
            return ToString(AmplitudeRatioUnit.DecibelVolt);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(AmplitudeRatioUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(AmplitudeRatioUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
