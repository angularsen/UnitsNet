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
    ///     Temperature change rate is the ratio of the temperature change to the time during which the change occurred (value of temperature changes per unit time).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct TemperatureChangeRate : IComparable, IComparable<TemperatureChangeRate>
    {
        /// <summary>
        ///     Base unit of TemperatureChangeRate.
        /// </summary>
        private readonly double _degreesCelsiusPerSecond;

        public TemperatureChangeRate(double degreescelsiuspersecond) : this()
        {
            _degreesCelsiusPerSecond = degreescelsiuspersecond;
        }

        #region Properties

        public static TemperatureChangeRateUnit BaseUnit
        {
            get { return TemperatureChangeRateUnit.DegreeCelsiusPerSecond; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in CentidegreesCelsiusPerSecond.
        /// </summary>
        public double CentidegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-2d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in DecadegreesCelsiusPerSecond.
        /// </summary>
        public double DecadegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e1d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in DecidegreesCelsiusPerSecond.
        /// </summary>
        public double DecidegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-1d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in DegreesCelsiusPerSecond.
        /// </summary>
        public double DegreesCelsiusPerSecond
        {
            get { return _degreesCelsiusPerSecond; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in HectodegreesCelsiusPerSecond.
        /// </summary>
        public double HectodegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e2d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in KilodegreesCelsiusPerSecond.
        /// </summary>
        public double KilodegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e3d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in MicrodegreesCelsiusPerSecond.
        /// </summary>
        public double MicrodegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-6d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in MillidegreesCelsiusPerSecond.
        /// </summary>
        public double MillidegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-3d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in NanodegreesCelsiusPerSecond.
        /// </summary>
        public double NanodegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-9d; }
        }

        #endregion

        #region Static 

        public static TemperatureChangeRate Zero
        {
            get { return new TemperatureChangeRate(); }
        }

        /// <summary>
        ///     Get TemperatureChangeRate from CentidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromCentidegreesCelsiusPerSecond(double centidegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((centidegreescelsiuspersecond) * 1e-2d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from DecadegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromDecadegreesCelsiusPerSecond(double decadegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((decadegreescelsiuspersecond) * 1e1d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from DecidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromDecidegreesCelsiusPerSecond(double decidegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((decidegreescelsiuspersecond) * 1e-1d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from DegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromDegreesCelsiusPerSecond(double degreescelsiuspersecond)
        {
            return new TemperatureChangeRate(degreescelsiuspersecond);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from HectodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromHectodegreesCelsiusPerSecond(double hectodegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((hectodegreescelsiuspersecond) * 1e2d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from KilodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromKilodegreesCelsiusPerSecond(double kilodegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((kilodegreescelsiuspersecond) * 1e3d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from MicrodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromMicrodegreesCelsiusPerSecond(double microdegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((microdegreescelsiuspersecond) * 1e-6d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from MillidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromMillidegreesCelsiusPerSecond(double millidegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((millidegreescelsiuspersecond) * 1e-3d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from NanodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromNanodegreesCelsiusPerSecond(double nanodegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((nanodegreescelsiuspersecond) * 1e-9d);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TemperatureChangeRateUnit" /> to <see cref="TemperatureChangeRate" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>TemperatureChangeRate unit value.</returns>
        public static TemperatureChangeRate From(double value, TemperatureChangeRateUnit fromUnit)
        {
            switch (fromUnit)
            {
                case TemperatureChangeRateUnit.CentidegreeCelsiusPerSecond:
                    return FromCentidegreesCelsiusPerSecond(value);
                case TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond:
                    return FromDecadegreesCelsiusPerSecond(value);
                case TemperatureChangeRateUnit.DecidegreeCelsiusPerSecond:
                    return FromDecidegreesCelsiusPerSecond(value);
                case TemperatureChangeRateUnit.DegreeCelsiusPerSecond:
                    return FromDegreesCelsiusPerSecond(value);
                case TemperatureChangeRateUnit.HectodegreeCelsiusPerSecond:
                    return FromHectodegreesCelsiusPerSecond(value);
                case TemperatureChangeRateUnit.KilodegreeCelsiusPerSecond:
                    return FromKilodegreesCelsiusPerSecond(value);
                case TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond:
                    return FromMicrodegreesCelsiusPerSecond(value);
                case TemperatureChangeRateUnit.MillidegreeCelsiusPerSecond:
                    return FromMillidegreesCelsiusPerSecond(value);
                case TemperatureChangeRateUnit.NanodegreeCelsiusPerSecond:
                    return FromNanodegreesCelsiusPerSecond(value);

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
        public static string GetAbbreviation(TemperatureChangeRateUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static TemperatureChangeRate operator -(TemperatureChangeRate right)
        {
            return new TemperatureChangeRate(-right._degreesCelsiusPerSecond);
        }

        public static TemperatureChangeRate operator +(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return new TemperatureChangeRate(left._degreesCelsiusPerSecond + right._degreesCelsiusPerSecond);
        }

        public static TemperatureChangeRate operator -(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return new TemperatureChangeRate(left._degreesCelsiusPerSecond - right._degreesCelsiusPerSecond);
        }

        public static TemperatureChangeRate operator *(double left, TemperatureChangeRate right)
        {
            return new TemperatureChangeRate(left*right._degreesCelsiusPerSecond);
        }

        public static TemperatureChangeRate operator *(TemperatureChangeRate left, double right)
        {
            return new TemperatureChangeRate(left._degreesCelsiusPerSecond*(double)right);
        }

        public static TemperatureChangeRate operator /(TemperatureChangeRate left, double right)
        {
            return new TemperatureChangeRate(left._degreesCelsiusPerSecond/(double)right);
        }

        public static double operator /(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return Convert.ToDouble(left._degreesCelsiusPerSecond/right._degreesCelsiusPerSecond);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is TemperatureChangeRate)) throw new ArgumentException("Expected type TemperatureChangeRate.", "obj");
            return CompareTo((TemperatureChangeRate) obj);
        }

        public int CompareTo(TemperatureChangeRate other)
        {
            return _degreesCelsiusPerSecond.CompareTo(other._degreesCelsiusPerSecond);
        }

        public static bool operator <=(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return left._degreesCelsiusPerSecond <= right._degreesCelsiusPerSecond;
        }

        public static bool operator >=(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return left._degreesCelsiusPerSecond >= right._degreesCelsiusPerSecond;
        }

        public static bool operator <(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return left._degreesCelsiusPerSecond < right._degreesCelsiusPerSecond;
        }

        public static bool operator >(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return left._degreesCelsiusPerSecond > right._degreesCelsiusPerSecond;
        }

        public static bool operator ==(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._degreesCelsiusPerSecond == right._degreesCelsiusPerSecond;
        }

        public static bool operator !=(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._degreesCelsiusPerSecond != right._degreesCelsiusPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _degreesCelsiusPerSecond.Equals(((TemperatureChangeRate) obj)._degreesCelsiusPerSecond);
        }

        public override int GetHashCode()
        {
            return _degreesCelsiusPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(TemperatureChangeRateUnit unit)
        {
            switch (unit)
            {
                case TemperatureChangeRateUnit.CentidegreeCelsiusPerSecond:
                    return CentidegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond:
                    return DecadegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.DecidegreeCelsiusPerSecond:
                    return DecidegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.DegreeCelsiusPerSecond:
                    return DegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.HectodegreeCelsiusPerSecond:
                    return HectodegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.KilodegreeCelsiusPerSecond:
                    return KilodegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond:
                    return MicrodegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.MillidegreeCelsiusPerSecond:
                    return MillidegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.NanodegreeCelsiusPerSecond:
                    return NanodegreesCelsiusPerSecond;

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
        public static TemperatureChangeRate Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<TemperatureChangeRate> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<TemperatureChangeRate>();

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
                    TemperatureChangeRateUnit unit = ParseUnit(unitString, formatProvider);
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
        public static TemperatureChangeRateUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<TemperatureChangeRateUnit>(str.Trim());

            if (unit == TemperatureChangeRateUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized TemperatureChangeRateUnit.");
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
            return ToString(TemperatureChangeRateUnit.DegreeCelsiusPerSecond);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(TemperatureChangeRateUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(TemperatureChangeRateUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
