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
    /// Pressure (symbol: P or p) is the ratio of force to the area over which that force is distributed. Pressure is force per unit area applied in a direction perpendicular to the surface of an object. Gauge pressure (also spelled gage pressure)[a] is the pressure relative to the local atmospheric or ambient pressure. Pressure is measured in any unit of force divided by any unit of area. The SI unit of pressure is the newton per square metre, which is called the pascal (Pa) after the seventeenth-century philosopher and scientist Blaise Pascal. A pressure of 1 Pa is small; it approximately equals the pressure exerted by a dollar bill resting flat on a table. Everyday pressures are often stated in kilopascals (1 kPa = 1000 Pa).
    /// </summary>
    public partial struct Pressure : IComparable, IComparable<Pressure>
    {
        /// <summary>
        /// Base unit of Pressure.
        /// </summary>
        public readonly double Pascals;

        public Pressure(double pascals) : this()
        {
            Pascals = pascals;
        }

        #region Unit Properties

        /// <summary>
        /// Get Pressure in Atmospheres.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Atmospheres and y is value in base unit Pascals.</remarks>
        public double Atmospheres
        {
            get { return (Pascals - (0)) / 101325; }
        }

        /// <summary>
        /// Get Pressure in Bars.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Bars and y is value in base unit Pascals.</remarks>
        public double Bars
        {
            get { return (Pascals - (0)) / 100000; }
        }

        /// <summary>
        /// Get Pressure in KilogramForcePerSquareCentimeter.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in KilogramForcePerSquareCentimeter and y is value in base unit Pascals.</remarks>
        public double KilogramForcePerSquareCentimeter
        {
            get { return (Pascals - (0)) / 98066.5; }
        }

        /// <summary>
        /// Get Pressure in Kilopascals.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Kilopascals and y is value in base unit Pascals.</remarks>
        public double Kilopascals
        {
            get { return (Pascals - (0)) / 1000; }
        }

        /// <summary>
        /// Get Pressure in Megapascals.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Megapascals and y is value in base unit Pascals.</remarks>
        public double Megapascals
        {
            get { return (Pascals - (0)) / 1000000; }
        }

        /// <summary>
        /// Get Pressure in NewtonsPerSquareCentimeter.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in NewtonsPerSquareCentimeter and y is value in base unit Pascals.</remarks>
        public double NewtonsPerSquareCentimeter
        {
            get { return (Pascals - (0)) / 10000; }
        }

        /// <summary>
        /// Get Pressure in NewtonsPerSquareMeter.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in NewtonsPerSquareMeter and y is value in base unit Pascals.</remarks>
        public double NewtonsPerSquareMeter
        {
            get { return (Pascals - (0)) / 1; }
        }

        /// <summary>
        /// Get Pressure in NewtonsPerSquareMillimeter.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in NewtonsPerSquareMillimeter and y is value in base unit Pascals.</remarks>
        public double NewtonsPerSquareMillimeter
        {
            get { return (Pascals - (0)) / 1000000; }
        }

        /// <summary>
        /// Get Pressure in Psi.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Psi and y is value in base unit Pascals.</remarks>
        public double Psi
        {
            get { return (Pascals - (0)) / 6894.64975179; }
        }

        /// <summary>
        /// Get Pressure in TechnicalAtmospheres.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in TechnicalAtmospheres and y is value in base unit Pascals.</remarks>
        public double TechnicalAtmospheres
        {
            get { return (Pascals - (0)) / 98068.0592331; }
        }

        /// <summary>
        /// Get Pressure in Torrs.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Torrs and y is value in base unit Pascals.</remarks>
        public double Torrs
        {
            get { return (Pascals - (0)) / 133.32266752; }
        }

        #endregion

        #region Static 

        public static Pressure Zero
        {
            get { return new Pressure(); }
        }
        
        /// <summary>
        /// Get Pressure from Atmospheres.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Atmospheres and y is value in base unit Pascals.</remarks>
        public static Pressure FromAtmospheres(double atmospheres)
        {
            return new Pressure(101325 * atmospheres + 0);
        }

        /// <summary>
        /// Get Pressure from Bars.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Bars and y is value in base unit Pascals.</remarks>
        public static Pressure FromBars(double bars)
        {
            return new Pressure(100000 * bars + 0);
        }

        /// <summary>
        /// Get Pressure from KilogramForcePerSquareCentimeter.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in KilogramForcePerSquareCentimeter and y is value in base unit Pascals.</remarks>
        public static Pressure FromKilogramForcePerSquareCentimeter(double kilogramforcepersquarecentimeter)
        {
            return new Pressure(98066.5 * kilogramforcepersquarecentimeter + 0);
        }

        /// <summary>
        /// Get Pressure from Kilopascals.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Kilopascals and y is value in base unit Pascals.</remarks>
        public static Pressure FromKilopascals(double kilopascals)
        {
            return new Pressure(1000 * kilopascals + 0);
        }

        /// <summary>
        /// Get Pressure from Megapascals.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Megapascals and y is value in base unit Pascals.</remarks>
        public static Pressure FromMegapascals(double megapascals)
        {
            return new Pressure(1000000 * megapascals + 0);
        }

        /// <summary>
        /// Get Pressure from NewtonsPerSquareCentimeter.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in NewtonsPerSquareCentimeter and y is value in base unit Pascals.</remarks>
        public static Pressure FromNewtonsPerSquareCentimeter(double newtonspersquarecentimeter)
        {
            return new Pressure(10000 * newtonspersquarecentimeter + 0);
        }

        /// <summary>
        /// Get Pressure from NewtonsPerSquareMeter.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in NewtonsPerSquareMeter and y is value in base unit Pascals.</remarks>
        public static Pressure FromNewtonsPerSquareMeter(double newtonspersquaremeter)
        {
            return new Pressure(1 * newtonspersquaremeter + 0);
        }

        /// <summary>
        /// Get Pressure from NewtonsPerSquareMillimeter.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in NewtonsPerSquareMillimeter and y is value in base unit Pascals.</remarks>
        public static Pressure FromNewtonsPerSquareMillimeter(double newtonspersquaremillimeter)
        {
            return new Pressure(1000000 * newtonspersquaremillimeter + 0);
        }

        /// <summary>
        /// Get Pressure from Pascals.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Pascals and y is value in base unit Pascals.</remarks>
        public static Pressure FromPascals(double pascals)
        {
            return new Pressure(1 * pascals + 0);
        }

        /// <summary>
        /// Get Pressure from Psi.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Psi and y is value in base unit Pascals.</remarks>
        public static Pressure FromPsi(double psi)
        {
            return new Pressure(6894.64975179 * psi + 0);
        }

        /// <summary>
        /// Get Pressure from TechnicalAtmospheres.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in TechnicalAtmospheres and y is value in base unit Pascals.</remarks>
        public static Pressure FromTechnicalAtmospheres(double technicalatmospheres)
        {
            return new Pressure(98068.0592331 * technicalatmospheres + 0);
        }

        /// <summary>
        /// Get Pressure from Torrs.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Torrs and y is value in base unit Pascals.</remarks>
        public static Pressure FromTorrs(double torrs)
        {
            return new Pressure(133.32266752 * torrs + 0);
        }

        #endregion

        #region Arithmetic Operators

        public static Pressure operator -(Pressure right)
        {
            return new Pressure(-right.Pascals);
        }

        public static Pressure operator +(Pressure left, Pressure right)
        {
            return new Pressure(left.Pascals + right.Pascals);
        }

        public static Pressure operator -(Pressure left, Pressure right)
        {
            return new Pressure(left.Pascals - right.Pascals);
        }

        public static Pressure operator *(double left, Pressure right)
        {
            return new Pressure(left*right.Pascals);
        }

        public static Pressure operator *(Pressure left, double right)
        {
            return new Pressure(left.Pascals*right);
        }

        public static Pressure operator /(Pressure left, double right)
        {
            return new Pressure(left.Pascals/right);
        }

        public static double operator /(Pressure left, Pressure right)
        {
            return left.Pascals/right.Pascals;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Pressure)) throw new ArgumentException("Expected type Pressure.", "obj");
            return CompareTo((Pressure) obj);
        }

        public int CompareTo(Pressure other)
        {
            return Pascals.CompareTo(other.Pascals);
        }

        public static bool operator <=(Pressure left, Pressure right)
        {
            return left.Pascals <= right.Pascals;
        }

        public static bool operator >=(Pressure left, Pressure right)
        {
            return left.Pascals >= right.Pascals;
        }

        public static bool operator <(Pressure left, Pressure right)
        {
            return left.Pascals < right.Pascals;
        }

        public static bool operator >(Pressure left, Pressure right)
        {
            return left.Pascals > right.Pascals;
        }

        public static bool operator ==(Pressure left, Pressure right)
        {
            return left.Pascals == right.Pascals;
        }

        public static bool operator !=(Pressure left, Pressure right)
        {
            return left.Pascals != right.Pascals;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Pascals.Equals(((Pressure) obj).Pascals);
        }

        public override int GetHashCode()
        {
            return Pascals.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Pascals, UnitSystem.Create().GetDefaultAbbreviation(Unit.Pascal));
        }
    }
} 
