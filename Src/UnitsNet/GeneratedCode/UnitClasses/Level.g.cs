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
    ///     Level is the logarithm of the ratio of a quantity Q to a reference value of that quantity, Q0, expressed in dimensionless units.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Level : IComparable, IComparable<Level>
    {
        /// <summary>
        ///     Base unit of Level.
        /// </summary>
        private readonly double _decibels;

        public Level(double decibels) : this()
        {
            _decibels = decibels;
        }

        #region Properties

        /// <summary>
        ///     Get Level in Decibels.
        /// </summary>
        public double Decibels
        {
            get { return _decibels; }
        }

        /// <summary>
        ///     Get Level in Nepers.
        /// </summary>
        public double Nepers
        {
            get { return 0.115129254*_decibels; }
        }

        #endregion

        #region Static 

        public static Level Zero
        {
            get { return new Level(); }
        }

        /// <summary>
        ///     Get Level from Decibels.
        /// </summary>
        public static Level FromDecibels(double decibels)
        {
            return new Level(decibels);
        }

        /// <summary>
        ///     Get Level from Nepers.
        /// </summary>
        public static Level FromNepers(double nepers)
        {
            return new Level((1/0.115129254)*nepers);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LevelUnit" /> to <see cref="Level" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Level unit value.</returns>
        public static Level From(double value, LevelUnit fromUnit)
        {
            switch (fromUnit)
            {
                case LevelUnit.Decibel:
                    return FromDecibels(value);
                case LevelUnit.Neper:
                    return FromNepers(value);

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
        public static string GetAbbreviation(LevelUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Logarithmic Arithmetic Operators

        public static Level operator -(Level right)
        {
            return new Level(-right._decibels);
        }

        public static Level operator +(Level left, Level right)
        {
            // Logarithmic addition
            // Formula: 10*log10(10^(x/10) + 10^(y/10))
            return new Level(10*Math.Log10(Math.Pow(10, left._decibels/10) + Math.Pow(10, right._decibels/10)));
        }

        public static Level operator -(Level left, Level right)
        {
            // Logarithmic subtraction 
            // Formula: 10*log10(10^(x/10) - 10^(y/10))
            return new Level(10*Math.Log10(Math.Pow(10, left._decibels/10) - Math.Pow(10, right._decibels/10)));
        }

        public static Level operator *(double left, Level right)
        {
            // Logarithmic multiplication = addition
            return new Level(left + right._decibels);
        }

        public static Level operator *(Level left, double right)
        {
            // Logarithmic multiplication = addition
            return new Level(left._decibels + (double)right);
        }

        public static Level operator /(Level left, double right)
        {
            // Logarithmic division = subtraction
            return new Level(left._decibels - (double)right);
        }

        public static double operator /(Level left, Level right)
        {
            // Logarithmic division = subtraction
            return Convert.ToDouble(left._decibels - right._decibels);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Level)) throw new ArgumentException("Expected type Level.", "obj");
            return CompareTo((Level) obj);
        }

        public int CompareTo(Level other)
        {
            return _decibels.CompareTo(other._decibels);
        }

        public static bool operator <=(Level left, Level right)
        {
            return left._decibels <= right._decibels;
        }

        public static bool operator >=(Level left, Level right)
        {
            return left._decibels >= right._decibels;
        }

        public static bool operator <(Level left, Level right)
        {
            return left._decibels < right._decibels;
        }

        public static bool operator >(Level left, Level right)
        {
            return left._decibels > right._decibels;
        }

        public static bool operator ==(Level left, Level right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decibels == right._decibels;
        }

        public static bool operator !=(Level left, Level right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._decibels != right._decibels;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _decibels.Equals(((Level) obj)._decibels);
        }

        public override int GetHashCode()
        {
            return _decibels.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(LevelUnit unit)
        {
            switch (unit)
            {
                case LevelUnit.Decibel:
                    return Decibels;
                case LevelUnit.Neper:
                    return Nepers;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(LevelUnit.Decibel);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
		/// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(LevelUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(LevelUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
