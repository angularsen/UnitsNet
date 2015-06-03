﻿// Copyright © 2007 by Initial Force AS.  All rights reserved.
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
    ///     Quantity .
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct ForceFlowRate : IComparable, IComparable<ForceFlowRate>
    {
        /// <summary>
        ///     Base unit of ForceFlowRate.
        /// </summary>
        private readonly double _newtonsPerSecond;

        public ForceFlowRate(double newtonspersecond) : this()
        {
            _newtonsPerSecond = newtonspersecond;
        }

        #region Properties

        /// <summary>
        ///     Get ForceFlowRate in NewtonsPerSecond.
        /// </summary>
        public double NewtonsPerSecond
        {
            get { return _newtonsPerSecond; }
        }

        #endregion

        #region Static 

        public static ForceFlowRate Zero
        {
            get { return new ForceFlowRate(); }
        }

        /// <summary>
        ///     Get ForceFlowRate from NewtonsPerSecond.
        /// </summary>
        public static ForceFlowRate FromNewtonsPerSecond(double newtonspersecond)
        {
            return new ForceFlowRate(newtonspersecond);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ForceFlowRateUnit" /> to <see cref="ForceFlowRate" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ForceFlowRate unit value.</returns>
        public static ForceFlowRate From(double value, ForceFlowRateUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ForceFlowRateUnit.NewtonPerSecond:
                    return FromNewtonsPerSecond(value);

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
        public static string GetAbbreviation(ForceFlowRateUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static ForceFlowRate operator -(ForceFlowRate right)
        {
            return new ForceFlowRate(-right._newtonsPerSecond);
        }

        public static ForceFlowRate operator +(ForceFlowRate left, ForceFlowRate right)
        {
            return new ForceFlowRate(left._newtonsPerSecond + right._newtonsPerSecond);
        }

        public static ForceFlowRate operator -(ForceFlowRate left, ForceFlowRate right)
        {
            return new ForceFlowRate(left._newtonsPerSecond - right._newtonsPerSecond);
        }

        public static ForceFlowRate operator *(double left, ForceFlowRate right)
        {
            return new ForceFlowRate(left*right._newtonsPerSecond);
        }

        public static ForceFlowRate operator *(ForceFlowRate left, double right)
        {
            return new ForceFlowRate(left._newtonsPerSecond*(double)right);
        }

        public static ForceFlowRate operator /(ForceFlowRate left, double right)
        {
            return new ForceFlowRate(left._newtonsPerSecond/(double)right);
        }

        public static double operator /(ForceFlowRate left, ForceFlowRate right)
        {
            return Convert.ToDouble(left._newtonsPerSecond/right._newtonsPerSecond);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is ForceFlowRate)) throw new ArgumentException("Expected type ForceFlowRate.", "obj");
            return CompareTo((ForceFlowRate) obj);
        }

        public int CompareTo(ForceFlowRate other)
        {
            return _newtonsPerSecond.CompareTo(other._newtonsPerSecond);
        }

        public static bool operator <=(ForceFlowRate left, ForceFlowRate right)
        {
            return left._newtonsPerSecond <= right._newtonsPerSecond;
        }

        public static bool operator >=(ForceFlowRate left, ForceFlowRate right)
        {
            return left._newtonsPerSecond >= right._newtonsPerSecond;
        }

        public static bool operator <(ForceFlowRate left, ForceFlowRate right)
        {
            return left._newtonsPerSecond < right._newtonsPerSecond;
        }

        public static bool operator >(ForceFlowRate left, ForceFlowRate right)
        {
            return left._newtonsPerSecond > right._newtonsPerSecond;
        }

        public static bool operator ==(ForceFlowRate left, ForceFlowRate right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonsPerSecond == right._newtonsPerSecond;
        }

        public static bool operator !=(ForceFlowRate left, ForceFlowRate right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonsPerSecond != right._newtonsPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _newtonsPerSecond.Equals(((ForceFlowRate) obj)._newtonsPerSecond);
        }

        public override int GetHashCode()
        {
            return _newtonsPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(ForceFlowRateUnit unit)
        {
            switch (unit)
            {
                case ForceFlowRateUnit.NewtonPerSecond:
                    return NewtonsPerSecond;

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
        public static ForceFlowRate Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var regexString = string.Format("(?<value>[-+]?{0}{1}{2}{3}",
                            numRegex,              // capture base (integral) Quantity value
                            @"(?:[eE][-+]?\d+)?)", // capture exponential (if any), end of Quantity capturing
                            @"\s?",                // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>\S+)");      // capture Unit (non-whitespace) input

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
                ForceFlowRateUnit unit = ParseUnit(unitString, formatProvider);
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
        public static ForceFlowRateUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<ForceFlowRateUnit>(str.Trim());

            if (unit == ForceFlowRateUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ForceFlowRateUnit.");
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
            return ToString(ForceFlowRateUnit.NewtonPerSecond);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(ForceFlowRateUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(ForceFlowRateUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
