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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Torque, moment or moment of force (see the terminology below), is the tendency of a force to rotate an object about an axis,[1] fulcrum, or pivot. Just as a force is a push or a pull, a torque can be thought of as a twist to an object. Mathematically, torque is defined as the cross product of the lever-arm distance and force, which tends to produce rotation. Loosely speaking, torque is a measure of the turning force on an object such as a bolt or a flywheel. For example, pushing or pulling the handle of a wrench connected to a nut or bolt produces a torque (turning force) that loosens or tightens the nut or bolt.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Torque : IComparable, IComparable<Torque>
    {
        /// <summary>
        ///     Base unit of Torque.
        /// </summary>
        private readonly double _newtonmeters;

        public Torque(double newtonmeters) : this()
        {
            _newtonmeters = newtonmeters;
        }

        #region Properties

        /// <summary>
        ///     Get Torque in Newtonmeters.
        /// </summary>
        public double Newtonmeters
        {
            get { return _newtonmeters; }
        }

        #endregion

        #region Static 

        public static Torque Zero
        {
            get { return new Torque(); }
        }

        /// <summary>
        ///     Get Torque from Newtonmeters.
        /// </summary>
        public static Torque FromNewtonmeters(double newtonmeters)
        {
            return new Torque(newtonmeters);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TorqueUnit" /> to <see cref="Torque" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Torque unit value.</returns>
        public static Torque From(double value, TorqueUnit fromUnit)
        {
            switch (fromUnit)
            {
                case TorqueUnit.Newtonmeter:
                    return FromNewtonmeters(value);

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
        public static string GetAbbreviation(TorqueUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Torque operator -(Torque right)
        {
            return new Torque(-right._newtonmeters);
        }

        public static Torque operator +(Torque left, Torque right)
        {
            return new Torque(left._newtonmeters + right._newtonmeters);
        }

        public static Torque operator -(Torque left, Torque right)
        {
            return new Torque(left._newtonmeters - right._newtonmeters);
        }

        public static Torque operator *(double left, Torque right)
        {
            return new Torque(left*right._newtonmeters);
        }

        public static Torque operator *(Torque left, double right)
        {
            return new Torque(left._newtonmeters*(double)right);
        }

        public static Torque operator /(Torque left, double right)
        {
            return new Torque(left._newtonmeters/(double)right);
        }

        public static double operator /(Torque left, Torque right)
        {
            return Convert.ToDouble(left._newtonmeters/right._newtonmeters);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Torque)) throw new ArgumentException("Expected type Torque.", "obj");
            return CompareTo((Torque) obj);
        }

        public int CompareTo(Torque other)
        {
            return _newtonmeters.CompareTo(other._newtonmeters);
        }

        public static bool operator <=(Torque left, Torque right)
        {
            return left._newtonmeters <= right._newtonmeters;
        }

        public static bool operator >=(Torque left, Torque right)
        {
            return left._newtonmeters >= right._newtonmeters;
        }

        public static bool operator <(Torque left, Torque right)
        {
            return left._newtonmeters < right._newtonmeters;
        }

        public static bool operator >(Torque left, Torque right)
        {
            return left._newtonmeters > right._newtonmeters;
        }

        public static bool operator ==(Torque left, Torque right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonmeters == right._newtonmeters;
        }

        public static bool operator !=(Torque left, Torque right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonmeters != right._newtonmeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _newtonmeters.Equals(((Torque) obj)._newtonmeters);
        }

        public override int GetHashCode()
        {
            return _newtonmeters.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(TorqueUnit unit)
        {
            switch (unit)
            {
                case TorqueUnit.Newtonmeter:
                    return Newtonmeters;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected 2 words. Input string needs to be in the format "&lt;quantity&gt; &lt;unit
        ///     &gt;".
        /// </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static Torque Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = @"[\d., "                        // allows digits, dots, commas, and spaces in the number by default
                         + numFormat.NumberGroupSeparator   // adds provided (or current) culture's group separator
                         + numFormat.NumberDecimalSeparator // adds provided (or current) culture's decimal separator
                         + @"]*\d";                         // ensures quantity ends in digit
            var regexString = @"(?<value>[-+]?" + numRegex + @"(?:[eE][-+]?\d+)?)" // capture Quantity input
                            + @"\s?"                                               // ignore whitespace (allows both "1kg", "1 kg")
                            + @"(?<unit>\S+)";                                     // capture Unit (non-whitespace) input

            var regex = new Regex(regexString);
            GroupCollection groups = regex.Match(str.Trim()).Groups;

            var valueString = groups["value"].Value;
            var unitString = groups["unit"].Value;

            if (valueString == "" || unitString == "")
            {
                var ex = new ArgumentException(
                    "Expected valid quantity and unit. Input string needs to be in the format \"<quantity><unit> or <quantity> <unit>\".", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }

            try
            {
                TorqueUnit unit = ParseUnit(unitString, formatProvider);
                double value = double.Parse(valueString, formatProvider);

                return From(value, unit);
            }
            catch (Exception e)
            {
                var newEx = new UnitsNetException("Error parsing string.", e);
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static TorqueUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<TorqueUnit>(str.Trim());

            if (unit == TorqueUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized TorqueUnit.");
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
            return ToString(TorqueUnit.Newtonmeter);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(TorqueUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(TorqueUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
