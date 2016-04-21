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
    ///     The SpecificEnergy
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class SpecificEnergy
#else
    public partial struct SpecificEnergy : IComparable, IComparable<SpecificEnergy>
#endif
    {
        /// <summary>
        ///     Base unit of SpecificEnergy.
        /// </summary>
        private readonly double _joulesPerKilogram;

#if WINDOWS_UWP
        public SpecificEnergy() : this(0)
        {
        }
#endif

        public SpecificEnergy(double joulesperkilogram)
        {
            _joulesPerKilogram = Convert.ToDouble(joulesperkilogram);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        SpecificEnergy(long joulesperkilogram)
        {
            _joulesPerKilogram = Convert.ToDouble(joulesperkilogram);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        SpecificEnergy(decimal joulesperkilogram)
        {
            _joulesPerKilogram = Convert.ToDouble(joulesperkilogram);
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

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable SpecificEnergy from nullable CaloriesPerGram.
        /// </summary>
        public static SpecificEnergy? FromCaloriesPerGram(double? caloriespergram)
        {
            if (caloriespergram.HasValue)
            {
                return FromCaloriesPerGram(caloriespergram.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificEnergy from nullable JoulesPerKilogram.
        /// </summary>
        public static SpecificEnergy? FromJoulesPerKilogram(double? joulesperkilogram)
        {
            if (joulesperkilogram.HasValue)
            {
                return FromJoulesPerKilogram(joulesperkilogram.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificEnergy from nullable KilocaloriesPerGram.
        /// </summary>
        public static SpecificEnergy? FromKilocaloriesPerGram(double? kilocaloriespergram)
        {
            if (kilocaloriespergram.HasValue)
            {
                return FromKilocaloriesPerGram(kilocaloriespergram.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificEnergy from nullable KilojoulesPerKilogram.
        /// </summary>
        public static SpecificEnergy? FromKilojoulesPerKilogram(double? kilojoulesperkilogram)
        {
            if (kilojoulesperkilogram.HasValue)
            {
                return FromKilojoulesPerKilogram(kilojoulesperkilogram.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificEnergy from nullable KilowattHoursPerKilogram.
        /// </summary>
        public static SpecificEnergy? FromKilowattHoursPerKilogram(double? kilowatthoursperkilogram)
        {
            if (kilowatthoursperkilogram.HasValue)
            {
                return FromKilowattHoursPerKilogram(kilowatthoursperkilogram.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificEnergy from nullable MegajoulesPerKilogram.
        /// </summary>
        public static SpecificEnergy? FromMegajoulesPerKilogram(double? megajoulesperkilogram)
        {
            if (megajoulesperkilogram.HasValue)
            {
                return FromMegajoulesPerKilogram(megajoulesperkilogram.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificEnergy from nullable MegawattHoursPerKilogram.
        /// </summary>
        public static SpecificEnergy? FromMegawattHoursPerKilogram(double? megawatthoursperkilogram)
        {
            if (megawatthoursperkilogram.HasValue)
            {
                return FromMegawattHoursPerKilogram(megawatthoursperkilogram.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificEnergy from nullable WattHoursPerKilogram.
        /// </summary>
        public static SpecificEnergy? FromWattHoursPerKilogram(double? watthoursperkilogram)
        {
            if (watthoursperkilogram.HasValue)
            {
                return FromWattHoursPerKilogram(watthoursperkilogram.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificEnergyUnit" /> to <see cref="SpecificEnergy" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificEnergy unit value.</returns>
        public static SpecificEnergy From(double val, SpecificEnergyUnit fromUnit)
        {
            switch (fromUnit)
            {
                case SpecificEnergyUnit.CaloriePerGram:
                    return FromCaloriesPerGram(val);
                case SpecificEnergyUnit.JoulePerKilogram:
                    return FromJoulesPerKilogram(val);
                case SpecificEnergyUnit.KilocaloriePerGram:
                    return FromKilocaloriesPerGram(val);
                case SpecificEnergyUnit.KilojoulePerKilogram:
                    return FromKilojoulesPerKilogram(val);
                case SpecificEnergyUnit.KilowattHourPerKilogram:
                    return FromKilowattHoursPerKilogram(val);
                case SpecificEnergyUnit.MegajoulePerKilogram:
                    return FromMegajoulesPerKilogram(val);
                case SpecificEnergyUnit.MegawattHourPerKilogram:
                    return FromMegawattHoursPerKilogram(val);
                case SpecificEnergyUnit.WattHourPerKilogram:
                    return FromWattHoursPerKilogram(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificEnergyUnit" /> to <see cref="SpecificEnergy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificEnergy unit value.</returns>
        public static SpecificEnergy? From(double? value, SpecificEnergyUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case SpecificEnergyUnit.CaloriePerGram:
                    return FromCaloriesPerGram(value.Value);
                case SpecificEnergyUnit.JoulePerKilogram:
                    return FromJoulesPerKilogram(value.Value);
                case SpecificEnergyUnit.KilocaloriePerGram:
                    return FromKilocaloriesPerGram(value.Value);
                case SpecificEnergyUnit.KilojoulePerKilogram:
                    return FromKilojoulesPerKilogram(value.Value);
                case SpecificEnergyUnit.KilowattHourPerKilogram:
                    return FromKilowattHoursPerKilogram(value.Value);
                case SpecificEnergyUnit.MegajoulePerKilogram:
                    return FromMegajoulesPerKilogram(value.Value);
                case SpecificEnergyUnit.MegawattHourPerKilogram:
                    return FromMegawattHoursPerKilogram(value.Value);
                case SpecificEnergyUnit.WattHourPerKilogram:
                    return FromWattHoursPerKilogram(value.Value);

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
        public static string GetAbbreviation(SpecificEnergyUnit unit)
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
        public static string GetAbbreviation(SpecificEnergyUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
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
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SpecificEnergy)) throw new ArgumentException("Expected type SpecificEnergy.", "obj");
            return CompareTo((SpecificEnergy) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(SpecificEnergy other)
        {
            return _joulesPerKilogram.CompareTo(other._joulesPerKilogram);
        }

#if !WINDOWS_UWP
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
#endif

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
        public static SpecificEnergy Parse(string str)
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
        public static SpecificEnergy Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => SpecificEnergy.FromJoulesPerKilogram(x.JoulesPerKilogram + y.JoulesPerKilogram));
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
        public static SpecificEnergyUnit ParseUnit(string str)
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
        public static SpecificEnergyUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static SpecificEnergyUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<SpecificEnergyUnit>(str.Trim());

            if (unit == SpecificEnergyUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized SpecificEnergyUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
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
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(SpecificEnergyUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(SpecificEnergyUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(SpecificEnergyUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(SpecificEnergyUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of SpecificEnergy
        /// </summary>
        public static SpecificEnergy MaxValue
        {
            get
            {
                return new SpecificEnergy(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of SpecificEnergy
        /// </summary>
        public static SpecificEnergy MinValue
        {
            get
            {
                return new SpecificEnergy(double.MinValue);
            }
        }
    }
}
