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
    ///     A class for representing units of volume.
    /// </summary>
    public struct Volume : IComparable, IComparable<Volume>
    {
        public readonly double Meters;

        /// <summary>
        ///     Enforce static methods for creation.
        /// </summary>
        private Volume(double meters)
            : this()
        {
            Meters = meters;
        }

        #region Unit Properties

        public double Kilometers
        {
            get { return Meters * 1E-9; }
        }

        public double Decimeters
        {
            get { return Meters * 1E3; }
        }

        public double Centimeters
        {
            get { return Meters * 1E6; }
        }

        public double Milimeters
        {
            get { return Meters * 1E9; }
        }

        public double Hectoliters
        {
            get { return Meters * 1E1; }
        }

        public double Liters
        {
            get { return Meters * 1E3; }
        }

        public double Deciliters
        {
            get { return Meters * 1E4; }
        }

        public double Centiliters
        {
            get { return Meters * 1E5; }
        }

        public double Mililiters
        {
            get { return Meters * 1E6; }
        }

        #endregion

        #region Static

        /// <summary>
        ///     The maximum representable volume in meters.
        /// </summary>
        public static Volume Max
        {
            get { return new Volume(double.MaxValue); }
        }

        /// <summary>
        ///     The smallest representable volume in meters.
        /// </summary>
        public static Volume Min
        {
            get { return new Volume(double.MinValue); }
        }

        public static Volume Zero
        {
            get { return new Volume(); }
        }

        public static Volume FromKilometers(double km)
        {
            return new Volume(km * 1E9);
        }

        public static Volume FromMeters(double m)
        {
            return new Volume(m);
        }

        public static Volume FromDecimeters(double dm)
        {
            return new Volume(dm * 1E-3);
        }

        public static Volume FromCentimeters(double cm)
        {
            return new Volume(cm * 1E-6);
        }

        public static Volume FromMilimeters(double mm)
        {
            return new Volume(mm * 1E-9);
        }

        public static Volume FromHectoliters(double hl)
        {
            return new Volume(hl * 1E-1);
        }

        public static Volume FromLiters(double l)
        {
            return new Volume(l * 1E-3);
        }

        public static Volume FromDeciliters(double dl)
        {
            return new Volume(dl * 1E-4);
        }

        public static Volume FromCentiliters(double cl)
        {
            return new Volume(cl * 1E-5);
        }

        public static Volume FromMililiters(double ml)
        {
            return new Volume(ml * 1E-6);
        }

        #endregion

        #region Arithmetic operators

        public static Volume  operator -(Volume  right)
        {
            return FromMeters(-right.Meters);
        }

        public static Volume operator -(Volume left, Volume right)
        {
            return FromMeters(left.Meters - right.Meters);
        }

        public static Volume operator +(Volume left, Volume right)
        {
            return FromMeters(left.Meters + right.Meters);
        }

        #endregion

        #region Comparable operators

        public static bool operator <=(Volume left, Volume right)
        {
            return left.Meters <= right.Meters;
        }

        public static bool operator >=(Volume left, Volume right)
        {
            return left.Meters >= right.Meters;
        }

        public static bool operator <(Volume left, Volume right)
        {
            return left.Meters < right.Meters;
        }

        public static bool operator >(Volume left, Volume right)
        {
            return left.Meters > right.Meters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Volume)) throw new ArgumentException("Expected type Volume.", "obj");
            return CompareTo((Volume)obj);
        }

        public int CompareTo(Volume other)
        {
            return Meters.CompareTo(other.Meters);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Volume))
            {
                return false;
            }

            return Meters.CompareTo(((Volume)obj).Meters) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return Meters + " m3";
        }
    }
}
