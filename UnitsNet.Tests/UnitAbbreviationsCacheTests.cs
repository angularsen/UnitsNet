// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Linq;
using UnitsNet.Tests.CustomQuantities;
using UnitsNet.Tests.Helpers;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    // Disable parallelization due to manipulating global state, like UnitsNetSetup.Default.UnitAbbreviations.MapUnitToDefaultAbbreviation().
    [Collection(nameof(DisableParallelizationCollectionFixture))]
    public class UnitAbbreviationsCacheTests
    {
        private static readonly CultureInfo AmericanCulture = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo NorwegianCulture = CultureInfo.GetCultureInfo("nb-NO");

        [Fact]
        public void EmptyConstructor_ReturnsAnAbbreviationCacheWithDefaultQuantityInfoLookup()
        {
            var unitAbbreviationCache = new UnitAbbreviationsCache();

            Assert.Equal(UnitsNetSetup.Default.Quantities, unitAbbreviationCache.Quantities);
            Assert.Equal("g", unitAbbreviationCache.GetUnitAbbreviations(MassUnit.Gram, AmericanCulture)[0]);
            Assert.Throws<UnitNotFoundException>(() => unitAbbreviationCache.GetUnitAbbreviations(HowMuchUnit.Some));
        }
        
        [Fact]
        public void Constructor_WithQuantities_ReturnsAnAbbreviationCacheWithNewQuantityInfoLookup()
        {
            var unitAbbreviationCache = new UnitAbbreviationsCache([Mass.Info, HowMuch.Info]);

            Assert.NotEqual(UnitsNetSetup.Default.Quantities, unitAbbreviationCache.Quantities);
            Assert.Equal("g", unitAbbreviationCache.GetUnitAbbreviations(MassUnit.Gram, AmericanCulture)[0]);
            Assert.Empty(unitAbbreviationCache.GetUnitAbbreviations(HowMuchUnit.Some, AmericanCulture));
            Assert.Throws<UnitNotFoundException>(() => unitAbbreviationCache.GetUnitAbbreviations(LengthUnit.Meter));
        }
        
        [Fact]
        public void CreateDefault_ReturnsAnAbbreviationCacheWithDefaultQuantityInfoLookup()
        {
            var unitAbbreviationCache = UnitAbbreviationsCache.CreateDefault();

            Assert.Equal(UnitsNetSetup.Default.Quantities, unitAbbreviationCache.Quantities);
            Assert.Equal("g", unitAbbreviationCache.GetUnitAbbreviations(MassUnit.Gram, AmericanCulture)[0]);
            Assert.Throws<UnitNotFoundException>(() => unitAbbreviationCache.GetUnitAbbreviations(HowMuchUnit.Some));
        }
        
        [Fact]
        public void CreateDefault_WithConfigureAction_ReturnsAnAbbreviationCacheWithNewQuantityInfoLookup()
        {
            var unitAbbreviationCache = UnitAbbreviationsCache.CreateDefault(configuration => configuration.WithAdditionalQuantities([HowMuch.Info]));

            Assert.NotEqual(UnitsNetSetup.Default.Quantities, unitAbbreviationCache.Quantities);
            Assert.Equal("g", unitAbbreviationCache.GetUnitAbbreviations(MassUnit.Gram, AmericanCulture)[0]);
            Assert.Empty(unitAbbreviationCache.GetUnitAbbreviations(HowMuchUnit.Some, AmericanCulture));
        }
        
        [Fact]
        public void Create_WithQuantitiesAndConfigureAction_ReturnsAnAbbreviationCacheWithNewQuantityInfoLookup()
        {
            var unitAbbreviationCache = UnitAbbreviationsCache.Create([Mass.Info, HowMuch.Info],
                configuration =>
                    configuration.Configure(() => Mass.MassInfo.CreateDefault(mappings => mappings.SelectUnits(MassUnit.Kilogram, MassUnit.Gram))));

            Assert.NotEqual(UnitsNetSetup.Default.Quantities, unitAbbreviationCache.Quantities);
            Assert.Equal("g", unitAbbreviationCache.GetUnitAbbreviations(MassUnit.Gram, AmericanCulture)[0]);
            Assert.Empty(unitAbbreviationCache.GetUnitAbbreviations(HowMuchUnit.Some, AmericanCulture));
            Assert.Throws<UnitNotFoundException>(() => unitAbbreviationCache.GetUnitAbbreviations(MassUnit.EarthMass));
        }

        [Fact]
        public void UnitAbbreviationsCache_Default_ReturnsInstanceFromUnitsNetSetup()
        {
            Assert.Equal(UnitsNetSetup.Default.UnitAbbreviations, UnitAbbreviationsCache.Default);
        }

        [Fact]
        public void GetUnitAbbreviationsThrowsUnitNotFoundExceptionIfNoneExist()
        {
            Assert.Multiple(checks: [
                () => Assert.Throws<UnitNotFoundException>(() => new UnitAbbreviationsCache().GetUnitAbbreviations(HowMuchUnit.AShitTon)),
                () => Assert.Throws<UnitNotFoundException>(() => new UnitAbbreviationsCache().GetUnitAbbreviations(typeof(HowMuchUnit), (int)HowMuchUnit.AShitTon))
            ]);
        }

        [Fact]
        public void GetUnitAbbreviationReturnsTheExpectedAbbreviationWhenConstructedWithTheSpecificQuantityInfo()
        {
            Assert.Multiple(checks:
            [
                () => { Assert.Equal("g", new UnitAbbreviationsCache([Mass.Info]).GetUnitAbbreviations(MassUnit.Gram, AmericanCulture)[0]); },
                () => { Assert.Equal("g", new UnitAbbreviationsCache([Mass.Info]).GetUnitAbbreviations(typeof(MassUnit), (int)MassUnit.Gram, AmericanCulture)[0]); }
            ]);
        }

        [Fact]
        public void GetUnitAbbreviationsReturnsTheExpectedAbbreviationWhenConstructedWithTheSpecificQuantityInfo()
        {
            var unitAbbreviationCache = new UnitAbbreviationsCache([Mass.Info]);
            Assert.Equal("g", unitAbbreviationCache.GetUnitAbbreviations(MassUnit.Gram, AmericanCulture)[0]);
        }

        [Fact]
        public void GetDefaultAbbreviationReturnsTheExpectedAbbreviationWhenConstructedWithTheSpecificQuantityInfo()
        {
            Assert.Multiple(checks:
            [
                () => { Assert.Equal("g", new UnitAbbreviationsCache([Mass.Info]).GetDefaultAbbreviation(MassUnit.Gram, AmericanCulture)); },
                () => { Assert.Equal("g", new UnitAbbreviationsCache([Mass.Info]).GetDefaultAbbreviation(typeof(MassUnit), (int)MassUnit.Gram, AmericanCulture)); }
            ]);
        }

        [Fact]
        public void GetDefaultAbbreviationFallsBackToUsEnglishCulture()
        {
            // CurrentCulture affects number formatting, such as comma or dot as decimal separator.
            // CurrentCulture also affects localization of unit abbreviations.
            // Zulu (South Africa)
            var zuluCulture = CultureInfo.GetCultureInfo("zu-ZA");

            var abbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            abbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.AShitTon, AmericanCulture, "US english abbreviation for Unit1");

            // Act
            string abbreviation = abbreviationsCache.GetDefaultAbbreviation(HowMuchUnit.AShitTon, zuluCulture);

            // Assert
            Assert.Equal("US english abbreviation for Unit1", abbreviation);
        }

        [Fact]
        public void GetDefaultAbbreviationFallsBackToInvariantCulture()
        {
            // CurrentCulture affects number formatting, such as comma or dot as decimal separator.
            // CurrentCulture also affects localization of unit abbreviations.
            // Zulu (South Africa)
            var zuluCulture = CultureInfo.GetCultureInfo("zu-ZA");

            var abbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            abbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.AShitTon, CultureInfo.InvariantCulture, "Invariant abbreviation for Unit1");

            // Act
            string abbreviation = abbreviationsCache.GetDefaultAbbreviation(HowMuchUnit.AShitTon, zuluCulture);

            // Assert
            Assert.Equal("Invariant abbreviation for Unit1", abbreviation);
        }
        
        [Fact]
        public void GetDefaultAbbreviation_WithNullUnitType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => UnitAbbreviationsCache.Default.GetDefaultAbbreviation(null!, 1));
        }

        [Fact]
        public void GetDefaultAbbreviationThrowsUnitNotFoundExceptionIfNoneExist()
        {
            Assert.Multiple(checks: [
                () => Assert.Throws<UnitNotFoundException>(() => new UnitAbbreviationsCache().GetDefaultAbbreviation(HowMuchUnit.AShitTon)),
                () => Assert.Throws<UnitNotFoundException>(() => new UnitAbbreviationsCache().GetDefaultAbbreviation(typeof(HowMuchUnit), (int)HowMuchUnit.AShitTon))
            ]);
        }

        [Fact]
        public void GetDefaultAbbreviation_ForUnitWithoutAbbreviations_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new UnitAbbreviationsCache([HowMuch.Info]).GetDefaultAbbreviation(HowMuchUnit.AShitTon));
        }

        [Fact]
        public void GetAllUnitAbbreviationsForQuantity_WithQuantityWithoutAbbreviations_ReturnsEmpty()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            Assert.Empty(unitAbbreviationsCache.GetAllUnitAbbreviationsForQuantity(typeof(HowMuchUnit)));
        }

        [Fact]
        public void GetAllUnitAbbreviationsForQuantity_WithNullUnitType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => UnitAbbreviationsCache.Default.GetAllUnitAbbreviationsForQuantity(null!));
        }

        [Fact]
        public void GetAllUnitAbbreviationsForQuantity_WithInvalidUnitType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => UnitAbbreviationsCache.Default.GetAllUnitAbbreviationsForQuantity(typeof(DateTime)));
        }

        [Fact]
        public void GetAllUnitAbbreviationsForQuantity_WithUnknownUnitType_ThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => UnitAbbreviationsCache.Default.GetAllUnitAbbreviationsForQuantity(typeof(HowMuchUnit)));
        }

        [Fact]
        public void MapUnitToAbbreviation_DoesNotAffectOtherCacheInstances()
        {
            var culture = AmericanCulture;
            var unit = AreaUnit.SquareMeter;

            var cache1 = UnitAbbreviationsCache.CreateDefault();
            cache1.MapUnitToAbbreviation(unit, culture, "m^2");

            var cache2 = UnitAbbreviationsCache.CreateDefault();
            cache2.MapUnitToAbbreviation(unit, culture, "m2");

            Assert.Equal(new[] { "m²", "m^2" }, cache1.GetUnitAbbreviations(unit, culture));
            Assert.Equal(new[] { "m²", "m2" }, cache2.GetUnitAbbreviations(unit, culture));
            Assert.Equal("m²", cache1.GetDefaultAbbreviation(unit, culture));
            Assert.Equal("m²", cache2.GetDefaultAbbreviation(unit, culture));
        }

        [Fact]
        public void MapUnitToAbbreviation_AddCustomUnit_DoesNotOverrideDefaultAbbreviationForAlreadyMappedUnits()
        {
            var cache = UnitAbbreviationsCache.CreateDefault();
            cache.MapUnitToAbbreviation(AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m²", cache.GetDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_GivenUnitAndNoCulture_SetsDefaultAbbreviationForUnitForCurrentCulture()
        {
            using var cultureScope = new CultureScope(NorwegianCulture);
            var cache = new UnitAbbreviationsCache([Mass.Info]);

            cache.MapUnitToDefaultAbbreviation(MassUnit.Gram, "zz");

            Assert.Equal("zz", cache.GetDefaultAbbreviation(MassUnit.Gram));
            Assert.Equal("g", cache.GetDefaultAbbreviation(MassUnit.Gram, AmericanCulture));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_GivenUnitAndCulture_SetsDefaultAbbreviationForUnitAndCulture()
        {
            var cache = new UnitAbbreviationsCache([Area.Info]);
            cache.MapUnitToDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m^2", cache.GetDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_GivenUnitTypeValueAndCulture_SetsDefaultAbbreviationForUnitAndCulture()
        {
            var cache = new UnitAbbreviationsCache([Area.Info]);
            cache.MapUnitToDefaultAbbreviation(typeof(AreaUnit), (int)AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m^2", cache.GetDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_GivenCustomAbbreviation_SetsAbbreviationUsedByQuantityToString()
        {
            // Use a distinct culture here so that we don't mess up other tests that may rely on the default cache.
            var newZealandCulture = CultureInfo.GetCultureInfo("en-NZ");
            UnitsNetSetup.Default.UnitAbbreviations.MapUnitToDefaultAbbreviation(AreaUnit.SquareMeter, newZealandCulture, "m^2");

            Assert.Equal("1 m^2", Area.FromSquareMeters(1).ToString(newZealandCulture));
        }

        [Fact]
        public void MapUnitToAbbreviation_GivenUnitTypeAndValue_AddsTheAbbreviationForUnitForCurrentCulture()
        {
            using var cultureScope = new CultureScope(NorwegianCulture);
            var cache = new UnitAbbreviationsCache([Mass.Info]);

            cache.MapUnitToAbbreviation(typeof(MassUnit), (int)MassUnit.Gram, null, "zz");

            Assert.Equal("zz", cache.GetUnitAbbreviations(MassUnit.Gram).Last());
            Assert.Equal("g", cache.GetDefaultAbbreviation(MassUnit.Gram, AmericanCulture));
            Assert.DoesNotContain("zz", cache.GetUnitAbbreviations(MassUnit.Gram, AmericanCulture));
        }

        [Fact]
        public void MapUnitToAbbreviation_DoesNotInsertDuplicates()
        {
            var cache = new UnitAbbreviationsCache([HowMuch.Info]);

            cache.MapUnitToAbbreviation(HowMuchUnit.Some, "sm");
            cache.MapUnitToAbbreviation(HowMuchUnit.Some, "sm");
            cache.MapUnitToAbbreviation(HowMuchUnit.Some, "sm");

            Assert.Equal("sm", cache.GetDefaultAbbreviation(HowMuchUnit.Some));
            Assert.Equal(new[] { "sm" }, cache.GetUnitAbbreviations(HowMuchUnit.Some));
            Assert.Equal(new[] { "sm" }, cache.GetAllUnitAbbreviationsForQuantity(typeof(HowMuchUnit)));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_Twice_SetsNewDefaultAndKeepsOrderOfExistingAbbreviations()
        {
            var cache = new UnitAbbreviationsCache([HowMuch.Info]);

            cache.MapUnitToAbbreviation(HowMuchUnit.Some, "sm");
            cache.MapUnitToDefaultAbbreviation(HowMuchUnit.Some, "1st default");
            cache.MapUnitToDefaultAbbreviation(HowMuchUnit.Some, "2nd default");

            Assert.Equal("2nd default", cache.GetDefaultAbbreviation(HowMuchUnit.Some));
            Assert.Equal(new[] { "2nd default", "1st default", "sm" }, cache.GetUnitAbbreviations(HowMuchUnit.Some));
        }

        /// <summary>
        /// Test that lookup works when specifying unit enum value both as cast to <see cref="Enum"/> and as specific enum value type.
        /// We have had subtle bugs when <see cref="Enum"/> is passed to generic methods with constraint TUnitEnum : Enum,
        /// which the Enum type satisfies, but trying to use typeof(TUnitEnum) no longer represent the actual enum type so unitEnumValue.GetType() should be used.
        /// </summary>
        [Fact]
        public void MapAndLookup_WithSpecificEnumType()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToDefaultAbbreviation(HowMuchUnit.Some, "sm");
            Assert.Equal("sm", unitAbbreviationsCache.GetDefaultAbbreviation(HowMuchUnit.Some));
        }

        /// <inheritdoc cref="MapAndLookup_WithSpecificEnumType"/>
        [Fact]
        public void MapAndLookup_WithEnumType()
        {
            Enum valueAsEnumType = HowMuchUnit.Some;
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToDefaultAbbreviation(valueAsEnumType, "sm");
            Assert.Equal("sm", unitAbbreviationsCache.GetDefaultAbbreviation(valueAsEnumType));
        }

        /// <inheritdoc cref="MapAndLookup_WithSpecificEnumType"/>
        [Fact]
        public void MapAndLookup_MapWithSpecificEnumType_LookupWithEnumType()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToDefaultAbbreviation(HowMuchUnit.Some, "sm");
            Assert.Equal("sm", unitAbbreviationsCache.GetDefaultAbbreviation((Enum)HowMuchUnit.Some));
        }
        
        [Fact]
        public void MapUnitToAbbreviation_WithUnknownUnit_ThrowsUnitNotFoundException()
        {
            var unitAbbreviationCache = new UnitAbbreviationsCache([Mass.Info]);
            Assert.Throws<UnitNotFoundException>(() => unitAbbreviationCache.MapUnitToAbbreviation(HowMuchUnit.Some, "nothing"));
            Assert.Throws<UnitNotFoundException>(() => unitAbbreviationCache.MapUnitToAbbreviation(LengthUnit.Centimeter, "nothing"));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_WithUnknownUnit_ThrowsUnitNotFoundException()
        {
            var unitAbbreviationCache = new UnitAbbreviationsCache([Mass.Info]);
            Assert.Throws<UnitNotFoundException>(() => unitAbbreviationCache.MapUnitToDefaultAbbreviation(HowMuchUnit.Some, "nothing"));
            Assert.Throws<UnitNotFoundException>(() => unitAbbreviationCache.MapUnitToDefaultAbbreviation(LengthUnit.AstronomicalUnit, "nothing"));
        }
    }
}
