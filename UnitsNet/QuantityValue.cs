// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
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

using UnitsNet.InternalHelpers;

#if !WINDOWS_UWP
namespace UnitsNet
{
    /// <summary>
    ///     A type that supports implicit cast from all .NET numeric types, in order to avoid a large number of overloads
    ///     and binary size for all From(value, unit) factory methods, for each of the 700+ units in the library.
    ///     <see cref="QuantityValue"/> stores the value internally with the proper type to preserve the range or precision of the original value:
    /// <list type="bullet">
    /// <item><description><see cref="double"/> for [byte, short, int, long, float, double]</description></item>
    /// <item><description><see cref="decimal"/> for [decimal] to preserve the 128-bit precision</description></item>
    /// </list>
    /// </summary>
    /// <remarks>
    ///     At the time of this writing, this reduces the number of From(value, unit) overloads to 1/4th:
    ///     From 8 (int, long, double, decimal + each nullable) down to 2 (QuantityValue and QuantityValue?).
    ///     This also adds more numeric types with no extra overhead, such as float, short and byte.
    /// </remarks>
    public struct QuantityValue
    {
        /// <summary>
        ///     Value assigned when implicitly casting from all numeric types except <see cref="decimal" />, since
        ///     <see cref="double" /> has the greatest range and is 64 bits versus 128 bits for <see cref="decimal"/>.
        /// </summary>
        private readonly double? _value;

        /// <summary>
        ///     Value assigned when implicitly casting from <see cref="decimal" /> type, since it has a greater precision than
        ///     <see cref="double"/> and we want to preserve that when constructing quantities that use <see cref="decimal"/>
        ///     as their value type.
        /// </summary>
        private readonly decimal? _valueDecimal;

        private QuantityValue(double val)
        {
            _value = Guard.EnsureValidNumber(val, nameof(val));
            _valueDecimal = null;
        }

        private QuantityValue(decimal val)
        {
            _valueDecimal = val;
            _value = null;
        }

        #region To QuantityValue

#pragma warning disable 618
        // Prefer double for integer types, since most quantities use that type as of now and
        // that avoids unnecessary casts back and forth.
        // If we later change to use decimal more, we should revisit this.
        public static implicit operator QuantityValue(byte val) => new QuantityValue((double) val);
        public static implicit operator QuantityValue(short val) => new QuantityValue((double) val);
        public static implicit operator QuantityValue(int val) => new QuantityValue((double) val);
        public static implicit operator QuantityValue(long val) => new QuantityValue((double) val);
        public static implicit operator QuantityValue(float val) => new QuantityValue(val); // double
        public static implicit operator QuantityValue(double val) => new QuantityValue(val); // double
        public static implicit operator QuantityValue(decimal val) => new QuantityValue(val); // decimal
#pragma warning restore 618

        #endregion

        #region To double

        public static explicit operator double(QuantityValue number)
        {
            // double -> decimal -> zero (since we can't implement the default struct ctor)
            return number._value ?? (double) number._valueDecimal.GetValueOrDefault();
        }

        #endregion

        #region To decimal

        public static explicit operator decimal(QuantityValue number)
        {
            // decimal -> double -> zero (since we can't implement the default struct ctor)
            return number._valueDecimal ?? (decimal) number._value.GetValueOrDefault();
        }

        #endregion
    }
}
#endif
