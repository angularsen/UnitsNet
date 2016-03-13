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
    ///     A temperature is a numerical measure of hot or cold. Its measurement is by detection of heat radiation or particle velocity or kinetic energy, or by the bulk behavior of a thermometric material. It may be calibrated in any of various temperature scales, Celsius, Fahrenheit, Kelvin, etc. The fundamental physical definition of temperature is provided by thermodynamics.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Temperature
#else
    public partial struct Temperature : IComparable, IComparable<Temperature>
#endif
    {
        /// <summary>
        ///     Base unit of Temperature.
        /// </summary>
        private readonly double _kelvins;

#if WINDOWS_UWP
        public Temperature() : this(0)
        {
        }
#endif

        public Temperature(double kelvins)
        {
            _kelvins = Convert.ToDouble(kelvins);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Temperature(long kelvins)
        {
            _kelvins = Convert.ToDouble(kelvins);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Temperature(decimal kelvins)
        {
            _kelvins = Convert.ToDouble(kelvins);
        }

        #region Properties

        public static TemperatureUnit BaseUnit
        {
            get { return TemperatureUnit.Kelvin; }
        }

        /// <summary>
        ///     Get Temperature in DegreesCelsius.
        /// </summary>
        public double DegreesCelsius
        {
            get { return _kelvins - 273.15; }
        }

        /// <summary>
        ///     Get Temperature in DegreesDelisle.
        /// </summary>
        public double DegreesDelisle
        {
            get { return (_kelvins - 373.15)*-3/2; }
        }

        /// <summary>
        ///     Get Temperature in DegreesFahrenheit.
        /// </summary>
        public double DegreesFahrenheit
        {
            get { return (_kelvins - 459.67*5/9)*9/5; }
        }

        /// <summary>
        ///     Get Temperature in DegreesNewton.
        /// </summary>
        public double DegreesNewton
        {
            get { return (_kelvins - 273.15)*33/100; }
        }

        /// <summary>
        ///     Get Temperature in DegreesRankine.
        /// </summary>
        public double DegreesRankine
        {
            get { return _kelvins*9/5; }
        }

        /// <summary>
        ///     Get Temperature in DegreesReaumur.
        /// </summary>
        public double DegreesReaumur
        {
            get { return (_kelvins - 273.15)*4/5; }
        }

        /// <summary>
        ///     Get Temperature in DegreesRoemer.
        /// </summary>
        public double DegreesRoemer
        {
            get { return (_kelvins - (273.15 - 7.5*40d/21))*21/40; }
        }

        /// <summary>
        ///     Get Temperature in Kelvins.
        /// </summary>
        public double Kelvins
        {
            get { return _kelvins; }
        }

        #endregion

        #region Static

        public static Temperature Zero
        {
            get { return new Temperature(); }
        }

        /// <summary>
        ///     Get Temperature from DegreesCelsius.
        /// </summary>
        public static Temperature FromDegreesCelsius(double degreescelsius)
        {
            return new Temperature(degreescelsius + 273.15);
        }

        /// <summary>
        ///     Get Temperature from DegreesDelisle.
        /// </summary>
        public static Temperature FromDegreesDelisle(double degreesdelisle)
        {
            return new Temperature(degreesdelisle*-2/3 + 373.15);
        }

        /// <summary>
        ///     Get Temperature from DegreesFahrenheit.
        /// </summary>
        public static Temperature FromDegreesFahrenheit(double degreesfahrenheit)
        {
            return new Temperature(degreesfahrenheit*5/9 + 459.67*5/9);
        }

        /// <summary>
        ///     Get Temperature from DegreesNewton.
        /// </summary>
        public static Temperature FromDegreesNewton(double degreesnewton)
        {
            return new Temperature(degreesnewton*100/33 + 273.15);
        }

        /// <summary>
        ///     Get Temperature from DegreesRankine.
        /// </summary>
        public static Temperature FromDegreesRankine(double degreesrankine)
        {
            return new Temperature(degreesrankine*5/9);
        }

        /// <summary>
        ///     Get Temperature from DegreesReaumur.
        /// </summary>
        public static Temperature FromDegreesReaumur(double degreesreaumur)
        {
            return new Temperature(degreesreaumur*5/4 + 273.15);
        }

        /// <summary>
        ///     Get Temperature from DegreesRoemer.
        /// </summary>
        public static Temperature FromDegreesRoemer(double degreesroemer)
        {
            return new Temperature(degreesroemer*40/21 + 273.15 - 7.5*40d/21);
        }

        /// <summary>
        ///     Get Temperature from Kelvins.
        /// </summary>
        public static Temperature FromKelvins(double kelvins)
        {
            return new Temperature(kelvins);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Temperature from nullable DegreesCelsius.
        /// </summary>
        public static Temperature? FromDegreesCelsius(double? degreescelsius)
        {
            if (degreescelsius.HasValue)
            {
                return FromDegreesCelsius(degreescelsius.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Temperature from nullable DegreesDelisle.
        /// </summary>
        public static Temperature? FromDegreesDelisle(double? degreesdelisle)
        {
            if (degreesdelisle.HasValue)
            {
                return FromDegreesDelisle(degreesdelisle.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Temperature from nullable DegreesFahrenheit.
        /// </summary>
        public static Temperature? FromDegreesFahrenheit(double? degreesfahrenheit)
        {
            if (degreesfahrenheit.HasValue)
            {
                return FromDegreesFahrenheit(degreesfahrenheit.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Temperature from nullable DegreesNewton.
        /// </summary>
        public static Temperature? FromDegreesNewton(double? degreesnewton)
        {
            if (degreesnewton.HasValue)
            {
                return FromDegreesNewton(degreesnewton.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Temperature from nullable DegreesRankine.
        /// </summary>
        public static Temperature? FromDegreesRankine(double? degreesrankine)
        {
            if (degreesrankine.HasValue)
            {
                return FromDegreesRankine(degreesrankine.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Temperature from nullable DegreesReaumur.
        /// </summary>
        public static Temperature? FromDegreesReaumur(double? degreesreaumur)
        {
            if (degreesreaumur.HasValue)
            {
                return FromDegreesReaumur(degreesreaumur.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Temperature from nullable DegreesRoemer.
        /// </summary>
        public static Temperature? FromDegreesRoemer(double? degreesroemer)
        {
            if (degreesroemer.HasValue)
            {
                return FromDegreesRoemer(degreesroemer.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Temperature from nullable Kelvins.
        /// </summary>
        public static Temperature? FromKelvins(double? kelvins)
        {
            if (kelvins.HasValue)
            {
                return FromKelvins(kelvins.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TemperatureUnit" /> to <see cref="Temperature" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Temperature unit value.</returns>
        public static Temperature From(double val, TemperatureUnit fromUnit)
        {
            switch (fromUnit)
            {
                case TemperatureUnit.DegreeCelsius:
                    return FromDegreesCelsius(val);
                case TemperatureUnit.DegreeDelisle:
                    return FromDegreesDelisle(val);
                case TemperatureUnit.DegreeFahrenheit:
                    return FromDegreesFahrenheit(val);
                case TemperatureUnit.DegreeNewton:
                    return FromDegreesNewton(val);
                case TemperatureUnit.DegreeRankine:
                    return FromDegreesRankine(val);
                case TemperatureUnit.DegreeReaumur:
                    return FromDegreesReaumur(val);
                case TemperatureUnit.DegreeRoemer:
                    return FromDegreesRoemer(val);
                case TemperatureUnit.Kelvin:
                    return FromKelvins(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TemperatureUnit" /> to <see cref="Temperature" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Temperature unit value.</returns>
        public static Temperature? From(double? value, TemperatureUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case TemperatureUnit.DegreeCelsius:
                    return FromDegreesCelsius(value.Value);
                case TemperatureUnit.DegreeDelisle:
                    return FromDegreesDelisle(value.Value);
                case TemperatureUnit.DegreeFahrenheit:
                    return FromDegreesFahrenheit(value.Value);
                case TemperatureUnit.DegreeNewton:
                    return FromDegreesNewton(value.Value);
                case TemperatureUnit.DegreeRankine:
                    return FromDegreesRankine(value.Value);
                case TemperatureUnit.DegreeReaumur:
                    return FromDegreesReaumur(value.Value);
                case TemperatureUnit.DegreeRoemer:
                    return FromDegreesRoemer(value.Value);
                case TemperatureUnit.Kelvin:
                    return FromKelvins(value.Value);

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
        public static string GetAbbreviation(TemperatureUnit unit)
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
        public static string GetAbbreviation(TemperatureUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Temperature operator -(Temperature right)
        {
            return new Temperature(-right._kelvins);
        }

        public static Temperature operator +(Temperature left, Temperature right)
        {
            return new Temperature(left._kelvins + right._kelvins);
        }

        public static Temperature operator -(Temperature left, Temperature right)
        {
            return new Temperature(left._kelvins - right._kelvins);
        }

        public static Temperature operator *(double left, Temperature right)
        {
            return new Temperature(left*right._kelvins);
        }

        public static Temperature operator *(Temperature left, double right)
        {
            return new Temperature(left._kelvins*(double)right);
        }

        public static Temperature operator /(Temperature left, double right)
        {
            return new Temperature(left._kelvins/(double)right);
        }

        public static double operator /(Temperature left, Temperature right)
        {
            return Convert.ToDouble(left._kelvins/right._kelvins);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Temperature)) throw new ArgumentException("Expected type Temperature.", "obj");
            return CompareTo((Temperature) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Temperature other)
        {
            return _kelvins.CompareTo(other._kelvins);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Temperature left, Temperature right)
        {
            return left._kelvins <= right._kelvins;
        }

        public static bool operator >=(Temperature left, Temperature right)
        {
            return left._kelvins >= right._kelvins;
        }

        public static bool operator <(Temperature left, Temperature right)
        {
            return left._kelvins < right._kelvins;
        }

        public static bool operator >(Temperature left, Temperature right)
        {
            return left._kelvins > right._kelvins;
        }

        public static bool operator ==(Temperature left, Temperature right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kelvins == right._kelvins;
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kelvins != right._kelvins;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _kelvins.Equals(((Temperature) obj)._kelvins);
        }

        public override int GetHashCode()
        {
            return _kelvins.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(TemperatureUnit unit)
        {
            switch (unit)
            {
                case TemperatureUnit.DegreeCelsius:
                    return DegreesCelsius;
                case TemperatureUnit.DegreeDelisle:
                    return DegreesDelisle;
                case TemperatureUnit.DegreeFahrenheit:
                    return DegreesFahrenheit;
                case TemperatureUnit.DegreeNewton:
                    return DegreesNewton;
                case TemperatureUnit.DegreeRankine:
                    return DegreesRankine;
                case TemperatureUnit.DegreeReaumur:
                    return DegreesReaumur;
                case TemperatureUnit.DegreeRoemer:
                    return DegreesRoemer;
                case TemperatureUnit.Kelvin:
                    return Kelvins;

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
        public static Temperature Parse(string str)
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
        public static Temperature Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Temperature.FromKelvins(x.Kelvins + y.Kelvins));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Temperature> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Temperature>();

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
                    TemperatureUnit unit = ParseUnit(unitString, formatProvider);
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
        public static TemperatureUnit ParseUnit(string str)
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
        public static TemperatureUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static TemperatureUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<TemperatureUnit>(str.Trim());

            if (unit == TemperatureUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized TemperatureUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Kelvin
        /// </summary>
        public static TemperatureUnit ToStringDefaultUnit { get; set; } = TemperatureUnit.Kelvin;

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
        public string ToString(TemperatureUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(TemperatureUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(TemperatureUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(TemperatureUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
    }
}
