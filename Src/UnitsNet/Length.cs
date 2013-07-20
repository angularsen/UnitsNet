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
    ///     A class for representing units of length.
    /// </summary>
    public struct Length : IComparable, IComparable<Length>
    {
        public readonly double Meters;

        /// <summary>
        ///     Enforce static methods for creation.
        /// </summary>
        private Length(double meters) : this()
        {
            Meters = meters;
        }

        #region Unit Properties

        public double Miles
        {
            get { return Meters*0.000621371; }
        }

        public double Yards
        {
            get { return Meters*1.09361; }
        }

        public double Feet
        {
            get { return Meters*3.28084; }
        }

        public double Inches
        {
            get { return Meters * 39.3701; }
        }

        public double Kilometers
        {
            get { return Meters*1E-3; }
        }

        public double Decimeters
        {
            get { return Meters*1E1; }
        }

        public double Centimeters
        {
            get { return Meters*1E2; }
        }

        public double Millimeters
        {
            get { return Meters*1E3; }
        }

        public double Micrometers
        {
            get { return Meters*1E6; }
        }

        public double Nanometers
        {
            get { return Meters*1E9; }
        }

        #endregion

        #region Static

        /// <summary>
        ///     The maximum representable distance in meters.
        /// </summary>
        public static Length Max
        {
            get { return new Length(double.MaxValue); }
        }

        /// <summary>
        ///     The smallest representable distance in meters.
        /// </summary>
        public static Length Min
        {
            get { return new Length(double.MinValue); }
        }

        public static Length Zero
        {
            get { return new Length(); }
        }

        public static Length FromKilometers(double km)
        {
            return new Length(km*1E3);
        }

        public static Length FromMiles(double m)
        {
            return new Length(m*1609.34);
        }

        public static Length FromYards(double yds)
        {
            return new Length(yds*0.9144);
        }

        public static Length FromFeet(double ft)
        {
            return new Length(ft*0.3048);
        }

        public static Length FromInches(double @in)
        {
            return new Length(@in*0.0254);
        }

        public static Length FromMeters(double m)
        {
            return new Length(m);
        }

        public static Length FromDecimeters(double dm)
        {
            return new Length(dm*1E-1);
        } 

        public static Length FromCentimeters(double cm)
        {
            return FromMeters(cm*1E-2);
        }

        public static Length FromMillimeters(double mm)
        {
            return FromMeters(mm*1E-3);
        }

        public static Length FromMicrometers(double um)
        {
            return FromMeters(um*1E-6);
        }

        public static Length FromNanometers(double nm)
        {
            return FromMeters(nm*1E-9);
        }

        #endregion

        #region Arithmetic operators

        public static Length operator -(Length right)
        {
            return FromMeters(-right.Meters);
        }

        public static Length operator +(Length left, Length right)
        {
            return FromMeters(left.Meters + right.Meters);
        }

        public static Length operator -(Length left, Length right)
        {
            return FromMeters(left.Meters - right.Meters);
        }

        public static Length operator *(double left, Length right)
        {
            return FromMeters(left*right.Meters);
        }

        public static Length operator /(Length left, double right)
        {
            return FromMeters(left.Meters/right);
        }

        #endregion

        #region Comparable operators

        public static bool operator <=(Length left, Length right)
        {
            return left.Meters <= right.Meters;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left.Meters >= right.Meters;
        }

        public static bool operator <(Length left, Length right)
        {
            return left.Meters < right.Meters;
        }

        public static bool operator >(Length left, Length right)
        {
            return left.Meters > right.Meters;
        }

        public static bool operator !=(Length left, Length right)
        {
            return left.Meters != right.Meters;
        }

        public static bool operator ==(Length left, Length right)
        {
            return left.Meters == right.Meters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Length)) throw new ArgumentException("Expected type Length.", "obj");
            return CompareTo((Length) obj);
        }

        public int CompareTo(Length other)
        {
            return Meters.CompareTo(other.Meters);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Length))
                return false;

            return Meters.CompareTo(((Length) obj).Meters) == 0;
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