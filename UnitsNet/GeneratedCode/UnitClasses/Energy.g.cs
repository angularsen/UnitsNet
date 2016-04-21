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

#if WINDOWS_UWP
using Culture = System.String;
#else
using Culture = System.IFormatProvider;
#endif

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     The joule, symbol J, is a derived unit of energy, work, or amount of heat in the International System of Units. It is equal to the energy transferred (or work done) when applying a force of one newton through a distance of one metre (1 newton metre or N·m), or in passing an electric current of one ampere through a resistance of one ohm for one second. Many other units of energy are included. Please do not confuse this definition of the calorie with the one colloquially used by the food industry, the large calorie, which is equivalent to 1 kcal. Thermochemical definition of the calorie is used. For BTU, the IT definition is used.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Energy
#else
    public partial struct Energy : IComparable, IComparable<Energy>
#endif
    {
        /// <summary>
        ///     Base unit of Energy.
        /// </summary>
        private readonly double _joules;

#if WINDOWS_UWP
        public Energy() : this(0)
        {
        }
#endif

        public Energy(double joules)
        {
            _joules = Convert.ToDouble(joules);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Energy(long joules)
        {
            _joules = Convert.ToDouble(joules);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Energy(decimal joules)
        {
            _joules = Convert.ToDouble(joules);
        }

        #region Properties

        public static EnergyUnit BaseUnit
        {
            get { return EnergyUnit.Joule; }
        }

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

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Energy from nullable BritishThermalUnits.
        /// </summary>
        public static Energy? FromBritishThermalUnits(double? britishthermalunits)
        {
            if (britishthermalunits.HasValue)
            {
                return FromBritishThermalUnits(britishthermalunits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable Calories.
        /// </summary>
        public static Energy? FromCalories(double? calories)
        {
            if (calories.HasValue)
            {
                return FromCalories(calories.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable ElectronVolts.
        /// </summary>
        public static Energy? FromElectronVolts(double? electronvolts)
        {
            if (electronvolts.HasValue)
            {
                return FromElectronVolts(electronvolts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable Ergs.
        /// </summary>
        public static Energy? FromErgs(double? ergs)
        {
            if (ergs.HasValue)
            {
                return FromErgs(ergs.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable FootPounds.
        /// </summary>
        public static Energy? FromFootPounds(double? footpounds)
        {
            if (footpounds.HasValue)
            {
                return FromFootPounds(footpounds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable GigawattHours.
        /// </summary>
        public static Energy? FromGigawattHours(double? gigawatthours)
        {
            if (gigawatthours.HasValue)
            {
                return FromGigawattHours(gigawatthours.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable Joules.
        /// </summary>
        public static Energy? FromJoules(double? joules)
        {
            if (joules.HasValue)
            {
                return FromJoules(joules.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable Kilocalories.
        /// </summary>
        public static Energy? FromKilocalories(double? kilocalories)
        {
            if (kilocalories.HasValue)
            {
                return FromKilocalories(kilocalories.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable Kilojoules.
        /// </summary>
        public static Energy? FromKilojoules(double? kilojoules)
        {
            if (kilojoules.HasValue)
            {
                return FromKilojoules(kilojoules.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable KilowattHours.
        /// </summary>
        public static Energy? FromKilowattHours(double? kilowatthours)
        {
            if (kilowatthours.HasValue)
            {
                return FromKilowattHours(kilowatthours.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable Megajoules.
        /// </summary>
        public static Energy? FromMegajoules(double? megajoules)
        {
            if (megajoules.HasValue)
            {
                return FromMegajoules(megajoules.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable MegawattHours.
        /// </summary>
        public static Energy? FromMegawattHours(double? megawatthours)
        {
            if (megawatthours.HasValue)
            {
                return FromMegawattHours(megawatthours.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Energy from nullable WattHours.
        /// </summary>
        public static Energy? FromWattHours(double? watthours)
        {
            if (watthours.HasValue)
            {
                return FromWattHours(watthours.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="EnergyUnit" /> to <see cref="Energy" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Energy unit value.</returns>
        public static Energy From(double val, EnergyUnit fromUnit)
        {
            switch (fromUnit)
            {
                case EnergyUnit.BritishThermalUnit:
                    return FromBritishThermalUnits(val);
                case EnergyUnit.Calorie:
                    return FromCalories(val);
                case EnergyUnit.ElectronVolt:
                    return FromElectronVolts(val);
                case EnergyUnit.Erg:
                    return FromErgs(val);
                case EnergyUnit.FootPound:
                    return FromFootPounds(val);
                case EnergyUnit.GigawattHour:
                    return FromGigawattHours(val);
                case EnergyUnit.Joule:
                    return FromJoules(val);
                case EnergyUnit.Kilocalorie:
                    return FromKilocalories(val);
                case EnergyUnit.Kilojoule:
                    return FromKilojoules(val);
                case EnergyUnit.KilowattHour:
                    return FromKilowattHours(val);
                case EnergyUnit.Megajoule:
                    return FromMegajoules(val);
                case EnergyUnit.MegawattHour:
                    return FromMegawattHours(val);
                case EnergyUnit.WattHour:
                    return FromWattHours(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="EnergyUnit" /> to <see cref="Energy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Energy unit value.</returns>
        public static Energy? From(double? value, EnergyUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case EnergyUnit.BritishThermalUnit:
                    return FromBritishThermalUnits(value.Value);
                case EnergyUnit.Calorie:
                    return FromCalories(value.Value);
                case EnergyUnit.ElectronVolt:
                    return FromElectronVolts(value.Value);
                case EnergyUnit.Erg:
                    return FromErgs(value.Value);
                case EnergyUnit.FootPound:
                    return FromFootPounds(value.Value);
                case EnergyUnit.GigawattHour:
                    return FromGigawattHours(value.Value);
                case EnergyUnit.Joule:
                    return FromJoules(value.Value);
                case EnergyUnit.Kilocalorie:
                    return FromKilocalories(value.Value);
                case EnergyUnit.Kilojoule:
                    return FromKilojoules(value.Value);
                case EnergyUnit.KilowattHour:
                    return FromKilowattHours(value.Value);
                case EnergyUnit.Megajoule:
                    return FromMegajoules(value.Value);
                case EnergyUnit.MegawattHour:
                    return FromMegawattHours(value.Value);
                case EnergyUnit.WattHour:
                    return FromWattHours(value.Value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
#endif

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(EnergyUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(EnergyUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
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
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Energy)) throw new ArgumentException("Expected type Energy.", "obj");
            return CompareTo((Energy) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Energy other)
        {
            return _joules.CompareTo(other._joules);
        }

#if !WINDOWS_UWP
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
#endif

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
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
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
        public static Energy Parse(string str)
        {
            return Parse(str, null);
        }

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="culture">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
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
        public static Energy Parse(string str, [CanBeNull] Culture culture)
        {
            if (str == null) throw new ArgumentNullException("str");

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
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
            return quantities.Aggregate((x, y) => Energy.FromJoules(x.Joules + y.Joules));
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
                catch(AmbiguousUnitParseException)
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
        public static EnergyUnit ParseUnit(string str)
        {
            return ParseUnit(str, (IFormatProvider)null);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static EnergyUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            return ParseUnit(str, cultureName == null ? null : new CultureInfo(cultureName));
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static EnergyUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<EnergyUnit>(str.Trim());

            if (unit == EnergyUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized EnergyUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Joule
        /// </summary>
        public static EnergyUnit ToStringDefaultUnit { get; set; } = EnergyUnit.Joule;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(ToStringDefaultUnit);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(EnergyUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(EnergyUnit unit, [CanBeNull] Culture culture)
        {
            return ToString(unit, culture, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(EnergyUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
        {
            double value = As(unit);
            string format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(unit, culture, format);
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
        public string ToString(EnergyUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
            [NotNull] params object[] args)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            double value = As(unit);
            object[] formatArgs = UnitFormatter.GetFormatArgs(unit, value, formatProvider, args);
            return string.Format(formatProvider, format, formatArgs);
        }

        /// <summary>
        /// Represents the largest possible value of Energy
        /// </summary>
        public static Energy MaxValue
        {
            get
            {
                return new Energy(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of Energy
        /// </summary>
        public static Energy MinValue
        {
            get
            {
                return new Energy(double.MinValue);
            }
        }
    }
}
