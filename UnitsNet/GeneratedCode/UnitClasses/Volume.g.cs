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
    ///     Volume is the quantity of three-dimensional space enclosed by some closed boundary, for example, the space that a substance (solid, liquid, gas, or plasma) or shape occupies or contains.[1] Volume is often quantified numerically using the SI derived unit, the cubic metre. The volume of a container is generally understood to be the capacity of the container, i. e. the amount of fluid (gas or liquid) that the container could hold, rather than the amount of space the container itself displaces.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Volume : IComparable, IComparable<Volume>
    {
        /// <summary>
        ///     Base unit of Volume.
        /// </summary>
        private readonly double _cubicMeters;

        public Volume(double cubicmeters) : this()
        {
            _cubicMeters = cubicmeters;
        }

        #region Properties

        public static VolumeUnit BaseUnit
        {
            get { return VolumeUnit.CubicMeter; }
        }

        /// <summary>
        ///     Get Volume in Centiliters.
        /// </summary>
        public double Centiliters
        {
            get { return (_cubicMeters*1e3) / 1e-2d; }
        }

        /// <summary>
        ///     Get Volume in CubicCentimeters.
        /// </summary>
        public double CubicCentimeters
        {
            get { return _cubicMeters*1e6; }
        }

        /// <summary>
        ///     Get Volume in CubicDecimeters.
        /// </summary>
        public double CubicDecimeters
        {
            get { return _cubicMeters*1e3; }
        }

        /// <summary>
        ///     Get Volume in CubicFeet.
        /// </summary>
        public double CubicFeet
        {
            get { return _cubicMeters/0.0283168; }
        }

        /// <summary>
        ///     Get Volume in CubicInches.
        /// </summary>
        public double CubicInches
        {
            get { return _cubicMeters/(1.6387*1e-5); }
        }

        /// <summary>
        ///     Get Volume in CubicKilometers.
        /// </summary>
        public double CubicKilometers
        {
            get { return _cubicMeters/1e9; }
        }

        /// <summary>
        ///     Get Volume in CubicMeters.
        /// </summary>
        public double CubicMeters
        {
            get { return _cubicMeters; }
        }

        /// <summary>
        ///     Get Volume in CubicMiles.
        /// </summary>
        public double CubicMiles
        {
            get { return _cubicMeters/(4.16818183*1e9); }
        }

        /// <summary>
        ///     Get Volume in CubicMillimeters.
        /// </summary>
        public double CubicMillimeters
        {
            get { return _cubicMeters*1e9; }
        }

        /// <summary>
        ///     Get Volume in CubicYards.
        /// </summary>
        public double CubicYards
        {
            get { return _cubicMeters/0.764554858; }
        }

        /// <summary>
        ///     Get Volume in Deciliters.
        /// </summary>
        public double Deciliters
        {
            get { return (_cubicMeters*1e3) / 1e-1d; }
        }

        /// <summary>
        ///     Get Volume in Hectoliters.
        /// </summary>
        public double Hectoliters
        {
            get { return (_cubicMeters*1e3) / 1e2d; }
        }

        /// <summary>
        ///     Get Volume in ImperialGallons.
        /// </summary>
        public double ImperialGallons
        {
            get { return _cubicMeters/0.00454609000000181429905810072407; }
        }

        /// <summary>
        ///     Get Volume in ImperialOunces.
        /// </summary>
        public double ImperialOunces
        {
            get { return _cubicMeters/2.8413062499962901241875439064617e-5; }
        }

        /// <summary>
        ///     Get Volume in Liters.
        /// </summary>
        public double Liters
        {
            get { return _cubicMeters*1e3; }
        }

        /// <summary>
        ///     Get Volume in Milliliters.
        /// </summary>
        public double Milliliters
        {
            get { return (_cubicMeters*1e3) / 1e-3d; }
        }

        /// <summary>
        ///     Get Volume in Tablespoons.
        /// </summary>
        public double Tablespoons
        {
            get { return _cubicMeters/1.47867648e-5; }
        }

        /// <summary>
        ///     Get Volume in Teaspoons.
        /// </summary>
        public double Teaspoons
        {
            get { return _cubicMeters/4.92892159e-6; }
        }

        /// <summary>
        ///     Get Volume in UsGallons.
        /// </summary>
        public double UsGallons
        {
            get { return _cubicMeters/0.00378541; }
        }

        /// <summary>
        ///     Get Volume in UsOunces.
        /// </summary>
        public double UsOunces
        {
            get { return _cubicMeters/2.957352956253760505068307980135e-5; }
        }

        #endregion

        #region Static 

        public static Volume Zero
        {
            get { return new Volume(); }
        }

        /// <summary>
        ///     Get Volume from Centiliters.
        /// </summary>
        public static Volume FromCentiliters(double centiliters)
        {
            return new Volume((centiliters/1e3) * 1e-2d);
        }

        /// <summary>
        ///     Get Volume from CubicCentimeters.
        /// </summary>
        public static Volume FromCubicCentimeters(double cubiccentimeters)
        {
            return new Volume(cubiccentimeters/1e6);
        }

        /// <summary>
        ///     Get Volume from CubicDecimeters.
        /// </summary>
        public static Volume FromCubicDecimeters(double cubicdecimeters)
        {
            return new Volume(cubicdecimeters/1e3);
        }

        /// <summary>
        ///     Get Volume from CubicFeet.
        /// </summary>
        public static Volume FromCubicFeet(double cubicfeet)
        {
            return new Volume(cubicfeet*0.0283168);
        }

        /// <summary>
        ///     Get Volume from CubicInches.
        /// </summary>
        public static Volume FromCubicInches(double cubicinches)
        {
            return new Volume(cubicinches*1.6387*1e-5);
        }

        /// <summary>
        ///     Get Volume from CubicKilometers.
        /// </summary>
        public static Volume FromCubicKilometers(double cubickilometers)
        {
            return new Volume(cubickilometers*1e9);
        }

        /// <summary>
        ///     Get Volume from CubicMeters.
        /// </summary>
        public static Volume FromCubicMeters(double cubicmeters)
        {
            return new Volume(cubicmeters);
        }

        /// <summary>
        ///     Get Volume from CubicMiles.
        /// </summary>
        public static Volume FromCubicMiles(double cubicmiles)
        {
            return new Volume(cubicmiles*4.16818183*1e9);
        }

        /// <summary>
        ///     Get Volume from CubicMillimeters.
        /// </summary>
        public static Volume FromCubicMillimeters(double cubicmillimeters)
        {
            return new Volume(cubicmillimeters/1e9);
        }

        /// <summary>
        ///     Get Volume from CubicYards.
        /// </summary>
        public static Volume FromCubicYards(double cubicyards)
        {
            return new Volume(cubicyards*0.764554858);
        }

        /// <summary>
        ///     Get Volume from Deciliters.
        /// </summary>
        public static Volume FromDeciliters(double deciliters)
        {
            return new Volume((deciliters/1e3) * 1e-1d);
        }

        /// <summary>
        ///     Get Volume from Hectoliters.
        /// </summary>
        public static Volume FromHectoliters(double hectoliters)
        {
            return new Volume((hectoliters/1e3) * 1e2d);
        }

        /// <summary>
        ///     Get Volume from ImperialGallons.
        /// </summary>
        public static Volume FromImperialGallons(double imperialgallons)
        {
            return new Volume(imperialgallons*0.00454609000000181429905810072407);
        }

        /// <summary>
        ///     Get Volume from ImperialOunces.
        /// </summary>
        public static Volume FromImperialOunces(double imperialounces)
        {
            return new Volume(imperialounces*2.8413062499962901241875439064617e-5);
        }

        /// <summary>
        ///     Get Volume from Liters.
        /// </summary>
        public static Volume FromLiters(double liters)
        {
            return new Volume(liters/1e3);
        }

        /// <summary>
        ///     Get Volume from Milliliters.
        /// </summary>
        public static Volume FromMilliliters(double milliliters)
        {
            return new Volume((milliliters/1e3) * 1e-3d);
        }

        /// <summary>
        ///     Get Volume from Tablespoons.
        /// </summary>
        public static Volume FromTablespoons(double tablespoons)
        {
            return new Volume(tablespoons*1.47867648e-5);
        }

        /// <summary>
        ///     Get Volume from Teaspoons.
        /// </summary>
        public static Volume FromTeaspoons(double teaspoons)
        {
            return new Volume(teaspoons*4.92892159e-6);
        }

        /// <summary>
        ///     Get Volume from UsGallons.
        /// </summary>
        public static Volume FromUsGallons(double usgallons)
        {
            return new Volume(usgallons*0.00378541);
        }

        /// <summary>
        ///     Get Volume from UsOunces.
        /// </summary>
        public static Volume FromUsOunces(double usounces)
        {
            return new Volume(usounces*2.957352956253760505068307980135e-5);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="VolumeUnit" /> to <see cref="Volume" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Volume unit value.</returns>
        public static Volume From(double value, VolumeUnit fromUnit)
        {
            switch (fromUnit)
            {
                case VolumeUnit.Centiliter:
                    return FromCentiliters(value);
                case VolumeUnit.CubicCentimeter:
                    return FromCubicCentimeters(value);
                case VolumeUnit.CubicDecimeter:
                    return FromCubicDecimeters(value);
                case VolumeUnit.CubicFoot:
                    return FromCubicFeet(value);
                case VolumeUnit.CubicInch:
                    return FromCubicInches(value);
                case VolumeUnit.CubicKilometer:
                    return FromCubicKilometers(value);
                case VolumeUnit.CubicMeter:
                    return FromCubicMeters(value);
                case VolumeUnit.CubicMile:
                    return FromCubicMiles(value);
                case VolumeUnit.CubicMillimeter:
                    return FromCubicMillimeters(value);
                case VolumeUnit.CubicYard:
                    return FromCubicYards(value);
                case VolumeUnit.Deciliter:
                    return FromDeciliters(value);
                case VolumeUnit.Hectoliter:
                    return FromHectoliters(value);
                case VolumeUnit.ImperialGallon:
                    return FromImperialGallons(value);
                case VolumeUnit.ImperialOunce:
                    return FromImperialOunces(value);
                case VolumeUnit.Liter:
                    return FromLiters(value);
                case VolumeUnit.Milliliter:
                    return FromMilliliters(value);
                case VolumeUnit.Tablespoon:
                    return FromTablespoons(value);
                case VolumeUnit.Teaspoon:
                    return FromTeaspoons(value);
                case VolumeUnit.UsGallon:
                    return FromUsGallons(value);
                case VolumeUnit.UsOunce:
                    return FromUsOunces(value);

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
        public static string GetAbbreviation(VolumeUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Volume operator -(Volume right)
        {
            return new Volume(-right._cubicMeters);
        }

        public static Volume operator +(Volume left, Volume right)
        {
            return new Volume(left._cubicMeters + right._cubicMeters);
        }

        public static Volume operator -(Volume left, Volume right)
        {
            return new Volume(left._cubicMeters - right._cubicMeters);
        }

        public static Volume operator *(double left, Volume right)
        {
            return new Volume(left*right._cubicMeters);
        }

        public static Volume operator *(Volume left, double right)
        {
            return new Volume(left._cubicMeters*(double)right);
        }

        public static Volume operator /(Volume left, double right)
        {
            return new Volume(left._cubicMeters/(double)right);
        }

        public static double operator /(Volume left, Volume right)
        {
            return Convert.ToDouble(left._cubicMeters/right._cubicMeters);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Volume)) throw new ArgumentException("Expected type Volume.", "obj");
            return CompareTo((Volume) obj);
        }

        public int CompareTo(Volume other)
        {
            return _cubicMeters.CompareTo(other._cubicMeters);
        }

        public static bool operator <=(Volume left, Volume right)
        {
            return left._cubicMeters <= right._cubicMeters;
        }

        public static bool operator >=(Volume left, Volume right)
        {
            return left._cubicMeters >= right._cubicMeters;
        }

        public static bool operator <(Volume left, Volume right)
        {
            return left._cubicMeters < right._cubicMeters;
        }

        public static bool operator >(Volume left, Volume right)
        {
            return left._cubicMeters > right._cubicMeters;
        }

        public static bool operator ==(Volume left, Volume right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._cubicMeters == right._cubicMeters;
        }

        public static bool operator !=(Volume left, Volume right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._cubicMeters != right._cubicMeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _cubicMeters.Equals(((Volume) obj)._cubicMeters);
        }

        public override int GetHashCode()
        {
            return _cubicMeters.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(VolumeUnit unit)
        {
            switch (unit)
            {
                case VolumeUnit.Centiliter:
                    return Centiliters;
                case VolumeUnit.CubicCentimeter:
                    return CubicCentimeters;
                case VolumeUnit.CubicDecimeter:
                    return CubicDecimeters;
                case VolumeUnit.CubicFoot:
                    return CubicFeet;
                case VolumeUnit.CubicInch:
                    return CubicInches;
                case VolumeUnit.CubicKilometer:
                    return CubicKilometers;
                case VolumeUnit.CubicMeter:
                    return CubicMeters;
                case VolumeUnit.CubicMile:
                    return CubicMiles;
                case VolumeUnit.CubicMillimeter:
                    return CubicMillimeters;
                case VolumeUnit.CubicYard:
                    return CubicYards;
                case VolumeUnit.Deciliter:
                    return Deciliters;
                case VolumeUnit.Hectoliter:
                    return Hectoliters;
                case VolumeUnit.ImperialGallon:
                    return ImperialGallons;
                case VolumeUnit.ImperialOunce:
                    return ImperialOunces;
                case VolumeUnit.Liter:
                    return Liters;
                case VolumeUnit.Milliliter:
                    return Milliliters;
                case VolumeUnit.Tablespoon:
                    return Tablespoons;
                case VolumeUnit.Teaspoon:
                    return Teaspoons;
                case VolumeUnit.UsGallon:
                    return UsGallons;
                case VolumeUnit.UsOunce:
                    return UsOunces;

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
        public static Volume Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<Volume> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Volume>();

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
                    VolumeUnit unit = ParseUnit(unitString, formatProvider);
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
        public static VolumeUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<VolumeUnit>(str.Trim());

            if (unit == VolumeUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized VolumeUnit.");
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
            return ToString(VolumeUnit.CubicMeter);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(VolumeUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(VolumeUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
