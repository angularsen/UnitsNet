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
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     The strength of a signal expressed in decibels (dB) relative to one watt.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct PowerRatio : IComparable, IComparable<PowerRatio>
    {
        /// <summary>
        ///     Base unit of PowerRatio.
        /// </summary>
        private readonly double _decibelWatts;

        public PowerRatio(double decibelwatts) : this()
        {
            _decibelWatts = decibelwatts;
        }

        #region Properties

        /// <summary>
        ///     Get PowerRatio in DecibelMilliwatts.
        /// </summary>
        public double DecibelMilliwatts
        {
            get { return _decibelWatts + 30; }
        }

        /// <summary>
        ///     Get PowerRatio in DecibelWatts.
        /// </summary>
        public double DecibelWatts
        {
            get { return _decibelWatts; }
        }

        #endregion

        #region Static 

        public static PowerRatio Zero
        {
            get { return new PowerRatio(); }
        }

        /// <summary>
        ///     Get PowerRatio from DecibelMilliwatts.
        /// </summary>
        public static PowerRatio FromDecibelMilliwatts(double decibelmilliwatts)
        {
            return new PowerRatio(decibelmilliwatts - 30);
        }

        /// <summary>
        ///     Get PowerRatio from DecibelWatts.
        /// </summary>
        public static PowerRatio FromDecibelWatts(double decibelwatts)
        {
            return new PowerRatio(decibelwatts);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="PowerRatioUnit" /> to <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>PowerRatio unit value.</returns>
        public static PowerRatio From(double value, PowerRatioUnit fromUnit)
        {
            switch (fromUnit)
            {
                case PowerRatioUnit.DecibelMilliwatt:
                    return FromDecibelMilliwatts(value);
                case PowerRatioUnit.DecibelWatt:
                    return FromDecibelWatts(value);

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
        public static string GetAbbreviation(PowerRatioUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Logarithmic Arithmetic Operators

        public static PowerRatio operator -(PowerRatio right)
        {
            return new PowerRatio(-right._decibelWatts);
        }

        public static PowerRatio operator +(PowerRatio left, PowerRatio right)
        {
            // Logarithmic addition
            // Formula: 10*log10(10^(x/10) + 10^(y/10))
            return new PowerRatio(10*Math.Log10(Math.Pow(10, left._decibelWatts/10) + Math.Pow(10, right._decibelWatts/10)));
        }

        public static PowerRatio operator -(PowerRatio left, PowerRatio right)
        {
            // Logarithmic subtraction 
            // Formula: 10*log10(10^(x/10) - 10^(y/10))
            return new PowerRatio(10*Math.Log10(Math.Pow(10, left._decibelWatts/10) - Math.Pow(10, right._decibelWatts/10)));
        }

        public static PowerRatio operator *(double left, PowerRatio right)
        {
            // Logarithmic multiplication = addition
            return new PowerRatio(left + right._decibelWatts);
        }

        public static PowerRatio operator *(PowerRatio left, double right)
        {
            // Logarithmic multiplication = addition
            return new PowerRatio(left._decibelWatts + (double)right);
        }

        public static PowerRatio operator /(PowerRatio left, double right)
        {
            // Logarithmic division = subtraction
            return new PowerRatio(left._decibelWatts - (double)right);
        }

        public static double operator /(PowerRatio left, PowerRatio right)
        {
            // Logarithmic division = subtraction
            return Convert.ToDouble(left._decibelWatts - right._decibelWatts);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is PowerRatio)) throw new ArgumentException("Expected type PowerRatio.", "obj");
            return CompareTo((PowerRatio) obj);
        }

        public int CompareTo(PowerRatio other)
        {
            return _decibelWatts.CompareTo(other._decibelWatts);
        }

        public static bool operator <=(PowerRatio left, PowerRatio right)
        {
            return left._decibelWatts <= right._decibelWatts;
        }

        public static bool operator >=(PowerRatio left, PowerRatio right)
        {
            return left._decibelWatts >= right._decibelWatts;
        }

        public static bool operator <(PowerRatio left, PowerRatio right)
        {
            return left._decibelWatts < right._decibelWatts;
        }

        public static bool operator >(PowerRatio left, PowerRatio right)
        {
            return left._decibelWatts > right._decibelWatts;
        }

        public static bool operator ==(PowerRatio left, PowerRatio right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decibelWatts == right._decibelWatts;
        }

        public static bool operator !=(PowerRatio left, PowerRatio right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decibelWatts != right._decibelWatts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _decibelWatts.Equals(((PowerRatio) obj)._decibelWatts);
        }

        public override int GetHashCode()
        {
            return _decibelWatts.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(PowerRatioUnit unit)
        {
            switch (unit)
            {
                case PowerRatioUnit.DecibelMilliwatt:
                    return DecibelMilliwatts;
                case PowerRatioUnit.DecibelWatt:
                    return DecibelWatts;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(PowerRatioUnit unit, CultureInfo culture = null)
        {
            return ToString(unit, culture, "{0:0.##} {1}");
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
        public string ToString(PowerRatioUnit unit, CultureInfo culture, string format, params object[] args)
        {
            string abbreviation = UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
            object[] finalArgs = new object[] {As(unit), abbreviation}
                .Concat(args)
                .ToArray();

            return string.Format(culture, format, finalArgs);
        }

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(PowerRatioUnit.DecibelWatt);
        }
    }
}
