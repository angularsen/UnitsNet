using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitsNet.Tests
{
    /// <summary>
    ///     Tests that cover generated code in quantity structs, such as <see cref="Length" /> and <see cref="Mass" />.
    ///     The idea is to move tests that cover uniformly generated code here, because repeating the exact same test N times
    ///     over don't make it safer.
    /// </summary>
    public class GeneratedQuantityCodeTests
    {
        /// <summary>
        ///     Types with <see cref="double" /> as internal representation. This is the majority of units, such as
        ///     <see cref="Length" />.
        /// </summary>
        public class QuantitiesWithDouble
        {
            [Fact]
            public void LengthEquals_GivenMaxError_ReturnsTrueIfWithinError()
            {
                var smallError = 1e-5;

                Assert.True(Length.FromMeters(1).Equals(Length.FromMeters(1), 0, ComparisonType.Relative), "Integer values have zero difference.");
                Assert.True(Length.FromMeters(1).Equals(Length.FromMeters(1), smallError, ComparisonType.Relative), "Using a max difference value should not change that fact.");

                Assert.False(Length.FromMeters(1 + 0.39).Equals(Length.FromMeters(1.39), 0, ComparisonType.Relative),
                    "Example of floating precision arithmetic that produces slightly different results.");
                Assert.True(Length.FromMeters(1 + 0.39).Equals(Length.FromMeters(1.39), smallError, ComparisonType.Relative), "But the difference is very small");
            }

            [Fact]
            public void HasMultiplicationOperator_GivenMassAndVolume_ReturnsFalse()
            {
                Assert.False(HasMultiplicationOperator(typeof(Mass), typeof(Volume)));
                Assert.DoesNotContain(typeof(Volume), GetMultipliers(typeof(Mass)));
            }

            [Fact]
            public void HasMultiplicationOperator_GivenDensityAndVolume_ReturnsTrue()
            {
                Assert.True(HasMultiplicationOperator(typeof(Density), typeof(Volume)));
                Assert.Contains(typeof(Volume), GetMultipliers(typeof(Density)));
                Assert.Equal(typeof(Mass), GetMultiplicationResult(typeof(Density), typeof(Volume)));
            }

            [Fact]
            public void HasDivisionOperator_GivenDensityAndVolume_ReturnsFalse()
            {
                Assert.False(HasDivisionOperator(typeof(Density), typeof(Volume)));
                Assert.DoesNotContain(typeof(Volume), GetDivisors(typeof(Density)));
            }

            [Fact]
            public void HasDivisionOperator_GivenMassAndVolume_ReturnsTrue()
            {
                Assert.True(HasDivisionOperator(typeof(Mass), typeof(Volume)));
                Assert.Contains(typeof(Volume), GetDivisors(typeof(Mass)));
                Assert.Equal(typeof(Density), GetDivisionResult(typeof(Mass), typeof(Volume)));
            }

            [Fact]
            public void HasMultiplicationOperator_GivenTwoQuantities_ReturnsTrueIfDimensionsMultiplicationIsValid()
            {
                foreach (var firstQuantity in Quantity.Infos)
                {
                    foreach (var divisor in GetMultipliers(firstQuantity.ValueType))
                    {
                        var secondQuantity = Quantity.Infos.FirstOrDefault(x => x.ValueType == divisor);
                        if (secondQuantity == null)
                        {
                            continue; // scalers
                        }
                        var resultDimensions = firstQuantity.BaseDimensions * secondQuantity.BaseDimensions;
                        var resultingType = GetMultiplicationResult(firstQuantity.ValueType, secondQuantity.ValueType);
                        var resultQuantity = Quantity.Infos.FirstOrDefault(x => x.ValueType == resultingType);
                        if (resultQuantity == null)
                        {
                            continue; // scalers
                        }
                        Assert.Equal(resultQuantity.BaseDimensions, resultDimensions);
                    }
                }
            }

            [Fact]
            public void HasDivisionOperator_GivenTwoQuantities_ReturnsTrueIfDimensionsDivisionIsValid()
            {
                foreach (var firstQuantity in Quantity.Infos)
                {
                    foreach (var divisor in GetDivisors(firstQuantity.ValueType))
                    {
                        var secondQuantity = Quantity.Infos.FirstOrDefault(x => x.ValueType == divisor);
                        if (secondQuantity == null)
                        {
                            continue; // scalers
                        }
                        var resultDimensions = firstQuantity.BaseDimensions / secondQuantity.BaseDimensions;
                        var resultingType = GetDivisionResult(firstQuantity.ValueType, secondQuantity.ValueType);
                        var resultQuantity = Quantity.Infos.FirstOrDefault(x => x.ValueType == resultingType);
                        if (resultQuantity == null)
                        {
                            continue; // scalers
                        }
                        Assert.Equal(resultQuantity.BaseDimensions, resultDimensions);
                    }
                }
            }

            private static bool HasMultiplicationOperator(Type t, Type operandType)
            {
                var operation = t.GetMethod("op_Multiply", new[] { t, operandType });
                return operation != null && operation.IsSpecialName;
            }

            private static bool HasDivisionOperator(Type t, Type operandType)
            {
                var operation = t.GetMethod("op_Division", new[] { t, operandType });
                return operation != null && operation.IsSpecialName;
            }

            private static Type? GetMultiplicationResult(Type t, Type operandType)
            {
                var operation = t.GetMethod("op_Multiply", new[] { t, operandType });
                return operation != null && operation.IsSpecialName ? operation.ReturnType : null;
            }

            private static Type? GetDivisionResult(Type t, Type operandType)
            {
                var operation = t.GetMethod("op_Division", new[] { t, operandType });
                return operation != null && operation.IsSpecialName ? operation.ReturnType : null;
            }

            private static IEnumerable<Type> GetMultipliers(Type t)
            {
                return t.GetMethods().Where(x => x.IsSpecialName && x.Name == "op_Multiply" && x.CustomAttributes.All(a => a.AttributeType != typeof(ObsoleteAttribute)))
                    .SelectMany(x => x.GetParameters().Skip(1).Select(p => p.ParameterType));
            }

            private static IEnumerable<Type> GetDivisors(Type t)
            {
                return t.GetMethods().Where(x => x.IsSpecialName && x.Name == "op_Division" && x.CustomAttributes.All(a => a.AttributeType != typeof(ObsoleteAttribute)))
                    .SelectMany(x => x.GetParameters().Skip(1).Select(p => p.ParameterType));
            }
        }
    }
}
