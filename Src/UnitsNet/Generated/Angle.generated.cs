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
    /// In geometry, an angle is the figure formed by two rays, called the sides of the angle, sharing a common endpoint, called the vertex of the angle.
    /// </summary>
    public partial struct Angle : IComparable, IComparable<Angle>
    {
        /// <summary>
        /// Base unit of Angle.
        /// </summary>
        public readonly double Degrees;

        public Angle(double degrees) : this()
        {
            Degrees = degrees;
        }

        #region Unit Properties

        public double Gradians
        {
            get { return Degrees/1.11111111111111; }
        }

        public double Radians
        {
            get { return Degrees/0.0174532925199433; }
        }

        #endregion

        #region Static 

        public static Angle Zero
        {
            get { return new Angle(); }
        }
        
        public static Angle FromDegrees(double degrees)
        {
            return new Angle(degrees*1);
        }

        public static Angle FromGradians(double gradians)
        {
            return new Angle(gradians*1.11111111111111);
        }

        public static Angle FromRadians(double radians)
        {
            return new Angle(radians*0.0174532925199433);
        }

        #endregion

        #region Arithmetic Operators

        public static Angle operator -(Angle right)
        {
            return new Angle(-right.Degrees);
        }

        public static Angle operator +(Angle left, Angle right)
        {
            return new Angle(left.Degrees + right.Degrees);
        }

        public static Angle operator -(Angle left, Angle right)
        {
            return new Angle(left.Degrees - right.Degrees);
        }

        public static Angle operator *(double left, Angle right)
        {
            return new Angle(left*right.Degrees);
        }

        public static Angle operator *(Angle left, double right)
        {
            return new Angle(left.Degrees*right);
        }

        public static Angle operator /(Angle left, double right)
        {
            return new Angle(left.Degrees/right);
        }

        public static double operator /(Angle left, Angle right)
        {
            return left.Degrees/right.Degrees;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Angle)) throw new ArgumentException("Expected type Angle.", "obj");
            return CompareTo((Angle) obj);
        }

        public int CompareTo(Angle other)
        {
            return Degrees.CompareTo(other.Degrees);
        }

        public static bool operator <=(Angle left, Angle right)
        {
            return left.Degrees <= right.Degrees;
        }

        public static bool operator >=(Angle left, Angle right)
        {
            return left.Degrees >= right.Degrees;
        }

        public static bool operator <(Angle left, Angle right)
        {
            return left.Degrees < right.Degrees;
        }

        public static bool operator >(Angle left, Angle right)
        {
            return left.Degrees > right.Degrees;
        }

        public static bool operator ==(Angle left, Angle right)
        {
            return left.Degrees == right.Degrees;
        }

        public static bool operator !=(Angle left, Angle right)
        {
            return left.Degrees != right.Degrees;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Degrees.Equals(((Angle) obj).Degrees);
        }

        public override int GetHashCode()
        {
            return Degrees.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Degrees, UnitSystem.Create().GetDefaultAbbreviation(Unit.Degree));
        }
    }
} 
