// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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

using UnitsNet.Units;
using System;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// Rotational speed (sometimes called speed of revolution) is the number of complete rotations, revolutions, cycles, or turns per time unit. Rotational speed is a cyclic frequency, measured in radians per second or in hertz in the SI System by scientists, or in revolutions per minute (rpm or min-1) or revolutions per second in everyday life. The symbol for rotational speed is ω (the Greek lowercase letter "omega").
    /// </summary>
    public partial struct RotationalSpeed : IComparable, IComparable<RotationalSpeed>
    {
        /// <summary>
        /// Base unit of RotationalSpeed.
        /// </summary>
        public readonly double RevolutionsPerSecond;

        public RotationalSpeed(double revolutionspersecond) : this()
        {
            RevolutionsPerSecond = revolutionspersecond;
        }

        #region Properties

        /// <summary>
        /// Get RotationalSpeed in RevolutionsPerMinute.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in RevolutionsPerMinute and y is value in base unit RevolutionsPerSecond.</remarks>
        public double RevolutionsPerMinute
        { 
            get { return RevolutionsPerSecond / 0.0166666666666667; }
        }

        #endregion

        #region Static 

        public static RotationalSpeed Zero
        {
            get { return new RotationalSpeed(); }
        }
        
        /// <summary>
        /// Get RotationalSpeed from RevolutionsPerMinute.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in RevolutionsPerMinute and y is value in base unit RevolutionsPerSecond.</remarks>
        public static RotationalSpeed FromRevolutionsPerMinute(double revolutionsperminute)
        { 
            return new RotationalSpeed(0.0166666666666667 * revolutionsperminute);
        }

        /// <summary>
        /// Get RotationalSpeed from RevolutionsPerSecond.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in RevolutionsPerSecond and y is value in base unit RevolutionsPerSecond.</remarks>
        public static RotationalSpeed FromRevolutionsPerSecond(double revolutionspersecond)
        { 
            return new RotationalSpeed(1 * revolutionspersecond);
        }

        /// <summary>
        /// Try to dynamically convert from RotationalSpeed to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>RotationalSpeed unit value.</returns> 
        public static RotationalSpeed From(double value, RotationalSpeedUnit fromUnit)
        {
            switch (fromUnit)
            {
                case RotationalSpeedUnit.RevolutionPerMinute:
                    return FromRevolutionsPerMinute(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
        #endregion

        #region Arithmetic Operators

        public static RotationalSpeed operator -(RotationalSpeed right)
        {
            return new RotationalSpeed(-right.RevolutionsPerSecond);
        }

        public static RotationalSpeed operator +(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left.RevolutionsPerSecond + right.RevolutionsPerSecond);
        }

        public static RotationalSpeed operator -(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left.RevolutionsPerSecond - right.RevolutionsPerSecond);
        }

        public static RotationalSpeed operator *(double left, RotationalSpeed right)
        {
            return new RotationalSpeed(left*right.RevolutionsPerSecond);
        }

        public static RotationalSpeed operator *(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left.RevolutionsPerSecond*right);
        }

        public static RotationalSpeed operator /(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left.RevolutionsPerSecond/right);
        }

        public static double operator /(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond/right.RevolutionsPerSecond;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is RotationalSpeed)) throw new ArgumentException("Expected type RotationalSpeed.", "obj");
            return CompareTo((RotationalSpeed) obj);
        }

        public int CompareTo(RotationalSpeed other)
        {
            return RevolutionsPerSecond.CompareTo(other.RevolutionsPerSecond);
        }

        public static bool operator <=(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond <= right.RevolutionsPerSecond;
        }

        public static bool operator >=(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond >= right.RevolutionsPerSecond;
        }

        public static bool operator <(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond < right.RevolutionsPerSecond;
        }

        public static bool operator >(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond > right.RevolutionsPerSecond;
        }

        public static bool operator ==(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond == right.RevolutionsPerSecond;
        }

        public static bool operator !=(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond != right.RevolutionsPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return RevolutionsPerSecond.Equals(((RotationalSpeed) obj).RevolutionsPerSecond);
        }

        public override int GetHashCode()
        {
            return RevolutionsPerSecond.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from RotationalSpeed to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(RotationalSpeedUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case RotationalSpeedUnit.RevolutionPerMinute:
                    newValue = RevolutionsPerMinute;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from RotationalSpeed to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(RotationalSpeedUnit toUnit)
        {
            double newValue;
            if (!TryConvert(toUnit, out newValue))
                throw new NotImplementedException("toUnit: " + toUnit);

            return newValue;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", RevolutionsPerSecond, UnitSystem.Create().GetDefaultAbbreviation(RotationalSpeedUnit.RevolutionPerSecond));
        }
    }
} 
