using System;
using System.Collections.Generic;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class UnitMathTests
    {
        [Fact]
        public void AverageOfDifferentUnitsThrowsException()
        {
            var units = new IQuantity[] {Length.FromMeters(1), Volume.FromLiters(50)};

            Assert.Throws<ArgumentException>(() => units.Average(LengthUnit.Centimeter));
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

            Assert.Throws<ArgumentNullException>(() => units.Average((Func<KeyValuePair<string, Length>, Length>) null, LengthUnit.Centimeter));
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
        public void MaxOfDifferentUnitsThrowsException()
        {
            var units = new IQuantity[] {Length.FromMeters(1), Volume.FromLiters(50)};

            Assert.Throws<ArgumentException>(() => units.Max(LengthUnit.Centimeter));
        }

        [Fact]
        public void MaxOfEmptySourceThrowsException()
        {
            var units = new Length[] { };

            Assert.Throws<InvalidOperationException>(() => units.Max(LengthUnit.Centimeter));
        }

        [Fact]
        public void MaxOfLengthsCalculatesCorrectly()
        {
            var units = new[] {Length.FromMeters(1), Length.FromCentimeters(50)};

            Length max = units.Max(LengthUnit.Centimeter);

            Assert.Equal(100, max.Value);
            Assert.Equal(LengthUnit.Centimeter, max.Unit);
        }

        [Fact]
        public void MaxOfLengthsWithNullSelectorThrowsException()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length>("1", Length.FromMeters(1)),
                new KeyValuePair<string, Length>("2", Length.FromCentimeters(50))
            };

            Assert.Throws<ArgumentNullException>(() => units.Max((Func<KeyValuePair<string, Length>, Length>) null, LengthUnit.Centimeter));
        }

        [Fact]
        public void MaxOfLengthsWithSelectorCalculatesCorrectly()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length>("1", Length.FromMeters(1)),
                new KeyValuePair<string, Length>("2", Length.FromCentimeters(50))
            };

            Length max = units.Max(x => x.Value, LengthUnit.Centimeter);

            Assert.Equal(100, max.Value);
            Assert.Equal(LengthUnit.Centimeter, max.Unit);
        }

        [Fact]
        public void MinOfDifferentUnitsThrowsException()
        {
            var units = new IQuantity[] {Length.FromMeters(1), Volume.FromLiters(50)};

            Assert.Throws<ArgumentException>(() => units.Min(LengthUnit.Centimeter));
        }

        [Fact]
        public void MinOfEmptySourceThrowsException()
        {
            var units = new Length[] { };

            Assert.Throws<InvalidOperationException>(() => units.Min(LengthUnit.Centimeter));
        }

        [Fact]
        public void MinOfLengthsCalculatesCorrectly()
        {
            var units = new[] {Length.FromMeters(1), Length.FromCentimeters(50)};

            Length min = units.Min(LengthUnit.Centimeter);

            Assert.Equal(50, min.Value);
            Assert.Equal(LengthUnit.Centimeter, min.Unit);
        }

        [Fact]
        public void MinOfLengthsWithNullSelectorThrowsException()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length>("1", Length.FromMeters(1)),
                new KeyValuePair<string, Length>("2", Length.FromCentimeters(50))
            };

            Assert.Throws<ArgumentNullException>(() => units.Min((Func<KeyValuePair<string, Length>, Length>) null, LengthUnit.Centimeter));
        }

        [Fact]
        public void MinOfLengthsWithSelectorCalculatesCorrectly()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length>("1", Length.FromMeters(1)),
                new KeyValuePair<string, Length>("2", Length.FromCentimeters(50))
            };

            Length min = units.Min(x => x.Value, LengthUnit.Centimeter);

            Assert.Equal(50, min.Value);
            Assert.Equal(LengthUnit.Centimeter, min.Unit);
        }

        [Fact]
        public void SumOfDifferentUnitsThrowsException()
        {
            var units = new IQuantity[] {Length.FromMeters(1), Volume.FromLiters(50)};

            Assert.Throws<ArgumentException>(() => units.Sum(LengthUnit.Centimeter));
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

            Assert.Throws<ArgumentNullException>(() => units.Sum((Func<KeyValuePair<string, Length>, Length>) null, LengthUnit.Centimeter));
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
    }
}
