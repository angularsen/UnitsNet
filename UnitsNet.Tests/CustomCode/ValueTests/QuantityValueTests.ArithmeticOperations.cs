using Xunit.Abstractions;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public class ArithmeticOperatorTests
    {
        [Theory]
        [ClassData(typeof(AdditionTestData))]
        public void AdditionOperatorTests(OperatorTestCase testCase)
        {
            var (value1, value2, expectedValue) = testCase;
            Assert.Multiple(() =>
            {
                // the operation is implemented as expected
                Assert.Equal(expectedValue, value1 + value2);
                Assert.Equal(expectedValue, value2 + value1);
            }, () =>
            {
#if NET
                // double-checking that the expectations are correct
                var doubleResult = (double)value1 + (double)value2;
                if (double.IsFinite(doubleResult))
                {
                    Assert.Equal((double)expectedValue, doubleResult, 15);
                }
                else
                {
                    Assert.Equal((double)expectedValue, doubleResult);
                }
#endif
            });
        }

        [Fact]
        public void UnaryIncrementOperator_IncrementsTheValueByOne()
        {
            var value = new QuantityValue(1, 2);
            value++;
            Assert.Equal(new QuantityValue(3, 2), value);
        }

        [Fact]
        public void PlusOperator_ReturnsTheSameValue()
        {
            Assert.Equal(QuantityValue.One, +QuantityValue.One);
            Assert.Equal(QuantityValue.MinusOne, +QuantityValue.MinusOne);
            Assert.Equal(QuantityValue.Zero, +QuantityValue.Zero);
        }

        [Fact]
        public void MinusOperator_ReturnsTheNegatedValue()
        {
            Assert.Equal(QuantityValue.MinusOne, -QuantityValue.One);
            Assert.Equal(QuantityValue.One, -QuantityValue.MinusOne);
            Assert.Equal(QuantityValue.Zero, -QuantityValue.Zero);
        }

        [Theory]
        [ClassData(typeof(SubtractionTestData))]
        public void SubtractionOperatorTests(OperatorTestCase testCase)
        {
            var (value1, value2, expectedValue) = testCase;
            Assert.Multiple(() =>
            {
                // the operation is implemented as expected
                Assert.Equal(expectedValue, value1 - value2);
            }, () =>
            {
#if NET
                // double-checking that the expectations are correct
                var doubleResult = (double)value1 - (double)value2;
                if (double.IsFinite(doubleResult))
                {
                    Assert.Equal((double)expectedValue, doubleResult, 15);
                }
                else
                {
                    Assert.Equal((double)expectedValue, doubleResult);
                }
#endif
            });
        }

        [Fact]
        public void UnaryDecrementOperator_DecrementsTheValueByOne()
        {
            var value = new QuantityValue(1, 2);
            value--;
            Assert.Equal(new QuantityValue(-1, 2), value);
        }

        [Theory]
        [ClassData(typeof(MultiplicationTestData))]
        public void MultiplicationOperatorTests(OperatorTestCase testCase)
        {
            var (value1, value2, expectedValue) = testCase;
            Assert.Multiple(() =>
            {
                // the operation is implemented as expected
                Assert.Equal(expectedValue, value1 * value2);
                Assert.Equal(expectedValue, value2 * value1);
            }, () =>
            {
#if NET
                // double-checking that the expectations are correct
                var doubleResult = (double)value1 * (double)value2;
                if (double.IsFinite(doubleResult))
                {
                    Assert.Equal((double)expectedValue, doubleResult, 15);
                }
                else
                {
                    Assert.Equal((double)expectedValue, doubleResult);
                }
#endif
            });
        }

        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void DivisionOperatorTests(OperatorTestCase testCase)
        {
            var (value1, value2, expectedValue) = testCase;
            Assert.Multiple(() =>
            {
                // the operation is implemented as expected
                Assert.Equal(expectedValue, value1 / value2);
            }, () =>
            {
#if NET
                // double-checking that the expectations are correct
                var doubleResult = (double)value1 / (double)value2;
                if (double.IsFinite(doubleResult))
                {
                    Assert.Equal((double)expectedValue, doubleResult, 14);
                }
                else
                {
                    Assert.Equal((double)expectedValue, doubleResult);
                }
#endif
            });
        }

        [Theory]
        [ClassData(typeof(ModulusTestData))]
        public void ModulusOperatorTests(OperatorTestCase testCase)
        {
            var (value1, value2, expectedValue) = testCase;
            Assert.Multiple(() =>
            {
                // the operation is implemented as expected
                Assert.Equal(expectedValue, value1 % value2);
            }, () =>
            {
#if NET
                // double-checking that the expectations are correct
                var doubleResult = (double)value1 % (double)value2;
                if (double.IsFinite(doubleResult))
                {
                    Assert.Equal((double)expectedValue, doubleResult, 15);
                }
                else
                {
                    Assert.Equal((double)expectedValue, doubleResult);
                }
#endif
            });
        }

        public abstract record OperatorTestCase : IXunitSerializable
        {
            protected OperatorTestCase(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
            {
                Value1 = value1;
                Value2 = value2;
                ExpectedValue = expectedValue;
            }

            public QuantityValue Value1 { get; private set; }
            public QuantityValue Value2 { get; private set; }
            public QuantityValue ExpectedValue { get; private set; }

            public void Deconstruct(out QuantityValue value1, out QuantityValue value2, out QuantityValue expectedValue)
            {
                value1 = Value1;
                value2 = Value2;
                expectedValue = ExpectedValue;
            }

            #region Implementation of IXunitSerializable

            public OperatorTestCase()
            {
            }

            public void Serialize(IXunitSerializationInfo info)
            {
                info.AddValue("v1", (QuantityValueData)Value1);
                info.AddValue("v2", (QuantityValueData)Value2);
                info.AddValue("expected", (QuantityValueData)ExpectedValue);
            }

            public void Deserialize(IXunitSerializationInfo info)
            {
                Value1 = info.GetValue<QuantityValueData>("v1");
                Value2 = info.GetValue<QuantityValueData>("v2");
                ExpectedValue = info.GetValue<QuantityValueData>("expected");
            }

            #endregion
        }

        public sealed class AdditionTestData : TheoryData<OperatorTestCase>
        {
            public AdditionTestData()
            {
                // zero
                Add(QuantityValue.Zero, new QuantityValue(0, 10), QuantityValue.Zero);
                Add(QuantityValue.Zero, QuantityValue.One, QuantityValue.One);
                Add(QuantityValue.Zero, QuantityValue.MinusOne, QuantityValue.MinusOne);

                // positive
                // 4.2 + 0.5 = 4.7
                Add(new QuantityValue(42, 10),
                    new QuantityValue(1, 2),
                    new QuantityValue(47, 10));
                // 4.2 + (-0.333..) = 3.666..
                Add(new QuantityValue(42, 10),
                    new QuantityValue(-1, 3),
                    new QuantityValue(116, 30));

                // negative
                // -4.2 + 0.5 = -3.7
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(1, 2),
                    new QuantityValue(-37, 10));

                // -4.2 + (-0.333..) = -4.533..
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(-1, 3),
                    new QuantityValue(-136, 30));

                // positive infinity
                Add(QuantityValue.PositiveInfinity, QuantityValue.Zero, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, QuantityValue.One, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, QuantityValue.MinusOne, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, new QuantityValue(10, 0), QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, new QuantityValue(-10, 0), QuantityValue.NaN);

                // negative infinity
                Add(QuantityValue.NegativeInfinity, QuantityValue.Zero, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, QuantityValue.One, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, QuantityValue.MinusOne, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(-10, 0), QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(10, 0), QuantityValue.NaN);

                // NaN
                Add(QuantityValue.NaN, QuantityValue.NaN, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.Zero, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.One, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.MinusOne, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.PositiveInfinity, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.NegativeInfinity, QuantityValue.NaN);
            }

            private void Add(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
            {
                Add(new AdditionOperationTestCase(value1, value2, expectedValue));
            }

            public sealed record AdditionOperationTestCase : OperatorTestCase
            {
                public AdditionOperationTestCase()
                {
                }

                public AdditionOperationTestCase(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
                    : base(value1, value2, expectedValue)
                {
                }

                public override string ToString()
                {
                    // return $"{Value1} + {Value2} = {ExpectedValue}";
                    return $"{Value1.Numerator}/{Value1.Denominator} + {Value2.Numerator}/{Value2.Denominator} = {ExpectedValue.Numerator}/{ExpectedValue.Denominator}";
                }
            }
        }

        public sealed class SubtractionTestData : TheoryData<OperatorTestCase>
        {
            public SubtractionTestData()
            {
                // zero
                Add(QuantityValue.Zero, new QuantityValue(0, 10), QuantityValue.Zero);
                Add(QuantityValue.Zero, QuantityValue.One, QuantityValue.MinusOne);
                Add(QuantityValue.Zero, QuantityValue.MinusOne, QuantityValue.One);

                // positive
                // 4.2 - 0.5 = 3.7
                Add(new QuantityValue(42, 10),
                    new QuantityValue(1, 2),
                    new QuantityValue(37, 10));
                // 4.2 - (-0.333..) = 4.533..
                Add(new QuantityValue(42, 10),
                    new QuantityValue(-1, 3),
                    new QuantityValue(136, 30));

                // negative
                // -4.2 - 0.5 = -4.7
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(1, 2),
                    new QuantityValue(-47, 10));

                // -4.2 - (-0.333..) = -3.866..
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(-1, 3),
                    new QuantityValue(-116, 30));

                // positive infinity
                Add(QuantityValue.PositiveInfinity, QuantityValue.Zero, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, QuantityValue.One, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, QuantityValue.MinusOne, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, new QuantityValue(10, 0), QuantityValue.NaN);
                Add(QuantityValue.PositiveInfinity, new QuantityValue(-10, 0), QuantityValue.PositiveInfinity);

                // negative infinity
                Add(QuantityValue.NegativeInfinity, QuantityValue.Zero, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, QuantityValue.One, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, QuantityValue.MinusOne, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(-10, 0), QuantityValue.NaN);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(10, 0), QuantityValue.NegativeInfinity);

                // NaN
                Add(QuantityValue.NaN, QuantityValue.NaN, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.Zero, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.One, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.MinusOne, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.PositiveInfinity, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.NegativeInfinity, QuantityValue.NaN);
            }

            private void Add(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
            {
                Add(new SubtractionOperationTestCase(value1, value2, expectedValue));
            }

            public sealed record SubtractionOperationTestCase : OperatorTestCase
            {
                public SubtractionOperationTestCase()
                {
                }

                public SubtractionOperationTestCase(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
                    : base(value1, value2, expectedValue)
                {
                }

                public override string ToString()
                {
                    // return $"{Value1} - {Value2} = {ExpectedValue}";
                    return $"{Value1.Numerator}/{Value1.Denominator} - {Value2.Numerator}/{Value2.Denominator} = {ExpectedValue.Numerator}/{ExpectedValue.Denominator}";
                }
            }
        }

        public sealed class MultiplicationTestData : TheoryData<OperatorTestCase>
        {
            public MultiplicationTestData()
            {
                // zero
                Add(QuantityValue.Zero, new QuantityValue(0, 10), QuantityValue.Zero);
                Add(QuantityValue.Zero, QuantityValue.One, QuantityValue.Zero);
                Add(QuantityValue.Zero, QuantityValue.MinusOne, QuantityValue.Zero);

                // positive
                // 4.2 * 0.5 = 2.1
                Add(new QuantityValue(42, 10),
                    new QuantityValue(1, 2),
                    new QuantityValue(21, 10));
                // 4.2 * (-0.333..) = -1.4
                Add(new QuantityValue(42, 10),
                    new QuantityValue(-1, 3),
                    new QuantityValue(-14, 10));

                // negative
                // -4.2 * 0.5 = -2.1
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(1, 2),
                    new QuantityValue(-21, 10));

                // -4.2 * (-0.333..) = 1.4
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(-1, 3),
                    new QuantityValue(14, 10));

                // positive infinity
                Add(QuantityValue.PositiveInfinity, QuantityValue.Zero, QuantityValue.NaN);
                Add(QuantityValue.PositiveInfinity, QuantityValue.One, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, QuantityValue.MinusOne, QuantityValue.NegativeInfinity);
                Add(QuantityValue.PositiveInfinity, new QuantityValue(10, 0), QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, new QuantityValue(-10, 0), QuantityValue.NegativeInfinity);

                // negative infinity
                Add(QuantityValue.NegativeInfinity, QuantityValue.Zero, QuantityValue.NaN);
                Add(QuantityValue.NegativeInfinity, QuantityValue.One, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, QuantityValue.MinusOne, QuantityValue.PositiveInfinity);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(-10, 0), QuantityValue.PositiveInfinity);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(10, 0), QuantityValue.NegativeInfinity);

                // NaN
                Add(QuantityValue.NaN, QuantityValue.NaN, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.Zero, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.One, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.MinusOne, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.PositiveInfinity, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.NegativeInfinity, QuantityValue.NaN);
            }

            private void Add(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
            {
                Add(new MultiplicationOperationTestCase(value1, value2, expectedValue));
            }

            public sealed record MultiplicationOperationTestCase : OperatorTestCase
            {
                public MultiplicationOperationTestCase()
                {
                }

                public MultiplicationOperationTestCase(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
                    : base(value1, value2, expectedValue)
                {
                }

                public override string ToString()
                {
                    // return $"{Value1} * {Value2} = {ExpectedValue}";
                    return $"{Value1.Numerator}/{Value1.Denominator} * {Value2.Numerator}/{Value2.Denominator} = {ExpectedValue.Numerator}/{ExpectedValue.Denominator}";
                }
            }
        }

        public sealed class DivisionTestData : TheoryData<OperatorTestCase>
        {
            public DivisionTestData()
            {
                // zero
                Add(QuantityValue.Zero, new QuantityValue(0, 10), QuantityValue.NaN);
                Add(QuantityValue.Zero, QuantityValue.NaN, QuantityValue.NaN);
                Add(QuantityValue.Zero, QuantityValue.One, QuantityValue.Zero);
                Add(QuantityValue.Zero, QuantityValue.MinusOne, QuantityValue.Zero);

                // division by zero
                Add(QuantityValue.One, QuantityValue.Zero, QuantityValue.PositiveInfinity);
                Add(QuantityValue.MinusOne, QuantityValue.Zero, QuantityValue.NegativeInfinity);

                #region positive / positive

                // 4.2 / 1 = 8.4
                Add(new QuantityValue(42, 10),
                    new QuantityValue(1, 1),
                    new QuantityValue(42, 10));

                // 4.2 / 0.5 = 8.4
                Add(new QuantityValue(42, 10),
                    new QuantityValue(1, 2),
                    new QuantityValue(84, 10));

                // 4.2 / 1.5 = 2.8
                Add(new QuantityValue(42, 10),
                    new QuantityValue(3, 2),
                    new QuantityValue(28, 10));

                // 4.2 / 2 = 2.1
                Add(new QuantityValue(42, 10),
                    new QuantityValue(2, 1),
                    new QuantityValue(21, 10));

                // 42 / 2 = 21
                Add(new QuantityValue(42, 1),
                    new QuantityValue(2, 1),
                    new QuantityValue(21, 1));

                // 1 / 45.6 = {10/456}
                Add(new QuantityValue(1, 1),
                    new QuantityValue(456, 10),
                    new QuantityValue(10, 456));

                // 0.025 / 0.01 = 2.5
                Add(new QuantityValue(1, 40),
                    new QuantityValue(1, 100),
                    new QuantityValue(100, 40));

                // 0.05 / 0.01 = 5
                Add(new QuantityValue(2, 40),
                    new QuantityValue(1, 100),
                    new QuantityValue(200, 40));

                // 0.25 / 4.2 = {5/84}
                Add(new QuantityValue(1, 4),
                    new QuantityValue(42, 10),
                    new QuantityValue(5, 84));

                // 0.33.. / 4.2 = {10/126}
                Add(new QuantityValue(1, 3),
                    new QuantityValue(42, 10),
                    new QuantityValue(10, 126));

                // 0.5 / 4.2 = {10/84}
                Add(new QuantityValue(1, 2),
                    new QuantityValue(42, 10),
                    new QuantityValue(10, 84));

                // 1.5 / 4.2 = {30/84}
                Add(new QuantityValue(3, 2),
                    new QuantityValue(42, 10),
                    new QuantityValue(30, 84));

                // 123 / 45.6 = {1230/456}
                Add(new QuantityValue(123, 1),
                    new QuantityValue(456, 10),
                    new QuantityValue(1230, 456));

                #endregion

                #region positive / negative

                // 4.2 / -0.333.. = -12.6
                Add(new QuantityValue(42, 10),
                    new QuantityValue(-1, 3),
                    new QuantityValue(-126, 10));

                // 4.2 / -0.5 = -8.4
                Add(new QuantityValue(42, 10),
                    new QuantityValue(-1, 2),
                    new QuantityValue(-84, 10));

                // 0.01 / -0.05 = -0.2
                Add(new QuantityValue(1, 100),
                    new QuantityValue(-2, 40),
                    new QuantityValue(-40, 200));

                #endregion

                #region negative / positive

                // -4.2 / 1 = -8.4
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(1, 1),
                    new QuantityValue(-42, 10));

                // -4.2 / 0.5 = -8.4
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(1, 2),
                    new QuantityValue(-84, 10));

                // -4.2 / 1.5 = 2.8
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(3, 2),
                    new QuantityValue(-28, 10));

                // -4.2 / 2 = -2.1
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(2, 1),
                    new QuantityValue(-21, 10));

                // -42 / 2 = -21
                Add(new QuantityValue(-42, 1),
                    new QuantityValue(2, 1),
                    new QuantityValue(-21, 1));

                // -1 / 45.6 = {10/456}
                Add(new QuantityValue(-1, 1),
                    new QuantityValue(456, 10),
                    new QuantityValue(-10, 456));

                // -0.025 / 0.01 = 2.5
                Add(new QuantityValue(-1, 40),
                    new QuantityValue(1, 100),
                    new QuantityValue(-100, 40));

                // -0.05 / 0.01 = 5
                Add(new QuantityValue(-2, 40),
                    new QuantityValue(1, 100),
                    new QuantityValue(-200, 40));

                // -0.25 / 4.2 = {5/84}
                Add(new QuantityValue(-1, 4),
                    new QuantityValue(42, 10),
                    new QuantityValue(-5, 84));

                // -0.33.. / 4.2 = {10/126}
                Add(new QuantityValue(-1, 3),
                    new QuantityValue(42, 10),
                    new QuantityValue(-10, 126));

                // -0.5 / 4.2 = {-10/84}
                Add(new QuantityValue(-1, 2),
                    new QuantityValue(42, 10),
                    new QuantityValue(-10, 84));

                // -1.5 / 4.2 = {-30/84}
                Add(new QuantityValue(-3, 2),
                    new QuantityValue(42, 10),
                    new QuantityValue(-30, 84));

                // -123 / 45.6 = {-1230/456}
                Add(new QuantityValue(-123, 1),
                    new QuantityValue(456, 10),
                    new QuantityValue(-1230, 456));

                #endregion

                #region negative / negative

                // -4.2 / (-0.333..) = 12.6
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(-1, 3),
                    new QuantityValue(126, 10));

                // -4.2 / -0.5 = 8.4
                Add(new QuantityValue(-42, 10),
                    new QuantityValue(-1, 2),
                    new QuantityValue(84, 10));

                // -0.01 / -0.05 = 0.2
                Add(new QuantityValue(-1, 100),
                    new QuantityValue(-2, 40),
                    new QuantityValue(40, 200));

                #endregion

                // positive infinity
                Add(QuantityValue.PositiveInfinity, QuantityValue.Zero, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, QuantityValue.One, QuantityValue.PositiveInfinity);
                Add(QuantityValue.PositiveInfinity, QuantityValue.MinusOne, QuantityValue.NegativeInfinity);
                Add(QuantityValue.PositiveInfinity, new QuantityValue(10, 0), QuantityValue.NaN);
                Add(QuantityValue.PositiveInfinity, new QuantityValue(-10, 0), QuantityValue.NaN);

                // division by positive infinity
                Add(QuantityValue.Zero, QuantityValue.PositiveInfinity, QuantityValue.Zero);
                Add(QuantityValue.One, QuantityValue.PositiveInfinity, QuantityValue.Zero);
                Add(QuantityValue.MinusOne, QuantityValue.PositiveInfinity, QuantityValue.Zero);

                // negative infinity
                Add(QuantityValue.NegativeInfinity, QuantityValue.Zero, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, QuantityValue.One, QuantityValue.NegativeInfinity);
                Add(QuantityValue.NegativeInfinity, QuantityValue.MinusOne, QuantityValue.PositiveInfinity);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(-10, 0), QuantityValue.NaN);
                Add(QuantityValue.NegativeInfinity, new QuantityValue(10, 0), QuantityValue.NaN);

                // division by negative infinity
                Add(QuantityValue.Zero, QuantityValue.NegativeInfinity, QuantityValue.Zero);
                Add(QuantityValue.One, QuantityValue.NegativeInfinity, QuantityValue.Zero);
                Add(QuantityValue.MinusOne, QuantityValue.NegativeInfinity, QuantityValue.Zero);

                // NaN
                Add(QuantityValue.NaN, QuantityValue.NaN, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.Zero, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.One, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.MinusOne, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.PositiveInfinity, QuantityValue.NaN);
                Add(QuantityValue.NaN, QuantityValue.NegativeInfinity, QuantityValue.NaN);
            }

            private void Add(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
            {
                Add(new DivisionOperationTestCase(value1, value2, expectedValue));
            }

            public sealed record DivisionOperationTestCase : OperatorTestCase
            {
                public DivisionOperationTestCase()
                {
                }

                public DivisionOperationTestCase(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
                    : base(value1, value2, expectedValue)
                {
                }

                public override string ToString()
                {
                    // return $"{Value1} / {Value2} = {ExpectedValue}";
                    return $"{Value1.Numerator}/{Value1.Denominator} / {Value2.Numerator}/{Value2.Denominator} = {ExpectedValue.Numerator}/{ExpectedValue.Denominator}";
                }
            }
        }

        public sealed class ModulusTestData : TheoryData<OperatorTestCase>
        {
            public ModulusTestData()
            {
                Add(QuantityValue.One, QuantityValue.Zero, QuantityValue.NaN);
                Add(QuantityValue.Zero, QuantityValue.NaN, QuantityValue.NaN);
                Add(QuantityValue.Zero, QuantityValue.One, QuantityValue.Zero);
                Add(QuantityValue.PositiveInfinity, QuantityValue.One, QuantityValue.NaN);
                Add(QuantityValue.NegativeInfinity, QuantityValue.One, QuantityValue.NaN);
                Add(QuantityValue.One, QuantityValue.PositiveInfinity, QuantityValue.One);
                Add(QuantityValue.One, QuantityValue.NegativeInfinity, QuantityValue.One);
                Add(1, 2, 1);
                Add(new QuantityValue(1, 2), new QuantityValue(1, 5), new QuantityValue(1, 10));
                Add(new QuantityValue(1, 4), new QuantityValue(1, 2), new QuantityValue(1, 4));
                Add(new QuantityValue(1, 2), new QuantityValue(1, 4), QuantityValue.Zero);
                Add(new QuantityValue(1, 4), new QuantityValue(1, 10), new QuantityValue(5, 100));
            }

            private void Add(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
            {
                Add(new ModulusOperationTestCase(value1, value2, expectedValue));
            }

            public sealed record ModulusOperationTestCase : OperatorTestCase
            {
                public ModulusOperationTestCase()
                {
                }

                public ModulusOperationTestCase(QuantityValue value1, QuantityValue value2, QuantityValue expectedValue)
                    : base(value1, value2, expectedValue)
                {
                }

                public override string ToString()
                {
                    // return $"{Value1} % {Value2} = {ExpectedValue}";
                    return $"{Value1.Numerator}/{Value1.Denominator} % {Value2.Numerator}/{Value2.Denominator} = {ExpectedValue.Numerator}/{ExpectedValue.Denominator}";
                }
            }
        }
    }
}