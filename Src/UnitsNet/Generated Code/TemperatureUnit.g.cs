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
    /// A temperature is a numerical measure of hot or cold. Its measurement is by detection of heat radiation or particle velocity or kinetic energy, or by the bulk behavior of a thermometric material. It may be calibrated in any of various temperature scales, Celsius, Fahrenheit, Kelvin, etc. The fundamental physical definition of temperature is provided by thermodynamics.
    /// </summary>
    public partial struct Temperature : IComparable, IComparable<Temperature>
    {
        /// <summary>
        /// Base unit of Temperature.
        /// </summary>
        public readonly double Kelvins;

        public Temperature(double kelvins) : this()
        {
            Kelvins = kelvins;
        }

        #region Unit Properties

        /// <summary>
        /// Get Temperature in DegreesCelsius.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in DegreesCelsius and y is value in base unit Kelvins.</remarks>
        public double DegreesCelsius
        {
            get { return (Kelvins - (273.15)) / 1; }
        }

        /// <summary>
        /// Get Temperature in DegreesDelisle.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in DegreesDelisle and y is value in base unit Kelvins.</remarks>
        public double DegreesDelisle
        {
            get { return (Kelvins - (373.15)) / -0.666666666666667; }
        }

        /// <summary>
        /// Get Temperature in DegreesFahrenheit.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in DegreesFahrenheit and y is value in base unit Kelvins.</remarks>
        public double DegreesFahrenheit
        {
            get { return (Kelvins - (255.372222222222)) / 0.555555555555556; }
        }

        /// <summary>
        /// Get Temperature in DegreesNewton.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in DegreesNewton and y is value in base unit Kelvins.</remarks>
        public double DegreesNewton
        {
            get { return (Kelvins - (273.15)) / 3.03030303030303; }
        }

        /// <summary>
        /// Get Temperature in DegreesRankine.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in DegreesRankine and y is value in base unit Kelvins.</remarks>
        public double DegreesRankine
        {
            get { return (Kelvins - (0)) / 0.555555555555556; }
        }

        /// <summary>
        /// Get Temperature in DegreesReaumur.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in DegreesReaumur and y is value in base unit Kelvins.</remarks>
        public double DegreesReaumur
        {
            get { return (Kelvins - (273.15)) / 1.25; }
        }

        /// <summary>
        /// Get Temperature in DegreesRoemer.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in DegreesRoemer and y is value in base unit Kelvins.</remarks>
        public double DegreesRoemer
        {
            get { return (Kelvins - (258.864285714286)) / 1.9047619047619; }
        }

        #endregion

        #region Static 

        public static Temperature Zero
        {
            get { return new Temperature(); }
        }
        
        /// <summary>
        /// Get Temperature from DegreesCelsius.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in DegreesCelsius and y is value in base unit Kelvins.</remarks>
        public static Temperature FromDegreesCelsius(double degreescelsius)
        {
            return new Temperature(1 * degreescelsius + 273.15);
        }

        /// <summary>
        /// Get Temperature from DegreesDelisle.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in DegreesDelisle and y is value in base unit Kelvins.</remarks>
        public static Temperature FromDegreesDelisle(double degreesdelisle)
        {
            return new Temperature(-0.666666666666667 * degreesdelisle + 373.15);
        }

        /// <summary>
        /// Get Temperature from DegreesFahrenheit.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in DegreesFahrenheit and y is value in base unit Kelvins.</remarks>
        public static Temperature FromDegreesFahrenheit(double degreesfahrenheit)
        {
            return new Temperature(0.555555555555556 * degreesfahrenheit + 255.372222222222);
        }

        /// <summary>
        /// Get Temperature from DegreesNewton.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in DegreesNewton and y is value in base unit Kelvins.</remarks>
        public static Temperature FromDegreesNewton(double degreesnewton)
        {
            return new Temperature(3.03030303030303 * degreesnewton + 273.15);
        }

        /// <summary>
        /// Get Temperature from DegreesRankine.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in DegreesRankine and y is value in base unit Kelvins.</remarks>
        public static Temperature FromDegreesRankine(double degreesrankine)
        {
            return new Temperature(0.555555555555556 * degreesrankine + 0);
        }

        /// <summary>
        /// Get Temperature from DegreesReaumur.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in DegreesReaumur and y is value in base unit Kelvins.</remarks>
        public static Temperature FromDegreesReaumur(double degreesreaumur)
        {
            return new Temperature(1.25 * degreesreaumur + 273.15);
        }

        /// <summary>
        /// Get Temperature from DegreesRoemer.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in DegreesRoemer and y is value in base unit Kelvins.</remarks>
        public static Temperature FromDegreesRoemer(double degreesroemer)
        {
            return new Temperature(1.9047619047619 * degreesroemer + 258.864285714286);
        }

        /// <summary>
        /// Get Temperature from Kelvins.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Kelvins and y is value in base unit Kelvins.</remarks>
        public static Temperature FromKelvins(double kelvins)
        {
            return new Temperature(1 * kelvins + 0);
        }

        #endregion

        #region Arithmetic Operators

        public static Temperature operator -(Temperature right)
        {
            return new Temperature(-right.Kelvins);
        }

        public static Temperature operator +(Temperature left, Temperature right)
        {
            return new Temperature(left.Kelvins + right.Kelvins);
        }

        public static Temperature operator -(Temperature left, Temperature right)
        {
            return new Temperature(left.Kelvins - right.Kelvins);
        }

        public static Temperature operator *(double left, Temperature right)
        {
            return new Temperature(left*right.Kelvins);
        }

        public static Temperature operator *(Temperature left, double right)
        {
            return new Temperature(left.Kelvins*right);
        }

        public static Temperature operator /(Temperature left, double right)
        {
            return new Temperature(left.Kelvins/right);
        }

        public static double operator /(Temperature left, Temperature right)
        {
            return left.Kelvins/right.Kelvins;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Temperature)) throw new ArgumentException("Expected type Temperature.", "obj");
            return CompareTo((Temperature) obj);
        }

        public int CompareTo(Temperature other)
        {
            return Kelvins.CompareTo(other.Kelvins);
        }

        public static bool operator <=(Temperature left, Temperature right)
        {
            return left.Kelvins <= right.Kelvins;
        }

        public static bool operator >=(Temperature left, Temperature right)
        {
            return left.Kelvins >= right.Kelvins;
        }

        public static bool operator <(Temperature left, Temperature right)
        {
            return left.Kelvins < right.Kelvins;
        }

        public static bool operator >(Temperature left, Temperature right)
        {
            return left.Kelvins > right.Kelvins;
        }

        public static bool operator ==(Temperature left, Temperature right)
        {
            return left.Kelvins == right.Kelvins;
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            return left.Kelvins != right.Kelvins;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Kelvins.Equals(((Temperature) obj).Kelvins);
        }

        public override int GetHashCode()
        {
            return Kelvins.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Kelvins, UnitSystem.Create().GetDefaultAbbreviation(Unit.Kelvin));
        }
    }
} 
