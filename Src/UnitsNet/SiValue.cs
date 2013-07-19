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

using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing a double-precision value with an associated SI unit.
    /// </summary>
    public class SiValue
    {
        public readonly SiUnit Unit;
        public readonly double Value;

        public SiValue(double value, SiUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        #region Equality

//        public static bool operator ==(SIValue left, SIValue right)
//        {
//            return left.Equals(right);
//        }
//
//        public static bool operator !=(SIValue left, SIValue right)
//        {
//            return left.Equals(right) == false;
//        }
//
//        public static bool operator <=(SIValue left, SIValue right)
//        {
//            if (!SIUnits.IsCompatible(left.Unit, right.Unit)) throw new ArgumentException(String.Format("Incompatible units {0} and {1}.", left.Unit, right.Unit));
//
//            return left.Value <= right.ToUnit(left.Unit).Value;
//        }
//
//        public static bool operator >=(SIValue left, SIValue right)
//        {
//            return left.Value >= right.ToUnit(left.Unit).Value;
//        }
//
//        public static bool operator <(SIValue left, SIValue right)
//        {
//            return left.Value < right.ToUnit(left.Unit).Value;
//        }
//
//        public static bool operator >(SIValue left, SIValue right)
//        {
//            return left.Value > right.ToUnit(left.Unit).Value;
//        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == typeof (SiValue) && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode()*397) ^ Unit.GetHashCode();
            }
        }

        #endregion

        public override string ToString()
        {
            return Value + " " + SiUnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(Unit);
        }
    }
}