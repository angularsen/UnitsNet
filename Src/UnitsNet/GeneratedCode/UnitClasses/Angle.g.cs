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
    ///     In geometry, an angle is the figure formed by two rays, called the sides of the angle, sharing a common endpoint, called the vertex of the angle.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Angle : IComparable, IComparable<Angle>
    {
        /// <summary>
        ///     Base unit of Angle.
        /// </summary>
        private readonly double _degrees;

        public Angle(double degrees) : this()
        {
            _degrees = degrees;
        }

        #region Properties

        /// <summary>
        ///     Get Angle in Degrees.
        /// </summary>
        public double Degrees
        {
            get { return _degrees; }
        }

        /// <summary>
        ///     Get Angle in Gradians.
        /// </summary>
        public double Gradians
        {
            get { return _degrees/0.9; }
        }

        /// <summary>
        ///     Get Angle in Radians.
        /// </summary>
        public double Radians
        {
            get { return _degrees/180*Math.PI; }
        }

        #endregion

        #region Static 

        public static Angle Zero
        {
            get { return new Angle(); }
        }

        /// <summary>
        ///     Get Angle from Degrees.
        /// </summary>
        public static Angle FromDegrees(double degrees)
        {
            return new Angle(degrees);
        }

        /// <summary>
        ///     Get Angle from Gradians.
        /// </summary>
        public static Angle FromGradians(double gradians)
        {
            return new Angle(gradians*0.9);
        }

        /// <summary>
        ///     Get Angle from Radians.
        /// </summary>
        public static Angle FromRadians(double radians)
        {
            return new Angle(radians*180/Math.PI);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AngleUnit" /> to <see cref="Angle" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Angle unit value.</returns>
        public static Angle From(double value, AngleUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AngleUnit.Degree:
                    return FromDegrees(value);
                case AngleUnit.Gradian:
                    return FromGradians(value);
                case AngleUnit.Radian:
                    return FromRadians(value);

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
        public static string GetAbbreviation(AngleUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Angle operator -(Angle right)
        {
            return new Angle(-right._degrees);
        }

        public static Angle operator +(Angle left, Angle right)
        {
            return new Angle(left._degrees + right._degrees);
        }

        public static Angle operator -(Angle left, Angle right)
        {
            return new Angle(left._degrees - right._degrees);
        }

        public static Angle operator *(double left, Angle right)
        {
            return new Angle(left*right._degrees);
        }

        public static Angle operator *(Angle left, double right)
        {
            return new Angle(left._degrees*(double)right);
        }

        public static Angle operator /(Angle left, double right)
        {
            return new Angle(left._degrees/(double)right);
        }

        public static double operator /(Angle left, Angle right)
        {
            return Convert.ToDouble(left._degrees/right._degrees);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Angle)) throw new ArgumentException("Expected type Angle.", "obj");
            return CompareTo((Angle) obj);
        }

        public int CompareTo(Angle other)
        {
            return _degrees.CompareTo(other._degrees);
        }

        public static bool operator <=(Angle left, Angle right)
        {
            return left._degrees <= right._degrees;
        }

        public static bool operator >=(Angle left, Angle right)
        {
            return left._degrees >= right._degrees;
        }

        public static bool operator <(Angle left, Angle right)
        {
            return left._degrees < right._degrees;
        }

        public static bool operator >(Angle left, Angle right)
        {
            return left._degrees > right._degrees;
        }

        public static bool operator ==(Angle left, Angle right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._degrees == right._degrees;
        }

        public static bool operator !=(Angle left, Angle right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._degrees != right._degrees;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _degrees.Equals(((Angle) obj)._degrees);
        }

        public override int GetHashCode()
        {
            return _degrees.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AngleUnit unit)
        {
            switch (unit)
            {
                case AngleUnit.Degree:
                    return Degrees;
                case AngleUnit.Gradian:
                    return Gradians;
                case AngleUnit.Radian:
                    return Radians;

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
            return ToString(AngleUnit.Degree);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
		/// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(AngleUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(AngleUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
