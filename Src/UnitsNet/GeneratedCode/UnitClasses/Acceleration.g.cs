// Copyright ©2007 by Initial Force AS.  All rights reserved.
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
    ///     Acceleration, in physics, is the rate at which the velocity of an object changes over time. An object's acceleration is the net result of any and all forces acting on the object, as described by Newton's Second Law. The SI unit for acceleration is the Meter per second squared (m/s2). Accelerations are vector quantities (they have magnitude and direction) and add according to the parallelogram law. As a vector, the calculated net force is equal to the product of the object's mass (a scalar quantity) and the acceleration.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Acceleration : IComparable, IComparable<Acceleration>
    {
        /// <summary>
        ///     Base unit of Acceleration.
        /// </summary>
        private readonly double _meterPerSecondSquared;

        public Acceleration(double meterpersecondsquared) : this()
        {
            _meterPerSecondSquared = meterpersecondsquared;
        }

        #region Properties

        /// <summary>
        ///     Get Acceleration in MeterPerSecondSquared.
        /// </summary>
        public double MeterPerSecondSquared
        {
            get { return _meterPerSecondSquared; }
        }

        #endregion

        #region Static 

        public static Acceleration Zero
        {
            get { return new Acceleration(); }
        }

        /// <summary>
        ///     Get Acceleration from MeterPerSecondSquared.
        /// </summary>
        public static Acceleration FromMeterPerSecondSquared(double meterpersecondsquared)
        {
            return new Acceleration(meterpersecondsquared);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AccelerationUnit" /> to <see cref="Acceleration" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Acceleration unit value.</returns>
        public static Acceleration From(double value, AccelerationUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AccelerationUnit.MeterPerSecondSquared:
                    return FromMeterPerSecondSquared(value);

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
        public static string GetAbbreviation(AccelerationUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Acceleration operator -(Acceleration right)
        {
            return new Acceleration(-right._meterPerSecondSquared);
        }

        public static Acceleration operator +(Acceleration left, Acceleration right)
        {
            return new Acceleration(left._meterPerSecondSquared + right._meterPerSecondSquared);
        }

        public static Acceleration operator -(Acceleration left, Acceleration right)
        {
            return new Acceleration(left._meterPerSecondSquared - right._meterPerSecondSquared);
        }

        public static Acceleration operator *(double left, Acceleration right)
        {
            return new Acceleration(left*right._meterPerSecondSquared);
        }

        public static Acceleration operator *(Acceleration left, double right)
        {
            return new Acceleration(left._meterPerSecondSquared*(double)right);
        }

        public static Acceleration operator /(Acceleration left, double right)
        {
            return new Acceleration(left._meterPerSecondSquared/(double)right);
        }

        public static double operator /(Acceleration left, Acceleration right)
        {
            return Convert.ToDouble(left._meterPerSecondSquared/right._meterPerSecondSquared);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Acceleration)) throw new ArgumentException("Expected type Acceleration.", "obj");
            return CompareTo((Acceleration) obj);
        }

        public int CompareTo(Acceleration other)
        {
            return _meterPerSecondSquared.CompareTo(other._meterPerSecondSquared);
        }

        public static bool operator <=(Acceleration left, Acceleration right)
        {
            return left._meterPerSecondSquared <= right._meterPerSecondSquared;
        }

        public static bool operator >=(Acceleration left, Acceleration right)
        {
            return left._meterPerSecondSquared >= right._meterPerSecondSquared;
        }

        public static bool operator <(Acceleration left, Acceleration right)
        {
            return left._meterPerSecondSquared < right._meterPerSecondSquared;
        }

        public static bool operator >(Acceleration left, Acceleration right)
        {
            return left._meterPerSecondSquared > right._meterPerSecondSquared;
        }

        public static bool operator ==(Acceleration left, Acceleration right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._meterPerSecondSquared == right._meterPerSecondSquared;
        }

        public static bool operator !=(Acceleration left, Acceleration right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._meterPerSecondSquared != right._meterPerSecondSquared;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _meterPerSecondSquared.Equals(((Acceleration) obj)._meterPerSecondSquared);
        }

        public override int GetHashCode()
        {
            return _meterPerSecondSquared.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AccelerationUnit unit)
        {
            switch (unit)
            {
                case AccelerationUnit.MeterPerSecondSquared:
                    return MeterPerSecondSquared;

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
        public string ToString(AccelerationUnit unit, CultureInfo culture = null)
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
        public string ToString(AccelerationUnit unit, CultureInfo culture, string format, params object[] args)
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
            return ToString(AccelerationUnit.MeterPerSecondSquared);
        }
    }
}
