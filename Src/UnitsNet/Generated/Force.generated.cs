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
    /// In physics, a force is any influence that causes an object to undergo a certain change, either concerning its movement, direction, or geometrical construction. In other words, a force can cause an object with mass to change its velocity (which includes to begin moving from a state of rest), i.e., to accelerate, or a flexible object to deform, or both. Force can also be described by intuitive concepts such as a push or a pull. A force has both magnitude and direction, making it a vector quantity. It is measured in the SI unit of newtons and represented by the symbol F.
    /// </summary>
    public partial struct Force : IComparable, IComparable<Force>
    {
        /// <summary>
        /// Base unit of Force.
        /// </summary>
        public readonly double Newtons;

        public Force(double newtons) : this()
        {
            Newtons = newtons;
        }

        #region Unit Properties

        public double Dyne
        {
            get { return Newtons/1E-05; }
        }

        public double KilogramsForce
        {
            get { return Newtons/9.80665002864; }
        }

        public double Kilonewtons
        {
            get { return Newtons/1000; }
        }

        public double KiloPonds
        {
            get { return Newtons/9.80665002864; }
        }

        public double Poundals
        {
            get { return Newtons/0.13825502798973; }
        }

        public double PoundForces
        {
            get { return Newtons/4.44822161526051; }
        }

        #endregion

        #region Static 

        public static Force Zero
        {
            get { return new Force(); }
        }
        
        public static Force FromDyne(double dyne)
        {
            return new Force(dyne*1E-05);
        }

        public static Force FromKilogramsForce(double kilogramsforce)
        {
            return new Force(kilogramsforce*9.80665002864);
        }

        public static Force FromKilonewtons(double kilonewtons)
        {
            return new Force(kilonewtons*1000);
        }

        public static Force FromKiloPonds(double kiloponds)
        {
            return new Force(kiloponds*9.80665002864);
        }

        public static Force FromNewtons(double newtons)
        {
            return new Force(newtons*1);
        }

        public static Force FromPoundals(double poundals)
        {
            return new Force(poundals*0.13825502798973);
        }

        public static Force FromPoundForces(double poundforces)
        {
            return new Force(poundforces*4.44822161526051);
        }

        #endregion

        #region Arithmetic Operators

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
            return string.Format("{0:0.##} {1}", Newtons, UnitSystem.Create().GetDefaultAbbreviation(Unit.Newton));
        }
    }
} 
