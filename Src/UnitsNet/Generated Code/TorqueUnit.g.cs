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
    /// Torque, moment or moment of force (see the terminology below), is the tendency of a force to rotate an object about an axis,[1] fulcrum, or pivot. Just as a force is a push or a pull, a torque can be thought of as a twist to an object. Mathematically, torque is defined as the cross product of the lever-arm distance and force, which tends to produce rotation. Loosely speaking, torque is a measure of the turning force on an object such as a bolt or a flywheel. For example, pushing or pulling the handle of a wrench connected to a nut or bolt produces a torque (turning force) that loosens or tightens the nut or bolt.
    /// </summary>
    public partial struct Torque : IComparable, IComparable<Torque>
    {
        /// <summary>
        /// Base unit of Torque.
        /// </summary>
        public readonly double Newtonmeters;

        public Torque(double newtonmeters) : this()
        {
            Newtonmeters = newtonmeters;
        }

        #region Unit Properties

        #endregion

        #region Static 

        public static Torque Zero
        {
            get { return new Torque(); }
        }
        
        public static Torque FromNewtonmeters(double newtonmeters)
        {
            return new Torque(newtonmeters*1);
        }

        #endregion

        #region Arithmetic Operators

        public static Torque operator -(Torque right)
        {
            return new Torque(-right.Newtonmeters);
        }

        public static Torque operator +(Torque left, Torque right)
        {
            return new Torque(left.Newtonmeters + right.Newtonmeters);
        }

        public static Torque operator -(Torque left, Torque right)
        {
            return new Torque(left.Newtonmeters - right.Newtonmeters);
        }

        public static Torque operator *(double left, Torque right)
        {
            return new Torque(left*right.Newtonmeters);
        }

        public static Torque operator *(Torque left, double right)
        {
            return new Torque(left.Newtonmeters*right);
        }

        public static Torque operator /(Torque left, double right)
        {
            return new Torque(left.Newtonmeters/right);
        }

        public static double operator /(Torque left, Torque right)
        {
            return left.Newtonmeters/right.Newtonmeters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Torque)) throw new ArgumentException("Expected type Torque.", "obj");
            return CompareTo((Torque) obj);
        }

        public int CompareTo(Torque other)
        {
            return Newtonmeters.CompareTo(other.Newtonmeters);
        }

        public static bool operator <=(Torque left, Torque right)
        {
            return left.Newtonmeters <= right.Newtonmeters;
        }

        public static bool operator >=(Torque left, Torque right)
        {
            return left.Newtonmeters >= right.Newtonmeters;
        }

        public static bool operator <(Torque left, Torque right)
        {
            return left.Newtonmeters < right.Newtonmeters;
        }

        public static bool operator >(Torque left, Torque right)
        {
            return left.Newtonmeters > right.Newtonmeters;
        }

        public static bool operator ==(Torque left, Torque right)
        {
            return left.Newtonmeters == right.Newtonmeters;
        }

        public static bool operator !=(Torque left, Torque right)
        {
            return left.Newtonmeters != right.Newtonmeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Newtonmeters.Equals(((Torque) obj).Newtonmeters);
        }

        public override int GetHashCode()
        {
            return Newtonmeters.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Newtonmeters, UnitSystem.Create().GetDefaultAbbreviation(Unit.Newtonmeter));
        }
    }
} 
