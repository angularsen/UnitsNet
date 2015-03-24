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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Many different units of length have been used around the world. The main units in modern use are U.S. customary units in the United States and the Metric system elsewhere. British Imperial units are still used for some purposes in the United Kingdom and some other countries. The metric system is sub-divided into SI and non-SI units.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Length : IComparable, IComparable<Length>
    {
        /// <summary>
        ///     Base unit of Length.
        /// </summary>
        private readonly double _meters;

        public Length(double meters) : this()
        {
            _meters = meters;
        }

        #region Properties

        /// <summary>
        ///     Get Length in Centimeters.
        /// </summary>
        public double Centimeters
        {
            get { return (_meters) / 1e-2d; }
        }

        /// <summary>
        ///     Get Length in Decimeters.
        /// </summary>
        public double Decimeters
        {
            get { return (_meters) / 1e-1d; }
        }

        /// <summary>
        ///     Get Length in Feet.
        /// </summary>
        public double Feet
        {
            get { return _meters/0.3048; }
        }

        /// <summary>
        ///     Get Length in Inches.
        /// </summary>
        public double Inches
        {
            get { return _meters/2.54e-2; }
        }

        /// <summary>
        ///     Get Length in Kilometers.
        /// </summary>
        public double Kilometers
        {
            get { return (_meters) / 1e3d; }
        }

        /// <summary>
        ///     Get Length in Meters.
        /// </summary>
        public double Meters
        {
            get { return _meters; }
        }

        /// <summary>
        ///     Get Length in Microinches.
        /// </summary>
        public double Microinches
        {
            get { return _meters/2.54e-8; }
        }

        /// <summary>
        ///     Get Length in Micrometers.
        /// </summary>
        public double Micrometers
        {
            get { return (_meters) / 1e-6d; }
        }

        /// <summary>
        ///     Get Length in Mils.
        /// </summary>
        public double Mils
        {
            get { return _meters/2.54e-5; }
        }

        /// <summary>
        ///     Get Length in Miles.
        /// </summary>
        public double Miles
        {
            get { return _meters/1609.34; }
        }

        /// <summary>
        ///     Get Length in Millimeters.
        /// </summary>
        public double Millimeters
        {
            get { return (_meters) / 1e-3d; }
        }

        /// <summary>
        ///     Get Length in Nanometers.
        /// </summary>
        public double Nanometers
        {
            get { return (_meters) / 1e-9d; }
        }

        /// <summary>
        ///     Get Length in Yards.
        /// </summary>
        public double Yards
        {
            get { return _meters/0.9144; }
        }

        #endregion

        #region Static 

        public static Length Zero
        {
            get { return new Length(); }
        }

        /// <summary>
        ///     Get Length from Centimeters.
        /// </summary>
        public static Length FromCentimeters(double centimeters)
        {
            return new Length((centimeters) * 1e-2d);
        }

        /// <summary>
        ///     Get Length from Decimeters.
        /// </summary>
        public static Length FromDecimeters(double decimeters)
        {
            return new Length((decimeters) * 1e-1d);
        }

        /// <summary>
        ///     Get Length from Feet.
        /// </summary>
        public static Length FromFeet(double feet)
        {
            return new Length(feet*0.3048);
        }

        /// <summary>
        ///     Get Length from Inches.
        /// </summary>
        public static Length FromInches(double inches)
        {
            return new Length(inches*2.54e-2);
        }

        /// <summary>
        ///     Get Length from Kilometers.
        /// </summary>
        public static Length FromKilometers(double kilometers)
        {
            return new Length((kilometers) * 1e3d);
        }

        /// <summary>
        ///     Get Length from Meters.
        /// </summary>
        public static Length FromMeters(double meters)
        {
            return new Length(meters);
        }

        /// <summary>
        ///     Get Length from Microinches.
        /// </summary>
        public static Length FromMicroinches(double microinches)
        {
            return new Length(microinches*2.54e-8);
        }

        /// <summary>
        ///     Get Length from Micrometers.
        /// </summary>
        public static Length FromMicrometers(double micrometers)
        {
            return new Length((micrometers) * 1e-6d);
        }

        /// <summary>
        ///     Get Length from Mils.
        /// </summary>
        public static Length FromMils(double mils)
        {
            return new Length(mils*2.54e-5);
        }

        /// <summary>
        ///     Get Length from Miles.
        /// </summary>
        public static Length FromMiles(double miles)
        {
            return new Length(miles*1609.34);
        }

        /// <summary>
        ///     Get Length from Millimeters.
        /// </summary>
        public static Length FromMillimeters(double millimeters)
        {
            return new Length((millimeters) * 1e-3d);
        }

        /// <summary>
        ///     Get Length from Nanometers.
        /// </summary>
        public static Length FromNanometers(double nanometers)
        {
            return new Length((nanometers) * 1e-9d);
        }

        /// <summary>
        ///     Get Length from Yards.
        /// </summary>
        public static Length FromYards(double yards)
        {
            return new Length(yards*0.9144);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LengthUnit" /> to <see cref="Length" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Length unit value.</returns>
        public static Length From(double value, LengthUnit fromUnit)
        {
            switch (fromUnit)
            {
                case LengthUnit.Centimeter:
                    return FromCentimeters(value);
                case LengthUnit.Decimeter:
                    return FromDecimeters(value);
                case LengthUnit.Foot:
                    return FromFeet(value);
                case LengthUnit.Inch:
                    return FromInches(value);
                case LengthUnit.Kilometer:
                    return FromKilometers(value);
                case LengthUnit.Meter:
                    return FromMeters(value);
                case LengthUnit.Microinch:
                    return FromMicroinches(value);
                case LengthUnit.Micrometer:
                    return FromMicrometers(value);
                case LengthUnit.Mil:
                    return FromMils(value);
                case LengthUnit.Mile:
                    return FromMiles(value);
                case LengthUnit.Millimeter:
                    return FromMillimeters(value);
                case LengthUnit.Nanometer:
                    return FromNanometers(value);
                case LengthUnit.Yard:
                    return FromYards(value);

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
        public static string GetAbbreviation(LengthUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Length operator -(Length right)
        {
            return new Length(-right._meters);
        }

        public static Length operator +(Length left, Length right)
        {
            return new Length(left._meters + right._meters);
        }

        public static Length operator -(Length left, Length right)
        {
            return new Length(left._meters - right._meters);
        }

        public static Length operator *(double left, Length right)
        {
            return new Length(left*right._meters);
        }

        public static Length operator *(Length left, double right)
        {
            return new Length(left._meters*(double)right);
        }

        public static Length operator /(Length left, double right)
        {
            return new Length(left._meters/(double)right);
        }

        public static double operator /(Length left, Length right)
        {
            return Convert.ToDouble(left._meters/right._meters);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Length)) throw new ArgumentException("Expected type Length.", "obj");
            return CompareTo((Length) obj);
        }

        public int CompareTo(Length other)
        {
            return _meters.CompareTo(other._meters);
        }

        public static bool operator <=(Length left, Length right)
        {
            return left._meters <= right._meters;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left._meters >= right._meters;
        }

        public static bool operator <(Length left, Length right)
        {
            return left._meters < right._meters;
        }

        public static bool operator >(Length left, Length right)
        {
            return left._meters > right._meters;
        }

        public static bool operator ==(Length left, Length right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._meters == right._meters;
        }

        public static bool operator !=(Length left, Length right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._meters != right._meters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _meters.Equals(((Length) obj)._meters);
        }

        public override int GetHashCode()
        {
            return _meters.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.Centimeter:
                    return Centimeters;
                case LengthUnit.Decimeter:
                    return Decimeters;
                case LengthUnit.Foot:
                    return Feet;
                case LengthUnit.Inch:
                    return Inches;
                case LengthUnit.Kilometer:
                    return Kilometers;
                case LengthUnit.Meter:
                    return Meters;
                case LengthUnit.Microinch:
                    return Microinches;
                case LengthUnit.Micrometer:
                    return Micrometers;
                case LengthUnit.Mil:
                    return Mils;
                case LengthUnit.Mile:
                    return Miles;
                case LengthUnit.Millimeter:
                    return Millimeters;
                case LengthUnit.Nanometer:
                    return Nanometers;
                case LengthUnit.Yard:
                    return Yards;

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
        public static Length Parse(string str, IFormatProvider formatProvider = null)
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
                LengthUnit unit = ParseUnit(unitString, formatProvider);
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
        public static LengthUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<LengthUnit>(str.Trim());

            if (unit == LengthUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized LengthUnit.");
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
            return ToString(LengthUnit.Meter);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(LengthUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(LengthUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
