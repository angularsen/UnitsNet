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
        string[] names = Enum.GetNames<MassUnit>();

        Assert.Contains("Kilogram", names);
        Assert.Contains("Gram", names);
        Assert.Contains("Milligram", names);
        Assert.DoesNotContain("Pound", names);
    }

    [Fact]
    public void DerivedOperators_AppearWhenAllQuantitiesAreSelected()
    {
        Force force = Mass.FromKilograms(2) * Acceleration.FromMetersPerSecondSquared(3);
        Area area = Length.FromMeters(2) * Length.FromMeters(4);
        Pressure pressure = force / area;

        Assert.Equal(6, force.Newtons, 10);
        Assert.Equal(8, area.SquareMeters, 10);
        Assert.Equal(0.75, pressure.Pascals, 10);
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
    public void JsonDefinition_SupportsPrefixesLocalizationAndNonlinearConversions()
    {
        var norwegian = System.Globalization.CultureInfo.GetCultureInfo("nb-NO");

        HowMuch localized = HowMuch.Parse("10 tonnevis", norwegian);
        HowMuch nonlinear = HowMuch.FromMagnitudes(3);
        HowMuch prefixed = HowMuch.FromKilosome(2);

        Assert.Equal(200, localized.Some, 10);
        Assert.Equal("10 tonnevis", localized.ToString(null, norwegian));
        Assert.Equal(9, nonlinear.Some, 10);
        Assert.Equal(3, nonlinear.Magnitudes, 10);
        Assert.Equal(2000, prefixed.Some, 10);
        Assert.Equal("2 knoe", prefixed.ToString(null, norwegian));
    }
}
