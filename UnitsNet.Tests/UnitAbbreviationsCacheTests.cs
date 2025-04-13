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
        public void UnitAbbreviationsCacheDefaultReturnsUnitsNetSetupDefaultUnitAbbreviations()
        {
            Assert.Equal(UnitsNetSetup.Default.UnitAbbreviations, UnitAbbreviationsCache.Default);
        }

        [Fact]
        public void GetUnitAbbreviationsThrowsUnitNotFoundExceptionIfNoneExist()
        {
            Assert.Multiple(checks: [
                () => Assert.Throws<UnitNotFoundException>(() => new UnitAbbreviationsCache().GetUnitAbbreviations(MassUnit.Gram)),
                () => Assert.Throws<UnitNotFoundException>(() => new UnitAbbreviationsCache().GetUnitAbbreviations(typeof(MassUnit), (int)MassUnit.Gram))
            ]);
        }

        [Fact]
        public void GetUnitAbbreviationsReturnsTheExpectedAbbreviationWhenConstructedWithTheSpecificQuantityInfo()
        {
            Assert.Multiple(checks:
            [
                () => { Assert.Equal("g", new UnitAbbreviationsCache([Mass.Info]).GetUnitAbbreviations(MassUnit.Gram, AmericanCulture)[0]); },
                () => { Assert.Equal("g", new UnitAbbreviationsCache([Mass.Info]).GetUnitAbbreviations(typeof(MassUnit), (int)MassUnit.Gram, AmericanCulture)[0]); }
            ]);
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

            var abbreviationsCache = new UnitAbbreviationsCache();
            abbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.AShitTon, AmericanCulture, "US english abbreviation for Unit1");

            // Act
            string abbreviation = abbreviationsCache.GetDefaultAbbreviation(HowMuchUnit.AShitTon, zuluCulture);

            // Assert
            Assert.Equal("US english abbreviation for Unit1", abbreviation);
        }

        [Fact]
        public void GetDefaultAbbreviationThrowsUnitNotFoundExceptionIfNoneExist()
        {
            Assert.Multiple(checks: [
                () => Assert.Throws<UnitNotFoundException>(() => new UnitAbbreviationsCache().GetDefaultAbbreviation(MassUnit.Gram)),
                () => Assert.Throws<UnitNotFoundException>(() => new UnitAbbreviationsCache().GetDefaultAbbreviation(typeof(MassUnit), (int)MassUnit.Gram))
            ]);
        }

        [Fact]
        public void GetAbbreviationsThrowsArgumentNullExceptionWhenGivenANullUnitInfo()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitAbbreviationsCache().GetAbbreviations(null!));
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
        public void MapUnitToDefaultAbbreviation_GivenUnitAndCulture_SetsDefaultAbbreviationForUnitAndCulture()
        {
            var cache = new UnitAbbreviationsCache();
            cache.MapUnitToDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m^2", cache.GetDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture));
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
        public void MapUnitToDefaultAbbreviation_GivenUnitTypeAndValue_SetsDefaultAbbreviationForUnitForCurrentCulture()
        {
            using var cultureScope = new CultureScope(NorwegianCulture);
            var cache = new UnitAbbreviationsCache([Mass.Info]);

            cache.MapUnitToDefaultAbbreviation(typeof(MassUnit), (int)MassUnit.Gram, null, "zz");

            Assert.Equal("zz", cache.GetDefaultAbbreviation(MassUnit.Gram));
            Assert.Equal("g", cache.GetDefaultAbbreviation(MassUnit.Gram, AmericanCulture));
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
            var cache = new UnitAbbreviationsCache();

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
            var cache = new UnitAbbreviationsCache();

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
            UnitsNetSetup.Default.UnitAbbreviations.MapUnitToDefaultAbbreviation(HowMuchUnit.Some, "sm");
            Assert.Equal("sm", UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(HowMuchUnit.Some));
        }
    }
}
