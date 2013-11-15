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
        /// Base unit of Pressure in pascals.
        /// </summary>
        public readonly double Pascals;

        public Pressure(double pascals) : this()
        {
            Pascals = pascals;
        }

        #region Unit Properties

        public double Atmospheres
        {
            get { return Pascals/101325; }
        }

        public double Bars
        {
            get { return Pascals/100000; }
        }

        public double KilogramForcePerSquareCentimeter
        {
            get { return Pascals/98066.5; }
        }

        public double Kilopascals
        {
            get { return Pascals/1000; }
        }

        public double Megapascals
        {
            get { return Pascals/1000000; }
        }

        public double NewtonsPerSquareCentimeter
        {
            get { return Pascals/10000; }
        }

        public double NewtonsPerSquareMeter
        {
            get { return Pascals/1; }
        }

        public double NewtonsPerSquareMillimeter
        {
            get { return Pascals/1000000; }
        }

        public double Psi
        {
            get { return Pascals/6894.64975179; }
        }

        public double TechnicalAtmospheres
        {
            get { return Pascals/98068.0592331; }
        }

        public double Torrs
        {
            get { return Pascals/133.32266752; }
        }

        #endregion

        #region Static 

        public static Pressure Zero
        {
            get { return new Pressure(); }
        }
        
        public static Pressure FromAtmospheres(double atmospheres)
        {
            return new Pressure(atmospheres*101325);
        }

        public static Pressure FromBars(double bars)
        {
            return new Pressure(bars*100000);
        }

        public static Pressure FromKilogramForcePerSquareCentimeter(double kilogramforcepersquarecentimeter)
        {
            return new Pressure(kilogramforcepersquarecentimeter*98066.5);
        }

        public static Pressure FromKilopascals(double kilopascals)
        {
            return new Pressure(kilopascals*1000);
        }

        public static Pressure FromMegapascals(double megapascals)
        {
            return new Pressure(megapascals*1000000);
        }

        public static Pressure FromNewtonsPerSquareCentimeter(double newtonspersquarecentimeter)
        {
            return new Pressure(newtonspersquarecentimeter*10000);
        }

        public static Pressure FromNewtonsPerSquareMeter(double newtonspersquaremeter)
        {
            return new Pressure(newtonspersquaremeter*1);
        }

        public static Pressure FromNewtonsPerSquareMillimeter(double newtonspersquaremillimeter)
        {
            return new Pressure(newtonspersquaremillimeter*1000000);
        }

        public static Pressure FromPascals(double pascals)
        {
            return new Pressure(pascals*1);
        }

        public static Pressure FromPsi(double psi)
        {
            return new Pressure(psi*6894.64975179);
        }

        public static Pressure FromTechnicalAtmospheres(double technicalatmospheres)
        {
            return new Pressure(technicalatmospheres*98068.0592331);
        }

        public static Pressure FromTorrs(double torrs)
        {
            return new Pressure(torrs*133.32266752);
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
