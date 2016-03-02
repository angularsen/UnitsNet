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
    /// Test of Power.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PowerTestsBase
    {
        protected abstract double BoilerHorsepowerInOneWatt { get; }
        protected abstract double ElectricalHorsepowerInOneWatt { get; }
        protected abstract double FemtowattsInOneWatt { get; }
        protected abstract double GigawattsInOneWatt { get; }
        protected abstract double HydraulicHorsepowerInOneWatt { get; }
        protected abstract double KilowattsInOneWatt { get; }
        protected abstract double MechanicalHorsepowerInOneWatt { get; }
        protected abstract double MegawattsInOneWatt { get; }
        protected abstract double MetricHorsepowerInOneWatt { get; }
        protected abstract double MicrowattsInOneWatt { get; }
        protected abstract double MilliwattsInOneWatt { get; }
        protected abstract double NanowattsInOneWatt { get; }
        protected abstract double PetawattsInOneWatt { get; }
        protected abstract double PicowattsInOneWatt { get; }
        protected abstract double TerawattsInOneWatt { get; }
        protected abstract double WattsInOneWatt { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double BoilerHorsepowerTolerance { get { return 1e-5; } }
        protected virtual double ElectricalHorsepowerTolerance { get { return 1e-5; } }
        protected virtual double FemtowattsTolerance { get { return 1e-5; } }
        protected virtual double GigawattsTolerance { get { return 1e-5; } }
        protected virtual double HydraulicHorsepowerTolerance { get { return 1e-5; } }
        protected virtual double KilowattsTolerance { get { return 1e-5; } }
        protected virtual double MechanicalHorsepowerTolerance { get { return 1e-5; } }
        protected virtual double MegawattsTolerance { get { return 1e-5; } }
        protected virtual double MetricHorsepowerTolerance { get { return 1e-5; } }
        protected virtual double MicrowattsTolerance { get { return 1e-5; } }
        protected virtual double MilliwattsTolerance { get { return 1e-5; } }
        protected virtual double NanowattsTolerance { get { return 1e-5; } }
        protected virtual double PetawattsTolerance { get { return 1e-5; } }
        protected virtual double PicowattsTolerance { get { return 1e-5; } }
        protected virtual double TerawattsTolerance { get { return 1e-5; } }
        protected virtual double WattsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void WattToPowerUnits()
        {
            Power watt = Power.FromWatts(1);
            Assert.AreEqual(BoilerHorsepowerInOneWatt, watt.BoilerHorsepower, BoilerHorsepowerTolerance);
            Assert.AreEqual(ElectricalHorsepowerInOneWatt, watt.ElectricalHorsepower, ElectricalHorsepowerTolerance);
            Assert.AreEqual(FemtowattsInOneWatt, watt.Femtowatts, FemtowattsTolerance);
            Assert.AreEqual(GigawattsInOneWatt, watt.Gigawatts, GigawattsTolerance);
            Assert.AreEqual(HydraulicHorsepowerInOneWatt, watt.HydraulicHorsepower, HydraulicHorsepowerTolerance);
            Assert.AreEqual(KilowattsInOneWatt, watt.Kilowatts, KilowattsTolerance);
            Assert.AreEqual(MechanicalHorsepowerInOneWatt, watt.MechanicalHorsepower, MechanicalHorsepowerTolerance);
            Assert.AreEqual(MegawattsInOneWatt, watt.Megawatts, MegawattsTolerance);
            Assert.AreEqual(MetricHorsepowerInOneWatt, watt.MetricHorsepower, MetricHorsepowerTolerance);
            Assert.AreEqual(MicrowattsInOneWatt, watt.Microwatts, MicrowattsTolerance);
            Assert.AreEqual(MilliwattsInOneWatt, watt.Milliwatts, MilliwattsTolerance);
            Assert.AreEqual(NanowattsInOneWatt, watt.Nanowatts, NanowattsTolerance);
            Assert.AreEqual(PetawattsInOneWatt, watt.Petawatts, PetawattsTolerance);
            Assert.AreEqual(PicowattsInOneWatt, watt.Picowatts, PicowattsTolerance);
            Assert.AreEqual(TerawattsInOneWatt, watt.Terawatts, TerawattsTolerance);
            Assert.AreEqual(WattsInOneWatt, watt.Watts, WattsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Power.From(1, PowerUnit.BoilerHorsepower).BoilerHorsepower, BoilerHorsepowerTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.ElectricalHorsepower).ElectricalHorsepower, ElectricalHorsepowerTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Femtowatt).Femtowatts, FemtowattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Gigawatt).Gigawatts, GigawattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.HydraulicHorsepower).HydraulicHorsepower, HydraulicHorsepowerTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Kilowatt).Kilowatts, KilowattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.MechanicalHorsepower).MechanicalHorsepower, MechanicalHorsepowerTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Megawatt).Megawatts, MegawattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.MetricHorsepower).MetricHorsepower, MetricHorsepowerTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Microwatt).Microwatts, MicrowattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Milliwatt).Milliwatts, MilliwattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Nanowatt).Nanowatts, NanowattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Petawatt).Petawatts, PetawattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Picowatt).Picowatts, PicowattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Terawatt).Terawatts, TerawattsTolerance);
            Assert.AreEqual(1, Power.From(1, PowerUnit.Watt).Watts, WattsTolerance);
        }

        [Test]
        public void As()
        {
            var watt = Power.FromWatts(1);
            Assert.AreEqual(BoilerHorsepowerInOneWatt, watt.As(PowerUnit.BoilerHorsepower), BoilerHorsepowerTolerance);
            Assert.AreEqual(ElectricalHorsepowerInOneWatt, watt.As(PowerUnit.ElectricalHorsepower), ElectricalHorsepowerTolerance);
            Assert.AreEqual(FemtowattsInOneWatt, watt.As(PowerUnit.Femtowatt), FemtowattsTolerance);
            Assert.AreEqual(GigawattsInOneWatt, watt.As(PowerUnit.Gigawatt), GigawattsTolerance);
            Assert.AreEqual(HydraulicHorsepowerInOneWatt, watt.As(PowerUnit.HydraulicHorsepower), HydraulicHorsepowerTolerance);
            Assert.AreEqual(KilowattsInOneWatt, watt.As(PowerUnit.Kilowatt), KilowattsTolerance);
            Assert.AreEqual(MechanicalHorsepowerInOneWatt, watt.As(PowerUnit.MechanicalHorsepower), MechanicalHorsepowerTolerance);
            Assert.AreEqual(MegawattsInOneWatt, watt.As(PowerUnit.Megawatt), MegawattsTolerance);
            Assert.AreEqual(MetricHorsepowerInOneWatt, watt.As(PowerUnit.MetricHorsepower), MetricHorsepowerTolerance);
            Assert.AreEqual(MicrowattsInOneWatt, watt.As(PowerUnit.Microwatt), MicrowattsTolerance);
            Assert.AreEqual(MilliwattsInOneWatt, watt.As(PowerUnit.Milliwatt), MilliwattsTolerance);
            Assert.AreEqual(NanowattsInOneWatt, watt.As(PowerUnit.Nanowatt), NanowattsTolerance);
            Assert.AreEqual(PetawattsInOneWatt, watt.As(PowerUnit.Petawatt), PetawattsTolerance);
            Assert.AreEqual(PicowattsInOneWatt, watt.As(PowerUnit.Picowatt), PicowattsTolerance);
            Assert.AreEqual(TerawattsInOneWatt, watt.As(PowerUnit.Terawatt), TerawattsTolerance);
            Assert.AreEqual(WattsInOneWatt, watt.As(PowerUnit.Watt), WattsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Power watt = Power.FromWatts(1);
            Assert.AreEqual(1, Power.FromBoilerHorsepower(watt.BoilerHorsepower).Watts, BoilerHorsepowerTolerance);
            Assert.AreEqual(1, Power.FromElectricalHorsepower(watt.ElectricalHorsepower).Watts, ElectricalHorsepowerTolerance);
            Assert.AreEqual(1, Power.FromFemtowatts(watt.Femtowatts).Watts, FemtowattsTolerance);
            Assert.AreEqual(1, Power.FromGigawatts(watt.Gigawatts).Watts, GigawattsTolerance);
            Assert.AreEqual(1, Power.FromHydraulicHorsepower(watt.HydraulicHorsepower).Watts, HydraulicHorsepowerTolerance);
            Assert.AreEqual(1, Power.FromKilowatts(watt.Kilowatts).Watts, KilowattsTolerance);
            Assert.AreEqual(1, Power.FromMechanicalHorsepower(watt.MechanicalHorsepower).Watts, MechanicalHorsepowerTolerance);
            Assert.AreEqual(1, Power.FromMegawatts(watt.Megawatts).Watts, MegawattsTolerance);
            Assert.AreEqual(1, Power.FromMetricHorsepower(watt.MetricHorsepower).Watts, MetricHorsepowerTolerance);
            Assert.AreEqual(1, Power.FromMicrowatts(watt.Microwatts).Watts, MicrowattsTolerance);
            Assert.AreEqual(1, Power.FromMilliwatts(watt.Milliwatts).Watts, MilliwattsTolerance);
            Assert.AreEqual(1, Power.FromNanowatts(watt.Nanowatts).Watts, NanowattsTolerance);
            Assert.AreEqual(1, Power.FromPetawatts(watt.Petawatts).Watts, PetawattsTolerance);
            Assert.AreEqual(1, Power.FromPicowatts(watt.Picowatts).Watts, PicowattsTolerance);
            Assert.AreEqual(1, Power.FromTerawatts(watt.Terawatts).Watts, TerawattsTolerance);
            Assert.AreEqual(1, Power.FromWatts(watt.Watts).Watts, WattsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Power v = Power.FromWatts(1);
            Assert.AreEqual(-1, -v.Watts, WattsTolerance);
            Assert.AreEqual(2, (Power.FromWatts(3)-v).Watts, WattsTolerance);
            Assert.AreEqual(2, (v + v).Watts, WattsTolerance);
            Assert.AreEqual(10, (v*10).Watts, WattsTolerance);
            Assert.AreEqual(10, (10*v).Watts, WattsTolerance);
            Assert.AreEqual(2, (Power.FromWatts(10)/5).Watts, WattsTolerance);
            Assert.AreEqual(2, Power.FromWatts(10)/Power.FromWatts(5), WattsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Power oneWatt = Power.FromWatts(1);
            Power twoWatts = Power.FromWatts(2);

            Assert.True(oneWatt < twoWatts);
            Assert.True(oneWatt <= twoWatts);
            Assert.True(twoWatts > oneWatt);
            Assert.True(twoWatts >= oneWatt);

            Assert.False(oneWatt > twoWatts);
            Assert.False(oneWatt >= twoWatts);
            Assert.False(twoWatts < oneWatt);
            Assert.False(twoWatts <= oneWatt);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Power watt = Power.FromWatts(1);
            Assert.AreEqual(0, watt.CompareTo(watt));
            Assert.Greater(watt.CompareTo(Power.Zero), 0);
            Assert.Less(Power.Zero.CompareTo(watt), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Power watt = Power.FromWatts(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            watt.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Power watt = Power.FromWatts(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            watt.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Power a = Power.FromWatts(1);
            Power b = Power.FromWatts(2);

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
            Power v = Power.FromWatts(1);
            Assert.IsTrue(v.Equals(Power.FromWatts(1)));
            Assert.IsFalse(v.Equals(Power.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Power watt = Power.FromWatts(1);
            Assert.IsFalse(watt.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Power watt = Power.FromWatts(1);
            Assert.IsFalse(watt.Equals(null));
        }
    }
}
