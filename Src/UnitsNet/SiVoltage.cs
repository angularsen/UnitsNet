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
    ///     A class for representing electrical tension in SI units.
    /// </summary>
    public class SiVoltage : IComparable, IComparable<SiVoltage>
    {
        /// <summary>
        ///     Returns a volt representation of the voltage instance.
        /// </summary>
        public readonly double Volts;

        public SiVoltage(double volts)
        {
            Volts = volts;
        }

        public override string ToString()
        {
            return Volts + " " + UnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(Unit.Volt);
        }

        #region Static

        public static SiVoltage FromVolts(double volts)
        {
            return new SiVoltage(volts);
        }

        #endregion

        #region Arithmetic operators

        public static SiVoltage operator -(SiVoltage right)
        {
            return new SiVoltage(-right.Volts);
        }

        public static SiVoltage operator +(SiVoltage left, SiVoltage right)
        {
            return new SiVoltage(left.Volts + right.Volts);
        }

        public static SiVoltage operator -(SiVoltage left, SiVoltage right)
        {
            return new SiVoltage(left.Volts - right.Volts);
        }

        public static SiVoltage operator *(double left, SiVoltage right)
        {
            return new SiVoltage(left*right.Volts);
        }

        public static SiVoltage operator /(SiVoltage left, double right)
        {
            return new SiVoltage(left.Volts/right);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SiVoltage)) throw new ArgumentException("Expected type SiVoltage.", "obj");
            return CompareTo((SiVoltage) obj);
        }

        public int CompareTo(SiVoltage other)
        {
            return Volts.CompareTo(other.Volts);
        }

        public static bool operator <=(SiVoltage left, SiVoltage right)
        {
            return left.Volts <= right.Volts;
        }

        public static bool operator >=(SiVoltage left, SiVoltage right)
        {
            return left.Volts >= right.Volts;
        }

        public static bool operator <(SiVoltage left, SiVoltage right)
        {
            return left.Volts < right.Volts;
        }

        public static bool operator >(SiVoltage left, SiVoltage right)
        {
            return left.Volts > right.Volts;
        }

        #endregion
    }
}