// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using JetBrains.Annotations;
using Xunit.Abstractions;

namespace UnitsNet.Tests;

[TestSubject(typeof(QuantityValue))]
public static partial class QuantityValueTests
{
    public class QuantityValueData : IXunitSerializable
    {
        private QuantityValue _value;

        public QuantityValueData()
        {
            // empty constructor
        }

        public QuantityValueData(QuantityValue value)
        {
            _value = value;
        }

        public static implicit operator QuantityValue(QuantityValueData data)
        {
            return data._value;
        }

        public static implicit operator QuantityValueData(QuantityValue value)
        {
            return new QuantityValueData(value);
        }

        public static implicit operator QuantityValueData(int value)
        {
            return new QuantityValueData(value);
        }

        public static implicit operator QuantityValueData(decimal value)
        {
            return new QuantityValueData(value);
        }

        public static implicit operator QuantityValueData(double value)
        {
            return new QuantityValueData(value);
        }

        public QuantityValue Value => _value;

        #region Implementation of IXunitSerializable

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("Numerator", _value.Numerator);
            info.AddValue("Denominator", _value.Denominator);
        }

        public void Deserialize(IXunitSerializationInfo info)
        {
            var numerator = info.GetValue<BigInteger>("Numerator");
            var denominator = info.GetValue<BigInteger>("Denominator");
            _value = new QuantityValue(numerator, denominator);
        }

        #endregion

        public override string ToString()
        {
            return $"{Value.Numerator}/{Value.Denominator}";
        }
    }

#if NET
    /// <summary>
    ///     Represents a fake number implementation for testing purposes.
    /// </summary>
    /// <remarks>
    ///     This class is used internally within the test suite to simulate a number type that implements the
    ///     <see cref="System.Numerics.INumberBase{T}" /> interface.
    ///     It provides functionality to test conversions and operations involving custom number types.
    /// </remarks>
#pragma warning disable CA1067, CS0660
    private class FakeNumber : INumberBase<FakeNumber>
#pragma warning restore CS0660, CA1067
    {
        public static FakeNumber Zero { get; } = new();

        static bool INumberBase<FakeNumber>.TryConvertFromChecked<TOther>(TOther value, [MaybeNullWhen(false)] out FakeNumber result)
        {
            result = null;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertFromSaturating<TOther>(TOther value, [MaybeNullWhen(false)] out FakeNumber result)
        {
            result = null;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertFromTruncating<TOther>(TOther value, [MaybeNullWhen(false)] out FakeNumber result)
        {
            result = null;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertToChecked<TOther>(FakeNumber value, [MaybeNullWhen(false)] out TOther result)
        {
            result = default;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertToSaturating<TOther>(FakeNumber value, [MaybeNullWhen(false)] out TOther result)
        {
            result = default;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertToTruncating<TOther>(FakeNumber value, [MaybeNullWhen(false)] out TOther result)
        {
            result = default;
            return false;
        }

        #region Other interface members (not implemented)

        bool IEquatable<FakeNumber>.Equals(FakeNumber? other)
        {
            throw new NotImplementedException();
        }

        string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

        bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        static FakeNumber IParsable<FakeNumber>.Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        static bool IParsable<FakeNumber>.TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out FakeNumber result)
        {
            throw new NotImplementedException();
        }

        static FakeNumber ISpanParsable<FakeNumber>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        static bool ISpanParsable<FakeNumber>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out FakeNumber result)
        {
            throw new NotImplementedException();
        }


        static FakeNumber IAdditionOperators<FakeNumber, FakeNumber, FakeNumber>.operator +(FakeNumber left, FakeNumber right)
        {
            throw new NotImplementedException();
        }

        static FakeNumber IAdditiveIdentity<FakeNumber, FakeNumber>.AdditiveIdentity { get; } = new();

        static FakeNumber IDecrementOperators<FakeNumber>.operator --(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static FakeNumber IDivisionOperators<FakeNumber, FakeNumber, FakeNumber>.operator /(FakeNumber left, FakeNumber right)
        {
            throw new NotImplementedException();
        }

        static bool IEqualityOperators<FakeNumber, FakeNumber, bool>.operator ==(FakeNumber? left, FakeNumber? right)
        {
            throw new NotImplementedException();
        }

        static bool IEqualityOperators<FakeNumber, FakeNumber, bool>.operator !=(FakeNumber? left, FakeNumber? right)
        {
            throw new NotImplementedException();
        }

        static FakeNumber IIncrementOperators<FakeNumber>.operator ++(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static FakeNumber IMultiplicativeIdentity<FakeNumber, FakeNumber>.MultiplicativeIdentity { get; } = new();

        static FakeNumber IMultiplyOperators<FakeNumber, FakeNumber, FakeNumber>.operator *(FakeNumber left, FakeNumber right)
        {
            throw new NotImplementedException();
        }

        static FakeNumber ISubtractionOperators<FakeNumber, FakeNumber, FakeNumber>.operator -(FakeNumber left, FakeNumber right)
        {
            throw new NotImplementedException();
        }

        static FakeNumber IUnaryNegationOperators<FakeNumber, FakeNumber>.operator -(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static FakeNumber IUnaryPlusOperators<FakeNumber, FakeNumber>.operator +(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.Abs(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsCanonical(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsComplexNumber(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsEvenInteger(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsFinite(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsImaginaryNumber(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsInfinity(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsInteger(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsNaN(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsNegative(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsNegativeInfinity(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsNormal(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsOddInteger(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsPositive(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsPositiveInfinity(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsRealNumber(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsSubnormal(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsZero(FakeNumber value)
        {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.MaxMagnitude(FakeNumber x, FakeNumber y)
        {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.MaxMagnitudeNumber(FakeNumber x, FakeNumber y)
        {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.MinMagnitude(FakeNumber x, FakeNumber y)
        {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.MinMagnitudeNumber(FakeNumber x, FakeNumber y)
        {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.Parse(string s, NumberStyles style, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FakeNumber result)
        {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FakeNumber result)
        {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.One { get; } = new();
        static int INumberBase<FakeNumber>.Radix { get; } = 10;

        #endregion
    }
    
#endif
}