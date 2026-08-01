// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Text.Json;
using Fictional.Measurements;
using UnitsNet;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Modular.Tests;

public sealed class GeneratedQuantityTests
{
    [Fact]
    public void GeneratedRegistry_SystemTextJsonRoundTripsBuiltInAndCustomQuantities()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(global::UnitsNet.Modular.Generated.GeneratedQuantityRegistry.JsonConverter);

        Length length = Length.FromKilometers(1.5);
        HowMuch amount = HowMuch.FromLots(2);

        Assert.Equal(length, JsonSerializer.Deserialize<Length>(JsonSerializer.Serialize(length, options), options));
        Assert.Equal(amount, JsonSerializer.Deserialize<HowMuch>(JsonSerializer.Serialize(amount, options), options));
    }

    [Theory]
    [InlineData("null")]
    [InlineData("{}")]
    [InlineData("""{"Value":1.5}""")]
    [InlineData("""{"Value":1.5,"Unit":"Missing"}""")]
    public void GeneratedRegistry_SystemTextJsonRejectsInvalidQuantityShapes(string json)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(global::UnitsNet.Modular.Generated.GeneratedQuantityRegistry.JsonConverter);

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Length>(json, options));
    }

    [Fact]
    public void GeneratedRegistry_SystemTextJsonDoesNotGuessPolymorphicQuantityTypes()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(global::UnitsNet.Modular.Generated.GeneratedQuantityRegistry.JsonConverter);

        Assert.Throws<NotSupportedException>(
            () => JsonSerializer.Deserialize<UnitsNet.Modular.IQuantity<double>>(
                """{"Value":1.5,"Unit":"Kilometer"}""",
                options));
    }

    [Fact]
    public void SystemTextJsonWithoutGeneratedConverterDoesNotUseTheStableStringUnitShape()
    {
        string json = JsonSerializer.Serialize(Length.FromKilometers(1.5));
        using JsonDocument document = JsonDocument.Parse(json);

        Assert.Equal(JsonValueKind.Number, document.RootElement.GetProperty("Unit").ValueKind);
    }

    [Fact]
    public void GeneratedRegistry_SupportsCommonDynamicMigrationWorkflows()
    {
        UnitsNet.Modular.QuantityRegistry registry = global::UnitsNet.Modular.Generated.GeneratedQuantityRegistry.Instance;
        var invariant = System.Globalization.CultureInfo.InvariantCulture;

        Assert.Same(registry.Get("Length"), registry.Get(typeof(Length)));
        Assert.Same(registry.Get("Length"), registry.Get(Length.Info.Id));
        Assert.Same(registry.Get("Length"), registry.GetByUnitType(typeof(LengthUnit)));

        var byName = Assert.IsType<Length>(registry.Create(3, "Length", "Centimeter"));
        var byUnit = Assert.IsType<Length>(registry.Create(1.5, LengthUnit.Kilometer));
        var parsed = Assert.IsType<Length>(registry.Parse(typeof(Length), "2 km", invariant));

        Assert.Equal(3, byName.Centimeters, 10);
        Assert.Equal(1500, byUnit.Meters, 10);
        Assert.Equal(2000, parsed.Meters, 10);
        Assert.Equal(1500, registry.Convert(1.5, "Length", "Kilometer", "Meter"), 10);
        Assert.Equal(1500, registry.Convert(1.5, LengthUnit.Kilometer, LengthUnit.Meter), 10);
        Assert.Equal(
            "1.5 km",
            registry.Get("Length").Format(byUnit, null, invariant));

        Assert.True(
            registry.TryCreate(
                2,
                "Length",
                "Meter",
                out UnitsNet.Modular.IQuantity<double>? created));
        Assert.IsType<Length>(created);
        Assert.True(registry.TryCreate(2, LengthUnit.Meter, out created));
        Assert.IsType<Length>(created);
        Assert.True(registry.TryConvert(2, "Length", "Kilometer", "Meter", out double converted));
        Assert.Equal(2000, converted, 10);
        Assert.True(registry.TryConvert(2, LengthUnit.Kilometer, LengthUnit.Meter, out converted));
        Assert.Equal(2000, converted, 10);
        Assert.True(
            registry.TryParse(
                typeof(Length),
                "2 km",
                invariant,
                out UnitsNet.Modular.IQuantity<double>? parsedValue));
        Assert.IsType<Length>(parsedValue);

        Assert.False(registry.TryCreate(2, "Missing", "Meter", out _));
        Assert.False(registry.TryCreate(2, "Length", "Missing", out _));
        Assert.False(registry.TryCreate(2, (LengthUnit)(-1), out _));
        Assert.False(registry.TryConvert(2, "Length", "Missing", "Meter", out _));
        Assert.False(registry.TryConvert(2, LengthUnit.Meter, MassUnit.Kilogram, out _));
        Assert.False(registry.TryParse(typeof(DateTime), "2 km", invariant, out _));
    }

    [Fact]
    public void GeneratedRegistry_FindsOnlySelectedQuantitiesWithMatchingDimensions()
    {
        UnitsNet.Modular.QuantityRegistry registry = global::UnitsNet.Modular.Generated.GeneratedQuantityRegistry.Instance;

        IReadOnlyList<UnitsNet.Modular.IQuantityDescriptor> matches =
            registry.FindByBaseDimensions(Length.Info.BaseDimensions);

        Assert.Contains(matches, descriptor => descriptor.QuantityType == typeof(Length));
        Assert.DoesNotContain(matches, descriptor => descriptor.QuantityType == typeof(Area));
        Assert.All(matches, descriptor => Assert.Equal(Length.Info.BaseDimensions, descriptor.BaseDimensions));
        Assert.Throws<NotSupportedException>(
            () => ((IList<UnitsNet.Modular.IQuantityDescriptor>)matches).Add(registry.Get("Area")));
    }

    [Fact]
    public void GeneratedQuantityFacade_ProvidesOwnerScopedDynamicApi()
    {
        var invariant = System.Globalization.CultureInfo.InvariantCulture;

        Assert.Same(global::UnitsNet.Modular.Generated.GeneratedQuantityRegistry.Instance, Quantity.Registry);
        Assert.Contains("Length", Quantity.Names);
        Assert.Same(Quantity.Registry.Get("Length"), Quantity.ByName["length"]);
        Assert.Contains(Quantity.Infos, descriptor => descriptor.QuantityType == typeof(Length));

        UnitsNet.Modular.IQuantity<double> byName = Quantity.From(1.5, "Length", "Kilometer");
        UnitsNet.Modular.IQuantity<double> bySystem =
            Quantity.From(1.5, "Length", UnitsNet.Modular.UnitSystem.SI);
        UnitsNet.Modular.IQuantity<double> byUnit = Quantity.From(1.5, LengthUnit.Kilometer);
        UnitsNet.Modular.IQuantity<double> parsed = Quantity.Parse(invariant, typeof(Length), "1.5 km");

        Assert.Equal(1500, Assert.IsType<Length>(byName).Meters, 10);
        Assert.Equal(1.5, Assert.IsType<Length>(bySystem).Meters, 10);
        Assert.Equal(1500, Assert.IsType<Length>(byUnit).Meters, 10);
        Assert.Equal(1500, Assert.IsType<Length>(parsed).Meters, 10);
        Assert.True(Quantity.TryFrom(2, "Length", "Meter", out UnitsNet.Modular.IQuantity<double>? created));
        Assert.IsType<Length>(created);
        Assert.True(Quantity.TryFrom(2, "Length", UnitsNet.Modular.UnitSystem.SI, out created));
        Assert.IsType<Length>(created);
        Assert.True(Quantity.TryFrom(2, LengthUnit.Meter, out created));
        Assert.IsType<Length>(created);
        Assert.True(Quantity.TryParse(typeof(Length), "2 km", out UnitsNet.Modular.IQuantity<double>? parsedValue));
        Assert.IsType<Length>(parsedValue);
        Assert.False(Quantity.TryFrom(2, "Missing", "Meter", out _));
        Assert.False(Quantity.TryParse(typeof(DateTime), "2 km", out _));
        Assert.Contains(
            Quantity.GetQuantitiesWithBaseDimensions(Length.Info.BaseDimensions),
            descriptor => descriptor.QuantityType == typeof(Length));
    }

    [Fact]
    public void DynamicQuantityContracts_DoNotExposeObjectValues()
    {
        Type[] contractTypes =
        {
            typeof(UnitsNet.Modular.IQuantityDescriptor),
            typeof(QuantityInfo<Length, LengthUnit>),
            typeof(UnitsNet.Modular.QuantityRegistry),
            typeof(Quantity),
        };
        string[] objectContracts = contractTypes
            .SelectMany(GetObjectContracts)
            .OrderBy(member => member, StringComparer.Ordinal)
            .ToArray();

        Assert.Empty(objectContracts);

        static IEnumerable<string> GetObjectContracts(Type type)
        {
            const System.Reflection.BindingFlags flags =
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.DeclaredOnly;
            IEnumerable<string> methods = type
                .GetMethods(flags)
                .Where(method =>
                    IsObject(method.ReturnType) ||
                    method.GetParameters().Any(parameter => IsObject(parameter.ParameterType)))
                .Select(method => $"{type.FullName}.{method}");
            IEnumerable<string> constructors = type
                .GetConstructors(flags)
                .Where(constructor =>
                    constructor.GetParameters().Any(parameter => IsObject(parameter.ParameterType)))
                .Select(constructor => $"{type.FullName}.{constructor}");
            IEnumerable<string> properties = type
                .GetProperties(flags)
                .Where(property => IsObject(property.PropertyType))
                .Select(property => $"{type.FullName}.{property}");
            return methods.Concat(constructors).Concat(properties);
        }

        static bool IsObject(Type type) =>
            (type.IsByRef ? type.GetElementType() : type) == typeof(object);
    }

    [Fact]
    public void GeneratedQuantity_InfoIsCanonicalAndImmutable()
    {
        UnitsNet.Modular.IQuantityDescriptor descriptor =
            global::UnitsNet.Modular.Generated.GeneratedQuantityRegistry.Instance.Get(typeof(Length));
        Length value = Length.FromKilometers(1.5);
        UnitInfo<LengthUnit> kilometer = Length.Info[LengthUnit.Kilometer];

        Assert.Same(Length.Info, descriptor);
        Assert.Same(Length.Info.Units, Length.Info.UnitInfos);
        Assert.Same(Length.Info.BaseUnit, Length.Info.BaseUnitInfo);
        Assert.Equal(LengthUnit.Meter, Length.Info.BaseUnit.Value);
        Assert.Equal(LengthUnit.Kilometer, kilometer.Value);
        Assert.Equal(kilometer.SingularName, kilometer.Name);
        Assert.Equal(kilometer.SingularName, kilometer.ToString());
        Assert.Equal(value, Length.From(1.5, kilometer.Value));
        Assert.True(Length.Info.TryGetUnitInfo(LengthUnit.Kilometer, out UnitInfo<LengthUnit>? found));
        Assert.Same(kilometer, found);
        Assert.Same(
            kilometer,
            Length.Info.GetUnitInfoFor(new UnitsNet.Modular.BaseUnits(length: "Kilometer")));
        Assert.Same(Length.Info.BaseUnit, Length.Info.GetUnit(UnitsNet.Modular.UnitSystem.SI));
        Assert.Throws<NotSupportedException>(
            () => ((IList<UnitInfo<LengthUnit>>)Length.Info.Units).Add(kilometer));

        Assert.Equal(
            System.ComponentModel.EditorBrowsableState.Never,
            typeof(UnitInfo<LengthUnit>)
                .GetProperty(nameof(UnitInfo<LengthUnit>.Name))!
                .GetCustomAttributes(typeof(System.ComponentModel.EditorBrowsableAttribute), inherit: false)
                .Cast<System.ComponentModel.EditorBrowsableAttribute>()
                .Single()
                .State);
    }

    [Fact]
    public void GeneratedQuantity_DoesNotDuplicateDescriptiveMetadata()
    {
        const System.Reflection.BindingFlags publicMembers =
            System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.Static;

        Assert.NotNull(typeof(Length).GetProperty(nameof(Length.Info), publicMembers));
        Assert.Null(typeof(Length).GetProperty("QuantityId", publicMembers));
        Assert.Null(typeof(Length).GetProperty("BaseUnit", publicMembers));
        Assert.Null(typeof(Length).GetProperty("BaseDimensions", publicMembers));
        Assert.Null(typeof(Length).GetProperty("Units", publicMembers));
        Assert.Null(typeof(Length).GetProperty("UnitInfos", publicMembers));
        Assert.Null(typeof(Length).GetProperty("QuantityInfo", publicMembers));

        AssertHidden(typeof(UnitsNet.Modular.IQuantityMetadata<>));
        AssertHidden(typeof(UnitsNet.Modular.QuantityOperations));
        AssertHidden(typeof(QuantityInfo<Length, LengthUnit>).GetConstructors().Single());
        AssertHidden(typeof(QuantityInfo<Length, LengthUnit>).GetProperty("BaseUnitInfo")!);
        AssertHidden(typeof(QuantityInfo<Length, LengthUnit>).GetProperty("UnitInfos")!);

        static void AssertHidden(System.Reflection.MemberInfo member) =>
            Assert.Equal(
                System.ComponentModel.EditorBrowsableState.Never,
                member.GetCustomAttributes(typeof(System.ComponentModel.EditorBrowsableAttribute), inherit: false)
                    .Cast<System.ComponentModel.EditorBrowsableAttribute>()
                    .Single()
                    .State);
    }

    [Fact]
    public void GeneratedRegistry_RetainsBaseUnitsAndResolvesImmutableUnitSystems()
    {
        UnitsNet.Modular.QuantityRegistry registry = global::UnitsNet.Modular.Generated.GeneratedQuantityRegistry.Instance;
        UnitsNet.Modular.IQuantityDescriptor length = registry.Get("Length");
        UnitsNet.Modular.IQuantityDescriptor force = registry.Get("Force");
        UnitsNet.Modular.IQuantityDescriptor density = registry.Get("Density");
        UnitsNet.Modular.IQuantityDescriptor information = registry.Get("Information");

        Assert.Equal(
            new UnitsNet.Modular.BaseUnits(length: "Meter"),
            length.Units.Single(unit => unit.Name == "Meter").BaseUnits);
        Assert.Equal(
            new UnitsNet.Modular.BaseUnits(length: "Kilometer"),
            length.Units.Single(unit => unit.Name == "Kilometer").BaseUnits);
        Assert.Equal(
            new UnitsNet.Modular.BaseUnits(length: "Meter", mass: "Kilogram", time: "Second"),
            force.Units.Single(unit => unit.Name == "Newton").BaseUnits);
        Assert.Equal(
            new UnitsNet.Modular.BaseUnits(length: "Meter", mass: "Kilogram"),
            density.Units.Single(unit => unit.Name == "KilogramPerCubicMeter").BaseUnits);

        Assert.Equal("Meter", length.GetUnit(UnitsNet.Modular.UnitSystem.SI).Name);
        Assert.Equal("Newton", force.GetUnit(UnitsNet.Modular.UnitSystem.SI).Name);
        Assert.Equal("KilogramPerCubicMeter", density.GetUnit(UnitsNet.Modular.UnitSystem.SI).Name);
        Assert.Equal(information.BaseUnitName, information.GetUnit(UnitsNet.Modular.UnitSystem.SI).Name);

        var imperialLength = new UnitsNet.Modular.UnitSystem(
            new UnitsNet.Modular.BaseUnits(length: "Foot"));
        Assert.Equal("Foot", length.GetUnit(imperialLength).Name);
        Assert.True(length.TryGetUnit(imperialLength, out UnitsNet.Modular.UnitDescriptor? selected));
        Assert.Equal("Foot", selected!.Name);
        Assert.Equal(LengthUnit.Meter, new Length(2, UnitsNet.Modular.UnitSystem.SI).Unit);
        Assert.Equal(LengthUnit.Meter, Length.From(2, UnitsNet.Modular.UnitSystem.SI).Unit);
        Assert.Equal(ForceUnit.Newton, new Force(2, UnitsNet.Modular.UnitSystem.SI).Unit);
        Assert.Equal(Information.Info.BaseUnit.Value, new Information(2, UnitsNet.Modular.UnitSystem.SI).Unit);
        Assert.Equal(LengthUnit.Foot, new Length(2, imperialLength).Unit);
        Assert.Equal(1000, Length.FromKilometers(1).As(UnitsNet.Modular.UnitSystem.SI), 10);
        Assert.Equal(LengthUnit.Meter, Length.FromKilometers(1).ToUnit(UnitsNet.Modular.UnitSystem.SI).Unit);

        var registryValue = Assert.IsType<Length>(
            registry.Create(2, "Length", UnitsNet.Modular.UnitSystem.SI));
        Assert.Equal(LengthUnit.Meter, registryValue.Unit);
        Assert.Equal(
            1000,
            registry.Convert(1, "Length", "Kilometer", UnitsNet.Modular.UnitSystem.SI),
            10);
        Assert.True(
            registry.TryCreate(
                2,
                "Length",
                UnitsNet.Modular.UnitSystem.SI,
                out UnitsNet.Modular.IQuantity<double>? created));
        Assert.IsType<Length>(created);
        Assert.True(
            registry.TryConvert(
                1,
                "Length",
                "Kilometer",
                UnitsNet.Modular.UnitSystem.SI,
                out double converted));
        Assert.Equal(1000, converted, 10);

        var unavailable = new UnitsNet.Modular.UnitSystem(
            new UnitsNet.Modular.BaseUnits(length: "Smoot"));
        Assert.False(length.TryGetUnit(unavailable, out _));
        Assert.Throws<ArgumentException>(() => length.GetUnit(unavailable));
        Assert.Throws<ArgumentException>(() => new Length(2, unavailable));
        Assert.Throws<ArgumentException>(() => Length.FromMeters(2).As(unavailable));
        Assert.False(registry.TryCreate(2, "Length", unavailable, out _));
        Assert.False(registry.TryConvert(2, "Length", "Meter", unavailable, out _));
        Assert.False(Quantity.TryFrom(2, "Length", unavailable, out _));
        Assert.Throws<ArgumentException>(() => new UnitsNet.Modular.UnitSystem(UnitsNet.Modular.BaseUnits.Undefined));
        Assert.True(
            new UnitsNet.Modular.BaseUnits(length: "Meter", time: "Second")
                .IsSubsetOf(UnitsNet.Modular.UnitSystem.SI.BaseUnits));
        Assert.False(
            new UnitsNet.Modular.BaseUnits(length: "Foot")
                .IsSubsetOf(UnitsNet.Modular.UnitSystem.SI.BaseUnits));
    }

    [Fact]
    public void ConversionAndParsing_ReuseRuntimeBehavior()
    {
        Length distance = Length.Parse("1.5 km");

        Assert.Equal(1500, distance.Meters, 10);
        Assert.Equal(150_000, distance.Centimeters, 10);
        Assert.Equal("1.5 km", distance.ToString(null, System.Globalization.CultureInfo.InvariantCulture));
    }

    [Fact]
    public void UnitPattern_ExcludesNonMatchingUnit()
    {
        string[] names = Enum.GetNames<InformationUnit>();

        Assert.Contains("Bit", names);
        Assert.Contains("Byte", names);
        Assert.Contains("Kilobyte", names);
        Assert.Contains("Kibibyte", names);
        Assert.DoesNotContain("Octet", names);
        Assert.DoesNotContain("Kibioctet", names);
    }

    [Fact]
    public void DerivedOperators_AppearWhenAllQuantitiesAreSelected()
    {
        Area area = Length.FromMeters(2) * Length.FromMeters(4);

        Assert.Equal(8, area.SquareMeters, 10);
    }

    [Fact]
    public void BuiltInAugmentation_CalculatesCircleAreaFromLength()
    {
        Area fromDiameter = Area.FromCircleDiameter(Length.FromMeters(4));
        Area fromRadius = Area.FromCircleRadius(Length.FromCentimeters(200));

        Assert.Equal(4 * Math.PI, fromDiameter.SquareMeters, 12);
        Assert.Equal(fromDiameter, fromRadius);
    }

    [Fact]
    public void BuiltInRelations_GenerateCommutativeAndInferredOperators()
    {
        Mass mass = Mass.FromKilograms(3);
        Acceleration acceleration = Acceleration.FromMetersPerSecondSquared(4);

        Force forward = mass * acceleration;
        Force reversed = acceleration * mass;

        Assert.Equal(12, forward.Newtons, 10);
        Assert.Equal(forward, reversed);
        Assert.Equal(mass, forward / acceleration);
        Assert.Equal(acceleration, forward / mass);
    }

    [Fact]
    public void RepresentativeCatalog_SupportsAffineLogarithmicAndBinaryConversions()
    {
        Temperature boiling = Temperature.FromDegreesCelsius(100);
        Level combined = Level.FromDecibels(10) + Level.FromDecibels(10);
        Information data = Information.FromKibibytes(2);

        Assert.Equal(373.15, boiling.Kelvins, 10);
        Assert.Equal(212, boiling.DegreesFahrenheit, 10);
        Assert.Equal(13.010299956639813, combined.Decibels, 10);
        Assert.Equal(16_384, data.Bits, 10);
    }

    [Fact]
    public void BuiltInDefinition_PreservesLocalizedAbbreviations()
    {
        var russian = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");

        Length length = Length.Parse("2 м", russian);

        Assert.Equal(2, length.Meters, 10);
        Assert.Equal("2 м", length.ToString(null, russian));
    }

    [Fact]
    public void Parsing_DistinguishesCaseSensitiveSiPrefixes()
    {
        Length millimeters = Length.Parse("2 mm", System.Globalization.CultureInfo.InvariantCulture);
        Length megameters = Length.Parse("2 Mm", System.Globalization.CultureInfo.InvariantCulture);

        Assert.Equal(0.002, millimeters.Meters, 10);
        Assert.Equal(2_000_000, megameters.Meters, 10);
    }

    [Fact]
    public void CustomQuantity_GetsSameGeneratedSurfaceInOwnNamespace()
    {
        HowMuch amount = HowMuch.Parse("10 tons");

        Assert.Equal(200, amount.Some, 10);
        Assert.Equal(100, amount.Lots, 10);
        Assert.Equal("Fictional.Measurements.HowMuch", typeof(HowMuch).FullName);
    }

    [Fact]
    public void CustomRelationFile_GeneratesRelationshipOperator()
    {
        HowMuch product = HowMuch.FromSome(2) * HowMuch.FromSome(3);

        Assert.Equal(6, product.Lots, 10);
        Assert.Equal(12, product.Some, 10);
    }

    [Fact]
    public void JsonDefinition_SupportsPrefixesLocalizationAndNonlinearConversions()
    {
        var norwegian = System.Globalization.CultureInfo.GetCultureInfo("nb-NO");

        HowMuch localized = HowMuch.Parse("10 tonnevis", norwegian);
        HowMuch nonlinear = HowMuch.FromMagnitudes(3);
        HowMuch prefixed = HowMuch.FromKilosome(2);
        HowMuch alternatePrefixed = HowMuch.Parse("2 kn", norwegian);

        Assert.Equal(200, localized.Some, 10);
        Assert.Equal("10 tonnevis", localized.ToString(null, norwegian));
        Assert.Equal(9, nonlinear.Some, 10);
        Assert.Equal(3, nonlinear.Magnitudes, 10);
        Assert.Equal(2000, prefixed.Some, 10);
        Assert.Equal(2000, alternatePrefixed.Some, 10);
        Assert.Equal("2 knoe", prefixed.ToString(null, norwegian));
    }

    [Fact]
    public void Net10GeneratedQuantities_SupportGenericParsingAndMath()
    {
        Length parsed = Parse<Length>("1.5 km");
        Length total = Add(parsed, Length.FromMeters(500));

        Assert.Equal(2, total.Kilometers, 10);
    }

    [Fact]
    public void GeneratedQuantity_ImplementsMinimalSelfTypedModularContract()
    {
        Assert.Equal(new UnitsNet.Modular.QuantityId("UnitsNet.Length"), Length.Info.Id);
        Assert.Equal(LengthUnit.Meter, Length.Info.BaseUnit.Value);

        Length length = Create<Length, LengthUnit>(2, LengthUnit.Meter);
        UnitsNet.Modular.IQuantity<Length, LengthUnit> stored = length;
        UnitsNet.Modular.IQuantity<double> erased = length;
        Assert.Equal(2d, stored.Value);
        Assert.Equal(LengthUnit.Meter, stored.Unit);
        Assert.Equal(LengthUnit.Meter, erased.Unit);
        Assert.Equal(1000, ConvertValue<Length, LengthUnit>(1, LengthUnit.Kilometer, LengthUnit.Meter), 10);
        Assert.Equal(1000, Length.FromKilometers(1).As(LengthUnit.Meter), 10);

        const System.Reflection.BindingFlags publicMembers =
            System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.Static;
        Assert.Null(typeof(Length).GetProperty("BaseValue", publicMembers));
        Assert.Null(typeof(Length).GetProperty("UnitName", publicMembers));
    }

    [Fact]
    public void QuantityId_RequiresANonEmptyValue()
    {
        Assert.Throws<ArgumentNullException>(() => new UnitsNet.Modular.QuantityId(null!));
        Assert.Throws<ArgumentException>(() => new UnitsNet.Modular.QuantityId(" "));
        Assert.Equal("Sample.Distance", new UnitsNet.Modular.QuantityId("Sample.Distance").Value);
    }

    [Fact]
    public void GeneratedQuantities_AdvertiseTheirArithmeticCapabilities()
    {
        AssertLinearCapability<Length, LengthUnit>();
        AssertLinearCapability<TemperatureDelta, TemperatureDeltaUnit>();
        AssertAffineCapability<Temperature, TemperatureUnit, TemperatureDelta>();
        AssertLogarithmicCapability<Level, LevelUnit>();
        Assert.DoesNotContain(
            typeof(Temperature).GetInterfaces(),
            type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(UnitsNet.Modular.ILinearQuantity<>));
        Assert.DoesNotContain(
            typeof(Level).GetInterfaces(),
            type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(UnitsNet.Modular.ILinearQuantity<>));
    }

    [Theory]
    [InlineData(0d)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void LinearQuantity_ConversionPreservesZeroAndNonFiniteValues(double meters)
    {
        double kilometers = Length.FromMeters(meters).Kilometers;
        double roundTrip = Length.FromKilometers(kilometers).Meters;

        if (double.IsNaN(meters))
        {
            Assert.True(double.IsNaN(kilometers));
            Assert.True(double.IsNaN(roundTrip));
            return;
        }

        Assert.Equal(meters / 1000d, kilometers);
        Assert.Equal(meters, roundTrip);
    }

    [Fact]
    public void AffineQuantity_UsesLinearOffsetsAndSupportsGenericAverage()
    {
        Temperature freezing = Temperature.FromDegreesCelsius(0);
        Temperature boiling = Temperature.FromDegreesFahrenheit(212);

        TemperatureDelta interval = Difference<Temperature, TemperatureUnit, TemperatureDelta>(boiling, freezing);
        Temperature raised = AddOffset<Temperature, TemperatureUnit, TemperatureDelta>(freezing, interval);
        Temperature commutative = interval + freezing;
        Temperature lowered = boiling - interval;
        Temperature average = new[] { freezing, boiling }.Average(TemperatureUnit.DegreeCelsius);

        Assert.Equal(100, interval.DegreesCelsius, 10);
        Assert.Equal(100, raised.DegreesCelsius, 10);
        Assert.Equal(100, commutative.DegreesCelsius, 10);
        Assert.Equal(0, lowered.DegreesCelsius, 10);
        Assert.Equal(50, average.DegreesCelsius, 10);
        Assert.True(freezing.Equals(
            Temperature.FromDegreesCelsius(0.05),
            TemperatureDelta.FromDegreesCelsius(0.1)));
        Assert.False(freezing.Equals(
            Temperature.FromDegreesCelsius(0.2),
            TemperatureDelta.FromDegreesCelsius(0.1)));
        Assert.Throws<InvalidOperationException>(() =>
            Array.Empty<Temperature>().Average(TemperatureUnit.Kelvin));
    }

    [Fact]
    public void FirstUnitAggregations_DoNotMaterializeInputSequences()
    {
        var temperatures = new NonMaterializableCollection<Temperature>(
            Temperature.FromDegreesCelsius(10),
            Temperature.FromDegreesCelsius(30));
        var levels = new NonMaterializableCollection<Level>(
            Level.FromDecibels(10),
            Level.FromDecibels(20));

        Temperature temperatureAverage = temperatures.Average();
        Level levelSum = levels.Sum();
        Level arithmeticMean = levels.ArithmeticMean();
        Level geometricMean = levels.GeometricMean();

        Assert.Equal(TemperatureUnit.DegreeCelsius, temperatureAverage.Unit);
        Assert.Equal(LevelUnit.Decibel, levelSum.Unit);
        Assert.Equal(LevelUnit.Decibel, arithmeticMean.Unit);
        Assert.Equal(LevelUnit.Decibel, geometricMean.Unit);
        Assert.Throws<InvalidOperationException>(() => Array.Empty<Temperature>().Average());
        Assert.Throws<InvalidOperationException>(() => Array.Empty<Level>().Sum());
    }

    [Fact]
    public void QuantityMath_SumsAndAveragesMixedUnits()
    {
        Length sum = UnitsNet.Modular.QuantityMath.Sum(new[]
        {
            Length.FromKilometers(1),
            Length.FromMeters(500),
        });
        Length targetedSum = UnitsNet.Modular.QuantityMath.Sum(
            new[] { Length.FromKilometers(1), Length.FromMeters(500) },
            LengthUnit.Meter);
        Length average = UnitsNet.Modular.QuantityMath.Average(new[]
        {
            Length.FromMeters(1),
            Length.FromCentimeters(300),
        });
        Length targetedAverage = UnitsNet.Modular.QuantityMath.Average(
            new[] { Length.FromMeters(1), Length.FromCentimeters(300) },
            LengthUnit.Centimeter);

        Assert.Equal(1.5, sum.Kilometers, 10);
        Assert.Equal(1500, targetedSum.Meters, 10);
        Assert.Equal(2, average.Meters, 10);
        Assert.Equal(200, targetedAverage.Centimeters, 10);
        Assert.Equal(Length.Zero, UnitsNet.Modular.QuantityMath.Sum(Array.Empty<Length>()));
    }

    [Fact]
    public void DefaultQuantity_UsesBaseUnitLikeUnitsNet()
    {
        Length value = default;

        Assert.Equal(LengthUnit.Meter, value.Unit);
        Assert.Equal(0, value.Meters);
        Assert.Equal(Length.Zero, value);
        Assert.Equal(Length.Zero.GetHashCode(), value.GetHashCode());
        Assert.Equal("0 m", value.ToString(null, System.Globalization.CultureInfo.InvariantCulture));
    }

    private static T Parse<T>(string text)
        where T : IParsable<T>
        => T.Parse(text, System.Globalization.CultureInfo.InvariantCulture);

    private static T Add<T>(T left, T right)
        where T : System.Numerics.IAdditionOperators<T, T, T>
        => left + right;

    private static TQuantity Create<TQuantity, TUnit>(double value, TUnit unit)
        where TQuantity : UnitsNet.Modular.IQuantity<TQuantity, TUnit, double>
        where TUnit : struct, Enum
        => TQuantity.From(value, unit);

    private static double ConvertValue<TQuantity, TUnit>(double value, TUnit fromUnit, TUnit toUnit)
        where TQuantity : UnitsNet.Modular.IQuantity<TQuantity, TUnit, double>
        where TUnit : struct, Enum
        => TQuantity.Convert(value, fromUnit, toUnit);

    private static void AssertLinearCapability<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Modular.ILinearQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
        => Assert.Equal(TQuantity.Info.BaseUnit.Value, TQuantity.Zero.Unit);

    private static void AssertAffineCapability<TQuantity, TUnit, TOffset>()
        where TQuantity : UnitsNet.Modular.IAffineQuantity<TQuantity, TUnit, TOffset>
        where TUnit : struct, Enum
        where TOffset : UnitsNet.Modular.ILinearQuantity<TOffset>
        => Assert.Contains(
            typeof(UnitsNet.Modular.IAffineQuantity<TQuantity, TUnit, TOffset>),
            typeof(TQuantity).GetInterfaces());

    private static TQuantity AddOffset<TQuantity, TUnit, TOffset>(TQuantity quantity, TOffset offset)
        where TQuantity : UnitsNet.Modular.IAffineQuantity<TQuantity, TUnit, TOffset>
        where TUnit : struct, Enum
        where TOffset : UnitsNet.Modular.ILinearQuantity<TOffset>
        => quantity + offset;

    private static TOffset Difference<TQuantity, TUnit, TOffset>(TQuantity left, TQuantity right)
        where TQuantity : UnitsNet.Modular.IAffineQuantity<TQuantity, TUnit, TOffset>
        where TUnit : struct, Enum
        where TOffset : UnitsNet.Modular.ILinearQuantity<TOffset>
        => left - right;

    private static void AssertLogarithmicCapability<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Modular.ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
        => Assert.Equal(TQuantity.Info.BaseUnit.Value, TQuantity.Zero.Unit);

    private sealed class NonMaterializableCollection<T>(params T[] values) : ICollection<T>
    {
        public int Count => values.Length;

        public bool IsReadOnly => true;

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)values).GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(T item) => values.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) =>
            throw new InvalidOperationException("The aggregation attempted to materialize its input.");

        public void Add(T item) => throw new NotSupportedException();

        public void Clear() => throw new NotSupportedException();

        public bool Remove(T item) => throw new NotSupportedException();
    }
}
