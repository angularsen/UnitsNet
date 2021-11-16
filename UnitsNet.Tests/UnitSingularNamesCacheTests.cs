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
            Assert.Equal("Meter", UnitSingularNamesCache.Default.GetUnitSingularName(LengthUnit.Meter, AmericanCulture));
            Assert.Equal("Decimeter", UnitSingularNamesCache.Default.GetUnitSingularName(LengthUnit.Decimeter, AmericanCulture));
        }

        [Fact]
        public void SingularName_WithRussianCulture()
        {
            Assert.Equal("метр", UnitSingularNamesCache.Default.GetUnitSingularName(LengthUnit.Meter, RussianCulture));
            Assert.Equal("Децигметр", UnitSingularNamesCache.Default.GetUnitSingularName(LengthUnit.Decimeter, RussianCulture));
            Assert.Equal("Килогметр", UnitSingularNamesCache.Default.GetUnitSingularName(LengthUnit.Kilometer, RussianCulture));
        }

        [Fact]
        public void SingularName_WithFrenchCulture()
        {
            Assert.Equal("Mètre", UnitSingularNamesCache.Default.GetUnitSingularName(LengthUnit.Meter, FrenchCulture));
            Assert.Equal("Décimètre", UnitSingularNamesCache.Default.GetUnitSingularName(LengthUnit.Decimeter, FrenchCulture));
            Assert.Equal("Kilomètre", UnitSingularNamesCache.Default.GetUnitSingularName(LengthUnit.Kilometer, FrenchCulture));
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
