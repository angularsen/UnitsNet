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
    ///     In mathematics, a ratio is a relationship between two numbers of the same kind (e.g., objects, persons, students, spoonfuls, units of whatever identical dimension), usually expressed as "a to b" or a:b, sometimes expressed arithmetically as a dimensionless quotient of the two that explicitly indicates how many times the first number contains the second (not necessarily an integer).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Ratio : IComparable, IComparable<Ratio>
    {
        /// <summary>
        ///     Base unit of Ratio.
        /// </summary>
        private readonly double _decimalFractions;

        public Ratio(double decimalfractions) : this()
        {
            _decimalFractions = decimalfractions;
        }

        #region Properties

        /// <summary>
        ///     Get Ratio in DecimalFractions.
        /// </summary>
        public double DecimalFractions
        {
            get { return _decimalFractions; }
        }

        /// <summary>
        ///     Get Ratio in PartsPerBillion.
        /// </summary>
        public double PartsPerBillion
        {
            get { return _decimalFractions*1e9; }
        }

        /// <summary>
        ///     Get Ratio in PartsPerMillion.
        /// </summary>
        public double PartsPerMillion
        {
            get { return _decimalFractions*1e6; }
        }

        /// <summary>
        ///     Get Ratio in PartsPerThousand.
        /// </summary>
        public double PartsPerThousand
        {
            get { return _decimalFractions*1e3; }
        }

        /// <summary>
        ///     Get Ratio in PartsPerTrillion.
        /// </summary>
        public double PartsPerTrillion
        {
            get { return _decimalFractions*1e12; }
        }

        /// <summary>
        ///     Get Ratio in Percent.
        /// </summary>
        public double Percent
        {
            get { return _decimalFractions*1e2; }
        }

        #endregion

        #region Static 

        public static Ratio Zero
        {
            get { return new Ratio(); }
        }

        /// <summary>
        ///     Get Ratio from DecimalFractions.
        /// </summary>
        public static Ratio FromDecimalFractions(double decimalfractions)
        {
            return new Ratio(decimalfractions);
        }

        /// <summary>
        ///     Get Ratio from PartsPerBillion.
        /// </summary>
        public static Ratio FromPartsPerBillion(double partsperbillion)
        {
            return new Ratio(partsperbillion/1e9);
        }

        /// <summary>
        ///     Get Ratio from PartsPerMillion.
        /// </summary>
        public static Ratio FromPartsPerMillion(double partspermillion)
        {
            return new Ratio(partspermillion/1e6);
        }

        /// <summary>
        ///     Get Ratio from PartsPerThousand.
        /// </summary>
        public static Ratio FromPartsPerThousand(double partsperthousand)
        {
            return new Ratio(partsperthousand/1e3);
        }

        /// <summary>
        ///     Get Ratio from PartsPerTrillion.
        /// </summary>
        public static Ratio FromPartsPerTrillion(double partspertrillion)
        {
            return new Ratio(partspertrillion/1e12);
        }

        /// <summary>
        ///     Get Ratio from Percent.
        /// </summary>
        public static Ratio FromPercent(double percent)
        {
            return new Ratio(percent/1e2);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RatioUnit" /> to <see cref="Ratio" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Ratio unit value.</returns>
        public static Ratio From(double value, RatioUnit fromUnit)
        {
            switch (fromUnit)
            {
                case RatioUnit.DecimalFraction:
                    return FromDecimalFractions(value);
                case RatioUnit.PartPerBillion:
                    return FromPartsPerBillion(value);
                case RatioUnit.PartPerMillion:
                    return FromPartsPerMillion(value);
                case RatioUnit.PartPerThousand:
                    return FromPartsPerThousand(value);
                case RatioUnit.PartPerTrillion:
                    return FromPartsPerTrillion(value);
                case RatioUnit.Percent:
                    return FromPercent(value);

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
        public static string GetAbbreviation(RatioUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Ratio operator -(Ratio right)
        {
            return new Ratio(-right._decimalFractions);
        }

        public static Ratio operator +(Ratio left, Ratio right)
        {
            return new Ratio(left._decimalFractions + right._decimalFractions);
        }

        public static Ratio operator -(Ratio left, Ratio right)
        {
            return new Ratio(left._decimalFractions - right._decimalFractions);
        }

        public static Ratio operator *(double left, Ratio right)
        {
            return new Ratio(left*right._decimalFractions);
        }

        public static Ratio operator *(Ratio left, double right)
        {
            return new Ratio(left._decimalFractions*(double)right);
        }

        public static Ratio operator /(Ratio left, double right)
        {
            return new Ratio(left._decimalFractions/(double)right);
        }

        public static double operator /(Ratio left, Ratio right)
        {
            return Convert.ToDouble(left._decimalFractions/right._decimalFractions);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Ratio)) throw new ArgumentException("Expected type Ratio.", "obj");
            return CompareTo((Ratio) obj);
        }

        public int CompareTo(Ratio other)
        {
            return _decimalFractions.CompareTo(other._decimalFractions);
        }

        public static bool operator <=(Ratio left, Ratio right)
        {
            return left._decimalFractions <= right._decimalFractions;
        }

        public static bool operator >=(Ratio left, Ratio right)
        {
            return left._decimalFractions >= right._decimalFractions;
        }

        public static bool operator <(Ratio left, Ratio right)
        {
            return left._decimalFractions < right._decimalFractions;
        }

        public static bool operator >(Ratio left, Ratio right)
        {
            return left._decimalFractions > right._decimalFractions;
        }

        public static bool operator ==(Ratio left, Ratio right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decimalFractions == right._decimalFractions;
        }

        public static bool operator !=(Ratio left, Ratio right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decimalFractions != right._decimalFractions;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _decimalFractions.Equals(((Ratio) obj)._decimalFractions);
        }

        public override int GetHashCode()
        {
            return _decimalFractions.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(RatioUnit unit)
        {
            switch (unit)
            {
                case RatioUnit.DecimalFraction:
                    return DecimalFractions;
                case RatioUnit.PartPerBillion:
                    return PartsPerBillion;
                case RatioUnit.PartPerMillion:
                    return PartsPerMillion;
                case RatioUnit.PartPerThousand:
                    return PartsPerThousand;
                case RatioUnit.PartPerTrillion:
                    return PartsPerTrillion;
                case RatioUnit.Percent:
                    return Percent;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string with at least one quantity of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected valid quantity and unit. Input string needs to have at least one valid quantity in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;".
        /// </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static Ratio Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var regexString = string.Format(@"(?:(?<value>[-+]?{0}{1}{2}{3}\s?)+?",
                            numRegex,              // capture base (integral) Quantity value
                            @"(?:[eE][-+]?\d+)?)", // capture exponential (if any), end of Quantity capturing
                            @"\s?",                // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>[^\s\d]+)"); // capture Unit (non-numeric, non-whitespace) input

            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Ratio>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;

                try
                {
                    RatioUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch (Exception e)
                {
                    var newEx = new UnitsNetException("Error parsing string.", e);
                    newEx.Data["input"] = str;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
            }

            if(converted.Count == 0) // No valid matches
            {
                var ex = new ArgumentException(
                    "Expected valid quantity and unit. Input string needs to have at least one valid quantity in the format \"<quantity><unit> or <quantity> <unit>\".", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }
            return converted.Aggregate((x, y) => x + y);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static RatioUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<RatioUnit>(str.Trim());

            if (unit == RatioUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized RatioUnit.");
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
            return ToString(RatioUnit.DecimalFraction);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(RatioUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(RatioUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
