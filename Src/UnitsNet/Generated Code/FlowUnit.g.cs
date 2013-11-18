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
    /// In physics and engineering, in particular fluid dynamics and hydrometry, the volumetric flow rate, (also known as volume flow rate, rate of fluid flow or volume velocity) is the volume of fluid which passes through a given surface per unit time. The SI unit is m3·s−1 (cubic meters per second). In US Customary Units and British Imperial Units, volumetric flow rate is often expressed as ft3/s (cubic feet per second). It is usually represented by the symbol Q.
    /// </summary>
    public partial struct Flow : IComparable, IComparable<Flow>
    {
        /// <summary>
        /// Base unit of Flow.
        /// </summary>
        public readonly double CubicMetersPerSecond;

        public Flow(double cubicmeterspersecond) : this()
        {
            CubicMetersPerSecond = cubicmeterspersecond;
        }

        #region Unit Properties

        public double CubicMetersPerHour
        {
            get { return CubicMetersPerSecond/0.000277777777777778; }
        }

        #endregion

        #region Static 

        public static Flow Zero
        {
            get { return new Flow(); }
        }
        
        public static Flow FromCubicMetersPerHour(double cubicmetersperhour)
        {
            return new Flow(cubicmetersperhour*0.000277777777777778);
        }

        public static Flow FromCubicMetersPerSecond(double cubicmeterspersecond)
        {
            return new Flow(cubicmeterspersecond*1);
        }

        #endregion

        #region Arithmetic Operators

        public static Flow operator -(Flow right)
        {
            return new Flow(-right.CubicMetersPerSecond);
        }

        public static Flow operator +(Flow left, Flow right)
        {
            return new Flow(left.CubicMetersPerSecond + right.CubicMetersPerSecond);
        }

        public static Flow operator -(Flow left, Flow right)
        {
            return new Flow(left.CubicMetersPerSecond - right.CubicMetersPerSecond);
        }

        public static Flow operator *(double left, Flow right)
        {
            return new Flow(left*right.CubicMetersPerSecond);
        }

        public static Flow operator *(Flow left, double right)
        {
            return new Flow(left.CubicMetersPerSecond*right);
        }

        public static Flow operator /(Flow left, double right)
        {
            return new Flow(left.CubicMetersPerSecond/right);
        }

        public static double operator /(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond/right.CubicMetersPerSecond;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Flow)) throw new ArgumentException("Expected type Flow.", "obj");
            return CompareTo((Flow) obj);
        }

        public int CompareTo(Flow other)
        {
            return CubicMetersPerSecond.CompareTo(other.CubicMetersPerSecond);
        }

        public static bool operator <=(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond <= right.CubicMetersPerSecond;
        }

        public static bool operator >=(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond >= right.CubicMetersPerSecond;
        }

        public static bool operator <(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond < right.CubicMetersPerSecond;
        }

        public static bool operator >(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond > right.CubicMetersPerSecond;
        }

        public static bool operator ==(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond == right.CubicMetersPerSecond;
        }

        public static bool operator !=(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond != right.CubicMetersPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CubicMetersPerSecond.Equals(((Flow) obj).CubicMetersPerSecond);
        }

        public override int GetHashCode()
        {
            return CubicMetersPerSecond.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", CubicMetersPerSecond, UnitSystem.Create().GetDefaultAbbreviation(Unit.CubicMeterPerSecond));
        }
    }
} 
