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

        /// <summary>
        /// Get Volume in Centiliters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Centiliters and y is value in base unit CubicMeters.</remarks>
        public double Centiliters
        {
            get { return (CubicMeters - (0)) / 1E-05; }
        }

        /// <summary>
        /// Get Volume in CubicCentimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicCentimeters and y is value in base unit CubicMeters.</remarks>
        public double CubicCentimeters
        {
            get { return (CubicMeters - (0)) / 1E-06; }
        }

        /// <summary>
        /// Get Volume in CubicDecimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicDecimeters and y is value in base unit CubicMeters.</remarks>
        public double CubicDecimeters
        {
            get { return (CubicMeters - (0)) / 0.001; }
        }

        /// <summary>
        /// Get Volume in CubicFeet.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicFeet and y is value in base unit CubicMeters.</remarks>
        public double CubicFeet
        {
            get { return (CubicMeters - (0)) / 0.0283168; }
        }

        /// <summary>
        /// Get Volume in CubicInches.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicInches and y is value in base unit CubicMeters.</remarks>
        public double CubicInches
        {
            get { return (CubicMeters - (0)) / 1.6387E-05; }
        }

        /// <summary>
        /// Get Volume in CubicKilometers.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicKilometers and y is value in base unit CubicMeters.</remarks>
        public double CubicKilometers
        {
            get { return (CubicMeters - (0)) / 1000000000; }
        }

        /// <summary>
        /// Get Volume in CubicMiles.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicMiles and y is value in base unit CubicMeters.</remarks>
        public double CubicMiles
        {
            get { return (CubicMeters - (0)) / 4168181830; }
        }

        /// <summary>
        /// Get Volume in CubicMillimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicMillimeters and y is value in base unit CubicMeters.</remarks>
        public double CubicMillimeters
        {
            get { return (CubicMeters - (0)) / 1E-09; }
        }

        /// <summary>
        /// Get Volume in CubicYards.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicYards and y is value in base unit CubicMeters.</remarks>
        public double CubicYards
        {
            get { return (CubicMeters - (0)) / 0.764554858; }
        }

        /// <summary>
        /// Get Volume in Deciliters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Deciliters and y is value in base unit CubicMeters.</remarks>
        public double Deciliters
        {
            get { return (CubicMeters - (0)) / 0.0001; }
        }

        /// <summary>
        /// Get Volume in Hectoliters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Hectoliters and y is value in base unit CubicMeters.</remarks>
        public double Hectoliters
        {
            get { return (CubicMeters - (0)) / 0.1; }
        }

        /// <summary>
        /// Get Volume in ImperialGallons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in ImperialGallons and y is value in base unit CubicMeters.</remarks>
        public double ImperialGallons
        {
            get { return (CubicMeters - (0)) / 0.00454609000000181; }
        }

        /// <summary>
        /// Get Volume in ImperialOunces.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in ImperialOunces and y is value in base unit CubicMeters.</remarks>
        public double ImperialOunces
        {
            get { return (CubicMeters - (0)) / 2.84130624999629E-05; }
        }

        /// <summary>
        /// Get Volume in Liters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Liters and y is value in base unit CubicMeters.</remarks>
        public double Liters
        {
            get { return (CubicMeters - (0)) / 0.001; }
        }

        /// <summary>
        /// Get Volume in Milliliters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Milliliters and y is value in base unit CubicMeters.</remarks>
        public double Milliliters
        {
            get { return (CubicMeters - (0)) / 1E-06; }
        }

        /// <summary>
        /// Get Volume in UsGallons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in UsGallons and y is value in base unit CubicMeters.</remarks>
        public double UsGallons
        {
            get { return (CubicMeters - (0)) / 0.00378541; }
        }

        /// <summary>
        /// Get Volume in UsOunces.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in UsOunces and y is value in base unit CubicMeters.</remarks>
        public double UsOunces
        {
            get { return (CubicMeters - (0)) / 2.95735295625376E-05; }
        }

        #endregion

        #region Static 

        public static Volume Zero
        {
            get { return new Volume(); }
        }
        
        /// <summary>
        /// Get Volume from Centiliters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Centiliters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCentiliters(double centiliters)
        {
            return new Volume(1E-05 * centiliters + 0);
        }

        /// <summary>
        /// Get Volume from CubicCentimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicCentimeters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicCentimeters(double cubiccentimeters)
        {
            return new Volume(1E-06 * cubiccentimeters + 0);
        }

        /// <summary>
        /// Get Volume from CubicDecimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicDecimeters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicDecimeters(double cubicdecimeters)
        {
            return new Volume(0.001 * cubicdecimeters + 0);
        }

        /// <summary>
        /// Get Volume from CubicFeet.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicFeet and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicFeet(double cubicfeet)
        {
            return new Volume(0.0283168 * cubicfeet + 0);
        }

        /// <summary>
        /// Get Volume from CubicInches.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicInches and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicInches(double cubicinches)
        {
            return new Volume(1.6387E-05 * cubicinches + 0);
        }

        /// <summary>
        /// Get Volume from CubicKilometers.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicKilometers and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicKilometers(double cubickilometers)
        {
            return new Volume(1000000000 * cubickilometers + 0);
        }

        /// <summary>
        /// Get Volume from CubicMeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicMeters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicMeters(double cubicmeters)
        {
            return new Volume(1 * cubicmeters + 0);
        }

        /// <summary>
        /// Get Volume from CubicMiles.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicMiles and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicMiles(double cubicmiles)
        {
            return new Volume(4168181830 * cubicmiles + 0);
        }

        /// <summary>
        /// Get Volume from CubicMillimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicMillimeters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicMillimeters(double cubicmillimeters)
        {
            return new Volume(1E-09 * cubicmillimeters + 0);
        }

        /// <summary>
        /// Get Volume from CubicYards.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicYards and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicYards(double cubicyards)
        {
            return new Volume(0.764554858 * cubicyards + 0);
        }

        /// <summary>
        /// Get Volume from Deciliters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Deciliters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromDeciliters(double deciliters)
        {
            return new Volume(0.0001 * deciliters + 0);
        }

        /// <summary>
        /// Get Volume from Hectoliters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Hectoliters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromHectoliters(double hectoliters)
        {
            return new Volume(0.1 * hectoliters + 0);
        }

        /// <summary>
        /// Get Volume from ImperialGallons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in ImperialGallons and y is value in base unit CubicMeters.</remarks>
        public static Volume FromImperialGallons(double imperialgallons)
        {
            return new Volume(0.00454609000000181 * imperialgallons + 0);
        }

        /// <summary>
        /// Get Volume from ImperialOunces.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in ImperialOunces and y is value in base unit CubicMeters.</remarks>
        public static Volume FromImperialOunces(double imperialounces)
        {
            return new Volume(2.84130624999629E-05 * imperialounces + 0);
        }

        /// <summary>
        /// Get Volume from Liters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Liters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromLiters(double liters)
        {
            return new Volume(0.001 * liters + 0);
        }

        /// <summary>
        /// Get Volume from Milliliters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Milliliters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromMilliliters(double milliliters)
        {
            return new Volume(1E-06 * milliliters + 0);
        }

        /// <summary>
        /// Get Volume from UsGallons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in UsGallons and y is value in base unit CubicMeters.</remarks>
        public static Volume FromUsGallons(double usgallons)
        {
            return new Volume(0.00378541 * usgallons + 0);
        }

        /// <summary>
        /// Get Volume from UsOunces.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in UsOunces and y is value in base unit CubicMeters.</remarks>
        public static Volume FromUsOunces(double usounces)
        {
            return new Volume(2.95735295625376E-05 * usounces + 0);
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
