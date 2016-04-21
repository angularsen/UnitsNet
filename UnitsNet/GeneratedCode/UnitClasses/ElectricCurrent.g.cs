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
    ///     An electric current is a flow of electric charge. In electric circuits this charge is often carried by moving electrons in a wire. It can also be carried by ions in an electrolyte, or by both ions and electrons such as in a plasma.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class ElectricCurrent
#else
    public partial struct ElectricCurrent : IComparable, IComparable<ElectricCurrent>
#endif
    {
        /// <summary>
        ///     Base unit of ElectricCurrent.
        /// </summary>
        private readonly double _amperes;

#if WINDOWS_UWP
        public ElectricCurrent() : this(0)
        {
        }
#endif

        public ElectricCurrent(double amperes)
        {
            _amperes = Convert.ToDouble(amperes);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        ElectricCurrent(long amperes)
        {
            _amperes = Convert.ToDouble(amperes);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        ElectricCurrent(decimal amperes)
        {
            _amperes = Convert.ToDouble(amperes);
        }

        #region Properties

        public static ElectricCurrentUnit BaseUnit
        {
            get { return ElectricCurrentUnit.Ampere; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Amperes.
        /// </summary>
        public double Amperes
        {
            get { return _amperes; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Kiloamperes.
        /// </summary>
        public double Kiloamperes
        {
            get { return (_amperes) / 1e3d; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Megaamperes.
        /// </summary>
        public double Megaamperes
        {
            get { return (_amperes) / 1e6d; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Microamperes.
        /// </summary>
        public double Microamperes
        {
            get { return (_amperes) / 1e-6d; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Milliamperes.
        /// </summary>
        public double Milliamperes
        {
            get { return (_amperes) / 1e-3d; }
        }

        /// <summary>
        ///     Get ElectricCurrent in Nanoamperes.
        /// </summary>
        public double Nanoamperes
        {
            get { return (_amperes) / 1e-9d; }
        }

        #endregion

        #region Static

        public static ElectricCurrent Zero
        {
            get { return new ElectricCurrent(); }
        }

        /// <summary>
        ///     Get ElectricCurrent from Amperes.
        /// </summary>
        public static ElectricCurrent FromAmperes(double amperes)
        {
            return new ElectricCurrent(amperes);
        }

        /// <summary>
        ///     Get ElectricCurrent from Kiloamperes.
        /// </summary>
        public static ElectricCurrent FromKiloamperes(double kiloamperes)
        {
            return new ElectricCurrent((kiloamperes) * 1e3d);
        }

        /// <summary>
        ///     Get ElectricCurrent from Megaamperes.
        /// </summary>
        public static ElectricCurrent FromMegaamperes(double megaamperes)
        {
            return new ElectricCurrent((megaamperes) * 1e6d);
        }

        /// <summary>
        ///     Get ElectricCurrent from Microamperes.
        /// </summary>
        public static ElectricCurrent FromMicroamperes(double microamperes)
        {
            return new ElectricCurrent((microamperes) * 1e-6d);
        }

        /// <summary>
        ///     Get ElectricCurrent from Milliamperes.
        /// </summary>
        public static ElectricCurrent FromMilliamperes(double milliamperes)
        {
            return new ElectricCurrent((milliamperes) * 1e-3d);
        }

        /// <summary>
        ///     Get ElectricCurrent from Nanoamperes.
        /// </summary>
        public static ElectricCurrent FromNanoamperes(double nanoamperes)
        {
            return new ElectricCurrent((nanoamperes) * 1e-9d);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable ElectricCurrent from nullable Amperes.
        /// </summary>
        public static ElectricCurrent? FromAmperes(double? amperes)
        {
            if (amperes.HasValue)
            {
                return FromAmperes(amperes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ElectricCurrent from nullable Kiloamperes.
        /// </summary>
        public static ElectricCurrent? FromKiloamperes(double? kiloamperes)
        {
            if (kiloamperes.HasValue)
            {
                return FromKiloamperes(kiloamperes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ElectricCurrent from nullable Megaamperes.
        /// </summary>
        public static ElectricCurrent? FromMegaamperes(double? megaamperes)
        {
            if (megaamperes.HasValue)
            {
                return FromMegaamperes(megaamperes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ElectricCurrent from nullable Microamperes.
        /// </summary>
        public static ElectricCurrent? FromMicroamperes(double? microamperes)
        {
            if (microamperes.HasValue)
            {
                return FromMicroamperes(microamperes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ElectricCurrent from nullable Milliamperes.
        /// </summary>
        public static ElectricCurrent? FromMilliamperes(double? milliamperes)
        {
            if (milliamperes.HasValue)
            {
                return FromMilliamperes(milliamperes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable ElectricCurrent from nullable Nanoamperes.
        /// </summary>
        public static ElectricCurrent? FromNanoamperes(double? nanoamperes)
        {
            if (nanoamperes.HasValue)
            {
                return FromNanoamperes(nanoamperes.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricCurrentUnit" /> to <see cref="ElectricCurrent" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricCurrent unit value.</returns>
        public static ElectricCurrent From(double val, ElectricCurrentUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ElectricCurrentUnit.Ampere:
                    return FromAmperes(val);
                case ElectricCurrentUnit.Kiloampere:
                    return FromKiloamperes(val);
                case ElectricCurrentUnit.Megaampere:
                    return FromMegaamperes(val);
                case ElectricCurrentUnit.Microampere:
                    return FromMicroamperes(val);
                case ElectricCurrentUnit.Milliampere:
                    return FromMilliamperes(val);
                case ElectricCurrentUnit.Nanoampere:
                    return FromNanoamperes(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricCurrentUnit" /> to <see cref="ElectricCurrent" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricCurrent unit value.</returns>
        public static ElectricCurrent? From(double? value, ElectricCurrentUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case ElectricCurrentUnit.Ampere:
                    return FromAmperes(value.Value);
                case ElectricCurrentUnit.Kiloampere:
                    return FromKiloamperes(value.Value);
                case ElectricCurrentUnit.Megaampere:
                    return FromMegaamperes(value.Value);
                case ElectricCurrentUnit.Microampere:
                    return FromMicroamperes(value.Value);
                case ElectricCurrentUnit.Milliampere:
                    return FromMilliamperes(value.Value);
                case ElectricCurrentUnit.Nanoampere:
                    return FromNanoamperes(value.Value);

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
        public static string GetAbbreviation(ElectricCurrentUnit unit)
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
        public static string GetAbbreviation(ElectricCurrentUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static ElectricCurrent operator -(ElectricCurrent right)
        {
            return new ElectricCurrent(-right._amperes);
        }

        public static ElectricCurrent operator +(ElectricCurrent left, ElectricCurrent right)
        {
            return new ElectricCurrent(left._amperes + right._amperes);
        }

        public static ElectricCurrent operator -(ElectricCurrent left, ElectricCurrent right)
        {
            return new ElectricCurrent(left._amperes - right._amperes);
        }

        public static ElectricCurrent operator *(double left, ElectricCurrent right)
        {
            return new ElectricCurrent(left*right._amperes);
        }

        public static ElectricCurrent operator *(ElectricCurrent left, double right)
        {
            return new ElectricCurrent(left._amperes*(double)right);
        }

        public static ElectricCurrent operator /(ElectricCurrent left, double right)
        {
            return new ElectricCurrent(left._amperes/(double)right);
        }

        public static double operator /(ElectricCurrent left, ElectricCurrent right)
        {
            return Convert.ToDouble(left._amperes/right._amperes);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is ElectricCurrent)) throw new ArgumentException("Expected type ElectricCurrent.", "obj");
            return CompareTo((ElectricCurrent) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(ElectricCurrent other)
        {
            return _amperes.CompareTo(other._amperes);
        }

#if !WINDOWS_UWP
        public static bool operator <=(ElectricCurrent left, ElectricCurrent right)
        {
            return left._amperes <= right._amperes;
        }

        public static bool operator >=(ElectricCurrent left, ElectricCurrent right)
        {
            return left._amperes >= right._amperes;
        }

        public static bool operator <(ElectricCurrent left, ElectricCurrent right)
        {
            return left._amperes < right._amperes;
        }

        public static bool operator >(ElectricCurrent left, ElectricCurrent right)
        {
            return left._amperes > right._amperes;
        }

        public static bool operator ==(ElectricCurrent left, ElectricCurrent right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._amperes == right._amperes;
        }

        public static bool operator !=(ElectricCurrent left, ElectricCurrent right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._amperes != right._amperes;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _amperes.Equals(((ElectricCurrent) obj)._amperes);
        }

        public override int GetHashCode()
        {
            return _amperes.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(ElectricCurrentUnit unit)
        {
            switch (unit)
            {
                case ElectricCurrentUnit.Ampere:
                    return Amperes;
                case ElectricCurrentUnit.Kiloampere:
                    return Kiloamperes;
                case ElectricCurrentUnit.Megaampere:
                    return Megaamperes;
                case ElectricCurrentUnit.Microampere:
                    return Microamperes;
                case ElectricCurrentUnit.Milliampere:
                    return Milliamperes;
                case ElectricCurrentUnit.Nanoampere:
                    return Nanoamperes;

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
        public static ElectricCurrent Parse(string str)
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
        public static ElectricCurrent Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => ElectricCurrent.FromAmperes(x.Amperes + y.Amperes));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<ElectricCurrent> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<ElectricCurrent>();

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
                    ElectricCurrentUnit unit = ParseUnit(unitString, formatProvider);
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
        public static ElectricCurrentUnit ParseUnit(string str)
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
        public static ElectricCurrentUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static ElectricCurrentUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<ElectricCurrentUnit>(str.Trim());

            if (unit == ElectricCurrentUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ElectricCurrentUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Ampere
        /// </summary>
        public static ElectricCurrentUnit ToStringDefaultUnit { get; set; } = ElectricCurrentUnit.Ampere;

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
        public string ToString(ElectricCurrentUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(ElectricCurrentUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(ElectricCurrentUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(ElectricCurrentUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of ElectricCurrent
        /// </summary>
        public static ElectricCurrent MaxValue
        {
            get
            {
                return new ElectricCurrent(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of ElectricCurrent
        /// </summary>
        public static ElectricCurrent MinValue
        {
            get
            {
                return new ElectricCurrent(double.MinValue);
            }
        }
    }
}
