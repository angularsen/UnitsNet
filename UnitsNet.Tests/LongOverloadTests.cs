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
    public class LongOverloadTests
    {
        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromLongReturnsCorrectValue()
        {
            long oneMeterPerSecondSquared = 1;
            Acceleration acceleration = Acceleration.FromMetersPerSecondSquared(oneMeterPerSecondSquared);
            Assert.Equal(1.0, acceleration.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromNullableLongReturnsCorrectValue()
        {
            long? oneMeterPerSecondSquared = 1;
            Acceleration? acceleration = Acceleration.FromMetersPerSecondSquared(oneMeterPerSecondSquared);
            Assert.NotNull(acceleration);
            Assert.Equal(1.0, acceleration.Value.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromNullableLongReturnsNullWhenGivenNull()
        {
            long? nullLong = null;
            Acceleration? acceleration = Acceleration.FromMetersPerSecondSquared(nullLong);
            Assert.Null(acceleration);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromLongWithExtensionMethodReturnsCorrectValue()
        {
            long oneMeterPerSecondSquared = 1;
            Acceleration acceleration = oneMeterPerSecondSquared.MetersPerSecondSquared();
            Assert.Equal(1.0, acceleration.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromNullableLongWithExtensionMethodReturnsCorrectValue()
        {
            long? oneMeterPerSecondSquared = 1;
            Acceleration? acceleration = oneMeterPerSecondSquared.MetersPerSecondSquared();
            Assert.NotNull(acceleration);
            Assert.Equal(1.0, acceleration.Value.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromNullableLongWithExtensionMethodReturnsNullWhenGivenNull()
        {
            long? nullLong = null;
            Acceleration? acceleration = nullLong.MetersPerSecondSquared();
            Assert.Null(acceleration);
        }

        [Fact]
        public static void CreatingQuantityWithLongBackingFieldFromLongReturnsCorrectValue()
        {
            long oneWatt = 1;
            Power power = Power.FromWatts(oneWatt);
            Assert.Equal(1.0, power.Watts);
        }

        [Fact]
        public static void CreatingQuantityWithLongBackingFieldFromNullableLongReturnsCorrectValue()
        {
            long? oneWatt = 1;
            Power? power = Power.FromWatts(oneWatt);
            Assert.NotNull(power);
            Assert.Equal(1.0, power.Value.Watts);
        }

        [Fact]
        public static void CreatingQuantityWithLongBackingFieldFromNullableLongReturnsNullWhenGivenNull()
        {
            long? nullLong = null;
            Power? power = Power.FromWatts(nullLong);
            Assert.Null(power);
        }

        [Fact]
        public static void CreatingQuantityWithLongBackingFieldFromLongWithExtensionMethodReturnsCorrectValue()
        {
            long oneWatt = 1;
            Power power = oneWatt.Watts();
            Assert.Equal(1.0, power.Watts);
        }

        [Fact]
        public static void CreatingQuantityWithLongBackingFieldFromNullableLongWithExtensionMethodReturnsCorrectValue()
        {
            long? oneWatt = 1;
            Power? power = oneWatt.Watts();
            Assert.NotNull(power);
            Assert.Equal(1.0, power.Value.Watts);
        }

        [Fact]
        public static void CreatingQuantityWithLongBackingFieldFromNullableLongWithExtensionMethodReturnsNullWhenGivenNull()
        {
            long? nullLong = null;
            Power? power = nullLong.Watts();
            Assert.Null(power);
        }
    }
}
