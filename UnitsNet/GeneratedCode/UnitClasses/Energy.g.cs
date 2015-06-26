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
    ///     The joule, symbol J, is a derived unit of energy, work, or amount of heat in the International System of Units. It is equal to the energy transferred (or work done) when applying a force of one newton through a distance of one metre (1 newton metre or N·m), or in passing an electric current of one ampere through a resistance of one ohm for one second. Many other units of energy are included. Please do not confuse this definition of the calorie with the one colloquially used by the food industry, the large calorie, which is equivalent to 1 kcal. Thermochemical definition of the calorie is used. For BTU, the IT definition is used.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Energy : IComparable, IComparable<Energy>
    {
        /// <summary>
        ///     Base unit of Energy.
        /// </summary>
        private readonly double _joules;

        public Energy(double joules) : this()
        {
            _joules = joules;
        }

        #region Properties

        /// <summary>
        ///     Get Energy in BritishThermalUnits.
        /// </summary>
        public double BritishThermalUnits
        {
            get { return _joules/1055.05585262; }
        }

        /// <summary>
        ///     Get Energy in Calories.
        /// </summary>
        public double Calories
        {
            get { return _joules/4.184; }
        }

        /// <summary>
        ///     Get Energy in ElectronVolts.
        /// </summary>
        public double ElectronVolts
        {
            get { return _joules/1.602176565e-19; }
        }

        /// <summary>
        ///     Get Energy in Ergs.
        /// </summary>
        public double Ergs
        {
            get { return _joules/1e-7; }
        }

        /// <summary>
        ///     Get Energy in FootPounds.
        /// </summary>
        public double FootPounds
        {
            get { return _joules/1.355817948; }
        }

        /// <summary>
        ///     Get Energy in GigawattHours.
        /// </summary>
        public double GigawattHours
        {
            get { return (_joules/3600d) / 1e9d; }
        }

        /// <summary>
        ///     Get Energy in Joules.
        /// </summary>
        public double Joules
        {
            get { return _joules; }
        }

        /// <summary>
        ///     Get Energy in Kilocalories.
        /// </summary>
        public double Kilocalories
        {
            get { return (_joules/4.184) / 1e3d; }
        }

        /// <summary>
        ///     Get Energy in Kilojoules.
        /// </summary>
        public double Kilojoules
        {
            get { return (_joules) / 1e3d; }
        }

        /// <summary>
        ///     Get Energy in KilowattHours.
        /// </summary>
        public double KilowattHours
        {
            get { return (_joules/3600d) / 1e3d; }
        }

        /// <summary>
        ///     Get Energy in Megajoules.
        /// </summary>
        public double Megajoules
        {
            get { return (_joules) / 1e6d; }
        }

        /// <summary>
        ///     Get Energy in MegawattHours.
        /// </summary>
        public double MegawattHours
        {
            get { return (_joules/3600d) / 1e6d; }
        }

        /// <summary>
        ///     Get Energy in WattHours.
        /// </summary>
        public double WattHours
        {
            get { return _joules/3600d; }
        }

        #endregion

        #region Static 

        public static Energy Zero
        {
            get { return new Energy(); }
        }

        /// <summary>
        ///     Get Energy from BritishThermalUnits.
        /// </summary>
        public static Energy FromBritishThermalUnits(double britishthermalunits)
        {
            return new Energy(britishthermalunits*1055.05585262);
        }

        /// <summary>
        ///     Get Energy from Calories.
        /// </summary>
        public static Energy FromCalories(double calories)
        {
            return new Energy(calories*4.184);
        }

        /// <summary>
        ///     Get Energy from ElectronVolts.
        /// </summary>
        public static Energy FromElectronVolts(double electronvolts)
        {
            return new Energy(electronvolts*1.602176565e-19);
        }

        /// <summary>
        ///     Get Energy from Ergs.
        /// </summary>
        public static Energy FromErgs(double ergs)
        {
            return new Energy(ergs*1e-7);
        }

        /// <summary>
        ///     Get Energy from FootPounds.
        /// </summary>
        public static Energy FromFootPounds(double footpounds)
        {
            return new Energy(footpounds*1.355817948);
        }

        /// <summary>
        ///     Get Energy from GigawattHours.
        /// </summary>
        public static Energy FromGigawattHours(double gigawatthours)
        {
            return new Energy((gigawatthours*3600d) * 1e9d);
        }

        /// <summary>
        ///     Get Energy from Joules.
        /// </summary>
        public static Energy FromJoules(double joules)
        {
            return new Energy(joules);
        }

        /// <summary>
        ///     Get Energy from Kilocalories.
        /// </summary>
        public static Energy FromKilocalories(double kilocalories)
        {
            return new Energy((kilocalories*4.184) * 1e3d);
        }

        /// <summary>
        ///     Get Energy from Kilojoules.
        /// </summary>
        public static Energy FromKilojoules(double kilojoules)
        {
            return new Energy((kilojoules) * 1e3d);
        }

        /// <summary>
        ///     Get Energy from KilowattHours.
        /// </summary>
        public static Energy FromKilowattHours(double kilowatthours)
        {
            return new Energy((kilowatthours*3600d) * 1e3d);
        }

        /// <summary>
        ///     Get Energy from Megajoules.
        /// </summary>
        public static Energy FromMegajoules(double megajoules)
        {
            return new Energy((megajoules) * 1e6d);
        }

        /// <summary>
        ///     Get Energy from MegawattHours.
        /// </summary>
        public static Energy FromMegawattHours(double megawatthours)
        {
            return new Energy((megawatthours*3600d) * 1e6d);
        }

        /// <summary>
        ///     Get Energy from WattHours.
        /// </summary>
        public static Energy FromWattHours(double watthours)
        {
            return new Energy(watthours*3600d);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="EnergyUnit" /> to <see cref="Energy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Energy unit value.</returns>
        public static Energy From(double value, EnergyUnit fromUnit)
        {
            switch (fromUnit)
            {
                case EnergyUnit.BritishThermalUnit:
                    return FromBritishThermalUnits(value);
                case EnergyUnit.Calorie:
                    return FromCalories(value);
                case EnergyUnit.ElectronVolt:
                    return FromElectronVolts(value);
                case EnergyUnit.Erg:
                    return FromErgs(value);
                case EnergyUnit.FootPound:
                    return FromFootPounds(value);
                case EnergyUnit.GigawattHour:
                    return FromGigawattHours(value);
                case EnergyUnit.Joule:
                    return FromJoules(value);
                case EnergyUnit.Kilocalorie:
                    return FromKilocalories(value);
                case EnergyUnit.Kilojoule:
                    return FromKilojoules(value);
                case EnergyUnit.KilowattHour:
                    return FromKilowattHours(value);
                case EnergyUnit.Megajoule:
                    return FromMegajoules(value);
                case EnergyUnit.MegawattHour:
                    return FromMegawattHours(value);
                case EnergyUnit.WattHour:
                    return FromWattHours(value);

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
        public static string GetAbbreviation(EnergyUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Energy operator -(Energy right)
        {
            return new Energy(-right._joules);
        }

        public static Energy operator +(Energy left, Energy right)
        {
            return new Energy(left._joules + right._joules);
        }

        public static Energy operator -(Energy left, Energy right)
        {
            return new Energy(left._joules - right._joules);
        }

        public static Energy operator *(double left, Energy right)
        {
            return new Energy(left*right._joules);
        }

        public static Energy operator *(Energy left, double right)
        {
            return new Energy(left._joules*(double)right);
        }

        public static Energy operator /(Energy left, double right)
        {
            return new Energy(left._joules/(double)right);
        }

        public static double operator /(Energy left, Energy right)
        {
            return Convert.ToDouble(left._joules/right._joules);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Energy)) throw new ArgumentException("Expected type Energy.", "obj");
            return CompareTo((Energy) obj);
        }

        public int CompareTo(Energy other)
        {
            return _joules.CompareTo(other._joules);
        }

        public static bool operator <=(Energy left, Energy right)
        {
            return left._joules <= right._joules;
        }

        public static bool operator >=(Energy left, Energy right)
        {
            return left._joules >= right._joules;
        }

        public static bool operator <(Energy left, Energy right)
        {
            return left._joules < right._joules;
        }

        public static bool operator >(Energy left, Energy right)
        {
            return left._joules > right._joules;
        }

        public static bool operator ==(Energy left, Energy right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._joules == right._joules;
        }

        public static bool operator !=(Energy left, Energy right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._joules != right._joules;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _joules.Equals(((Energy) obj)._joules);
        }

        public override int GetHashCode()
        {
            return _joules.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(EnergyUnit unit)
        {
            switch (unit)
            {
                case EnergyUnit.BritishThermalUnit:
                    return BritishThermalUnits;
                case EnergyUnit.Calorie:
                    return Calories;
                case EnergyUnit.ElectronVolt:
                    return ElectronVolts;
                case EnergyUnit.Erg:
                    return Ergs;
                case EnergyUnit.FootPound:
                    return FootPounds;
                case EnergyUnit.GigawattHour:
                    return GigawattHours;
                case EnergyUnit.Joule:
                    return Joules;
                case EnergyUnit.Kilocalorie:
                    return Kilocalories;
                case EnergyUnit.Kilojoule:
                    return Kilojoules;
                case EnergyUnit.KilowattHour:
                    return KilowattHours;
                case EnergyUnit.Megajoule:
                    return Megajoules;
                case EnergyUnit.MegawattHour:
                    return MegawattHours;
                case EnergyUnit.WattHour:
                    return WattHours;

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
        public static Energy Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<Energy> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Energy>();

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
                    EnergyUnit unit = ParseUnit(unitString, formatProvider);
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
        public static EnergyUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<EnergyUnit>(str.Trim());

            if (unit == EnergyUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized EnergyUnit.");
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
            return ToString(EnergyUnit.Joule);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(EnergyUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(EnergyUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
