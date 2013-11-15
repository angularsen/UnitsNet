// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class VolumeTests
    {
        private const double Delta = 1E-5;
        private readonly Volume _cubicMeter = Volume.FromCubicMeters(1);

        [Test]
        public void CubicMetersToVolumeUnits()
        {
            Assert.AreEqual(1E-9, _cubicMeter.CubicKilometers, Delta);
            Assert.AreEqual(1, _cubicMeter.CubicMeters, Delta);
            Assert.AreEqual(1E3, _cubicMeter.CubicDecimeters, Delta);
            Assert.AreEqual(1E6, _cubicMeter.CubicCentimeters, Delta);
            Assert.AreEqual(1E9, _cubicMeter.CubicMillimeters, Delta);

            Assert.AreEqual(1E1, _cubicMeter.Hectoliters, Delta);
            Assert.AreEqual(1E3, _cubicMeter.Liters, Delta);
            Assert.AreEqual(1E4, _cubicMeter.Deciliters, Delta);
            Assert.AreEqual(1E5, _cubicMeter.Centiliters, Delta);
            Assert.AreEqual(1E6, _cubicMeter.Milliliters, Delta);

            Assert.AreEqual(3.86102*1E-7, _cubicMeter.CubicMiles, Delta);
            Assert.AreEqual(1.30795062, _cubicMeter.CubicYards, Delta);
            Assert.AreEqual(35.31472, _cubicMeter.CubicFeet, Delta);
            Assert.AreEqual(61023.98242, _cubicMeter.CubicInches, Delta);
            
            Assert.AreEqual(264.17217, _cubicMeter.UsGallons, Delta);
            Assert.AreEqual(33814.02270, _cubicMeter.UsOunces, Delta);
            Assert.AreEqual(219.96924, _cubicMeter.ImperialGallons, Delta);
            Assert.AreEqual(35195.07972, _cubicMeter.ImperialOunces, Delta);
        }

        [Test]
        public void VolumeUnitsRoundTrip()
        {
            Assert.AreEqual(1, Volume.FromCubicKilometers(_cubicMeter.CubicKilometers).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicMeters(_cubicMeter.CubicMeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicDecimeters(_cubicMeter.CubicDecimeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicCentimeters(_cubicMeter.CubicCentimeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicMillimeters(_cubicMeter.CubicMillimeters).CubicMeters, Delta);

            Assert.AreEqual(1, Volume.FromHectoliters(_cubicMeter.Hectoliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromLiters(_cubicMeter.Liters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromDeciliters(_cubicMeter.Deciliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCentiliters(_cubicMeter.Centiliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromMilliliters(_cubicMeter.Milliliters).CubicMeters, Delta);

            Assert.AreEqual(1, Volume.FromCubicMiles(_cubicMeter.CubicMiles).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicYards(_cubicMeter.CubicYards).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicFeet(_cubicMeter.CubicFeet).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicMiles(_cubicMeter.CubicMiles).CubicMeters, Delta);

            Assert.AreEqual(1, Volume.FromUsGallons(_cubicMeter.UsGallons).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromUsOunces(_cubicMeter.UsOunces).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromImperialGallons(_cubicMeter.ImperialGallons).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromImperialOunces(_cubicMeter.ImperialOunces).CubicMeters, Delta);
        }

        [Test]
        public void ArithmeticOperatorsRoundtrip()
        {
            Volume v = Volume.FromLiters(1);
            Assert.AreEqual(-1, -v.Liters, Delta);
            Assert.AreEqual(2, (Volume.FromLiters(3)-v).Liters, Delta);
            Assert.AreEqual(2, (v + v).Liters, Delta);
            Assert.AreEqual(10, (v*10).Liters, Delta);
            Assert.AreEqual(10, (10*v).Liters, Delta);
            Assert.AreEqual(2, (Volume.FromLiters(10)/5).Liters, Delta);
            Assert.AreEqual(2, Volume.FromLiters(10)/Volume.FromLiters(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Volume oneCubicMeter = Volume.FromCubicMeters(1);
            Volume twoCubicMeters = Volume.FromCubicMeters(2);

            Assert.True(oneCubicMeter < twoCubicMeters);
            Assert.True(oneCubicMeter <= twoCubicMeters);
            Assert.True(twoCubicMeters > oneCubicMeter);
            Assert.True(twoCubicMeters >= oneCubicMeter);

            Assert.False(oneCubicMeter > twoCubicMeters);
            Assert.False(oneCubicMeter >= twoCubicMeters);
            Assert.False(twoCubicMeters < oneCubicMeter);
            Assert.False(twoCubicMeters <= oneCubicMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Volume meter = Volume.FromCubicMeters(1);
            Assert.AreEqual(0, meter.CompareTo(meter));
            Assert.Greater(meter.CompareTo(Volume.Zero), 0);
            Assert.Less(Volume.Zero.CompareTo(meter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Volume meter = Volume.FromCubicMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Volume meter = Volume.FromCubicMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Volume a = Volume.FromCubicMeters(1);
            Volume b = Volume.FromCubicMeters(2);

// ReSharper disable EqualExpressionComparison
            Assert.True(a == a); 
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
// ReSharper restore EqualExpressionComparison
        }

        [Test]
        public void EqualsIsImplemented()
        {
            Volume v = Volume.FromCubicMeters(1);
            Assert.IsTrue(v.Equals(Volume.FromCubicMeters(1)));
            Assert.IsFalse(v.Equals(Volume.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Volume meter = Volume.FromCubicMeters(1);
            Assert.IsFalse(meter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Volume meter = Volume.FromCubicMeters(1);
            Assert.IsFalse(meter.Equals(null));
        }
    }
}