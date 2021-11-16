// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
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
        public void GetDefaultSingularNameThrowsNotImplementedExceptionIfNoneExist()
        {
            var unitCache = new UnitSingularNamesCache();
            Assert.Throws<NotImplementedException>(() => unitCache.GetDefaultSingularName(CustomUnit.Unit1));
        }

        [Fact]
        public void GetDefaultSingularNameFallsBackToUsEnglishCulture()
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

                var cache = new UnitSingularNamesCache();
                cache.MapUnitToDefaultSingularName(CustomUnit.Unit1, AmericanCulture, "US english singular name for Unit1");

                // Act
                string abbreviation = cache.GetDefaultSingularName(CustomUnit.Unit1, zuluCulture);

                // Assert
                Assert.Equal("US english singular name for Unit1", abbreviation);
            }
            finally
            {
                CultureInfo.CurrentCulture = oldCurrentCulture;
                CultureInfo.CurrentUICulture = oldCurrentUICulture;
            }
        }

        [Fact]
        public void MapUnitToSingularName_AddCustomUnit_DoesNotOverrideDefaultSingularNameForAlreadyMappedUnits()
        {
            var cache = new UnitSingularNamesCache();
            cache.MapUnitToSingularName(LengthUnit.Centimeter, AmericanCulture, "mycentimeter");

            Assert.Equal("Centimeter", cache.GetDefaultSingularName(LengthUnit.Centimeter));
        }

        [Fact]
        public void MapUnitToSingularnName_GivenUnitAndCulture_SetsDefaulSingularNameForUnitAndCulture()
        {
            var cache = new UnitSingularNamesCache();
            cache.MapUnitToDefaultSingularName(LengthUnit.Centimeter, AmericanCulture, "mycentimeter");
            Assert.Equal("mycentimeter", cache.GetDefaultSingularName(LengthUnit.Centimeter, AmericanCulture));
        }
        [Fact]
        public void TestParse()
        {
            var result=Information.Parse("1 m");
            _output.WriteLine(result.ToString());
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
