// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
        protected abstract double ExabytesInOneBit { get; }
        protected abstract double GigabytesInOneBit { get; }
        protected abstract double KilobytesInOneBit { get; }
        protected abstract double MegabytesInOneBit { get; }
        protected abstract double PetabytesInOneBit { get; }
        protected abstract double TerabytesInOneBit { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double BitsTolerance { get { return 1E-5; } }
        protected virtual double BytesTolerance { get { return 1E-5; } }
        protected virtual double ExabytesTolerance { get { return 1E-5; } }
        protected virtual double GigabytesTolerance { get { return 1E-5; } }
        protected virtual double KilobytesTolerance { get { return 1E-5; } }
        protected virtual double MegabytesTolerance { get { return 1E-5; } }
        protected virtual double PetabytesTolerance { get { return 1E-5; } }
        protected virtual double TerabytesTolerance { get { return 1E-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void BitToInformationUnits()
        {
            Information bit = Information.FromBits(1);
            Assert.AreEqual(BitsInOneBit, bit.Bits, BitsTolerance);
            Assert.AreEqual(BytesInOneBit, bit.Bytes, BytesTolerance);
            Assert.AreEqual(ExabytesInOneBit, bit.Exabytes, ExabytesTolerance);
            Assert.AreEqual(GigabytesInOneBit, bit.Gigabytes, GigabytesTolerance);
            Assert.AreEqual(KilobytesInOneBit, bit.Kilobytes, KilobytesTolerance);
            Assert.AreEqual(MegabytesInOneBit, bit.Megabytes, MegabytesTolerance);
            Assert.AreEqual(PetabytesInOneBit, bit.Petabytes, PetabytesTolerance);
            Assert.AreEqual(TerabytesInOneBit, bit.Terabytes, TerabytesTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Information.From(1, InformationUnit.Bit).Bits, BitsTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Byte).Bytes, BytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Exabyte).Exabytes, ExabytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Gigabyte).Gigabytes, GigabytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Kilobyte).Kilobytes, KilobytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Megabyte).Megabytes, MegabytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Petabyte).Petabytes, PetabytesTolerance);
            Assert.AreEqual(1, Information.From(1, InformationUnit.Terabyte).Terabytes, TerabytesTolerance);
        }

        [Test]
        public void As()
        {
            var bit = Information.FromBits(1);
            Assert.AreEqual(BitsInOneBit, bit.As(InformationUnit.Bit), BitsTolerance);
            Assert.AreEqual(BytesInOneBit, bit.As(InformationUnit.Byte), BytesTolerance);
            Assert.AreEqual(ExabytesInOneBit, bit.As(InformationUnit.Exabyte), ExabytesTolerance);
            Assert.AreEqual(GigabytesInOneBit, bit.As(InformationUnit.Gigabyte), GigabytesTolerance);
            Assert.AreEqual(KilobytesInOneBit, bit.As(InformationUnit.Kilobyte), KilobytesTolerance);
            Assert.AreEqual(MegabytesInOneBit, bit.As(InformationUnit.Megabyte), MegabytesTolerance);
            Assert.AreEqual(PetabytesInOneBit, bit.As(InformationUnit.Petabyte), PetabytesTolerance);
            Assert.AreEqual(TerabytesInOneBit, bit.As(InformationUnit.Terabyte), TerabytesTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Information bit = Information.FromBits(1);
            Assert.AreEqual(1, Information.FromBits(bit.Bits).Bits, BitsTolerance);
            Assert.AreEqual(1, Information.FromBytes(bit.Bytes).Bits, BytesTolerance);
            Assert.AreEqual(1, Information.FromExabytes(bit.Exabytes).Bits, ExabytesTolerance);
            Assert.AreEqual(1, Information.FromGigabytes(bit.Gigabytes).Bits, GigabytesTolerance);
            Assert.AreEqual(1, Information.FromKilobytes(bit.Kilobytes).Bits, KilobytesTolerance);
            Assert.AreEqual(1, Information.FromMegabytes(bit.Megabytes).Bits, MegabytesTolerance);
            Assert.AreEqual(1, Information.FromPetabytes(bit.Petabytes).Bits, PetabytesTolerance);
            Assert.AreEqual(1, Information.FromTerabytes(bit.Terabytes).Bits, TerabytesTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Information v = Information.FromBits(1);
            Assert.AreEqual(-1, -v.Bits, TerabytesTolerance);
            Assert.AreEqual(2, (Information.FromBits(3)-v).Bits, TerabytesTolerance);
            Assert.AreEqual(2, (v + v).Bits, TerabytesTolerance);
            Assert.AreEqual(10, (v*10).Bits, TerabytesTolerance);
            Assert.AreEqual(10, (10*v).Bits, TerabytesTolerance);
            Assert.AreEqual(2, (Information.FromBits(10)/5).Bits, TerabytesTolerance);
            Assert.AreEqual(2, Information.FromBits(10)/Information.FromBits(5), TerabytesTolerance);
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
