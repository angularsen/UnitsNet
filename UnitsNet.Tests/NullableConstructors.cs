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

using System;
using Xunit;
using UnitsNet.Units;

namespace UnitsNet.Tests
{
    public class NullableConstructors 
    {
        [Fact]
        public void StaticConstructorWithNullReturnsNullWhenBackingTypeIsDouble()
        {
            Length? meter = Length.FromMeters(null);
            Assert.False(meter.HasValue);
        }

        [Fact]
        public void StaticConstructorWithNullAndEnumReturnsNullWhenBackingTypeIsDouble()
        {
            Length? meter = Length.From(null, LengthUnit.Meter);
            Assert.False(meter.HasValue);
        }

        [Fact]
        public void StaticConstructorWithNullAndEnumArgumentReturnsValueWhenInputArgumentHasValueWhenBackingTypeIsDouble()
        {
            double? value = 1.0;
            Length? meter = Length.From(value, LengthUnit.Meter);
            Assert.True(meter.HasValue);
        }

        [Fact]
        public void StaticConstructorWithNullArgumentReturnsValueWhenInputArgumentHasValueWhenBackingTypeIsDouble()
        {
            double? value = 1.0;
            Length? meter = Length.FromMeters(value);
            Assert.True(meter.HasValue);
        }

        [Fact]
        public void StaticConstructorWithNullReturnsNullWhenBackingTypeIsDecimal()
        {
            Information? meter = Information.FromBytes(null);
            Assert.False(meter.HasValue);
        }

        [Fact]
        public void StaticConstructorWithNullAndEnumReturnsNullWhenBackingTypeIsDecimal()
        {
            Information? meter = Information.From(null, InformationUnit.Byte);
            Assert.False(meter.HasValue);
        }

        [Fact]
        public void StaticConstructorWithNullAndEnumArgumentReturnsValueWhenInputArgumentHasValueWhenBackingTypeIsDecimal()
        {
            double? value = 1.0;
            Information? meter = Information.From(value, InformationUnit.Byte);
            Assert.True(meter.HasValue);
        }

        [Fact]
        public void StaticConstructorWithNullArgumentReturnsValueWhenInputArgumentHasValueWhenBackingTypeIsDecimal()
        {
            double? value = 1.0;
            Information? meter = Information.FromBytes(value);
            Assert.True(meter.HasValue);
        }
    }
}