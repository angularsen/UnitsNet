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
using System.Globalization;
using NUnit.Framework;
using UnitsNet.Units;

namespace UnitsNet.Tests
{
    public class UnitFormatterTests
    {
        [TestFixture]
        public class GetFormat
        {
            [Test]
            public void ValueIsZero_ExpectNoFormatting()
            {
                string format = UnitFormatter.GetFormat(0, 2);

                StringAssert.DoesNotContain("#", format);
                Assert.That(format, Is.EqualTo("{0} {1}"));
            }

            [TestCase(0.0000012345, 1)]
            [TestCase(0.0000012345, 2)]
            [TestCase(0.0000012345, 4)]
            [TestCase(1234567, 1)]
            [TestCase(1234567, 2)]
            [TestCase(1234567, 4)]
            public void VerySmallAndVeryLargeValues_ExpectCorrectNumberOfHashSymbols(double value, int digitsAfterRadix)
            {
                string format = UnitFormatter.GetFormat(value, digitsAfterRadix);

                // The number of hash symbols directly correlates to the number of digits after the radix point.
                string hashes = new string('#', digitsAfterRadix);
                StringAssert.Contains(hashes, format);
            }

            [Test]
            public void ValueIsSmallerThan1eNeg5_ExpectFormatContainsScientificNotationSpecifier()
            {
                string format = UnitFormatter.GetFormat(1e-7, 2);

                StringAssert.Contains("e-0", format);
            }

            [Test]
            public void ValueIsSmallerThan1ButGreaterThan1eNeg5_ExpectFormatUsesGeneralSpecifier()
            {
                string format = UnitFormatter.GetFormat(1e-3, 2);

                StringAssert.Contains("g2", format);
            }

            [Test]
            public void ValueIs1_ExpectFormatIsFixedPointNotation()
            {
                string format = UnitFormatter.GetFormat(1, 2);

                Assert.That(format, Is.EqualTo("{0:0.##} {1}"));
            }

            [Test]
            public void ValueIsBetween1And1e5_ExpectFormatIsFixedPointNotation()
            {
                string format = UnitFormatter.GetFormat(1234.56, 3);

                Assert.That(format, Is.EqualTo("{0:0.###} {1}"));
            }

            [Test]
            public void ValueIsLargerThan1e5_ExpectFormatContainsScientificNotationSpecifier()
            {
                string format = UnitFormatter.GetFormat(1e7, 2);

                StringAssert.Contains("e0", format);
            }
        }

        [TestFixture]
        public class GetFormatArgs
        {
            [Test]
            public void ExpectArgsContainsCorrectUnitAbbreviation()
            {
                var args = UnitFormatter.GetFormatArgs(LengthUnit.Meter, 1, null, new object[]{});
                Assert.That(args, Contains.Item("m"));

                args = UnitFormatter.GetFormatArgs(FrequencyUnit.Gigahertz, 1, null, new object[]{});
                Assert.That(args, Contains.Item("GHz"));

                args = UnitFormatter.GetFormatArgs(ElectricPotentialUnit.Volt, 1, null, new object[]{});
                Assert.That(args, Contains.Item("V"));
            }

            [Test]
            public void ExpectAllParametersConcatenatedIntoObjectArray()
            {
                var args = UnitFormatter.GetFormatArgs(LengthUnit.Kilometer, 99, CultureInfo.InvariantCulture, new object[] {1});

                Assert.That(args, Contains.Item(99.0));
                Assert.That(args, Contains.Item("km"));
                Assert.That(args, Contains.Item(1));
            }
        }
    }
}