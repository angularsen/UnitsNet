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
            var units = new IQuantity[] {Length<double>.FromMeters(1), Volume<double>.FromLiters(50)};

            Assert.Throws<ArgumentException>(() => units.Average<IQuantity, double>(LengthUnit.Centimeter));
        }

        [Fact]
        public void AverageOfEmptySourceThrowsException()
        {
            var units = new Length<double>[] { };

            Assert.Throws<InvalidOperationException>(() => units.Average<Length<double>, double>(LengthUnit.Centimeter));
        }

        [Fact]
        public void AverageOfLengthsCalculatesCorrectly()
        {
            var units = new[] {Length<double>.FromMeters(1), Length<double>.FromCentimeters(50)};

            var average = units.Average<Length<double>, double>( LengthUnit.Centimeter);

            Assert.Equal(75, average.Value);
            Assert.Equal(LengthUnit.Centimeter, average.Unit);
        }

        [Fact]
        public void AverageOfLengthsWithNullSelectorThrowsException()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length<double>>("1", Length<double>.FromMeters(1)),
                new KeyValuePair<string, Length<double>>("2", Length<double>.FromCentimeters(50))
            };

            Assert.Throws<ArgumentNullException>(() => units.Average<KeyValuePair<string, Length<double>>, Length<double>, double>((Func<KeyValuePair<string, Length<double>>, Length<double>>) null, LengthUnit.Centimeter));
        }

        [Fact]
        public void AverageOfLengthsWithSelectorCalculatesCorrectly()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length<double>>("1", Length<double>.FromMeters(1)),
                new KeyValuePair<string, Length<double>>("2", Length<double>.FromCentimeters(50))
            };

            var average = units.Average<KeyValuePair<string, Length<double>>, Length<double>, double>( x => x.Value, LengthUnit.Centimeter);

            Assert.Equal(75, average.Value);
            Assert.Equal(LengthUnit.Centimeter, average.Unit);
        }

        [Fact]
        public void MaxOfDifferentUnitsThrowsException()
        {
            var units = new IQuantity[] {Length<double>.FromMeters(1), Volume<double>.FromLiters(50)};

            Assert.Throws<ArgumentException>(() => units.Max<IQuantity, double>(LengthUnit.Centimeter));
        }

        [Fact]
        public void MaxOfEmptySourceThrowsException()
        {
            var units = new Length<double>[] { };

            Assert.Throws<InvalidOperationException>(() => units.Max<Length<double>, double>(LengthUnit.Centimeter));
        }

        [Fact]
        public void MaxOfLengthsCalculatesCorrectly()
        {
            var units = new[] {Length<double>.FromMeters(1), Length<double>.FromCentimeters(50)};

            var max = units.Max<Length<double>, double>(LengthUnit.Centimeter);

            Assert.Equal(100, max.Value);
            Assert.Equal(LengthUnit.Centimeter, max.Unit);
        }

        [Fact]
        public void MaxOfLengthsWithNullSelectorThrowsException()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length<double>>("1", Length<double>.FromMeters(1)),
                new KeyValuePair<string, Length<double>>("2", Length<double>.FromCentimeters(50))
            };

            Assert.Throws<ArgumentNullException>(() => units.Max<KeyValuePair<string, Length<double>>, Length<double>, double>( (Func<KeyValuePair<string, Length<double>>, Length<double>>) null, LengthUnit.Centimeter));
        }

        [Fact]
        public void MaxOfLengthsWithSelectorCalculatesCorrectly()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length<double>>("1", Length<double>.FromMeters(1)),
                new KeyValuePair<string, Length<double>>("2", Length<double>.FromCentimeters(50))
            };

            var max = units.Max<KeyValuePair<string, Length<double>>, Length<double>, double>( x => x.Value, LengthUnit.Centimeter);

            Assert.Equal(100, max.Value);
            Assert.Equal(LengthUnit.Centimeter, max.Unit);
        }

        [Fact]
        public void MinOfDifferentUnitsThrowsException()
        {
            var units = new IQuantity[] {Length<double>.FromMeters(1), Volume<double>.FromLiters(50)};

            Assert.Throws<ArgumentException>(() => units.Min<IQuantity, double>(LengthUnit.Centimeter));
        }

        [Fact]
        public void MinOfEmptySourceThrowsException()
        {
            var units = new Length<double>[] { };

            Assert.Throws<InvalidOperationException>(() => units.Min<Length<double>, double>(LengthUnit.Centimeter));
        }

        [Fact]
        public void MinOfLengthsCalculatesCorrectly()
        {
            var units = new[] {Length<double>.FromMeters(1), Length<double>.FromCentimeters(50)};

            var min = units.Min<Length<double>, double>(LengthUnit.Centimeter);

            Assert.Equal(50, min.Value);
            Assert.Equal(LengthUnit.Centimeter, min.Unit);
        }

        [Fact]
        public void MinOfLengthsWithNullSelectorThrowsException()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length<double>>("1", Length<double>.FromMeters(1)),
                new KeyValuePair<string, Length<double>>("2", Length<double>.FromCentimeters(50))
            };

            Assert.Throws<ArgumentNullException>(() => units.Min<KeyValuePair<string, Length<double>>, Length<double>, double>( (Func<KeyValuePair<string, Length<double>>, Length<double>>) null, LengthUnit.Centimeter));
        }

        [Fact]
        public void MinOfLengthsWithSelectorCalculatesCorrectly()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length<double>>("1", Length<double>.FromMeters(1)),
                new KeyValuePair<string, Length<double>>("2", Length<double>.FromCentimeters(50))
            };

            var min = units.Min<KeyValuePair<string, Length<double>>, Length<double>, double>(x => x.Value, LengthUnit.Centimeter);

            Assert.Equal(50, min.Value);
            Assert.Equal(LengthUnit.Centimeter, min.Unit);
        }

        [Fact]
        public void SumOfDifferentUnitsThrowsException()
        {
            var units = new IQuantity[] {Length<double>.FromMeters(1), Volume<double>.FromLiters(50)};

            Assert.Throws<ArgumentException>(() => units.Sum<IQuantity, double>(LengthUnit.Centimeter));
        }

        [Fact]
        public void SumOfEmptySourceReturnsZero()
        {
            var units = new Length<double>[] { };

            var sum = units.Sum<Length<double>, double>(Length<double>.BaseUnit);

            Assert.Equal(Length<double>.Zero, sum);
        }

        [Fact]
        public void SumOfLengthsCalculatesCorrectly()
        {
            var units = new[] {Length<double>.FromMeters(1), Length<double>.FromCentimeters(50)};

            var sum = units.Sum<Length<double>, double>(LengthUnit.Centimeter);

            Assert.Equal(150, sum.Value);
            Assert.Equal(LengthUnit.Centimeter, sum.Unit);
        }

        [Fact]
        public void SumOfLengthsWithNullSelectorThrowsException()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length<double>>("1", Length<double>.FromMeters(1)),
                new KeyValuePair<string, Length<double>>("2", Length<double>.FromCentimeters(50))
            };

            Assert.Throws<ArgumentNullException>(() => units.Sum<KeyValuePair<string, Length<double>>, Length<double>, double>( (Func<KeyValuePair<string, Length<double>>, Length<double>>) null, LengthUnit.Centimeter));
        }

        [Fact]
        public void SumOfLengthsWithSelectorCalculatesCorrectly()
        {
            var units = new[]
            {
                new KeyValuePair<string, Length<double>>("1", Length<double>.FromMeters(1)),
                new KeyValuePair<string, Length<double>>("2", Length<double>.FromCentimeters(50))
            };

            var sum = units.Sum<KeyValuePair<string, Length<double>>, Length<double>, double>( x => x.Value, LengthUnit.Centimeter);

            Assert.Equal(150, sum.Value);
            Assert.Equal(LengthUnit.Centimeter, sum.Unit);
        }
    }
}
