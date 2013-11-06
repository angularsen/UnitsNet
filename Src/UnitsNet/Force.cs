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
using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing force.
    /// </summary>
    public struct Force : IComparable, IComparable<Force>
    {
        private const double Gravity = 9.80665002864;

        /// <summary>
        ///     Returns a Newton representation of the force instance.
        /// </summary>
        public readonly double Newtons;

        private Force(double newtons) : this()
        {
            Newtons = newtons;
        }

        public double Kilonewtons
        {
            get { return Newtons*1E-3; }
        }

        public double Dyne
        {
            get { return Newtons*1E5; }
        }

        public double KilogramForce
        {
            get { return Newtons/Gravity; }
        }

        public double KiloPonds
        {
            get { return KilogramForce; }
        }

        public double PoundForce
        {
            get { return 0.22480894309971 * Newtons; }
        }

        public double Poundal
        {
            get { return 7.23301 * Newtons; }
        }

        #region Static 

        public static Force Zero
        {
            get { return new Force(); }
        }

        public static Force FromDyne(double dyn)
        {
            return new Force(dyn*1E-5);
        }

        public static Force FromPoundal(double pdl)
        {
            return new Force(0.13825502798973041652092282466083*pdl);
        }

        public static Force FromPoundForce(double lbf)
        {
            return new Force(4.4482216152605095551842641431421*lbf);
        }

        public static Force FromKilogramForce(double kgf)
        {
            return new Force(Gravity*kgf);
        }

        public static Force FromKiloPonds(double kp)
        {
            return FromKilogramForce(kp);
        }

        public static Force FromNewtons(double newtons)
        {
            return new Force(newtons);
        }

        public static Force FromKilonewtons(double kN)
        {
            return new Force(kN*1E3);
        }

        public static Force FromPressureByArea(Pressure p, Length2d area)
        {
            double metersSquared = area.Meters.X*area.Meters.Y;
            double newtons = p.Pascals*metersSquared;
            return new Force(newtons);
        }

        public static Force FromMassAcceleration(Mass mass, double metersPerSecondSquared)
        {
            return new Force(mass.Kilograms*metersPerSecondSquared);
        }

        #endregion

        #region Arithmetic operators

        public static Force operator -(Force right)
        {
            return new Force(-right.Newtons);
        }

        public static Force operator +(Force left, Force right)
        {
            return new Force(left.Newtons + right.Newtons);
        }

        public static Force operator -(Force left, Force right)
        {
            return new Force(left.Newtons - right.Newtons);
        }

        public static Force operator *(double left, Force right)
        {
            return new Force(left*right.Newtons);
        }

        public static Force operator *(Force left, double right)
        {
            return new Force(left.Newtons*right);
        }

        public static Force operator /(Force left, double right)
        {
            return new Force(left.Newtons/right);
        }

        public static double operator /(Force left, Force right)
        {
            return left.Newtons/right.Newtons;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Force)) throw new ArgumentException("Expected type Force.", "obj");
            return CompareTo((Force) obj);
        }

        public int CompareTo(Force other)
        {
            return Newtons.CompareTo(other.Newtons);
        }

        public static bool operator <=(Force left, Force right)
        {
            return left.Newtons <= right.Newtons;
        }

        public static bool operator >=(Force left, Force right)
        {
            return left.Newtons >= right.Newtons;
        }

        public static bool operator <(Force left, Force right)
        {
            return left.Newtons < right.Newtons;
        }

        public static bool operator >(Force left, Force right)
        {
            return left.Newtons > right.Newtons;
        }

        public static bool operator ==(Force left, Force right)
        {
            return left.Newtons == right.Newtons;
        }

        public static bool operator !=(Force left, Force right)
        {
            return left.Newtons != right.Newtons;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Newtons.Equals(((Force) obj).Newtons);
        }

        public override int GetHashCode()
        {
            return Newtons.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return Newtons + " " + UnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(Unit.Newton);
        }
    }
}