// Licensed under MIT No Attribution, see LICENSE file at the root.

extern alias Generated;
extern alias Legacy;
extern alias LegacyScenario;

using System.Reflection;
using Xunit;

namespace UnitsNetGen.Compatibility.Tests;

public sealed class CompatibilityTests
{
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
            "FromDegreesFahrenheit");
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
        string legacy = LegacyScenario::UnitsNetGen.Compatibility.CompatibilityScenario.Run();
        string generated = Generated::UnitsNetGen.Compatibility.CompatibilityScenario.Run();

        Assert.Equal(legacy, generated);
    }

    [Fact]
    public void BothImplementations_ImplementSharedCoreContract()
    {
        Type contract = typeof(UnitsNet.Core.IQuantity<double>);
        Type[] legacyTypes =
        {
            typeof(Legacy::UnitsNet.Length),
            typeof(Legacy::UnitsNet.Mass),
            typeof(Legacy::UnitsNet.Duration),
            typeof(Legacy::UnitsNet.Area),
            typeof(Legacy::UnitsNet.Speed),
            typeof(Legacy::UnitsNet.Acceleration),
            typeof(Legacy::UnitsNet.Force),
            typeof(Legacy::UnitsNet.Pressure),
            typeof(Legacy::UnitsNet.Energy),
            typeof(Legacy::UnitsNet.Power),
            typeof(Legacy::UnitsNet.Temperature),
            typeof(Legacy::UnitsNet.Level),
            typeof(Legacy::UnitsNet.Information),
        };
        Type[] generatedTypes =
        {
            typeof(Generated::UnitsNet.Length),
            typeof(Generated::UnitsNet.Mass),
            typeof(Generated::UnitsNet.Duration),
            typeof(Generated::UnitsNet.Area),
            typeof(Generated::UnitsNet.Speed),
            typeof(Generated::UnitsNet.Acceleration),
            typeof(Generated::UnitsNet.Force),
            typeof(Generated::UnitsNet.Pressure),
            typeof(Generated::UnitsNet.Energy),
            typeof(Generated::UnitsNet.Power),
            typeof(Generated::UnitsNet.Temperature),
            typeof(Generated::UnitsNet.Level),
            typeof(Generated::UnitsNet.Information),
        };

        Assert.All(legacyTypes, type => Assert.True(contract.IsAssignableFrom(type), type.FullName));
        Assert.All(generatedTypes, type => Assert.True(contract.IsAssignableFrom(type), type.FullName));
    }

    [Fact]
    public void BothImplementations_ImplementSelfTypedCoreContract()
    {
        AssertSelfTypedContract<Legacy::UnitsNet.Length, Legacy::UnitsNet.Units.LengthUnit>(
            Legacy::UnitsNet.Units.LengthUnit.Meter);
        AssertSelfTypedContract<Generated::UnitsNet.Length, Generated::UnitsNet.Units.LengthUnit>(
            Generated::UnitsNet.Units.LengthUnit.Meter);
    }

    [Fact]
    public void BothImplementations_ImplementSharedCapabilityContracts()
    {
        AssertLinearCapabilities<Legacy::UnitsNet.Length, Legacy::UnitsNet.Units.LengthUnit>();
        AssertLinearCapabilities<Generated::UnitsNet.Length, Generated::UnitsNet.Units.LengthUnit>();
        AssertAffineCapabilities<Legacy::UnitsNet.Temperature, Legacy::UnitsNet.Units.TemperatureUnit>();
        AssertAffineCapabilities<Generated::UnitsNet.Temperature, Generated::UnitsNet.Units.TemperatureUnit>();
        AssertLogarithmicCapabilities<Legacy::UnitsNet.Level, Legacy::UnitsNet.Units.LevelUnit>();
        AssertLogarithmicCapabilities<Generated::UnitsNet.Level, Generated::UnitsNet.Units.LevelUnit>();
    }

    [Fact]
    public void QuantityMath_WorksAcrossBothImplementations()
    {
        Legacy::UnitsNet.Length legacy = UnitsNet.Core.QuantityMath.Average(new[]
        {
            Legacy::UnitsNet.Length.FromMeters(1),
            Legacy::UnitsNet.Length.FromCentimeters(300),
        });
        Generated::UnitsNet.Length generated = UnitsNet.Core.QuantityMath.Average(new[]
        {
            Generated::UnitsNet.Length.FromMeters(1),
            Generated::UnitsNet.Length.FromCentimeters(300),
        });

        Assert.Equal(legacy.Meters, generated.Meters, 10);
        Assert.Equal(2, generated.Meters, 10);
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
            "QuantityId",
            "BaseUnit",
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
        Assert.Subset(legacySurface, generatedSurface);
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

    private static void AssertSelfTypedContract<TQuantity, TUnit>(TUnit baseUnit)
        where TQuantity : UnitsNet.Core.IQuantity<TQuantity, TUnit, double>
        where TUnit : struct, Enum
    {
        Assert.Equal(new UnitsNet.Core.QuantityId("UnitsNet.Length"), TQuantity.QuantityId);
        Assert.Equal(baseUnit, TQuantity.BaseUnit);

        TQuantity quantity = TQuantity.From(2, baseUnit);
        UnitsNet.Core.IQuantity<TUnit, double> stored = quantity;
        Assert.Equal(2d, stored.Value);
        Assert.Equal(baseUnit, stored.Unit);
        Assert.Equal(2d, quantity.As(baseUnit));
    }

    private static void AssertLinearCapabilities<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Core.ILinearQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        Assert.Equal(TQuantity.Zero, UnitsNet.Core.QuantityMath.Sum(Array.Empty<TQuantity>()));
    }

    private static void AssertAffineCapabilities<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Core.IAffineQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        Assert.Equal(TQuantity.BaseUnit, TQuantity.Zero.Unit);
    }

    private static void AssertLogarithmicCapabilities<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Core.ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        Assert.Equal(TQuantity.BaseUnit, TQuantity.Zero.Unit);
        Assert.True(TQuantity.LogarithmicScalingFactor > 0);
    }

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

    private static string TypeName(Type type) => type.FullName ?? type.Name;
}
