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
    ///     Force change rate is the ratio of the force change to the time during which the change occurred (value of force changes per unit time).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class ForceChangeRate
#else
    public partial struct ForceChangeRate : IComparable, IComparable<ForceChangeRate>
#endif
    {
        /// <summary>
        ///     Base unit of ForceChangeRate.
        /// </summary>
        private readonly double _newtonsPerSecond;

#if WINDOWS_UWP
        public ForceChangeRate() : this(0)
        {
        }
#endif

        public ForceChangeRate(double newtonspersecond)
        {
            _newtonsPerSecond = Convert.ToDouble(newtonspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        ForceChangeRate(long newtonspersecond)
        {
            _newtonsPerSecond = Convert.ToDouble(newtonspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        ForceChangeRate(decimal newtonspersecond)
        {
            _newtonsPerSecond = Convert.ToDouble(newtonspersecond);
        }

        #region Properties

        public static ForceChangeRateUnit BaseUnit
        {
            get { return ForceChangeRateUnit.NewtonPerSecond; }
        }

        /// <summary>
        ///     Get ForceChangeRate in CentinewtonsPerSecond.
        /// </summary>
        public double CentinewtonsPerSecond
        {
            get { return (_newtonsPerSecond) / 1e-2d; }
        }

        /// <summary>
        ///     Get ForceChangeRate in DecinewtonsPerSecond.
        /// </summary>
        public double DecinewtonsPerSecond
        {
            get { return (_newtonsPerSecond) / 1e-1d; }
        }

        /// <summary>
        ///     Get ForceChangeRate in KilonewtonsPerSecond.
        /// </summary>
        public double KilonewtonsPerSecond
        {
            get { return (_newtonsPerSecond) / 1e3d; }
        }

        /// <summary>
        ///     Get ForceChangeRate in MicronewtonsPerSecond.
        /// </summary>
        public double MicronewtonsPerSecond
        {
            get { return (_newtonsPerSecond) / 1e-6d; }
        }

        /// <summary>
        ///     Get ForceChangeRate in MillinewtonsPerSecond.
        /// </summary>
        public double MillinewtonsPerSecond
        {
            get { return (_newtonsPerSecond) / 1e-3d; }
        }

        /// <summary>
        ///     Get ForceChangeRate in NanonewtonsPerSecond.
        /// </summary>
        public double NanonewtonsPerSecond
        {
            get { return (_newtonsPerSecond) / 1e-9d; }
        }

        /// <summary>
        ///     Get ForceChangeRate in NewtonsPerSecond.
        /// </summary>
        public double NewtonsPerSecond
        {
            get { return _newtonsPerSecond; }
        }

        #endregion

        #region Static

        public static ForceChangeRate Zero
        {
            get { return new ForceChangeRate(); }
        }

        /// <summary>
        ///     Get ForceChangeRate from CentinewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate FromCentinewtonsPerSecond(double centinewtonspersecond)
        {
            return new ForceChangeRate((centinewtonspersecond) * 1e-2d);
        }

        /// <summary>
        ///     Get ForceChangeRate from DecinewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate FromDecinewtonsPerSecond(double decinewtonspersecond)
        {
            return new ForceChangeRate((decinewtonspersecond) * 1e-1d);
        }

        /// <summary>
        ///     Get ForceChangeRate from KilonewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate FromKilonewtonsPerSecond(double kilonewtonspersecond)
        {
            return new ForceChangeRate((kilonewtonspersecond) * 1e3d);
        }

        /// <summary>
        ///     Get ForceChangeRate from MicronewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate FromMicronewtonsPerSecond(double micronewtonspersecond)
        {
            return new ForceChangeRate((micronewtonspersecond) * 1e-6d);
        }

        /// <summary>
        ///     Get ForceChangeRate from MillinewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate FromMillinewtonsPerSecond(double millinewtonspersecond)
        {
            return new ForceChangeRate((millinewtonspersecond) * 1e-3d);
        }

        /// <summary>
        ///     Get ForceChangeRate from NanonewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate FromNanonewtonsPerSecond(double nanonewtonspersecond)
        {
            return new ForceChangeRate((nanonewtonspersecond) * 1e-9d);
        }

        /// <summary>
        ///     Get ForceChangeRate from NewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate FromNewtonsPerSecond(double newtonspersecond)
        {
            return new ForceChangeRate(newtonspersecond);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable ForceChangeRate from nullable CentinewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate? FromCentinewtonsPerSecond(double? centinewtonspersecond)
        {
            if (centinewtonspersecond.HasValue)
            {
                return FromCentinewtonsPerSecond(centinewtonspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ForceChangeRate from nullable DecinewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate? FromDecinewtonsPerSecond(double? decinewtonspersecond)
        {
            if (decinewtonspersecond.HasValue)
            {
                return FromDecinewtonsPerSecond(decinewtonspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ForceChangeRate from nullable KilonewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate? FromKilonewtonsPerSecond(double? kilonewtonspersecond)
        {
            if (kilonewtonspersecond.HasValue)
            {
                return FromKilonewtonsPerSecond(kilonewtonspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ForceChangeRate from nullable MicronewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate? FromMicronewtonsPerSecond(double? micronewtonspersecond)
        {
            if (micronewtonspersecond.HasValue)
            {
                return FromMicronewtonsPerSecond(micronewtonspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ForceChangeRate from nullable MillinewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate? FromMillinewtonsPerSecond(double? millinewtonspersecond)
        {
            if (millinewtonspersecond.HasValue)
            {
                return FromMillinewtonsPerSecond(millinewtonspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ForceChangeRate from nullable NanonewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate? FromNanonewtonsPerSecond(double? nanonewtonspersecond)
        {
            if (nanonewtonspersecond.HasValue)
            {
                return FromNanonewtonsPerSecond(nanonewtonspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ForceChangeRate from nullable NewtonsPerSecond.
        /// </summary>
        public static ForceChangeRate? FromNewtonsPerSecond(double? newtonspersecond)
        {
            if (newtonspersecond.HasValue)
            {
                return FromNewtonsPerSecond(newtonspersecond.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ForceChangeRateUnit" /> to <see cref="ForceChangeRate" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ForceChangeRate unit value.</returns>
        public static ForceChangeRate From(double val, ForceChangeRateUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ForceChangeRateUnit.CentinewtonPerSecond:
                    return FromCentinewtonsPerSecond(val);
                case ForceChangeRateUnit.DecinewtonPerSecond:
                    return FromDecinewtonsPerSecond(val);
                case ForceChangeRateUnit.KilonewtonPerSecond:
                    return FromKilonewtonsPerSecond(val);
                case ForceChangeRateUnit.MicronewtonPerSecond:
                    return FromMicronewtonsPerSecond(val);
                case ForceChangeRateUnit.MillinewtonPerSecond:
                    return FromMillinewtonsPerSecond(val);
                case ForceChangeRateUnit.NanonewtonPerSecond:
                    return FromNanonewtonsPerSecond(val);
                case ForceChangeRateUnit.NewtonPerSecond:
                    return FromNewtonsPerSecond(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ForceChangeRateUnit" /> to <see cref="ForceChangeRate" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ForceChangeRate unit value.</returns>
        public static ForceChangeRate? From(double? value, ForceChangeRateUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case ForceChangeRateUnit.CentinewtonPerSecond:
                    return FromCentinewtonsPerSecond(value.Value);
                case ForceChangeRateUnit.DecinewtonPerSecond:
                    return FromDecinewtonsPerSecond(value.Value);
                case ForceChangeRateUnit.KilonewtonPerSecond:
                    return FromKilonewtonsPerSecond(value.Value);
                case ForceChangeRateUnit.MicronewtonPerSecond:
                    return FromMicronewtonsPerSecond(value.Value);
                case ForceChangeRateUnit.MillinewtonPerSecond:
                    return FromMillinewtonsPerSecond(value.Value);
                case ForceChangeRateUnit.NanonewtonPerSecond:
                    return FromNanonewtonsPerSecond(value.Value);
                case ForceChangeRateUnit.NewtonPerSecond:
                    return FromNewtonsPerSecond(value.Value);

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
        public static string GetAbbreviation(ForceChangeRateUnit unit)
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
        public static string GetAbbreviation(ForceChangeRateUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static ForceChangeRate operator -(ForceChangeRate right)
        {
            return new ForceChangeRate(-right._newtonsPerSecond);
        }

        public static ForceChangeRate operator +(ForceChangeRate left, ForceChangeRate right)
        {
            return new ForceChangeRate(left._newtonsPerSecond + right._newtonsPerSecond);
        }

        public static ForceChangeRate operator -(ForceChangeRate left, ForceChangeRate right)
        {
            return new ForceChangeRate(left._newtonsPerSecond - right._newtonsPerSecond);
        }

        public static ForceChangeRate operator *(double left, ForceChangeRate right)
        {
            return new ForceChangeRate(left*right._newtonsPerSecond);
        }

        public static ForceChangeRate operator *(ForceChangeRate left, double right)
        {
            return new ForceChangeRate(left._newtonsPerSecond*(double)right);
        }

        public static ForceChangeRate operator /(ForceChangeRate left, double right)
        {
            return new ForceChangeRate(left._newtonsPerSecond/(double)right);
        }

        public static double operator /(ForceChangeRate left, ForceChangeRate right)
        {
            return Convert.ToDouble(left._newtonsPerSecond/right._newtonsPerSecond);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is ForceChangeRate)) throw new ArgumentException("Expected type ForceChangeRate.", "obj");
            return CompareTo((ForceChangeRate) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(ForceChangeRate other)
        {
            return _newtonsPerSecond.CompareTo(other._newtonsPerSecond);
        }

#if !WINDOWS_UWP
        public static bool operator <=(ForceChangeRate left, ForceChangeRate right)
        {
            return left._newtonsPerSecond <= right._newtonsPerSecond;
        }

        public static bool operator >=(ForceChangeRate left, ForceChangeRate right)
        {
            return left._newtonsPerSecond >= right._newtonsPerSecond;
        }

        public static bool operator <(ForceChangeRate left, ForceChangeRate right)
        {
            return left._newtonsPerSecond < right._newtonsPerSecond;
        }

        public static bool operator >(ForceChangeRate left, ForceChangeRate right)
        {
            return left._newtonsPerSecond > right._newtonsPerSecond;
        }

        public static bool operator ==(ForceChangeRate left, ForceChangeRate right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonsPerSecond == right._newtonsPerSecond;
        }

        public static bool operator !=(ForceChangeRate left, ForceChangeRate right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonsPerSecond != right._newtonsPerSecond;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _newtonsPerSecond.Equals(((ForceChangeRate) obj)._newtonsPerSecond);
        }

        public override int GetHashCode()
        {
            return _newtonsPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(ForceChangeRateUnit unit)
        {
            switch (unit)
            {
                case ForceChangeRateUnit.CentinewtonPerSecond:
                    return CentinewtonsPerSecond;
                case ForceChangeRateUnit.DecinewtonPerSecond:
                    return DecinewtonsPerSecond;
                case ForceChangeRateUnit.KilonewtonPerSecond:
                    return KilonewtonsPerSecond;
                case ForceChangeRateUnit.MicronewtonPerSecond:
                    return MicronewtonsPerSecond;
                case ForceChangeRateUnit.MillinewtonPerSecond:
                    return MillinewtonsPerSecond;
                case ForceChangeRateUnit.NanonewtonPerSecond:
                    return NanonewtonsPerSecond;
                case ForceChangeRateUnit.NewtonPerSecond:
                    return NewtonsPerSecond;

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
        public static ForceChangeRate Parse(string str)
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
        public static ForceChangeRate Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => ForceChangeRate.FromNewtonsPerSecond(x.NewtonsPerSecond + y.NewtonsPerSecond));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<ForceChangeRate> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<ForceChangeRate>();

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
                    ForceChangeRateUnit unit = ParseUnit(unitString, formatProvider);
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
        public static ForceChangeRateUnit ParseUnit(string str)
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
        public static ForceChangeRateUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static ForceChangeRateUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<ForceChangeRateUnit>(str.Trim());

            if (unit == ForceChangeRateUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ForceChangeRateUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is NewtonPerSecond
        /// </summary>
        public static ForceChangeRateUnit ToStringDefaultUnit { get; set; } = ForceChangeRateUnit.NewtonPerSecond;

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
        public string ToString(ForceChangeRateUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(ForceChangeRateUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(ForceChangeRateUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(ForceChangeRateUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of ForceChangeRate
        /// </summary>
        public static ForceChangeRate MaxValue
        {
            get
            {
                return new ForceChangeRate(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of ForceChangeRate
        /// </summary>
        public static ForceChangeRate MinValue
        {
            get
            {
                return new ForceChangeRate(double.MinValue);
            }
        }
    }
}
