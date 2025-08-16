using System.Numerics;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public class NumberTests
    {
#if NET7_0_OR_GREATER
        [Fact]
        public void Radix_Returns_Ten()
        {
            Assert.Equal(10, GetRadix<QuantityValue>());
            return;

            static int GetRadix<T>()
                where T : INumber<T>
            {
                return T.Radix;
            }
        }

        [Fact]
        public void AdditiveIdentity_Returns_Zero()
        {
            Assert.Equal(0, GetAdditiveIdentity<QuantityValue>());
            return;

            static T GetAdditiveIdentity<T>()
                where T : IAdditiveIdentity<T, T>
            {
                return T.AdditiveIdentity;
            }
        }

        [Fact]
        public void MultiplicativeIdentity_Returns_One()
        {
            Assert.Equal(1, GetMultiplicativeIdentity<QuantityValue>());
            return;

            static T GetMultiplicativeIdentity<T>()
                where T : IMultiplicativeIdentity<T, T>
            {
                return T.MultiplicativeIdentity;
            }
        }

        [Fact]
        public void NegativeOne__Returns_MinusOne()
        {
            Assert.Equal(-1, QuantityValue.MinusOne);
            Assert.Equal(-1, GetNegativeOne<QuantityValue>());
            return;

            static T GetNegativeOne<T>()
                where T : ISignedNumber<T>
            {
                return T.NegativeOne;
            }
        }

        [Fact]
        public void IsNormal_WithFiniteValue_ReturnsTrue()
        {
            Assert.True(IsNormal(new QuantityValue(1, 3)));
            return;
                
            static bool IsNormal<T>(T value)
                where T : INumberBase<T>
            {
                return T.IsNormal(value);
            }
        }

        [Fact]
        public void IsNormal_WithNonFiniteValue_ReturnsFalse()
        {
            Assert.Multiple(() =>
            {
                Assert.False(IsNormal(QuantityValue.NaN));
                Assert.False(IsNormal(QuantityValue.PositiveInfinity));
                Assert.False(IsNormal(QuantityValue.NegativeInfinity));
            }, () =>
            {
                // same as the behavior of double
                Assert.False(IsNormal(double.NaN));
                Assert.False(IsNormal(double.PositiveInfinity));
                Assert.False(IsNormal(double.NegativeInfinity));
            });
            return;

            static bool IsNormal<T>(T value)
                where T : INumberBase<T>
            {
                return T.IsNormal(value);
            }
        }

        [Fact]
        public void IsRealNumber_WithInfinity_ReturnsTrue()
        {
            Assert.Multiple(() =>
            {
                Assert.True(IsRealNumber(QuantityValue.PositiveInfinity));
                Assert.True(IsRealNumber(QuantityValue.NegativeInfinity));
            }, () =>
            {
                // same as the behavior of double
                Assert.True(IsRealNumber(double.PositiveInfinity));
                Assert.True(IsRealNumber(double.NegativeInfinity));
            });
            return;

            static bool IsRealNumber<T>(T value)
                where T : INumberBase<T>
            {
                return T.IsRealNumber(value);
            }
        }

        [Fact]
        public void IsRealNumber_WithNaN_ReturnsFalse()
        {
            Assert.Multiple(() =>
            {
                Assert.False(IsRealNumber(QuantityValue.NaN));
            }, () =>
            {
                // same as the behavior of double
                Assert.False(IsRealNumber(double.NaN));
            });
            return;

            static bool IsRealNumber<T>(T value)
                where T : INumberBase<T>
            {
                return T.IsRealNumber(value);
            }
        }

        [Fact]
        public void IsComplexNumber_ReturnsFalse()
        {
            Assert.Multiple(() =>
            {
                Assert.False(IsComplexNumber(QuantityValue.One));
                Assert.False(IsComplexNumber(QuantityValue.NaN));
                Assert.False(IsComplexNumber(QuantityValue.PositiveInfinity));
                Assert.False(IsComplexNumber(QuantityValue.NegativeInfinity));
            }, () =>
            {
                // same as the behavior of double
                Assert.False(IsComplexNumber(1.0));
                Assert.False(IsComplexNumber(double.NaN));
                Assert.False(IsComplexNumber(double.PositiveInfinity));
                Assert.False(IsComplexNumber(double.NegativeInfinity));
            });
            return;

            static bool IsComplexNumber<T>(T value)
                where T : INumberBase<T>
            {
                return T.IsComplexNumber(value);
            }
        }

        [Fact]
        public void IsImaginaryNumber_ReturnsFalse()
        {
            Assert.Multiple(() =>
            {
                Assert.False(IsImaginaryNumber(QuantityValue.One));
                Assert.False(IsImaginaryNumber(QuantityValue.NaN));
                Assert.False(IsImaginaryNumber(QuantityValue.PositiveInfinity));
                Assert.False(IsImaginaryNumber(QuantityValue.NegativeInfinity));
            }, () =>
            {
                // same as the behavior of double
                Assert.False(IsImaginaryNumber(1.0));
                Assert.False(IsImaginaryNumber(double.NaN));
                Assert.False(IsImaginaryNumber(double.PositiveInfinity));
                Assert.False(IsImaginaryNumber(double.NegativeInfinity));
            });
            return;

            static bool IsImaginaryNumber<T>(T value)
                where T : INumberBase<T>
            {
                return T.IsImaginaryNumber(value);
            }
        }

        [Fact]
        public void IsSubnormal_ReturnsFalse()
        {
            Assert.Multiple(() =>
            {
                Assert.False(IsSubnormal(QuantityValue.One));
                Assert.False(IsSubnormal(QuantityValue.NaN));
                Assert.False(IsSubnormal(QuantityValue.PositiveInfinity));
                Assert.False(IsSubnormal(QuantityValue.NegativeInfinity));
            }, () =>
            {
                // same as the behavior of double
                Assert.False(IsSubnormal(1.0));
                Assert.False(IsSubnormal(double.NaN));
                Assert.False(IsSubnormal(double.PositiveInfinity));
                Assert.False(IsSubnormal(double.NegativeInfinity));
            });
            return;

            static bool IsSubnormal<T>(T value)
                where T : INumberBase<T>
            {
                return T.IsSubnormal(value);
            }
        }
        
#endif

        [Theory]
        [InlineData(0, 1, true)]
        [InlineData(1, 1, true)]
        [InlineData(-1, 1, true)]
        [InlineData(-1, -1, true)]
        [InlineData(2, 1, true)]
        [InlineData(1, 2, true)]
        [InlineData(1, 0, true)]
        [InlineData(-1, 0, true)]
        [InlineData(0, 0, true)]
        [InlineData(2, 2, false)]
        [InlineData(-2, 2, false)]
        [InlineData(-2, -2, false)]
        public void IsCanonicalTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsCanonical(value));
        }
        
        [Theory]
        [InlineData(0, 1, true)]
        [InlineData(1, 0, false)]
        [InlineData(1, 2, true)]
        [InlineData(1, 3, false)]
        [InlineData(1, 4, true)]
        [InlineData(1, 10, true)]
        [InlineData(1, 50, true)]
        [InlineData(1, 350, false)]
        public void HasFiniteDecimalExpansion(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.HasFiniteDecimalExpansion(value));
        }

        [Theory]
        [InlineData(2, 1, true)]
        [InlineData(3, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(4, 2, true)]
        [InlineData(6, 2, false)]
        [InlineData(3, 2, false)]
        public void IsEvenIntegerTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsEvenInteger(value));
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(0, 1, true)]
        [InlineData(1, 0, false)]
        public void IsFiniteTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsFinite(value));
        }

        [Theory]
        [InlineData(1, 0, true)]
        [InlineData(0, 1, false)]
        public void IsInfinityTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsInfinity(value));
        }

        [Theory]
        [InlineData(0, 1, true)]
        [InlineData(0, 2, true)]
        [InlineData(1, 1, true)]
        [InlineData(2, 1, true)]
        [InlineData(-6, 3, true)]
        [InlineData(1, 2, false)]
        [InlineData(3, 2, false)]
        [InlineData(1, 0, false)]
        public void IsIntegerTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsInteger(value));
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(1, 1, false)]
        public void IsNaNTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsNaN(value));
        }

        [Theory]
        [InlineData(-1, 1, true)]
        [InlineData(1, 1, false)]
        public void IsNegativeTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsNegative(value));
        }

        [Theory]
        [InlineData(-1, 0, true)]
        [InlineData(1, 0, false)]
        public void IsNegativeInfinityTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsNegativeInfinity(value));
        }

        [Theory]
        [InlineData(2, 1, false)]
        [InlineData(3, 1, true)]
        [InlineData(1, 0, false)]
        [InlineData(1, 2, false)]
        [InlineData(6, 2, true)]
        [InlineData(6, 3, false)]
        public void IsOddIntegerTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsOddInteger(value));
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, true)]
        [InlineData(-1, 1, false)]
        [InlineData(-1, 0, false)]
        [InlineData(0, 0, false)]
        public void IsPositiveTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsPositive(value));
        }

        [Theory]
        [InlineData(1, 0, true)]
        [InlineData(-1, 0, false)]
        public void IsPositiveInfinityTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsPositiveInfinity(value));
        }

        [Theory]
        [InlineData(0, 1, true)]
        [InlineData(1, 1, false)]
        public void IsZeroTests(BigInteger numerator, BigInteger denominator, bool expected)
        {
            var value = new QuantityValue(numerator, denominator);
            Assert.Equal(expected, QuantityValue.IsZero(value));
        }

        [Theory]
        [InlineData(1, 2, 1, 3, 1, 2)]
        [InlineData(-1, 2, 1, 3, -1, 2)]
        [InlineData(0, 1, 1, 3, 1, 3)]
        [InlineData(0, 0, 1, 3, 0, 0)] // NaN
        [InlineData(1, 3, 0, 0, 0, 0)] // NaN
        [InlineData(0, 0, 1, 0, 0, 0)] // NaN
        [InlineData(1, 0, 0, 0, 0, 0)] // NaN
        [InlineData(0, 0, -1, 0, 0, 0)] // NaN
        [InlineData(-1, 0, 0, 0, 0, 0)] // NaN
        [InlineData(1, 0, -1, 0, 1, 0)] // PositiveInfinity
        [InlineData(-1, 0, 1, 0, 1, 0)] // PositiveInfinity
        public void MaxMagnitudeTests(BigInteger num1, BigInteger den1, BigInteger num2, BigInteger den2, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value1 = new QuantityValue(num1, den1);
            var value2 = new QuantityValue(num2, den2);
            var expected = new QuantityValue(expectedNum, expectedDen);
#if NET
            Assert.Equal(double.MaxMagnitude(value1.ToDouble(), value2.ToDouble()), expected.ToDouble()); // making sure the expectation is correct
#endif
            Assert.Equal(expected, QuantityValue.MaxMagnitude(value1, value2));
        }

        [Theory]
        [InlineData(1, 2, 1, 3, 1, 2)]
        [InlineData(-1, 2, 1, 3, -1, 2)]
        [InlineData(1, 3, -1, 2, -1, 2)]
        [InlineData(0, 0, 1, 3, 1, 3)] // NaN
        [InlineData(1, 2, 0, 0, 1, 2)] // NaN
        [InlineData(0, 0, 1, 0, 1, 0)] // NaN and PositiveInfinity
        [InlineData(1, 0, 0, 0, 1, 0)] // PositiveInfinity and NaN
        [InlineData(0, 0, -1, 0, -1, 0)] // NaN and NegativeInfinity
        [InlineData(-1, 0, 0, 0, -1, 0)] // NegativeInfinity and NaN
        [InlineData(1, 0, -1, 0, 1, 0)] // PositiveInfinity and NegativeInfinity
        [InlineData(-1, 0, 1, 0, 1, 0)] // NegativeInfinity and PositiveInfinity
        [InlineData(0, 0, 0, 0, 0, 0)] // NaN and NaN
        public void MaxMagnitudeNumberTests(BigInteger num1, BigInteger den1, BigInteger num2, BigInteger den2, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value1 = new QuantityValue(num1, den1);
            var value2 = new QuantityValue(num2, den2);
            var expected = new QuantityValue(expectedNum, expectedDen);
#if NET
            Assert.Equal(double.MaxMagnitudeNumber(value1.ToDouble(), value2.ToDouble()), expected.ToDouble()); // making sure the expectation is correct
#endif
            Assert.Equal(expected, QuantityValue.MaxMagnitudeNumber(value1, value2));
        }

        [Theory]
        [InlineData(1, 2, 1, 3, 1, 3)]
        [InlineData(-1, 2, 1, 3, 1, 3)]
        [InlineData(0, 1, 1, 3, 0, 1)]
        [InlineData(0, 0, 1, 3, 0, 0)] // NaN
        [InlineData(1, 3, 0, 0, 0, 0)] // NaN
        [InlineData(0, 0, 1, 0, 0, 0)] // NaN
        [InlineData(1, 0, 0, 0, 0, 0)] // NaN
        [InlineData(0, 0, -1, 0, 0, 0)] // NaN
        [InlineData(-1, 0, 0, 0, 0, 0)] // NaN
        [InlineData(1, 0, -1, 0, -1, 0)] // PositiveInfinity and NegativeInfinity
        [InlineData(-1, 0, 1, 0, -1, 0)] // NegativeInfinity and PositiveInfinity
        public void MinMagnitudeTests(BigInteger num1, BigInteger den1, BigInteger num2, BigInteger den2, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value1 = new QuantityValue(num1, den1);
            var value2 = new QuantityValue(num2, den2);
            var expected = new QuantityValue(expectedNum, expectedDen);
#if NET
            Assert.Equal(double.MinMagnitude(value1.ToDouble(), value2.ToDouble()), expected.ToDouble()); // making sure the expectation is correct
#endif
            Assert.Equal(expected, QuantityValue.MinMagnitude(value1, value2));
        }

        [Theory]
        [InlineData(1, 2, 1, 3, 1, 3)]
        [InlineData(-1, 2, 1, 3, 1, 3)]
        [InlineData(0, 0, 1, 3, 1, 3)] // NaN
        [InlineData(1, 2, 0, 0, 1, 2)] // NaN
        [InlineData(0, 0, 1, 0, 1, 0)] // NaN and PositiveInfinity
        [InlineData(1, 0, 0, 0, 1, 0)] // PositiveInfinity and NaN
        [InlineData(0, 0, -1, 0, -1, 0)] // NaN and NegativeInfinity
        [InlineData(-1, 0, 0, 0, -1, 0)] // NegativeInfinity and NaN
        [InlineData(1, 0, -1, 0, -1, 0)] // PositiveInfinity and NegativeInfinity
        [InlineData(-1, 0, 1, 0, -1, 0)] // NegativeInfinity and PositiveInfinity
        [InlineData(0, 0, 0, 0, 0, 0)] // NaN and NaN
        public void MinMagnitudeNumberTests(BigInteger num1, BigInteger den1, BigInteger num2, BigInteger den2, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value1 = new QuantityValue(num1, den1);
            var value2 = new QuantityValue(num2, den2);
            var expected = new QuantityValue(expectedNum, expectedDen);
#if NET
            Assert.Equal(double.MinMagnitudeNumber(value1.ToDouble(), value2.ToDouble()), expected.ToDouble()); // making sure the expectation is correct
#endif
            Assert.Equal(expected, QuantityValue.MinMagnitudeNumber(value1, value2));
        }

        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(-1, 1, 1, 1)]
        public void AbsTests(BigInteger num, BigInteger den, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value = new QuantityValue(num, den);
            var expected = new QuantityValue(expectedNum, expectedDen);
            Assert.Equal(expected, QuantityValue.Abs(value));
        }
    }
}
