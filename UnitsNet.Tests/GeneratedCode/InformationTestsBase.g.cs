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
    /// Test of Information.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class InformationTestsBase
    {
        protected abstract double BitsInOneBit { get; }
        protected abstract double BytesInOneBit { get; }
        protected abstract double ExabitsInOneBit { get; }
        protected abstract double ExabytesInOneBit { get; }
        protected abstract double ExbibitsInOneBit { get; }
        protected abstract double ExbibytesInOneBit { get; }
        protected abstract double GibibitsInOneBit { get; }
        protected abstract double GibibytesInOneBit { get; }
        protected abstract double GigabitsInOneBit { get; }
        protected abstract double GigabytesInOneBit { get; }
        protected abstract double KibibitsInOneBit { get; }
        protected abstract double KibibytesInOneBit { get; }
        protected abstract double KilobitsInOneBit { get; }
        protected abstract double KilobytesInOneBit { get; }
        protected abstract double MebibitsInOneBit { get; }
        protected abstract double MebibytesInOneBit { get; }
        protected abstract double MegabitsInOneBit { get; }
        protected abstract double MegabytesInOneBit { get; }
        protected abstract double PebibitsInOneBit { get; }
        protected abstract double PebibytesInOneBit { get; }
        protected abstract double PetabitsInOneBit { get; }
        protected abstract double PetabytesInOneBit { get; }
        protected abstract double TebibitsInOneBit { get; }
        protected abstract double TebibytesInOneBit { get; }
        protected abstract double TerabitsInOneBit { get; }
        protected abstract double TerabytesInOneBit { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double BitsTolerance { get { return 1e-5; } }
        protected virtual double BytesTolerance { get { return 1e-5; } }
        protected virtual double ExabitsTolerance { get { return 1e-5; } }
        protected virtual double ExabytesTolerance { get { return 1e-5; } }
        protected virtual double ExbibitsTolerance { get { return 1e-5; } }
        protected virtual double ExbibytesTolerance { get { return 1e-5; } }
        protected virtual double GibibitsTolerance { get { return 1e-5; } }
        protected virtual double GibibytesTolerance { get { return 1e-5; } }
        protected virtual double GigabitsTolerance { get { return 1e-5; } }
        protected virtual double GigabytesTolerance { get { return 1e-5; } }
        protected virtual double KibibitsTolerance { get { return 1e-5; } }
        protected virtual double KibibytesTolerance { get { return 1e-5; } }
        protected virtual double KilobitsTolerance { get { return 1e-5; } }
        protected virtual double KilobytesTolerance { get { return 1e-5; } }
        protected virtual double MebibitsTolerance { get { return 1e-5; } }
        protected virtual double MebibytesTolerance { get { return 1e-5; } }
        protected virtual double MegabitsTolerance { get { return 1e-5; } }
        protected virtual double MegabytesTolerance { get { return 1e-5; } }
        protected virtual double PebibitsTolerance { get { return 1e-5; } }
        protected virtual double PebibytesTolerance { get { return 1e-5; } }
        protected virtual double PetabitsTolerance { get { return 1e-5; } }
        protected virtual double PetabytesTolerance { get { return 1e-5; } }
        protected virtual double TebibitsTolerance { get { return 1e-5; } }
        protected virtual double TebibytesTolerance { get { return 1e-5; } }
        protected virtual double TerabitsTolerance { get { return 1e-5; } }
        protected virtual double TerabytesTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void BitToInformationUnits()
        {
            Information bit = Information.FromBits(1);
            Assert.AreEqual(BitsInOneBit, bit.Bits, BitsTolerance);
            Assert.AreEqual(BytesInOneBit, bit.Bytes, BytesTolerance);
            Assert.AreEqual(ExabitsInOneBit, bit.Exabits, ExabitsTolerance);
            Assert.AreEqual(ExabytesInOneBit, bit.Exabytes, ExabytesTolerance);
            Assert.AreEqual(ExbibitsInOneBit, bit.Exbibits, ExbibitsTolerance);
            Assert.AreEqual(ExbibytesInOneBit, bit.Exbibytes, ExbibytesTolerance);
            Assert.AreEqual(GibibitsInOneBit, bit.Gibibits, GibibitsTolerance);
            Assert.AreEqual(GibibytesInOneBit, bit.Gibibytes, GibibytesTolerance);
            Assert.AreEqual(GigabitsInOneBit, bit.Gigabits, GigabitsTolerance);
            Assert.AreEqual(GigabytesInOneBit, bit.Gigabytes, GigabytesTolerance);
            Assert.AreEqual(KibibitsInOneBit, bit.Kibibits, KibibitsTolerance);
            Assert.AreEqual(KibibytesInOneBit, bit.Kibibytes, KibibytesTolerance);
            Assert.AreEqual(KilobitsInOneBit, bit.Kilobits, KilobitsTolerance);
            Assert.AreEqual(KilobytesInOneBit, bit.Kilobytes, KilobytesTolerance);
            Assert.AreEqual(MebibitsInOneBit, bit.Mebibits, MebibitsTolerance);
            Assert.AreEqual(MebibytesInOneBit, bit.Mebibytes, MebibytesTolerance);
            Assert.AreEqual(MegabitsInOneBit, bit.Megabits, MegabitsTolerance);
            Assert.AreEqual(MegabytesInOneBit, bit.Megabytes, MegabytesTolerance);
            Assert.AreEqual(PebibitsInOneBit, bit.Pebibits, PebibitsTolerance);
            Assert.AreEqual(PebibytesInOneBit, bit.Pebibytes, PebibytesTolerance);
            Assert.AreEqual(PetabitsInOneBit, bit.Petabits, PetabitsTolerance);
            Assert.AreEqual(PetabytesInOneBit, bit.Petabytes, PetabytesTolerance);
            Assert.AreEqual(TebibitsInOneBit, bit.Tebibits, TebibitsTolerance);
            Assert.AreEqual(TebibytesInOneBit, bit.Tebibytes, TebibytesTolerance);
            Assert.AreEqual(TerabitsInOneBit, bit.Terabits, TerabitsTolerance);
            Assert.AreEqual(TerabytesInOneBit, bit.Terabytes, TerabytesTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Information.From(1, InformationUnit.Bit).Bits, BitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Byte).Bytes, BytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Exabit).Exabits, ExabitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Exabyte).Exabytes, ExabytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Exbibit).Exbibits, ExbibitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Exbibyte).Exbibytes, ExbibytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Gibibit).Gibibits, GibibitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Gibibyte).Gibibytes, GibibytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Gigabit).Gigabits, GigabitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Gigabyte).Gigabytes, GigabytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Kibibit).Kibibits, KibibitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Kibibyte).Kibibytes, KibibytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Kilobit).Kilobits, KilobitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Kilobyte).Kilobytes, KilobytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Mebibit).Mebibits, MebibitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Mebibyte).Mebibytes, MebibytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Megabit).Megabits, MegabitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Megabyte).Megabytes, MegabytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Pebibit).Pebibits, PebibitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Pebibyte).Pebibytes, PebibytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Petabit).Petabits, PetabitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Petabyte).Petabytes, PetabytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Tebibit).Tebibits, TebibitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Tebibyte).Tebibytes, TebibytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Terabit).Terabits, TerabitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Terabyte).Terabytes, TerabytesTolerance);
        }

        [Test]
        public void As()
        {
            var bit = Information.FromBits(1);
            Assert.AreEqual(BitsInOneBit, bit.As(InformationUnit.Bit), BitsTolerance);
            Assert.AreEqual(BytesInOneBit, bit.As(InformationUnit.Byte), BytesTolerance);
            Assert.AreEqual(ExabitsInOneBit, bit.As(InformationUnit.Exabit), ExabitsTolerance);
            Assert.AreEqual(ExabytesInOneBit, bit.As(InformationUnit.Exabyte), ExabytesTolerance);
            Assert.AreEqual(ExbibitsInOneBit, bit.As(InformationUnit.Exbibit), ExbibitsTolerance);
            Assert.AreEqual(ExbibytesInOneBit, bit.As(InformationUnit.Exbibyte), ExbibytesTolerance);
            Assert.AreEqual(GibibitsInOneBit, bit.As(InformationUnit.Gibibit), GibibitsTolerance);
            Assert.AreEqual(GibibytesInOneBit, bit.As(InformationUnit.Gibibyte), GibibytesTolerance);
            Assert.AreEqual(GigabitsInOneBit, bit.As(InformationUnit.Gigabit), GigabitsTolerance);
            Assert.AreEqual(GigabytesInOneBit, bit.As(InformationUnit.Gigabyte), GigabytesTolerance);
            Assert.AreEqual(KibibitsInOneBit, bit.As(InformationUnit.Kibibit), KibibitsTolerance);
            Assert.AreEqual(KibibytesInOneBit, bit.As(InformationUnit.Kibibyte), KibibytesTolerance);
            Assert.AreEqual(KilobitsInOneBit, bit.As(InformationUnit.Kilobit), KilobitsTolerance);
            Assert.AreEqual(KilobytesInOneBit, bit.As(InformationUnit.Kilobyte), KilobytesTolerance);
            Assert.AreEqual(MebibitsInOneBit, bit.As(InformationUnit.Mebibit), MebibitsTolerance);
            Assert.AreEqual(MebibytesInOneBit, bit.As(InformationUnit.Mebibyte), MebibytesTolerance);
            Assert.AreEqual(MegabitsInOneBit, bit.As(InformationUnit.Megabit), MegabitsTolerance);
            Assert.AreEqual(MegabytesInOneBit, bit.As(InformationUnit.Megabyte), MegabytesTolerance);
            Assert.AreEqual(PebibitsInOneBit, bit.As(InformationUnit.Pebibit), PebibitsTolerance);
            Assert.AreEqual(PebibytesInOneBit, bit.As(InformationUnit.Pebibyte), PebibytesTolerance);
            Assert.AreEqual(PetabitsInOneBit, bit.As(InformationUnit.Petabit), PetabitsTolerance);
            Assert.AreEqual(PetabytesInOneBit, bit.As(InformationUnit.Petabyte), PetabytesTolerance);
            Assert.AreEqual(TebibitsInOneBit, bit.As(InformationUnit.Tebibit), TebibitsTolerance);
            Assert.AreEqual(TebibytesInOneBit, bit.As(InformationUnit.Tebibyte), TebibytesTolerance);
            Assert.AreEqual(TerabitsInOneBit, bit.As(InformationUnit.Terabit), TerabitsTolerance);
            Assert.AreEqual(TerabytesInOneBit, bit.As(InformationUnit.Terabyte), TerabytesTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Information bit = Information.FromBits(1);
            Assert.AreEqual(1, Information.FromBits(bit.Bits).Bits, BitsTolerance);
            Assert.AreEqual(1, Information.FromBytes(bit.Bytes).Bits, BytesTolerance);
            Assert.AreEqual(1, Information.FromExabits(bit.Exabits).Bits, ExabitsTolerance);
            Assert.AreEqual(1, Information.FromExabytes(bit.Exabytes).Bits, ExabytesTolerance);
            Assert.AreEqual(1, Information.FromExbibits(bit.Exbibits).Bits, ExbibitsTolerance);
            Assert.AreEqual(1, Information.FromExbibytes(bit.Exbibytes).Bits, ExbibytesTolerance);
            Assert.AreEqual(1, Information.FromGibibits(bit.Gibibits).Bits, GibibitsTolerance);
            Assert.AreEqual(1, Information.FromGibibytes(bit.Gibibytes).Bits, GibibytesTolerance);
            Assert.AreEqual(1, Information.FromGigabits(bit.Gigabits).Bits, GigabitsTolerance);
            Assert.AreEqual(1, Information.FromGigabytes(bit.Gigabytes).Bits, GigabytesTolerance);
            Assert.AreEqual(1, Information.FromKibibits(bit.Kibibits).Bits, KibibitsTolerance);
            Assert.AreEqual(1, Information.FromKibibytes(bit.Kibibytes).Bits, KibibytesTolerance);
            Assert.AreEqual(1, Information.FromKilobits(bit.Kilobits).Bits, KilobitsTolerance);
            Assert.AreEqual(1, Information.FromKilobytes(bit.Kilobytes).Bits, KilobytesTolerance);
            Assert.AreEqual(1, Information.FromMebibits(bit.Mebibits).Bits, MebibitsTolerance);
            Assert.AreEqual(1, Information.FromMebibytes(bit.Mebibytes).Bits, MebibytesTolerance);
            Assert.AreEqual(1, Information.FromMegabits(bit.Megabits).Bits, MegabitsTolerance);
            Assert.AreEqual(1, Information.FromMegabytes(bit.Megabytes).Bits, MegabytesTolerance);
            Assert.AreEqual(1, Information.FromPebibits(bit.Pebibits).Bits, PebibitsTolerance);
            Assert.AreEqual(1, Information.FromPebibytes(bit.Pebibytes).Bits, PebibytesTolerance);
            Assert.AreEqual(1, Information.FromPetabits(bit.Petabits).Bits, PetabitsTolerance);
            Assert.AreEqual(1, Information.FromPetabytes(bit.Petabytes).Bits, PetabytesTolerance);
            Assert.AreEqual(1, Information.FromTebibits(bit.Tebibits).Bits, TebibitsTolerance);
            Assert.AreEqual(1, Information.FromTebibytes(bit.Tebibytes).Bits, TebibytesTolerance);
            Assert.AreEqual(1, Information.FromTerabits(bit.Terabits).Bits, TerabitsTolerance);
            Assert.AreEqual(1, Information.FromTerabytes(bit.Terabytes).Bits, TerabytesTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Information v = Information.FromBits(1);
            Assert.AreEqual(-1, -v.Bits, BitsTolerance);
            Assert.AreEqual(2, (Information.FromBits(3)-v).Bits, BitsTolerance);
            Assert.AreEqual(2, (v + v).Bits, BitsTolerance);
            Assert.AreEqual(10, (v*10).Bits, BitsTolerance);
            Assert.AreEqual(10, (10*v).Bits, BitsTolerance);
            Assert.AreEqual(2, (Information.FromBits(10)/5).Bits, BitsTolerance);
            Assert.AreEqual(2, Information.FromBits(10)/Information.FromBits(5), BitsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Information oneBit = Information.FromBits(1);
            Information twoBits = Information.FromBits(2);

            Assert.True(oneBit < twoBits);
            Assert.True(oneBit <= twoBits);
            Assert.True(twoBits > oneBit);
            Assert.True(twoBits >= oneBit);

            Assert.False(oneBit > twoBits);
            Assert.False(oneBit >= twoBits);
            Assert.False(twoBits < oneBit);
            Assert.False(twoBits <= oneBit);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Information bit = Information.FromBits(1);
            Assert.AreEqual(0, bit.CompareTo(bit));
            Assert.Greater(bit.CompareTo(Information.Zero), 0);
            Assert.Less(Information.Zero.CompareTo(bit), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Information bit = Information.FromBits(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            bit.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Information bit = Information.FromBits(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            bit.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Information a = Information.FromBits(1);
            Information b = Information.FromBits(2);

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
            Information v = Information.FromBits(1);
            Assert.IsTrue(v.Equals(Information.FromBits(1)));
            Assert.IsFalse(v.Equals(Information.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Information bit = Information.FromBits(1);
            Assert.IsFalse(bit.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Information bit = Information.FromBits(1);
            Assert.IsFalse(bit.Equals(null));
        }
    }
}
