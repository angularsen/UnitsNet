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
    ///     In classical electromagnetism, the electric potential (a scalar quantity denoted by Φ, ΦE or V and also called the electric field potential or the electrostatic potential) at a point is the amount of electric potential energy that a unitary point charge would have when located at that point.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct ElectricPotential : IComparable, IComparable<ElectricPotential>
    {
        /// <summary>
        ///     Base unit of ElectricPotential.
        /// </summary>
        [UsedImplicitly] public readonly double Volts;

        public ElectricPotential(double volts) : this()
        {
            Volts = volts;
        }

        #region Properties

        #endregion

        #region Static 

        public static ElectricPotential Zero
        {
            get { return new ElectricPotential(); }
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
            return new ElectricPotential(-right.Volts);
        }

        public static ElectricPotential operator +(ElectricPotential left, ElectricPotential right)
        {
            return new ElectricPotential(left.Volts + right.Volts);
        }

        public static ElectricPotential operator -(ElectricPotential left, ElectricPotential right)
        {
            return new ElectricPotential(left.Volts - right.Volts);
        }

        public static ElectricPotential operator *(double left, ElectricPotential right)
        {
            return new ElectricPotential(left*right.Volts);
        }

        public static ElectricPotential operator *(ElectricPotential left, double right)
        {
            return new ElectricPotential(left.Volts*right);
        }

        public static ElectricPotential operator /(ElectricPotential left, double right)
        {
            return new ElectricPotential(left.Volts/right);
        }

        public static double operator /(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts/right.Volts;
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
            return Volts.CompareTo(other.Volts);
        }

        public static bool operator <=(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts <= right.Volts;
        }

        public static bool operator >=(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts >= right.Volts;
        }

        public static bool operator <(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts < right.Volts;
        }

        public static bool operator >(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts > right.Volts;
        }

        public static bool operator ==(ElectricPotential left, ElectricPotential right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.Volts == right.Volts;
        }

        public static bool operator !=(ElectricPotential left, ElectricPotential right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.Volts != right.Volts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Volts.Equals(((ElectricPotential) obj).Volts);
        }

        public override int GetHashCode()
        {
            return Volts.GetHashCode();
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
                case ElectricPotentialUnit.Volt:
                    return Volts;

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
        public string ToString(ElectricPotentialUnit unit, CultureInfo culture = null)
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
        public string ToString(ElectricPotentialUnit unit, CultureInfo culture, string format, params object[] args)
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
            return ToString(ElectricPotentialUnit.Volt);
        }
    }
}
