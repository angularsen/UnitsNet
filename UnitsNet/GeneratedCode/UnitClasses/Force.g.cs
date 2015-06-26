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
    ///     In physics, a force is any influence that causes an object to undergo a certain change, either concerning its movement, direction, or geometrical construction. In other words, a force can cause an object with mass to change its velocity (which includes to begin moving from a state of rest), i.e., to accelerate, or a flexible object to deform, or both. Force can also be described by intuitive concepts such as a push or a pull. A force has both magnitude and direction, making it a vector quantity. It is measured in the SI unit of newtons and represented by the symbol F.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Force : IComparable, IComparable<Force>
    {
        /// <summary>
        ///     Base unit of Force.
        /// </summary>
        private readonly double _newtons;

        public Force(double newtons) : this()
        {
            _newtons = newtons;
        }

        #region Properties

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


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ForceUnit" /> to <see cref="Force" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Force unit value.</returns>
        public static Force From(double value, ForceUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ForceUnit.Dyn:
                    return FromDyne(value);
                case ForceUnit.KilogramForce:
                    return FromKilogramsForce(value);
                case ForceUnit.Kilonewton:
                    return FromKilonewtons(value);
                case ForceUnit.KiloPond:
                    return FromKiloPonds(value);
                case ForceUnit.Newton:
                    return FromNewtons(value);
                case ForceUnit.Poundal:
                    return FromPoundals(value);
                case ForceUnit.PoundForce:
                    return FromPoundsForce(value);
                case ForceUnit.TonneForce:
                    return FromTonnesForce(value);

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
        public static string GetAbbreviation(ForceUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

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

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Force)) throw new ArgumentException("Expected type Force.", "obj");
            return CompareTo((Force) obj);
        }

        public int CompareTo(Force other)
        {
            return _newtons.CompareTo(other._newtons);
        }

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
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in" 
        /// </exception>
        public static Force Parse(string str, IFormatProvider formatProvider = null)
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
        public static ForceUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<ForceUnit>(str.Trim());

            if (unit == ForceUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ForceUnit.");
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
            return ToString(ForceUnit.Newton);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(ForceUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(ForceUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
