// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Runtime;
using UnitsNet.Tests.CustomQuantities;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class UnitParserTests
    {
        [Fact]
        public void Constructor_WithQuantitiesCreatesNewAbbreviationsCacheAndNewQuantityInfoLookup()
        {
            var unitParser = new UnitParser([Mass.Info]);
            Assert.NotNull(unitParser.Abbreviations);
            Assert.NotEqual(UnitAbbreviationsCache.Default, unitParser.Abbreviations);
            Assert.NotEqual(UnitsNetSetup.Default.QuantityInfoLookup, unitParser.Quantities);
        }
        
        [Fact]
        public void Constructor_WithQuantityInfoLookupCreatesNewAbbreviationsCache()
        {
            var quantities = new QuantityInfoLookup([Mass.Info]);
            var unitParser = new UnitParser(quantities);
            Assert.NotNull(unitParser.Abbreviations);
            Assert.NotEqual(UnitAbbreviationsCache.Default, unitParser.Abbreviations);
            Assert.Equal(quantities, unitParser.Quantities);
        }
        
        [Fact]
        public void CreateDefault_CreatesNewAbbreviationsCacheWithDefaultQuantities()
        {
            var unitParser = UnitParser.CreateDefault();
            Assert.NotNull(unitParser.Abbreviations);
            Assert.NotEqual(UnitAbbreviationsCache.Default, unitParser.Abbreviations);
            Assert.Equal(UnitsNetSetup.Default.QuantityInfoLookup, unitParser.Quantities);
        }
        
        [Theory]
        [InlineData("m^^2", AreaUnit.SquareMeter)]
        [InlineData("cm^^2", AreaUnit.SquareCentimeter)]
        public void Parse_ReturnsUnitMappedByCustomAbbreviation(string customAbbreviation, AreaUnit expected)
        {
            var abbrevCache = new UnitAbbreviationsCache([Area.Info]);
            abbrevCache.MapUnitToAbbreviation(expected, customAbbreviation);
            var parser = new UnitParser(abbrevCache);

            var actual = parser.Parse<AreaUnit>(customAbbreviation);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AbbreviationCaseInsensitive_Lowercase_years()
        {
            var abbreviation = "years";
            var expected = DurationUnit.Year365;
            var parser = UnitsNetSetup.Default.UnitParser;

            var actual = parser.Parse<DurationUnit>(abbreviation);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AbbreviationCaseInsensitive_Uppercase_Years()
        {
            var abbreviation = "Years";
            var expected = DurationUnit.Year365;
            var parser = UnitsNetSetup.Default.UnitParser;

            var actual = parser.Parse<DurationUnit>(abbreviation);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_GivenAbbreviationsThatAreAmbiguousWhenLowerCase_ReturnsCorrectUnit()
        {
            Assert.Equal(PressureUnit.Megabar, Pressure.ParseUnit("Mbar"));
            Assert.Equal(PressureUnit.Millibar, Pressure.ParseUnit("mbar"));
        }

        [Fact]
        public void Parse_NullAbbreviation_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => UnitsNetSetup.Default.UnitParser.Parse<LengthUnit>(null!));
            Assert.Throws<ArgumentNullException>(() => UnitsNetSetup.Default.UnitParser.Parse(null!, Length.Info.UnitInfos));
            Assert.Throws<ArgumentNullException>(() => UnitsNetSetup.Default.UnitParser.Parse(null!, typeof(LengthUnit)));
        }

        [Fact]
        public void Parse_UnknownAbbreviationThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => UnitsNetSetup.Default.UnitParser.Parse<AreaUnit>("nonexistingunit"));
        }

        [Theory]
        [InlineData("m", typeof(LengthUnit), LengthUnit.Meter)]
        [InlineData("m^1", typeof(LengthUnit), LengthUnit.Meter)]
        [InlineData("m²", typeof(AreaUnit), AreaUnit.SquareMeter)]
        [InlineData("m^2", typeof(AreaUnit), AreaUnit.SquareMeter)]
        [InlineData("m³", typeof(VolumeUnit), VolumeUnit.CubicMeter)]
        [InlineData("m^3", typeof(VolumeUnit), VolumeUnit.CubicMeter)]
        [InlineData("m⁴", typeof(AreaMomentOfInertiaUnit), AreaMomentOfInertiaUnit.MeterToTheFourth)]
        [InlineData("m^4", typeof(AreaMomentOfInertiaUnit), AreaMomentOfInertiaUnit.MeterToTheFourth)]
        [InlineData("K⁻¹", typeof(CoefficientOfThermalExpansionUnit), CoefficientOfThermalExpansionUnit.PerKelvin)]
        [InlineData("K^-1", typeof(CoefficientOfThermalExpansionUnit), CoefficientOfThermalExpansionUnit.PerKelvin)]
        [InlineData("kg·s⁻¹·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg·s^-1·m^-2", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        public void Parse_CanParseUnitsWithPowers(string unitAbbreviation, Type unitType, Enum resultUnitType)
        {
            Assert.Equal(resultUnitType, UnitsNetSetup.Default.UnitParser.Parse(unitAbbreviation, unitType));
        }

        [Theory]
        [InlineData("kg·s⁻¹·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg*s⁻¹*m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg·s⁻¹*m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        public void Parse_CanParseMultiplySigns(string unitAbbreviation, Type unitType, Enum resultUnitType)
        {
            Assert.Equal(resultUnitType, UnitsNetSetup.Default.UnitParser.Parse(unitAbbreviation, unitType));
        }

        [Theory]
        [InlineData(" kg·s⁻¹·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg·s⁻¹·m⁻² ", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("k g · s ⁻ ¹ · m ⁻ ² ", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("   k   g   ·   s   ⁻   ¹   ·   m   ⁻   ²   ", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        public void Parse_CanParseWithWhitespacesInUnit(string unitAbbreviation, Type unitType, Enum resultUnitType)
        {
            Assert.Equal(resultUnitType, UnitsNetSetup.Default.UnitParser.Parse(unitAbbreviation, unitType));
        }

        [Fact]
        public void Parse_AmbiguousUnitsThrowsException()
        {
            // Act 1
            var exception1 = Assert.Throws<AmbiguousUnitParseException>(() => UnitsNetSetup.Default.UnitParser.Parse<LengthUnit>("pt"));

            // Act 2
            var exception2 = Assert.Throws<AmbiguousUnitParseException>(() => Length.Parse("1 pt", CultureInfo.InvariantCulture));

            // Assert
            Assert.Equal("""Cannot parse "pt" since it matches multiple units: DtpPoint ("pt"), PrinterPoint ("pt").""", exception1.Message);
            Assert.Equal("""Cannot parse "pt" since it matches multiple units: DtpPoint ("pt"), PrinterPoint ("pt").""", exception2.Message);
        }

        [Theory]
        [InlineData("ng", "en-US", MassUnit.Nanogram)]
        [InlineData("нг", "ru-RU", MassUnit.Nanogram)]
        [InlineData("g", "en-US", MassUnit.Gram)]
        [InlineData("г", "ru-RU", MassUnit.Gram)]
        [InlineData("kg", "en-US", MassUnit.Kilogram)]
        [InlineData("кг", "ru-RU", MassUnit.Kilogram)]
        [InlineData("kg", "ru-RU", MassUnit.Kilogram)] // should work with the "FallbackCulture"
        public void ParseMassUnit_GivenCulture(string str, string cultureName, Enum expectedUnit)
        {
            var formatProvider = CultureInfo.GetCultureInfo(cultureName);
            UnitParser unitParser = UnitsNetSetup.Default.UnitParser;
            
            Assert.Equal(expectedUnit, unitParser.Parse<MassUnit>(str, formatProvider));
        }
        
        [Fact]
        public void Parse_MappedCustomUnit()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.Some, "fooh");
            var unitParser = new UnitParser(unitAbbreviationsCache);

            var parsedUnit = unitParser.Parse<HowMuchUnit>("fooh");

            Assert.Equal(HowMuchUnit.Some, parsedUnit);
        }

        [Fact]
        public void Parse_LengthUnit_MM_ThrowsExceptionDescribingTheAmbiguity()
        {
            var ex = Assert.Throws<AmbiguousUnitParseException>(() => UnitsNetSetup.Default.UnitParser.Parse<LengthUnit>("MM"));
            Assert.Equal("""Cannot parse "MM" since it matches multiple units: Megameter ("Mm"), Millimeter ("mm").""", ex.Message);
        }
        
        [Fact]
        public void TryParse_WithNullAbbreviation_ReturnsFalse()
        {
            UnitParser unitParser = UnitsNetSetup.Default.UnitParser;
            Assert.Multiple(() =>
            {
                var success = unitParser.TryParse(null, out LengthUnit unit);
                Assert.False(success);
            }, () =>
            {
                var success = unitParser.TryParse(null, typeof(LengthUnit), out Enum? _);
                Assert.False(success);
            }, () =>
            {
                var success = unitParser.TryParse(null, [], null, out UnitInfo<Length, LengthUnit>? _);
                Assert.False(success);
            });
        }

        [Theory]
        [InlineData("")] 
        [InlineData("z^2")]
        [InlineData("nonexistingunit")]
        public void TryParse_UnknownAbbreviation_ReturnsFalse(string unknownAreaAbbreviation)
        {
            Assert.False(UnitsNetSetup.Default.UnitParser.TryParse(unknownAreaAbbreviation, out AreaUnit _));
        }

        [Fact]
        public void TryParse_WithAmbiguousUnits_ReturnsFalse()
        {
            UnitParser unitParser = UnitsNetSetup.Default.UnitParser;
            Assert.False(unitParser.TryParse("pt", CultureInfo.InvariantCulture, out LengthUnit _));
            Assert.False(unitParser.TryParse("pt", Length.Info.UnitInfos, CultureInfo.InvariantCulture, out UnitInfo<Length, LengthUnit>? _));
        }

        [Theory]
        [InlineData("ng", "en-US", MassUnit.Nanogram)]
        [InlineData("нг", "ru-RU", MassUnit.Nanogram)]
        [InlineData("g", "en-US", MassUnit.Gram)]
        [InlineData("г", "ru-RU", MassUnit.Gram)]
        [InlineData("kg", "en-US", MassUnit.Kilogram)]
        [InlineData("кг", "ru-RU", MassUnit.Kilogram)]
        [InlineData("kg", "ru-RU", MassUnit.Kilogram)] // should work with the "FallbackCulture"
        public void TryParseMassUnit_GivenCulture(string str, string cultureName, Enum expectedUnit)
        {
            var formatProvider = CultureInfo.GetCultureInfo(cultureName);
            UnitParser unitParser = UnitsNetSetup.Default.UnitParser;

            var success = unitParser.TryParse(str, formatProvider, out MassUnit unitParsed);

            Assert.True(success);
            Assert.Equal(expectedUnit, unitParsed);
        }

        [Fact]
        public void TryGetUnitFromAbbreviation_WithLocalizedUnit_MatchingCulture_ReturnsTrue()
        {
            var formatProvider = CultureInfo.GetCultureInfo("ru-RU");
            UnitParser unitParser = UnitsNetSetup.Default.UnitParser;

            var success = unitParser.TryGetUnitFromAbbreviation("кг", formatProvider, out UnitInfo? unitInfo);

            Assert.True(success);
            Assert.Equal(Mass.Info[MassUnit.Kilogram], unitInfo);
        }

        [Fact]
        public void TryGetUnitFromAbbreviation_MatchingFallbackCulture_ReturnsTrue()
        {
            var formatProvider = CultureInfo.GetCultureInfo("ru-RU");
            UnitParser unitParser = UnitsNetSetup.Default.UnitParser;

            var success = unitParser.TryGetUnitFromAbbreviation("kg", formatProvider, out UnitInfo? unitInfo);
            
            Assert.True(success);
            Assert.Equal(Mass.Info[MassUnit.Kilogram], unitInfo);
        }

        [Fact]
        public void TryGetUnitFromAbbreviation_WithNullString_ReturnsFalse()
        {
            var success = UnitsNetSetup.Default.UnitParser.TryGetUnitFromAbbreviation(null, CultureInfo.InvariantCulture, out UnitInfo? _);
            
            Assert.False(success);
        }

        [Fact]
        public void GetUnitFromAbbreviation_GivenAbbreviationsThatAreAmbiguousWhenLowerCase_ReturnsCorrectUnit()
        {
            Assert.Equal(PressureUnit.Megabar, UnitParser.Default.GetUnitFromAbbreviation("Mbar", CultureInfo.InvariantCulture).Value);
            Assert.Equal(PressureUnit.Millibar, UnitParser.Default.GetUnitFromAbbreviation("mbar", CultureInfo.InvariantCulture).Value);
        }

        [Fact]
        public void GetUnitFromAbbreviation_NullAbbreviation_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => UnitsNetSetup.Default.UnitParser.GetUnitFromAbbreviation(null!, CultureInfo.InvariantCulture));
        }
        
        [Theory]
        [InlineData("z^2")]
        [InlineData("nonexistingunit")]
        public void GetUnitFromAbbreviation_UnknownAbbreviationThrowsUnitNotFoundException(string unknownAbbreviation)
        {
            Assert.Throws<UnitNotFoundException>(() => UnitsNetSetup.Default.UnitParser.GetUnitFromAbbreviation(unknownAbbreviation, CultureInfo.InvariantCulture));
        }
    }
}
