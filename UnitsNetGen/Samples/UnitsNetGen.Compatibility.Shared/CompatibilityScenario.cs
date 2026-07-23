// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Globalization;
using UnitsNet;
using UnitsNet.Units;

namespace UnitsNetGen.Compatibility;

public static class CompatibilityScenario
{
    public static string Run()
    {
        Length distance = Length.FromKilometers(1.5).ToUnit(LengthUnit.Meter);
        Area area = Length.FromMeters(2) * Length.FromMeters(3);
        Temperature temperature = Temperature.FromDegreesCelsius(21.5)
            .ToUnit(TemperatureUnit.DegreeFahrenheit);
        Temperature freezing = Temperature.FromDegreesCelsius(0);
        Temperature boiling = Temperature.FromDegreesFahrenheit(212);
        TemperatureDelta temperatureRange = boiling - freezing;
        Temperature midpoint = UnitsNet.Core.AffineQuantityMath.Average(
            new[] { freezing, boiling },
            TemperatureUnit.DegreeCelsius);
        Level combinedLevel = Level.FromDecibels(10) + Level.FromDecibels(10);
        Information payload = Information.FromKibibytes(2).ToUnit(InformationUnit.Bit);
        Length total = UnitsNet.Core.QuantityMath.Sum(new[]
        {
            Length.FromKilometers(1),
            Length.FromMeters(500),
        });
        Length average = UnitsNet.Core.QuantityMath.Average(new[]
        {
            Length.FromMeters(1),
            Length.FromCentimeters(300),
        });

        return string.Join(
            Environment.NewLine,
            FormattableString.Invariant($"Length: {distance.Value:R} {distance.Unit}"),
            FormattableString.Invariant($"Area: {area.Value:R} {area.Unit}"),
            FormattableString.Invariant($"Temperature: {temperature.Value:R} {temperature.Unit}"),
            FormattableString.Invariant($"Temperature range: {temperatureRange.Value:R} {temperatureRange.Unit}"),
            FormattableString.Invariant($"Temperature midpoint: {midpoint.Value:R} {midpoint.Unit}"),
            FormattableString.Invariant($"Level: {combinedLevel.Value:R} {combinedLevel.Unit}"),
            FormattableString.Invariant($"Information: {payload.Value:R} {payload.Unit}"),
            FormattableString.Invariant($"Sum: {total.Value:R} {total.Unit}"),
            FormattableString.Invariant($"Average: {average.Value:R} {average.Unit}"),
            DescribeCoreContract<Length, LengthUnit>(distance));
    }

    public static Length ParseLength(string text) =>
        Length.Parse(text, CultureInfo.InvariantCulture);

    private static string DescribeCoreContract<TQuantity, TUnit>(TQuantity quantity)
        where TQuantity : UnitsNet.Core.IQuantity<TQuantity, TUnit, double>
        where TUnit : struct, Enum =>
        FormattableString.Invariant(
            $"Core: {TQuantity.QuantityId}={quantity.Value:R} {quantity.Unit}");
}
