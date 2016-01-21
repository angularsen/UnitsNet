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
    ///     Rotational speed (sometimes called speed of revolution) is the number of complete rotations, revolutions, cycles, or turns per time unit. Rotational speed is a cyclic frequency, measured in radians per second or in hertz in the SI System by scientists, or in revolutions per minute (rpm or min-1) or revolutions per second in everyday life. The symbol for rotational speed is ω (the Greek lowercase letter "omega").
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct RotationalSpeed : IComparable, IComparable<RotationalSpeed>
    {
        /// <summary>
        ///     Base unit of RotationalSpeed.
        /// </summary>
        private readonly double _revolutionsPerSecond;

        public RotationalSpeed(double revolutionspersecond) : this()
        {
            _revolutionsPerSecond = revolutionspersecond;
        }

        #region Properties

        public static RotationalSpeedUnit BaseUnit
        {
            get { return RotationalSpeedUnit.RevolutionPerSecond; }
        }

        /// <summary>
        ///     Get RotationalSpeed in CentiradiansPerSecond.
        /// </summary>
        public double CentiradiansPerSecond
        {
            get { return (_revolutionsPerSecond*6.2831853072) / 1e-2d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in DeciradiansPerSecond.
        /// </summary>
        public double DeciradiansPerSecond
        {
            get { return (_revolutionsPerSecond*6.2831853072) / 1e-1d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in MicroradiansPerSecond.
        /// </summary>
        public double MicroradiansPerSecond
        {
            get { return (_revolutionsPerSecond*6.2831853072) / 1e-6d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in MilliradiansPerSecond.
        /// </summary>
        public double MilliradiansPerSecond
        {
            get { return (_revolutionsPerSecond*6.2831853072) / 1e-3d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in NanoradiansPerSecond.
        /// </summary>
        public double NanoradiansPerSecond
        {
            get { return (_revolutionsPerSecond*6.2831853072) / 1e-9d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in RadiansPerSecond.
        /// </summary>
        public double RadiansPerSecond
        {
            get { return _revolutionsPerSecond*6.2831853072; }
        }

        /// <summary>
        ///     Get RotationalSpeed in RevolutionsPerMinute.
        /// </summary>
        public double RevolutionsPerMinute
        {
            get { return _revolutionsPerSecond*60; }
        }

        /// <summary>
        ///     Get RotationalSpeed in RevolutionsPerSecond.
        /// </summary>
        public double RevolutionsPerSecond
        {
            get { return _revolutionsPerSecond; }
        }

        #endregion

        #region Static 

        public static RotationalSpeed Zero
        {
            get { return new RotationalSpeed(); }
        }

        /// <summary>
        ///     Get RotationalSpeed from CentiradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromCentiradiansPerSecond(double centiradianspersecond)
        {
            return new RotationalSpeed((centiradianspersecond/6.2831853072) * 1e-2d);
        }

        /// <summary>
        ///     Get RotationalSpeed from DeciradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromDeciradiansPerSecond(double deciradianspersecond)
        {
            return new RotationalSpeed((deciradianspersecond/6.2831853072) * 1e-1d);
        }

        /// <summary>
        ///     Get RotationalSpeed from MicroradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromMicroradiansPerSecond(double microradianspersecond)
        {
            return new RotationalSpeed((microradianspersecond/6.2831853072) * 1e-6d);
        }

        /// <summary>
        ///     Get RotationalSpeed from MilliradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromMilliradiansPerSecond(double milliradianspersecond)
        {
            return new RotationalSpeed((milliradianspersecond/6.2831853072) * 1e-3d);
        }

        /// <summary>
        ///     Get RotationalSpeed from NanoradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromNanoradiansPerSecond(double nanoradianspersecond)
        {
            return new RotationalSpeed((nanoradianspersecond/6.2831853072) * 1e-9d);
        }

        /// <summary>
        ///     Get RotationalSpeed from RadiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromRadiansPerSecond(double radianspersecond)
        {
            return new RotationalSpeed(radianspersecond/6.2831853072);
        }

        /// <summary>
        ///     Get RotationalSpeed from RevolutionsPerMinute.
        /// </summary>
        public static RotationalSpeed FromRevolutionsPerMinute(double revolutionsperminute)
        {
            return new RotationalSpeed(revolutionsperminute/60);
        }

        /// <summary>
        ///     Get RotationalSpeed from RevolutionsPerSecond.
        /// </summary>
        public static RotationalSpeed FromRevolutionsPerSecond(double revolutionspersecond)
        {
            return new RotationalSpeed(revolutionspersecond);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RotationalSpeedUnit" /> to <see cref="RotationalSpeed" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>RotationalSpeed unit value.</returns>
        public static RotationalSpeed From(double value, RotationalSpeedUnit fromUnit)
        {
            switch (fromUnit)
            {
                case RotationalSpeedUnit.CentiradianPerSecond:
                    return FromCentiradiansPerSecond(value);
                case RotationalSpeedUnit.DeciradianPerSecond:
                    return FromDeciradiansPerSecond(value);
                case RotationalSpeedUnit.MicroradianPerSecond:
                    return FromMicroradiansPerSecond(value);
                case RotationalSpeedUnit.MilliradianPerSecond:
                    return FromMilliradiansPerSecond(value);
                case RotationalSpeedUnit.NanoradianPerSecond:
                    return FromNanoradiansPerSecond(value);
                case RotationalSpeedUnit.RadianPerSecond:
                    return FromRadiansPerSecond(value);
                case RotationalSpeedUnit.RevolutionPerMinute:
                    return FromRevolutionsPerMinute(value);
                case RotationalSpeedUnit.RevolutionPerSecond:
                    return FromRevolutionsPerSecond(value);

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
        public static string GetAbbreviation(RotationalSpeedUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static RotationalSpeed operator -(RotationalSpeed right)
        {
            return new RotationalSpeed(-right._revolutionsPerSecond);
        }

        public static RotationalSpeed operator +(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left._revolutionsPerSecond + right._revolutionsPerSecond);
        }

        public static RotationalSpeed operator -(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left._revolutionsPerSecond - right._revolutionsPerSecond);
        }

        public static RotationalSpeed operator *(double left, RotationalSpeed right)
        {
            return new RotationalSpeed(left*right._revolutionsPerSecond);
        }

        public static RotationalSpeed operator *(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left._revolutionsPerSecond*(double)right);
        }

        public static RotationalSpeed operator /(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left._revolutionsPerSecond/(double)right);
        }

        public static double operator /(RotationalSpeed left, RotationalSpeed right)
        {
            return Convert.ToDouble(left._revolutionsPerSecond/right._revolutionsPerSecond);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is RotationalSpeed)) throw new ArgumentException("Expected type RotationalSpeed.", "obj");
            return CompareTo((RotationalSpeed) obj);
        }

        public int CompareTo(RotationalSpeed other)
        {
            return _revolutionsPerSecond.CompareTo(other._revolutionsPerSecond);
        }

        public static bool operator <=(RotationalSpeed left, RotationalSpeed right)
        {
            return left._revolutionsPerSecond <= right._revolutionsPerSecond;
        }

        public static bool operator >=(RotationalSpeed left, RotationalSpeed right)
        {
            return left._revolutionsPerSecond >= right._revolutionsPerSecond;
        }

        public static bool operator <(RotationalSpeed left, RotationalSpeed right)
        {
            return left._revolutionsPerSecond < right._revolutionsPerSecond;
        }

        public static bool operator >(RotationalSpeed left, RotationalSpeed right)
        {
            return left._revolutionsPerSecond > right._revolutionsPerSecond;
        }

        public static bool operator ==(RotationalSpeed left, RotationalSpeed right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._revolutionsPerSecond == right._revolutionsPerSecond;
        }

        public static bool operator !=(RotationalSpeed left, RotationalSpeed right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._revolutionsPerSecond != right._revolutionsPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _revolutionsPerSecond.Equals(((RotationalSpeed) obj)._revolutionsPerSecond);
        }

        public override int GetHashCode()
        {
            return _revolutionsPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(RotationalSpeedUnit unit)
        {
            switch (unit)
            {
                case RotationalSpeedUnit.CentiradianPerSecond:
                    return CentiradiansPerSecond;
                case RotationalSpeedUnit.DeciradianPerSecond:
                    return DeciradiansPerSecond;
                case RotationalSpeedUnit.MicroradianPerSecond:
                    return MicroradiansPerSecond;
                case RotationalSpeedUnit.MilliradianPerSecond:
                    return MilliradiansPerSecond;
                case RotationalSpeedUnit.NanoradianPerSecond:
                    return NanoradiansPerSecond;
                case RotationalSpeedUnit.RadianPerSecond:
                    return RadiansPerSecond;
                case RotationalSpeedUnit.RevolutionPerMinute:
                    return RevolutionsPerMinute;
                case RotationalSpeedUnit.RevolutionPerSecond:
                    return RevolutionsPerSecond;

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
        public static RotationalSpeed Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<RotationalSpeed> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<RotationalSpeed>();

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
                    RotationalSpeedUnit unit = ParseUnit(unitString, formatProvider);
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
        public static RotationalSpeedUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<RotationalSpeedUnit>(str.Trim());

            if (unit == RotationalSpeedUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized RotationalSpeedUnit.");
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
            return ToString(RotationalSpeedUnit.RevolutionPerSecond);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(RotationalSpeedUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(RotationalSpeedUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
