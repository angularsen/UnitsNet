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
    ///     In physics, a force is any influence that causes an object to undergo a certain change, either concerning its movement, direction, or geometrical construction. In other words, a force can cause an object with mass to change its velocity (which includes to begin moving from a state of rest), i.e., to accelerate, or a flexible object to deform, or both. Force can also be described by intuitive concepts such as a push or a pull. A force has both magnitude and direction, making it a vector quantity. It is measured in the SI unit of newtons and represented by the symbol F.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Force
#else
    public partial struct Force : IComparable, IComparable<Force>
#endif
    {
        /// <summary>
        ///     Base unit of Force.
        /// </summary>
        private readonly double _newtons;

#if WINDOWS_UWP
        public Force() : this(0)
        {
        }
#endif

        public Force(double newtons)
        {
            _newtons = Convert.ToDouble(newtons);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Force(long newtons)
        {
            _newtons = Convert.ToDouble(newtons);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Force(decimal newtons)
        {
            _newtons = Convert.ToDouble(newtons);
        }

        #region Properties

        public static ForceUnit BaseUnit
        {
            get { return ForceUnit.Newton; }
        }

        /// <summary>
        ///     Get Force in Dyne.
        /// </summary>
        public double Dyne
        {
            get { return _newtons*1e5; }
        }

        /// <summary>
        ///     Get Force in KilogramsForce.
        /// </summary>
        public double KilogramsForce
        {
            get { return _newtons/Constants.Gravity; }
        }

        /// <summary>
        ///     Get Force in Kilonewtons.
        /// </summary>
        public double Kilonewtons
        {
            get { return (_newtons) / 1e3d; }
        }

        /// <summary>
        ///     Get Force in KiloPonds.
        /// </summary>
        public double KiloPonds
        {
            get { return _newtons/Constants.Gravity; }
        }

        /// <summary>
        ///     Get Force in Newtons.
        /// </summary>
        public double Newtons
        {
            get { return _newtons; }
        }

        /// <summary>
        ///     Get Force in Poundals.
        /// </summary>
        public double Poundals
        {
            get { return _newtons/0.13825502798973041652092282466083; }
        }

        /// <summary>
        ///     Get Force in PoundsForce.
        /// </summary>
        public double PoundsForce
        {
            get { return _newtons/4.4482216152605095551842641431421; }
        }

        /// <summary>
        ///     Get Force in TonnesForce.
        /// </summary>
        public double TonnesForce
        {
            get { return _newtons/Constants.Gravity/1000; }
        }

        #endregion

        #region Static

        public static Force Zero
        {
            get { return new Force(); }
        }

        /// <summary>
        ///     Get Force from Dyne.
        /// </summary>
        public static Force FromDyne(double dyne)
        {
            return new Force(dyne/1e5);
        }

        /// <summary>
        ///     Get Force from KilogramsForce.
        /// </summary>
        public static Force FromKilogramsForce(double kilogramsforce)
        {
            return new Force(kilogramsforce*Constants.Gravity);
        }

        /// <summary>
        ///     Get Force from Kilonewtons.
        /// </summary>
        public static Force FromKilonewtons(double kilonewtons)
        {
            return new Force((kilonewtons) * 1e3d);
        }

        /// <summary>
        ///     Get Force from KiloPonds.
        /// </summary>
        public static Force FromKiloPonds(double kiloponds)
        {
            return new Force(kiloponds*Constants.Gravity);
        }

        /// <summary>
        ///     Get Force from Newtons.
        /// </summary>
        public static Force FromNewtons(double newtons)
        {
            return new Force(newtons);
        }

        /// <summary>
        ///     Get Force from Poundals.
        /// </summary>
        public static Force FromPoundals(double poundals)
        {
            return new Force(poundals*0.13825502798973041652092282466083);
        }

        /// <summary>
        ///     Get Force from PoundsForce.
        /// </summary>
        public static Force FromPoundsForce(double poundsforce)
        {
            return new Force(poundsforce*4.4482216152605095551842641431421);
        }

        /// <summary>
        ///     Get Force from TonnesForce.
        /// </summary>
        public static Force FromTonnesForce(double tonnesforce)
        {
            return new Force(tonnesforce*Constants.Gravity*1000);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Force from nullable Dyne.
        /// </summary>
        public static Force? FromDyne(double? dyne)
        {
            if (dyne.HasValue)
            {
                return FromDyne(dyne.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Force from nullable KilogramsForce.
        /// </summary>
        public static Force? FromKilogramsForce(double? kilogramsforce)
        {
            if (kilogramsforce.HasValue)
            {
                return FromKilogramsForce(kilogramsforce.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Force from nullable Kilonewtons.
        /// </summary>
        public static Force? FromKilonewtons(double? kilonewtons)
        {
            if (kilonewtons.HasValue)
            {
                return FromKilonewtons(kilonewtons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Force from nullable KiloPonds.
        /// </summary>
        public static Force? FromKiloPonds(double? kiloponds)
        {
            if (kiloponds.HasValue)
            {
                return FromKiloPonds(kiloponds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Force from nullable Newtons.
        /// </summary>
        public static Force? FromNewtons(double? newtons)
        {
            if (newtons.HasValue)
            {
                return FromNewtons(newtons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Force from nullable Poundals.
        /// </summary>
        public static Force? FromPoundals(double? poundals)
        {
            if (poundals.HasValue)
            {
                return FromPoundals(poundals.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Force from nullable PoundsForce.
        /// </summary>
        public static Force? FromPoundsForce(double? poundsforce)
        {
            if (poundsforce.HasValue)
            {
                return FromPoundsForce(poundsforce.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Force from nullable TonnesForce.
        /// </summary>
        public static Force? FromTonnesForce(double? tonnesforce)
        {
            if (tonnesforce.HasValue)
            {
                return FromTonnesForce(tonnesforce.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ForceUnit" /> to <see cref="Force" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Force unit value.</returns>
        public static Force From(double val, ForceUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ForceUnit.Dyn:
                    return FromDyne(val);
                case ForceUnit.KilogramForce:
                    return FromKilogramsForce(val);
                case ForceUnit.Kilonewton:
                    return FromKilonewtons(val);
                case ForceUnit.KiloPond:
                    return FromKiloPonds(val);
                case ForceUnit.Newton:
                    return FromNewtons(val);
                case ForceUnit.Poundal:
                    return FromPoundals(val);
                case ForceUnit.PoundForce:
                    return FromPoundsForce(val);
                case ForceUnit.TonneForce:
                    return FromTonnesForce(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ForceUnit" /> to <see cref="Force" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Force unit value.</returns>
        public static Force? From(double? value, ForceUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case ForceUnit.Dyn:
                    return FromDyne(value.Value);
                case ForceUnit.KilogramForce:
                    return FromKilogramsForce(value.Value);
                case ForceUnit.Kilonewton:
                    return FromKilonewtons(value.Value);
                case ForceUnit.KiloPond:
                    return FromKiloPonds(value.Value);
                case ForceUnit.Newton:
                    return FromNewtons(value.Value);
                case ForceUnit.Poundal:
                    return FromPoundals(value.Value);
                case ForceUnit.PoundForce:
                    return FromPoundsForce(value.Value);
                case ForceUnit.TonneForce:
                    return FromTonnesForce(value.Value);

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
        public static string GetAbbreviation(ForceUnit unit)
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
        public static string GetAbbreviation(ForceUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Force operator -(Force right)
        {
            return new Force(-right._newtons);
        }

        public static Force operator +(Force left, Force right)
        {
            return new Force(left._newtons + right._newtons);
        }

        public static Force operator -(Force left, Force right)
        {
            return new Force(left._newtons - right._newtons);
        }

        public static Force operator *(double left, Force right)
        {
            return new Force(left*right._newtons);
        }

        public static Force operator *(Force left, double right)
        {
            return new Force(left._newtons*(double)right);
        }

        public static Force operator /(Force left, double right)
        {
            return new Force(left._newtons/(double)right);
        }

        public static double operator /(Force left, Force right)
        {
            return Convert.ToDouble(left._newtons/right._newtons);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Force)) throw new ArgumentException("Expected type Force.", "obj");
            return CompareTo((Force) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Force other)
        {
            return _newtons.CompareTo(other._newtons);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Force left, Force right)
        {
            return left._newtons <= right._newtons;
        }

        public static bool operator >=(Force left, Force right)
        {
            return left._newtons >= right._newtons;
        }

        public static bool operator <(Force left, Force right)
        {
            return left._newtons < right._newtons;
        }

        public static bool operator >(Force left, Force right)
        {
            return left._newtons > right._newtons;
        }

        public static bool operator ==(Force left, Force right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtons == right._newtons;
        }

        public static bool operator !=(Force left, Force right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtons != right._newtons;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _newtons.Equals(((Force) obj)._newtons);
        }

        public override int GetHashCode()
        {
            return _newtons.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(ForceUnit unit)
        {
            switch (unit)
            {
                case ForceUnit.Dyn:
                    return Dyne;
                case ForceUnit.KilogramForce:
                    return KilogramsForce;
                case ForceUnit.Kilonewton:
                    return Kilonewtons;
                case ForceUnit.KiloPond:
                    return KiloPonds;
                case ForceUnit.Newton:
                    return Newtons;
                case ForceUnit.Poundal:
                    return Poundals;
                case ForceUnit.PoundForce:
                    return PoundsForce;
                case ForceUnit.TonneForce:
                    return TonnesForce;

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
        public static Force Parse(string str)
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
        public static Force Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Force.FromNewtons(x.Newtons + y.Newtons));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Force> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Force>();

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
                    ForceUnit unit = ParseUnit(unitString, formatProvider);
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
        public static ForceUnit ParseUnit(string str)
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
        public static ForceUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static ForceUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<ForceUnit>(str.Trim());

            if (unit == ForceUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ForceUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Newton
        /// </summary>
        public static ForceUnit ToStringDefaultUnit { get; set; } = ForceUnit.Newton;

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
        public string ToString(ForceUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(ForceUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(ForceUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(ForceUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
