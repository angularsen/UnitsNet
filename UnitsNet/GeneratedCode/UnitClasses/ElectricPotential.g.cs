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
    ///     In classical electromagnetism, the electric potential (a scalar quantity denoted by Φ, ΦE or V and also called the electric field potential or the electrostatic potential) at a point is the amount of electric potential energy that a unitary point charge would have when located at that point.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct ElectricPotential : IComparable, IComparable<ElectricPotential>
    {
        /// <summary>
        ///     Base unit of ElectricPotential.
        /// </summary>
        private readonly double _volts;

        public ElectricPotential(double volts) : this()
        {
            _volts = volts;
        }

        #region Properties

        /// <summary>
        ///     Get ElectricPotential in Kilovolts.
        /// </summary>
        public double Kilovolts
        {
            get { return (_volts) / 1e3d; }
        }

        /// <summary>
        ///     Get ElectricPotential in Megavolts.
        /// </summary>
        public double Megavolts
        {
            get { return (_volts) / 1e6d; }
        }

        /// <summary>
        ///     Get ElectricPotential in Microvolts.
        /// </summary>
        public double Microvolts
        {
            get { return (_volts) / 1e-6d; }
        }

        /// <summary>
        ///     Get ElectricPotential in Millivolts.
        /// </summary>
        public double Millivolts
        {
            get { return (_volts) / 1e-3d; }
        }

        /// <summary>
        ///     Get ElectricPotential in Volts.
        /// </summary>
        public double Volts
        {
            get { return _volts; }
        }

        #endregion

        #region Static 

        public static ElectricPotential Zero
        {
            get { return new ElectricPotential(); }
        }

        /// <summary>
        ///     Get ElectricPotential from Kilovolts.
        /// </summary>
        public static ElectricPotential FromKilovolts(double kilovolts)
        {
            return new ElectricPotential((kilovolts) * 1e3d);
        }

        /// <summary>
        ///     Get ElectricPotential from Megavolts.
        /// </summary>
        public static ElectricPotential FromMegavolts(double megavolts)
        {
            return new ElectricPotential((megavolts) * 1e6d);
        }

        /// <summary>
        ///     Get ElectricPotential from Microvolts.
        /// </summary>
        public static ElectricPotential FromMicrovolts(double microvolts)
        {
            return new ElectricPotential((microvolts) * 1e-6d);
        }

        /// <summary>
        ///     Get ElectricPotential from Millivolts.
        /// </summary>
        public static ElectricPotential FromMillivolts(double millivolts)
        {
            return new ElectricPotential((millivolts) * 1e-3d);
        }

        /// <summary>
        ///     Get ElectricPotential from Volts.
        /// </summary>
        public static ElectricPotential FromVolts(double volts)
        {
            return new ElectricPotential(volts);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricPotentialUnit" /> to <see cref="ElectricPotential" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricPotential unit value.</returns>
        public static ElectricPotential From(double value, ElectricPotentialUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ElectricPotentialUnit.Kilovolt:
                    return FromKilovolts(value);
                case ElectricPotentialUnit.Megavolt:
                    return FromMegavolts(value);
                case ElectricPotentialUnit.Microvolt:
                    return FromMicrovolts(value);
                case ElectricPotentialUnit.Millivolt:
                    return FromMillivolts(value);
                case ElectricPotentialUnit.Volt:
                    return FromVolts(value);

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
        public static string GetAbbreviation(ElectricPotentialUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static ElectricPotential operator -(ElectricPotential right)
        {
            return new ElectricPotential(-right._volts);
        }

        public static ElectricPotential operator +(ElectricPotential left, ElectricPotential right)
        {
            return new ElectricPotential(left._volts + right._volts);
        }

        public static ElectricPotential operator -(ElectricPotential left, ElectricPotential right)
        {
            return new ElectricPotential(left._volts - right._volts);
        }

        public static ElectricPotential operator *(double left, ElectricPotential right)
        {
            return new ElectricPotential(left*right._volts);
        }

        public static ElectricPotential operator *(ElectricPotential left, double right)
        {
            return new ElectricPotential(left._volts*(double)right);
        }

        public static ElectricPotential operator /(ElectricPotential left, double right)
        {
            return new ElectricPotential(left._volts/(double)right);
        }

        public static double operator /(ElectricPotential left, ElectricPotential right)
        {
            return Convert.ToDouble(left._volts/right._volts);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is ElectricPotential)) throw new ArgumentException("Expected type ElectricPotential.", "obj");
            return CompareTo((ElectricPotential) obj);
        }

        public int CompareTo(ElectricPotential other)
        {
            return _volts.CompareTo(other._volts);
        }

        public static bool operator <=(ElectricPotential left, ElectricPotential right)
        {
            return left._volts <= right._volts;
        }

        public static bool operator >=(ElectricPotential left, ElectricPotential right)
        {
            return left._volts >= right._volts;
        }

        public static bool operator <(ElectricPotential left, ElectricPotential right)
        {
            return left._volts < right._volts;
        }

        public static bool operator >(ElectricPotential left, ElectricPotential right)
        {
            return left._volts > right._volts;
        }

        public static bool operator ==(ElectricPotential left, ElectricPotential right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._volts == right._volts;
        }

        public static bool operator !=(ElectricPotential left, ElectricPotential right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._volts != right._volts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _volts.Equals(((ElectricPotential) obj)._volts);
        }

        public override int GetHashCode()
        {
            return _volts.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(ElectricPotentialUnit unit)
        {
            switch (unit)
            {
                case ElectricPotentialUnit.Kilovolt:
                    return Kilovolts;
                case ElectricPotentialUnit.Megavolt:
                    return Megavolts;
                case ElectricPotentialUnit.Microvolt:
                    return Microvolts;
                case ElectricPotentialUnit.Millivolt:
                    return Millivolts;
                case ElectricPotentialUnit.Volt:
                    return Volts;

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
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static ElectricPotential Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var regexString = string.Format(@"(?:(?<value>[-+]?{0}{1}{2}{3}\s?){4}",
                            numRegex,              // capture base (integral) Quantity value
                            @"(?:[eE][-+]?\d+)?)", // capture exponential (if any), end of Quantity capturing
                            @"\s?",                // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>\S+)",       // capture Unit (non-numeric, non-whitespace) input
                            @"{1,2}?");            // capture one or two quantities (eg. 1ft 2in)

            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<ElectricPotential>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;

                try
                {
                    ElectricPotentialUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch (Exception e)
                {
                    var newEx = new UnitsNetException("Error parsing string.", e);
                    newEx.Data["input"] = str;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
            }

            // Check if there were no valid matches
            if (converted.Count == 0)
            {
                var ex = new ArgumentException(
                    "Expected string to have one or two pairs of quantity and unit in the format \"<quantity><unit> or <quantity> <unit>\". Eg. \"5.5 m\" or \"1ft 2in\"", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }
            return converted.Aggregate((x, y) => x + y);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static ElectricPotentialUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<ElectricPotentialUnit>(str.Trim());

            if (unit == ElectricPotentialUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ElectricPotentialUnit.");
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
            return ToString(ElectricPotentialUnit.Volt);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(ElectricPotentialUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(ElectricPotentialUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
