// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class FeetInchesTests
    {
        private const double FeetInOneMeter = 3.28084;
        private const double InchesInOneMeter = 39.37007874;
        private const double FeetTolerance = 1e-5;
        private const double InchesTolerance = 1e-5;

        [Fact]
        public void FeetInchesFrom()
        {
            Length meter = Length.FromFeetInches(2, 3);
            double expectedMeters = 2/FeetInOneMeter + 3/InchesInOneMeter;
            AssertEx.EqualTolerance(expectedMeters, meter.Meters, FeetTolerance);
        }

        [Fact]
        public void FeetInchesRoundTrip()
        {
            Length meter = Length.FromFeetInches(2, 3);
            FeetInches feetInches = meter.FeetInches;
            AssertEx.EqualTolerance(2, feetInches.Feet, FeetTolerance);
            AssertEx.EqualTolerance(3, feetInches.Inches, InchesTolerance);
        }

        [Theory]
        [InlineData("1'", 1)] // Feet only
        [InlineData("1′", 1)] // Feet only
        [InlineData("1\"", 0.08333333)] // Inches only
        [InlineData("1″", 0.08333333)] // Inches only
        [InlineData("1' 1\"", 1.08333333)] // Normal form
        [InlineData("1′ 1″", 1.08333333)] // Normal form
        [InlineData(" 1′ 1″ ", 1.08333333)] // Normal form, requires trimming
        [InlineData("1'1\"", 1.08333333)] // Without space
        [InlineData("1′1″", 1.08333333)] // Without space
        [InlineData("1 ft 1 in", 1.08333333)]
        [InlineData("1ft 1in", 1.08333333)]
        public void TryParseFeetInches(string str, double expectedFeet)
        {
            Assert.True(Length.TryParseFeetInches(str, out Length result));
            AssertEx.EqualTolerance(expectedFeet, result.Feet, 1e-5);
        }

        [Theory]
        [InlineData("a")] // Missing or invalid apostrophe or double prime chars
        [InlineData("1")]
        [InlineData("1`")]
        [InlineData("1^")]
        [InlineData("1' 1'")] // Feet apostrophe twice
        [InlineData("1′ 1′")]
        [InlineData("1' 1")] // No inches double prime
        [InlineData("1′ 1")]
        [InlineData("1′ 1`")] // Invalid inches double prime
        [InlineData("1' 1`")]
        [InlineData("1'1'")] // Same without space
        [InlineData("1′1′")]
        [InlineData("1'1")]
        [InlineData("1′1")]
        [InlineData("1′1`")]
        [InlineData("1'1`")]
        public void TryParseFeetInches_GivenInvalidString_ReturnsFalseAndZeroOut(string str)
        {
            Assert.False(Length.TryParseFeetInches(str, out Length result));
            Assert.Equal(Length.Zero, result);
        }
    }
}
