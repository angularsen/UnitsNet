// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using NUnit.Framework;
using UnitsNet.Units;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of BrakeSpecificFuelConsumption.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class BrakeSpecificFuelConsumptionTestsBase
    {
        protected abstract double GramsPerKiloWattHourInOneKilogramPerJoule { get; }
        protected abstract double KilogramsPerJouleInOneKilogramPerJoule { get; }
        protected abstract double PoundsPerMechanicalHorsepowerHourInOneKilogramPerJoule { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double GramsPerKiloWattHourTolerance { get { return 1e-5; } }
        protected virtual double KilogramsPerJouleTolerance { get { return 1e-5; } }
        protected virtual double PoundsPerMechanicalHorsepowerHourTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void KilogramPerJouleToBrakeSpecificFuelConsumptionUnits()
        {
            BrakeSpecificFuelConsumption kilogramperjoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            Assert.AreEqual(GramsPerKiloWattHourInOneKilogramPerJoule, kilogramperjoule.GramsPerKiloWattHour, GramsPerKiloWattHourTolerance);
            Assert.AreEqual(KilogramsPerJouleInOneKilogramPerJoule, kilogramperjoule.KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(PoundsPerMechanicalHorsepowerHourInOneKilogramPerJoule, kilogramperjoule.PoundsPerMechanicalHorsepowerHour, PoundsPerMechanicalHorsepowerHourTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, BrakeSpecificFuelConsumption.From(1, BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour).GramsPerKiloWattHour, GramsPerKiloWattHourTolerance);
            Assert.AreEqual(1, BrakeSpecificFuelConsumption.From(1, BrakeSpecificFuelConsumptionUnit.KilogramPerJoule).KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(1, BrakeSpecificFuelConsumption.From(1, BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour).PoundsPerMechanicalHorsepowerHour, PoundsPerMechanicalHorsepowerHourTolerance);
        }

        [Test]
        public void As()
        {
            var kilogramperjoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            Assert.AreEqual(GramsPerKiloWattHourInOneKilogramPerJoule, kilogramperjoule.As(BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour), GramsPerKiloWattHourTolerance);
            Assert.AreEqual(KilogramsPerJouleInOneKilogramPerJoule, kilogramperjoule.As(BrakeSpecificFuelConsumptionUnit.KilogramPerJoule), KilogramsPerJouleTolerance);
            Assert.AreEqual(PoundsPerMechanicalHorsepowerHourInOneKilogramPerJoule, kilogramperjoule.As(BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour), PoundsPerMechanicalHorsepowerHourTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            BrakeSpecificFuelConsumption kilogramperjoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            Assert.AreEqual(1, BrakeSpecificFuelConsumption.FromGramsPerKiloWattHour(kilogramperjoule.GramsPerKiloWattHour).KilogramsPerJoule, GramsPerKiloWattHourTolerance);
            Assert.AreEqual(1, BrakeSpecificFuelConsumption.FromKilogramsPerJoule(kilogramperjoule.KilogramsPerJoule).KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(1, BrakeSpecificFuelConsumption.FromPoundsPerMechanicalHorsepowerHour(kilogramperjoule.PoundsPerMechanicalHorsepowerHour).KilogramsPerJoule, PoundsPerMechanicalHorsepowerHourTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            BrakeSpecificFuelConsumption v = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            Assert.AreEqual(-1, -v.KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(2, (BrakeSpecificFuelConsumption.FromKilogramsPerJoule(3)-v).KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(2, (v + v).KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(10, (v*10).KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(10, (10*v).KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(2, (BrakeSpecificFuelConsumption.FromKilogramsPerJoule(10)/5).KilogramsPerJoule, KilogramsPerJouleTolerance);
            Assert.AreEqual(2, BrakeSpecificFuelConsumption.FromKilogramsPerJoule(10)/BrakeSpecificFuelConsumption.FromKilogramsPerJoule(5), KilogramsPerJouleTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            BrakeSpecificFuelConsumption oneKilogramPerJoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            BrakeSpecificFuelConsumption twoKilogramsPerJoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(2);

            Assert.True(oneKilogramPerJoule < twoKilogramsPerJoule);
            Assert.True(oneKilogramPerJoule <= twoKilogramsPerJoule);
            Assert.True(twoKilogramsPerJoule > oneKilogramPerJoule);
            Assert.True(twoKilogramsPerJoule >= oneKilogramPerJoule);

            Assert.False(oneKilogramPerJoule > twoKilogramsPerJoule);
            Assert.False(oneKilogramPerJoule >= twoKilogramsPerJoule);
            Assert.False(twoKilogramsPerJoule < oneKilogramPerJoule);
            Assert.False(twoKilogramsPerJoule <= oneKilogramPerJoule);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            BrakeSpecificFuelConsumption kilogramperjoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            Assert.AreEqual(0, kilogramperjoule.CompareTo(kilogramperjoule));
            Assert.Greater(kilogramperjoule.CompareTo(BrakeSpecificFuelConsumption.Zero), 0);
            Assert.Less(BrakeSpecificFuelConsumption.Zero.CompareTo(kilogramperjoule), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            BrakeSpecificFuelConsumption kilogramperjoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogramperjoule.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            BrakeSpecificFuelConsumption kilogramperjoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogramperjoule.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            BrakeSpecificFuelConsumption a = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            BrakeSpecificFuelConsumption b = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(2);

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
            BrakeSpecificFuelConsumption v = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            Assert.IsTrue(v.Equals(BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1)));
            Assert.IsFalse(v.Equals(BrakeSpecificFuelConsumption.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            BrakeSpecificFuelConsumption kilogramperjoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            Assert.IsFalse(kilogramperjoule.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            BrakeSpecificFuelConsumption kilogramperjoule = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(1);
            Assert.IsFalse(kilogramperjoule.Equals(null));
        }
    }
}
