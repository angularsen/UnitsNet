using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        ///     Types with <see cref="QuantityValue" /> as internal representation. 
        /// </summary>
        public class QuantitiesWithFractions
        {
            [Fact]
            public void LengthEquals_GivenMaxError_ReturnsTrueIfWithinError()
            {
                Assert.True(Length.FromMeters(1).Equals(Length.FromMeters(1), Length.Zero), "Equal values have zero difference.");
                Assert.True(Length.FromMeters(1).Equals(Length.FromMeters(1), Length.FromMillimeters(1e-5m)), "Using a max difference value should not change that fact.");

                Assert.True(Length.FromMeters(1 + 0.39).Equals(Length.FromMeters(1.39)),
                    "Example of floating precision arithmetic that would originally produces slightly different results is now correct:" +
                    "this is due to the implicit rounding (15 significant digits) that is applied when constructing from double.");
                
                Assert.True(Length.FromMeters((1 + 0.39) / double.MaxValue).Equals(Length.FromMeters(1.39 / double.MaxValue)),
                    "This is also true for very small values as they would be rounded the same way.");
                
                Assert.False((1.39 / double.MaxValue).Equals(Length.FromMeters(1.39 / double.MaxValue).Value.ToDouble()),
                    "The conversion back to double is not guaranteed to round-trip");
            }
            
            [Fact]
            public void QuantityValueComparisonEqualsAbsolute_ReturnsTrueIfWithinError()
            {
                Assert.True(Comparison.EqualsAbsolute(1, 1, 0));
                Assert.True(Comparison.EqualsAbsolute(1, 1, 0.001m));
                Assert.True(Comparison.EqualsAbsolute(1, 0.9999m, 0.001m));
                Assert.False(Comparison.EqualsAbsolute(1, 0.99m, 0.001m));
                Assert.False(Comparison.EqualsAbsolute(1, 0, 0.001m));
            }

            [Fact]
            public void QuantityValueComparisonEqualsAbsolute_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Comparison.EqualsAbsolute(1, 1, -1));
            }
            
            [Fact]
            public void QuantityValueComparisonEquals_GivenAbsoluteTolerance_ReturnsTrueIfWithinError()
            {
                Assert.True(Comparison.Equals(1, 1, 0, ComparisonType.Absolute));
                Assert.True(Comparison.Equals(1, 1, 0.001m, ComparisonType.Absolute));
                Assert.True(Comparison.Equals(1, 0.9999m, 0.001m, ComparisonType.Absolute));
                Assert.False(Comparison.Equals(1, 0.99m, 0.001m, ComparisonType.Absolute));
                Assert.False(Comparison.Equals(1, 0, 0.001m, ComparisonType.Absolute));
            }

            [Fact]
            public void QuantityValueComparisonEquals_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Comparison.Equals(1, 1, -1, ComparisonType.Absolute));
                Assert.Throws<ArgumentOutOfRangeException>(() => Comparison.Equals(1, 1, -1, ComparisonType.Relative));
            }

            [Fact]
            public void QuantityValueComparisonEquals_WithInvalidComparisonType_ThrowsArgumentOutOfRangeException()
            {
                Assert.Throws<InvalidOperationException>(() => Comparison.Equals(1, 1, 1, (ComparisonType)(-1)));
            }
            
            [Fact]
            public void QuantityValueComparisonEqualsRelative_ReturnsTrueIfWithinError()
            {
                Assert.True(Comparison.EqualsRelative(1, 1, 1e-5m));
                Assert.False(Comparison.EqualsRelative(1, 0, 1e-5m));
                Assert.True(Comparison.EqualsRelative(100, 120, 0.3m));
                Assert.False(Comparison.EqualsRelative(100, 120, 0.1m));
            }
            
            [Fact]
            public void QuantityValueComparisonEqualsRelative_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Comparison.EqualsRelative(1, 1, -1));
            }

            [Fact]
            public void QuantityValueComparisonEquals_GivenRelativeTolerance_ReturnsTrueIfWithinError()
            {
                Assert.True(Comparison.Equals(1, 1, 1e-5m, ComparisonType.Relative));
                Assert.False(Comparison.Equals(1, 0, 1e-5m, ComparisonType.Relative));
                Assert.True(Comparison.Equals(100, 120, 0.3m, ComparisonType.Relative));
                Assert.False(Comparison.Equals(100, 120, 0.1m, ComparisonType.Relative));
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
                    foreach (var divisor in GetMultipliers(firstQuantity.QuantityType))
                    {
                        var secondQuantity = Quantity.Infos.FirstOrDefault(x => x.QuantityType == divisor);
                        if (secondQuantity == null)
                        {
                            continue; // scalers
                        }
                        var resultDimensions = firstQuantity.BaseDimensions * secondQuantity.BaseDimensions;
                        var resultingType = GetMultiplicationResult(firstQuantity.QuantityType, secondQuantity.QuantityType);
                        var resultQuantity = Quantity.Infos.FirstOrDefault(x => x.QuantityType == resultingType);
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
                        var resultingType = GetDivisionResult(firstQuantity.QuantityType, secondQuantity.QuantityType);
                        var resultQuantity = Quantity.Infos.FirstOrDefault(x => x.QuantityType == resultingType);
                        if (resultQuantity == null)
                        {
                            continue; // scalers
                        }
                        Assert.Equal(resultQuantity.BaseDimensions, resultDimensions);
                    }
                }
            }

            public static IEnumerable<object[]> QuantitiesToMultiply { get; } = Quantity.Infos.SelectMany(s => GetMultipliers(s.QuantityType)
                .Where(multiplier=>
                {
                    if (!Quantity.ByName.ContainsKey(multiplier.Name)) return false;
                    Type? multiplicationResult = GetMultiplicationResult(s.QuantityType, multiplier);
                    return multiplicationResult != null && Quantity.ByName.ContainsKey(multiplicationResult.Name);
                }).Select(type => type.Name).Select(typeName => new[] { s.Name, typeName })).ToArray();

            [Theory(Skip = "Currently failing due to ElectricCurrent, MolarFlow, TemperatureGradient and FuelEfficiency")]
            [MemberData(nameof(QuantitiesToMultiply))]
            public void MultiplyingTwoQuantities_ReturnsQuantityInSIUnits(string leftName, string rightName)
            {
                var firstQuantity = Quantity.ByName[leftName];
                var secondQuantity = Quantity.ByName[rightName];

                IQuantity result = Multiply(firstQuantity.BaseUnitInfo.From(1), secondQuantity.BaseUnitInfo.From(1));
                if (result.QuantityInfo.BaseDimensions.IsDimensionless())
                {
                    Assert.Equal(result.QuantityInfo.BaseUnitInfo.Value, result.Unit);
                }
                // excluding results that don't have a valid base unit such as FuelEfficiency
                else if(result.QuantityInfo.UnitInfos.Any(unit => unit.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits)))
                {
                    Assert.True(result.QuantityInfo[result.Unit].BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
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
            
            private static IQuantity Multiply(IQuantity left, IQuantity right)
            {
                var leftType = left.GetType();
                var rightType = right.GetType();
                var multiplyMethod = GetMultiplyMethod(leftType, rightType);
                return (IQuantity)multiplyMethod.Invoke(null, new object[] { left, right })!;
            }
            private static MethodInfo GetMultiplyMethod(Type selfType, Type otherType)
            {
                return selfType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                    .FirstOrDefault(m => m.Name == "op_Multiply" &&
                                         m.GetParameters().Length == 2 &&
                                         m.GetParameters()[0].ParameterType == selfType &&
                                         m.GetParameters()[1].ParameterType == otherType)!;
            }

        }
    }
}
