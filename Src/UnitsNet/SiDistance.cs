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
    /// TODO Rename to Length.
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
        /// Distance in miles.
        /// </summary>
        public double Miles
        {
            get { return Meters*0.000621371; }
        }

        /// <summary>
        /// Distance in yards.
        /// </summary>
        public double Yards
        {
            get { return Meters*1.09361; }
        }

        /// <summary>
        /// Distance in feet.
        /// </summary>
        public double Feet
        {
            get { return Meters*3.28084; }
        }

        /// <summary>
        /// Distance in inches.
        /// </summary>
        public double Inches
        {
            get { return Meters * 39.3701; }
        }


        /// <summary>
        /// Distance in kilometers.
        /// </summary>
        public double Kilometers
        {
            get { return Meters*1E-3; }
        }

        public double Decimeters
        {
            get { return Meters*1E1; }
        }

        /// <summary>
        ///     Distance in centimeters.
        /// </summary>
        public double Centimeters
        {
            get { return Meters*1E2; }
        }

        /// <summary>
        ///     Distance in millimeters.
        /// </summary>
        public double Millimeters
        {
            get { return Meters*1E3; }
        }

        /// <summary>
        /// Distance in micrometers.
        /// </summary>
        public double Micrometers
        {
            get { return Meters*1E6; }
        }

        /// <summary>
        /// Distance in nanometers.
        /// </summary>
        public double Nanometers
        {
            get { return Meters*1E9; }
        }

        #endregion

        #region Static

        /// <summary>
        ///     The maximum representable distance in meters.
        /// </summary>
        public static SiDistance Max
        {
            get { return new SiDistance(double.MaxValue); }
        }

        /// <summary>
        ///     The smallest representable distance in meters.
        /// </summary>
        public static SiDistance Min
        {
            get { return new SiDistance(double.MinValue); }
        }

        public static SiDistance Zero
        {
            get { return new SiDistance(); }
        }

        public static SiDistance FromKilometers(double km)
        {
            return new SiDistance(km*1E3);
        }

        public static SiDistance FromMiles(double m)
        {
            return new SiDistance(m*1609.34);
        }

        public static SiDistance FromYards(double yds)
        {
            return new SiDistance(yds*0.9144);
        }

        public static SiDistance FromFeet(double ft)
        {
            return new SiDistance(ft*0.3048);
        }

        public static SiDistance FromInches(double @in)
        {
            return new SiDistance(@in*0.0254);
        }

        public static SiDistance FromMeters(double m)
        {
            return new SiDistance(m);
        }

        public static SiDistance FromDecimeters(double dm)
        {
            return new SiDistance(dm*1E-1);
        } 

        public static SiDistance FromCentimeters(double cm)
        {
            return FromMeters(cm*1E-2);
        }

        public static SiDistance FromMillimeters(double mm)
        {
            return FromMeters(mm*1E-3);
        }

        public static SiDistance FromMicrometers(double um)
        {
            return FromMeters(um*1E-6);
        }

        public static SiDistance FromNanometers(double nm)
        {
            return FromMeters(nm*1E-9);
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