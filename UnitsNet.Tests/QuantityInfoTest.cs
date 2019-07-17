// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
            var expectedUnitInfos = new UnitInfo[]{
                new UnitInfo(LengthUnit.Centimeter, new BaseUnits(LengthUnit.Centimeter)),
                new UnitInfo(LengthUnit.Kilometer, new BaseUnits(LengthUnit.Kilometer))
            };
            var expectedBaseUnit = LengthUnit.Centimeter;
            var expectedQuantityType = QuantityType.Length;
            var expectedBaseDimensions = Length.BaseDimensions;

            var info = new QuantityInfo(expectedQuantityType, expectedUnitInfos,
                expectedBaseUnit, expectedZero, expectedBaseDimensions);

            Assert.Equal(expectedZero, info.Zero);
            Assert.Equal("Length", info.Name);
            Assert.Equal(expectedUnitInfos, info.UnitInfos);
            Assert.Equal(expectedQuantityType, info.QuantityType);
            Assert.Equal(expectedBaseDimensions, info.BaseDimensions);

            // Obsolete members
#pragma warning disable 618
            Assert.Equal( expectedBaseUnit, info.BaseUnit );
            Assert.Equal( new[] { "Centimeter", "Kilometer" }, info.UnitNames );
#pragma warning restore 618
        }

        [Fact]
        public void GenericsConstructor_AssignsProperties()
        {
            var expectedZero = Length.FromCentimeters(10);
            var expectedUnitInfos = new UnitInfo<LengthUnit>[]{
                new UnitInfo<LengthUnit>(LengthUnit.Centimeter, new BaseUnits(LengthUnit.Centimeter)),
                new UnitInfo<LengthUnit>(LengthUnit.Kilometer, new BaseUnits(LengthUnit.Kilometer))
            };
            var expectedBaseUnit = LengthUnit.Centimeter;
            var expectedQuantityType = QuantityType.Length;
            var expectedBaseDimensions = Length.BaseDimensions;

            var info = new QuantityInfo<LengthUnit>(expectedQuantityType, expectedUnitInfos,
                expectedBaseUnit, expectedZero, expectedBaseDimensions);

            Assert.Equal(expectedZero, info.Zero);
            Assert.Equal("Length", info.Name);
            Assert.Equal(expectedUnitInfos, info.UnitInfos);
            Assert.Equal(expectedQuantityType, info.QuantityType);
            Assert.Equal(expectedBaseDimensions, info.BaseDimensions);

            // Obsolete members
#pragma warning disable 618
            Assert.Equal( expectedBaseUnit, info.BaseUnit );
            Assert.Equal( new[] { "Centimeter", "Kilometer" }, info.UnitNames );
#pragma warning restore 618
        }

        [Fact]
        public void Constructor_GivenUndefinedAsQuantityType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new QuantityInfo(QuantityType.Undefined,
                Length.Info.UnitInfos, Length.BaseUnit, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        public void GenericsConstructor_GivenUndefinedAsQuantityType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new QuantityInfo<LengthUnit>(QuantityType.Undefined,
                Length.Info.UnitInfos, Length.BaseUnit, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Constructor_GivenNullAsUnitInfos_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo(QuantityType.Length,
                null, Length.BaseUnit, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void GenericsConstructor_GivenNullAsUnitInfos_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo<LengthUnit>(QuantityType.Length,
                null, Length.BaseUnit, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Constructor_GivenNullAsBaseUnit_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo(QuantityType.Length,
                Length.Info.UnitInfos, null, Length.Zero, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Constructor_GivenNullAsZero_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo(QuantityType.Length,
                Length.Info.UnitInfos, Length.BaseUnit, null, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void GenericsConstructor_GivenNullAsZero_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo<LengthUnit>(QuantityType.Length,
                Length.Info.UnitInfos, Length.BaseUnit, null, Length.BaseDimensions));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Constructor_GivenNullAsBaseDimensions_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo(QuantityType.Length,
                Length.Info.UnitInfos, Length.BaseUnit, Length.Zero, null));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void GenericsConstructor_GivenNullAsBaseDimensions_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuantityInfo<LengthUnit>(QuantityType.Length,
                Length.Info.UnitInfos, Length.BaseUnit, Length.Zero, null));
        }

        [Fact]
        public void GetUnitInfoFor_GivenNullAsBaseUnits_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Length.Info.GetUnitInfoFor(null));
        }

        [Fact]
        public void GetUnitInfoFor_GivenBaseUnitsWithNoMatch_ThrowsInvalidOperationException()
        {
            var baseUnitsWithNoMatch = new BaseUnits(mass: MassUnit.Kilogram);
            Assert.Throws<InvalidOperationException>(() => Length.Info.GetUnitInfoFor(baseUnitsWithNoMatch));
        }

        [Fact]
        public void GetUnitInfoFor_GivenBaseUnitsWithMultipleMatches_ThrowsInvalidOperationException()
        {
            var baseUnits = new BaseUnits(LengthUnit.Meter);

            var quantityInfo = new QuantityInfo<LengthUnit>(QuantityType.Length,
                new UnitInfo<LengthUnit>[]{
                    new UnitInfo<LengthUnit>(LengthUnit.Meter, baseUnits),
                    new UnitInfo<LengthUnit>(LengthUnit.Foot, baseUnits) },
                LengthUnit.Meter, Length.Zero, Length.BaseDimensions);

            Assert.Throws<InvalidOperationException>(() => quantityInfo.GetUnitInfoFor(baseUnits));
        }

        [Fact]
        public void GetUnitInfosFor_GivenNullAsBaseUnits_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Length.Info.GetUnitInfosFor(null));
        }

        [Fact]
        public void GetUnitInfosFor_GivenBaseUnitsWithNoMatch_ReturnsEmpty()
        {
            var baseUnitsWithNoMatch = new BaseUnits(mass: MassUnit.Kilogram);
            var result = Length.Info.GetUnitInfosFor(baseUnitsWithNoMatch);
            Assert.Empty(result);
        }

        [Fact]
        public void GetUnitInfosFor_GivenBaseUnitsWithOneMatch_ReturnsOneMatch()
        {
            var baseUnitsWithOneMatch = new BaseUnits(LengthUnit.Foot);
            var result = Length.Info.GetUnitInfosFor(baseUnitsWithOneMatch);
            Assert.Collection(result, element1 => Assert.Equal(LengthUnit.Foot, element1.Value));
        }

        [Fact]
        public void GetUnitInfosFor_GivenBaseUnitsWithMultipleMatches_ReturnsMultipleMatches()
        {
            var baseUnits = new BaseUnits(LengthUnit.Meter);

            var quantityInfo = new QuantityInfo<LengthUnit>(QuantityType.Length,
                new UnitInfo<LengthUnit>[]{
                    new UnitInfo<LengthUnit>(LengthUnit.Meter, baseUnits),
                    new UnitInfo<LengthUnit>(LengthUnit.Foot, baseUnits) },
                LengthUnit.Meter, Length.Zero, Length.BaseDimensions);

            var result = quantityInfo.GetUnitInfosFor(baseUnits);

            Assert.Collection(result,
                element1 =>
                {
                    Assert.Equal(LengthUnit.Meter, element1.Value);
                    Assert.Equal(baseUnits, element1.BaseUnits);
                },
                element2 =>
                {
                    Assert.Equal(LengthUnit.Foot, element2.Value);
                    Assert.Equal(baseUnits, element2.BaseUnits);
                } );
        }
    }
}
