using System;
using System.Collections.Generic;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class UnitMathTests
    {
        [Fact]
        public void AbsoluteValueOfZeroReturnsZero()
        {
            var quantity = Length.Zero;

            var result = quantity.Abs();

            Assert.StrictEqual(quantity, result);
        }

        [Fact]
        public void AbsoluteValueOfPositiveReturnsSameValue()
        {
            var quantity = Length.FromCentimeters(1);

            var result = quantity.Abs();

            Assert.StrictEqual(quantity, result);
        }

        [Fact]
        public void AbsoluteValueOfNegativeReturnsPositive()
        {
            var quantity = Length.FromCentimeters(-1);

            var result = quantity.Abs();

            Assert.StrictEqual(-quantity, result);
        }

        [Fact]
        public void AverageOfEmptySourceThrowsException()
        {
            var units = new Length[] { };

            Assert.Throws<InvalidOperationException>(() => units.Average(LengthUnit.Centimeter));
        }

        [Fact]
        public void AverageOfLengthsCalculatesCorrectly()
        {
            var units = new[] {Length.FromMeters(1), Length.FromCentimeters(50)};

            Length average = units.Average(LengthUnit.Centimeter);

            Assert.Equal(75, average.Value);
            Assert.Equal(LengthUnit.Centimeter, average.Unit);
        }

        [Fact]
        public void AverageOfLengthsWithNullSelectorThrowsException()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length>("1", Length.FromMeters(1)),
                new KeyValuePair<string, Length>("2", Length.FromCentimeters(50))
            };

            Assert.Throws<ArgumentNullException>(() => units.Average((Func<KeyValuePair<string, Length>, Length>) null!, LengthUnit.Centimeter));
        }

        [Fact]
        public void AverageOfLengthsWithSelectorCalculatesCorrectly()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length>("1", Length.FromMeters(1)),
                new KeyValuePair<string, Length>("2", Length.FromCentimeters(50))
            };

            Length average = units.Average(x => x.Value, LengthUnit.Centimeter);

            Assert.Equal(75, average.Value);
            Assert.Equal(LengthUnit.Centimeter, average.Unit);
        }

        [Fact]
        public void MaxOfTwoLengthsReturnsTheLargestValue()
        {
            var firstValue = Length.FromMeters(1);
            var secondValue = Length.FromCentimeters(50);

            Length max = UnitMath.Max(firstValue, secondValue);

            Assert.Equal(1, max.Value);
            Assert.Equal(LengthUnit.Meter, max.Unit);
        }

        [Fact]
        public void MinOfTwoLengthsReturnsTheSmallestValue()
        {
            var firstValue = Length.FromMeters(1);
            var secondValue = Length.FromCentimeters(50);

            Length min = UnitMath.Min(firstValue, secondValue);

            Assert.Equal(50, min.Value);
            Assert.Equal(LengthUnit.Centimeter, min.Unit);
        }

        [Fact]
        public void SumOfEmptySourceReturnsZero()
        {
            var units = new Length[] { };

            Length sum = units.Sum(Length.BaseUnit);

            Assert.Equal(Length.Zero, sum);
        }

        [Fact]
        public void SumOfLengthsCalculatesCorrectly()
        {
            var units = new[] {Length.FromMeters(1), Length.FromCentimeters(50)};

            Length sum = units.Sum(LengthUnit.Centimeter);

            Assert.Equal(150, sum.Value);
            Assert.Equal(LengthUnit.Centimeter, sum.Unit);
        }

        [Fact]
        public void SumOfLengthsWithNullSelectorThrowsException()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length>("1", Length.FromMeters(1)),
                new KeyValuePair<string, Length>("2", Length.FromCentimeters(50))
            };

            Assert.Throws<ArgumentNullException>(() => units.Sum((Func<KeyValuePair<string, Length>, Length>) null!, LengthUnit.Centimeter));
        }

        [Fact]
        public void SumOfLengthsWithSelectorCalculatesCorrectly()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length>("1", Length.FromMeters(1)),
                new KeyValuePair<string, Length>("2", Length.FromCentimeters(50))
            };

            Length sum = units.Sum(x => x.Value, LengthUnit.Centimeter);

            Assert.Equal(150, sum.Value);
            Assert.Equal(LengthUnit.Centimeter, sum.Unit);
        }

        [Fact]
        public void Clamp_ReturnsValue_WhenWithinBounds()
        {
            var min = Length.FromMeters(-1);
            var max = Length.FromCentimeters(150);
            var value = Length.FromMillimeters(33);
            
            Length clampedValue = UnitMath.Clamp(value, min, max);
            
            Assert.Equal(33, clampedValue.Value);
            Assert.Equal(LengthUnit.Millimeter, clampedValue.Unit);
        }

        [Fact]
        public void Clamp_ReturnsMinAsValueUnit_WhenValueIsBelowMin()
        {
            var min = Length.FromMeters(-1);
            var max = Length.FromCentimeters(150);
            var value = Length.FromMillimeters(-1500);
            
            Length clampedMin = UnitMath.Clamp(value, min, max);
            
            Assert.Equal(-1000, clampedMin.Value);
            Assert.Equal(LengthUnit.Millimeter, clampedMin.Unit);
        }

        [Fact]
        public void Clamp_ReturnsMaxAsValueUnit_WhenValueIsAboveMax()
        {
            var min = Length.FromMeters(-1);
            var max = Length.FromCentimeters(150);
            var value = Length.FromMillimeters(2000);
            
            Length clampedMax = UnitMath.Clamp(value, min, max);
            
            Assert.Equal(1500, clampedMax.Value);
            Assert.Equal(LengthUnit.Millimeter, clampedMax.Unit);
        }

        [Fact]
        public void ClampMinGreaterThanMaxThrowsException()
        {
            var min = Length.FromMeters(2);
            var max = Length.FromCentimeters(150);
            var value = Length.FromMillimeters(33);

            Assert.Throws<ArgumentException>(() => UnitMath.Clamp(value, min, max));
        }
    }
}
