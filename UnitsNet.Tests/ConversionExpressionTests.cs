// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text;
using Xunit;

namespace UnitsNet.Tests
{
    public class ConversionExpressionTest
    {
        [Fact]
        public void Constructor_WithAllParameters_ShouldInitializeProperties()
        {
            // Arrange
            QuantityValue coefficient = 2.0m;
            ConvertValueDelegate? nestedFunction = value => value * 2;
            var exponent = 3;
            QuantityValue constantTerm = 5.0m;
            // Act
            var conversionExpression = new ConversionExpression(coefficient, nestedFunction, exponent, constantTerm);
            // Assert
            Assert.Equal(coefficient, conversionExpression.Coefficient);
            Assert.Equal(exponent, conversionExpression.Exponent);
            Assert.Equal(nestedFunction, conversionExpression.NestedFunction);
            Assert.Equal(constantTerm, conversionExpression.ConstantTerm);
        }

        [Fact]
        public void Constructor_WithCoefficientAndConstantTerm_ShouldInitializeProperties()
        {
            // Arrange
            QuantityValue coefficient = 2.0m;
            QuantityValue constantTerm = 5.0m;
            // Act
            var conversionExpression = new ConversionExpression(coefficient, constantTerm);
            // Assert
            Assert.Equal(coefficient, conversionExpression.Coefficient);
            Assert.Null(conversionExpression.NestedFunction);
            Assert.Equal(1, conversionExpression.Exponent);
            Assert.Equal(constantTerm, conversionExpression.ConstantTerm);
        }

        [Fact]
        public void Constructor_WithCoefficient_ShouldInitializeProperties()
        {
            // Arrange
            QuantityValue coefficient = 2.0m;
            // Act
            var conversionExpression = new ConversionExpression(coefficient);
            // Assert
            Assert.Equal(coefficient, conversionExpression.Coefficient);
            Assert.Null(conversionExpression.NestedFunction);
            Assert.Equal(1, conversionExpression.Exponent);
            Assert.True(QuantityValue.IsZero(conversionExpression.ConstantTerm));
        }

        [Fact]
        public void ImplicitConversion_FromQuantityValue_ShouldInitializeTheCoefficient()
        {
            // Arrange
            QuantityValue quantityValue = 2.0m;
            // Act
            ConversionExpression conversionExpression = quantityValue;
            // Assert
            Assert.Equal(quantityValue, conversionExpression.Coefficient);
            Assert.Null(conversionExpression.NestedFunction);
            Assert.Equal(1, conversionExpression.Exponent);
            Assert.True(QuantityValue.IsZero(conversionExpression.ConstantTerm));
        }

        [Fact]
        public void ImplicitConversion_FromInt_ShouldInitializeTheCoefficient()
        {
            // Arrange
            var value = 2;
            // Act
            ConversionExpression conversionExpression = value;
            // Assert
            Assert.Equal(value, conversionExpression.Coefficient);
            Assert.Null(conversionExpression.NestedFunction);
            Assert.Equal(1, conversionExpression.Exponent);
            Assert.True(QuantityValue.IsZero(conversionExpression.ConstantTerm));
        }

        [Fact]
        public void ImplicitConversion_FromLong_ShouldInitializeTheCoefficient()
        {
            // Arrange
            long value = 2;
            // Act
            ConversionExpression conversionExpression = value;
            // Assert
            Assert.Equal(value, conversionExpression.Coefficient);
            Assert.Null(conversionExpression.NestedFunction);
            Assert.Equal(1, conversionExpression.Exponent);
            Assert.True(QuantityValue.IsZero(conversionExpression.ConstantTerm));
        }

