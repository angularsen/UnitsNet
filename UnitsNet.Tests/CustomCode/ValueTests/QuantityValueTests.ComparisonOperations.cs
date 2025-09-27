using System.Diagnostics.CodeAnalysis;
using Xunit.Abstractions;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public static class ComparisonTests
    {
        #region Test cases

        /// <summary>
        ///     Represents a pair of <see cref="QuantityValue" /> instances that are considered equal for comparison purposes.
        /// </summary>
        /// <remarks>
        ///     This record is used in unit tests to validate equality and comparison operations between two
        ///     <see cref="QuantityValue" /> instances.
        ///     It implements <see cref="IXunitSerializable" /> to support serialization and deserialization of test data.
        /// </remarks>
        public sealed record EqualValuesPair : IXunitSerializable
        {
            public EqualValuesPair(QuantityValue value1, QuantityValue value2)
            {
                Value1 = value1;
                Value2 = value2;
            }

            public QuantityValue Value1 { get; private set; }

            public QuantityValue Value2 { get; private set; }

            public void Deconstruct(out QuantityValue value1, out QuantityValue value2)
            {
                value1 = Value1;
                value2 = Value2;
            }

            public override string ToString()
            {
                return $"{Value1.Numerator}/{Value1.Denominator} == {Value2.Numerator}/{Value2.Denominator}";
            }

            #region Implementation of IXunitSerializable

            public EqualValuesPair()
            {
            }

            public void Serialize(IXunitSerializationInfo info)
            {
                info.AddValue("v1", (QuantityValueData)Value1);
                info.AddValue("v2", (QuantityValueData)Value2);
            }

            public void Deserialize(IXunitSerializationInfo info)
            {
                Value1 = info.GetValue<QuantityValueData>("v1");
                Value2 = info.GetValue<QuantityValueData>("v2");
            }

            #endregion
        }

        /// <summary>
        ///     Provides a collection of test cases for verifying the equality of <see cref="QuantityValue" /> instances.
        /// </summary>
        /// <remarks>
        ///     This class is used in unit tests to supply pairs of <see cref="QuantityValue" /> instances that are expected to be
        ///     equal.
        ///     It extends <see cref="TheoryData{T}" /> to facilitate parameterized testing with xUnit.
        /// </remarks>
        public sealed class EqualTestCases : TheoryData<EqualValuesPair>
        {
            public EqualTestCases()
            {
                Add(QuantityValue.PositiveInfinity, QuantityValue.PositiveInfinity);
                Add(QuantityValue.NegativeInfinity, QuantityValue.NegativeInfinity);
                Add(QuantityValue.Zero, QuantityValue.Zero);
                Add(QuantityValue.Zero, new QuantityValue(0, 2));
                Add(new QuantityValue(0, 2), QuantityValue.Zero);
                Add(QuantityValue.One, new QuantityValue(2, 2));
                Add(QuantityValue.MinusOne, new QuantityValue(-2, 2));
                Add(new QuantityValue(1, 2), new QuantityValue(2, 4));
                Add(new QuantityValue(-1, 2), new QuantityValue(-2, 4));
                Add(42, 42);
                Add(-42, -42);
            }

            private void Add(QuantityValue value1, QuantityValue value2)
            {
                Add(new EqualValuesPair(value1, value2));
            }
        }

        /// <summary>
        ///     Represents a pair of unequal <see cref="QuantityValue" /> instances, where one value is smaller than the other.
        /// </summary>
        /// <remarks>
        ///     This record is used in unit tests to validate comparison operations between <see cref="QuantityValue" /> instances.
        ///     It implements <see cref="IXunitSerializable" /> to support serialization and deserialization for test cases.
        /// </remarks>
        public sealed record UnequalValuesPair : IXunitSerializable
        {
            public UnequalValuesPair(QuantityValue smaller, QuantityValue larger)
            {
                Smaller = smaller;
                Larger = larger;
            }

            public QuantityValue Smaller { get; private set; }

            public QuantityValue Larger { get; private set; }

            public void Deconstruct(out QuantityValue smaller, out QuantityValue larger)
            {
                smaller = Smaller;
                larger = Larger;
            }

            public override string ToString()
            {
                return $"{Smaller.Numerator}/{Smaller.Denominator} < {Larger.Numerator}/{Larger.Denominator}";
            }

            #region Implementation of IXunitSerializable

            public UnequalValuesPair()
            {
            }

            public void Serialize(IXunitSerializationInfo info)
            {
                info.AddValue("v1", (QuantityValueData)Smaller);
                info.AddValue("v2", (QuantityValueData)Larger);
            }

            public void Deserialize(IXunitSerializationInfo info)
            {
                Smaller = info.GetValue<QuantityValueData>("v1");
                Larger = info.GetValue<QuantityValueData>("v2");
            }

            #endregion
        }

        /// <summary>
        ///     Provides a collection of test cases for validating the behavior of comparison operations
        ///     between unequal <see cref="QuantityValue" /> instances.
        /// </summary>
        /// <remarks>
        ///     This class is used in unit tests to supply pairs of <see cref="QuantityValue" /> instances
        ///     where one value is smaller than the other. It extends <see cref="TheoryData{T}" /> to
        ///     facilitate parameterized tests with <see cref="Xunit.TheoryAttribute" />.
        /// </remarks>
        public sealed class UnequalTestCases : TheoryData<UnequalValuesPair>
        {
            public UnequalTestCases()
            {
                Add(QuantityValue.NegativeInfinity, QuantityValue.PositiveInfinity);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(1, 2));
                Add(new QuantityValue(1, 2), QuantityValue.PositiveInfinity);
                Add(QuantityValue.Zero, QuantityValue.One);
                Add(QuantityValue.MinusOne, QuantityValue.Zero);
                Add(QuantityValue.MinusOne, QuantityValue.One);
                Add(QuantityValue.Zero, new QuantityValue(1, 2));
                Add(new QuantityValue(-1, 2), QuantityValue.Zero);
                Add(new QuantityValue(-1, 2), new QuantityValue(2, 4));
                Add(new QuantityValue(1, 3), new QuantityValue(1, 2));
                Add(new QuantityValue(-1, 2), new QuantityValue(-1, 3));
                Add(new QuantityValue(3, 2), new QuantityValue(2, 1));
                Add(new QuantityValue(-2, 1), new QuantityValue(-3, 2));
                Add(new QuantityValue(3, 5), new QuantityValue(2, 3));
                Add(new QuantityValue(-2, 3), new QuantityValue(-3, 5));
                Add(new QuantityValue(2, 3), new QuantityValue(4, 5));
                Add(new QuantityValue(-4, 5), new QuantityValue(-2, 3));
                Add(new QuantityValue(4, 2), new QuantityValue(9, 4));
                Add(new QuantityValue(-9, 4), new QuantityValue(-4, 2));
                Add(new QuantityValue(8, 5), new QuantityValue(4, 2));
                Add(new QuantityValue(-4, 2), new QuantityValue(-8, 5));
                Add(42, 43);
                Add(-43, -42);
            }

            private void Add(QuantityValue value1, QuantityValue value2)
            {
                Add(new UnequalValuesPair(value1, value2));
            }
        }

        #endregion

        public class EqualityContractTests
        {
            [Fact]
            [SuppressMessage("ReSharper", "EqualExpressionComparison")]
            [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
            public void Equals_WithNaN_ReturnsTrue()
            {
                Assert.True(double.NaN.Equals(double.NaN));
                Assert.True(QuantityValue.NaN.Equals(QuantityValue.NaN));
            }

            [Fact]
            public void Equals_WithAnotherType_ReturnsFalse()
            {
                // ReSharper disable once SuspiciousTypeConversion.Global
                Assert.False(QuantityValue.Zero.Equals("text"));
            }

            [Fact]
            public void Equals_WithNull_ReturnsFalse()
            {
                Assert.False(QuantityValue.Zero.Equals(null));
            }

            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void Equals_WithSameValueAsObject_ReturnsTrue(EqualValuesPair test)
            {
                Assert.True(test.Value1.Equals((object)test.Value2));
                Assert.True(test.Value2.Equals((object)test.Value1));
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void Equals_WithAnotherValueAsObject_ReturnsFalse(UnequalValuesPair test)
            {
                Assert.False(test.Smaller.Equals((object)test.Larger));
                Assert.False(test.Larger.Equals((object)test.Smaller));
            }

            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void GetHashCode_WithSameValues_ReturnsTheSameCode(EqualValuesPair test)
            {
                Assert.Equal(test.Value1.GetHashCode(), test.Value2.GetHashCode());
            }
        }

        public class EqualityOperatorTests
        {
            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void EqualityOperator_WithEqualValues_ReturnsTrue(EqualValuesPair testCase)
            {
                Assert.True(testCase.Value1 == testCase.Value2);
                Assert.True(testCase.Value2 == testCase.Value1);
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void EqualityOperator_WithDifferentValues_ReturnsFalse(UnequalValuesPair testCase)
            {
                Assert.False(testCase.Smaller == testCase.Larger);
                Assert.False(testCase.Larger == testCase.Smaller);
            }

            [Fact]
            [SuppressMessage("ReSharper", "EqualExpressionComparison")]
            [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
            public void EqualityOperator_WithNaN_ReturnsFalse()
            {
#pragma warning disable CS1718
                Assert.False(double.NaN == double.NaN);
#pragma warning restore CS1718

                Assert.Multiple(
                    () => Assert.False(QuantityValue.NaN == QuantityValue.NaN),
                    () => Assert.False(QuantityValue.Zero == QuantityValue.NaN),
                    () => Assert.False(QuantityValue.NaN == QuantityValue.Zero));
            }

            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void InequalityOperator_WithEqualValues_ReturnsFalse(EqualValuesPair testCase)
            {
                Assert.False(testCase.Value1 != testCase.Value2);
                Assert.False(testCase.Value2 != testCase.Value1);
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void InequalityOperator_WithDifferentValues_ReturnsTrue(UnequalValuesPair testCase)
            {
                Assert.True(testCase.Smaller != testCase.Larger);
                Assert.True(testCase.Larger != testCase.Smaller);
            }

            [Fact]
            [SuppressMessage("ReSharper", "EqualExpressionComparison")]
            [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
            public void InequalityOperator_WithNaN_ReturnsTrue()
            {
#pragma warning disable CS1718
                Assert.True(double.NaN != double.NaN);
#pragma warning restore CS1718

                Assert.Multiple(
                    () => Assert.True(QuantityValue.NaN != QuantityValue.NaN),
                    () => Assert.True(QuantityValue.Zero != QuantityValue.NaN),
                    () => Assert.True(QuantityValue.NaN != QuantityValue.Zero));
            }
        }

        public class ComparableContractTests
        {
            [Fact]
            [SuppressMessage("ReSharper", "EqualExpressionComparison")]
            [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
            public void CompareTo_WithNaN_ReturnsZero()
            {
                Assert.Equal(0, double.NaN.CompareTo(double.NaN));
                Assert.Equal(0, QuantityValue.NaN.CompareTo(QuantityValue.NaN));
            }

            [Fact]
            public void CompareTo_WithAnotherType_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() => QuantityValue.Zero.CompareTo("text"));
            }

            [Fact]
            public void CompareTo_WithNull_ReturnsOne()
            {
                Assert.Equal(1, double.NegativeInfinity.CompareTo(null));
                Assert.Equal(1, QuantityValue.NegativeInfinity.CompareTo(null));
            }

            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void CompareTo_WithSameValueAsObject_ReturnsZero(EqualValuesPair test)
            {
                Assert.Equal(0, test.Value1.CompareTo((object)test.Value2));
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void CompareTo_WithLargerValueAsObject_ReturnsOne(UnequalValuesPair test)
            {
                Assert.Equal(1, test.Larger.CompareTo((object)test.Smaller));
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void CompareTo_WithSmallerValueAsObject_ReturnsMinusOne(UnequalValuesPair test)
            {
                Assert.Equal(-1, test.Smaller.CompareTo((object)test.Larger));
            }
        }

        public class ComparisonOperatorTests
        {
            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void SmallerThanOperator_WithEqualValues_ReturnsFalse(EqualValuesPair testCase)
            {
                Assert.False(testCase.Value1 < testCase.Value2);
                Assert.False(testCase.Value2 < testCase.Value1);
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void SmallerThanOperator_WithDifferentValues_ReturnsTheExpectedResult(UnequalValuesPair testCase)
            {
                Assert.True(testCase.Smaller < testCase.Larger);
                Assert.False(testCase.Larger < testCase.Smaller);
            }

            [Fact]
            [SuppressMessage("ReSharper", "EqualExpressionComparison")]
            public void SmallerThanOperator_WithNaN_ReturnsFalse()
            {
                Assert.Multiple(
                    () => Assert.False(QuantityValue.NaN < QuantityValue.NaN),
                    () => Assert.False(QuantityValue.NegativeInfinity < QuantityValue.NaN),
                    () => Assert.False(QuantityValue.NaN < QuantityValue.PositiveInfinity),
#pragma warning disable CS1718
                    () => Assert.False(double.NaN < double.NaN),
#pragma warning restore CS1718
                    () => Assert.False(double.NegativeInfinity < double.NaN),
                    () => Assert.False(double.NaN < double.PositiveInfinity));
            }

            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void SmallerThanOrEqualsOperator_WithEqualValues_ReturnsTrue(EqualValuesPair testCase)
            {
                Assert.True(testCase.Value1 <= testCase.Value2);
                Assert.True(testCase.Value2 <= testCase.Value1);
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void SmallerThanOrEqualsOperator_WithDifferentValues_ReturnsTheExpectedResult(UnequalValuesPair testCase)
            {
                Assert.True(testCase.Smaller <= testCase.Larger);
                Assert.False(testCase.Larger <= testCase.Smaller);
            }

            [Fact]
            [SuppressMessage("ReSharper", "EqualExpressionComparison")]
            public void SmallerThanOrEqualsOperator_WithNaN_ReturnsFalse()
            {
#pragma warning disable CS1718
                Assert.False(double.NaN <= double.NaN);
#pragma warning disable CS1718
                Assert.False(double.NegativeInfinity <= double.NaN);
                Assert.False(double.NaN <= double.PositiveInfinity);
                
                Assert.Multiple(
                    () => Assert.False(QuantityValue.NaN <= QuantityValue.NaN),
                    () => Assert.False(QuantityValue.NegativeInfinity <= QuantityValue.NaN),
                    () => Assert.False(QuantityValue.NaN <= QuantityValue.PositiveInfinity));
            }


            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void LargerThanOperator_WithEqualValues_ReturnsFalse(EqualValuesPair testCase)
            {
                Assert.False(testCase.Value1 > testCase.Value2);
                Assert.False(testCase.Value2 > testCase.Value1);
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void LargerThanOperator_WithDifferentValues_ReturnsTheExpectedResult(UnequalValuesPair testCase)
            {
                Assert.True(testCase.Larger > testCase.Smaller);
                Assert.False(testCase.Smaller > testCase.Larger);
            }

            [Fact]
            [SuppressMessage("ReSharper", "EqualExpressionComparison")]
            public void LargerThanOperator_WithNaN_ReturnsFalse()
            {
#pragma warning disable CS1718
                Assert.False(double.NaN > double.NaN);
#pragma warning disable CS1718
                Assert.False(double.PositiveInfinity > double.NaN);
                Assert.False(double.NaN > double.NegativeInfinity);
                
                Assert.Multiple(
                    () => Assert.False(QuantityValue.NaN > QuantityValue.NaN),
                    () => Assert.False(QuantityValue.PositiveInfinity > QuantityValue.NaN),
                    () => Assert.False(QuantityValue.NaN > QuantityValue.NegativeInfinity));
            }

            [Theory]
            [ClassData(typeof(EqualTestCases))]
            public void LargerThanOrEqualsOperator_WithEqualValues_ReturnsTrue(EqualValuesPair testCase)
            {
                Assert.True(testCase.Value1 >= testCase.Value2);
                Assert.True(testCase.Value2 >= testCase.Value1);
            }

            [Theory]
            [ClassData(typeof(UnequalTestCases))]
            public void LargerThanOrEqualsOperator_WithDifferentValues_ReturnsTheExpectedResult(UnequalValuesPair testCase)
            {
                Assert.True(testCase.Larger >= testCase.Smaller);
                Assert.False(testCase.Smaller >= testCase.Larger);
            }

            [Fact]
            [SuppressMessage("ReSharper", "EqualExpressionComparison")]
            public void LargerThanOrEqualsOperator_WithNaN_ReturnsFalse()
            {
#pragma warning disable CS1718
                Assert.False(double.NaN >= double.NaN);
#pragma warning disable CS1718
                Assert.False(double.PositiveInfinity >= double.NaN);
                Assert.False(double.NaN >= double.NegativeInfinity);
                
                Assert.Multiple(
                    () => Assert.False(QuantityValue.NaN >= QuantityValue.NaN),
                    () => Assert.False(QuantityValue.PositiveInfinity >= QuantityValue.NaN),
                    () => Assert.False(QuantityValue.NaN >= QuantityValue.NegativeInfinity));
            }
        }
    }
}