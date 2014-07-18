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
using UnitsNet.Annotations;
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
        [UsedImplicitly] public readonly double Newtonmeters;

        public Torque(double newtonmeters) : this()
        {
            Newtonmeters = newtonmeters;
        }

        #region Properties

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
            return new Torque(-right.Newtonmeters);
        }

        public static Torque operator +(Torque left, Torque right)
        {
            return new Torque(left.Newtonmeters + right.Newtonmeters);
        }

        public static Torque operator -(Torque left, Torque right)
        {
            return new Torque(left.Newtonmeters - right.Newtonmeters);
        }

        public static Torque operator *(double left, Torque right)
        {
            return new Torque(left*right.Newtonmeters);
        }

        public static Torque operator *(Torque left, double right)
        {
            return new Torque(left.Newtonmeters*right);
        }

        public static Torque operator /(Torque left, double right)
        {
            return new Torque(left.Newtonmeters/right);
        }

        public static double operator /(Torque left, Torque right)
        {
            return left.Newtonmeters/right.Newtonmeters;
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
            return Newtonmeters.CompareTo(other.Newtonmeters);
        }

        public static bool operator <=(Torque left, Torque right)
        {
            return left.Newtonmeters <= right.Newtonmeters;
        }

        public static bool operator >=(Torque left, Torque right)
        {
            return left.Newtonmeters >= right.Newtonmeters;
        }

        public static bool operator <(Torque left, Torque right)
        {
            return left.Newtonmeters < right.Newtonmeters;
        }

        public static bool operator >(Torque left, Torque right)
        {
            return left.Newtonmeters > right.Newtonmeters;
        }

        public static bool operator ==(Torque left, Torque right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.Newtonmeters == right.Newtonmeters;
        }

        public static bool operator !=(Torque left, Torque right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.Newtonmeters != right.Newtonmeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Newtonmeters.Equals(((Torque) obj).Newtonmeters);
        }

        public override int GetHashCode()
        {
            return Newtonmeters.GetHashCode();
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

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(TorqueUnit unit, CultureInfo culture = null)
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
        public string ToString(TorqueUnit unit, CultureInfo culture, string format, params object[] args)
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
            return ToString(TorqueUnit.Newtonmeter);
        }
    }
}
