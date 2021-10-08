// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnitsNet.Units;
using Xunit;
using Xunit.Abstractions;

namespace UnitsNet.Tests
{
    [Collection(nameof(UnitLocalizedNamesCacheFixture))]
    public class UnitSingularNamesCacheTests
    {
        private readonly ITestOutputHelper _output;
        private const string AmericanCultureName = "en-US";
        private const string FrenchCultureName = "fr-FR";
        private const string RussianCultureName = "ru-RU";

        private static readonly IFormatProvider AmericanCulture = new CultureInfo(AmericanCultureName);
        private static readonly IFormatProvider FrenchCulture = new CultureInfo(FrenchCultureName);
        private static readonly IFormatProvider RussianCulture = new CultureInfo(RussianCultureName);
        
        public UnitSingularNamesCacheTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private enum CustomUnit
        {
            // ReSharper disable UnusedMember.Local
            Undefined = 0,
            Unit1,
            Unit2
            // ReSharper restore UnusedMember.Local
        }


        [Fact]
        public void SingularName_WithAmericanCulture()
        {
            Assert.Equal("Meter", UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Meter, AmericanCulture));
            Assert.Equal("Decimeter", UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Decimeter, AmericanCulture));

        }

        [Fact]
        public void SingularName_WithRussianCulture()
        {
            _output.WriteLine(UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Meter, RussianCulture));
            _output.WriteLine(UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Decimeter, RussianCulture));
            _output.WriteLine(UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Kilometer, RussianCulture));

            Assert.Equal("метр", UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Meter, RussianCulture));
            Assert.Equal("Децигметр", UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Decimeter, RussianCulture));
            Assert.Equal("Килогметр", UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Kilometer, RussianCulture));
        }

        [Fact]
        public void SingularName_WithFrenchCulture()
        {
            Assert.Equal("Mètre", UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Meter, FrenchCulture));
            Assert.Equal("Décimètre", UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Decimeter, FrenchCulture));
            Assert.Equal("Kilomètre", UnitSingularNamesCache.Default.GetDefaultSingularName(LengthUnit.Kilometer, FrenchCulture));
        }

        [Fact]
        public void GetDefaultAbbreviationThrowsNotImplementedExceptionIfNoneExist()
        {
            var unitAbbreviationCache = new UnitAbbreviationsCache();
            Assert.Throws<NotImplementedException>(() => unitAbbreviationCache.GetDefaultAbbreviation(CustomUnit.Unit1));
        }

        [Fact]
        public void GetDefaultAbbreviationFallsBackToUsEnglishCulture()
        {
            var oldCurrentCulture = CultureInfo.CurrentCulture;
            var oldCurrentUICulture = CultureInfo.CurrentUICulture;

            try
            {
                // CurrentCulture affects number formatting, such as comma or dot as decimal separator.
                // CurrentUICulture affects localization, in this case the abbreviation.
                // Zulu (South Africa)
                var zuluCulture = new CultureInfo("zu-ZA");
                CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = zuluCulture;

                var abbreviationsCache = new UnitAbbreviationsCache();
                abbreviationsCache.MapUnitToAbbreviation(CustomUnit.Unit1, AmericanCulture, "US english abbreviation for Unit1");

                // Act
                string abbreviation = abbreviationsCache.GetDefaultAbbreviation(CustomUnit.Unit1, zuluCulture);

                // Assert
                Assert.Equal("US english abbreviation for Unit1", abbreviation);
            }
            finally
            {
                CultureInfo.CurrentCulture = oldCurrentCulture;
                CultureInfo.CurrentUICulture = oldCurrentUICulture;
            }
        }

        [Fact]
        public void MapUnitToAbbreviation_AddCustomUnit_DoesNotOverrideDefaultAbbreviationForAlreadyMappedUnits()
        {
            var cache = new UnitAbbreviationsCache();
            cache.MapUnitToAbbreviation(AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m²", cache.GetDefaultAbbreviation(AreaUnit.SquareMeter));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_GivenUnitAndCulture_SetsDefaultAbbreviationForUnitAndCulture()
        {
            var cache = new UnitAbbreviationsCache();
            cache.MapUnitToDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture, "m^2");

            Assert.Equal("m^2", cache.GetDefaultAbbreviation(AreaUnit.SquareMeter, AmericanCulture));
        }

        [Fact]
        public void MapUnitToDefaultAbbreviation_GivenCustomAbbreviation_SetsAbbreviationUsedByQuantityToString()
        {
            // Use a distinct culture here so that we don't mess up other tests that may rely on the default cache.
            var newZealandCulture = GetCulture("en-NZ");
            UnitAbbreviationsCache.Default.MapUnitToDefaultAbbreviation(AreaUnit.SquareMeter, newZealandCulture, "m^2");

            Assert.Equal("1 m^2", Area.FromSquareMeters(1).ToString(newZealandCulture));
        }

        /// <summary>
        ///     Convenience method to the proper culture parameter type.
        /// </summary>
        private static CultureInfo GetCulture(string cultureName)
        {
            return new CultureInfo(cultureName);
        }
    }
}