        [Theory]
        [InlineData(0, 1, 0, 0, 0)]
        [InlineData(1, 1, 2, 3, 5)] // x + 2 with x = 3 -> 3 + 2 = 5
        [InlineData(2, 2, 3, 4, 35)] // 2x^2 + 3 with x = 4 -> 2 * 16 + 3 = 35
        [InlineData(-1, 1, -2, -3, 1)] // -x - 2 with x = -3 -> 3 - 2 = 1
        public void Evaluate_Value_ReturnsExpectedResult(double coefficient, int exponent, double constantTerm, double value, double expected)
        {
            var expression = new ConversionExpression(coefficient, null, exponent, constantTerm);
            QuantityValue result = expression.Evaluate(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 1, 0, 0, 0)]
        [InlineData(1, 1, 2, 3, 0.5)] // g(x) + 2 with x = 3 -> -1.5 + 2 = 0.5
        [InlineData(2, 2, 3, 4, 11)] // 2 * g(x)^2 + 3 with x = 4 -> 2 * (-2)^2 + 3 = 11
        [InlineData(-1, 1, -2, -3, -3.5)] // -g(x) - 2 with x = -3 -> -1.5 - 2 = -3.5
        public void Evaluate_Value_WithNestedFunction_ReturnsExpectedResult(double coefficient, int exponent, double constantTerm, double value,
            double expected)
        {
            var expression = new ConversionExpression(coefficient, quantityValue => -quantityValue / 2, exponent, constantTerm);
            QuantityValue result = expression.Evaluate(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 1, 0)] 
        [InlineData(10, 1, 0)] 
        [InlineData(-1, 1, 0)]
        [InlineData(-10, 1, 0)]
        [InlineData(0, 1, 5)]
        [InlineData(1, 1, 5)] 
        [InlineData(10, 1, 5)] 
        [InlineData(-1, 1, 5)]
        [InlineData(-10, 1, 5)]
        [InlineData(0, 1, -5)]
        [InlineData(1, 1, -5)] 
        [InlineData(10, 1, -5)] 
        [InlineData(-10, 1, -5)]
        [InlineData(-1, 1, -5)]
        [InlineData(0, -1, 0)]
        [InlineData(1, -1, 0)] 
        [InlineData(10, -1, 0)] 
        [InlineData(-1, -1, 0)]
        [InlineData(-10, -1, 0)]
        [InlineData(0, -1, 5)]
        [InlineData(1, -1, 5)] 
        [InlineData(10, -1, 5)] 
        [InlineData(-10, -1, 5)]
        [InlineData(-1, -1, 5)]
        [InlineData(0, -1, -5)]
        [InlineData(1, -1, -5)] 
        [InlineData(10, -1, -5)] 
        [InlineData(-1, -1, -5)]
        [InlineData(-10, -1, -5)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 2, 0)] 
        [InlineData(10, 2, 0)] 
        [InlineData(-10, 2, 0)]
        [InlineData(-1, 2, 0)]
        [InlineData(0, 2, 5)]
        [InlineData(1, 2, 5)] 
        [InlineData(10, 2, 5)] 
        [InlineData(-1, 2, 5)]
        [InlineData(-10, 2, 5)]
        [InlineData(0, 2, -5)]
        [InlineData(1, 2, -5)] 
        [InlineData(10, 2, -5)] 
        [InlineData(-1, 2, -5)]
        [InlineData(-10, 2, -5)]
        [InlineData(0, -2, 0)]
        [InlineData(1, -2, 0)] 
        [InlineData(10, -2, 0)] 
        [InlineData(-1, -2, 0)]
        [InlineData(-10, -2, 0)]
        [InlineData(0, -2, 5)]
        [InlineData(1, -2, 5)] 
        [InlineData(10, -2, 5)] 
        [InlineData(-1, -2, 5)]
        [InlineData(-10, -2, 5)]
        [InlineData(0, -2, -5)]
        [InlineData(1, -2, -5)] 
        [InlineData(10, -2, -5)] 
        [InlineData(-1, -2, -5)]
        [InlineData(-10, -2, -5)]
        public void ExpressionWithoutNestedFunction_ConvertsTo_ConvertValueDelegate(double coefficient, int exponent, double constantTerm)
        {
            // Arrange
            var expression = new ConversionExpression(coefficient, null, exponent, constantTerm);
            QuantityValue expectedValueFor10 = expression.Evaluate(QuantityValue.Ten);
            // Act
            ConvertValueDelegate conversionFunction = expression;
            // Assert
            Assert.Equal(expectedValueFor10, conversionFunction(QuantityValue.Ten));
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 1, 0)] 
        [InlineData(10, 1, 0)] 
        [InlineData(-1, 1, 0)]
        [InlineData(-10, 1, 0)]
        [InlineData(0, 1, 5)]
        [InlineData(1, 1, 5)] 
        [InlineData(10, 1, 5)] 
        [InlineData(-1, 1, 5)]
        [InlineData(-10, 1, 5)]
        [InlineData(0, 1, -5)]
        [InlineData(1, 1, -5)] 
        [InlineData(10, 1, -5)] 
        [InlineData(-10, 1, -5)]
        [InlineData(-1, 1, -5)]
        [InlineData(0, -1, 0)]
        [InlineData(1, -1, 0)] 
        [InlineData(10, -1, 0)] 
        [InlineData(-1, -1, 0)]
        [InlineData(-10, -1, 0)]
        [InlineData(0, -1, 5)]
        [InlineData(1, -1, 5)] 
        [InlineData(10, -1, 5)] 
        [InlineData(-10, -1, 5)]
        [InlineData(-1, -1, 5)]
        [InlineData(0, -1, -5)]
        [InlineData(1, -1, -5)] 
        [InlineData(10, -1, -5)] 
        [InlineData(-1, -1, -5)]
        [InlineData(-10, -1, -5)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 2, 0)] 
        [InlineData(10, 2, 0)] 
        [InlineData(-10, 2, 0)]
        [InlineData(-1, 2, 0)]
        [InlineData(0, 2, 5)]
        [InlineData(1, 2, 5)] 
        [InlineData(10, 2, 5)] 
        [InlineData(-1, 2, 5)]
        [InlineData(-10, 2, 5)]
        [InlineData(0, 2, -5)]
        [InlineData(1, 2, -5)] 
        [InlineData(10, 2, -5)] 
        [InlineData(-1, 2, -5)]
        [InlineData(-10, 2, -5)]
        [InlineData(0, -2, 0)]
        [InlineData(1, -2, 0)] 
        [InlineData(10, -2, 0)] 
        [InlineData(-1, -2, 0)]
        [InlineData(-10, -2, 0)]
        [InlineData(0, -2, 5)]
        [InlineData(1, -2, 5)] 
        [InlineData(10, -2, 5)] 
        [InlineData(-1, -2, 5)]
        [InlineData(-10, -2, 5)]
        [InlineData(0, -2, -5)]
        [InlineData(1, -2, -5)] 
        [InlineData(10, -2, -5)] 
        [InlineData(-1, -2, -5)]
        [InlineData(-10, -2, -5)]
        public void ExpressionWithNestedFunction_ConvertsTo_ConvertValueDelegate(double coefficient, int exponent, double constantTerm)
        {
            // Arrange
            var expression = new ConversionExpression(coefficient, quantityValue => -quantityValue / 2, exponent, constantTerm);
            QuantityValue expectedValueFor10 = expression.Evaluate(QuantityValue.Ten);
            // Act
            ConvertValueDelegate conversionFunction = expression;
            // Assert
            Assert.Equal(expectedValueFor10, conversionFunction(QuantityValue.Ten));
        }

        [Theory]
        [InlineData(0, 1, 0, 0, 1, 0)]
        [InlineData(10, 1, 0, 2, 1, 0)]
        [InlineData(0.1, 2, 0, 4, -1, 0)]
        [InlineData(-1, 1, -2, -3, -2, 0)]
        [InlineData(10, 1, 5, 2, 1, 0)]
        [InlineData(2, 1, 0, 3, 1, 10)]
        [InlineData(1, 1, 2, 3, 1, 10)]
        [InlineData(2, 2, 3, 4, -1, 38)]
        [InlineData(-1, 1, -2, -3, -2, -14)]
        [InlineData(0, -1, 0, 0, 1, 0)]
        [InlineData(10, -1, 0, 2, 1, 0)]
        [InlineData(0.1, -2, 0, 4, -1, 0)]
        [InlineData(-1, -1, -2, -3, -2, 0)]
        [InlineData(10, -1, 5, 2, 1, 0)]
        [InlineData(2, -1, 0, 3, 1, 10)]
        [InlineData(1, -1, 2, 3, 1, 10)]
        [InlineData(2, -2, 3, 4, -1, 38)]
        [InlineData(-1, -1, -2, -3, -2, -14)]
        public void Evaluate_IntermediateExpression_ReturnsExpectedResult(decimal coefficient1, int exponent1, decimal constantTerm1,
            decimal coefficient2, int exponent2, decimal constantTerm2)
        {
            // Arrange
            var expression1 = new ConversionExpression(coefficient1, null, exponent1, constantTerm1);
            var expression2 = new ConversionExpression(coefficient2, null, exponent2, constantTerm2);
            QuantityValue expectedValueFor10 = expression1.Evaluate(expression2.Evaluate(QuantityValue.Ten));
            // Act
            ConversionExpression compositeExpression = expression1.Evaluate(expression2);
            // Assert
            if (expression1.Exponent == 1 || expression1.Exponent == -1 && expression2.ConstantTerm == QuantityValue.Zero)
            {
                Assert.Null(compositeExpression.NestedFunction);
            }
            else
            {
                Assert.NotNull(compositeExpression.NestedFunction);
            }

            Assert.Equal(expectedValueFor10, compositeExpression.Evaluate(QuantityValue.Ten));
        }

        [Theory]
        [InlineData(0, 1, 0, 0, 1, 0)]
        [InlineData(10, 1, 0, 2, 1, 0)]
        [InlineData(0.1, 2, 0, 4, -1, 0)]
        [InlineData(-1, 1, -2, -3, -2, 0)]
        [InlineData(10, 1, 5, 2, 1, 0)]
        [InlineData(2, 1, 0, 3, 1, 10)]
        [InlineData(1, 1, 2, 3, 1, 10)]
        [InlineData(2, 2, 3, 4, -1, 38)]
        [InlineData(-1, 1, -2, -3, -2, -14)]
        [InlineData(0, -1, 0, 0, 1, 0)]
        [InlineData(10, -1, 0, 2, 1, 0)]
        [InlineData(0.1, -2, 0, 4, -1, 0)]
        [InlineData(-1, -1, -2, -3, -2, 0)]
        [InlineData(10, -1, 5, 2, 1, 0)]
        [InlineData(2, -1, 0, 3, 1, 10)]
        [InlineData(1, -1, 2, 3, 1, 10)]
        [InlineData(2, -2, 3, 4, -1, 38)]
        [InlineData(-1, -1, -2, -3, -2, -14)]
        public void EvaluateAndReduce_IntermediateExpression_ReturnsExpectedResult(decimal coefficient1, int exponent1, decimal constantTerm1,
            decimal coefficient2, int exponent2, decimal constantTerm2)
        {
            // Arrange
            var expression1 = new ConversionExpression(coefficient1, null, exponent1, constantTerm1);
            var expression2 = new ConversionExpression(coefficient2, null, exponent2, constantTerm2);
            QuantityValue expectedValueFor10 = expression1.Evaluate(expression2.Evaluate(QuantityValue.Ten));
            // Act
            ConversionExpression compositeExpression = expression1.Evaluate(expression2, true);
            // Assert
            if (expression1.Exponent == 1 || expression1.Exponent == -1 && expression2.ConstantTerm == QuantityValue.Zero)
            {
                Assert.Null(compositeExpression.NestedFunction);
            }
            else
            {
                Assert.NotNull(compositeExpression.NestedFunction);
            }

            Assert.True(QuantityValue.IsCanonical(compositeExpression.Coefficient));
            Assert.Equal(expectedValueFor10, compositeExpression.Evaluate(QuantityValue.Ten));
        }

        [Theory]
        [InlineData(0, 1, 0, 0, 1, 0)]
        [InlineData(10, 1, 0, 2, 1, 0)]
        [InlineData(0.1, 2, 0, 4, -1, 0)]
        [InlineData(-1, 1, -2, -3, -2, 0)]
        [InlineData(10, 1, 5, 2, 1, 0)]
        [InlineData(2, 1, 0, 3, 1, 10)]
        [InlineData(1, 1, 2, 3, 1, 10)]
        [InlineData(2, 2, 3, 4, -1, 38)]
        [InlineData(-1, 1, -2, -3, -2, -14)]
        [InlineData(0, -1, 0, 0, 1, 0)]
        [InlineData(10, -1, 0, 2, 1, 0)]
        [InlineData(0.1, -2, 0, 4, -1, 0)]
        [InlineData(-1, -1, -2, -3, -2, 0)]
        [InlineData(10, -1, 5, 2, 1, 0)]
        [InlineData(2, -1, 0, 3, 1, 10)]
        [InlineData(1, -1, 2, 3, 1, 10)]
        [InlineData(2, -2, 3, 4, -1, 38)]
        [InlineData(-1, -1, -2, -3, -2, -14)]
        public void Evaluate_IntermediateExpression_WithNestedFunctions_ReturnsExpectedResult(decimal coefficient1, int exponent1, decimal constantTerm1,
            decimal coefficient2, int exponent2, decimal constantTerm2)
        {
            // Arrange
            var expression1 = new ConversionExpression(coefficient1, QuantityValue.Abs, exponent1, constantTerm1);
            var expression2 = new ConversionExpression(coefficient2, QuantityValue.Inverse, exponent2, constantTerm2);
            QuantityValue expectedValueFor10 = expression1.Evaluate(expression2.Evaluate(QuantityValue.Ten));
            // Act
            ConversionExpression compositeExpression = expression1.Evaluate(expression2);
            // Assert
            Assert.Equal(expression1.Coefficient, compositeExpression.Coefficient);
            Assert.NotNull(compositeExpression.NestedFunction);
            Assert.NotEqual(expression1.NestedFunction, compositeExpression.NestedFunction);
            Assert.NotEqual(expression2.NestedFunction, compositeExpression.NestedFunction);
            Assert.Equal(expression1.Exponent, compositeExpression.Exponent);
            Assert.Equal(expression1.ConstantTerm, compositeExpression.ConstantTerm);
            Assert.Equal(expectedValueFor10, compositeExpression.Evaluate(QuantityValue.Ten));
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 3)]
        [InlineData(0, 1, 0)]
        [InlineData(-1, 1, -2)]
        public void Negate_ReturnsExpectedResult(double coefficient, int exponent, double constantTerm)
        {
            // Arrange
            var expression = new ConversionExpression(coefficient, null, exponent, constantTerm);
            QuantityValue expectedCoefficient = -expression.Coefficient;
            QuantityValue expectedConstantTerm = -expression.ConstantTerm;
            // Act
            ConversionExpression negatedExpression = -expression;
            // Assert
            Assert.Equal(expectedCoefficient, negatedExpression.Coefficient);
            Assert.Null(negatedExpression.NestedFunction);
            Assert.Equal(expression.Exponent, negatedExpression.Exponent);
            Assert.Equal(expectedConstantTerm, negatedExpression.ConstantTerm);
        }
        
        [Theory]
        [InlineData(0, 1, 0, "0 * x")]
        [InlineData(1, 1, 2, "x + 2")]
        [InlineData(2, 2, 3, "2 * x^2 + 3")]
        [InlineData(-1, 1, -2, "-x - 2")]
        [InlineData(-2.5, 1, -2, "-2.5 * x - 2")]
        [InlineData(2, -1, 2, "2 / x + 2")]
        [InlineData(2, -2, 2, "2 * x^-2 + 2")]
        public void ToString_ReturnsExpectedResult(double coefficient, int exponent, double constantTerm, string expected)
        {
            var expression = new ConversionExpression(coefficient, null, exponent, constantTerm);
            var result = expression.ToString();
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void PrintMembers_ShouldReturnCorrectString()
        {
            var conversionExpression = new ConversionExpression(1);
            var stringBuilder = new StringBuilder();
            
            var success = conversionExpression.GetType().GetMethod("PrintMembers", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .Invoke(conversionExpression, [stringBuilder]);

            Assert.Equal(true, success);
            Assert.Equal("Coefficient = 1, Exponent = 1, ConstantTerm = 0", stringBuilder.ToString());
        }
        
        [Fact]
        public void PrintMembers_WithNestedFunction_ShouldReturnCorrectString()
        {
            var conversionExpression = new ConversionExpression(1, QuantityValue.Inverse);
            var stringBuilder = new StringBuilder();
            
            var success = conversionExpression.GetType().GetMethod("PrintMembers", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .Invoke(conversionExpression, [stringBuilder]);

            Assert.Equal(true, success);
            Assert.Equal("Coefficient = 1, Exponent = 1, ConstantTerm = 0, NestedFunction = Inverse", stringBuilder.ToString());
        }
    }
}
