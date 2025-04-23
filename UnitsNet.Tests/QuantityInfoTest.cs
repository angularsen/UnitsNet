// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;
using System.Resources;
using UnitsNet.Tests.CustomQuantities;

namespace UnitsNet.Tests;

public class QuantityInfoTest
{
    [Fact]
    [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
    public void Constructor_AssignsProperties()
    {
        UnitDefinition<LengthUnit>[] expectedUnitInfos =
        [
            new(LengthUnit.Centimeter, "Centimeters", new BaseUnits(LengthUnit.Centimeter)),
            new(LengthUnit.Kilometer, "Kilometers", new BaseUnits(LengthUnit.Kilometer))
        ];
        const LengthUnit expectedBaseUnit = LengthUnit.Centimeter;
        var expectedZero = Length.FromCentimeters(10);
        BaseDimensions expectedBaseDimensions = Length.BaseDimensions;
        var abbreviations = new ResourceManager("UnitsNet.GeneratedCode.Resources.Length", typeof(Length).Assembly);

        var quantityInfo = new QuantityInfo<Length, LengthUnit>(nameof(Length), expectedBaseUnit, expectedUnitInfos, expectedZero, expectedBaseDimensions,
            Length.From, abbreviations);

        Assert.Equal(nameof(Length), quantityInfo.Name);
        Assert.Equal(typeof(Length), quantityInfo.QuantityType);
        Assert.Equal(typeof(LengthUnit), quantityInfo.UnitType);

        // BaseUnitInfo
        Assert.Multiple(() =>
        {
            UnitInfo<Length, LengthUnit> baseUnitInfo = quantityInfo.BaseUnitInfo;
            Assert.Equal(expectedBaseUnit, baseUnitInfo.Value);
        }, () =>
        {
            QuantityInfo<LengthUnit> genericQuantityInfo = quantityInfo;
            UnitInfo<LengthUnit> unitInfos = genericQuantityInfo.BaseUnitInfo;
            Assert.Equal(quantityInfo.BaseUnitInfo, unitInfos);
        }, () =>
        {
            QuantityInfo genericQuantityInfo = quantityInfo;
            UnitInfo unitInfos = genericQuantityInfo.BaseUnitInfo;
            Assert.Equal(quantityInfo.BaseUnitInfo, unitInfos);
        });
        
        // UnitInfos
        Assert.Multiple(() =>
        {
            Assert.Collection(quantityInfo.UnitInfos, firstUnitInfo =>
            {
                Assert.Equal(LengthUnit.Centimeter, firstUnitInfo.Value);
                Assert.Equal(expectedUnitInfos[0].Name, firstUnitInfo.Name);
                Assert.Equal(expectedUnitInfos[0].PluralName, firstUnitInfo.PluralName);
                Assert.Equal(expectedUnitInfos[0].BaseUnits, firstUnitInfo.BaseUnits);
                Assert.Equal(quantityInfo, firstUnitInfo.QuantityInfo);
            }, secondUnitInfo =>
            {
                Assert.Equal(LengthUnit.Kilometer, secondUnitInfo.Value);
                Assert.Equal(expectedUnitInfos[1].Name, secondUnitInfo.Name);
                Assert.Equal(expectedUnitInfos[1].PluralName, secondUnitInfo.PluralName);
                Assert.Equal(expectedUnitInfos[1].BaseUnits, secondUnitInfo.BaseUnits);
                Assert.Equal(quantityInfo, secondUnitInfo.QuantityInfo);
            });
        }, () =>
        {
            QuantityInfo<LengthUnit> genericQuantityInfo = quantityInfo;
            IReadOnlyCollection<UnitInfo<LengthUnit>> unitInfos = genericQuantityInfo.UnitInfos;
            Assert.Equal(quantityInfo.UnitInfos, unitInfos);
        }, () =>
        {
            QuantityInfo genericQuantityInfo = quantityInfo;
            IReadOnlyCollection<UnitInfo> unitInfos = genericQuantityInfo.UnitInfos;
            Assert.Equal(quantityInfo.UnitInfos, unitInfos);
        });

        // Zero
        Assert.Multiple(() =>
        {
            Length zero = quantityInfo.Zero;
            Assert.Equal(expectedZero, zero);
        }, () =>
        {
            QuantityInfo<LengthUnit> genericQuantityInfo = quantityInfo;
            IQuantity<LengthUnit> zero = genericQuantityInfo.Zero;
            Assert.Equal(expectedZero, zero);
        }, () =>
        {
            QuantityInfo genericQuantityInfo = quantityInfo;
            IQuantity zero = genericQuantityInfo.Zero;
            Assert.Equal(expectedZero, zero);
        });

        Assert.Equal(expectedBaseDimensions, quantityInfo.BaseDimensions);
        Assert.Equal(abbreviations, quantityInfo.UnitAbbreviations);
    }

    [Fact]
    [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
    public void Constructor_AssignsPropertiesForCustomQuantity()
    {
        UnitDefinition<HowMuchUnit>[] expectedUnitInfos =
        [
            new(HowMuchUnit.Some, "Some", BaseUnits.Undefined),
            new(HowMuchUnit.ATon, "Tons", BaseUnits.Undefined),
            new(HowMuchUnit.AShitTon, "ShitTons", BaseUnits.Undefined)
        ];
        const HowMuchUnit expectedBaseUnit = HowMuchUnit.Some;
        var expectedZero = new HowMuch(10, HowMuchUnit.Some);
        BaseDimensions expectedBaseDimensions = BaseDimensions.Dimensionless;

        var quantityInfo = new QuantityInfo<HowMuch, HowMuchUnit>(nameof(HowMuch), expectedBaseUnit,
            expectedUnitInfos, expectedZero, expectedBaseDimensions, HowMuch.From);

        Assert.Equal(nameof(HowMuch), quantityInfo.Name);
        Assert.Equal(typeof(HowMuch), quantityInfo.QuantityType);
        Assert.Equal(typeof(HowMuchUnit), quantityInfo.UnitType);
        Assert.Equal(expectedBaseUnit, quantityInfo.BaseUnitInfo.Value);
        Assert.Collection(quantityInfo.UnitInfos, firstUnitInfo =>
        {
            Assert.Equal(HowMuchUnit.Some, firstUnitInfo.Value);
            Assert.Equal(expectedUnitInfos[0].Name, firstUnitInfo.Name);
            Assert.Equal(expectedUnitInfos[0].PluralName, firstUnitInfo.PluralName);
            Assert.Equal(expectedUnitInfos[0].BaseUnits, firstUnitInfo.BaseUnits);
            Assert.Equal(quantityInfo, firstUnitInfo.QuantityInfo);
        }, secondUnitInfo =>
        {
            Assert.Equal(HowMuchUnit.ATon, secondUnitInfo.Value);
            Assert.Equal(expectedUnitInfos[1].Name, secondUnitInfo.Name);
            Assert.Equal(expectedUnitInfos[1].PluralName, secondUnitInfo.PluralName);
            Assert.Equal(expectedUnitInfos[1].BaseUnits, secondUnitInfo.BaseUnits);
            Assert.Equal(quantityInfo, secondUnitInfo.QuantityInfo);
        }, thirdUnitInfo =>
        {
            Assert.Equal(HowMuchUnit.AShitTon, thirdUnitInfo.Value);
            Assert.Equal(expectedUnitInfos[2].Name, thirdUnitInfo.Name);
            Assert.Equal(expectedUnitInfos[2].PluralName, thirdUnitInfo.PluralName);
            Assert.Equal(expectedUnitInfos[2].BaseUnits, thirdUnitInfo.BaseUnits);
            Assert.Equal(quantityInfo, thirdUnitInfo.QuantityInfo);
        });
        Assert.Equal(expectedZero, quantityInfo.Zero);
        Assert.Equal(expectedBaseDimensions, quantityInfo.BaseDimensions);
        Assert.Null(quantityInfo.UnitAbbreviations);
    }

    [Fact]
    public void Constructor_WithoutZero_UsesZeroBaseUnit()
    {
        UnitDefinition<HowMuchUnit>[] expectedUnitInfos =
        [
            new(HowMuchUnit.Some, "Some", BaseUnits.Undefined)
        ];
        const HowMuchUnit expectedBaseUnit = HowMuchUnit.Some;
        BaseDimensions expectedBaseDimensions = BaseDimensions.Dimensionless;
        var expectedZero = new HowMuch(0, HowMuchUnit.Some);

        var quantityInfo = new QuantityInfo<HowMuch, HowMuchUnit>(nameof(HowMuch), expectedBaseUnit,
            expectedUnitInfos, expectedBaseDimensions, HowMuch.From);

        Assert.Equal(expectedZero, quantityInfo.Zero);
        Assert.Equal(nameof(HowMuch), quantityInfo.Name);
        Assert.Equal(expectedBaseUnit, quantityInfo.BaseUnitInfo.Value);
        Assert.Single(quantityInfo.UnitInfos, unitInfo =>
            expectedBaseUnit == unitInfo.Value &&
            expectedUnitInfos[0].Name == unitInfo.Name &&
            expectedUnitInfos[0].PluralName == unitInfo.PluralName &&
            expectedUnitInfos[0].BaseUnits == unitInfo.BaseUnits
        );
        Assert.Equal(expectedBaseDimensions, quantityInfo.BaseDimensions);
        Assert.Null(quantityInfo.UnitAbbreviations);
    }

    [Fact]
    public void Constructor_WithoutName_UsesDefaultQuantityTypeName()
    {
        UnitDefinition<HowMuchUnit>[] expectedUnitInfos =
        [
            new(HowMuchUnit.Some, "Some", BaseUnits.Undefined)
        ];
        const HowMuchUnit expectedBaseUnit = HowMuchUnit.Some;
        var expectedZero = new HowMuch(0, HowMuchUnit.Some);
        BaseDimensions expectedBaseDimensions = BaseDimensions.Dimensionless;
        var abbreviations = new ResourceManager("UnitsNet.GeneratedCode.Resources.Length", typeof(Length).Assembly);

        var quantityInfo =
            new QuantityInfo<HowMuch, HowMuchUnit>(expectedBaseUnit, expectedUnitInfos, expectedBaseDimensions, HowMuch.From, abbreviations);

        Assert.Equal(expectedZero, quantityInfo.Zero);
        Assert.Equal(nameof(HowMuch), quantityInfo.Name);
        Assert.Equal(expectedBaseUnit, quantityInfo.BaseUnitInfo.Value);
        Assert.Single(quantityInfo.UnitInfos, firstUnitInfo =>
            expectedBaseUnit == firstUnitInfo.Value &&
            expectedUnitInfos[0].Name == firstUnitInfo.Name &&
            expectedUnitInfos[0].PluralName == firstUnitInfo.PluralName &&
            expectedUnitInfos[0].BaseUnits == firstUnitInfo.BaseUnits
        );
        Assert.Equal(expectedBaseDimensions, quantityInfo.BaseDimensions);
        Assert.Equal(abbreviations, quantityInfo.UnitAbbreviations);
    }

    [Fact]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public void Constructor_GivenNullAsQuantityName_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new QuantityInfo<Length, LengthUnit>(null!,
            LengthUnit.Meter, Length.Info.UnitInfos, Length.BaseDimensions, Length.From));
    }

