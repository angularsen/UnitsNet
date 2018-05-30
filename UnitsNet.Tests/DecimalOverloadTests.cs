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
using UnitsNet.Extensions.NumberToAcceleration;
using UnitsNet.Extensions.NumberToPower;

namespace UnitsNet.Tests
{
    public class DecimalOverloadTests
    {
        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromDecimalReturnsCorrectValue()
        {
            decimal oneMeterPerSecondSquared = 1m;
            Acceleration acceleration = Acceleration.FromMetersPerSecondSquared(oneMeterPerSecondSquared);
            Assert.Equal(1.0, acceleration.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromNullableDecimalReturnsCorrectValue()
        {
            decimal? oneMeterPerSecondSquared = 1m;
            Acceleration? acceleration = Acceleration.FromMetersPerSecondSquared(oneMeterPerSecondSquared);
            Assert.NotNull(acceleration);
            Assert.Equal(1.0, acceleration.Value.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromNullableDecimalReturnsNullWhenGivenNull()
        {
            decimal? nullDecimal = null;
            Acceleration? acceleration = Acceleration.FromMetersPerSecondSquared(nullDecimal);
            Assert.Null(acceleration);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromDecimalWithExtensionMethodReturnsCorrectValue()
        {
            decimal oneMeterPerSecondSquared = 1m;
            Acceleration acceleration = oneMeterPerSecondSquared.MetersPerSecondSquared();
            Assert.Equal(1.0, acceleration.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromNullableDecimalWithExtensionMethodReturnsCorrectValue()
        {
            decimal? oneMeterPerSecondSquared = 1m;
            Acceleration? acceleration = oneMeterPerSecondSquared.MetersPerSecondSquared();
            Assert.NotNull(acceleration);
            Assert.Equal(1.0, acceleration.Value.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromNullableDecimalWithExtensionMethodReturnsNullWhenGivenNull()
        {
            decimal? nullDecimal = null;
            Acceleration? acceleration = nullDecimal.MetersPerSecondSquared();
            Assert.Null(acceleration);
        }

        [Fact]
        public static void CreatingQuantityWithDecimalBackingFieldFromDecimalReturnsCorrectValue()
        {
            decimal oneWatt = 1m;
            Power power = Power.FromWatts(oneWatt);
            Assert.Equal(1.0, power.Watts);
        }

        [Fact]
        public static void CreatingQuantityWithDecimalBackingFieldFromNullableDecimalReturnsCorrectValue()
        {
            decimal? oneWatt = 1m;
            Power? power = Power.FromWatts(oneWatt);
            Assert.NotNull(power);
            Assert.Equal(1.0, power.Value.Watts);
        }

        [Fact]
        public static void CreatingQuantityWithDecimalBackingFieldFromNullableDecimalReturnsNullWhenGivenNull()
        {
            decimal? nullDecimal = null;
            Power? power = Power.FromWatts(nullDecimal);
            Assert.Null(power);
        }

        [Fact]
        public static void CreatingQuantityWithDecimalBackingFieldFromDecimalWithExtensionMethodReturnsCorrectValue()
        {
            decimal oneWatt = 1m;
            Power power = oneWatt.Watts();
            Assert.Equal(1.0, power.Watts);
        }

        [Fact]
        public static void CreatingQuantityWithDecimalBackingFieldFromNullableDecimalWithExtensionMethodReturnsCorrectValue()
        {
            decimal? oneWatt = 1m;
            Power? power = oneWatt.Watts();
            Assert.NotNull(power);
            Assert.Equal(1.0, power.Value.Watts);
        }

        [Fact]
        public static void CreatingQuantityWithDecimalBackingFieldFromNullableDecimalWithExtensionMethodReturnsNullWhenGivenNull()
        {
            decimal? nullDecimal = null;
            Power? power = nullDecimal.Watts();
            Assert.Null(power);
        }
    }
}
