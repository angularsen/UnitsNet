// Licensed under MIT No Attribution, see LICENSE file at the root.

extern alias Generated;
extern alias Legacy;
extern alias LegacyScenario;

using System.Reflection;
using Xunit;

namespace UnitsNet.Modular.Compatibility.Tests;

public sealed class CompatibilityTests
{
    private static readonly Assembly LegacyAssembly = typeof(Legacy::UnitsNet.Length).Assembly;
    private static readonly Assembly GeneratedAssembly = typeof(Generated::UnitsNet.Length).Assembly;

    public static IEnumerable<object[]> QuantityApis()
    {
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Length),
            typeof(Generated::UnitsNet.Length),
            "Meters",
            "Kilometers",
            "FromMeters",
            "FromKilometers",
            "op_Multiply");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Mass),
            typeof(Generated::UnitsNet.Mass),
            "Kilograms",
            "FromKilograms");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Duration),
            typeof(Generated::UnitsNet.Duration),
            "Seconds",
            "FromSeconds");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Area),
            typeof(Generated::UnitsNet.Area),
            "SquareMeters",
            "FromSquareMeters");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Speed),
            typeof(Generated::UnitsNet.Speed),
            "MetersPerSecond",
            "FromMetersPerSecond");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Acceleration),
            typeof(Generated::UnitsNet.Acceleration),
            "MetersPerSecondSquared",
            "FromMetersPerSecondSquared");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Force),
            typeof(Generated::UnitsNet.Force),
            "Newtons",
            "FromNewtons");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Pressure),
            typeof(Generated::UnitsNet.Pressure),
            "Pascals",
            "FromPascals");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Energy),
            typeof(Generated::UnitsNet.Energy),
            "Joules",
            "FromJoules");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Power),
            typeof(Generated::UnitsNet.Power),
            "Watts",
            "FromWatts");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Temperature),
            typeof(Generated::UnitsNet.Temperature),
            "DegreesCelsius",
            "DegreesFahrenheit",
            "FromDegreesCelsius",
            "FromDegreesFahrenheit",
            "op_Addition",
            "op_Subtraction");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.TemperatureDelta),
            typeof(Generated::UnitsNet.TemperatureDelta),
            "DegreesCelsius",
            "DegreesFahrenheit",
            "FromDegreesCelsius",
            "FromDegreesFahrenheit",
            "op_Addition",
            "op_Subtraction");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Level),
            typeof(Generated::UnitsNet.Level),
            "Decibels",
            "FromDecibels",
            "op_Addition");
        yield return QuantityApi(
            typeof(Legacy::UnitsNet.Information),
            typeof(Generated::UnitsNet.Information),
            "Bits",
            "Kibibytes",
            "FromBits",
            "FromKibibytes");
    }

    public static IEnumerable<object[]> UnitEnums()
    {
        yield return new object[]
        {
            typeof(Legacy::UnitsNet.Units.LengthUnit),
            typeof(Generated::UnitsNet.Units.LengthUnit),
        };
        yield return UnitEnum<Legacy::UnitsNet.Units.MassUnit, Generated::UnitsNet.Units.MassUnit>();
        yield return UnitEnum<Legacy::UnitsNet.Units.DurationUnit, Generated::UnitsNet.Units.DurationUnit>();
        yield return new object[]
        {
            typeof(Legacy::UnitsNet.Units.AreaUnit),
            typeof(Generated::UnitsNet.Units.AreaUnit),
        };
        yield return UnitEnum<Legacy::UnitsNet.Units.SpeedUnit, Generated::UnitsNet.Units.SpeedUnit>();
        yield return UnitEnum<Legacy::UnitsNet.Units.AccelerationUnit, Generated::UnitsNet.Units.AccelerationUnit>();
        yield return UnitEnum<Legacy::UnitsNet.Units.ForceUnit, Generated::UnitsNet.Units.ForceUnit>();
        yield return UnitEnum<Legacy::UnitsNet.Units.PressureUnit, Generated::UnitsNet.Units.PressureUnit>();
        yield return UnitEnum<Legacy::UnitsNet.Units.EnergyUnit, Generated::UnitsNet.Units.EnergyUnit>();
        yield return UnitEnum<Legacy::UnitsNet.Units.PowerUnit, Generated::UnitsNet.Units.PowerUnit>();
        yield return new object[]
        {
            typeof(Legacy::UnitsNet.Units.TemperatureUnit),
            typeof(Generated::UnitsNet.Units.TemperatureUnit),
        };
        yield return UnitEnum<
            Legacy::UnitsNet.Units.TemperatureDeltaUnit,
            Generated::UnitsNet.Units.TemperatureDeltaUnit>();
        yield return new object[]
        {
            typeof(Legacy::UnitsNet.Units.LevelUnit),
            typeof(Generated::UnitsNet.Units.LevelUnit),
        };
        yield return new object[]
        {
            typeof(Legacy::UnitsNet.Units.InformationUnit),
            typeof(Generated::UnitsNet.Units.InformationUnit),
        };
    }

    [Fact]
    public void LinkedConsumer_ProducesSameOutput()
    {
        string legacy = LegacyScenario::UnitsNet.Modular.Compatibility.CompatibilityScenario.Run();
        string generated = Generated::UnitsNet.Modular.Compatibility.CompatibilityScenario.Run();

        Assert.Equal(legacy, generated);
    }

    [Fact]
    public void GeneratedCatalog_ContainsEveryUnitsNetQuantity()
    {
        string[] legacy = GetQuantityTypes(LegacyAssembly).Select(type => type.FullName!).ToArray();
        string[] generated = GetQuantityTypes(GeneratedAssembly).Select(type => type.FullName!).ToArray();

        Assert.Equal(129, legacy.Length);
        Assert.Equal(legacy, generated);
    }

    [Fact]
    public void GeneratedCatalog_UnitEnumsMatchUnitsNet()
    {
        foreach (Type legacyQuantity in GetQuantityTypes(LegacyAssembly))
        {
            Type generatedQuantity = GeneratedAssembly.GetType(legacyQuantity.FullName!, throwOnError: true)!;
            Type legacyUnit = LegacyAssembly.GetType($"UnitsNet.Units.{legacyQuantity.Name}Unit", throwOnError: true)!;
            Type generatedUnit = GeneratedAssembly.GetType(
                $"UnitsNet.Units.{generatedQuantity.Name}Unit",
                throwOnError: true)!;

            string[] names = Enum.GetNames(legacyUnit).OrderBy(name => name, StringComparer.Ordinal).ToArray();
            Assert.Equal(names, Enum.GetNames(generatedUnit).OrderBy(name => name, StringComparer.Ordinal));
            Assert.All(
                names,
                name => Assert.Equal(
                    Convert.ToInt32(Enum.Parse(legacyUnit, name)),
                    Convert.ToInt32(Enum.Parse(generatedUnit, name))));
        }
    }

    [Fact]
    public void GeneratedCatalog_SiUnitSystemSelectionMatchesUnitsNet()
    {
        object legacySi = Legacy::UnitsNet.UnitSystem.SI;
        Type generatedUnitSystemType = GeneratedAssembly
            .GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Select(assembly => assembly.GetType("UnitsNet.UnitSystem"))
            .First(type => type is not null)!;
        object generatedSi = generatedUnitSystemType.GetProperty("SI")!.GetValue(null)!;

        foreach (Type legacyQuantity in GetQuantityTypes(LegacyAssembly))
        {
            Type generatedQuantity = GeneratedAssembly.GetType(legacyQuantity.FullName!, throwOnError: true)!;
            ConstructorInfo? legacyConstructor = legacyQuantity.GetConstructors()
                .SingleOrDefault(constructor =>
                {
                    ParameterInfo[] parameters = constructor.GetParameters();
                    return parameters.Length == 2 &&
                           parameters[1].ParameterType == typeof(Legacy::UnitsNet.UnitSystem);
                });
            if (legacyConstructor is null)
            {
                continue;
            }

            ConstructorInfo generatedConstructor = generatedQuantity.GetConstructor(
                new[] { typeof(double), generatedUnitSystemType })!;
            (object? legacyValue, Exception? legacyError) =
                InvokeUnitSystemConstructor(legacyConstructor, legacySi);
            (object? generatedValue, Exception? generatedError) =
                InvokeUnitSystemConstructor(generatedConstructor, generatedSi);

            Assert.Equal(legacyError?.GetType(), generatedError?.GetType());
            if (legacyError is not null)
            {
                continue;
            }

            Assert.Equal(
                legacyQuantity.GetProperty("Unit")!.GetValue(legacyValue)!.ToString(),
                generatedQuantity.GetProperty("Unit")!.GetValue(generatedValue)!.ToString());
        }
    }

    [Fact]
    public void GeneratedCatalog_BaseUnitMetadataMatchesUnitsNet()
    {
        foreach (Type legacyQuantity in GetQuantityTypes(LegacyAssembly))
        {
            Type generatedQuantity = GeneratedAssembly.GetType(legacyQuantity.FullName!, throwOnError: true)!;
            object legacyInfo = legacyQuantity.GetProperty("Info")!.GetValue(null)!;
            var legacyUnits = ((System.Collections.IEnumerable)typeof(Legacy::UnitsNet.QuantityInfo)
                    .GetProperty("UnitInfos")!
                    .GetValue(legacyInfo)!)
                .Cast<object>()
                .ToDictionary(
                    unit => (string)unit.GetType().GetProperty("Name")!.GetValue(unit)!,
                    unit => unit.GetType().GetProperty("BaseUnits")!.GetValue(unit)!.ToString()!,
                    StringComparer.Ordinal);
            object generatedInfo = generatedQuantity.GetProperty("Info")!.GetValue(null)!;
            var generatedUnits = ((System.Collections.IEnumerable)generatedInfo
                    .GetType()
                    .GetProperty("Units")!
                    .GetValue(generatedInfo)!)
                .Cast<object>()
                .ToDictionary(
                    unit => (string)unit.GetType().GetProperty("SingularName")!.GetValue(unit)!,
                    unit => unit.GetType().GetProperty("BaseUnits")!.GetValue(unit)!.ToString()!,
                    StringComparer.Ordinal);

            Assert.Equal(
                legacyUnits.OrderBy(pair => pair.Key, StringComparer.Ordinal),
                generatedUnits.OrderBy(pair => pair.Key, StringComparer.Ordinal));
        }
    }

    [Fact]
    public void GeneratedCatalog_PublicSurfaceHasOnlyDocumentedCompatibilityDifferences()
    {
        var unknownDifferences = new List<string>();
        foreach (Type legacyType in GetQuantityTypes(LegacyAssembly))
        {
            Type generatedType = GeneratedAssembly.GetType(legacyType.FullName!, throwOnError: true)!;
            HashSet<string> generatedSurface = GetCompleteSurface(generatedType);
            unknownDifferences.AddRange(
                GetCompleteSurface(legacyType)
                    .Except(generatedSurface)
                    .Where(signature => !IsDocumentedCompatibilityDifference(legacyType.Name, signature))
                    .Select(signature => $"{legacyType.Name}: {signature}"));
        }

        Assert.True(
            unknownDifferences.Count == 0,
            $"Undocumented compatibility differences:{Environment.NewLine}" +
            string.Join(Environment.NewLine, unknownDifferences.OrderBy(item => item, StringComparer.Ordinal)));
    }

    [Fact]
    public void GeneratedCatalog_IntentionalQuantityApiExclusionsAreCurrentAndReasoned()
    {
        foreach ((string quantityName, QuantityApiExclusion exclusion) in IntentionalQuantityApiExclusions)
        {
            Assert.False(string.IsNullOrWhiteSpace(exclusion.Reason));
            Type legacyType = LegacyAssembly.GetType($"UnitsNet.{quantityName}", throwOnError: true)!;
            Type generatedType = GeneratedAssembly.GetType($"UnitsNet.{quantityName}", throwOnError: true)!;
            HashSet<string> legacySurface = GetCompleteSurface(legacyType);
            HashSet<string> generatedSurface = GetCompleteSurface(generatedType);

            foreach (string memberName in exclusion.MemberNames)
            {
                Assert.Contains(legacySurface, signature => IsNamedMember(signature, memberName));
                Assert.DoesNotContain(generatedSurface, signature => IsNamedMember(signature, memberName));
            }
        }
    }

    [Fact]
    public void GeneratedCatalog_CompanionWrapperSurfacesMatchUnitsNet()
    {
        Assert.Equal(
            GetCompanionSurface(typeof(Legacy::UnitsNet.FeetInches)),
            GetCompanionSurface(typeof(Generated::UnitsNet.FeetInches)));
        Assert.Equal(
            GetCompanionSurface(typeof(Legacy::UnitsNet.StonePounds)),
            GetCompanionSurface(typeof(Generated::UnitsNet.StonePounds)));
        Assert.Equal(
            GetCompanionSurface(typeof(Legacy::UnitsNet.Wrappers.ReferencePressure)),
            GetCompanionSurface(typeof(Generated::UnitsNet.Wrappers.ReferencePressure)));
        Assert.Equal(
            Enum.GetNames<Legacy::UnitsNet.CustomCode.Units.PressureReference>(),
            Enum.GetNames<Generated::UnitsNet.CustomCode.Units.PressureReference>());
    }

    [Fact]
    public void GeneratedCatalog_ConversionsMatchUnitsNet()
    {
        const double value = 12.3456789;
        foreach (Type legacyQuantity in GetQuantityTypes(LegacyAssembly))
        {
            Type generatedQuantity = GeneratedAssembly.GetType(legacyQuantity.FullName!, throwOnError: true)!;
            Type legacyUnitType = LegacyAssembly.GetType(
                $"UnitsNet.Units.{legacyQuantity.Name}Unit",
                throwOnError: true)!;
            Type generatedUnitType = GeneratedAssembly.GetType(
                $"UnitsNet.Units.{generatedQuantity.Name}Unit",
                throwOnError: true)!;
            object legacyBaseUnit = legacyQuantity.GetProperty("BaseUnit")!.GetValue(null)!;
            object generatedBaseUnit = GetGeneratedBaseUnit(generatedQuantity);
            MethodInfo legacyAs = LegacyAssembly.GetType("UnitsNet.QuantityExtensions", throwOnError: true)!
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(method =>
                    method.Name == "As" &&
                    method.IsGenericMethodDefinition &&
                    method.GetGenericArguments().Length == 2 &&
                    method.GetParameters().Length == 2)
                .MakeGenericMethod(legacyQuantity, legacyUnitType);
            MethodInfo generatedAs = generatedQuantity.GetMethod("As", new[] { generatedUnitType })!;

            foreach (string unitName in Enum.GetNames(legacyUnitType))
            {
                object legacyUnit = Enum.Parse(legacyUnitType, unitName);
                object generatedUnit = Enum.Parse(generatedUnitType, unitName);
                object legacyValue = CreateQuantity(legacyQuantity, value, legacyUnit);
                object generatedValue = CreateQuantity(generatedQuantity, value, generatedUnit);
                AssertNearlyEqual(
                    NumericValue(legacyAs.Invoke(null, new[] { legacyValue, legacyBaseUnit })!),
                    NumericValue(generatedAs.Invoke(generatedValue, new[] { generatedBaseUnit })!),
                    $"{legacyQuantity.Name}.{unitName} to base");

                object legacyBaseValue = CreateQuantity(legacyQuantity, value, legacyBaseUnit);
                object generatedBaseValue = CreateQuantity(generatedQuantity, value, generatedBaseUnit);
                AssertNearlyEqual(
                    NumericValue(legacyAs.Invoke(null, new[] { legacyBaseValue, legacyUnit })!),
                    NumericValue(generatedAs.Invoke(generatedBaseValue, new[] { generatedUnit })!),
                    $"{legacyQuantity.Name}.{unitName} from base");
            }
        }
    }

    [Fact]
    public void GeneratedCatalog_BaseUnitFormattingAndParsingMatchUnitsNet()
    {
        const double value = 12.3456789;
        var invariant = System.Globalization.CultureInfo.InvariantCulture;
        foreach (Type legacyQuantity in GetQuantityTypes(LegacyAssembly))
        {
            Type generatedQuantity = GeneratedAssembly.GetType(legacyQuantity.FullName!, throwOnError: true)!;
            Type legacyUnitType = LegacyAssembly.GetType(
                $"UnitsNet.Units.{legacyQuantity.Name}Unit",
                throwOnError: true)!;
            Type generatedUnitType = GeneratedAssembly.GetType(
                $"UnitsNet.Units.{generatedQuantity.Name}Unit",
                throwOnError: true)!;
            object legacyBaseUnit = legacyQuantity.GetProperty("BaseUnit")!.GetValue(null)!;
            object generatedBaseUnit = GetGeneratedBaseUnit(generatedQuantity);
            object legacyValue = CreateQuantity(legacyQuantity, value, legacyBaseUnit);
            object generatedValue = CreateQuantity(generatedQuantity, value, generatedBaseUnit);
            string legacyText = ((IFormattable)legacyValue).ToString(null, invariant);
            string generatedText = ((IFormattable)generatedValue).ToString(null, invariant);
            Assert.Equal(legacyText, generatedText);

            MethodInfo generatedParse = generatedQuantity.GetMethod(
                "Parse",
                new[] { typeof(string), typeof(IFormatProvider) })!;
            object parsed = generatedParse.Invoke(null, new object?[] { legacyText, invariant })!;
            MethodInfo generatedAs = generatedQuantity.GetMethod("As", new[] { generatedUnitType })!;
            AssertNearlyEqual(
                value,
                (double)generatedAs.Invoke(parsed, new[] { generatedBaseUnit })!,
                $"{legacyQuantity.Name} formatted round trip");

            MethodInfo legacyAbbreviation = legacyQuantity.GetMethod(
                "GetAbbreviation",
                new[] { legacyUnitType, typeof(IFormatProvider) })!;
            MethodInfo generatedAbbreviation = generatedQuantity.GetMethod(
                "GetAbbreviation",
                new[] { generatedUnitType, typeof(IFormatProvider) })!;
            string expectedAbbreviation =
                (string)legacyAbbreviation.Invoke(null, new[] { legacyBaseUnit, invariant })!;
            string actualAbbreviation =
                (string)generatedAbbreviation.Invoke(null, new[] { generatedBaseUnit, invariant })!;
            Assert.Equal(expectedAbbreviation, actualAbbreviation);

            MethodInfo generatedParseUnit = generatedQuantity.GetMethod(
                "ParseUnit",
                new[] { typeof(string), typeof(IFormatProvider) })!;
            Assert.Equal(
                generatedBaseUnit,
                generatedParseUnit.Invoke(null, new object?[] { actualAbbreviation, invariant }));
        }
    }

    [Fact]
    public void GeneratedQuantity_LocalizedCustomFormattingMatchesUnitsNet()
    {
        var culture = System.Globalization.CultureInfo.GetCultureInfo("nb-NO");
        Legacy::UnitsNet.Length legacy = Legacy::UnitsNet.Length.FromMeters(1234.5);
        Generated::UnitsNet.Length generated = Generated::UnitsNet.Length.FromMeters(1234.5);

        string legacyText = legacy.ToString("F2", culture);
        string generatedText = generated.ToString("F2", culture);

        Assert.Equal(legacyText, generatedText);
        Assert.Equal(
            legacy.Meters.ToDouble(),
            Generated::UnitsNet.Length.Parse(generatedText, culture).Meters,
            12);
    }

    [Fact]
    public void GeneratedRegistry_DescribesAndOperatesOnTheConsumerOwnedCatalog()
    {
        QuantityRegistry registry = Generated::UnitsNet.GeneratedQuantityRegistry.Instance;

        Assert.Equal(129, registry.Quantities.Count);
        IQuantityDescriptor length = registry.Get(new QuantityId("UnitsNet.Length"));
        Assert.Same(length, registry.Get("length"));
        Assert.Same(length, registry.Get(typeof(Generated::UnitsNet.Length)));
        Assert.Equal("Meter", length.BaseUnitName);
        Assert.Equal(1, length.BaseDimensions.Length);
        Assert.Equal(1000, length.Convert(1, "Kilometer", "Meter"), 12);

        var created = Assert.IsType<Generated::UnitsNet.Length>(length.Create(1.5, "Kilometer"));
        var parsed = Assert.IsType<Generated::UnitsNet.Length>(
            length.Parse("1500 m", System.Globalization.CultureInfo.InvariantCulture));
        Assert.Equal(created.Meters, parsed.Meters, 12);

        foreach (Type generatedType in GetQuantityTypes(GeneratedAssembly))
        {
            IQuantityDescriptor descriptor = registry.Get(generatedType);
            Type legacyType = LegacyAssembly.GetType(generatedType.FullName!, throwOnError: true)!;
            object legacyDimensions = legacyType.GetProperty("BaseDimensions")!.GetValue(null)!;
            Assert.Equal(
                ReadDimensions(legacyDimensions),
                new[]
                {
                    descriptor.BaseDimensions.Length,
                    descriptor.BaseDimensions.Mass,
                    descriptor.BaseDimensions.Time,
                    descriptor.BaseDimensions.Current,
                    descriptor.BaseDimensions.Temperature,
                    descriptor.BaseDimensions.Amount,
                    descriptor.BaseDimensions.LuminousIntensity,
                });
            Assert.Equal(
                Enum.GetNames(generatedType.Assembly.GetType($"UnitsNet.Units.{generatedType.Name}Unit")!).Length,
                descriptor.Units.Count);
        }
    }

    [Fact]
    public void GeneratedRegistry_ReplacesCommonLegacyDynamicWorkflows()
    {
        QuantityRegistry registry = Generated::UnitsNet.GeneratedQuantityRegistry.Instance;
        var invariant = System.Globalization.CultureInfo.InvariantCulture;

        var legacyCreated = Assert.IsType<Legacy::UnitsNet.Length>(
            Legacy::UnitsNet.Quantity.From(1.5, "Length", "Kilometer"));
        var generatedCreated = Assert.IsType<Generated::UnitsNet.Length>(
            registry.Create(1.5, "Length", "Kilometer"));
        var generatedFromUnit = Assert.IsType<Generated::UnitsNet.Length>(
            registry.Create(1.5, Generated::UnitsNet.Units.LengthUnit.Kilometer));

        double legacyConverted = Legacy::UnitsNet.UnitConverter.ConvertByName(
            1.5,
            "Length",
            "Kilometer",
            "Meter");
        double generatedConverted = registry.Convert(
            1.5,
            "Length",
            "Kilometer",
            "Meter");
        double generatedConvertedFromUnits = registry.Convert(
            1.5,
            Generated::UnitsNet.Units.LengthUnit.Kilometer,
            Generated::UnitsNet.Units.LengthUnit.Meter);

        var legacyParsed = Assert.IsType<Legacy::UnitsNet.Length>(
            Legacy::UnitsNet.Quantity.Parse(invariant, typeof(Legacy::UnitsNet.Length), "1.5 km"));
        var generatedParsed = Assert.IsType<Generated::UnitsNet.Length>(
            registry.Parse(typeof(Generated::UnitsNet.Length), "1.5 km", invariant));

        Assert.Equal(legacyCreated.Meters, generatedCreated.Meters, 12);
        Assert.Equal(legacyCreated.Meters, generatedFromUnit.Meters, 12);
        Assert.Equal(legacyConverted, generatedConverted, 12);
        Assert.Equal(legacyConverted, generatedConvertedFromUnits, 12);
        Assert.Equal(legacyParsed.Meters, generatedParsed.Meters, 12);
        Assert.Equal(
            legacyCreated.ToString(null, invariant),
            registry.Get("Length").Format(generatedCreated, null, invariant));
        Assert.Same(
            registry.Get("Length"),
            registry.GetByUnitType(typeof(Generated::UnitsNet.Units.LengthUnit)));

        string[] legacyDimensionMatches = Legacy::UnitsNet.Quantity
            .GetQuantitiesWithBaseDimensions(Legacy::UnitsNet.Length.BaseDimensions)
            .Select(quantity => quantity.Name)
            .OrderBy(name => name, StringComparer.Ordinal)
            .ToArray();
        string[] generatedDimensionMatches = registry
            .FindByBaseDimensions(Generated::UnitsNet.Length.Info.BaseDimensions)
            .Select(quantity => quantity.Name)
            .OrderBy(name => name, StringComparer.Ordinal)
            .ToArray();
        Assert.Equal(legacyDimensionMatches, generatedDimensionMatches);
    }

    [Fact]
    public void GeneratedQuantityFacade_PreservesCommonLegacyCallShapes()
    {
        var invariant = System.Globalization.CultureInfo.InvariantCulture;

        Legacy::UnitsNet.IQuantity legacyByName =
            Legacy::UnitsNet.Quantity.From(1.5, "Length", "Kilometer");
        IQuantity<double> generatedByName =
            Generated::UnitsNet.Quantity.From(1.5, "Length", "Kilometer");
        Legacy::UnitsNet.IQuantity legacyByUnit =
            Legacy::UnitsNet.Quantity.From(1.5, Legacy::UnitsNet.Units.LengthUnit.Kilometer);
        IQuantity<double> generatedByUnit =
            Generated::UnitsNet.Quantity.From(
                1.5,
                Generated::UnitsNet.Units.LengthUnit.Kilometer);
        Legacy::UnitsNet.IQuantity legacyParsed =
            Legacy::UnitsNet.Quantity.Parse(invariant, typeof(Legacy::UnitsNet.Length), "1.5 km");
        IQuantity<double> generatedParsed =
            Generated::UnitsNet.Quantity.Parse(
                invariant,
                typeof(Generated::UnitsNet.Length),
                "1.5 km");

        Assert.Equal(
            Assert.IsType<Legacy::UnitsNet.Length>(legacyByName).Meters,
            Assert.IsType<Generated::UnitsNet.Length>(generatedByName).Meters,
            12);
        Assert.Equal(
            Assert.IsType<Legacy::UnitsNet.Length>(legacyByUnit).Meters,
            Assert.IsType<Generated::UnitsNet.Length>(generatedByUnit).Meters,
            12);
        Assert.Equal(
            Assert.IsType<Legacy::UnitsNet.Length>(legacyParsed).Meters,
            Assert.IsType<Generated::UnitsNet.Length>(generatedParsed).Meters,
            12);
        Assert.Equal(
            Legacy::UnitsNet.Quantity.Names.OrderBy(name => name, StringComparer.Ordinal),
            Generated::UnitsNet.Quantity.Names.OrderBy(name => name, StringComparer.Ordinal));
        Assert.Equal(
            Legacy::UnitsNet.Quantity.Infos.Select(info => info.Name).OrderBy(name => name, StringComparer.Ordinal),
            Generated::UnitsNet.Quantity.Infos.Select(info => info.Name).OrderBy(name => name, StringComparer.Ordinal));
        Assert.True(
            Generated::UnitsNet.Quantity.TryFrom(
                2,
                "Length",
                "Meter",
                out IQuantity<double>? generated));
        Assert.IsType<Generated::UnitsNet.Length>(generated);
    }

    [Fact]
    public void RepresentativeBehavior_MatchesUnitsNet()
    {
        var invariant = System.Globalization.CultureInfo.InvariantCulture;
        Legacy::UnitsNet.Length legacyLength = Legacy::UnitsNet.Length.Parse("1.5 km", invariant);
        Generated::UnitsNet.Length generatedLength = Generated::UnitsNet.Length.Parse("1.5 km", invariant);

        Assert.Equal(legacyLength.Meters, generatedLength.Meters, 12);
        Assert.Equal(legacyLength.ToString(null, invariant), generatedLength.ToString(null, invariant));
#pragma warning disable CS0618 // Deliberately compare UnitsNet's strict legacy equality semantics.
        Assert.Equal(
            Legacy::UnitsNet.Length.FromMeters(1500).Equals(Legacy::UnitsNet.Length.FromKilometers(1.5)),
            Generated::UnitsNet.Length.FromMeters(1500).Equals(Generated::UnitsNet.Length.FromKilometers(1.5)));
#pragma warning restore CS0618

        Legacy::UnitsNet.Temperature legacyFreezing = Legacy::UnitsNet.Temperature.FromDegreesCelsius(0);
        Legacy::UnitsNet.Temperature legacyBoiling = Legacy::UnitsNet.Temperature.FromDegreesFahrenheit(212);
        Generated::UnitsNet.Temperature generatedFreezing = Generated::UnitsNet.Temperature.FromDegreesCelsius(0);
        Generated::UnitsNet.Temperature generatedBoiling = Generated::UnitsNet.Temperature.FromDegreesFahrenheit(212);
        Assert.Equal(
            (legacyBoiling - legacyFreezing).DegreesCelsius,
            (generatedBoiling - generatedFreezing).DegreesCelsius,
            12);

        Legacy::UnitsNet.Level legacyLevel =
            Legacy::UnitsNet.Level.FromDecibels(10) + Legacy::UnitsNet.Level.FromDecibels(10);
        Generated::UnitsNet.Level generatedLevel =
            Generated::UnitsNet.Level.FromDecibels(10) + Generated::UnitsNet.Level.FromDecibels(10);
        Assert.Equal(legacyLevel.Decibels, generatedLevel.Decibels, 12);

        Legacy::UnitsNet.Area legacyCircle =
            Legacy::UnitsNet.Area.FromCircleDiameter(Legacy::UnitsNet.Length.FromMeters(4));
        Generated::UnitsNet.Area generatedCircle =
            Generated::UnitsNet.Area.FromCircleDiameter(Generated::UnitsNet.Length.FromMeters(4));
        Assert.Equal(legacyCircle.SquareMeters, generatedCircle.SquareMeters, 12);

        Legacy::UnitsNet.MassFraction legacyFraction =
            Legacy::UnitsNet.MassFraction.FromMasses(
                Legacy::UnitsNet.Mass.FromKilograms(2),
                Legacy::UnitsNet.Mass.FromPounds(10));
        Generated::UnitsNet.MassFraction generatedFraction =
            Generated::UnitsNet.MassFraction.FromMasses(
                Generated::UnitsNet.Mass.FromKilograms(2),
                Generated::UnitsNet.Mass.FromPounds(10));
        Assert.Equal(legacyFraction.DecimalFractions, generatedFraction.DecimalFractions, 12);
        Assert.Equal(
            legacyFraction.GetComponentMass(Legacy::UnitsNet.Mass.FromPounds(10)).Kilograms,
            generatedFraction.GetComponentMass(Generated::UnitsNet.Mass.FromPounds(10)).Kilograms,
            12);
        Assert.Equal(
            legacyFraction.GetTotalMass(Legacy::UnitsNet.Mass.FromKilograms(2)).Pounds,
            generatedFraction.GetTotalMass(Generated::UnitsNet.Mass.FromKilograms(2)).Pounds,
            12);

        Legacy::UnitsNet.Force legacyForce =
            Legacy::UnitsNet.Force.FromPressureByArea(
                Legacy::UnitsNet.Pressure.FromPascals(5),
                Legacy::UnitsNet.Area.FromSquareMeters(7));
        Generated::UnitsNet.Force generatedForce =
            Generated::UnitsNet.Force.FromPressureByArea(
                Generated::UnitsNet.Pressure.FromPascals(5),
                Generated::UnitsNet.Area.FromSquareMeters(7));
        Assert.Equal(legacyForce.Newtons, generatedForce.Newtons, 12);
        Assert.Equal(
            Legacy::UnitsNet.Mass.FromGravitationalForce(legacyForce).Kilograms,
            Generated::UnitsNet.Mass.FromGravitationalForce(generatedForce).Kilograms,
            12);

        Legacy::UnitsNet.AmountOfSubstance legacyAmount =
            Legacy::UnitsNet.AmountOfSubstance.FromMass(
                Legacy::UnitsNet.Mass.FromKilograms(2),
                Legacy::UnitsNet.MolarMass.FromKilogramsPerMole(0.5));
        Generated::UnitsNet.AmountOfSubstance generatedAmount =
            Generated::UnitsNet.AmountOfSubstance.FromMass(
                Generated::UnitsNet.Mass.FromKilograms(2),
                Generated::UnitsNet.MolarMass.FromKilogramsPerMole(0.5));
        Assert.Equal(legacyAmount.Moles, generatedAmount.Moles, 12);
        AssertNearlyEqual(
            legacyAmount.NumberOfParticles().ToDouble(),
            generatedAmount.NumberOfParticles(),
            "AmountOfSubstance.NumberOfParticles");

        Legacy::UnitsNet.Molarity legacyMolarity = Legacy::UnitsNet.Molarity.FromMolesPerCubicMeter(2);
        Generated::UnitsNet.Molarity generatedMolarity = Generated::UnitsNet.Molarity.FromMolesPerCubicMeter(2);
        Legacy::UnitsNet.MolarMass legacyMolarMass = Legacy::UnitsNet.MolarMass.FromKilogramsPerMole(0.018);
        Generated::UnitsNet.MolarMass generatedMolarMass =
            Generated::UnitsNet.MolarMass.FromKilogramsPerMole(0.018);
        Legacy::UnitsNet.Density legacyDensity = Legacy::UnitsNet.Density.FromKilogramsPerCubicMeter(1000);
        Generated::UnitsNet.Density generatedDensity =
            Generated::UnitsNet.Density.FromKilogramsPerCubicMeter(1000);
        Legacy::UnitsNet.MassConcentration legacyMassConcentration =
            Legacy::UnitsNet.MassConcentration.FromMolarity(legacyMolarity, legacyMolarMass);
        Generated::UnitsNet.MassConcentration generatedMassConcentration =
            Generated::UnitsNet.MassConcentration.FromMolarity(generatedMolarity, generatedMolarMass);
        Assert.Equal(
            legacyMassConcentration.KilogramsPerCubicMeter,
            generatedMassConcentration.KilogramsPerCubicMeter,
            12);
        Assert.Equal(
            legacyMassConcentration.ToMolarity(legacyMolarMass).MolesPerCubicMeter,
            generatedMassConcentration.ToMolarity(generatedMolarMass).MolesPerCubicMeter,
            12);
        Assert.Equal(
            legacyMolarity.ToMassConcentration(legacyMolarMass).KilogramsPerCubicMeter,
            generatedMolarity.ToMassConcentration(generatedMolarMass).KilogramsPerCubicMeter,
            12);

        Legacy::UnitsNet.VolumeConcentration legacyVolumeConcentration =
            legacyMassConcentration.ToVolumeConcentration(legacyDensity);
        Generated::UnitsNet.VolumeConcentration generatedVolumeConcentration =
            generatedMassConcentration.ToVolumeConcentration(generatedDensity);
        Assert.Equal(
            legacyVolumeConcentration.DecimalFractions,
            generatedVolumeConcentration.DecimalFractions,
            12);
        Assert.Equal(
            legacyVolumeConcentration.ToMassConcentration(legacyDensity).KilogramsPerCubicMeter,
            generatedVolumeConcentration.ToMassConcentration(generatedDensity).KilogramsPerCubicMeter,
            12);
        Assert.Equal(
            legacyVolumeConcentration.ToMolarity(legacyDensity, legacyMolarMass).MolesPerCubicMeter,
            generatedVolumeConcentration.ToMolarity(generatedDensity, generatedMolarMass).MolesPerCubicMeter,
            12);
        Assert.Equal(
            Legacy::UnitsNet.VolumeConcentration.FromVolumes(
                Legacy::UnitsNet.Volume.FromLiters(1),
                Legacy::UnitsNet.Volume.FromCubicMeters(1)).DecimalFractions,
            Generated::UnitsNet.VolumeConcentration.FromVolumes(
                Generated::UnitsNet.Volume.FromLiters(1),
                Generated::UnitsNet.Volume.FromCubicMeters(1)).DecimalFractions,
            12);
        Assert.Equal(
            Legacy::UnitsNet.Molarity.FromVolumeConcentration(
                legacyVolumeConcentration,
                legacyDensity,
                legacyMolarMass).MolesPerCubicMeter,
            Generated::UnitsNet.Molarity.FromVolumeConcentration(
                generatedVolumeConcentration,
                generatedDensity,
                generatedMolarMass).MolesPerCubicMeter,
            12);
        Assert.Equal(
            Legacy::UnitsNet.VolumeConcentration.FromMolarity(
                legacyMolarity,
                legacyDensity,
                legacyMolarMass).DecimalFractions,
            Generated::UnitsNet.VolumeConcentration.FromMolarity(
                generatedMolarity,
                generatedDensity,
                generatedMolarMass).DecimalFractions,
            12);

        Legacy::UnitsNet.ElectricApparentPower legacyApparentPower =
            Legacy::UnitsNet.ElectricApparentPower.FromVoltamperes(120);
        Generated::UnitsNet.ElectricApparentPower generatedApparentPower =
            Generated::UnitsNet.ElectricApparentPower.FromVoltamperes(120);
        Assert.Equal(
            (legacyApparentPower / Legacy::UnitsNet.ElectricPotential.FromVolts(12)).Amperes,
            (generatedApparentPower / Generated::UnitsNet.ElectricPotential.FromVolts(12)).Amperes,
            12);
        Assert.Equal(
            (legacyApparentPower / Legacy::UnitsNet.ElectricCurrent.FromAmperes(10)).Volts,
            (generatedApparentPower / Generated::UnitsNet.ElectricCurrent.FromAmperes(10)).Volts,
            12);

        Legacy::UnitsNet.Energy legacyCombustionEnergy =
            Legacy::UnitsNet.EnergyDensity.CombustionEnergy(
                Legacy::UnitsNet.EnergyDensity.FromJoulesPerCubicMeter(10),
                Legacy::UnitsNet.Volume.FromCubicMeters(3),
                Legacy::UnitsNet.Ratio.FromPercent(80));
        Generated::UnitsNet.Energy generatedCombustionEnergy =
            Generated::UnitsNet.EnergyDensity.CombustionEnergy(
                Generated::UnitsNet.EnergyDensity.FromJoulesPerCubicMeter(10),
                Generated::UnitsNet.Volume.FromCubicMeters(3),
                Generated::UnitsNet.Ratio.FromPercent(80));
        Assert.Equal(legacyCombustionEnergy.Joules, generatedCombustionEnergy.Joules, 12);

        Legacy::UnitsNet.ElectricPotential legacyPotential = Legacy::UnitsNet.ElectricPotential.FromVolts(2);
        Generated::UnitsNet.ElectricPotential generatedPotential =
            Generated::UnitsNet.ElectricPotential.FromVolts(2);
        Legacy::UnitsNet.AmplitudeRatio legacyAmplitude =
            Legacy::UnitsNet.AmplitudeRatio.FromElectricPotential(legacyPotential);
        Generated::UnitsNet.AmplitudeRatio generatedAmplitude =
            Generated::UnitsNet.AmplitudeRatio.FromElectricPotential(generatedPotential);
        Assert.Equal(legacyAmplitude.DecibelVolts, generatedAmplitude.DecibelVolts, 12);
        Assert.Equal(legacyAmplitude.ToElectricPotential().Volts, generatedAmplitude.ToElectricPotential().Volts, 12);
        Assert.Equal(
            legacyPotential.ToAmplitudeRatio().DecibelVolts,
            generatedPotential.ToAmplitudeRatio().DecibelVolts,
            12);

        Legacy::UnitsNet.Power legacyPower = Legacy::UnitsNet.Power.FromWatts(2);
        Generated::UnitsNet.Power generatedPower = Generated::UnitsNet.Power.FromWatts(2);
        Legacy::UnitsNet.PowerRatio legacyPowerRatio = Legacy::UnitsNet.PowerRatio.FromPower(legacyPower);
        Generated::UnitsNet.PowerRatio generatedPowerRatio = Generated::UnitsNet.PowerRatio.FromPower(generatedPower);
        Assert.Equal(legacyPowerRatio.DecibelWatts, generatedPowerRatio.DecibelWatts, 12);
        Assert.Equal(legacyPowerRatio.ToPower().Watts, generatedPowerRatio.ToPower().Watts, 12);
        Assert.Equal(legacyPower.ToPowerRatio().DecibelWatts, generatedPower.ToPowerRatio().DecibelWatts, 12);

        Legacy::UnitsNet.ElectricResistance legacyImpedance =
            Legacy::UnitsNet.ElectricResistance.FromOhms(50);
        Generated::UnitsNet.ElectricResistance generatedImpedance =
            Generated::UnitsNet.ElectricResistance.FromOhms(50);
        Assert.Equal(
            legacyAmplitude.ToPowerRatio(legacyImpedance).DecibelWatts,
            generatedAmplitude.ToPowerRatio(generatedImpedance).DecibelWatts,
            12);
        Assert.Equal(
            legacyPowerRatio.ToAmplitudeRatio(legacyImpedance).DecibelVolts,
            generatedPowerRatio.ToAmplitudeRatio(generatedImpedance).DecibelVolts,
            12);

        Assert.Equal(
            new Legacy::UnitsNet.Level(100, 1).Decibels,
            new Generated::UnitsNet.Level(100, 1).Decibels,
            12);
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new Generated::UnitsNet.AmplitudeRatio(Generated::UnitsNet.ElectricPotential.Zero));
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new Generated::UnitsNet.PowerRatio(Generated::UnitsNet.Power.Zero));

        Assert.Equal(
            Legacy::UnitsNet.Length.FromFeetInches(5, 6).Meters,
            Generated::UnitsNet.Length.FromFeetInches(5, 6).Meters,
            12);
        Assert.Equal(
            Legacy::UnitsNet.Mass.FromStonePounds(11, 4).Kilograms,
            Generated::UnitsNet.Mass.FromStonePounds(11, 4).Kilograms,
            12);

        Legacy::UnitsNet.FeetInches legacyFeetInches =
            Legacy::UnitsNet.Length.FromFeetInches(5, 6.625).FeetInches;
        Generated::UnitsNet.FeetInches generatedFeetInches =
            Generated::UnitsNet.Length.FromFeetInches(5, 6.625).FeetInches;
        Assert.Equal(
            legacyFeetInches.ToString(System.Globalization.CultureInfo.InvariantCulture),
            generatedFeetInches.ToString(System.Globalization.CultureInfo.InvariantCulture));
        Assert.Equal(
            legacyFeetInches.ToArchitecturalString(8),
            generatedFeetInches.ToArchitecturalString(8));

        Legacy::UnitsNet.StonePounds legacyStonePounds =
            Legacy::UnitsNet.Mass.FromStonePounds(11, 4).StonePounds;
        Generated::UnitsNet.StonePounds generatedStonePounds =
            Generated::UnitsNet.Mass.FromStonePounds(11, 4).StonePounds;
        Assert.Equal(
            legacyStonePounds.ToString(System.Globalization.CultureInfo.InvariantCulture),
            generatedStonePounds.ToString(System.Globalization.CultureInfo.InvariantCulture));

        var legacyReferencePressure = new Legacy::UnitsNet.Wrappers.ReferencePressure(
            Legacy::UnitsNet.Pressure.FromAtmospheres(3),
            Legacy::UnitsNet.CustomCode.Units.PressureReference.Gauge);
        var generatedReferencePressure = new Generated::UnitsNet.Wrappers.ReferencePressure(
            Generated::UnitsNet.Pressure.FromAtmospheres(3),
            Generated::UnitsNet.CustomCode.Units.PressureReference.Gauge);
        Assert.Equal(
            legacyReferencePressure.Absolute.Atmospheres,
            generatedReferencePressure.Absolute.Atmospheres,
            12);
        Assert.Equal(
            legacyReferencePressure.Vacuum.Atmospheres,
            generatedReferencePressure.Vacuum.Atmospheres,
            12);

        TimeSpan timeSpan = TimeSpan.FromMinutes(90);
        Legacy::UnitsNet.Duration legacyDuration = timeSpan;
        Generated::UnitsNet.Duration generatedDuration = timeSpan;
        Assert.Equal(legacyDuration.ToTimeSpan(), generatedDuration.ToTimeSpan());
        Assert.Equal(
            new DateTime(2026, 1, 1) + legacyDuration,
            new DateTime(2026, 1, 1) + generatedDuration);
        Assert.Equal(legacyDuration > TimeSpan.FromHours(1), generatedDuration > TimeSpan.FromHours(1));

        Assert.Equal(
            default(Legacy::UnitsNet.Length).Meters.ToDouble(),
            default(Generated::UnitsNet.Length).Meters);
        Assert.Throws<FormatException>(() => Legacy::UnitsNet.Length.Parse("not a length", invariant));
        Assert.Throws<FormatException>(() => Generated::UnitsNet.Length.Parse("not a length", invariant));
    }

    [Theory]
    [MemberData(nameof(QuantityApis))]
    public void GeneratedQuantity_ExposesCompatibleApiSubset(
        Type legacyType,
        Type generatedType,
        string[] quantitySpecificMembers)
    {
        string[] commonMembers =
        {
            "Value",
            "Unit",
            "Zero",
            "From",
            "As",
            "ToUnit",
            "Parse",
            "TryParse",
            "ToString",
        };
        var selectedNames = new HashSet<string>(commonMembers.Concat(quantitySpecificMembers));
        HashSet<string> legacySurface = GetSurface(legacyType, selectedNames);
        HashSet<string> generatedSurface = GetSurface(generatedType, selectedNames);

        Assert.NotEmpty(generatedSurface);
        string[] unexpected = generatedSurface
            .Except(legacySurface)
            .Where(member =>
                member != "M:ToString:System.String(System.IFormatProvider)" &&
                member != "M:ToString:System.String(System.String)" &&
                !member.StartsWith("M:As:", StringComparison.Ordinal) &&
                !member.StartsWith("M:ToUnit:", StringComparison.Ordinal) &&
                !member.Contains("UnitsNet.UnitSystem", StringComparison.Ordinal))
            .OrderBy(member => member, StringComparer.Ordinal)
            .ToArray();
        Assert.True(
            unexpected.Length == 0,
            $"Generated surface has incompatible members:{Environment.NewLine}{string.Join(Environment.NewLine, unexpected)}");
    }

    [Theory]
    [MemberData(nameof(UnitEnums))]
    public void GeneratedUnitEnum_MatchesUnitsNet(Type legacyType, Type generatedType)
    {
        string[] names = Enum.GetNames(legacyType).OrderBy(name => name, StringComparer.Ordinal).ToArray();
        Assert.Equal(names, Enum.GetNames(generatedType).OrderBy(name => name, StringComparer.Ordinal));
        Assert.All(
            names,
            name => Assert.Equal(
                Convert.ToInt32(Enum.Parse(legacyType, name)),
                Convert.ToInt32(Enum.Parse(generatedType, name))));
    }

    private static object[] QuantityApi(Type legacyType, Type generatedType, params string[] members) =>
        new object[] { legacyType, generatedType, members };

    private static object[] UnitEnum<TLegacy, TGenerated>() => new object[] { typeof(TLegacy), typeof(TGenerated) };

    private static HashSet<string> GetSurface(Type type, ISet<string> selectedNames)
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                                   BindingFlags.DeclaredOnly;
        IEnumerable<string> properties = type.GetProperties(flags)
            .Where(property => selectedNames.Contains(property.Name))
            .Select(property => $"P:{property.Name}:{TypeName(property.PropertyType)}");
        IEnumerable<string> methods = type.GetMethods(flags)
            .Where(method => selectedNames.Contains(method.Name))
            .Select(MethodSignature);
        return properties.Concat(methods).ToHashSet(StringComparer.Ordinal);
    }

    private static string MethodSignature(MethodInfo method)
    {
        string parameters = string.Join(",", method.GetParameters().Select(parameter => TypeName(parameter.ParameterType)));
        return $"M:{method.Name}:{TypeName(method.ReturnType)}({parameters})";
    }

    private static (object? Value, Exception? Error) InvokeUnitSystemConstructor(
        ConstructorInfo constructor,
        object unitSystem)
    {
        try
        {
            ParameterInfo numericParameter = constructor.GetParameters()[0];
            return (constructor.Invoke(new[] { ConvertNumeric(1d, numericParameter.ParameterType), unitSystem }), null);
        }
        catch (TargetInvocationException exception)
        {
            return (null, exception.InnerException ?? exception);
        }
    }

    private static string TypeName(Type type) =>
        IsLegacyQuantityValue(type) ? typeof(double).FullName! : type.FullName ?? type.Name;

    private static HashSet<string> GetCompleteSurface(Type type)
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                                   BindingFlags.DeclaredOnly;
        IEnumerable<string> constructors = type.GetConstructors(flags)
            .Select(constructor =>
                $"C:.ctor({string.Join(",", constructor.GetParameters().Select(parameter => StableTypeName(parameter.ParameterType)))})");
        IEnumerable<string> properties = type.GetProperties(flags)
            .Select(property => $"P:{property.Name}:{StableTypeName(property.PropertyType)}");
        IEnumerable<string> methods = type.GetMethods(flags)
            .Where(method => !method.IsSpecialName || method.Name.StartsWith("op_", StringComparison.Ordinal))
            .Select(method =>
                $"M:{method.Name}:{StableTypeName(method.ReturnType)}" +
                $"({string.Join(",", method.GetParameters().Select(parameter => StableTypeName(parameter.ParameterType)))})");
        return constructors.Concat(properties).Concat(methods).ToHashSet(StringComparer.Ordinal);
    }

    private static string[] GetCompanionSurface(Type type)
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                                   BindingFlags.DeclaredOnly;
        IEnumerable<string> fields = type.GetFields(flags)
            .Select(field => $"F:{field.Name}:{StableTypeName(field.FieldType)}");
        return GetCompleteSurface(type)
            .Concat(fields)
            .OrderBy(signature => signature, StringComparer.Ordinal)
            .ToArray();
    }

    private static bool IsDocumentedCompatibilityDifference(string quantityName, string signature)
    {
        if (signature.StartsWith("P:DefaultConversionFunctions:", StringComparison.Ordinal) ||
            signature.StartsWith("P:BaseDimensions:", StringComparison.Ordinal) ||
            signature.StartsWith("P:BaseUnit:", StringComparison.Ordinal) ||
            signature.StartsWith("P:QuantityInfo:", StringComparison.Ordinal) ||
            signature.StartsWith("P:Units:", StringComparison.Ordinal) ||
            signature.Contains("(UnitsNet.UnitKey)", StringComparison.Ordinal) ||
            signature.Contains("UnitsNet.UnitConverter", StringComparison.Ordinal) ||
            signature.Contains("UnitsNet.UnitSystem", StringComparison.Ordinal))
        {
            return true;
        }

        if (quantityName is "AmplitudeRatio" or "PowerRatio" or "Level" &&
            signature.Contains("System.Byte", StringComparison.Ordinal))
        {
            return true;
        }

        return IntentionalQuantityApiExclusions.TryGetValue(quantityName, out QuantityApiExclusion? exclusion) &&
               exclusion.MemberNames.Any(member => IsNamedMember(signature, member));
    }

    private static bool IsNamedMember(string signature, string memberName) =>
        signature.StartsWith($"P:{memberName}:", StringComparison.Ordinal) ||
        signature.StartsWith($"M:{memberName}:", StringComparison.Ordinal) ||
        signature.StartsWith($"C:{memberName}", StringComparison.Ordinal);

    private static string StableTypeName(Type type)
    {
        if (type.IsByRef)
        {
            return StableTypeName(type.GetElementType()!) + "&";
        }

        if (type.IsArray)
        {
            return StableTypeName(type.GetElementType()!) + "[]";
        }

        if (IsLegacyQuantityValue(type) || type == typeof(System.Numerics.BigInteger))
        {
            return typeof(double).FullName!;
        }

        if (!type.IsGenericType)
        {
            return type.FullName ?? type.Name;
        }

        string name = type.GetGenericTypeDefinition().FullName ?? type.Name;
        int arity = name.IndexOf('`');
        if (arity >= 0)
        {
            name = name.Substring(0, arity);
        }

        return $"{name}<{string.Join(",", type.GetGenericArguments().Select(StableTypeName))}>";
    }

    private static object CreateQuantity(Type quantityType, double value, object unit)
    {
        ConstructorInfo constructor = quantityType.GetConstructors()
            .Single(candidate =>
            {
                ParameterInfo[] parameters = candidate.GetParameters();
                return parameters.Length == 2 && parameters[1].ParameterType == unit.GetType();
            });
        return constructor.Invoke(new[] { ConvertNumeric(value, constructor.GetParameters()[0].ParameterType), unit });
    }

    private static object GetGeneratedBaseUnit(Type quantityType)
    {
        object info = quantityType.GetProperty("Info")!.GetValue(null)!;
        object baseUnit = info.GetType().GetProperty("BaseUnit")!.GetValue(info)!;
        return baseUnit.GetType().GetProperty("Value")!.GetValue(baseUnit)!;
    }

    private static object ConvertNumeric(double value, Type targetType)
    {
        if (targetType == typeof(double))
        {
            return value;
        }

        MethodInfo conversion = targetType.GetMethod(
            "op_Implicit",
            BindingFlags.Public | BindingFlags.Static,
            binder: null,
            new[] { typeof(double) },
            modifiers: null)
            ?? throw new InvalidOperationException($"No implicit double conversion exists for {targetType}.");
        return conversion.Invoke(null, new object[] { value })!;
    }

    private static double NumericValue(object value) =>
        value is double number ? number : Convert.ToDouble(value, System.Globalization.CultureInfo.InvariantCulture);

    private static bool IsLegacyQuantityValue(Type type) =>
        type.Assembly == LegacyAssembly &&
        string.Equals(type.FullName, "UnitsNet.QuantityValue", StringComparison.Ordinal);

    private static void AssertNearlyEqual(double expected, double actual, string operation)
    {
        if (double.IsNaN(expected) || double.IsInfinity(expected))
        {
            Assert.Equal(expected, actual);
            return;
        }

        double tolerance = Math.Max(1e-11, Math.Abs(expected) * 1e-11);
        Assert.True(
            Math.Abs(expected - actual) <= tolerance,
            $"{operation}: expected {expected:R}, actual {actual:R}, tolerance {tolerance:R}");
    }

    private static IReadOnlyDictionary<string, QuantityApiExclusion> IntentionalQuantityApiExclusions { get; } =
        new Dictionary<string, QuantityApiExclusion>(StringComparer.Ordinal)
        {
            ["Length"] = new(
                "The specialized compound parser depends on presentation-specific grammar outside ordinary quantity parsing.",
                "ParseFeetInches",
                "TryParseFeetInches"),
            ["Pressure"] = new(
                "Elevation conversion is an empirical atmosphere model, not immutable unit-conversion metadata.",
                "FromElevation",
                "ToElevation"),
        };

    private sealed class QuantityApiExclusion
    {
        public QuantityApiExclusion(string reason, params string[] memberNames)
        {
            Reason = reason;
            MemberNames = memberNames.ToHashSet(StringComparer.Ordinal);
        }

        public string Reason { get; }

        public IReadOnlySet<string> MemberNames { get; }
    }

    private static int[] ReadDimensions(object dimensions)
    {
        string[] names =
        {
            "Length",
            "Mass",
            "Time",
            "Current",
            "Temperature",
            "Amount",
            "LuminousIntensity",
        };
        return names
            .Select(name => (int)dimensions.GetType().GetProperty(name)!.GetValue(dimensions)!)
            .ToArray();
    }

    private static Type[] GetQuantityTypes(Assembly assembly) =>
        assembly.GetTypes()
            .Where(type =>
                type.Namespace == "UnitsNet" &&
                type.IsValueType &&
                !type.IsEnum &&
                assembly.GetType($"UnitsNet.Units.{type.Name}Unit") is not null)
            .OrderBy(type => type.FullName, StringComparer.Ordinal)
            .ToArray();
}
