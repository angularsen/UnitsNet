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

using System;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// In everyday use and in kinematics, the speed of an object is the magnitude of its velocity (the rate of change of its position); it is thus a scalar quantity.[1] The average speed of an object in an interval of time is the distance travelled by the object divided by the duration of the interval;[2] the instantaneous speed is the limit of the average speed as the duration of the time interval approaches zero.
    /// </summary>
    public partial struct Speed : IComparable, IComparable<Speed>
    {
        /// <summary>
        /// Base unit of Speed.
        /// </summary>
        public readonly double MetersPerSecond;

        public Speed(double meterspersecond) : this()
        {
            MetersPerSecond = meterspersecond;
        }

        #region Unit Properties

        /// <summary>
        /// Get Speed in FeetPerSecond.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in FeetPerSecond and y is value in base unit MetersPerSecond.</remarks>
        public double FeetPerSecond
        {
            get { return (MetersPerSecond - (0)) / 0.3048; }
        }

        /// <summary>
        /// Get Speed in KilometersPerHour.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in KilometersPerHour and y is value in base unit MetersPerSecond.</remarks>
        public double KilometersPerHour
        {
            get { return (MetersPerSecond - (0)) / 0.277777777777778; }
        }

        /// <summary>
        /// Get Speed in Knots.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Knots and y is value in base unit MetersPerSecond.</remarks>
        public double Knots
        {
            get { return (MetersPerSecond - (0)) / 0.514444; }
        }

        /// <summary>
        /// Get Speed in MilesPerHour.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in MilesPerHour and y is value in base unit MetersPerSecond.</remarks>
        public double MilesPerHour
        {
            get { return (MetersPerSecond - (0)) / 0.44704; }
        }

        #endregion

        #region Static 

        public static Speed Zero
        {
            get { return new Speed(); }
        }
        
        /// <summary>
        /// Get Speed from FeetPerSecond.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in FeetPerSecond and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromFeetPerSecond(double feetpersecond)
        {
            return new Speed(0.3048 * feetpersecond + 0);
        }

        /// <summary>
        /// Get Speed from KilometersPerHour.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in KilometersPerHour and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromKilometersPerHour(double kilometersperhour)
        {
            return new Speed(0.277777777777778 * kilometersperhour + 0);
        }

        /// <summary>
        /// Get Speed from Knots.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Knots and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromKnots(double knots)
        {
            return new Speed(0.514444 * knots + 0);
        }

        /// <summary>
        /// Get Speed from MetersPerSecond.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in MetersPerSecond and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromMetersPerSecond(double meterspersecond)
        {
            return new Speed(1 * meterspersecond + 0);
        }

        /// <summary>
        /// Get Speed from MilesPerHour.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in MilesPerHour and y is value in base unit MetersPerSecond.</remarks>
        public static Speed FromMilesPerHour(double milesperhour)
        {
            return new Speed(0.44704 * milesperhour + 0);
        }

        #endregion

        #region Arithmetic Operators

        public static Speed operator -(Speed right)
        {
            return new Speed(-right.MetersPerSecond);
        }

        public static Speed operator +(Speed left, Speed right)
        {
            return new Speed(left.MetersPerSecond + right.MetersPerSecond);
        }

        public static Speed operator -(Speed left, Speed right)
        {
            return new Speed(left.MetersPerSecond - right.MetersPerSecond);
        }

        public static Speed operator *(double left, Speed right)
        {
            return new Speed(left*right.MetersPerSecond);
        }

        public static Speed operator *(Speed left, double right)
        {
            return new Speed(left.MetersPerSecond*right);
        }

        public static Speed operator /(Speed left, double right)
        {
            return new Speed(left.MetersPerSecond/right);
        }

        public static double operator /(Speed left, Speed right)
        {
            return left.MetersPerSecond/right.MetersPerSecond;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Speed)) throw new ArgumentException("Expected type Speed.", "obj");
            return CompareTo((Speed) obj);
        }

        public int CompareTo(Speed other)
        {
            return MetersPerSecond.CompareTo(other.MetersPerSecond);
        }

        public static bool operator <=(Speed left, Speed right)
        {
            return left.MetersPerSecond <= right.MetersPerSecond;
        }

        public static bool operator >=(Speed left, Speed right)
        {
            return left.MetersPerSecond >= right.MetersPerSecond;
        }

        public static bool operator <(Speed left, Speed right)
        {
            return left.MetersPerSecond < right.MetersPerSecond;
        }

        public static bool operator >(Speed left, Speed right)
        {
            return left.MetersPerSecond > right.MetersPerSecond;
        }

        public static bool operator ==(Speed left, Speed right)
        {
            return left.MetersPerSecond == right.MetersPerSecond;
        }

        public static bool operator !=(Speed left, Speed right)
        {
            return left.MetersPerSecond != right.MetersPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return MetersPerSecond.Equals(((Speed) obj).MetersPerSecond);
        }

        public override int GetHashCode()
        {
            return MetersPerSecond.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", MetersPerSecond, UnitSystem.Create().GetDefaultAbbreviation(Unit.MeterPerSecond));
        }
    }
} 
