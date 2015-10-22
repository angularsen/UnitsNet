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
    ///     The area density (also known as areal density, surface density, or superficial density) of a two-dimensional object is calculated as the mass per unit area. The SI derived unit is: kilogram per square metre (kg·m−2).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct AreaDensity : IComparable, IComparable<AreaDensity>
    {
        /// <summary>
        ///     Base unit of AreaDensity.
        /// </summary>
        private readonly double _kilogramsPerSquareMeter;

        public AreaDensity(double kilogramspersquaremeter) : this()
        {
            _kilogramsPerSquareMeter = kilogramspersquaremeter;
        }

        #region Properties

        /// <summary>
        ///     Get AreaDensity in KilgramsPerHectare.
        /// </summary>
        public double KilgramsPerHectare
        {
            get { return _kilogramsPerSquareMeter*10000; }
        }

        /// <summary>
        ///     Get AreaDensity in KilogramsPerSquareMeter.
        /// </summary>
        public double KilogramsPerSquareMeter
        {
            get { return _kilogramsPerSquareMeter; }
        }

        /// <summary>
        ///     Get AreaDensity in PoundsPerAcre.
        /// </summary>
        public double PoundsPerAcre
        {
            get { return _kilogramsPerSquareMeter*8921.532921; }
        }

        #endregion

        #region Static 

        public static AreaDensity Zero
        {
            get { return new AreaDensity(); }
        }

        /// <summary>
        ///     Get AreaDensity from KilgramsPerHectare.
        /// </summary>
        public static AreaDensity FromKilgramsPerHectare(double kilgramsperhectare)
        {
            return new AreaDensity(kilgramsperhectare/10000);
        }

        /// <summary>
        ///     Get AreaDensity from KilogramsPerSquareMeter.
        /// </summary>
        public static AreaDensity FromKilogramsPerSquareMeter(double kilogramspersquaremeter)
        {
            return new AreaDensity(kilogramspersquaremeter);
        }

        /// <summary>
        ///     Get AreaDensity from PoundsPerAcre.
        /// </summary>
        public static AreaDensity FromPoundsPerAcre(double poundsperacre)
        {
            return new AreaDensity(poundsperacre/8921.532921);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AreaDensityUnit" /> to <see cref="AreaDensity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>AreaDensity unit value.</returns>
        public static AreaDensity From(double value, AreaDensityUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AreaDensityUnit.KilogramPerHectare:
                    return FromKilgramsPerHectare(value);
                case AreaDensityUnit.KilogramPerSquareMeter:
                    return FromKilogramsPerSquareMeter(value);
                case AreaDensityUnit.PoundPerAcre:
                    return FromPoundsPerAcre(value);

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
        public static string GetAbbreviation(AreaDensityUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static AreaDensity operator -(AreaDensity right)
        {
            return new AreaDensity(-right._kilogramsPerSquareMeter);
        }

        public static AreaDensity operator +(AreaDensity left, AreaDensity right)
        {
            return new AreaDensity(left._kilogramsPerSquareMeter + right._kilogramsPerSquareMeter);
        }

        public static AreaDensity operator -(AreaDensity left, AreaDensity right)
        {
            return new AreaDensity(left._kilogramsPerSquareMeter - right._kilogramsPerSquareMeter);
        }

        public static AreaDensity operator *(double left, AreaDensity right)
        {
            return new AreaDensity(left*right._kilogramsPerSquareMeter);
        }

        public static AreaDensity operator *(AreaDensity left, double right)
        {
            return new AreaDensity(left._kilogramsPerSquareMeter*(double)right);
        }

        public static AreaDensity operator /(AreaDensity left, double right)
        {
            return new AreaDensity(left._kilogramsPerSquareMeter/(double)right);
        }

        public static double operator /(AreaDensity left, AreaDensity right)
        {
            return Convert.ToDouble(left._kilogramsPerSquareMeter/right._kilogramsPerSquareMeter);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is AreaDensity)) throw new ArgumentException("Expected type AreaDensity.", "obj");
            return CompareTo((AreaDensity) obj);
        }

        public int CompareTo(AreaDensity other)
        {
            return _kilogramsPerSquareMeter.CompareTo(other._kilogramsPerSquareMeter);
        }

        public static bool operator <=(AreaDensity left, AreaDensity right)
        {
            return left._kilogramsPerSquareMeter <= right._kilogramsPerSquareMeter;
        }

        public static bool operator >=(AreaDensity left, AreaDensity right)
        {
            return left._kilogramsPerSquareMeter >= right._kilogramsPerSquareMeter;
        }

        public static bool operator <(AreaDensity left, AreaDensity right)
        {
            return left._kilogramsPerSquareMeter < right._kilogramsPerSquareMeter;
        }

        public static bool operator >(AreaDensity left, AreaDensity right)
        {
            return left._kilogramsPerSquareMeter > right._kilogramsPerSquareMeter;
        }

        public static bool operator ==(AreaDensity left, AreaDensity right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilogramsPerSquareMeter == right._kilogramsPerSquareMeter;
        }

        public static bool operator !=(AreaDensity left, AreaDensity right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilogramsPerSquareMeter != right._kilogramsPerSquareMeter;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _kilogramsPerSquareMeter.Equals(((AreaDensity) obj)._kilogramsPerSquareMeter);
        }

        public override int GetHashCode()
        {
            return _kilogramsPerSquareMeter.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AreaDensityUnit unit)
        {
            switch (unit)
            {
                case AreaDensityUnit.KilogramPerHectare:
                    return KilgramsPerHectare;
                case AreaDensityUnit.KilogramPerSquareMeter:
                    return KilogramsPerSquareMeter;
                case AreaDensityUnit.PoundPerAcre:
                    return PoundsPerAcre;

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
        public static AreaDensity Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<AreaDensity> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<AreaDensity>();

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
                    AreaDensityUnit unit = ParseUnit(unitString, formatProvider);
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
        public static AreaDensityUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<AreaDensityUnit>(str.Trim());

            if (unit == AreaDensityUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized AreaDensityUnit.");
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
            return ToString(AreaDensityUnit.KilogramPerSquareMeter);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(AreaDensityUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(AreaDensityUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