    [Fact]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public void Constructor_GivenNullAsUnitInfos_ThrowsArgumentNullException()
    {
        IEnumerable<UnitDefinition<LengthUnit>> nullCollection = null!;
        Assert.Throws<ArgumentNullException>(() => new QuantityInfo<Length, LengthUnit>(nameof(Length),
            LengthUnit.Meter, nullCollection, Length.BaseDimensions, Length.From));
    }

    [Fact]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public void Constructor_GivenANullUnitInfo_ThrowsArgumentNullException()
    {
        IEnumerable<UnitDefinition<LengthUnit>> collectionContainingANull = [null!];
#if NET
        Assert.Throws<ArgumentNullException>(() => new QuantityInfo<Length, LengthUnit>(nameof(Length),
            LengthUnit.Meter, collectionContainingANull, Length.BaseDimensions, Length.From));
#else
            Assert.Throws<NullReferenceException>(() => new QuantityInfo<Length, LengthUnit>(nameof(Length),
                LengthUnit.Meter, collectionContainingANull, Length.BaseDimensions, Length.From));
#endif
    }

    [Fact]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public void Constructor_GivenNullAsBaseDimensions_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new QuantityInfo<Length, LengthUnit>(nameof(Length),
            LengthUnit.Meter, Length.Info.UnitInfos, null!, Length.From));
    }

    [Fact]
    public void Constructor_GivenAMissingBaseUnitDefinition_ThrowsUnitNotFoundException()
    {
        Assert.Throws<UnitNotFoundException>(() =>
            new QuantityInfo<Length, LengthUnit>(Length.BaseUnit, [], Length.BaseDimensions, Length.From));
    }

    [Fact]
    public void GetUnitInfoFor_GivenNullAsBaseUnits_ThrowsArgumentNullException()
    {
        Assert.Multiple(() =>
        {
            QuantityInfo<Length, LengthUnit> quantityInfo = Length.Info;
            Assert.Throws<ArgumentNullException>(() => quantityInfo.GetUnitInfoFor(null!));
        }, () =>
        {
            QuantityInfo<LengthUnit> quantityInfo = Length.Info;
            Assert.Throws<ArgumentNullException>(() => quantityInfo.GetUnitInfoFor(null!));
        }, () =>
        {
            QuantityInfo quantityInfo = Length.Info;
            Assert.Throws<ArgumentNullException>(() => quantityInfo.GetUnitInfoFor(null!));
        });
    }

    [Fact]
    public void GetUnitInfoFor_GivenBaseUnitsWithNoMatch_ThrowsInvalidOperationException()
    {
        var baseUnitsWithNoMatch = new BaseUnits(mass: MassUnit.Kilogram);
        Assert.Multiple(() =>
        {
            QuantityInfo<Length, LengthUnit> quantityInfo = Length.Info;
            Assert.Throws<InvalidOperationException>(() => quantityInfo.GetUnitInfoFor(baseUnitsWithNoMatch));
        }, () =>
        {
            QuantityInfo<LengthUnit> quantityInfo = Length.Info;
            Assert.Throws<InvalidOperationException>(() => quantityInfo.GetUnitInfoFor(baseUnitsWithNoMatch));
        }, () =>
        {
            QuantityInfo quantityInfo = Length.Info;
            Assert.Throws<InvalidOperationException>(() => quantityInfo.GetUnitInfoFor(baseUnitsWithNoMatch));
        });
    }

    [Fact]
    public void GetUnitInfoFor_GivenBaseUnitsWithMultipleMatches_ThrowsInvalidOperationException()
    {
        var baseUnits = new BaseUnits(LengthUnit.Meter);
        UnitDefinition<LengthUnit>[] duplicateBaseUnits =
        [
            new(LengthUnit.Meter, "Meters", baseUnits),
            new(LengthUnit.Foot, "Feet", baseUnits)
        ];
        BaseDimensions dimensions = Length.BaseDimensions;
        Assert.Multiple(() =>
        {
            var quantityInfo = new QuantityInfo<Length, LengthUnit>(LengthUnit.Meter, duplicateBaseUnits, dimensions, Length.From);
            Assert.Throws<InvalidOperationException>(() => quantityInfo.GetUnitInfoFor(baseUnits));
        }, () =>
        {
            QuantityInfo<LengthUnit> genericQuantityInfo = new QuantityInfo<Length, LengthUnit>(LengthUnit.Meter, duplicateBaseUnits, dimensions, Length.From);
            Assert.Throws<InvalidOperationException>(() => genericQuantityInfo.GetUnitInfoFor(baseUnits));
        }, () =>
        {
            QuantityInfo genericQuantityInfo = new QuantityInfo<Length, LengthUnit>(LengthUnit.Meter, duplicateBaseUnits, dimensions, Length.From);
            Assert.Throws<InvalidOperationException>(() => genericQuantityInfo.GetUnitInfoFor(baseUnits));
        });
    }

    [Fact]
    public void GetUnitInfoFor_GivenBaseUnitsWithOneMatch_ReturnsTheMatch()
    {
        var baseUnitsWithOneMatch = new BaseUnits(LengthUnit.Foot);
        UnitInfo<Length, LengthUnit> expectedUnitInfo = Length.Info[LengthUnit.Foot];

        Assert.Multiple(() =>
        {
            QuantityInfo<Length, LengthUnit> quantityInfo = Length.Info;

            UnitInfo<Length, LengthUnit> result = quantityInfo.GetUnitInfoFor(baseUnitsWithOneMatch);

            Assert.Equal(expectedUnitInfo, result);
        }, () =>
        {
            QuantityInfo<LengthUnit> quantityInfo = Length.Info;

            UnitInfo<LengthUnit> result = quantityInfo.GetUnitInfoFor(baseUnitsWithOneMatch);

            Assert.Equal(expectedUnitInfo, result);
        }, () =>
        {
            QuantityInfo quantityInfo = Length.Info;

            UnitInfo result = quantityInfo.GetUnitInfoFor(baseUnitsWithOneMatch);

            Assert.Equal(expectedUnitInfo, result);
        });
    }

    [Fact]
    public void GetUnitInfosFor_GivenNullAsBaseUnits_ThrowsArgumentNullException()
    {
        Assert.Multiple(() =>
        {
            QuantityInfo<Length, LengthUnit> quantityInfo = Length.Info;
            Assert.Throws<ArgumentNullException>(() => quantityInfo.GetUnitInfosFor(null!));
        }, () =>
        {
            QuantityInfo<LengthUnit> quantityInfo = Length.Info;
            Assert.Throws<ArgumentNullException>(() => quantityInfo.GetUnitInfosFor(null!));
        }, () =>
        {
            QuantityInfo quantityInfo = Length.Info;
            Assert.Throws<ArgumentNullException>(() => quantityInfo.GetUnitInfosFor(null!));
        });
    }

    [Fact]
    public void GetUnitInfosFor_GivenBaseUnitsWithNoMatch_ReturnsEmpty()
    {
        var baseUnitsWithNoMatch = new BaseUnits(mass: MassUnit.Kilogram);
        Assert.Multiple(() =>
        {
            QuantityInfo<Length, LengthUnit> quantityInfo = Length.Info;

            IEnumerable<UnitInfo<Length, LengthUnit>> result = quantityInfo.GetUnitInfosFor(baseUnitsWithNoMatch);

            Assert.Empty(result);
        }, () =>
        {
            QuantityInfo<LengthUnit> quantityInfo = Length.Info;

            IEnumerable<UnitInfo<LengthUnit>> result = quantityInfo.GetUnitInfosFor(baseUnitsWithNoMatch);

            Assert.Empty(result);
        }, () =>
        {
            QuantityInfo quantityInfo = Length.Info;

            IEnumerable<UnitInfo> result = quantityInfo.GetUnitInfosFor(baseUnitsWithNoMatch);

            Assert.Empty(result);
        });
    }

    [Fact]
    public void GetUnitInfosFor_GivenBaseUnitsWithOneMatch_ReturnsOneMatch()
    {
        var baseUnitsWithOneMatch = new BaseUnits(LengthUnit.Foot);
        IEnumerable<UnitInfo<Length, LengthUnit>> result = Length.Info.GetUnitInfosFor(baseUnitsWithOneMatch);
        Assert.Collection(result, element1 => Assert.Equal(LengthUnit.Foot, element1.Value));
    }

    [Fact]
    public void GetUnitInfosFor_GivenBaseUnitsWithMultipleMatches_ReturnsMultipleMatches()
    {
        var baseUnits = new BaseUnits(LengthUnit.Meter);

        var quantityInfo = new QuantityInfo<Length, LengthUnit>(Length.Info.Name,
            LengthUnit.Meter, new UnitDefinition<LengthUnit>[] { new(LengthUnit.Meter, "Meters", baseUnits), new(LengthUnit.Foot, "Feet", baseUnits) },
            Length.BaseDimensions, Length.From);

        var result = quantityInfo.GetUnitInfosFor(baseUnits).ToList();

        Assert.Equal(2, result.Count);
        Assert.Contains(result, info => info.Value == LengthUnit.Meter && info.BaseUnits == baseUnits);
        Assert.Contains(result, info => info.Value == LengthUnit.Foot && info.BaseUnits == baseUnits);
    }

    // [Fact]
    // public void TryGetUnitInfo_WithEnum_ReturnsTheExpectedResult()
    // {
    //     QuantityInfo quantityInfo = HowMuch.Info;
    //     
    //     var success = quantityInfo.TryGetUnitInfo(HowMuchUnit.ATon, out UnitInfo? unitInfo);
    //     
    //     Assert.True(success);
    //     Assert.Equal(HowMuchUnit.ATon, unitInfo!.Value);
    // }
    //
    // [Fact]
    // public void TryGetUnitInfo_WithInvalidEnum_ReturnsTheExpectedResult()
    // {
    //     QuantityInfo quantityInfo = HowMuch.Info;
    //     
    //     var success = quantityInfo.TryGetUnitInfo(LengthUnit.Meter, out UnitInfo? unitInfo);
    //     
    //     Assert.False(success);
    //     Assert.Null(unitInfo);
    // }

    [Fact]
    public void TryGetUnitInfo_WithUnit_ReturnsTheExpectedResult()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;

        var success = quantityInfo.TryGetUnitInfo(MassUnit.Milligram, out UnitInfo<Mass, MassUnit>? unitInfo);

        Assert.True(success);
        Assert.Equal(MassUnit.Milligram, unitInfo!.Value);
    }

    [Fact]
    public void TryGetUnitInfo_WithInvalidUnit_ReturnsTheExpectedResult()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;

        var success = quantityInfo.TryGetUnitInfo((MassUnit)(-1), out UnitInfo<Mass, MassUnit>? unitInfo);

        Assert.False(success);
        Assert.Null(unitInfo);
    }

    [Fact]
    public void Indexer_WithValidEnum_ReturnsTheTargetUnitInfo()
    {
        QuantityInfo quantityInfo = HowMuch.Info;

        UnitInfo unitInfo = quantityInfo[HowMuchUnit.ATon];

        Assert.Equal(HowMuchUnit.ATon, unitInfo.Value);
    }

    [Fact]
    public void Indexer_WithInvalidEnum_ThrowsKeyNotFoundException()
    {
        QuantityInfo quantityInfo = HowMuch.Info;

        Assert.Throws<KeyNotFoundException>(() => quantityInfo[(HowMuchUnit)(-1)]);
    }

    [Fact]
    public void Indexer_WithValidUnit_ReturnsTheTargetUnitInfo()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;

        UnitInfo<Mass, MassUnit> unitInfo = quantityInfo[MassUnit.Milligram];

        Assert.Equal(MassUnit.Milligram, unitInfo.Value);
    }

    [Fact]
    public void Indexer_WithInvalidUnit_ThrowsKeyNotFoundException()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;

        Assert.Throws<KeyNotFoundException>(() => quantityInfo[(MassUnit)(-1)]);
    }

    [Fact]
    public void Indexer_WithValidUnitKey_ReturnsTheTargetUnitInfo()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
        var unitKey = UnitKey.ForUnit(MassUnit.Milligram);

        UnitInfo unitInfo = quantityInfo[unitKey];

        Assert.Equal(MassUnit.Milligram, unitInfo.Value);
    }

    [Fact]
    public void Indexer_WithInvalidUnitKeyType_ThrowsInvalidOperationException()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
        var unitKey = UnitKey.ForUnit(LengthUnit.Meter);

        Assert.Throws<InvalidOperationException>(() => quantityInfo[unitKey]);
    }

    [Fact]
    public void Indexer_WithUnknownUnitKeyValue_ThrowsInvalidOperationException()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
        var unitKey = new UnitKey(typeof(MassUnit), -1);

        Assert.Throws<KeyNotFoundException>(() => quantityInfo[unitKey]);
    }

    [Fact]
    public void UntypedIndexer_WithUnknownUnitKeyValue_ThrowsInvalidOperationException()
    {
        QuantityInfo quantityInfo = Mass.Info;
        var unitKey = new UnitKey(typeof(MassUnit), -1);

        Assert.Throws<KeyNotFoundException>(() => quantityInfo[unitKey]);
    }

    [Theory]
    [InlineData(1, MassUnit.Kilogram)]
    [InlineData(2, MassUnit.Milligram)]
    public void From_ValueAndUnit_ReturnsTheExpectedQuantity(double value, MassUnit unit)
    {
        Assert.Multiple(() =>
        {
            QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;

            Mass quantity = quantityInfo.From(value, unit);

            Assert.Equal(value, quantity.Value);
            Assert.Equal(unit, quantity.Unit);
        }, () =>
        {
            QuantityInfo<MassUnit> quantityInfo = Mass.Info;

            IQuantity<MassUnit> quantity = quantityInfo.From(value, unit);

            Assert.Equal(value, quantity.Value);
            Assert.Equal(unit, quantity.Unit);
        }, () =>
        {
            QuantityInfo quantityInfo = Mass.Info;

            IQuantity quantity = quantityInfo.From(value, unit);

            Assert.Equal(value, quantity.Value);
            Assert.Equal(unit, quantity.Unit);
        });
    }

    [Theory]
    [InlineData(1, MassUnit.Kilogram)]
    [InlineData(2, MassUnit.Milligram)]
    public void From_ValueAndUnitKey_WithSameUnitType_ReturnsTheExpectedQuantity(double value, MassUnit unit)
    {
        IQuantityInstanceInfo<Mass> quantityInfo = Mass.Info;

        Mass quantity = quantityInfo.Create(value, UnitKey.ForUnit(unit));

        Assert.Equal(value, quantity.Value);
        Assert.Equal(unit, quantity.Unit);
    }

    [Theory]
    [InlineData(1, MassUnit.Kilogram)]
    [InlineData(2, MassUnit.Milligram)]
    public void From_ValueAnEnum_WithSameUnitType_ReturnsTheExpectedQuantity(double value, Enum unit)
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;

        IQuantity quantity = quantityInfo.From(value, unit);

        Assert.Equal(value, quantity.Value);
        Assert.Equal(unit, quantity.Unit);
    }

    [Fact]
    public void From_ValueAndUnitKey_WIthDifferentUnitType_ThrowsArgumentException()
    {
        IQuantityInstanceInfo<Mass> quantityInfo = Mass.Info;
        var unitKey = UnitKey.ForUnit(LengthUnit.Meter);

        Assert.Throws<InvalidOperationException>(() => quantityInfo.Create(1, unitKey));
    }

    [Fact]
    public void From_ValueAndEnum_WIthDifferentUnitType_ThrowsInvalidOperationException()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;

        Assert.Throws<InvalidOperationException>(() => quantityInfo.From(1, LengthUnit.Meter));
    }

    [Fact]
    public void ToString_ReturnsTheQuantityName()
    {
        QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;

        Assert.Equal(quantityInfo.Name, quantityInfo.ToString());
    }

