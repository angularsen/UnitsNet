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
    ///     An electric current is a flow of electric charge. In electric circuits this charge is often carried by moving electrons in a wire. It can also be carried by ions in an electrolyte, or by both ions and electrons such as in a plasma.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
	[DataContract]
    public partial struct ElectricCurrent : IComparable, IComparable<ElectricCurrent>
    {
        /// <summary>
        ///     Base unit of ElectricCurrent.
        /// </summary>
		[DataMember]
        private readonly double _amperes;

        public ElectricCurrent(double amperes) : this()
        {
            _amperes = amperes;
        }

        #region Properties

        /// <summary>
        ///     Get ElectricCurrent in Amperes.
        /// </summary>
        public double Amperes
        {
            get { return _amperes; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Kiloamperes.
        /// </summary>
        public double Kiloamperes
        {
            get { return (_amperes) / 1e3d; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Megaamperes.
        /// </summary>
        public double Megaamperes
        {
            get { return (_amperes) / 1e6d; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Microamperes.
        /// </summary>
        public double Microamperes
        {
            get { return (_amperes) / 1e-6d; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Milliamperes.
        /// </summary>
        public double Milliamperes
        {
            get { return (_amperes) / 1e-3d; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Nanoamperes.
        /// </summary>
        public double Nanoamperes
        {
            get { return (_amperes) / 1e-9d; }
        }

        #endregion

        #region Static 

        public static ElectricCurrent Zero
        {
            get { return new ElectricCurrent(); }
        }

        /// <summary>
        ///     Get ElectricCurrent from Amperes.
        /// </summary>
        public static ElectricCurrent FromAmperes(double amperes)
        {
            return new ElectricCurrent(amperes);
        }

        /// <summary>
        ///     Get ElectricCurrent from Kiloamperes.
        /// </summary>
        public static ElectricCurrent FromKiloamperes(double kiloamperes)
        {
            return new ElectricCurrent((kiloamperes) * 1e3d);
        }

        /// <summary>
        ///     Get ElectricCurrent from Megaamperes.
        /// </summary>
        public static ElectricCurrent FromMegaamperes(double megaamperes)
        {
            return new ElectricCurrent((megaamperes) * 1e6d);
        }

        /// <summary>
        ///     Get ElectricCurrent from Microamperes.
        /// </summary>
        public static ElectricCurrent FromMicroamperes(double microamperes)
        {
            return new ElectricCurrent((microamperes) * 1e-6d);
        }

        /// <summary>
        ///     Get ElectricCurrent from Milliamperes.
        /// </summary>
        public static ElectricCurrent FromMilliamperes(double milliamperes)
        {
            return new ElectricCurrent((milliamperes) * 1e-3d);
        }

        /// <summary>
        ///     Get ElectricCurrent from Nanoamperes.
        /// </summary>
        public static ElectricCurrent FromNanoamperes(double nanoamperes)
        {
            return new ElectricCurrent((nanoamperes) * 1e-9d);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricCurrentUnit" /> to <see cref="ElectricCurrent" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricCurrent unit value.</returns>
        public static ElectricCurrent From(double value, ElectricCurrentUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ElectricCurrentUnit.Ampere:
                    return FromAmperes(value);
                case ElectricCurrentUnit.Kiloampere:
                    return FromKiloamperes(value);
                case ElectricCurrentUnit.Megaampere:
                    return FromMegaamperes(value);
                case ElectricCurrentUnit.Microampere:
                    return FromMicroamperes(value);
                case ElectricCurrentUnit.Milliampere:
                    return FromMilliamperes(value);
                case ElectricCurrentUnit.Nanoampere:
                    return FromNanoamperes(value);

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
        public static string GetAbbreviation(ElectricCurrentUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static ElectricCurrent operator -(ElectricCurrent right)
        {
            return new ElectricCurrent(-right._amperes);
        }

        public static ElectricCurrent operator +(ElectricCurrent left, ElectricCurrent right)
        {
            return new ElectricCurrent(left._amperes + right._amperes);
        }

        public static ElectricCurrent operator -(ElectricCurrent left, ElectricCurrent right)
        {
            return new ElectricCurrent(left._amperes - right._amperes);
        }

        public static ElectricCurrent operator *(double left, ElectricCurrent right)
        {
            return new ElectricCurrent(left*right._amperes);
        }

        public static ElectricCurrent operator *(ElectricCurrent left, double right)
        {
            return new ElectricCurrent(left._amperes*(double)right);
        }

        public static ElectricCurrent operator /(ElectricCurrent left, double right)
        {
            return new ElectricCurrent(left._amperes/(double)right);
        }

        public static double operator /(ElectricCurrent left, ElectricCurrent right)
        {
            return Convert.ToDouble(left._amperes/right._amperes);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is ElectricCurrent)) throw new ArgumentException("Expected type ElectricCurrent.", "obj");
            return CompareTo((ElectricCurrent) obj);
        }

        public int CompareTo(ElectricCurrent other)
        {
            return _amperes.CompareTo(other._amperes);
        }

        public static bool operator <=(ElectricCurrent left, ElectricCurrent right)
        {
            return left._amperes <= right._amperes;
        }

        public static bool operator >=(ElectricCurrent left, ElectricCurrent right)
        {
            return left._amperes >= right._amperes;
        }

        public static bool operator <(ElectricCurrent left, ElectricCurrent right)
        {
            return left._amperes < right._amperes;
        }

        public static bool operator >(ElectricCurrent left, ElectricCurrent right)
        {
            return left._amperes > right._amperes;
        }

        public static bool operator ==(ElectricCurrent left, ElectricCurrent right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._amperes == right._amperes;
        }

        public static bool operator !=(ElectricCurrent left, ElectricCurrent right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._amperes != right._amperes;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _amperes.Equals(((ElectricCurrent) obj)._amperes);
        }

        public override int GetHashCode()
        {
            return _amperes.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(ElectricCurrentUnit unit)
        {
            switch (unit)
            {
                case ElectricCurrentUnit.Ampere:
                    return Amperes;
                case ElectricCurrentUnit.Kiloampere:
                    return Kiloamperes;
                case ElectricCurrentUnit.Megaampere:
                    return Megaamperes;
                case ElectricCurrentUnit.Microampere:
                    return Microamperes;
                case ElectricCurrentUnit.Milliampere:
                    return Milliamperes;
                case ElectricCurrentUnit.Nanoampere:
                    return Nanoamperes;

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
        public static ElectricCurrent Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<ElectricCurrent> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<ElectricCurrent>();

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
                    ElectricCurrentUnit unit = ParseUnit(unitString, formatProvider);
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
        public static ElectricCurrentUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<ElectricCurrentUnit>(str.Trim());

            if (unit == ElectricCurrentUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ElectricCurrentUnit.");
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
            return ToString(ElectricCurrentUnit.Ampere);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(ElectricCurrentUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(ElectricCurrentUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
