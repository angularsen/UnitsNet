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
    ///     In mathematics, a ratio is a relationship between two numbers of the same kind (e.g., objects, persons, students, spoonfuls, units of whatever identical dimension), usually expressed as "a to b" or a:b, sometimes expressed arithmetically as a dimensionless quotient of the two that explicitly indicates how many times the first number contains the second (not necessarily an integer).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Ratio
#else
    public partial struct Ratio : IComparable, IComparable<Ratio>
#endif
    {
        /// <summary>
        ///     Base unit of Ratio.
        /// </summary>
        private readonly double _decimalFractions;

#if WINDOWS_UWP
        public Ratio() : this(0)
        {
        }
#endif

        public Ratio(double decimalfractions)
        {
            _decimalFractions = Convert.ToDouble(decimalfractions);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Ratio(long decimalfractions)
        {
            _decimalFractions = Convert.ToDouble(decimalfractions);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Ratio(decimal decimalfractions)
        {
            _decimalFractions = Convert.ToDouble(decimalfractions);
        }

        #region Properties

        public static RatioUnit BaseUnit
        {
            get { return RatioUnit.DecimalFraction; }
        }

        /// <summary>
        ///     Get Ratio in DecimalFractions.
        /// </summary>
        public double DecimalFractions
        {
            get { return _decimalFractions; }
        }

        /// <summary>
        ///     Get Ratio in PartsPerBillion.
        /// </summary>
        public double PartsPerBillion
        {
            get { return _decimalFractions*1e9; }
        }

        /// <summary>
        ///     Get Ratio in PartsPerMillion.
        /// </summary>
        public double PartsPerMillion
        {
            get { return _decimalFractions*1e6; }
        }

        /// <summary>
        ///     Get Ratio in PartsPerThousand.
        /// </summary>
        public double PartsPerThousand
        {
            get { return _decimalFractions*1e3; }
        }

        /// <summary>
        ///     Get Ratio in PartsPerTrillion.
        /// </summary>
        public double PartsPerTrillion
        {
            get { return _decimalFractions*1e12; }
        }

        /// <summary>
        ///     Get Ratio in Percent.
        /// </summary>
        public double Percent
        {
            get { return _decimalFractions*1e2; }
        }

        #endregion

        #region Static

        public static Ratio Zero
        {
            get { return new Ratio(); }
        }

        /// <summary>
        ///     Get Ratio from DecimalFractions.
        /// </summary>
        public static Ratio FromDecimalFractions(double decimalfractions)
        {
            return new Ratio(decimalfractions);
        }

        /// <summary>
        ///     Get Ratio from PartsPerBillion.
        /// </summary>
        public static Ratio FromPartsPerBillion(double partsperbillion)
        {
            return new Ratio(partsperbillion/1e9);
        }

        /// <summary>
        ///     Get Ratio from PartsPerMillion.
        /// </summary>
        public static Ratio FromPartsPerMillion(double partspermillion)
        {
            return new Ratio(partspermillion/1e6);
        }

        /// <summary>
        ///     Get Ratio from PartsPerThousand.
        /// </summary>
        public static Ratio FromPartsPerThousand(double partsperthousand)
        {
            return new Ratio(partsperthousand/1e3);
        }

        /// <summary>
        ///     Get Ratio from PartsPerTrillion.
        /// </summary>
        public static Ratio FromPartsPerTrillion(double partspertrillion)
        {
            return new Ratio(partspertrillion/1e12);
        }

        /// <summary>
        ///     Get Ratio from Percent.
        /// </summary>
        public static Ratio FromPercent(double percent)
        {
            return new Ratio(percent/1e2);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Ratio from nullable DecimalFractions.
        /// </summary>
        public static Ratio? FromDecimalFractions(double? decimalfractions)
        {
            if (decimalfractions.HasValue)
            {
                return FromDecimalFractions(decimalfractions.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Ratio from nullable PartsPerBillion.
        /// </summary>
        public static Ratio? FromPartsPerBillion(double? partsperbillion)
        {
            if (partsperbillion.HasValue)
            {
                return FromPartsPerBillion(partsperbillion.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Ratio from nullable PartsPerMillion.
        /// </summary>
        public static Ratio? FromPartsPerMillion(double? partspermillion)
        {
            if (partspermillion.HasValue)
            {
                return FromPartsPerMillion(partspermillion.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Ratio from nullable PartsPerThousand.
        /// </summary>
        public static Ratio? FromPartsPerThousand(double? partsperthousand)
        {
            if (partsperthousand.HasValue)
            {
                return FromPartsPerThousand(partsperthousand.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Ratio from nullable PartsPerTrillion.
        /// </summary>
        public static Ratio? FromPartsPerTrillion(double? partspertrillion)
        {
            if (partspertrillion.HasValue)
            {
                return FromPartsPerTrillion(partspertrillion.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Ratio from nullable Percent.
        /// </summary>
        public static Ratio? FromPercent(double? percent)
        {
            if (percent.HasValue)
            {
                return FromPercent(percent.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RatioUnit" /> to <see cref="Ratio" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Ratio unit value.</returns>
        public static Ratio From(double val, RatioUnit fromUnit)
        {
            switch (fromUnit)
            {
                case RatioUnit.DecimalFraction:
                    return FromDecimalFractions(val);
                case RatioUnit.PartPerBillion:
                    return FromPartsPerBillion(val);
                case RatioUnit.PartPerMillion:
                    return FromPartsPerMillion(val);
                case RatioUnit.PartPerThousand:
                    return FromPartsPerThousand(val);
                case RatioUnit.PartPerTrillion:
                    return FromPartsPerTrillion(val);
                case RatioUnit.Percent:
                    return FromPercent(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RatioUnit" /> to <see cref="Ratio" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Ratio unit value.</returns>
        public static Ratio? From(double? value, RatioUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case RatioUnit.DecimalFraction:
                    return FromDecimalFractions(value.Value);
                case RatioUnit.PartPerBillion:
                    return FromPartsPerBillion(value.Value);
                case RatioUnit.PartPerMillion:
                    return FromPartsPerMillion(value.Value);
                case RatioUnit.PartPerThousand:
                    return FromPartsPerThousand(value.Value);
                case RatioUnit.PartPerTrillion:
                    return FromPartsPerTrillion(value.Value);
                case RatioUnit.Percent:
                    return FromPercent(value.Value);

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
        public static string GetAbbreviation(RatioUnit unit)
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
        public static string GetAbbreviation(RatioUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Ratio operator -(Ratio right)
        {
            return new Ratio(-right._decimalFractions);
        }

        public static Ratio operator +(Ratio left, Ratio right)
        {
            return new Ratio(left._decimalFractions + right._decimalFractions);
        }

        public static Ratio operator -(Ratio left, Ratio right)
        {
            return new Ratio(left._decimalFractions - right._decimalFractions);
        }

        public static Ratio operator *(double left, Ratio right)
        {
            return new Ratio(left*right._decimalFractions);
        }

        public static Ratio operator *(Ratio left, double right)
        {
            return new Ratio(left._decimalFractions*(double)right);
        }

        public static Ratio operator /(Ratio left, double right)
        {
            return new Ratio(left._decimalFractions/(double)right);
        }

        public static double operator /(Ratio left, Ratio right)
        {
            return Convert.ToDouble(left._decimalFractions/right._decimalFractions);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Ratio)) throw new ArgumentException("Expected type Ratio.", "obj");
            return CompareTo((Ratio) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Ratio other)
        {
            return _decimalFractions.CompareTo(other._decimalFractions);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Ratio left, Ratio right)
        {
            return left._decimalFractions <= right._decimalFractions;
        }

        public static bool operator >=(Ratio left, Ratio right)
        {
            return left._decimalFractions >= right._decimalFractions;
        }

        public static bool operator <(Ratio left, Ratio right)
        {
            return left._decimalFractions < right._decimalFractions;
        }

        public static bool operator >(Ratio left, Ratio right)
        {
            return left._decimalFractions > right._decimalFractions;
        }

        public static bool operator ==(Ratio left, Ratio right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decimalFractions == right._decimalFractions;
        }

        public static bool operator !=(Ratio left, Ratio right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decimalFractions != right._decimalFractions;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _decimalFractions.Equals(((Ratio) obj)._decimalFractions);
        }

        public override int GetHashCode()
        {
            return _decimalFractions.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(RatioUnit unit)
        {
            switch (unit)
            {
                case RatioUnit.DecimalFraction:
                    return DecimalFractions;
                case RatioUnit.PartPerBillion:
                    return PartsPerBillion;
                case RatioUnit.PartPerMillion:
                    return PartsPerMillion;
                case RatioUnit.PartPerThousand:
                    return PartsPerThousand;
                case RatioUnit.PartPerTrillion:
                    return PartsPerTrillion;
                case RatioUnit.Percent:
                    return Percent;

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
        public static Ratio Parse(string str)
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
        public static Ratio Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Ratio.FromDecimalFractions(x.DecimalFractions + y.DecimalFractions));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Ratio> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Ratio>();

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
                    RatioUnit unit = ParseUnit(unitString, formatProvider);
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
        public static RatioUnit ParseUnit(string str)
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
        public static RatioUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static RatioUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<RatioUnit>(str.Trim());

            if (unit == RatioUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized RatioUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is DecimalFraction
        /// </summary>
        public static RatioUnit ToStringDefaultUnit { get; set; } = RatioUnit.DecimalFraction;

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
        public string ToString(RatioUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(RatioUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(RatioUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(RatioUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