#if NET

    [Fact]
    public void Constructor_WithoutDelegate_UsesTheDefaultQuantityFrom()
    {
        UnitDefinition<HowMuchUnit>[] expectedUnitInfos =
        [
            new(HowMuchUnit.Some, "Some", BaseUnits.Undefined)
        ];
        const string quantityName = "How Much?";
        const HowMuchUnit expectedBaseUnit = HowMuchUnit.Some;
        var expectedZero = new HowMuch(0, HowMuchUnit.Some);
        BaseDimensions expectedBaseDimensions = BaseDimensions.Dimensionless;
        var abbreviations = new ResourceManager("UnitsNet.GeneratedCode.Resources.Length", typeof(Length).Assembly);

        var quantityInfo = new QuantityInfo<HowMuch, HowMuchUnit>(quantityName, expectedBaseUnit, expectedUnitInfos, expectedBaseDimensions, abbreviations);

        Assert.Equal(quantityName, quantityInfo.Name);
        Assert.Equal(expectedZero, quantityInfo.Zero);
        Assert.Equal(expectedBaseUnit, quantityInfo.BaseUnitInfo.Value);
        Assert.Single(quantityInfo.UnitInfos, firstUnitInfo =>
            expectedBaseUnit == firstUnitInfo.Value &&
            expectedUnitInfos[0].Name == firstUnitInfo.Name &&
            expectedUnitInfos[0].PluralName == firstUnitInfo.PluralName &&
            expectedUnitInfos[0].BaseUnits == firstUnitInfo.BaseUnits
        );
        Assert.Equal(expectedBaseDimensions, quantityInfo.BaseDimensions);
        Assert.Equal(abbreviations, quantityInfo.UnitAbbreviations);
    }

    [Fact]
    public void Constructor_WithoutNameOrDelegate_UsesTheDefaultQuantityNameAndFrom()
    {
        UnitDefinition<HowMuchUnit>[] expectedUnitInfos =
        [
            new(HowMuchUnit.Some, "Some", BaseUnits.Undefined)
        ];
        const HowMuchUnit expectedBaseUnit = HowMuchUnit.Some;
        var expectedZero = new HowMuch(0, HowMuchUnit.Some);
        BaseDimensions expectedBaseDimensions = BaseDimensions.Dimensionless;
        var abbreviations = new ResourceManager("UnitsNet.GeneratedCode.Resources.Length", typeof(Length).Assembly);

        var quantityInfo = new QuantityInfo<HowMuch, HowMuchUnit>(expectedBaseUnit, expectedUnitInfos, expectedBaseDimensions, abbreviations);

        Assert.Equal(expectedZero, quantityInfo.Zero);
        Assert.Equal(nameof(HowMuch), quantityInfo.Name);
        Assert.Equal(expectedBaseUnit, quantityInfo.BaseUnitInfo.Value);
        Assert.Single(quantityInfo.UnitInfos, firstUnitInfo =>
            expectedBaseUnit == firstUnitInfo.Value &&
            expectedUnitInfos[0].Name == firstUnitInfo.Name &&
            expectedUnitInfos[0].PluralName == firstUnitInfo.PluralName &&
            expectedUnitInfos[0].BaseUnits == firstUnitInfo.BaseUnits
        );
        Assert.Equal(expectedBaseDimensions, quantityInfo.BaseDimensions);
        Assert.Equal(abbreviations, quantityInfo.UnitAbbreviations);
    }

#endif
}
