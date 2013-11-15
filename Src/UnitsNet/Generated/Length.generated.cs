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
    /// Many different units of length have been used around the world. The main units in modern use are U.S. customary units in the United States and the Metric system elsewhere. British Imperial units are still used for some purposes in the United Kingdom and some other countries. The metric system is sub-divided into SI and non-SI units.
    /// </summary>
    public partial struct Length : IComparable, IComparable<Length>
    {
        /// <summary>
        /// Base unit of Length.
        /// </summary>
        public readonly double Meters;

        public Length(double meters) : this()
        {
            Meters = meters;
        }

        #region Unit Properties

        public double Centimeters
        {
            get { return Meters/0.01; }
        }

        public double Decimeters
        {
            get { return Meters/0.1; }
        }

        public double Feet
        {
            get { return Meters/0.3048; }
        }

        public double Inches
        {
            get { return Meters/0.0254; }
        }

        public double Kilometers
        {
            get { return Meters/1000; }
        }

        public double Microinches
        {
            get { return Meters/2.54E-08; }
        }

        public double Micrometers
        {
            get { return Meters/1E-06; }
        }

        public double Mils
        {
            get { return Meters/2.54E-05; }
        }

        public double Miles
        {
            get { return Meters/1609.34; }
        }

        public double Millimeters
        {
            get { return Meters/0.001; }
        }

        public double Nanometers
        {
            get { return Meters/1E-09; }
        }

        public double Yards
        {
            get { return Meters/0.9144; }
        }

        #endregion

        #region Static 

        public static Length Zero
        {
            get { return new Length(); }
        }
        
        public static Length FromCentimeters(double centimeters)
        {
            return new Length(centimeters*0.01);
        }

        public static Length FromDecimeters(double decimeters)
        {
            return new Length(decimeters*0.1);
        }

        public static Length FromFeet(double feet)
        {
            return new Length(feet*0.3048);
        }

        public static Length FromInches(double inches)
        {
            return new Length(inches*0.0254);
        }

        public static Length FromKilometers(double kilometers)
        {
            return new Length(kilometers*1000);
        }

        public static Length FromMeters(double meters)
        {
            return new Length(meters*1);
        }

        public static Length FromMicroinches(double microinches)
        {
            return new Length(microinches*2.54E-08);
        }

        public static Length FromMicrometers(double micrometers)
        {
            return new Length(micrometers*1E-06);
        }

        public static Length FromMils(double mils)
        {
            return new Length(mils*2.54E-05);
        }

        public static Length FromMiles(double miles)
        {
            return new Length(miles*1609.34);
        }

        public static Length FromMillimeters(double millimeters)
        {
            return new Length(millimeters*0.001);
        }

        public static Length FromNanometers(double nanometers)
        {
            return new Length(nanometers*1E-09);
        }

        public static Length FromYards(double yards)
        {
            return new Length(yards*0.9144);
        }

        #endregion

        #region Arithmetic Operators

        public static Length operator -(Length right)
        {
            return new Length(-right.Meters);
        }

        public static Length operator +(Length left, Length right)
        {
            return new Length(left.Meters + right.Meters);
        }

        public static Length operator -(Length left, Length right)
        {
            return new Length(left.Meters - right.Meters);
        }

        public static Length operator *(double left, Length right)
        {
            return new Length(left*right.Meters);
        }

        public static Length operator *(Length left, double right)
        {
            return new Length(left.Meters*right);
        }

        public static Length operator /(Length left, double right)
        {
            return new Length(left.Meters/right);
        }

        public static double operator /(Length left, Length right)
        {
            return left.Meters/right.Meters;
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

        public static bool operator ==(Length left, Length right)
        {
            return left.Meters == right.Meters;
        }

        public static bool operator !=(Length left, Length right)
        {
            return left.Meters != right.Meters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Meters.Equals(((Length) obj).Meters);
        }

        public override int GetHashCode()
        {
            return Meters.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Meters, UnitSystem.Create().GetDefaultAbbreviation(Unit.Meter));
        }
    }
} 
