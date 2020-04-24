using System;
using System.Collections.Generic;
using Xunit;

namespace UnitsNet.Tests
{
    public class BaseDimensionsTests
    {
        [Fact]
        public void ConstructorImplementedCorrectly()
        {
            var baseDimensions = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);

            Assert.True(baseDimensions.Length == 1);
            Assert.True(baseDimensions.Mass == 2);
            Assert.True(baseDimensions.Time == 3);
            Assert.True(baseDimensions.Current == 4);
            Assert.True(baseDimensions.Temperature == 5);
            Assert.True(baseDimensions.Amount == 6);
            Assert.True(baseDimensions.LuminousIntensity == 7);
        }

        [Theory]
        [InlineData(1, 0, 0, 0, 0, 0, 0)]
        [InlineData(0, 1, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 1, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 1, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, 1, 0, 0)]
        [InlineData(0, 0, 0, 0, 0, 1, 0)]
        [InlineData(0, 0, 0, 0, 0, 0, 1)]
        public void IsBaseQuantityImplementedProperly(int length, int mass, int time, int current, int temperature, int amount, int luminousIntensity)
        {
            var baseDimensions = new BaseDimensions(length, mass, time, current, temperature, amount, luminousIntensity);
            var derivedDimensions = new BaseDimensions(length * 2, mass * 2, time * 2, current * 2, temperature * 2, amount * 2, luminousIntensity * 2);

            Assert.True(baseDimensions.IsBaseQuantity());
            Assert.False(derivedDimensions.IsBaseQuantity());
        }

        [Theory]
        [InlineData(2, 0, 0, 0, 0, 0, 0)]
        [InlineData(0, 2, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 2, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 2, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, 2, 0, 0)]
        [InlineData(0, 0, 0, 0, 0, 2, 0)]
        [InlineData(0, 0, 0, 0, 0, 0, 2)]
        public void IsDerivedQuantityImplementedProperly(int length, int mass, int time, int current, int temperature, int amount, int luminousIntensity)
        {
            var baseDimensions = new BaseDimensions(length / 2, mass / 2, time / 2, current / 2, temperature / 2, amount / 2, luminousIntensity / 2);
            var derivedDimensions = new BaseDimensions(length, mass, time, current, temperature, amount, luminousIntensity);

            Assert.False(baseDimensions.IsDerivedQuantity());
            Assert.True(derivedDimensions.IsDerivedQuantity());
        }

