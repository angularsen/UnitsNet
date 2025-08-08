using System;
using System.Collections.Generic;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    /// <summary>
    /// Generates base class for each quantity test class, with stubs for testing conversion functions and error tolerances that the developer must complete to fix compile errors.
    /// </summary>
    /// <example>
    /// <list type="bullet">
    /// <item><description>UnitsNet.Tests\GeneratedCode\AccelerationTestsBase.g.cs</description></item>
    /// <item><description>UnitsNet.Tests\GeneratedCode\LengthTestsBase.g.cs</description></item>
    /// </list>
    /// </example>
    internal class UnitTestBaseClassGenerator : GeneratorBase
    {
        /// <summary>
        /// The quantity to generate test base class for.
        /// </summary>
        private readonly Quantity _quantity;

        /// <summary>
        /// Base unit for this quantity, such as Meter for quantity Length.
        /// </summary>
        private readonly Unit _baseUnit;

        /// <summary>
        /// Example: "LengthUnit"
        /// </summary>
        private readonly string _unitEnumName;

        /// <summary>
        /// Example: " m" for Length quantity with leading whitespace or "" for Ratio quantity where base unit does not have an abbreviation.
        /// </summary>
        private readonly string _baseUnitEnglishAbbreviation;

        /// <summary>
        /// Example: "LengthUnit.Meter".
        /// </summary>
        private readonly string _baseUnitFullName;

        /// <summary>
        /// Other unit, if more than one unit exists for quantity, otherwise same as <see cref="_baseUnit"/>.
        /// </summary>
        private readonly Unit _otherOrBaseUnit;

        /// <summary>
        /// Example: "LengthUnit.Centimeter".
        /// </summary>
        private readonly string _otherOrBaseUnitFullName;

        /// <summary>
        /// Indicates whether the quantity is dimensionless.
        /// </summary>
        /// <remarks>
        /// A dimensionless quantity has all base dimensions (L, M, T, I, Θ, N, J) equal to zero.
        /// </remarks>
        private readonly bool _isDimensionless;

        /// <summary>
        ///     Stores a mapping of culture names to their corresponding unique unit abbreviations.
        ///     Each culture maps to a dictionary where the key is the unit abbreviation and the value is the corresponding
        ///     <see cref="Unit" />.
        ///     This ensures that unit abbreviations are unique within the context of a specific culture.
        /// </summary>
        /// <remarks>
        ///     Used for testing culture-specific parsing with non-ambiguous (unique) abbreviations.
        /// </remarks>
        private readonly Dictionary<string, Dictionary<string, Unit>> _uniqueAbbreviationsForCulture;

        /// <summary>
        ///     Stores a mapping of culture names to their respective ambiguous unit abbreviations.
        ///     Each culture maps to a dictionary where the key is the ambiguous abbreviation, and the value is a list of
        ///     <see cref="Unit" /> objects
        ///     that share the same abbreviation within that culture.
        /// </summary>
        /// <remarks>
        ///     This field is used to identify and handle unit abbreviations that are not unique within a specific culture.
        ///     Ambiguities arise when multiple units share the same abbreviation, requiring additional logic to resolve.
        /// </remarks>
        private readonly Dictionary<string, Dictionary<string, List<Unit>>> _ambiguousAbbreviationsForCulture;

        /// <summary>
        ///     The default or fallback culture for unit localizations.
        /// </summary>
        /// <remarks>
        ///     This culture, "en-US", is used as a fallback when a specific <see cref="System.Globalization.CultureInfo" />
        ///     is not available for the defined unit localizations.
        /// </remarks>
        private const string FallbackCultureName = "en-US";

        public UnitTestBaseClassGenerator(Quantity quantity)
        {
            _quantity = quantity;
            _baseUnit = quantity.Units.FirstOrDefault(u => u.SingularName == _quantity.BaseUnit) ??
                        throw new ArgumentException($"No unit found with SingularName equal to BaseUnit [{_quantity.BaseUnit}]. This unit must be defined.",
                            nameof(quantity));

            _unitEnumName = $"{quantity.Name}Unit";

            _baseUnitEnglishAbbreviation = GetEnglishAbbreviation(_baseUnit);
            _baseUnitFullName = $"{_unitEnumName}.{_baseUnit.SingularName}";

            // Try to pick another unit, or fall back to base unit if only a single unit.
            _otherOrBaseUnit = quantity.Units.Where(u => u != _baseUnit).DefaultIfEmpty(_baseUnit).First();
            _otherOrBaseUnitFullName = $"{_unitEnumName}.{_otherOrBaseUnit.SingularName}";
            _isDimensionless = quantity.BaseDimensions is { L: 0, M: 0, T: 0, I: 0, Θ: 0, N: 0, J: 0 };

            var abbreviationsForCulture = new Dictionary<string, Dictionary<string, List<Unit>>>();
            foreach (Unit unit in quantity.Units)
            {
                if (unit.ObsoleteText != null)
                {
                    continue;
                }

                foreach (Localization localization in unit.Localization)
                {
                    if (!abbreviationsForCulture.TryGetValue(localization.Culture, out Dictionary<string, List<Unit>>? localizationsForCulture))
                    {
                        abbreviationsForCulture[localization.Culture] = localizationsForCulture = new Dictionary<string, List<Unit>>();
                    }

                    foreach (var abbreviation in localization.Abbreviations)
                    {
                        if (localizationsForCulture.TryGetValue(abbreviation, out List<Unit>? matchingUnits))
                        {
                            matchingUnits.Add(unit);
                        }
                        else
                        {
                            localizationsForCulture[abbreviation] = [unit];
                        }
                    }
                }
            }

            _uniqueAbbreviationsForCulture = new Dictionary<string, Dictionary<string, Unit>>();
            _ambiguousAbbreviationsForCulture = new Dictionary<string, Dictionary<string, List<Unit>>>();
            foreach ((var cultureName, Dictionary<string, List<Unit>>? abbreviations) in abbreviationsForCulture)
            {
                var uniqueAbbreviations = abbreviations.Where(pair => pair.Value.Count == 1).ToDictionary(pair => pair.Key, pair => pair.Value[0]);
                if (uniqueAbbreviations.Count != 0)
                {
                    _uniqueAbbreviationsForCulture.Add(cultureName, uniqueAbbreviations);
                }

                var ambiguousAbbreviations = abbreviations.Where(pair => pair.Value.Count > 1).ToDictionary();
                if (ambiguousAbbreviations.Count != 0)
                {
                    _ambiguousAbbreviationsForCulture.Add(cultureName, ambiguousAbbreviations);
                }
            }
        }

        private string GetUnitFullName(Unit unit) => $"{_unitEnumName}.{unit.SingularName}";

        /// <summary>
        /// Gets the first en-US abbreviation for the unit -or- empty string if none is defined.
        /// If a unit abbreviation exists, a leading whitespace is added to separate the number and the abbreviation like "1 m".
        /// </summary>
        private static string GetEnglishAbbreviation(Unit unit)
        {
            var unitAbbreviation = unit.Localization.First(l => l.Culture == "en-US").Abbreviations.FirstOrDefault();
            return string.IsNullOrEmpty(unitAbbreviation) ? "" : $" {unitAbbreviation}";
        }

        public string Generate()
        {
            var baseUnitVariableName = _baseUnit.SingularName.ToLowerInvariant();

            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using UnitsNet.InternalHelpers;
using UnitsNet.Tests.Helpers;
using UnitsNet.Tests.TestsBase;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{{
    /// <summary>
    /// Test of {_quantity.Name}.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class {_quantity.Name}TestsBase : QuantityTestsBase
    {{");
            foreach (var unit in _quantity.Units)
            {
                if (unit.SkipConversionGeneration) continue;

                Writer.WL($@"
        protected abstract double {unit.PluralName}InOne{_baseUnit.SingularName} {{ get; }}");
            }

            Writer.WL();
            Writer.WL(@"
// ReSharper disable VirtualMemberNeverOverriden.Global");
            foreach (var unit in _quantity.Units)
            {
                if (unit.SkipConversionGeneration) continue;

                Writer.WL($@"
        protected virtual double {unit.PluralName}Tolerance {{ get {{ return 1e-5; }} }}");
            }
            Writer.WL($@"
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor({_unitEnumName} unit)
        {{
            return unit switch
            {{");
            foreach (var unit in _quantity.Units)
            {
                Writer.WL($@"
                {GetUnitFullName(unit)} => ({unit.PluralName}InOne{_baseUnit.SingularName}, {unit.PluralName}Tolerance),");
            }

            Writer.WL($@"
                _ => throw new NotSupportedException()
            }};
        }}

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {{");
            foreach (var unit in _quantity.Units)
            {
                Writer.WL($@"
            new object[] {{ {GetUnitFullName(unit)} }},");
            }
            Writer.WL($@"
        }};

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {{
            var quantity = new {_quantity.Name}();
            Assert.Equal(0, quantity.Value);
            Assert.Equal({_baseUnitFullName}, quantity.Unit);
        }}

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {{
            var exception1 = Record.Exception(() => new {_quantity.Name}(double.PositiveInfinity, {_baseUnitFullName}));
            var exception2 = Record.Exception(() => new {_quantity.Name}(double.NegativeInfinity, {_baseUnitFullName}));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }}

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {{
            var exception = Record.Exception(() => new {_quantity.Name}(double.NaN, {_baseUnitFullName}));

            Assert.Null(exception);
        }}
");
            if (!_isDimensionless)
            {
                Writer.WL($@"

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {{
            Assert.Throws<ArgumentNullException>(() => new {_quantity.Name}(value: 1, unitSystem: null));
        }}

        [Fact]
        public virtual void Ctor_SIUnitSystem_ReturnsQuantityWithSIUnits()
        {{
            var quantity = new {_quantity.Name}(value: 1, unitSystem: UnitSystem.SI);
            Assert.Equal(1, quantity.Value);
            Assert.True(quantity.QuantityInfo[quantity.Unit].BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }}

        [Fact]
        public void Ctor_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {{
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => new {_quantity.Name}(value: 1, unitSystem: unsupportedUnitSystem));
        }}
");
            }

            Writer.WL($@"

        [Fact]
        public void {_quantity.Name}_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {{
            {_unitEnumName}[] unitsOrderedByName = EnumHelper.GetValues<{_unitEnumName}>().OrderBy(x => x.ToString()).ToArray();
            var quantity = new {_quantity.Name}(1, {_baseUnitFullName});

            QuantityInfo<{_quantity.Name}, {_unitEnumName}> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(""{_quantity.Name}"", quantityInfo.Name);
            Assert.Equal({_quantity.Name}.Zero, quantityInfo.Zero);
            Assert.Equal({_quantity.Name}.BaseUnit, quantityInfo.BaseUnitInfo.Value);
            Assert.Equal(unitsOrderedByName, quantityInfo.Units);
            Assert.Equal(unitsOrderedByName, quantityInfo.UnitInfos.Select(x => x.Value));
            Assert.Equal({_quantity.Name}.Info, quantityInfo);
            Assert.Equal(quantityInfo, ((IQuantity)quantity).QuantityInfo);
            Assert.Equal(quantityInfo, ((IQuantity<{_unitEnumName}>)quantity).QuantityInfo);
        }}

        [Fact]
        public void {_baseUnit.SingularName}To{_quantity.Name}Units()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);");

            foreach (var unit in _quantity.Units) Writer.WL($@"
            AssertEx.EqualTolerance({unit.PluralName}InOne{_baseUnit.SingularName}, {baseUnitVariableName}.{unit.PluralName}, {unit.PluralName}Tolerance);");
            Writer.WL($@"
        }}

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {{");
            var i = 0;
            foreach (var unit in _quantity.Units)
            {
                var quantityVariable = $"quantity{i++:D2}";
                Writer.WL($@"
            var {quantityVariable} = {_quantity.Name}.From(1, {GetUnitFullName(unit)});
            AssertEx.EqualTolerance(1, {quantityVariable}.{unit.PluralName}, {unit.PluralName}Tolerance);
            Assert.Equal({GetUnitFullName(unit)}, {quantityVariable}.Unit);
");

            }
            Writer.WL($@"
        }}

        [Fact]
        public void From{_baseUnit.PluralName}_WithInfinityValue_DoNotThrowsArgumentException()
        {{
            var exception1 = Record.Exception(() => {_quantity.Name}.From{_baseUnit.PluralName}(double.PositiveInfinity));
            var exception2 = Record.Exception(() => {_quantity.Name}.From{_baseUnit.PluralName}(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }}

        [Fact]
        public void From{_baseUnit.PluralName}_WithNanValue_DoNotThrowsArgumentException()
        {{
            var exception = Record.Exception(() => {_quantity.Name}.From{_baseUnit.PluralName}(double.NaN));

            Assert.Null(exception);
        }}

        [Fact]
        public void As()
        {{
            var {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);");
            foreach (var unit in _quantity.Units) Writer.WL($@"
            AssertEx.EqualTolerance({unit.PluralName}InOne{_baseUnit.SingularName}, {baseUnitVariableName}.As({GetUnitFullName(unit)}), {unit.PluralName}Tolerance);");
            Writer.WL($@"
        }}
");
            if (_isDimensionless)
            {
                Writer.WL($@"

        [Fact]
        public void As_UnitSystem_ReturnsValueInDimensionlessUnit()
        {{
            var quantity = new {_quantity.Name}(value: 1, unit: {_baseUnitFullName});

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(quantity.Value, convertedValue);
        }}

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {{
            var quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }}

        [Fact]
        public void ToUnitSystem_ReturnsValueInDimensionlessUnit()
        {{
            Assert.Multiple(() =>
            {{
                var quantity = new {_quantity.Name}(value: 1, unit: {_baseUnitFullName});

                {_quantity.Name} convertedQuantity = quantity.ToUnit(UnitSystem.SI);

                Assert.Equal({_baseUnitFullName}, convertedQuantity.Unit);
                Assert.Equal(quantity.Value, convertedQuantity.Value);
            }}, () =>
            {{
                IQuantity<{_unitEnumName}> quantity = new {_quantity.Name}(value: 1, unit: {_baseUnitFullName});

                IQuantity<{_unitEnumName}> convertedQuantity = quantity.ToUnit(UnitSystem.SI);

                Assert.Equal({_baseUnitFullName}, convertedQuantity.Unit);
                Assert.Equal(quantity.Value, convertedQuantity.Value);
            }}, () =>
            {{
                IQuantity quantity = new {_quantity.Name}(value: 1, unit: {_baseUnitFullName});

                IQuantity convertedQuantity = quantity.ToUnit(UnitSystem.SI);

                Assert.Equal({_baseUnitFullName}, convertedQuantity.Unit);
                Assert.Equal(quantity.Value, convertedQuantity.Value);
            }});
        }}

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {{
            UnitSystem nullUnitSystem = null!;
            Assert.Multiple(() =>
            {{
                var quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }}, () =>
            {{
                IQuantity<{_unitEnumName}> quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }}, () =>
            {{
                IQuantity quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }});
        }}
");
            }
            else
            {
                Writer.WL($@"

        [Fact]
        public virtual void BaseUnit_HasSIBase()
        {{
            var baseUnitInfo = {_quantity.Name}.Info.BaseUnitInfo;
            Assert.True(baseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }}

        [Fact]
        public virtual void As_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {{
            var quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
            var expectedValue = quantity.As({_quantity.Name}.Info.GetDefaultUnit(UnitSystem.SI));

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(expectedValue, convertedValue);
        }}

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {{
            var quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }}

        [Fact]
        public void As_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {{
            var quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => quantity.As(unsupportedUnitSystem));
        }}

        [Fact]
        public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {{
            var quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
            var expectedUnit = {_quantity.Name}.Info.GetDefaultUnit(UnitSystem.SI);
            var expectedValue = quantity.As(expectedUnit);

            Assert.Multiple(() =>
            {{
                {_quantity.Name} quantityToConvert = quantity;

                {_quantity.Name} convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }}, () =>
            {{
                IQuantity<{_unitEnumName}> quantityToConvert = quantity;

                IQuantity<{_unitEnumName}> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }}, () =>
            {{
                IQuantity quantityToConvert = quantity;

                IQuantity convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }});
        }}

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {{
            UnitSystem nullUnitSystem = null!;
            Assert.Multiple(() =>
            {{
                var quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }}, () =>
            {{
                IQuantity<{_unitEnumName}> quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }}, () =>
            {{
                IQuantity quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }});
        }}

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {{
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Multiple(() =>
            {{
                var quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }}, () =>
            {{
                IQuantity<{_unitEnumName}> quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }}, () =>
            {{
                IQuantity quantity = new {_quantity.Name}(value: 1, unit: {_quantity.Name}.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }});
        }}
");
            }

            Writer.WL($@"

        [Fact]
        public void Parse()
        {{");
            foreach (var unit in _quantity.Units.Where(u => string.IsNullOrEmpty(u.ObsoleteText)))
            foreach (var localization in unit.Localization)
            foreach (var abbreviation in localization.Abbreviations)
            {
                Writer.WL($@"
            try
            {{
                var parsed = {_quantity.Name}.Parse(""1 {abbreviation}"", CultureInfo.GetCultureInfo(""{localization.Culture}""));
                AssertEx.EqualTolerance(1, parsed.{unit.PluralName}, {unit.PluralName}Tolerance);
                Assert.Equal({GetUnitFullName(unit)}, parsed.Unit);
            }} catch (AmbiguousUnitParseException) {{ /* Some units have the same abbreviations */ }}
");
            }
            Writer.WL($@"
        }}

        [Fact]
        public void TryParse()
        {{");
            foreach (var unit in _quantity.Units.Where(u => string.IsNullOrEmpty(u.ObsoleteText)))
            foreach (var localization in unit.Localization)
            foreach (var abbreviation in localization.Abbreviations)
            {
                // Skip units with ambiguous abbreviations, since there is no exception to describe this is why TryParse failed.
                if (IsAmbiguousAbbreviation(localization, abbreviation)) continue;

                Writer.WL($@"
            {{
                Assert.True({_quantity.Name}.TryParse(""1 {abbreviation}"", CultureInfo.GetCultureInfo(""{localization.Culture}""), out var parsed));
                AssertEx.EqualTolerance(1, parsed.{unit.PluralName}, {unit.PluralName}Tolerance);
                Assert.Equal({GetUnitFullName(unit)}, parsed.Unit);
            }}
");
            }
            Writer.WL($@"
        }}
");

            Writer.WL($@"
        [Theory]");
            foreach ((var abbreviation, Unit unit) in _uniqueAbbreviationsForCulture[FallbackCultureName])
            {
                Writer.WL($@"
        [InlineData(""{abbreviation}"", {GetUnitFullName(unit)})]");
            }
            Writer.WL($@"
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, {_unitEnumName} expectedUnit)
        {{
            // Fallback culture ""{FallbackCultureName}"" is always localized
            using var _ = new CultureScope(""{FallbackCultureName}"");
            {_unitEnumName} parsedUnit = {_quantity.Name}.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }}
");

            Writer.WL($@"
        [Theory]");
            foreach ((var abbreviation, Unit unit) in _uniqueAbbreviationsForCulture[FallbackCultureName])
            {
                Writer.WL($@"
        [InlineData(""{abbreviation}"", {GetUnitFullName(unit)})]");
            }
            Writer.WL($@"
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, {_unitEnumName} expectedUnit)
        {{
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to ""{FallbackCultureName}"" when parsing.
            using var _ = new CultureScope(""is-IS"");
            {_unitEnumName} parsedUnit = {_quantity.Name}.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }}
");

            Writer.WL($@"
        [Theory]");
            foreach ((var cultureName, Dictionary<string, Unit> abbreviations) in _uniqueAbbreviationsForCulture)
            {
                foreach ((var abbreviation, Unit unit) in abbreviations)
                {
                    Writer.WL($@"
        [InlineData(""{cultureName}"", ""{abbreviation}"", {GetUnitFullName(unit)})]");
                }
            }
            Writer.WL($@"
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, {_unitEnumName} expectedUnit)
        {{
            using var _ = new CultureScope(culture);
            {_unitEnumName} parsedUnit = {_quantity.Name}.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }}
");

            Writer.WL($@"
        [Theory]");
            foreach ((var cultureName, Dictionary<string, Unit> abbreviations) in _uniqueAbbreviationsForCulture)
            {
                foreach ((var abbreviation, Unit unit) in abbreviations)
                {
                    Writer.WL($@"
        [InlineData(""{cultureName}"", ""{abbreviation}"", {GetUnitFullName(unit)})]");
                }
            }
            Writer.WL($@"
        public void ParseUnit_WithCulture(string culture, string abbreviation, {_unitEnumName} expectedUnit)
        {{
            {_unitEnumName} parsedUnit = {_quantity.Name}.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }}
");

            // we only generate these for a few of the quantities
            if (_ambiguousAbbreviationsForCulture.Count != 0)
            {
                Writer.WL($@"
        [Theory]");
                foreach ((var cultureName, Dictionary<string, List<Unit>>? abbreviations) in _ambiguousAbbreviationsForCulture)
                {
                    foreach (KeyValuePair<string, List<Unit>> ambiguousPair in abbreviations)
                    {
                        Writer.WL($@"
        [InlineData(""{cultureName}"", ""{ambiguousPair.Key}"")] // [{string.Join(", ", ambiguousPair.Value.Select(x => x.SingularName))}]");
                    }
                }
                Writer.WL($@"
        public void ParseUnitWithAmbiguousAbbreviation(string culture, string abbreviation)
        {{
            Assert.Throws<AmbiguousUnitParseException>(() => {_quantity.Name}.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture)));
        }}
");
            } // ambiguousAbbreviations

            Writer.WL($@"
        [Theory]");
            foreach ((var abbreviation, Unit unit) in _uniqueAbbreviationsForCulture[FallbackCultureName])
            {
                Writer.WL($@"
        [InlineData(""{abbreviation}"", {GetUnitFullName(unit)})]");
            }
            Writer.WL($@"
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, {_unitEnumName} expectedUnit)
        {{
            // Fallback culture ""{FallbackCultureName}"" is always localized
            using var _ = new CultureScope(""{FallbackCultureName}"");
            Assert.True({_quantity.Name}.TryParseUnit(abbreviation, out {_unitEnumName} parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }}
");

            Writer.WL($@"
        [Theory]");
            foreach ((var abbreviation, Unit unit) in _uniqueAbbreviationsForCulture[FallbackCultureName])
            {
                Writer.WL($@"
        [InlineData(""{abbreviation}"", {GetUnitFullName(unit)})]");
            }
            Writer.WL($@"
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, {_unitEnumName} expectedUnit)
        {{
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to ""{FallbackCultureName}"" when parsing.
            using var _ = new CultureScope(""is-IS"");
            Assert.True({_quantity.Name}.TryParseUnit(abbreviation, out {_unitEnumName} parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }}
");

            Writer.WL($@"
        [Theory]");
            foreach ((var cultureName, Dictionary<string, Unit> abbreviations) in _uniqueAbbreviationsForCulture)
            {
                foreach ((var abbreviation, Unit unit) in abbreviations)
                {
                    Writer.WL($@"
        [InlineData(""{cultureName}"", ""{abbreviation}"", {GetUnitFullName(unit)})]");
                }
            }
            Writer.WL($@"
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, {_unitEnumName} expectedUnit)
        {{
            using var _ = new CultureScope(culture);
            Assert.True({_quantity.Name}.TryParseUnit(abbreviation, out {_unitEnumName} parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }}
");

            Writer.WL($@"
        [Theory]");
            foreach ((var cultureName, Dictionary<string, Unit> abbreviations) in _uniqueAbbreviationsForCulture)
            {
                foreach ((var abbreviation, Unit unit) in abbreviations)
                {
                    Writer.WL($@"
        [InlineData(""{cultureName}"", ""{abbreviation}"", {GetUnitFullName(unit)})]");
                }
            }
            Writer.WL($@"
        public void TryParseUnit_WithCulture(string culture, string abbreviation, {_unitEnumName} expectedUnit)
        {{
            Assert.True({_quantity.Name}.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out {_unitEnumName} parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }}
");

            // we only generate these for a few of the quantities
            if (_ambiguousAbbreviationsForCulture.Count != 0)
            {
                Writer.WL($@"
        [Theory]");
                foreach ((var cultureName, Dictionary<string, List<Unit>>? abbreviations) in _ambiguousAbbreviationsForCulture)
                {
                    foreach (KeyValuePair<string, List<Unit>> ambiguousPair in abbreviations)
                    {
                        Writer.WL($@"
        [InlineData(""{cultureName}"", ""{ambiguousPair.Key}"")] // [{string.Join(", ", ambiguousPair.Value.Select(x => x.SingularName))}]");
                    }
                }
                Writer.WL($@"
        public void TryParseUnitWithAmbiguousAbbreviation(string culture, string abbreviation)
        {{
            Assert.False({_quantity.Name}.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out _));
        }}
");
            } // ambiguousAbbreviations

            Writer.WL($@"
        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit({_unitEnumName} unit)
        {{
            var inBaseUnits = {_quantity.Name}.From(1.0, {_quantity.Name}.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }}

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual({_unitEnumName} unit)
        {{
            var quantity = {_quantity.Name}.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }}

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit({_unitEnumName} unit)
        {{
            Assert.All({_quantity.Name}.Units.Where(u => u != {_quantity.Name}.BaseUnit), fromUnit =>
            {{
                var quantity = {_quantity.Name}.From(3.0, fromUnit);
                var converted = quantity.ToUnit(unit);
                Assert.Equal(converted.Unit, unit);
            }});
        }}

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit({_unitEnumName} unit)
        {{
            var quantity = default({_quantity.Name});
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }}

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromIQuantity_ReturnsTheExpectedIQuantity({_unitEnumName} unit)
        {{
            var quantity = {_quantity.Name}.From(3, {_quantity.Name}.BaseUnit);
            {_quantity.Name} expectedQuantity = quantity.ToUnit(unit);
            Assert.Multiple(() =>
            {{
                IQuantity<{_unitEnumName}> quantityToConvert = quantity;
                IQuantity<{_unitEnumName}> convertedQuantity = quantityToConvert.ToUnit(unit);
                Assert.Equal(unit, convertedQuantity.Unit);
            }}, () =>
            {{
                IQuantity quantityToConvert = quantity;
                IQuantity convertedQuantity = quantityToConvert.ToUnit(unit);
                Assert.Equal(unit, convertedQuantity.Unit);
            }});
        }}

        [Fact]
        public void ConversionRoundTrip()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);");
            foreach (var unit in _quantity.Units) Writer.WL($@"
            AssertEx.EqualTolerance(1, {_quantity.Name}.From{unit.PluralName}({baseUnitVariableName}.{unit.PluralName}).{_baseUnit.PluralName}, {unit.PluralName}Tolerance);");
            Writer.WL($@"
        }}
");
            if (_quantity.Logarithmic)
            {
                var unit = _quantity.Units.Last();
                Writer.WL($@"
        [Fact]
        public void LogarithmicArithmeticOperators()
        {{
            {_quantity.Name} v = {_quantity.Name}.From{_baseUnit.PluralName}(40);
            AssertEx.EqualTolerance(-40, -v.{_baseUnit.PluralName}, {unit.PluralName}Tolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            AssertEx.EqualTolerance(50, (v*10).{_baseUnit.PluralName}, {unit.PluralName}Tolerance);
            AssertEx.EqualTolerance(50, (10*v).{_baseUnit.PluralName}, {unit.PluralName}Tolerance);
            AssertEx.EqualTolerance(35, (v/5).{_baseUnit.PluralName}, {unit.PluralName}Tolerance);
            AssertEx.EqualTolerance(35, v/{_quantity.Name}.From{_baseUnit.PluralName}(5), {unit.PluralName}Tolerance);
        }}

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();
");
            }
            else if (!_quantity.IsAffine)
            {
                Writer.WL($@"
        [Fact]
        public void ArithmeticOperators()
        {{
            {_quantity.Name} v = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            AssertEx.EqualTolerance(-1, -v.{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(2, ({_quantity.Name}.From{_baseUnit.PluralName}(3)-v).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(2, (v + v).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(10, (v*10).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(10, (10*v).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(2, ({_quantity.Name}.From{_baseUnit.PluralName}(10)/5).{_baseUnit.PluralName}, {_baseUnit.PluralName}Tolerance);
            AssertEx.EqualTolerance(2, {_quantity.Name}.From{_baseUnit.PluralName}(10)/{_quantity.Name}.From{_baseUnit.PluralName}(5), {_baseUnit.PluralName}Tolerance);
        }}
");
            }
            else
            {
                Writer.WL();
            }

            Writer.WL($@"
        [Fact]
        public void ComparisonOperators()
        {{
            {_quantity.Name} one{_baseUnit.SingularName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            {_quantity.Name} two{_baseUnit.PluralName} = {_quantity.Name}.From{_baseUnit.PluralName}(2);

            Assert.True(one{_baseUnit.SingularName} < two{_baseUnit.PluralName});
            Assert.True(one{_baseUnit.SingularName} <= two{_baseUnit.PluralName});
            Assert.True(two{_baseUnit.PluralName} > one{_baseUnit.SingularName});
            Assert.True(two{_baseUnit.PluralName} >= one{_baseUnit.SingularName});

            Assert.False(one{_baseUnit.SingularName} > two{_baseUnit.PluralName});
            Assert.False(one{_baseUnit.SingularName} >= two{_baseUnit.PluralName});
            Assert.False(two{_baseUnit.PluralName} < one{_baseUnit.SingularName});
            Assert.False(two{_baseUnit.PluralName} <= one{_baseUnit.SingularName});
        }}

        [Fact]
        public void CompareToIsImplemented()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.Equal(0, {baseUnitVariableName}.CompareTo({baseUnitVariableName}));
            Assert.True({baseUnitVariableName}.CompareTo({_quantity.Name}.Zero) > 0);
            Assert.True({_quantity.Name}.Zero.CompareTo({baseUnitVariableName}) < 0);
        }}

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.Throws<ArgumentException>(() => {baseUnitVariableName}.CompareTo(new object()));
        }}

        [Fact]
        public void CompareToThrowsOnNull()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.Throws<ArgumentNullException>(() => {baseUnitVariableName}.CompareTo(null));
        }}

        [Theory]
        [InlineData(1, {_baseUnitFullName}, 1, {_baseUnitFullName}, true)]  // Same value and unit.
        [InlineData(1, {_baseUnitFullName}, 2, {_baseUnitFullName}, false)] // Different value.
        [InlineData(2, {_baseUnitFullName}, 1, {_otherOrBaseUnitFullName}, false)] // Different value and unit.");
            if (_baseUnit != _otherOrBaseUnit)
            {
                Writer.WL($@"
        [InlineData(1, {_baseUnitFullName}, 1, {_otherOrBaseUnitFullName}, false)] // Different unit.");
            }
            Writer.WL($@"
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, {_unitEnumName} unitA, double valueB, {_unitEnumName} unitB, bool expectEqual)
        {{
            var a = new {_quantity.Name}(valueA, unitA);
            var b = new {_quantity.Name}(valueB, unitB);

            // Operator overloads.
            Assert.Equal(expectEqual, a == b);
            Assert.Equal(expectEqual, b == a);
            Assert.Equal(!expectEqual, a != b);
            Assert.Equal(!expectEqual, b != a);

            // IEquatable<T>
            Assert.Equal(expectEqual, a.Equals(b));
            Assert.Equal(expectEqual, b.Equals(a));

            // IEquatable
            Assert.Equal(expectEqual, a.Equals((object)b));
            Assert.Equal(expectEqual, b.Equals((object)a));
        }}

        [Fact]
        public void Equals_Null_ReturnsFalse()
        {{
            var a = {_quantity.Name}.Zero;

            Assert.False(a.Equals((object)null));

            // ""The result of the expression is always 'false'...""
            #pragma warning disable CS8073
            Assert.False(a == null);
            Assert.False(null == a);
            Assert.True(a != null);
            Assert.True(null != a);
            #pragma warning restore CS8073
        }}

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.False({baseUnitVariableName}.Equals(new object()));
        }}

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {{
            {_quantity.Name} {baseUnitVariableName} = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            Assert.False({baseUnitVariableName}.Equals(null));
        }}
");
            var differenceResultType = _quantity.AffineOffsetType ?? _quantity.Name;
            if (_quantity.Logarithmic)
            {
                Writer.WL($@"

        [Theory]
        [InlineData(1, 2)]
        [InlineData(100, 110)]
        [InlineData(100, 90)]
        public void Equals_Logarithmic_WithTolerance(double firstValue, double secondValue)
        {{
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(firstValue);
            var otherQuantity = {_quantity.Name}.From{_baseUnit.PluralName}(secondValue);
            {differenceResultType} maxTolerance = quantity > otherQuantity ? quantity - otherQuantity : otherQuantity - quantity;
            var largerTolerance = maxTolerance * 1.1;
            var smallerTolerance = maxTolerance / 1.1;
            Assert.True(quantity.Equals(quantity, {differenceResultType}.Zero));
            Assert.True(quantity.Equals(quantity, maxTolerance));
            Assert.True(quantity.Equals(otherQuantity, largerTolerance));
            Assert.False(quantity.Equals(otherQuantity, smallerTolerance));
            // note: it's currently not possible to test this due to the rounding error from (quantity - otherQuantity) 
            // Assert.True(quantity.Equals(otherQuantity, maxTolerance));
        }}

        [Fact]
        public void Equals_Logarithmic_WithNegativeTolerance_DoesNotThrowArgumentOutOfRangeException()
        {{
            // note: unlike with vector quantities- a small tolerance maybe positive in one unit and negative in another
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            var negativeTolerance = {_quantity.Name}.From{_baseUnit.PluralName}(-1);
            Assert.True(quantity.Equals(quantity, negativeTolerance));
        }}
");
            }
            else // quantities with a linear scale
            {
                Writer.WL($@"

        [Theory]
        [InlineData(1, 2)]
        [InlineData(100, 110)]
        [InlineData(100, 90)]
        public void Equals_WithTolerance(double firstValue, double secondValue)
        {{
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(firstValue);
            var otherQuantity = {_quantity.Name}.From{_baseUnit.PluralName}(secondValue);
            {differenceResultType} maxTolerance = quantity > otherQuantity ? quantity - otherQuantity : otherQuantity - quantity;
            var largerTolerance = maxTolerance * 1.1;
            var smallerTolerance = maxTolerance / 1.1;
            Assert.True(quantity.Equals(quantity, {differenceResultType}.Zero));
            Assert.True(quantity.Equals(quantity, maxTolerance));
            Assert.True(quantity.Equals(otherQuantity, maxTolerance));
            Assert.True(quantity.Equals(otherQuantity, largerTolerance));
            Assert.False(quantity.Equals(otherQuantity, smallerTolerance));
        }}
");
                if (_quantity.IsAffine)
                {
                    Writer.WL($@"

        [Fact]
        public void Equals_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
        {{
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            {differenceResultType} negativeTolerance = quantity - {_quantity.Name}.From{_baseUnit.PluralName}(2);
            Assert.Throws<ArgumentOutOfRangeException>(() => quantity.Equals(quantity, negativeTolerance));
        }}
");
                }
                else  // vector quantities
                {
                    Writer.WL($@"

        [Fact]
        public void Equals_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
        {{
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(1);
            var negativeTolerance = {_quantity.Name}.From{_baseUnit.PluralName}(-1);
            Assert.Throws<ArgumentOutOfRangeException>(() => quantity.Equals(quantity, negativeTolerance));
        }}
");
                }
            }
            
            Writer.WL($@"

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {{
            var units = Enum.GetValues<{_unitEnumName}>();
            foreach (var unit in units)
            {{
                var defaultAbbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit);
            }}
        }}

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {{
            Assert.False({_quantity.Name}.BaseDimensions is null);
        }}

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {{
            using var _ = new CultureScope(""en-US"");");
            foreach (var unit in _quantity.Units)
            {
                Writer.WL($@"
            Assert.Equal(""1{GetEnglishAbbreviation(unit)}"", new {_quantity.Name}(1, {GetUnitFullName(unit)}).ToString());");
            }
            Writer.WL($@"
        }}

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {{
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo(""sv-SE"");
");
            foreach (var unit in _quantity.Units)
            {
                Writer.WL($@"
            Assert.Equal(""1{GetEnglishAbbreviation(unit)}"", new {_quantity.Name}(1, {GetUnitFullName(unit)}).ToString(swedishCulture));");
            }
            Writer.WL($@"
        }}

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {{
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal(""0.1{_baseUnitEnglishAbbreviation}"", new {_quantity.Name}(0.123456, {_baseUnitFullName}).ToString(""s1""));
            Assert.Equal(""0.12{_baseUnitEnglishAbbreviation}"", new {_quantity.Name}(0.123456, {_baseUnitFullName}).ToString(""s2""));
            Assert.Equal(""0.123{_baseUnitEnglishAbbreviation}"", new {_quantity.Name}(0.123456, {_baseUnitFullName}).ToString(""s3""));
            Assert.Equal(""0.1235{_baseUnitEnglishAbbreviation}"", new {_quantity.Name}(0.123456, {_baseUnitFullName}).ToString(""s4""));
        }}

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {{
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal(""0.1{_baseUnitEnglishAbbreviation}"", new {_quantity.Name}(0.123456, {_baseUnitFullName}).ToString(""s1"", culture));
            Assert.Equal(""0.12{_baseUnitEnglishAbbreviation}"", new {_quantity.Name}(0.123456, {_baseUnitFullName}).ToString(""s2"", culture));
            Assert.Equal(""0.123{_baseUnitEnglishAbbreviation}"", new {_quantity.Name}(0.123456, {_baseUnitFullName}).ToString(""s3"", culture));
            Assert.Equal(""0.1235{_baseUnitEnglishAbbreviation}"", new {_quantity.Name}(0.123456, {_baseUnitFullName}).ToString(""s4"", culture));
        }}

        [Theory]
        [InlineData(null)]
        [InlineData(""en-US"")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {{
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(1.0);
            CultureInfo formatProvider = cultureName == null
                ? null
                : CultureInfo.GetCultureInfo(cultureName);

            Assert.Equal(quantity.ToString(""G"", formatProvider), quantity.ToString(null, formatProvider));
        }}

        [Theory]
        [InlineData(null)]
        [InlineData(""g"")]
        public void ToString_NullProvider_EqualsCurrentCulture(string format)
        {{
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }}

        [Fact]
        public void GetHashCode_Equals()
        {{
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(1.0);
            Assert.Equal(Comparison.GetHashCode(quantity.Unit, quantity.Value), quantity.GetHashCode());
        }}
");

        if (!_quantity.IsAffine)
        {
                Writer.WL($@"
        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {{
            var quantity = {_quantity.Name}.From{_baseUnit.PluralName}(value);
            Assert.Equal({_quantity.Name}.From{_baseUnit.PluralName}(-value), -quantity);
        }}");
        }

        Writer.WL($@"
    }}
}}");
            return Writer.ToString();
        }

        private bool IsAmbiguousAbbreviation(Localization localization, string abbreviation)
        {
            return _quantity.Units.Count(u =>
                u.Localization.SingleOrDefault(l => l.Culture == localization.Culture) is { } otherUnitLocalization &&
                otherUnitLocalization.Abbreviations.Contains(abbreviation, StringComparer.OrdinalIgnoreCase)) > 1;
        }
    }
}
