// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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
using UnitsNet.ThirdParty.Units;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.ThirdParty.Tests
{
    /// <summary>
    /// Test of Foo.
    /// </summary>
    [TestFixture]
    public abstract partial class FooTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double FoosInOneFoo { get; }
        public abstract double FooPlusTwosInOneFoo { get; }
        public abstract double FoosQuadrupledInOneFoo { get; }
        public abstract double TwiceThanFoosInOneFoo { get; }

        [Test]
        public void FooToFooUnits()
        {
            Foo foo = Foo.FromFoos(1);
            Assert.AreEqual(FoosInOneFoo, foo.Foos, Delta);
            Assert.AreEqual(FooPlusTwosInOneFoo, foo.FooPlusTwos, Delta);
            Assert.AreEqual(FoosQuadrupledInOneFoo, foo.FoosQuadrupled, Delta);
            Assert.AreEqual(TwiceThanFoosInOneFoo, foo.TwiceThanFoos, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Foo foo = Foo.FromFoos(1); 
            Assert.AreEqual(1, Foo.FromFoos(foo.Foos).Foos, Delta);
            Assert.AreEqual(1, Foo.FromFooPlusTwos(foo.FooPlusTwos).Foos, Delta);
            Assert.AreEqual(1, Foo.FromFoosQuadrupled(foo.FoosQuadrupled).Foos, Delta);
            Assert.AreEqual(1, Foo.FromTwiceThanFoos(foo.TwiceThanFoos).Foos, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Foo v = Foo.FromFoos(1);
            Assert.AreEqual(-1, -v.Foos, Delta);
            Assert.AreEqual(2, (Foo.FromFoos(3)-v).Foos, Delta);
            Assert.AreEqual(2, (v + v).Foos, Delta);
            Assert.AreEqual(10, (v*10).Foos, Delta);
            Assert.AreEqual(10, (10*v).Foos, Delta);
            Assert.AreEqual(2, (Foo.FromFoos(10)/5).Foos, Delta);
            Assert.AreEqual(2, Foo.FromFoos(10)/Foo.FromFoos(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Foo oneFoo = Foo.FromFoos(1);
            Foo twoFoos = Foo.FromFoos(2);

            Assert.True(oneFoo < twoFoos);
            Assert.True(oneFoo <= twoFoos);
            Assert.True(twoFoos > oneFoo);
            Assert.True(twoFoos >= oneFoo);

            Assert.False(oneFoo > twoFoos);
            Assert.False(oneFoo >= twoFoos);
            Assert.False(twoFoos < oneFoo);
            Assert.False(twoFoos <= oneFoo);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Foo foo = Foo.FromFoos(1);
            Assert.AreEqual(0, foo.CompareTo(foo));
            Assert.Greater(foo.CompareTo(Foo.Zero), 0);
            Assert.Less(Foo.Zero.CompareTo(foo), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Foo foo = Foo.FromFoos(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            foo.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Foo foo = Foo.FromFoos(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            foo.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Foo a = Foo.FromFoos(1);
            Foo b = Foo.FromFoos(2);

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
            Foo v = Foo.FromFoos(1);
            Assert.IsTrue(v.Equals(Foo.FromFoos(1)));
            Assert.IsFalse(v.Equals(Foo.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Foo foo = Foo.FromFoos(1);
            Assert.IsFalse(foo.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Foo foo = Foo.FromFoos(1);
            Assert.IsFalse(foo.Equals(null));
        }

        [Test]
        public void FooUnitHasAnEnumerationNamedUndefinedEqualToZero()
        {
            Assert.AreEqual("Undefined", Enum.ToObject(typeof (FooUnit), 0).ToString(), "Enumeration 'FooUnit.Undefined = 0' not found.");
        }

        [Test]
        public void From_DynamicConversion()
        {
            Assert.AreEqual(Foo.FromFoos(1), Foo.From(1, FooUnit.Foo));
            Assert.AreEqual(Foo.FromFooPlusTwos(1), Foo.From(1, FooUnit.FooPlus2));
            Assert.AreEqual(Foo.FromFoosQuadrupled(1), Foo.From(1, FooUnit.FooQuadrupled));
            Assert.AreEqual(Foo.FromTwiceThanFoos(1), Foo.From(1, FooUnit.TwiceThanFoo));
        }
        
        [Test]
        public void Convert_Conversion()
        {
            var from = Foo.FromFoos(1);
            Assert.AreEqual(from.Foos, from.Convert(FooUnit.Foo));
            Assert.AreEqual(from.FooPlusTwos, from.Convert(FooUnit.FooPlus2));
            Assert.AreEqual(from.FoosQuadrupled, from.Convert(FooUnit.FooQuadrupled));
            Assert.AreEqual(from.TwiceThanFoos, from.Convert(FooUnit.TwiceThanFoo));
        }

        [Test]
        public void Convert_ThrowsOnInvalidUnit()
        {
            var from = Foo.FromFoos(1);
            Assert.Throws<NotImplementedException>(() => from.Convert(0));
        }

        [Test]
        public void TryConvert_Conversion()
        {
            var from = Foo.FromFoos(1);
            double val;

            Assert.True(from.TryConvert(FooUnit.Foo, out val));
            Assert.AreEqual(from.Foos, val);

            Assert.True(from.TryConvert(FooUnit.FooPlus2, out val));
            Assert.AreEqual(from.FooPlusTwos, val);

            Assert.True(from.TryConvert(FooUnit.FooQuadrupled, out val));
            Assert.AreEqual(from.FoosQuadrupled, val);

            Assert.True(from.TryConvert(FooUnit.TwiceThanFoo, out val));
            Assert.AreEqual(from.TwiceThanFoos, val);
        }

        [Test]
        public void TryConvert_ReturnsFalseOnInvalidUnit()
        {
            var from = Foo.FromFoos(1);
            double val;
            Assert.False(from.TryConvert(0, out val));
        }
    }
}
