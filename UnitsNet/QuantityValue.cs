// Copyright © 2007 Andreas Gullberg Larsen (angularsen@gmail.com).
// https://github.com/angularsen/UnitsNet
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

// Operator overloads not supported in Windows Runtime Components, we use 'double' type instead
#if !WINDOWS_UWP
using System;

namespace UnitsNet
{
    /// <summary>
    ///     Pass it any numeric value (int, double, decimal, float..) and it will be implicitly converted to a <see cref="double" />, the quantity value representation used in UnitsNet.
    ///     This is used to avoid an explosion of overloads for methods taking N numeric types for all our 500+ units.
    /// </summary>
    /// <remarks>
    ///     At the time of this writing, this reduces the number of From() overloads to 1/4th:
    ///     From 8 (int, long, double, decimal + each nullable) down to 2 (QuantityValue and QuantityValue?).
    ///     This also adds more numeric types with no extra overhead, such as float, short and byte.
    /// </remarks>
    public struct QuantityValue
    {
        private readonly double _value;

        // Obsolete is used to communicate how they should use this type, instead of making the constructor private and have them figure it out
        [Obsolete("Do not use this constructor. Instead pass any numeric value such as int, long, float, double, decimal, short or byte directly and it will be implicitly casted to double.")]
        private QuantityValue(double val)
        {
            _value = val;
        }

        #region To QuantityValue

#pragma warning disable 618
        public static implicit operator QuantityValue(double val) => new QuantityValue(val);
        public static implicit operator QuantityValue(float val) => new QuantityValue(val);
        public static implicit operator QuantityValue(long val) => new QuantityValue(val);
        public static implicit operator QuantityValue(decimal val) => new QuantityValue(Convert.ToDouble(val));
        public static implicit operator QuantityValue(short val) => new QuantityValue(val);
        public static implicit operator QuantityValue(byte val) => new QuantityValue(val);
#pragma warning restore 618
        
        #endregion

        #region To double

        public static explicit operator double(QuantityValue number) => Convert.ToDouble(number._value);

        #endregion
    }
}
#endif
