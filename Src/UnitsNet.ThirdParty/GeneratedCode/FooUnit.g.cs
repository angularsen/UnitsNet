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

using UnitsNet.ThirdParty.Extensions;
using System;

// ReSharper disable once CheckNamespace
namespace UnitsNet.ThirdParty
{
    /// <summary>
    /// Example unit to illustrate adding third party units to Units.NET.
    /// </summary>
    public partial struct Foo : IComparable, IComparable<Foo>
    {
        /// <summary>
        /// Base unit of Foo.
        /// </summary>
        public readonly double Bars;

        public Foo(double bars) : this()
        {
            Bars = bars;
        }

        #region Properties

        /// <summary>
        /// Get Foo in BarPlusOnes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in BarPlusOnes and y is value in base unit Bars.</remarks>
        public double BarPlusOnes
        {            
            get { return (Bars - 1) / 1; }
        }

        /// <summary>
        /// Get Foo in BarsTripled.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in BarsTripled and y is value in base unit Bars.</remarks>
        public double BarsTripled
        { 
            get { return Bars / 3; }
        }

        /// <summary>
        /// Get Foo in TwiceThanBars.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in TwiceThanBars and y is value in base unit Bars.</remarks>
        public double TwiceThanBars
        { 
            get { return Bars / 2; }
        }

        #endregion

        #region Static 

        public static Foo Zero
        {
            get { return new Foo(); }
        }
        
        /// <summary>
        /// Get Foo from Bars.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Bars and y is value in base unit Bars.</remarks>
        public static Foo FromBars(double bars)
        {
            return new Foo(1 * bars + 0);
        }

        /// <summary>
        /// Get Foo from BarPlusOnes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in BarPlusOnes and y is value in base unit Bars.</remarks>
        public static Foo FromBarPlusOnes(double barplusones)
        {
            return new Foo(1 * barplusones + 1);
        }

        /// <summary>
        /// Get Foo from BarsTripled.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in BarsTripled and y is value in base unit Bars.</remarks>
        public static Foo FromBarsTripled(double barstripled)
        {
            return new Foo(3 * barstripled + 0);
        }

        /// <summary>
        /// Get Foo from TwiceThanBars.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in TwiceThanBars and y is value in base unit Bars.</remarks>
        public static Foo FromTwiceThanBars(double twicethanbars)
        {
            return new Foo(2 * twicethanbars + 0);
        }

        #endregion

        #region Arithmetic Operators

        public static Foo operator -(Foo right)
        {
            return new Foo(-right.Bars);
        }

        public static Foo operator +(Foo left, Foo right)
        {
            return new Foo(left.Bars + right.Bars);
        }

        public static Foo operator -(Foo left, Foo right)
        {
            return new Foo(left.Bars - right.Bars);
        }

        public static Foo operator *(double left, Foo right)
        {
            return new Foo(left*right.Bars);
        }

        public static Foo operator *(Foo left, double right)
        {
            return new Foo(left.Bars*right);
        }

        public static Foo operator /(Foo left, double right)
        {
            return new Foo(left.Bars/right);
        }

        public static double operator /(Foo left, Foo right)
        {
            return left.Bars/right.Bars;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Foo)) throw new ArgumentException("Expected type Foo.", "obj");
            return CompareTo((Foo) obj);
        }

        public int CompareTo(Foo other)
        {
            return Bars.CompareTo(other.Bars);
        }

        public static bool operator <=(Foo left, Foo right)
        {
            return left.Bars <= right.Bars;
        }

        public static bool operator >=(Foo left, Foo right)
        {
            return left.Bars >= right.Bars;
        }

        public static bool operator <(Foo left, Foo right)
        {
            return left.Bars < right.Bars;
        }

        public static bool operator >(Foo left, Foo right)
        {
            return left.Bars > right.Bars;
        }

        public static bool operator ==(Foo left, Foo right)
        {
            return left.Bars == right.Bars;
        }

        public static bool operator !=(Foo left, Foo right)
        {
            return left.Bars != right.Bars;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Bars.Equals(((Foo) obj).Bars);
        }

        public override int GetHashCode()
        {
            return Bars.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Bars, UnitSystem.Create().GetDefaultAbbreviation(FooUnit.Bar));
        }
    }
} 
