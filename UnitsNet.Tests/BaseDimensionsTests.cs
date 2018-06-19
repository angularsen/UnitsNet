using System;
using Xunit;

namespace UnitsNet.Tests
{
    public class BaseDimensionsTests
    {
        [Fact]
        public void EqualityWorksAsExpected()
        {
            var baseDimensions1 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);
            var baseDimensions2 = new BaseDimensions(1, 2, 3, 4, 5, 6, 7);

            Assert.True(baseDimensions1.Equals(baseDimensions2));
            Assert.True(baseDimensions2.Equals(baseDimensions1));
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

#if !WINDOWS_UWP
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
#endif

        [Fact]
        public void CheckToStringUsingMolarEntropy()
        {
            Assert.Equal("[Length]^2[Mass][Time]^-2[Temperature][Amount]", MolarEntropy.BaseDimensions.ToString());
        }
    }
}
