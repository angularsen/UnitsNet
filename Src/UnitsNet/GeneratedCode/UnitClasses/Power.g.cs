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
    ///     In physics, power is the rate of doing work. It is equivalent to an amount of energy consumed per unit time.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Power : IComparable, IComparable<Power>
    {
        /// <summary>
        ///     Base unit of Power.
        /// </summary>
        private readonly decimal _watts;

        public Power(decimal watts) : this()
        {
            _watts = watts;
        }

        #region Properties

        /// <summary>
        ///     Get Power in Femtowatts.
        /// </summary>
        public double Femtowatts
        {
            get { return Convert.ToDouble((_watts) / 1e-15m); }
        }

        /// <summary>
        ///     Get Power in Gigawatts.
        /// </summary>
        public double Gigawatts
        {
            get { return Convert.ToDouble((_watts) / 1e9m); }
        }

        /// <summary>
        ///     Get Power in Kilowatts.
        /// </summary>
        public double Kilowatts
        {
            get { return Convert.ToDouble((_watts) / 1e3m); }
        }

        /// <summary>
        ///     Get Power in Megawatts.
        /// </summary>
        public double Megawatts
        {
            get { return Convert.ToDouble((_watts) / 1e6m); }
        }

        /// <summary>
        ///     Get Power in Microwatts.
        /// </summary>
        public double Microwatts
        {
            get { return Convert.ToDouble((_watts) / 1e-6m); }
        }

        /// <summary>
        ///     Get Power in Milliwatts.
        /// </summary>
        public double Milliwatts
        {
            get { return Convert.ToDouble((_watts) / 1e-3m); }
        }

        /// <summary>
        ///     Get Power in Nanowatts.
        /// </summary>
        public double Nanowatts
        {
            get { return Convert.ToDouble((_watts) / 1e-9m); }
        }

        /// <summary>
        ///     Get Power in Petawatts.
        /// </summary>
        public double Petawatts
        {
            get { return Convert.ToDouble((_watts) / 1e15m); }
        }

        /// <summary>
        ///     Get Power in Picowatts.
        /// </summary>
        public double Picowatts
        {
            get { return Convert.ToDouble((_watts) / 1e-12m); }
        }

        /// <summary>
        ///     Get Power in Terawatts.
        /// </summary>
        public double Terawatts
        {
            get { return Convert.ToDouble((_watts) / 1e12m); }
        }

        /// <summary>
        ///     Get Power in Watts.
        /// </summary>
        public double Watts
        {
            get { return Convert.ToDouble(_watts); }
        }

        #endregion

        #region Static 

        public static Power Zero
        {
            get { return new Power(); }
        }

        /// <summary>
        ///     Get Power from Femtowatts.
        /// </summary>
        public static Power FromFemtowatts(double femtowatts)
        {
            return new Power(Convert.ToDecimal((femtowatts) * 1e-15d));
        }

        /// <summary>
        ///     Get Power from Gigawatts.
        /// </summary>
        public static Power FromGigawatts(double gigawatts)
        {
            return new Power(Convert.ToDecimal((gigawatts) * 1e9d));
        }

        /// <summary>
        ///     Get Power from Kilowatts.
        /// </summary>
        public static Power FromKilowatts(double kilowatts)
        {
            return new Power(Convert.ToDecimal((kilowatts) * 1e3d));
        }

        /// <summary>
        ///     Get Power from Megawatts.
        /// </summary>
        public static Power FromMegawatts(double megawatts)
        {
            return new Power(Convert.ToDecimal((megawatts) * 1e6d));
        }

        /// <summary>
        ///     Get Power from Microwatts.
        /// </summary>
        public static Power FromMicrowatts(double microwatts)
        {
            return new Power(Convert.ToDecimal((microwatts) * 1e-6d));
        }

        /// <summary>
        ///     Get Power from Milliwatts.
        /// </summary>
        public static Power FromMilliwatts(double milliwatts)
        {
            return new Power(Convert.ToDecimal((milliwatts) * 1e-3d));
        }

        /// <summary>
        ///     Get Power from Nanowatts.
        /// </summary>
        public static Power FromNanowatts(double nanowatts)
        {
            return new Power(Convert.ToDecimal((nanowatts) * 1e-9d));
        }

        /// <summary>
        ///     Get Power from Petawatts.
        /// </summary>
        public static Power FromPetawatts(double petawatts)
        {
            return new Power(Convert.ToDecimal((petawatts) * 1e15d));
        }

        /// <summary>
        ///     Get Power from Picowatts.
        /// </summary>
        public static Power FromPicowatts(double picowatts)
        {
            return new Power(Convert.ToDecimal((picowatts) * 1e-12d));
        }

        /// <summary>
        ///     Get Power from Terawatts.
        /// </summary>
        public static Power FromTerawatts(double terawatts)
        {
            return new Power(Convert.ToDecimal((terawatts) * 1e12d));
        }

        /// <summary>
        ///     Get Power from Watts.
        /// </summary>
        public static Power FromWatts(double watts)
        {
            return new Power(Convert.ToDecimal(watts));
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="PowerUnit" /> to <see cref="Power" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Power unit value.</returns>
        public static Power From(double value, PowerUnit fromUnit)
        {
            switch (fromUnit)
            {
                case PowerUnit.Femtowatt:
                    return FromFemtowatts(value);
                case PowerUnit.Gigawatt:
                    return FromGigawatts(value);
                case PowerUnit.Kilowatt:
                    return FromKilowatts(value);
                case PowerUnit.Megawatt:
                    return FromMegawatts(value);
                case PowerUnit.Microwatt:
                    return FromMicrowatts(value);
                case PowerUnit.Milliwatt:
                    return FromMilliwatts(value);
                case PowerUnit.Nanowatt:
                    return FromNanowatts(value);
                case PowerUnit.Petawatt:
                    return FromPetawatts(value);
                case PowerUnit.Picowatt:
                    return FromPicowatts(value);
                case PowerUnit.Terawatt:
                    return FromTerawatts(value);
                case PowerUnit.Watt:
                    return FromWatts(value);

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
        public static string GetAbbreviation(PowerUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Power operator -(Power right)
        {
            return new Power(-right._watts);
        }

        public static Power operator +(Power left, Power right)
        {
            return new Power(left._watts + right._watts);
        }

        public static Power operator -(Power left, Power right)
        {
            return new Power(left._watts - right._watts);
        }

        public static Power operator *(decimal left, Power right)
        {
            return new Power(left*right._watts);
        }

        public static Power operator *(Power left, double right)
        {
            return new Power(left._watts*(decimal)right);
        }

        public static Power operator /(Power left, double right)
        {
            return new Power(left._watts/(decimal)right);
        }

        public static double operator /(Power left, Power right)
        {
            return Convert.ToDouble(left._watts/right._watts);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Power)) throw new ArgumentException("Expected type Power.", "obj");
            return CompareTo((Power) obj);
        }

        public int CompareTo(Power other)
        {
            return _watts.CompareTo(other._watts);
        }

        public static bool operator <=(Power left, Power right)
        {
            return left._watts <= right._watts;
        }

        public static bool operator >=(Power left, Power right)
        {
            return left._watts >= right._watts;
        }

        public static bool operator <(Power left, Power right)
        {
            return left._watts < right._watts;
        }

        public static bool operator >(Power left, Power right)
        {
            return left._watts > right._watts;
        }

        public static bool operator ==(Power left, Power right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._watts == right._watts;
        }

        public static bool operator !=(Power left, Power right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._watts != right._watts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _watts.Equals(((Power) obj)._watts);
        }

        public override int GetHashCode()
        {
            return _watts.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(PowerUnit unit)
        {
            switch (unit)
            {
                case PowerUnit.Femtowatt:
                    return Femtowatts;
                case PowerUnit.Gigawatt:
                    return Gigawatts;
                case PowerUnit.Kilowatt:
                    return Kilowatts;
                case PowerUnit.Megawatt:
                    return Megawatts;
                case PowerUnit.Microwatt:
                    return Microwatts;
                case PowerUnit.Milliwatt:
                    return Milliwatts;
                case PowerUnit.Nanowatt:
                    return Nanowatts;
                case PowerUnit.Petawatt:
                    return Petawatts;
                case PowerUnit.Picowatt:
                    return Picowatts;
                case PowerUnit.Terawatt:
                    return Terawatts;
                case PowerUnit.Watt:
                    return Watts;

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
        public static Power Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = @"[\d., "                        // allows digits, dots, commas, and spaces in the number by default
                         + numFormat.NumberGroupSeparator   // adds provided (or current) culture's group separator
                         + numFormat.NumberDecimalSeparator // adds provided (or current) culture's decimal separator
                         + @"]*\d";                         // ensures quantity ends in digit
            var regexString = @"(?<value>[-+]?" + numRegex + @"(?:[eE][-+]?\d+)?)" // capture Quantity input
                            + @"\s?"                                               // ignore whitespace (allows both "1kg", "1 kg")
                            + @"(?<unit>\S+)";                                     // capture Unit (non-whitespace) input

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
                PowerUnit unit = ParseUnit(unitString, formatProvider);
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
        public static PowerUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<PowerUnit>(str.Trim());

            if (unit == PowerUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized PowerUnit.");
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
            return ToString(PowerUnit.Watt);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(PowerUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(PowerUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
