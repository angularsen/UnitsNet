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
    /// Volume is the quantity of three-dimensional space enclosed by some closed boundary, for example, the space that a substance (solid, liquid, gas, or plasma) or shape occupies or contains.[1] Volume is often quantified numerically using the SI derived unit, the cubic metre. The volume of a container is generally understood to be the capacity of the container, i. e. the amount of fluid (gas or liquid) that the container could hold, rather than the amount of space the container itself displaces.
    /// </summary>
    public partial struct Volume : IComparable, IComparable<Volume>
    {
        /// <summary>
        /// Base unit of Volume.
        /// </summary>
        public readonly double CubicMeters;

        public Volume(double cubicmeters) : this()
        {
            CubicMeters = cubicmeters;
        }

        #region Unit Properties

        public double Centiliters
        {
            get { return CubicMeters/1E-05; }
        }

        public double CubicCentimeters
        {
            get { return CubicMeters/1E-06; }
        }

        public double CubicDecimeters
        {
            get { return CubicMeters/0.001; }
        }

        public double CubicFeet
        {
            get { return CubicMeters/0.0283168; }
        }

        public double CubicInches
        {
            get { return CubicMeters/1.6387E-05; }
        }

        public double CubicKilometers
        {
            get { return CubicMeters/1000000000; }
        }

        public double CubicMiles
        {
            get { return CubicMeters/4168181830; }
        }

        public double CubicMillimeters
        {
            get { return CubicMeters/1E-09; }
        }

        public double CubicYards
        {
            get { return CubicMeters/0.764554858; }
        }

        public double Deciliters
        {
            get { return CubicMeters/0.0001; }
        }

        public double Hectoliters
        {
            get { return CubicMeters/0.1; }
        }

        public double ImperialGallons
        {
            get { return CubicMeters/0.00454609000000181; }
        }

        public double ImperialOunces
        {
            get { return CubicMeters/2.84130624999629E-05; }
        }

        public double Liters
        {
            get { return CubicMeters/0.001; }
        }

        public double Milliliters
        {
            get { return CubicMeters/1E-06; }
        }

        public double UsGallons
        {
            get { return CubicMeters/0.00378541; }
        }

        public double UsOunces
        {
            get { return CubicMeters/2.95735295625376E-05; }
        }

        #endregion

        #region Static 

        public static Volume Zero
        {
            get { return new Volume(); }
        }
        
        public static Volume FromCentiliters(double centiliters)
        {
            return new Volume(centiliters*1E-05);
        }

        public static Volume FromCubicCentimeters(double cubiccentimeters)
        {
            return new Volume(cubiccentimeters*1E-06);
        }

        public static Volume FromCubicDecimeters(double cubicdecimeters)
        {
            return new Volume(cubicdecimeters*0.001);
        }

        public static Volume FromCubicFeet(double cubicfeet)
        {
            return new Volume(cubicfeet*0.0283168);
        }

        public static Volume FromCubicInches(double cubicinches)
        {
            return new Volume(cubicinches*1.6387E-05);
        }

        public static Volume FromCubicKilometers(double cubickilometers)
        {
            return new Volume(cubickilometers*1000000000);
        }

        public static Volume FromCubicMeters(double cubicmeters)
        {
            return new Volume(cubicmeters*1);
        }

        public static Volume FromCubicMiles(double cubicmiles)
        {
            return new Volume(cubicmiles*4168181830);
        }

        public static Volume FromCubicMillimeters(double cubicmillimeters)
        {
            return new Volume(cubicmillimeters*1E-09);
        }

        public static Volume FromCubicYards(double cubicyards)
        {
            return new Volume(cubicyards*0.764554858);
        }

        public static Volume FromDeciliters(double deciliters)
        {
            return new Volume(deciliters*0.0001);
        }

        public static Volume FromHectoliters(double hectoliters)
        {
            return new Volume(hectoliters*0.1);
        }

        public static Volume FromImperialGallons(double imperialgallons)
        {
            return new Volume(imperialgallons*0.00454609000000181);
        }

        public static Volume FromImperialOunces(double imperialounces)
        {
            return new Volume(imperialounces*2.84130624999629E-05);
        }

        public static Volume FromLiters(double liters)
        {
            return new Volume(liters*0.001);
        }

        public static Volume FromMilliliters(double milliliters)
        {
            return new Volume(milliliters*1E-06);
        }

        public static Volume FromUsGallons(double usgallons)
        {
            return new Volume(usgallons*0.00378541);
        }

        public static Volume FromUsOunces(double usounces)
        {
            return new Volume(usounces*2.95735295625376E-05);
        }

        #endregion

        #region Arithmetic Operators

        public static Volume operator -(Volume right)
        {
            return new Volume(-right.CubicMeters);
        }

        public static Volume operator +(Volume left, Volume right)
        {
            return new Volume(left.CubicMeters + right.CubicMeters);
        }

        public static Volume operator -(Volume left, Volume right)
        {
            return new Volume(left.CubicMeters - right.CubicMeters);
        }

        public static Volume operator *(double left, Volume right)
        {
            return new Volume(left*right.CubicMeters);
        }

        public static Volume operator *(Volume left, double right)
        {
            return new Volume(left.CubicMeters*right);
        }

        public static Volume operator /(Volume left, double right)
        {
            return new Volume(left.CubicMeters/right);
        }

        public static double operator /(Volume left, Volume right)
        {
            return left.CubicMeters/right.CubicMeters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Volume)) throw new ArgumentException("Expected type Volume.", "obj");
            return CompareTo((Volume) obj);
        }

        public int CompareTo(Volume other)
        {
            return CubicMeters.CompareTo(other.CubicMeters);
        }

        public static bool operator <=(Volume left, Volume right)
        {
            return left.CubicMeters <= right.CubicMeters;
        }

        public static bool operator >=(Volume left, Volume right)
        {
            return left.CubicMeters >= right.CubicMeters;
        }

        public static bool operator <(Volume left, Volume right)
        {
            return left.CubicMeters < right.CubicMeters;
        }

        public static bool operator >(Volume left, Volume right)
        {
            return left.CubicMeters > right.CubicMeters;
        }

        public static bool operator ==(Volume left, Volume right)
        {
            return left.CubicMeters == right.CubicMeters;
        }

        public static bool operator !=(Volume left, Volume right)
        {
            return left.CubicMeters != right.CubicMeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CubicMeters.Equals(((Volume) obj).CubicMeters);
        }

        public override int GetHashCode()
        {
            return CubicMeters.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", CubicMeters, UnitSystem.Create().GetDefaultAbbreviation(Unit.CubicMeter));
        }
    }
} 
