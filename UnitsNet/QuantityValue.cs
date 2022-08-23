// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Globalization;
using System.Runtime.Serialization;
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
    // [DebuggerDisplay("{GetDebugRepresentation()}")] // TODO replace with a DebuggerTypeProxy?
    [DataContract]
    public readonly struct QuantityValue : IFormattable, IEquatable<QuantityValue>, IComparable<QuantityValue>, IComparable, IConvertible
    {
        private const decimal MinPrecision = 1E-6m; // min number of decimals reserved: as to avoid values that just barely fit the decimal range  
        private const double DecimalMin = (double)(decimal.MinValue * MinPrecision);
        private const double DecimalMax = (double)(decimal.MaxValue * MinPrecision);

        private static bool InDecimalRange(double value)
        {
            if (value == 0)
            {
                return true;
            }

            return value is >= DecimalMin and <= DecimalMax && 1 / value is >= DecimalMin and <= DecimalMax;
        }

        /// <summary>
        /// The value 0
        /// </summary>
        public static readonly QuantityValue Zero = default;
        
        /// <summary>
        ///     Value assigned when implicitly casting from all numeric types except <see cref="decimal" />, since
        ///     <see cref="double" /> has the greatest range.
        /// </summary>
        [FieldOffset(4)] // so that it does not interfere with the Nullable<decimal> // TODO please review this
        [DataMember(Name = "Double", Order = 0, EmitDefaultValue = false)]
        private readonly double? _doubleValue;

        /// <summary>
        ///     Value assigned when implicitly casting from <see cref="decimal" /> type, since it has a greater precision than
        ///     <see cref="double"/> and we want to preserve that when constructing quantities that use <see cref="decimal"/>
        ///     as their value type.
        /// </summary>
        [FieldOffset(0)]
        // bytes layout: 0-1 unused, 2 exponent, 3 sign (only highest bit), 4-15 number
        [DataMember(Name = "Decimal", Order = 1, EmitDefaultValue = false)]
        private readonly decimal? _decimalValue;


        /// <summary>
        ///     Determines the underlying type of this <see cref="QuantityValue"/>.
        /// </summary>
        public QuantityValueType Type => IsDecimal ? QuantityValueType.Decimal : QuantityValueType.Double;

        private QuantityValue(double val) : this()
        {
            _doubleValue = Guard.EnsureValidNumber(val, nameof(val));
        }

        private QuantityValue(decimal val) : this()
        {
            _decimalValue = val;
        }

        /// <summary>
        /// Returns true if the underlying value is stored as a decimal
        /// </summary>
        /// <remarks>True for default(QuantityValue) and QuantityValue.Zero</remarks>
        public bool IsDecimal =>  !_doubleValue.HasValue; 

        /// <summary>
        ///     Value assigned when implicitly casting from all numeric types except <see cref="decimal" />, since
        ///     <see cref="double" /> has the greatest range.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double DoubleValue => _doubleValue.GetValueOrDefault();

        /// <summary>
        ///     Value assigned when implicitly casting from <see cref="decimal" /> type, since it has a greater precision than
        ///     <see cref="double"/> and we want to preserve that when constructing quantities that use <see cref="decimal"/>
        ///     as their value type.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private decimal DecimalValue => _decimalValue.GetValueOrDefault();

        #region Implicit cast to QuantityValue

        // Prefer double for integer types, since most quantities use that type as of now and
        // that avoids unnecessary casts back and forth.
        // If we later change to use decimal more, we should revisit this.
        /// <summary>Implicit cast from <see cref="byte"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(byte val) => new QuantityValue((decimal) val);
        /// <summary>Implicit cast from <see cref="short"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(short val) => new QuantityValue((decimal) val);
        /// <summary>Implicit cast from <see cref="int"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(int val) => new QuantityValue((decimal) val);
        /// <summary>Implicit cast from <see cref="long"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(long val) => new QuantityValue((decimal) val);
        /// <summary>Implicit cast from <see cref="float"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(float val) => new QuantityValue(val); // double
        /// <summary>Implicit cast from <see cref="double"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(double val) => new QuantityValue(val); // double
        /// <summary>Implicit cast from <see cref="decimal"/> to <see cref="QuantityValue"/>.</summary>
        public static implicit operator QuantityValue(decimal val) => new QuantityValue(val); // decimal
        #endregion

        #region Explicit cast to double

        /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="double" />.</summary>
        public static explicit operator double(QuantityValue number)
        {
            return number.IsDecimal ? (double)number.DecimalValue : number.DoubleValue;
        }

        #endregion

        #region Explicit cast to decimal

        /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="decimal" />.</summary>
        public static explicit operator decimal(QuantityValue number)
        {
            return number.IsDecimal ? number.DecimalValue : (decimal)number.DoubleValue;
        }

        #endregion

        #region Operators and Comparators

        /// <inheritdoc />
        public int CompareTo(QuantityValue other)
        {
            if (IsDecimal && other.IsDecimal)
            {
                return DecimalValue.CompareTo(other.DecimalValue);
            }

            if (IsDecimal)
            {
                var otherValue = other.DoubleValue;
                return InDecimalRange(otherValue) ? DecimalValue.CompareTo((decimal)otherValue) : ((double)DecimalValue).CompareTo(otherValue);
            }

            if (other.IsDecimal)
            {
                var thisValue = DoubleValue;
                return InDecimalRange(thisValue) ? ((decimal)thisValue).CompareTo(other.DecimalValue) : thisValue.CompareTo((double)other.DecimalValue);
            }

            // Both are double
            return DoubleValue.CompareTo(other.DoubleValue);
        }

        
        /// <inheritdoc />
        public int CompareTo(object? obj)
        {
            return obj is QuantityValue other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(QuantityValue)}");
        }

        /// <inheritdoc />
        public override bool Equals(object other)
        {
            if (other is QuantityValue qv)
            {
                return Equals(qv);
            }

            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            if (IsDecimal)
            {
                return DecimalValue.GetHashCode();
            }
            else
            {
                return DoubleValue.GetHashCode();
            }
        }

        /// <summary>
        /// Performs an equality comparison on two instances of <see cref="QuantityValue"/>.
        /// Note that rounding might occur if the two values don't use the same base type.
        /// </summary>
        /// <param name="other">The value to compare to</param>
        /// <returns>True on exact equality, false otherwise</returns>
        public bool Equals(QuantityValue other)
        {
            if (IsDecimal && other.IsDecimal)
            {
                return DecimalValue == other.DecimalValue;
            }

            if (IsDecimal)
            {
                var otherValue = other.DoubleValue;
                return InDecimalRange(otherValue) && DecimalValue == (decimal)otherValue;
            }

            if (other.IsDecimal)
            {
                var thisValue = DoubleValue;
                return InDecimalRange(thisValue) && (decimal)DoubleValue == other.DecimalValue;
            }

            return DoubleValue.Equals(other.DoubleValue);
        }

        /// <summary>Equality comparator</summary>
        public static bool operator ==(QuantityValue a, QuantityValue b)
        {
            return a.Equals(b);
        }

        /// <summary>Inequality comparator</summary>
        public static bool operator !=(QuantityValue a, QuantityValue b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Greater-than operator
        /// </summary>
        public static bool operator >(QuantityValue a, QuantityValue b)
        {
            return a.CompareTo(b) == 1;
        }

        /// <summary>
        /// Less-than operator
        /// </summary>
        public static bool operator <(QuantityValue a, QuantityValue b)
        {
            
            return a.CompareTo(b) == -1;
        }

        /// <summary>
        /// Greater-than-or-equal operator
        /// </summary>
        public static bool operator >=(QuantityValue a, QuantityValue b)
        {
            
            return a.CompareTo(b) >= 0;
        }

        /// <summary>
        /// Less-than-or-equal operator
        /// </summary>
        public static bool operator <=(QuantityValue a, QuantityValue b)
        {
            
            return a.CompareTo(b) <= 0;
        }

        /// <summary>
        /// Returns the negated value of the operand
        /// </summary>
        /// <param name="v">Value to negate</param>
        /// <returns>-v</returns>
        public static QuantityValue operator -(QuantityValue v)
        {
            if (v.IsDecimal)
            {
                return new QuantityValue(-v.DecimalValue);
            }
            else
            {
                return new QuantityValue(-v.DoubleValue);
            }
        }

        /// <summary>
        /// Addition operator.
        /// </summary>
        /// <remarks>
        /// This performs an operation on the numeric value of a quantity, clamping the decimal representation as necessary.
        /// </remarks>
        public static QuantityValue operator +(QuantityValue a, QuantityValue b)
        {
            if (a.IsDecimal && b.IsDecimal)
            {
                var doubleResult = (double)a.DecimalValue + (double)b.DecimalValue;
                return InDecimalRange(doubleResult) ? new QuantityValue(a.DecimalValue + b.DecimalValue) : new QuantityValue(doubleResult);
            }
            else if (a.IsDecimal)
            {
                var doubleResult = (double)a.DecimalValue + b.DoubleValue;
                return InDecimalRange(doubleResult) ? new QuantityValue(a.DecimalValue + (decimal)b.DoubleValue): new QuantityValue(doubleResult);
            }
            else if (b.IsDecimal)
            {
                var doubleResult = a.DoubleValue + (double)b.DecimalValue;
                return InDecimalRange(doubleResult) ? new QuantityValue((decimal)a.DoubleValue + b.DecimalValue): new QuantityValue(doubleResult);
            }
            else
            {
                // Both are double
                return new QuantityValue(a.DoubleValue + b.DoubleValue);
            }
        }

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        /// <remarks>
        /// This performs an operation on the numeric value of a quantity, there is no unit or conversions involved.
        /// </remarks>
        public static QuantityValue operator -(QuantityValue a, QuantityValue b)
        {
            if (a.IsDecimal && b.IsDecimal)
            {
                var doubleResult = (double)a.DecimalValue - (double)b.DecimalValue;
                return InDecimalRange(doubleResult) ? new QuantityValue(a.DecimalValue - b.DecimalValue) : new QuantityValue(doubleResult);
            }
            else if (a.IsDecimal)
            {
                var doubleResult = (double)a.DecimalValue - b.DoubleValue;
                return InDecimalRange(doubleResult) ? new QuantityValue(a.DecimalValue - (decimal)b.DoubleValue): new QuantityValue(doubleResult);
            }
            else if (b.IsDecimal)
            {
                var doubleResult = a.DoubleValue - (double)b.DecimalValue;
                return InDecimalRange(doubleResult) ? new QuantityValue((decimal)a.DoubleValue - b.DecimalValue): new QuantityValue(doubleResult);
            }
            else
            {
                // Both are double
                return new QuantityValue(a.DoubleValue - b.DoubleValue);
            }
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <remarks>
        /// This performs an operation on the numeric value of a quantity, there is no unit or conversions involved.
        /// </remarks>
        public static QuantityValue operator *(QuantityValue a, QuantityValue b)
        {
            if (a.IsDecimal && b.IsDecimal)
            {
                var doubleResult = (double)a.DecimalValue * (double)b.DecimalValue;
                return InDecimalRange(doubleResult) ? new QuantityValue(a.DecimalValue * b.DecimalValue) : new QuantityValue(doubleResult);
            }
            else if (a.IsDecimal)
            {
                var doubleResult = (double)a.DecimalValue * b.DoubleValue;
                return InDecimalRange(doubleResult) ? new QuantityValue(a.DecimalValue * (decimal)b.DoubleValue): new QuantityValue(doubleResult);
            }
            else if (b.IsDecimal)
            {
                var doubleResult = a.DoubleValue * (double)b.DecimalValue;
                return InDecimalRange(doubleResult) ? new QuantityValue((decimal)a.DoubleValue * b.DecimalValue): new QuantityValue(doubleResult);
            }
            else
            {
                // Both are double
                return new QuantityValue(a.DoubleValue * b.DoubleValue);
            }
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <remarks>
        /// This performs an operation on the numeric value of a quantity, there is no unit or conversions involved.
        /// </remarks>
        public static QuantityValue operator /(QuantityValue a, QuantityValue b)
        {
            if (a.IsDecimal && b.IsDecimal)
            {
                var doubleResult = (double)a.DecimalValue / (double)b.DecimalValue;
                return InDecimalRange(doubleResult) ? new QuantityValue(a.DecimalValue / b.DecimalValue) : new QuantityValue(doubleResult);
            }
            else if (a.IsDecimal)
            {
                var doubleResult = (double)a.DecimalValue / b.DoubleValue;
                return InDecimalRange(doubleResult) ? new QuantityValue(a.DecimalValue / (decimal)b.DoubleValue): new QuantityValue(doubleResult);
            }
            else if (b.IsDecimal)
            {
                var doubleResult = a.DoubleValue / (double)b.DecimalValue;
                return InDecimalRange(doubleResult) ? new QuantityValue((decimal)a.DoubleValue / b.DecimalValue): new QuantityValue(doubleResult);
            }
            else
            {
                // Both are double
                return new QuantityValue(a.DoubleValue / b.DoubleValue);
            }
        }

        #endregion

        #region ToString

        /// <summary>Returns the string representation of the numeric value.</summary>
        public override string ToString()
            => Type switch
            {
                QuantityValueType.Decimal => DecimalValue.ToString(),
                QuantityValueType.Double => DoubleValue.ToString(),
                _ => throw new NotImplementedException()
            };

        private string GetDebugRepresentation() // TODO replace by DebuggerTypeProxy?
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
        /// Returns the string representation of the numeric value, formatted using the given standard numeric format string
        /// </summary>
        /// <param name="format">A standard numeric format string (must be valid for either double or decimal, depending on the base type)</param>
        /// <returns>The string representation</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns the string representation of the underlying value
        /// </summary>
        /// <param name="format">Standard format specifiers. Because the underlying value can be double or decimal, the meaning can vary</param>
        /// <param name="formatProvider">Culture specific settings</param>
        /// <returns>A string representation of the number</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (IsDecimal)
            {
                return DecimalValue.ToString(format, formatProvider);
            }
            else
            {
                return DoubleValue.ToString(format, formatProvider);
            }
        }

            #endregion

        #region IConvertiable interface implmentation

        TypeCode IConvertible.GetTypeCode()
        {
            return IsDecimal ? TypeCode.Decimal : TypeCode.Double;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(QuantityValue)} to Boolean is not supported.");
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToByte(DecimalValue) : Convert.ToByte(DoubleValue);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(QuantityValue)} to Char is not supported.");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(QuantityValue)} to DateTime is not supported.");
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return IsDecimal ? DecimalValue : Convert.ToDecimal(DoubleValue);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToDouble(DecimalValue) : DoubleValue;
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToInt16(DecimalValue) : Convert.ToInt16(DoubleValue);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToInt16(DecimalValue) : Convert.ToInt16(DoubleValue);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToInt16(DecimalValue) : Convert.ToInt16(DoubleValue);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToSByte(DecimalValue) : Convert.ToSByte(DoubleValue);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToSingle(DecimalValue) : Convert.ToSingle(DoubleValue);
        }
        
        /// <summary>Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.</summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the value of this instance as specified by <paramref name="provider" />.</returns>
        public string ToString(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToString(DecimalValue, provider) : Convert.ToString(DoubleValue, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToUInt16(DecimalValue) : Convert.ToUInt16(DoubleValue);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToUInt32(DecimalValue) : Convert.ToUInt32(DoubleValue);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return IsDecimal ? Convert.ToUInt64(DecimalValue) : Convert.ToUInt64(DoubleValue);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return IsDecimal ? ((IConvertible)DecimalValue).ToType(conversionType, provider) : ((IConvertible)DoubleValue).ToType(conversionType, provider);
        }

        #endregion

        /// <summary>
        ///     Describes the underlying type of a <see cref="QuantityValue"/>.
        /// </summary>
        public enum QuantityValueType : byte
        {
            /// <summary><see cref="Decimal"/> must have the value 0 due to the bit structure of <see cref="decimal"/>.</summary>
            Decimal = 0,
            /// <inheritdoc cref="double"/>
            Double = 1
        }
    }
}
