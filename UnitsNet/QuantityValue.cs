// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using UnitsNet.InternalHelpers;

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
    ///     <para>At the time of this writing, this reduces the number of From(value, unit) overloads to 1/4th:
    ///     From 8 (int, long, double, decimal + each nullable) down to 2 (QuantityValue and QuantityValue?).
    ///     This also adds more numeric types with no extra overhead, such as float, short and byte.</para>
    ///     <para>So far, the internal representation can be either <see cref="double"/> or <see cref="decimal"/>,
    ///     but as this struct is realized as a union struct with overlapping fields, only the amount of memory of the largest data type is used.
    ///     This allows for adding support for smaller data types without increasing the overall size.</para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("{GetDebugRepresentation()}")]
    public readonly struct QuantityValue
    {
        /// <summary>
        ///     Value assigned when implicitly casting from all numeric types except <see cref="decimal" />, since
        ///     <see cref="double" /> has the greatest range.
        /// </summary>
        [FieldOffset(8)] // so that it does not interfere with the Type field
        private readonly double _doubleValue;

        /// <summary>
        ///     Value assigned when implicitly casting from <see cref="decimal" /> type, since it has a greater precision than
        ///     <see cref="double"/> and we want to preserve that when constructing quantities that use <see cref="decimal"/>
        ///     as their value type.
        /// </summary>
        [FieldOffset(0)]
        // bytes layout: 0-1 unused, 2 exponent, 3 sign (only highest bit), 4-15 number
        private readonly decimal _decimalValue;

        /// <summary>
        ///     Determines the underlying type of this <see cref="QuantityValue"/>.
        /// </summary>
        [FieldOffset(0)] // using unused byte for storing type
        public readonly UnderlyingDataType Type;

        private QuantityValue(double val) : this()
        {
            _doubleValue = Guard.EnsureValidNumber(val, nameof(val));
            Type = UnderlyingDataType.Double;
        }

        private QuantityValue(decimal val) : this()
        {
            _decimalValue = val;
            Type = UnderlyingDataType.Decimal;
        }

        #region To QuantityValue

        // Prefer double for integer types, since most quantities use that type as of now and
        // that avoids unnecessary casts back and forth.
        // If we later change to use decimal more, we should revisit this.
        /// <summary>Implicit cast from <see cref="byte"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(byte val) => new QuantityValue((double) val);
        /// <summary>Implicit cast from <see cref="short"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(short val) => new QuantityValue((double) val);
        /// <summary>Implicit cast from <see cref="int"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(int val) => new QuantityValue((double) val);
        /// <summary>Implicit cast from <see cref="long"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(long val) => new QuantityValue((double) val);
        /// <summary>Implicit cast from <see cref="float"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(float val) => new QuantityValue(val); // double
        /// <summary>Implicit cast from <see cref="double"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(double val) => new QuantityValue(val); // double
        /// <summary>Implicit cast from <see cref="decimal"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(decimal val) => new QuantityValue(val); // decimal
        #endregion

        #region To double

        /// <summary>Explicit cast from <see cref="QuantityValue"/> to <see cref="double"/>.</summary>
        public static explicit operator double(QuantityValue number)
            => number.Type switch
            {
                UnderlyingDataType.Decimal => (double)number._decimalValue,
                UnderlyingDataType.Double => number._doubleValue,
                _ => throw new NotImplementedException()
            };

        #endregion

        #region To decimal

        /// <summary>Explicit cast from <see cref="QuantityValue"/> to <see cref="decimal"/>.</summary>
        public static explicit operator decimal(QuantityValue number)
            => number.Type switch
            {
                UnderlyingDataType.Decimal => number._decimalValue,
                UnderlyingDataType.Double => (decimal)number._doubleValue,
                _ => throw new NotImplementedException()
            };

        #endregion

        /// <summary>Returns the string representation of the numeric value.</summary>
        public override string ToString()
            => Type switch
            {
                UnderlyingDataType.Decimal => _decimalValue.ToString(),
                UnderlyingDataType.Double => _doubleValue.ToString(),
                _ => throw new NotImplementedException()
            };

        private string GetDebugRepresentation()
        {
            StringBuilder builder = new($"{Type} {ToString()} Hex:");

            byte[] bytes = BytesUtility.GetBytes(this);
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                builder.Append($" {bytes[i]:X2}");
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Describes the underlying type of a <see cref="QuantityValue"/>.
        /// </summary>
        public enum UnderlyingDataType : byte
        {
            /// <summary><see cref="Decimal"/> must have the value 0 due to the bit structure of <see cref="decimal"/>.</summary>
            Decimal = 0,
            /// <inheritdoc cref="double"/>
            Double = 1
        }
    }
}
