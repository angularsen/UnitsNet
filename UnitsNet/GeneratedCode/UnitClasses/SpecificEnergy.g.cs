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
    ///     The SpecificEnergy
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct SpecificEnergy : IComparable, IComparable<SpecificEnergy>
    {
        /// <summary>
        ///     Base unit of SpecificEnergy.
        /// </summary>
        private readonly double _joulesPerKiloGram;

        public SpecificEnergy(double joulesperkilogram) : this()
        {
            _joulesPerKiloGram = joulesperkilogram;
        }

        #region Properties

        public static SpecificEnergyUnit BaseUnit
        {
            get { return SpecificEnergyUnit.JoulePerKiloGram; }
        }

        /// <summary>
        ///     Get SpecificEnergy in JoulesPerKiloGram.
        /// </summary>
        public double JoulesPerKiloGram
        {
            get { return _joulesPerKiloGram; }
        }

        /// <summary>
        ///     Get SpecificEnergy in KiloCaloriesPerGram.
        /// </summary>
        public double KiloCaloriesPerGram
        {
            get { return _joulesPerKiloGram/4.184e6; }
        }

        /// <summary>
        ///     Get SpecificEnergy in KilojoulesPerKiloGram.
        /// </summary>
        public double KilojoulesPerKiloGram
        {
            get { return (_joulesPerKiloGram) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in KilowattHoursPerKiloGram.
        /// </summary>
        public double KilowattHoursPerKiloGram
        {
            get { return (_joulesPerKiloGram/3.6e3) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in MegajoulesPerKiloGram.
        /// </summary>
        public double MegajoulesPerKiloGram
        {
            get { return (_joulesPerKiloGram) / 1e6d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in MegawattHoursPerKiloGram.
        /// </summary>
        public double MegawattHoursPerKiloGram
        {
            get { return (_joulesPerKiloGram/3.6e3) / 1e6d; }
        }

        /// <summary>
        ///     Get SpecificEnergy in WattHoursPerKiloGram.
        /// </summary>
        public double WattHoursPerKiloGram
        {
            get { return _joulesPerKiloGram/3.6e3; }
        }

        #endregion

        #region Static 

        public static SpecificEnergy Zero
        {
            get { return new SpecificEnergy(); }
        }

        /// <summary>
        ///     Get SpecificEnergy from JoulesPerKiloGram.
        /// </summary>
        public static SpecificEnergy FromJoulesPerKiloGram(double joulesperkilogram)
        {
            return new SpecificEnergy(joulesperkilogram);
        }

        /// <summary>
        ///     Get SpecificEnergy from KiloCaloriesPerGram.
        /// </summary>
        public static SpecificEnergy FromKiloCaloriesPerGram(double kilocaloriespergram)
        {
            return new SpecificEnergy(kilocaloriespergram*4.184e6);
        }

        /// <summary>
        ///     Get SpecificEnergy from KilojoulesPerKiloGram.
        /// </summary>
        public static SpecificEnergy FromKilojoulesPerKiloGram(double kilojoulesperkilogram)
        {
            return new SpecificEnergy((kilojoulesperkilogram) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificEnergy from KilowattHoursPerKiloGram.
        /// </summary>
        public static SpecificEnergy FromKilowattHoursPerKiloGram(double kilowatthoursperkilogram)
        {
            return new SpecificEnergy((kilowatthoursperkilogram*3.6e3) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificEnergy from MegajoulesPerKiloGram.
        /// </summary>
        public static SpecificEnergy FromMegajoulesPerKiloGram(double megajoulesperkilogram)
        {
            return new SpecificEnergy((megajoulesperkilogram) * 1e6d);
        }

        /// <summary>
        ///     Get SpecificEnergy from MegawattHoursPerKiloGram.
        /// </summary>
        public static SpecificEnergy FromMegawattHoursPerKiloGram(double megawatthoursperkilogram)
        {
            return new SpecificEnergy((megawatthoursperkilogram*3.6e3) * 1e6d);
        }

        /// <summary>
        ///     Get SpecificEnergy from WattHoursPerKiloGram.
        /// </summary>
        public static SpecificEnergy FromWattHoursPerKiloGram(double watthoursperkilogram)
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
                case SpecificEnergyUnit.JoulePerKiloGram:
                    return FromJoulesPerKiloGram(value);
                case SpecificEnergyUnit.KiloCaloriePerGram:
                    return FromKiloCaloriesPerGram(value);
                case SpecificEnergyUnit.KilojoulePerKiloGram:
                    return FromKilojoulesPerKiloGram(value);
                case SpecificEnergyUnit.KilowattHourPerKiloGram:
                    return FromKilowattHoursPerKiloGram(value);
                case SpecificEnergyUnit.MegajoulePerKiloGram:
                    return FromMegajoulesPerKiloGram(value);
                case SpecificEnergyUnit.MegawattHourPerKiloGram:
                    return FromMegawattHoursPerKiloGram(value);
                case SpecificEnergyUnit.WattHourPerKiloGram:
                    return FromWattHoursPerKiloGram(value);

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
            return new SpecificEnergy(-right._joulesPerKiloGram);
        }

        public static SpecificEnergy operator +(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left._joulesPerKiloGram + right._joulesPerKiloGram);
        }

        public static SpecificEnergy operator -(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left._joulesPerKiloGram - right._joulesPerKiloGram);
        }

        public static SpecificEnergy operator *(double left, SpecificEnergy right)
        {
            return new SpecificEnergy(left*right._joulesPerKiloGram);
        }

        public static SpecificEnergy operator *(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left._joulesPerKiloGram*(double)right);
        }

        public static SpecificEnergy operator /(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left._joulesPerKiloGram/(double)right);
        }

        public static double operator /(SpecificEnergy left, SpecificEnergy right)
        {
            return Convert.ToDouble(left._joulesPerKiloGram/right._joulesPerKiloGram);
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
            return _joulesPerKiloGram.CompareTo(other._joulesPerKiloGram);
        }

        public static bool operator <=(SpecificEnergy left, SpecificEnergy right)
        {
            return left._joulesPerKiloGram <= right._joulesPerKiloGram;
        }

        public static bool operator >=(SpecificEnergy left, SpecificEnergy right)
        {
            return left._joulesPerKiloGram >= right._joulesPerKiloGram;
        }

        public static bool operator <(SpecificEnergy left, SpecificEnergy right)
        {
            return left._joulesPerKiloGram < right._joulesPerKiloGram;
        }

        public static bool operator >(SpecificEnergy left, SpecificEnergy right)
        {
            return left._joulesPerKiloGram > right._joulesPerKiloGram;
        }

        public static bool operator ==(SpecificEnergy left, SpecificEnergy right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._joulesPerKiloGram == right._joulesPerKiloGram;
        }

        public static bool operator !=(SpecificEnergy left, SpecificEnergy right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._joulesPerKiloGram != right._joulesPerKiloGram;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _joulesPerKiloGram.Equals(((SpecificEnergy) obj)._joulesPerKiloGram);
        }

        public override int GetHashCode()
        {
            return _joulesPerKiloGram.GetHashCode();
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
                case SpecificEnergyUnit.JoulePerKiloGram:
                    return JoulesPerKiloGram;
                case SpecificEnergyUnit.KiloCaloriePerGram:
                    return KiloCaloriesPerGram;
                case SpecificEnergyUnit.KilojoulePerKiloGram:
                    return KilojoulesPerKiloGram;
                case SpecificEnergyUnit.KilowattHourPerKiloGram:
                    return KilowattHoursPerKiloGram;
                case SpecificEnergyUnit.MegajoulePerKiloGram:
                    return MegajoulesPerKiloGram;
                case SpecificEnergyUnit.MegawattHourPerKiloGram:
                    return MegawattHoursPerKiloGram;
                case SpecificEnergyUnit.WattHourPerKiloGram:
                    return WattHoursPerKiloGram;

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
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(SpecificEnergyUnit.JoulePerKiloGram);
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
