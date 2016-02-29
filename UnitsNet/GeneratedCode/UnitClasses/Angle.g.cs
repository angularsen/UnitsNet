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
    ///     In geometry, an angle is the figure formed by two rays, called the sides of the angle, sharing a common endpoint, called the vertex of the angle.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Angle : IComparable, IComparable<Angle>
    {
        /// <summary>
        ///     Base unit of Angle.
        /// </summary>
        private readonly double _degrees;

        public Angle(double degrees) : this()
        {
            _degrees = degrees;
        }

        #region Properties

        public static AngleUnit BaseUnit
        {
            get { return AngleUnit.Degree; }
        }

        /// <summary>
        ///     Get Angle in Arcminutes.
        /// </summary>
        public double Arcminutes
        {
            get { return _degrees*60; }
        }

        /// <summary>
        ///     Get Angle in Arcseconds.
        /// </summary>
        public double Arcseconds
        {
            get { return _degrees*3600; }
        }

        /// <summary>
        ///     Get Angle in Centiradians.
        /// </summary>
        public double Centiradians
        {
            get { return (_degrees/180*Math.PI) / 1e-2d; }
        }

        /// <summary>
        ///     Get Angle in Deciradians.
        /// </summary>
        public double Deciradians
        {
            get { return (_degrees/180*Math.PI) / 1e-1d; }
        }

        /// <summary>
        ///     Get Angle in Degrees.
        /// </summary>
        public double Degrees
        {
            get { return _degrees; }
        }

        /// <summary>
        ///     Get Angle in Gradians.
        /// </summary>
        public double Gradians
        {
            get { return _degrees/0.9; }
        }

        /// <summary>
        ///     Get Angle in Microradians.
        /// </summary>
        public double Microradians
        {
            get { return (_degrees/180*Math.PI) / 1e-6d; }
        }

        /// <summary>
        ///     Get Angle in Milliradians.
        /// </summary>
        public double Milliradians
        {
            get { return (_degrees/180*Math.PI) / 1e-3d; }
        }

        /// <summary>
        ///     Get Angle in Nanoradians.
        /// </summary>
        public double Nanoradians
        {
            get { return (_degrees/180*Math.PI) / 1e-9d; }
        }

        /// <summary>
        ///     Get Angle in Radians.
        /// </summary>
        public double Radians
        {
            get { return _degrees/180*Math.PI; }
        }

        #endregion

        #region Static 

        public static Angle Zero
        {
            get { return new Angle(); }
        }

        /// <summary>
        ///     Get Angle from Arcminutes.
        /// </summary>
        public static Angle FromArcminutes(double arcminutes)
        {
            return new Angle(arcminutes/60);
        }

        /// <summary>
        ///     Get Angle from Arcseconds.
        /// </summary>
        public static Angle FromArcseconds(double arcseconds)
        {
            return new Angle(arcseconds/3600);
        }

        /// <summary>
        ///     Get Angle from Centiradians.
        /// </summary>
        public static Angle FromCentiradians(double centiradians)
        {
            return new Angle((centiradians*180/Math.PI) * 1e-2d);
        }

        /// <summary>
        ///     Get Angle from Deciradians.
        /// </summary>
        public static Angle FromDeciradians(double deciradians)
        {
            return new Angle((deciradians*180/Math.PI) * 1e-1d);
        }

        /// <summary>
        ///     Get Angle from Degrees.
        /// </summary>
        public static Angle FromDegrees(double degrees)
        {
            return new Angle(degrees);
        }

        /// <summary>
        ///     Get Angle from Gradians.
        /// </summary>
        public static Angle FromGradians(double gradians)
        {
            return new Angle(gradians*0.9);
        }

        /// <summary>
        ///     Get Angle from Microradians.
        /// </summary>
        public static Angle FromMicroradians(double microradians)
        {
            return new Angle((microradians*180/Math.PI) * 1e-6d);
        }

        /// <summary>
        ///     Get Angle from Milliradians.
        /// </summary>
        public static Angle FromMilliradians(double milliradians)
        {
            return new Angle((milliradians*180/Math.PI) * 1e-3d);
        }

        /// <summary>
        ///     Get Angle from Nanoradians.
        /// </summary>
        public static Angle FromNanoradians(double nanoradians)
        {
            return new Angle((nanoradians*180/Math.PI) * 1e-9d);
        }

        /// <summary>
        ///     Get Angle from Radians.
        /// </summary>
        public static Angle FromRadians(double radians)
        {
            return new Angle(radians*180/Math.PI);
        }


        /// <summary>
        ///     Get nullable Angle from nullable Arcminutes.
        /// </summary>
        public static Angle? FromArcminutes(double? arcminutes)
        {
            if (arcminutes.HasValue)
            {
                return FromArcminutes(arcminutes.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Arcseconds.
        /// </summary>
        public static Angle? FromArcseconds(double? arcseconds)
        {
            if (arcseconds.HasValue)
            {
                return FromArcseconds(arcseconds.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Centiradians.
        /// </summary>
        public static Angle? FromCentiradians(double? centiradians)
        {
            if (centiradians.HasValue)
            {
                return FromCentiradians(centiradians.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Deciradians.
        /// </summary>
        public static Angle? FromDeciradians(double? deciradians)
        {
            if (deciradians.HasValue)
            {
                return FromDeciradians(deciradians.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Degrees.
        /// </summary>
        public static Angle? FromDegrees(double? degrees)
        {
            if (degrees.HasValue)
            {
                return FromDegrees(degrees.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Gradians.
        /// </summary>
        public static Angle? FromGradians(double? gradians)
        {
            if (gradians.HasValue)
            {
                return FromGradians(gradians.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Microradians.
        /// </summary>
        public static Angle? FromMicroradians(double? microradians)
        {
            if (microradians.HasValue)
            {
                return FromMicroradians(microradians.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Milliradians.
        /// </summary>
        public static Angle? FromMilliradians(double? milliradians)
        {
            if (milliradians.HasValue)
            {
                return FromMilliradians(milliradians.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Nanoradians.
        /// </summary>
        public static Angle? FromNanoradians(double? nanoradians)
        {
            if (nanoradians.HasValue)
            {
                return FromNanoradians(nanoradians.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Angle from nullable Radians.
        /// </summary>
        public static Angle? FromRadians(double? radians)
        {
            if (radians.HasValue)
            {
                return FromRadians(radians.Value);
            }
            else
            {
            	return null;
            }
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AngleUnit" /> to <see cref="Angle" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Angle unit value.</returns>
        public static Angle From(double value, AngleUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AngleUnit.Arcminute:
                    return FromArcminutes(value);
                case AngleUnit.Arcsecond:
                    return FromArcseconds(value);
                case AngleUnit.Centiradian:
                    return FromCentiradians(value);
                case AngleUnit.Deciradian:
                    return FromDeciradians(value);
                case AngleUnit.Degree:
                    return FromDegrees(value);
                case AngleUnit.Gradian:
                    return FromGradians(value);
                case AngleUnit.Microradian:
                    return FromMicroradians(value);
                case AngleUnit.Milliradian:
                    return FromMilliradians(value);
                case AngleUnit.Nanoradian:
                    return FromNanoradians(value);
                case AngleUnit.Radian:
                    return FromRadians(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AngleUnit" /> to <see cref="Angle" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Angle unit value.</returns>
        public static Angle? From(double? value, AngleUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case AngleUnit.Arcminute:
                    return FromArcminutes(value.Value);
                case AngleUnit.Arcsecond:
                    return FromArcseconds(value.Value);
                case AngleUnit.Centiradian:
                    return FromCentiradians(value.Value);
                case AngleUnit.Deciradian:
                    return FromDeciradians(value.Value);
                case AngleUnit.Degree:
                    return FromDegrees(value.Value);
                case AngleUnit.Gradian:
                    return FromGradians(value.Value);
                case AngleUnit.Microradian:
                    return FromMicroradians(value.Value);
                case AngleUnit.Milliradian:
                    return FromMilliradians(value.Value);
                case AngleUnit.Nanoradian:
                    return FromNanoradians(value.Value);
                case AngleUnit.Radian:
                    return FromRadians(value.Value);

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
        public static string GetAbbreviation(AngleUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Angle operator -(Angle right)
        {
            return new Angle(-right._degrees);
        }

        public static Angle operator +(Angle left, Angle right)
        {
            return new Angle(left._degrees + right._degrees);
        }

        public static Angle operator -(Angle left, Angle right)
        {
            return new Angle(left._degrees - right._degrees);
        }

        public static Angle operator *(double left, Angle right)
        {
            return new Angle(left*right._degrees);
        }

        public static Angle operator *(Angle left, double right)
        {
            return new Angle(left._degrees*(double)right);
        }

        public static Angle operator /(Angle left, double right)
        {
            return new Angle(left._degrees/(double)right);
        }

        public static double operator /(Angle left, Angle right)
        {
            return Convert.ToDouble(left._degrees/right._degrees);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Angle)) throw new ArgumentException("Expected type Angle.", "obj");
            return CompareTo((Angle) obj);
        }

        public int CompareTo(Angle other)
        {
            return _degrees.CompareTo(other._degrees);
        }

        public static bool operator <=(Angle left, Angle right)
        {
            return left._degrees <= right._degrees;
        }

        public static bool operator >=(Angle left, Angle right)
        {
            return left._degrees >= right._degrees;
        }

        public static bool operator <(Angle left, Angle right)
        {
            return left._degrees < right._degrees;
        }

        public static bool operator >(Angle left, Angle right)
        {
            return left._degrees > right._degrees;
        }

        public static bool operator ==(Angle left, Angle right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._degrees == right._degrees;
        }

        public static bool operator !=(Angle left, Angle right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._degrees != right._degrees;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _degrees.Equals(((Angle) obj)._degrees);
        }

        public override int GetHashCode()
        {
            return _degrees.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AngleUnit unit)
        {
            switch (unit)
            {
                case AngleUnit.Arcminute:
                    return Arcminutes;
                case AngleUnit.Arcsecond:
                    return Arcseconds;
                case AngleUnit.Centiradian:
                    return Centiradians;
                case AngleUnit.Deciradian:
                    return Deciradians;
                case AngleUnit.Degree:
                    return Degrees;
                case AngleUnit.Gradian:
                    return Gradians;
                case AngleUnit.Microradian:
                    return Microradians;
                case AngleUnit.Milliradian:
                    return Milliradians;
                case AngleUnit.Nanoradian:
                    return Nanoradians;
                case AngleUnit.Radian:
                    return Radians;

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
        public static Angle Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<Angle> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Angle>();

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
                    AngleUnit unit = ParseUnit(unitString, formatProvider);
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
        public static AngleUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<AngleUnit>(str.Trim());

            if (unit == AngleUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized AngleUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Degree
        /// </summary>
        public static AngleUnit ToStringDefaultUnit { get; set; } = AngleUnit.Degree;

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
        public string ToString(AngleUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(AngleUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
