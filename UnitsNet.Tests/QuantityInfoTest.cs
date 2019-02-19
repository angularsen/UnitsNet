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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityInfoTest
    {
        [Fact]
        public void Constructor_AssignsProperties()
        {
            var expectedZero = Length.FromCentimeters(10);
            var expectedUnitInfos = new UnitInfo[]{ new UnitInfo(LengthUnit.Centimeter, new BaseUnits(LengthUnit.Centimeter)), new UnitInfo(LengthUnit.Kilometer, new BaseUnits(LengthUnit.Kilometer))};
            var expectedBaseUnit = LengthUnit.Centimeter;
            var expectedQuantityType = QuantityType.Length;
            var expectedBaseDimensions = Length.BaseDimensions;

            var info = new QuantityInfo(expectedQuantityType, expectedUnitInfos, expectedBaseUnit, expectedZero, expectedBaseDimensions);

            Assert.Equal(expectedZero, info.Zero);
            Assert.Equal("Length", info.Name);
            Assert.Equal(expectedUnitInfos, info.UnitInfos);
            Assert.Equal(expectedBaseUnit, info.BaseUnit);
            Assert.Equal(new[]{"Centimeter", "Kilometer"}, info.UnitNames);
            Assert.Equal(expectedQuantityType, info.QuantityType);
            Assert.Equal(expectedBaseDimensions, info.BaseDimensions);
        }

        [Fact]
        public void GenericsConstructor_AssignsProperties()
        {
            var expectedZero = Length.FromCentimeters(10);
            var expectedUnitInfos = new UnitInfo<LengthUnit>[]{ new UnitInfo<LengthUnit>(LengthUnit.Centimeter, new BaseUnits(LengthUnit.Centimeter)), new UnitInfo<LengthUnit>(LengthUnit.Kilometer, new BaseUnits(LengthUnit.Kilometer))};
            var expectedBaseUnit = LengthUnit.Centimeter;
            var expectedQuantityType = QuantityType.Length;
            var expectedBaseDimensions = Length.BaseDimensions;

            var info = new QuantityInfo<LengthUnit>(expectedQuantityType, expectedUnitInfos, expectedBaseUnit, expectedZero, expectedBaseDimensions);

            Assert.Equal(expectedZero, info.Zero);
            Assert.Equal("Length", info.Name);
            Assert.Equal(expectedUnitInfos, info.UnitInfos);
            Assert.Equal(expectedBaseUnit, info.BaseUnit);
            Assert.Equal(new[]{"Centimeter", "Kilometer"}, info.UnitNames);
            Assert.Equal(expectedQuantityType, info.QuantityType);
            Assert.Equal(expectedBaseDimensions, info.BaseDimensions);
        }

        [Fact]
        public void Constructor_GivenUndefinedAsQuantityType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new QuantityInfo(QuantityType.Undefined, Length.Info.UnitInfos, Length.BaseUnit, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        public void GenericsConstructor_GivenUndefinedAsQuantityType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new QuantityInfo<LengthUnit>(QuantityType.Undefined, Length.Info.UnitInfos, Length.BaseUnit, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Constructor_GivenNullAsUnitInfos_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo(QuantityType.Length, null, Length.BaseUnit, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void GenericsConstructor_GivenNullAsUnitInfos_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo<LengthUnit>(QuantityType.Length, null, Length.BaseUnit, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Constructor_GivenNullAsBaseUnit_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo(QuantityType.Length, Length.Info.UnitInfos, null, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Constructor_GivenNullAsZero_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo(QuantityType.Length, Length.Info.UnitInfos, Length.BaseUnit, null, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void GenericsConstructor_GivenNullAsZero_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo<LengthUnit>(QuantityType.Length, Length.Info.UnitInfos, Length.BaseUnit, null, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Constructor_GivenNullAsBaseDimensions_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo(QuantityType.Length, Length.Info.UnitInfos, Length.BaseUnit, Length.Zero, null));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void GenericsConstructor_GivenNullAsBaseDimensions_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo<LengthUnit>(QuantityType.Length, Length.Info.UnitInfos, Length.BaseUnit, Length.Zero, null));
        }
    }
}
