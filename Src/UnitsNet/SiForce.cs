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
    ///     A class for representing force, according to the International System of Units (SI).
    /// </summary>
    public struct SiForce : IComparable, IComparable<SiForce>
    {
        private const double Gravity = 9.80665002864;

        /// <summary>
        ///     Returns a Newton representation of the force instance.
        /// </summary>
        public readonly double Newtons;

        private SiForce(double newtons) : this()
        {
            Newtons = newtons;
        }

        public double Kilograms
        {
            get { return Newtons/Gravity; }
            //set { Newtons = value * SiUnits.Gravity; }
        }

        #region Static 

        public static SiForce Zero
        {
            get { return new SiForce(); }
        }

        public static SiForce FromKilograms(double kilograms)
        {
            return new SiForce(Gravity*kilograms);
        }

        public static SiForce FromPressureByArea(SiPressure p, SiDistance2d area)
        {
            double metersSquared = area.Meters.X*area.Meters.Y;
            double newtons = p.Pascals*metersSquared;
            return new SiForce(newtons);
        }

        public static SiForce FromNewtons(double newtons)
        {
            return new SiForce(newtons);
        }

        #endregion

        #region Arithmetic operators

        public static SiForce operator -(SiForce right)
        {
            return new SiForce(-right.Newtons);
        }

        public static SiForce operator +(SiForce left, SiForce right)
        {
            return new SiForce(left.Newtons + right.Newtons);
        }

        public static SiForce operator -(SiForce left, SiForce right)
        {
            return new SiForce(left.Newtons - right.Newtons);
        }

        public static SiForce operator *(double left, SiForce right)
        {
            return new SiForce(left*right.Newtons);
        }

        public static SiForce operator /(SiForce left, double right)
        {
            return new SiForce(left.Newtons/right);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SiForce)) throw new ArgumentException("Expected type SiForce.", "obj");
            return CompareTo((SiForce) obj);
        }

        public int CompareTo(SiForce other)
        {
            return Newtons.CompareTo(other.Newtons);
        }

        public static bool operator <=(SiForce left, SiForce right)
        {
            return left.Newtons <= right.Newtons;
        }

        public static bool operator >=(SiForce left, SiForce right)
        {
            return left.Newtons >= right.Newtons;
        }

        public static bool operator <(SiForce left, SiForce right)
        {
            return left.Newtons < right.Newtons;
        }

        public static bool operator >(SiForce left, SiForce right)
        {
            return left.Newtons > right.Newtons;
        }

        #endregion

        public override string ToString()
        {
            return Newtons + " " + SiUnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(SiUnit.Newton);
        }
    }
}