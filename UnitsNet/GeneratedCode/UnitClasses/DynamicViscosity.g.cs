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
    ///     The dynamic (shear) viscosity of a fluid expresses its resistance to shearing flows, where adjacent layers move parallel to each other with different speeds
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class DynamicViscosity
#else
    public partial struct DynamicViscosity : IComparable, IComparable<DynamicViscosity>
#endif
    {
        /// <summary>
        ///     Base unit of DynamicViscosity.
        /// </summary>
        private readonly double _newtonSecondsPerMeterSquared;

#if WINDOWS_UWP
        public DynamicViscosity() : this(0)
        {
        }
#endif

        public DynamicViscosity(double newtonsecondspermetersquared)
        {
            _newtonSecondsPerMeterSquared = Convert.ToDouble(newtonsecondspermetersquared);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        DynamicViscosity(long newtonsecondspermetersquared)
        {
            _newtonSecondsPerMeterSquared = Convert.ToDouble(newtonsecondspermetersquared);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        DynamicViscosity(decimal newtonsecondspermetersquared)
        {
            _newtonSecondsPerMeterSquared = Convert.ToDouble(newtonsecondspermetersquared);
        }

        #region Properties

        public static DynamicViscosityUnit BaseUnit
        {
            get { return DynamicViscosityUnit.NewtonSecondPerMeterSquared; }
        }

        /// <summary>
        ///     Get DynamicViscosity in Centipoise.
        /// </summary>
        public double Centipoise
        {
            get { return (_newtonSecondsPerMeterSquared*10) / 1e-2d; }
        }

        /// <summary>
        ///     Get DynamicViscosity in MillipascalSeconds.
        /// </summary>
        public double MillipascalSeconds
        {
            get { return (_newtonSecondsPerMeterSquared) / 1e-3d; }
        }

        /// <summary>
        ///     Get DynamicViscosity in NewtonSecondsPerMeterSquared.
        /// </summary>
        public double NewtonSecondsPerMeterSquared
        {
            get { return _newtonSecondsPerMeterSquared; }
        }

        /// <summary>
        ///     Get DynamicViscosity in PascalSeconds.
        /// </summary>
        public double PascalSeconds
        {
            get { return _newtonSecondsPerMeterSquared; }
        }

        /// <summary>
        ///     Get DynamicViscosity in Poise.
        /// </summary>
        public double Poise
        {
            get { return _newtonSecondsPerMeterSquared*10; }
        }

        #endregion

        #region Static

        public static DynamicViscosity Zero
        {
            get { return new DynamicViscosity(); }
        }

        /// <summary>
        ///     Get DynamicViscosity from Centipoise.
        /// </summary>
        public static DynamicViscosity FromCentipoise(double centipoise)
        {
            return new DynamicViscosity((centipoise/10) * 1e-2d);
        }

        /// <summary>
        ///     Get DynamicViscosity from MillipascalSeconds.
        /// </summary>
        public static DynamicViscosity FromMillipascalSeconds(double millipascalseconds)
        {
            return new DynamicViscosity((millipascalseconds) * 1e-3d);
        }

        /// <summary>
        ///     Get DynamicViscosity from NewtonSecondsPerMeterSquared.
        /// </summary>
        public static DynamicViscosity FromNewtonSecondsPerMeterSquared(double newtonsecondspermetersquared)
        {
            return new DynamicViscosity(newtonsecondspermetersquared);
        }

        /// <summary>
        ///     Get DynamicViscosity from PascalSeconds.
        /// </summary>
        public static DynamicViscosity FromPascalSeconds(double pascalseconds)
        {
            return new DynamicViscosity(pascalseconds);
        }

        /// <summary>
        ///     Get DynamicViscosity from Poise.
        /// </summary>
        public static DynamicViscosity FromPoise(double poise)
        {
            return new DynamicViscosity(poise/10);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable DynamicViscosity from nullable Centipoise.
        /// </summary>
        public static DynamicViscosity? FromCentipoise(double? centipoise)
        {
            if (centipoise.HasValue)
            {
                return FromCentipoise(centipoise.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable DynamicViscosity from nullable MillipascalSeconds.
        /// </summary>
        public static DynamicViscosity? FromMillipascalSeconds(double? millipascalseconds)
        {
            if (millipascalseconds.HasValue)
            {
                return FromMillipascalSeconds(millipascalseconds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable DynamicViscosity from nullable NewtonSecondsPerMeterSquared.
        /// </summary>
        public static DynamicViscosity? FromNewtonSecondsPerMeterSquared(double? newtonsecondspermetersquared)
        {
            if (newtonsecondspermetersquared.HasValue)
            {
                return FromNewtonSecondsPerMeterSquared(newtonsecondspermetersquared.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable DynamicViscosity from nullable PascalSeconds.
        /// </summary>
        public static DynamicViscosity? FromPascalSeconds(double? pascalseconds)
        {
            if (pascalseconds.HasValue)
            {
                return FromPascalSeconds(pascalseconds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable DynamicViscosity from nullable Poise.
        /// </summary>
        public static DynamicViscosity? FromPoise(double? poise)
        {
            if (poise.HasValue)
            {
                return FromPoise(poise.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="DynamicViscosityUnit" /> to <see cref="DynamicViscosity" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>DynamicViscosity unit value.</returns>
        public static DynamicViscosity From(double val, DynamicViscosityUnit fromUnit)
        {
            switch (fromUnit)
            {
                case DynamicViscosityUnit.Centipoise:
                    return FromCentipoise(val);
                case DynamicViscosityUnit.MillipascalSecond:
                    return FromMillipascalSeconds(val);
                case DynamicViscosityUnit.NewtonSecondPerMeterSquared:
                    return FromNewtonSecondsPerMeterSquared(val);
                case DynamicViscosityUnit.PascalSecond:
                    return FromPascalSeconds(val);
                case DynamicViscosityUnit.Poise:
                    return FromPoise(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="DynamicViscosityUnit" /> to <see cref="DynamicViscosity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>DynamicViscosity unit value.</returns>
        public static DynamicViscosity? From(double? value, DynamicViscosityUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case DynamicViscosityUnit.Centipoise:
                    return FromCentipoise(value.Value);
                case DynamicViscosityUnit.MillipascalSecond:
                    return FromMillipascalSeconds(value.Value);
                case DynamicViscosityUnit.NewtonSecondPerMeterSquared:
                    return FromNewtonSecondsPerMeterSquared(value.Value);
                case DynamicViscosityUnit.PascalSecond:
                    return FromPascalSeconds(value.Value);
                case DynamicViscosityUnit.Poise:
                    return FromPoise(value.Value);

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
        public static string GetAbbreviation(DynamicViscosityUnit unit)
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
        public static string GetAbbreviation(DynamicViscosityUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static DynamicViscosity operator -(DynamicViscosity right)
        {
            return new DynamicViscosity(-right._newtonSecondsPerMeterSquared);
        }

        public static DynamicViscosity operator +(DynamicViscosity left, DynamicViscosity right)
        {
            return new DynamicViscosity(left._newtonSecondsPerMeterSquared + right._newtonSecondsPerMeterSquared);
        }

        public static DynamicViscosity operator -(DynamicViscosity left, DynamicViscosity right)
        {
            return new DynamicViscosity(left._newtonSecondsPerMeterSquared - right._newtonSecondsPerMeterSquared);
        }

        public static DynamicViscosity operator *(double left, DynamicViscosity right)
        {
            return new DynamicViscosity(left*right._newtonSecondsPerMeterSquared);
        }

        public static DynamicViscosity operator *(DynamicViscosity left, double right)
        {
            return new DynamicViscosity(left._newtonSecondsPerMeterSquared*(double)right);
        }

        public static DynamicViscosity operator /(DynamicViscosity left, double right)
        {
            return new DynamicViscosity(left._newtonSecondsPerMeterSquared/(double)right);
        }

        public static double operator /(DynamicViscosity left, DynamicViscosity right)
        {
            return Convert.ToDouble(left._newtonSecondsPerMeterSquared/right._newtonSecondsPerMeterSquared);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is DynamicViscosity)) throw new ArgumentException("Expected type DynamicViscosity.", "obj");
            return CompareTo((DynamicViscosity) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(DynamicViscosity other)
        {
            return _newtonSecondsPerMeterSquared.CompareTo(other._newtonSecondsPerMeterSquared);
        }

#if !WINDOWS_UWP
        public static bool operator <=(DynamicViscosity left, DynamicViscosity right)
        {
            return left._newtonSecondsPerMeterSquared <= right._newtonSecondsPerMeterSquared;
        }

        public static bool operator >=(DynamicViscosity left, DynamicViscosity right)
        {
            return left._newtonSecondsPerMeterSquared >= right._newtonSecondsPerMeterSquared;
        }

        public static bool operator <(DynamicViscosity left, DynamicViscosity right)
        {
            return left._newtonSecondsPerMeterSquared < right._newtonSecondsPerMeterSquared;
        }

        public static bool operator >(DynamicViscosity left, DynamicViscosity right)
        {
            return left._newtonSecondsPerMeterSquared > right._newtonSecondsPerMeterSquared;
        }

        public static bool operator ==(DynamicViscosity left, DynamicViscosity right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonSecondsPerMeterSquared == right._newtonSecondsPerMeterSquared;
        }

        public static bool operator !=(DynamicViscosity left, DynamicViscosity right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonSecondsPerMeterSquared != right._newtonSecondsPerMeterSquared;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _newtonSecondsPerMeterSquared.Equals(((DynamicViscosity) obj)._newtonSecondsPerMeterSquared);
        }

        public override int GetHashCode()
        {
            return _newtonSecondsPerMeterSquared.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(DynamicViscosityUnit unit)
        {
            switch (unit)
            {
                case DynamicViscosityUnit.Centipoise:
                    return Centipoise;
                case DynamicViscosityUnit.MillipascalSecond:
                    return MillipascalSeconds;
                case DynamicViscosityUnit.NewtonSecondPerMeterSquared:
                    return NewtonSecondsPerMeterSquared;
                case DynamicViscosityUnit.PascalSecond:
                    return PascalSeconds;
                case DynamicViscosityUnit.Poise:
                    return Poise;

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
        public static DynamicViscosity Parse(string str)
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
        public static DynamicViscosity Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => DynamicViscosity.FromNewtonSecondsPerMeterSquared(x.NewtonSecondsPerMeterSquared + y.NewtonSecondsPerMeterSquared));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<DynamicViscosity> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<DynamicViscosity>();

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
                    DynamicViscosityUnit unit = ParseUnit(unitString, formatProvider);
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
        public static DynamicViscosityUnit ParseUnit(string str)
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
        public static DynamicViscosityUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static DynamicViscosityUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<DynamicViscosityUnit>(str.Trim());

            if (unit == DynamicViscosityUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized DynamicViscosityUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is NewtonSecondPerMeterSquared
        /// </summary>
        public static DynamicViscosityUnit ToStringDefaultUnit { get; set; } = DynamicViscosityUnit.NewtonSecondPerMeterSquared;

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
        public string ToString(DynamicViscosityUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(DynamicViscosityUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(DynamicViscosityUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(DynamicViscosityUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of DynamicViscosity
        /// </summary>
        public static DynamicViscosity MaxValue
        {
            get
            {
                return new DynamicViscosity(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of DynamicViscosity
        /// </summary>
        public static DynamicViscosity MinValue
        {
            get
            {
                return new DynamicViscosity(double.MinValue);
            }
        }
    }
}
