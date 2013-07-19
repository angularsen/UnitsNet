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

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing distance, according to the International System of Units (SI)
    /// </summary>
    public struct SiDistance : IComparable, IComparable<SiDistance>
    {
        public readonly double Meters;

        /// <summary>
        ///     Enforce static methods for creation.
        /// </summary>
        private SiDistance(double meters) : this()
        {
            Meters = meters;
        }

        #region Unit Properties

        /// <summary>
        ///     Return the centimeter representation of the distance.
        /// </summary>
        public double Centimeters
        {
            get { return Meters*100; }
        }

        /// <summary>
        ///     Return the millimeter representation of the distance.
        /// </summary>
        public double Millimeters
        {
            get { return Meters*1000; }
        }

        #endregion

        #region Static

        /// <summary>
        ///     The maximum representable distance in meters.
        /// </summary>
        public static SiDistance Max
        {
            get { return FromMillimeters(double.MaxValue); }
        }

        /// <summary>
        ///     The smallest representable distance in meters.
        /// </summary>
        public static SiDistance Min
        {
            get { return FromMillimeters(double.MinValue); }
        }

        public static SiDistance Zero
        {
            get { return new SiDistance(0); }
        }

        public static SiDistance FromMeters(double meters)
        {
            return new SiDistance(meters);
        }

        public static SiDistance FromCentimeters(double centimeters)
        {
            return FromMeters(centimeters/100);
        }

        public static SiDistance FromMillimeters(double millimeters)
        {
            return FromMeters(millimeters/1000);
        }

        #endregion

        #region Arithmetic operators

        public static SiDistance operator -(SiDistance right)
        {
            return FromMeters(-right.Meters);
        }

        public static SiDistance operator +(SiDistance left, SiDistance right)
        {
            return FromMeters(left.Meters + right.Meters);
        }

        public static SiDistance operator -(SiDistance left, SiDistance right)
        {
            return FromMeters(left.Meters - right.Meters);
        }

        public static SiDistance operator *(double left, SiDistance right)
        {
            return FromMeters(left*right.Meters);
        }

        public static SiDistance operator /(SiDistance left, double right)
        {
            return FromMeters(left.Meters/right);
        }

        #endregion

        #region Comparable operators

        public static bool operator <=(SiDistance left, SiDistance right)
        {
            return left.Meters <= right.Meters;
        }

        public static bool operator >=(SiDistance left, SiDistance right)
        {
            return left.Meters >= right.Meters;
        }

        public static bool operator <(SiDistance left, SiDistance right)
        {
            return left.Meters < right.Meters;
        }

        public static bool operator >(SiDistance left, SiDistance right)
        {
            return left.Meters > right.Meters;
        }

        public static bool operator !=(SiDistance left, SiDistance right)
        {
            return left.Meters != right.Meters;
        }

        public static bool operator ==(SiDistance left, SiDistance right)
        {
            return left.Meters == right.Meters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SiDistance)) throw new ArgumentException("Expected type SiDistance.", "obj");
            return CompareTo((SiDistance) obj);
        }

        public int CompareTo(SiDistance other)
        {
            return Meters.CompareTo(other.Meters);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SiDistance))
                return false;

            return Meters.CompareTo(((SiDistance) obj).Meters) == 0;
        }

        public override int GetHashCode()
        {
            return Meters.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return Meters + " m";
        }
    }
}