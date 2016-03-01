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

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Level is the logarithm of the ratio of a quantity Q to a reference value of that quantity, Q0, expressed in dimensionless units.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Level : IComparable, IComparable<Level>
    {
        /// <summary>
        ///     Base unit of Level.
        /// </summary>
        private readonly double _decibels;

        public Level(double decibels) : this()
        {
            _decibels = decibels;
        }

        #region Properties

        public static LevelUnit BaseUnit
        {
            get { return LevelUnit.Decibel; }
        }

        /// <summary>
        ///     Get Level in Decibels.
        /// </summary>
        public double Decibels
        {
            get { return _decibels; }
        }

        /// <summary>
        ///     Get Level in Nepers.
        /// </summary>
        public double Nepers
        {
            get { return 0.115129254*_decibels; }
        }

        #endregion

        #region Static 

        public static Level Zero
        {
            get { return new Level(); }
        }

        /// <summary>
        ///     Get Level from Decibels.
        /// </summary>
        public static Level FromDecibels(double decibels)
        {
            return new Level(decibels);
        }

        /// <summary>
        ///     Get Level from Nepers.
        /// </summary>
        public static Level FromNepers(double nepers)
        {
            return new Level((1/0.115129254)*nepers);
        }


        /// <summary>
        ///     Get nullable Level from nullable Decibels.
        /// </summary>
        public static Level? FromDecibels(double? decibels)
        {
            if (decibels.HasValue)
            {
                return FromDecibels(decibels.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Level from nullable Nepers.
        /// </summary>
        public static Level? FromNepers(double? nepers)
        {
            if (nepers.HasValue)
            {
                return FromNepers(nepers.Value);
            }
            else
            {
            	return null;
            }
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LevelUnit" /> to <see cref="Level" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Level unit value.</returns>
        public static Level From(double value, LevelUnit fromUnit)
        {
            switch (fromUnit)
            {
                case LevelUnit.Decibel:
                    return FromDecibels(value);
                case LevelUnit.Neper:
                    return FromNepers(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LevelUnit" /> to <see cref="Level" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Level unit value.</returns>
        public static Level? From(double? value, LevelUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case LevelUnit.Decibel:
                    return FromDecibels(value.Value);
                case LevelUnit.Neper:
                    return FromNepers(value.Value);

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
        public static string GetAbbreviation(LevelUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Logarithmic Arithmetic Operators

        public static Level operator -(Level right)
        {
            return new Level(-right._decibels);
        }

        public static Level operator +(Level left, Level right)
        {
            // Logarithmic addition
            // Formula: 10*log10(10^(x/10) + 10^(y/10))
            return new Level(10*Math.Log10(Math.Pow(10, left._decibels/10) + Math.Pow(10, right._decibels/10)));
        }

        public static Level operator -(Level left, Level right)
        {
            // Logarithmic subtraction 
            // Formula: 10*log10(10^(x/10) - 10^(y/10))
            return new Level(10*Math.Log10(Math.Pow(10, left._decibels/10) - Math.Pow(10, right._decibels/10)));
        }

        public static Level operator *(double left, Level right)
        {
            // Logarithmic multiplication = addition
            return new Level(left + right._decibels);
        }

        public static Level operator *(Level left, double right)
        {
            // Logarithmic multiplication = addition
            return new Level(left._decibels + (double)right);
        }

        public static Level operator /(Level left, double right)
        {
            // Logarithmic division = subtraction
            return new Level(left._decibels - (double)right);
        }

        public static double operator /(Level left, Level right)
        {
            // Logarithmic division = subtraction
            return Convert.ToDouble(left._decibels - right._decibels);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Level)) throw new ArgumentException("Expected type Level.", "obj");
            return CompareTo((Level) obj);
        }

        public int CompareTo(Level other)
        {
            return _decibels.CompareTo(other._decibels);
        }

        public static bool operator <=(Level left, Level right)
        {
            return left._decibels <= right._decibels;
        }

        public static bool operator >=(Level left, Level right)
        {
            return left._decibels >= right._decibels;
        }

        public static bool operator <(Level left, Level right)
        {
            return left._decibels < right._decibels;
        }

        public static bool operator >(Level left, Level right)
        {
            return left._decibels > right._decibels;
        }

        public static bool operator ==(Level left, Level right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decibels == right._decibels;
        }

        public static bool operator !=(Level left, Level right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decibels != right._decibels;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _decibels.Equals(((Level) obj)._decibels);
        }

        public override int GetHashCode()
        {
            return _decibels.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(LevelUnit unit)
        {
            switch (unit)
            {
                case LevelUnit.Decibel:
                    return Decibels;
                case LevelUnit.Neper:
                    return Nepers;

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
        /// <param name="formatProvider">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
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
        public static Level Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<Level> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Level>();

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
                    LevelUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch(AmbiguousUnitParseException ambiguousException)
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
        public static LevelUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<LevelUnit>(str.Trim());

            if (unit == LevelUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized LevelUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Decibel
        /// </summary>
        public static LevelUnit ToStringDefaultUnit { get; set; } = LevelUnit.Decibel;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(ToStringDefaultUnit);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(LevelUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(LevelUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
