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

        const System.Reflection.BindingFlags publicMembers =
            System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.Static;
        Assert.Null(typeof(Length).GetProperty("BaseValue", publicMembers));
        Assert.Null(typeof(Length).GetProperty("UnitName", publicMembers));
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
}
