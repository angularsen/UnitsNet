// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class PressureTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void PascalToPressureUnits()
        { 
            Pressure pa = Pressure.FromPascals(1);

            // Source: http://en.wikipedia.org/wiki/Pressure
            Assert.AreEqual(9.8692*1E-6, pa.Atmospheres, Delta);
            Assert.AreEqual(1E-5, pa.Bars, Delta);
            Assert.AreEqual(1E-3, pa.Kilopascals);
            Assert.AreEqual(1E-6, pa.Megapascals);
            Assert.AreEqual(1/98066.5, pa.KilogramForcePerSquareCentimeter);
            Assert.AreEqual(1E-4, pa.NewtonsPerSquareCentimeter, Delta);
            Assert.AreEqual(1E-6, pa.NewtonsPerSquareMillimeter, Delta);
            Assert.AreEqual(1, pa.NewtonsPerSquareMeter, Delta);
            Assert.AreEqual(1, pa.Pascals);
            Assert.AreEqual(1.450377*1E-4, pa.Psi, Delta);
            Assert.AreEqual(1.0197*1E-5, pa.TechnicalAtmospheres, Delta);
            Assert.AreEqual(7.5006*1E-3, pa.Torrs, Delta);
        }

        [Test]
        public void PressureUnitsRoundTrip()
        {
            Pressure pa = Pressure.FromPascals(1);

            Assert.AreEqual(1, Pressure.FromAtmospheres(pa.Atmospheres).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromBars(pa.Bars).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromKilopascals(pa.Kilopascals).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromMegapascals(pa.Megapascals).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromKilogramForcePerSquareCentimeter(pa.KilogramForcePerSquareCentimeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareCentimeter(pa.NewtonsPerSquareCentimeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMeter(pa.NewtonsPerSquareMeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMillimeter(pa.NewtonsPerSquareMillimeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromPascals(pa.Pascals).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromPsi(pa.Psi).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromTechnicalAtmospheres(pa.TechnicalAtmospheres).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromTorrs(pa.Torrs).Pascals, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Pressure v = Pressure.FromPascals(1);
            Assert.AreEqual(-1, -v.Pascals, Delta);
            Assert.AreEqual(2, (Pressure.FromPascals(3)-v).Pascals, Delta);
            Assert.AreEqual(2, (v + v).Pascals, Delta);
            Assert.AreEqual(10, (v*10).Pascals, Delta);
            Assert.AreEqual(10, (10*v).Pascals, Delta);
            Assert.AreEqual(2, (Pressure.FromPascals(10)/5).Pascals, Delta);
            Assert.AreEqual(2, Pressure.FromPascals(10)/Pressure.FromPascals(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Pressure oneMeter = Pressure.FromPascals(1);
            Pressure twoMeters = Pressure.FromPascals(2);

            Assert.True(oneMeter < twoMeters);
            Assert.True(oneMeter <= twoMeters);
            Assert.True(twoMeters > oneMeter);
            Assert.True(twoMeters >= oneMeter);

            Assert.False(oneMeter > twoMeters);
            Assert.False(oneMeter >= twoMeters);
            Assert.False(twoMeters < oneMeter);
            Assert.False(twoMeters <= oneMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Pressure meter = Pressure.FromPascals(1);
            Assert.AreEqual(0, meter.CompareTo(meter));
            Assert.Greater(meter.CompareTo(Pressure.Zero), 0);
            Assert.Less(Pressure.Zero.CompareTo(meter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Pressure meter = Pressure.FromPascals(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Pressure meter = Pressure.FromPascals(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Pressure a = Pressure.FromPascals(1);
            Pressure b = Pressure.FromPascals(2);

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
            Pressure v = Pressure.FromPascals(1);
            Assert.IsTrue(v.Equals(Pressure.FromPascals(1)));
            Assert.IsFalse(v.Equals(Pressure.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Pressure meter = Pressure.FromPascals(1);
            Assert.IsFalse(meter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Pressure meter = Pressure.FromPascals(1);
            Assert.IsFalse(meter.Equals(null));
        }
    }
}