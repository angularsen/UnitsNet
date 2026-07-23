// Licensed under MIT No Attribution, see LICENSE file at the root.

using Fictional.Measurements;
using Xunit;

namespace UnitsNetGen.Tests;

public sealed class GeneratedQuantityTests
{
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
    public void GeneratedQuantity_ImplementsMinimalSelfTypedCoreContract()
    {
        Assert.Equal(new UnitsNet.Core.QuantityId("UnitsNet.Length"), Length.QuantityId);
        Assert.Equal(LengthUnit.Meter, Length.BaseUnit);

        Length length = Create<Length, LengthUnit>(2, LengthUnit.Meter);
        UnitsNet.Core.IQuantity<LengthUnit, double> stored = length;
        Assert.Equal(2d, stored.Value);
        Assert.Equal(LengthUnit.Meter, stored.Unit);
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
    public void GeneratedQuantities_AdvertiseTheirArithmeticCapabilities()
    {
        AssertLinearCapability<Length, LengthUnit>();
        AssertLinearCapability<TemperatureDelta, TemperatureDeltaUnit>();
        AssertAffineCapability<Temperature, TemperatureUnit, TemperatureDelta>();
        AssertLogarithmicCapability<Level, LevelUnit>();
        Assert.DoesNotContain(
            typeof(Temperature).GetInterfaces(),
            type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(UnitsNet.Core.ILinearQuantity<>));
        Assert.DoesNotContain(
            typeof(Level).GetInterfaces(),
            type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(UnitsNet.Core.ILinearQuantity<>));
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
        Temperature average = UnitsNet.Core.AffineQuantityMath.Average(
            new[] { freezing, boiling },
            TemperatureUnit.DegreeCelsius);

        Assert.Equal(100, interval.DegreesCelsius, 10);
        Assert.Equal(100, raised.DegreesCelsius, 10);
        Assert.Equal(100, commutative.DegreesCelsius, 10);
        Assert.Equal(0, lowered.DegreesCelsius, 10);
        Assert.Equal(50, average.DegreesCelsius, 10);
        Assert.Throws<InvalidOperationException>(() =>
            UnitsNet.Core.AffineQuantityMath.Average(Array.Empty<Temperature>(), TemperatureUnit.Kelvin));
    }

    [Fact]
    public void QuantityMath_SumsAndAveragesMixedUnits()
    {
        Length sum = UnitsNet.Core.QuantityMath.Sum(new[]
        {
            Length.FromKilometers(1),
            Length.FromMeters(500),
        });
        Length targetedSum = UnitsNet.Core.QuantityMath.Sum(
            new[] { Length.FromKilometers(1), Length.FromMeters(500) },
            LengthUnit.Meter);
        Length average = UnitsNet.Core.QuantityMath.Average(new[]
        {
            Length.FromMeters(1),
            Length.FromCentimeters(300),
        });
        Length targetedAverage = UnitsNet.Core.QuantityMath.Average(
            new[] { Length.FromMeters(1), Length.FromCentimeters(300) },
            LengthUnit.Centimeter);

        Assert.Equal(1.5, sum.Kilometers, 10);
        Assert.Equal(1500, targetedSum.Meters, 10);
        Assert.Equal(2, average.Meters, 10);
        Assert.Equal(200, targetedAverage.Centimeters, 10);
        Assert.Equal(Length.Zero, UnitsNet.Core.QuantityMath.Sum(Array.Empty<Length>()));
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
        where TQuantity : UnitsNet.Core.IQuantity<TQuantity, TUnit, double>
        where TUnit : struct, Enum
        => TQuantity.From(value, unit);

    private static double ConvertValue<TQuantity, TUnit>(double value, TUnit fromUnit, TUnit toUnit)
        where TQuantity : UnitsNet.Core.IQuantity<TQuantity, TUnit, double>
        where TUnit : struct, Enum
        => TQuantity.Convert(value, fromUnit, toUnit);

    private static void AssertLinearCapability<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Core.ILinearQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
        => Assert.Equal(TQuantity.BaseUnit, TQuantity.Zero.Unit);

    private static void AssertAffineCapability<TQuantity, TUnit, TOffset>()
        where TQuantity : UnitsNet.Core.IAffineQuantity<TQuantity, TUnit, TOffset>
        where TUnit : struct, Enum
        where TOffset : UnitsNet.Core.ILinearQuantity<TOffset>
        => Assert.Equal(TQuantity.BaseUnit, TQuantity.Zero.Unit);

    private static TQuantity AddOffset<TQuantity, TUnit, TOffset>(TQuantity quantity, TOffset offset)
        where TQuantity : UnitsNet.Core.IAffineQuantity<TQuantity, TUnit, TOffset>
        where TUnit : struct, Enum
        where TOffset : UnitsNet.Core.ILinearQuantity<TOffset>
        => quantity + offset;

    private static TOffset Difference<TQuantity, TUnit, TOffset>(TQuantity left, TQuantity right)
        where TQuantity : UnitsNet.Core.IAffineQuantity<TQuantity, TUnit, TOffset>
        where TUnit : struct, Enum
        where TOffset : UnitsNet.Core.ILinearQuantity<TOffset>
        => left - right;

    private static void AssertLogarithmicCapability<TQuantity, TUnit>()
        where TQuantity : UnitsNet.Core.ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
        => Assert.Equal(TQuantity.BaseUnit, TQuantity.Zero.Unit);
}
