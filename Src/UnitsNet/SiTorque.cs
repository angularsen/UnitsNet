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
    ///     A class for representing torque, according to the International System of Units (SI).
    /// </summary>
    public class SiTorque : IComparable, IComparable<SiTorque>
    {
        /// <summary>
        ///     Returns a newtonmeter representation of the torque.
        /// </summary>
        public readonly double Newtonmeters;


        private SiTorque(double newtonmeters)
        {
            Newtonmeters = newtonmeters;
        }

        public override string ToString()
        {
            return Newtonmeters.ToString("#0.0") + " " +
                   SiUnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(SiUnit.Newtonmeter);
        }

        #region Static

        public static SiTorque FromNewtonmeters(double newtonmeters)
        {
            return new SiTorque(newtonmeters);
        }

        #endregion

        #region Arithmetic operators

        /// <summary>
        ///     This operator overload is only intended to be used like -MyDistance, and will
        ///     throw an exception if left side is anything but zero.
        /// </summary>
        /// <param name="right">The SITorque to negativize.</param>
        /// <returns></returns>
        public static SiTorque operator -(SiTorque right)
        {
            return new SiTorque(-right.Newtonmeters);
        }

        public static SiTorque operator +(SiTorque left, SiTorque right)
        {
            return new SiTorque(left.Newtonmeters + right.Newtonmeters);
        }

        public static SiTorque operator -(SiTorque left, SiTorque right)
        {
            return new SiTorque(left.Newtonmeters - right.Newtonmeters);
        }

        public static SiTorque operator *(double left, SiTorque right)
        {
            return new SiTorque(left*right.Newtonmeters);
        }

        public static SiTorque operator /(SiTorque left, double right)
        {
            return new SiTorque(left.Newtonmeters/right);
        }

        #endregion

        #region Equality

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SiTorque)) throw new ArgumentException("Expected type SiTorque.", "obj");
            return CompareTo((SiTorque) obj);
        }

        public int CompareTo(SiTorque other)
        {
            return Newtonmeters.CompareTo(other.Newtonmeters);
        }

        public static bool operator <=(SiTorque left, SiTorque right)
        {
            return left.Newtonmeters <= right.Newtonmeters;
        }

        public static bool operator >=(SiTorque left, SiTorque right)
        {
            return left.Newtonmeters >= right.Newtonmeters;
        }

        public static bool operator <(SiTorque left, SiTorque right)
        {
            return left.Newtonmeters < right.Newtonmeters;
        }

        public static bool operator >(SiTorque left, SiTorque right)
        {
            return left.Newtonmeters > right.Newtonmeters;
        }

        #endregion
    }
}