        [Fact]
        public void EqualsWorksAsExpected()
        {
            var baseDimensions1 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);
            var baseDimensions2 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);

            Assert.True(baseDimensions1.Equals(baseDimensions2));
            Assert.True(baseDimensions2.Equals(baseDimensions1));

            Assert.False(baseDimensions1.Equals(null));
        }

        [Fact]
        public void EqualityOperatorsWorkAsExpected()
        {
            var baseDimensions1 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);
            var baseDimensions2 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);

            Assert.True(baseDimensions1 == baseDimensions2);
            Assert.True(baseDimensions2 == baseDimensions1);

            Assert.False(baseDimensions1 == null);
            Assert.False(null == baseDimensions1);

            Assert.False(baseDimensions2 == null);
            Assert.False(null == baseDimensions2);

            BaseDimensions nullBaseDimensions1 = null;
            BaseDimensions nullBaseDimensions2 = null;

            Assert.True(nullBaseDimensions1 == nullBaseDimensions2);
        }

        [Fact]
        public void InequalityOperatorsWorkAsExpected()
        {
            var baseDimensions1 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);
            var baseDimensions2 = new BaseDimensions(7, 6, 5, 4, 3, 2, 1);

            Assert.True(baseDimensions1 != baseDimensions2);
            Assert.True(baseDimensions2 != baseDimensions1);

            Assert.True(baseDimensions1 != null);
            Assert.True(null != baseDimensions1);

            Assert.True(baseDimensions2 != null);
            Assert.True(null != baseDimensions2);

            BaseDimensions nullBaseDimensions1 = null;
            BaseDimensions nullBaseDimensions2 = null;

            Assert.False(nullBaseDimensions1 != nullBaseDimensions2);
        }

        [Fact]
        public void MultiplyThrowsExceptionIfPassedNull()
        {
            var baseDimensions1 = new BaseDimensions(1, 0, 0, 0, 0, 0, 0);
            Assert.Throws<ArgumentNullException>(() => baseDimensions1.Multiply(null));
        }

        [Fact]
        public void DivideThrowsExceptionIfPassedNull()
        {
            var baseDimensions1 = new BaseDimensions(1, 0, 0, 0, 0, 0, 0);
            Assert.Throws<ArgumentNullException>(() => baseDimensions1.Divide(null));
        }

        [Fact]
        public void MultiplyOperatorThrowsExceptionWithNull()
        {
            var baseDimensions1 = new BaseDimensions(1, 0, 0, 0, 0, 0, 0);
            Assert.Throws<ArgumentNullException>(() => baseDimensions1 / null);
            Assert.Throws<ArgumentNullException>(() => null / baseDimensions1);
        }

        [Fact]
        public void DivideOperatorThrowsExceptionWithNull()
        {
            var baseDimensions1 = new BaseDimensions(1, 0, 0, 0, 0, 0, 0);
            Assert.Throws<ArgumentNullException>(() => baseDimensions1 * null);
            Assert.Throws<ArgumentNullException>(() => null * baseDimensions1);
        }

        [Fact]
        public void LengthDimensionsMultiplyCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(1, 0, 0, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(2, 0, 0, 0, 0, 0, 0);

            var result = baseDimensions1.Multiply(baseDimensions2);

            Assert.True(result.Length == 3);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void MassDimensionsMultiplyCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 2, 0, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 3, 0, 0, 0, 0, 0);

            var result = baseDimensions1.Multiply(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 5);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void TimeDimensionsMultiplyCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 3, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 4, 0, 0, 0, 0);

            var result = baseDimensions1.Multiply(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 7);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void CurrentDimensionsMultiplyCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 4, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 5, 0, 0, 0);

            var result = baseDimensions1.Multiply(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 9);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void TemperatureDimensionsMultiplyCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 5, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 6, 0, 0);

            var result = baseDimensions1.Multiply(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 11);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void AmountDimensionsMultiplyCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 0, 6, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 0, 7, 0);

            var result = baseDimensions1.Multiply(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 13);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void LuminousIntensityDimensionsMultiplyCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 0, 0, 7);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 0, 0, 8);

            var result = baseDimensions1.Multiply(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 15);
        }

        [Fact]
        public void LengthDimensionsDivideCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(8, 0, 0, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(7, 0, 0, 0, 0, 0, 0);

            var result = baseDimensions1.Divide(baseDimensions2);

            Assert.True(result.Length == 1);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void MassDimensionsDivideCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 7, 0, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 6, 0, 0, 0, 0, 0);

            var result = baseDimensions1.Divide(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 1);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void TimeDimensionsDivideCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 6, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 5, 0, 0, 0, 0);

            var result = baseDimensions1.Divide(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 1);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void CurrentDimensionsDivideCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 5, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 4, 0, 0, 0);

            var result = baseDimensions1.Divide(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 1);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void TemperatureDimensionsDivideCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 4, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 3, 0, 0);

            var result = baseDimensions1.Divide(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 1);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void AmountDimensionsDivideCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 0, 3, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 0, 2, 0);

            var result = baseDimensions1.Divide(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 1);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void LuminousIntensityDimensionsDivideCorrectly()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 0, 0, 2);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 0, 0, 1);

            var result = baseDimensions1.Divide(baseDimensions2);

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 1);
        }

        [Fact]
        public void CheckBaseDimensionDivisionWithSpeedEqualsDistanceDividedByTimeOnStaticProperty()
        {
            var calculatedDimensions = Length.BaseDimensions.Divide(Duration.BaseDimensions);
            Assert.True(calculatedDimensions == Speed.BaseDimensions);
        }

        [Fact]
        public void CheckBaseDimensionDivisionWithSpeedEqualsDistanceDividedByTimeOnInstanceProperty()
        {
            var length = Length.FromKilometers(100);
            var duration = Duration.FromHours(1);

            var calculatedDimensions = length.Dimensions.Divide(duration.Dimensions);
            Assert.True(calculatedDimensions == Speed.BaseDimensions);
        }

        [Fact]
        public void CheckBaseDimensionMultiplicationWithForceEqualsMassTimesAccelerationOnStaticProperty()
        {
            var calculatedDimensions = Mass.BaseDimensions.Multiply(Acceleration.BaseDimensions);
            Assert.True(calculatedDimensions == Force.BaseDimensions);
        }

        [Fact]
        public void CheckBaseDimensionMultiplicationWithForceEqualsMassTimesAccelerationOnInstanceProperty()
        {
            var mass = Mass.FromPounds(205);
            var acceleration = Acceleration.FromMetersPerSecondSquared(9.8);

            var calculatedDimensions = mass.Dimensions.Multiply(acceleration.Dimensions);
            Assert.True(calculatedDimensions == Force.BaseDimensions);
        }

        [Fact]
        public void EqualityWorksAsExpectedWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);
            var baseDimensions2 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);

            Assert.True(baseDimensions1 == baseDimensions2);
            Assert.True(baseDimensions2 == baseDimensions1);
        }

        [Fact]
        public void LengthDimensionsMultiplyCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(1, 0, 0, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(2, 0, 0, 0, 0, 0, 0);

            var result = baseDimensions1 * baseDimensions2;

            Assert.True(result.Length == 3);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void MassDimensionsMultiplyCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 2, 0, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 3, 0, 0, 0, 0, 0);

            var result = baseDimensions1 * baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 5);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void TimeDimensionsMultiplyCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 3, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 4, 0, 0, 0, 0);

            var result = baseDimensions1 * baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 7);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void CurrentDimensionsMultiplyCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 4, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 5, 0, 0, 0);

            var result = baseDimensions1 * baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 9);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void TemperatureDimensionsMultiplyCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 5, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 6, 0, 0);

            var result = baseDimensions1 * baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 11);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void AmountDimensionsMultiplyCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 0, 6, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 0, 7, 0);

            var result = baseDimensions1 * baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 13);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void LuminousIntensityDimensionsMultiplyCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 0, 0, 7);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 0, 0, 8);

            var result = baseDimensions1 * baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 15);
        }

        [Fact]
        public void LengthDimensionsDivideCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(8, 0, 0, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(7, 0, 0, 0, 0, 0, 0);

            var result = baseDimensions1 / baseDimensions2;

            Assert.True(result.Length == 1);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void MassDimensionsDivideCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 7, 0, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 6, 0, 0, 0, 0, 0);

            var result = baseDimensions1 / baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 1);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void TimeDimensionsDivideCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 6, 0, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 5, 0, 0, 0, 0);

            var result = baseDimensions1 / baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 1);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void CurrentDimensionsDivideCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 5, 0, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 4, 0, 0, 0);

            var result = baseDimensions1 / baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 1);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void TemperatureDimensionsDivideCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 4, 0, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 3, 0, 0);

            var result = baseDimensions1 / baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 1);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void AmountDimensionsDivideCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 0, 3, 0);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 0, 2, 0);

            var result = baseDimensions1 / baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 1);
            Assert.True(result.LuminousIntensity == 0);
        }

        [Fact]
        public void LuminousIntensityDimensionsDivideCorrectlyWithOperatorOverloads()
        {
            var baseDimensions1 = new BaseDimensions(0, 0, 0, 0, 0, 0, 2);
            var baseDimensions2 = new BaseDimensions(0, 0, 0, 0, 0, 0, 1);

            var result = baseDimensions1 / baseDimensions2;

            Assert.True(result.Length == 0);
            Assert.True(result.Mass == 0);
            Assert.True(result.Time == 0);
            Assert.True(result.Current == 0);
            Assert.True(result.Temperature == 0);
            Assert.True(result.Amount == 0);
            Assert.True(result.LuminousIntensity == 1);
        }

        [Fact]
        public void CheckBaseDimensionDivisionWithSpeedEqualsDistanceDividedByTimeOnStaticPropertyWithOperatorOverloads()
        {
            var calculatedDimensions = Length.BaseDimensions / Duration.BaseDimensions;
            Assert.True(calculatedDimensions == Speed.BaseDimensions);
        }

        [Fact]
        public void CheckBaseDimensionDivisionWithSpeedEqualsDistanceDividedByTimeOnInstancePropertyWithOperatorOverloads()
        {
            var length = Length.FromKilometers(100);
            var duration = Duration.FromHours(1);

            var calculatedDimensions = length.Dimensions / duration.Dimensions;
            Assert.True(calculatedDimensions == Speed.BaseDimensions);
        }

        [Fact]
        public void CheckBaseDimensionMultiplicationWithForceEqualsMassTimesAccelerationOnStaticPropertyWithOperatorOverloads()
        {
            var calculatedDimensions = Mass.BaseDimensions * Acceleration.BaseDimensions;
            Assert.True(calculatedDimensions == Force.BaseDimensions);
        }

        [Fact]
        public void CheckBaseDimensionMultiplicationWithForceEqualsMassTimesAccelerationOnInstancePropertyWithOperatorOverloads()
        {
            var mass = Mass.FromPounds(205);
            var acceleration = Acceleration.FromMetersPerSecondSquared(9.8);

            var calculatedDimensions = mass.Dimensions * acceleration.Dimensions;
            Assert.True(calculatedDimensions == Force.BaseDimensions);
        }

        [Fact]
        public void CheckToStringUsingMolarEntropy()
        {
            Assert.Equal("[Length]^2[Mass][Time]^-2[Temperature][Amount]", MolarEntropy.BaseDimensions.ToString());
        }

        [Fact]
        public void GetHashCodeWorksProperly()
        {
            var baseDimensions1 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);
            var baseDimensions2 = new BaseDimensions(7, 6, 5, 4, 3, 2, 1);
            var baseDimensions3 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);

            var hashSet = new HashSet<BaseDimensions>();

            hashSet.Add(baseDimensions1);
            Assert.Contains(baseDimensions1, hashSet);

            hashSet.Add(baseDimensions2);
            Assert.Contains(baseDimensions2, hashSet);

            // Should be the same as baseDimensions1
            Assert.Contains(baseDimensions3, hashSet);

            Assert.True(baseDimensions1.GetHashCode() != baseDimensions2.GetHashCode());
            Assert.True(baseDimensions1.GetHashCode() == baseDimensions3.GetHashCode());
        }

        [Fact]
        public void DimensionlessPropertyIsCorrect()
        {
            Assert.True(BaseDimensions.Dimensionless == new BaseDimensions(0, 0, 0, 0, 0, 0, 0));
        }

        [Fact]
        public void IsDimensionlessMethodImplementedCorrectly()
        {
            Assert.True(BaseDimensions.Dimensionless.IsDimensionless());
            Assert.True(new BaseDimensions(0, 0, 0, 0, 0, 0, 0).IsDimensionless());

            Assert.False(BaseDimensions.Dimensionless.IsBaseQuantity());
            Assert.False(BaseDimensions.Dimensionless.IsDerivedQuantity());

            // Example case
            Assert.True(Level.BaseDimensions.IsDimensionless());
        }
    }
}
