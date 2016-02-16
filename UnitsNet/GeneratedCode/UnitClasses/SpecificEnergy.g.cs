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
    ///     The SpecificEnergy
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct SpecificEnergy : IComparable, IComparable<SpecificEnergy>
    {
        /// <summary>
        ///     Base unit of SpecificEnergy.
        /// </summary>
        private readonly double _joulesPerKilogram;

        public SpecificEnergy(double joulesperkilogram) : this()
        {
            _joulesPerKilogram = joulesperkilogram;
        }

        #region Properties

        public static SpecificEnergyUnit BaseUnit
        {
            get { return SpecificEnergyUnit.JoulePerKilogram; }
        }

        /// <summary>
        ///     Get SpecificEnergy in CaloriesPerGram.
        /// </summary>
        public double CaloriesPerGram
        {
            get { return _joulesPerKilogram/4.184e3; }
        }

        /// <summary>
        ///     Get SpecificEnergy in JoulesPerKilogram.
        /// </summary>
        public double JoulesPerKilogram
        {
            get { return _joulesPerKilogram; }
        }

        /// <summary>
        ///     Get SpecificEnergy in KilocaloriesPerGram.
        /// </summary>
        public double KilocaloriesPerGram
        {
            get { return (_joulesPerKilogram/4.184e3) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in KilojoulesPerKilogram.
        /// </summary>
        public double KilojoulesPerKilogram
        {
            get { return (_joulesPerKilogram) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in KilowattHoursPerKilogram.
        /// </summary>
        public double KilowattHoursPerKilogram
        {
            get { return (_joulesPerKilogram/3.6e3) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in MegajoulesPerKilogram.
        /// </summary>
        public double MegajoulesPerKilogram
        {
            get { return (_joulesPerKilogram) / 1e6d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in MegawattHoursPerKilogram.
        /// </summary>
        public double MegawattHoursPerKilogram
        {
            get { return (_joulesPerKilogram/3.6e3) / 1e6d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in WattHoursPerKilogram.
        /// </summary>
        public double WattHoursPerKilogram
        {
            get { return _joulesPerKilogram/3.6e3; }
        }

        #endregion

        #region Static 

        public static SpecificEnergy Zero
        {
            get { return new SpecificEnergy(); }
        }

        /// <summary>
        ///     Get SpecificEnergy from CaloriesPerGram.
        /// </summary>
        public static SpecificEnergy FromCaloriesPerGram(double caloriespergram)
        {
            return new SpecificEnergy(caloriespergram*4.184e3);
        }

        /// <summary>
        ///     Get SpecificEnergy from JoulesPerKilogram.
        /// </summary>
        public static SpecificEnergy FromJoulesPerKilogram(double joulesperkilogram)
        {
            return new SpecificEnergy(joulesperkilogram);
        }

        /// <summary>
        ///     Get SpecificEnergy from KilocaloriesPerGram.
        /// </summary>
        public static SpecificEnergy FromKilocaloriesPerGram(double kilocaloriespergram)
        {
            return new SpecificEnergy((kilocaloriespergram*4.184e3) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificEnergy from KilojoulesPerKilogram.
        /// </summary>
        public static SpecificEnergy FromKilojoulesPerKilogram(double kilojoulesperkilogram)
        {
            return new SpecificEnergy((kilojoulesperkilogram) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificEnergy from KilowattHoursPerKilogram.
        /// </summary>
        public static SpecificEnergy FromKilowattHoursPerKilogram(double kilowatthoursperkilogram)
        {
            return new SpecificEnergy((kilowatthoursperkilogram*3.6e3) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificEnergy from MegajoulesPerKilogram.
        /// </summary>
        public static SpecificEnergy FromMegajoulesPerKilogram(double megajoulesperkilogram)
        {
            return new SpecificEnergy((megajoulesperkilogram) * 1e6d);
        }

        /// <summary>
        ///     Get SpecificEnergy from MegawattHoursPerKilogram.
        /// </summary>
        public static SpecificEnergy FromMegawattHoursPerKilogram(double megawatthoursperkilogram)
        {
            return new SpecificEnergy((megawatthoursperkilogram*3.6e3) * 1e6d);
        }

        /// <summary>
        ///     Get SpecificEnergy from WattHoursPerKilogram.
        /// </summary>
        public static SpecificEnergy FromWattHoursPerKilogram(double watthoursperkilogram)
        {
            return new SpecificEnergy(watthoursperkilogram*3.6e3);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificEnergyUnit" /> to <see cref="SpecificEnergy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificEnergy unit value.</returns>
        public static SpecificEnergy From(double value, SpecificEnergyUnit fromUnit)
        {
            switch (fromUnit)
            {
                case SpecificEnergyUnit.CaloriePerGram:
                    return FromCaloriesPerGram(value);
                case SpecificEnergyUnit.JoulePerKilogram:
                    return FromJoulesPerKilogram(value);
                case SpecificEnergyUnit.KilocaloriePerGram:
                    return FromKilocaloriesPerGram(value);
                case SpecificEnergyUnit.KilojoulePerKilogram:
                    return FromKilojoulesPerKilogram(value);
                case SpecificEnergyUnit.KilowattHourPerKilogram:
                    return FromKilowattHoursPerKilogram(value);
                case SpecificEnergyUnit.MegajoulePerKilogram:
                    return FromMegajoulesPerKilogram(value);
                case SpecificEnergyUnit.MegawattHourPerKilogram:
                    return FromMegawattHoursPerKilogram(value);
                case SpecificEnergyUnit.WattHourPerKilogram:
                    return FromWattHoursPerKilogram(value);

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
        public static string GetAbbreviation(SpecificEnergyUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static SpecificEnergy operator -(SpecificEnergy right)
        {
            return new SpecificEnergy(-right._joulesPerKilogram);
        }

        public static SpecificEnergy operator +(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left._joulesPerKilogram + right._joulesPerKilogram);
        }

        public static SpecificEnergy operator -(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left._joulesPerKilogram - right._joulesPerKilogram);
        }

        public static SpecificEnergy operator *(double left, SpecificEnergy right)
        {
            return new SpecificEnergy(left*right._joulesPerKilogram);
        }

        public static SpecificEnergy operator *(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left._joulesPerKilogram*(double)right);
        }

        public static SpecificEnergy operator /(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left._joulesPerKilogram/(double)right);
        }

        public static double operator /(SpecificEnergy left, SpecificEnergy right)
        {
            return Convert.ToDouble(left._joulesPerKilogram/right._joulesPerKilogram);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SpecificEnergy)) throw new ArgumentException("Expected type SpecificEnergy.", "obj");
            return CompareTo((SpecificEnergy) obj);
        }

        public int CompareTo(SpecificEnergy other)
        {
            return _joulesPerKilogram.CompareTo(other._joulesPerKilogram);
        }

        public static bool operator <=(SpecificEnergy left, SpecificEnergy right)
        {
            return left._joulesPerKilogram <= right._joulesPerKilogram;
        }

        public static bool operator >=(SpecificEnergy left, SpecificEnergy right)
        {
            return left._joulesPerKilogram >= right._joulesPerKilogram;
        }

        public static bool operator <(SpecificEnergy left, SpecificEnergy right)
        {
            return left._joulesPerKilogram < right._joulesPerKilogram;
        }

        public static bool operator >(SpecificEnergy left, SpecificEnergy right)
        {
            return left._joulesPerKilogram > right._joulesPerKilogram;
        }

        public static bool operator ==(SpecificEnergy left, SpecificEnergy right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._joulesPerKilogram == right._joulesPerKilogram;
        }

        public static bool operator !=(SpecificEnergy left, SpecificEnergy right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._joulesPerKilogram != right._joulesPerKilogram;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _joulesPerKilogram.Equals(((SpecificEnergy) obj)._joulesPerKilogram);
        }

        public override int GetHashCode()
        {
            return _joulesPerKilogram.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(SpecificEnergyUnit unit)
        {
            switch (unit)
            {
                case SpecificEnergyUnit.CaloriePerGram:
                    return CaloriesPerGram;
                case SpecificEnergyUnit.JoulePerKilogram:
                    return JoulesPerKilogram;
                case SpecificEnergyUnit.KilocaloriePerGram:
                    return KilocaloriesPerGram;
                case SpecificEnergyUnit.KilojoulePerKilogram:
                    return KilojoulesPerKilogram;
                case SpecificEnergyUnit.KilowattHourPerKilogram:
                    return KilowattHoursPerKilogram;
                case SpecificEnergyUnit.MegajoulePerKilogram:
                    return MegajoulesPerKilogram;
                case SpecificEnergyUnit.MegawattHourPerKilogram:
                    return MegawattHoursPerKilogram;
                case SpecificEnergyUnit.WattHourPerKilogram:
                    return WattHoursPerKilogram;

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
        public static SpecificEnergy Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<SpecificEnergy> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<SpecificEnergy>();

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
                    SpecificEnergyUnit unit = ParseUnit(unitString, formatProvider);
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
        public static SpecificEnergyUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<SpecificEnergyUnit>(str.Trim());

            if (unit == SpecificEnergyUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized SpecificEnergyUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is JoulePerKilogram
        /// </summary>
        public static SpecificEnergyUnit ToStringDefaultUnit { get; set; } = SpecificEnergyUnit.JoulePerKilogram;

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
        public string ToString(SpecificEnergyUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(SpecificEnergyUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
