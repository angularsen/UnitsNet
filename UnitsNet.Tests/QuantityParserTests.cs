// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using UnitsNet.Tests.CustomQuantities;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityParserTests
    {
        [Fact]
        public void Parse_WithSingleCaseInsensitiveMatch_ParsesWithMatchedUnit()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.Some, "foo");
            var quantityParser = new QuantityParser(unitAbbreviationsCache);

            HowMuch q = quantityParser.Parse<HowMuch, HowMuchUnit>("1 FOO",
                null,
                (value, unit) => new HowMuch(value, unit));

            Assert.Equal(HowMuchUnit.Some, q.Unit);
            Assert.Equal(1, q.Value);
        }

        [Fact]
        public void Parse_WithOneCaseInsensitiveMatchAndOneExactMatch_ParsesWithTheExactMatchUnit()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.Some, "foo");
            unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.ATon, "FOO");
            var quantityParser = new QuantityParser(unitAbbreviationsCache);

            HowMuch q = quantityParser.Parse<HowMuch, HowMuchUnit>("1 FOO",
                null,
                (value, unit) => new HowMuch(value, unit));

            Assert.Equal(HowMuchUnit.ATon, q.Unit);
            Assert.Equal(1, q.Value);
        }

        [Fact]
        public void Parse_WithMultipleCaseInsensitiveMatchesButNoExactMatches_ThrowsAmbiguousUnitParseException()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.Some, "foo");
            unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.ATon, "FOO");
            var quantityParser = new QuantityParser(unitAbbreviationsCache);

            void Act()
            {
                quantityParser.Parse<HowMuch, HowMuchUnit>("1 Foo", null, (value, unit) => new HowMuch(value, unit));
            }

            var ex = Assert.Throws<AmbiguousUnitParseException>(Act);
            Assert.Equal("""Cannot parse "Foo" since it matches multiple units: ATon ("FOO"), Some ("foo").""", ex.Message);
        }

        [Fact]
        public void Parse_MappedCustomUnit()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.Some, "fooh");
            var quantityParser = new QuantityParser(unitAbbreviationsCache);

            HowMuch q = quantityParser.Parse<HowMuch, HowMuchUnit>("1 fooh",
                null,
                (value, unit) => new HowMuch(value, unit));

            Assert.Equal(HowMuchUnit.Some, q.Unit);
            Assert.Equal(1, q.Value);
        }

        [Fact]
        public void TryParse_MappedCustomUnit()
        {
            var unitAbbreviationsCache = new UnitAbbreviationsCache([HowMuch.Info]);
            unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.Some, "fooh");
            var quantityParser = new QuantityParser(unitAbbreviationsCache);

            bool success = quantityParser.TryParse<HowMuch, HowMuchUnit>("1 fooh",
                null,
                (value, unit) => new HowMuch(value, unit),
                out HowMuch q);

            Assert.True(success);
            Assert.Equal(HowMuchUnit.Some, q.Unit);
            Assert.Equal(1, q.Value);
        }

        [Fact]
        public void TryParse_NullString_Returns_False()
        {
            QuantityParser quantityParser = UnitsNetSetup.Default.QuantityParser;

            var success = quantityParser.TryParse<Mass, MassUnit>(null, null, Mass.From, out Mass _);

            Assert.False(success);
        }

        [Fact]
        public void TryParse_WithInvalidValue_Returns_False()
        {
            QuantityParser quantityParser = UnitsNetSetup.Default.QuantityParser;

            var success = quantityParser.TryParse<Mass, MassUnit>("XX kg", CultureInfo.InvariantCulture, Mass.From, out Mass _);

            Assert.False(success);
        }
    }
}
