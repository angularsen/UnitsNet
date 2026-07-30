// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Globalization;
using UnitsNet;
using UnitsNet.Units;

namespace UnitsNet.Modular.Compatibility;

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
        Temperature midpoint = new[] { freezing, boiling }.Average(TemperatureUnit.DegreeCelsius);
        Level combinedLevel = Level.FromDecibels(10) + Level.FromDecibels(10);
        Information payload = Information.FromKibibytes(2).ToUnit(InformationUnit.Bit);
        Length total = new[]
        {
            Length.FromKilometers(1),
            Length.FromMeters(500),
        }.Sum();
        Length average = new[]
        {
            Length.FromMeters(1),
            Length.FromCentimeters(300),
        }.Average();
        var kilometerInfo = Length.Info[LengthUnit.Kilometer];
        Length metadataDistance = Length.Info.From(1.5, kilometerInfo.Value);
        if (!ReferenceEquals(Length.Info, metadataDistance.QuantityInfo))
        {
            throw new InvalidOperationException("Quantity metadata should be shared.");
        }

        return string.Join(
            Environment.NewLine,
            FormattableString.Invariant($"Length: {distance.Value:G15} {distance.Unit}"),
            FormattableString.Invariant($"Area: {area.Value:G15} {area.Unit}"),
            FormattableString.Invariant($"Temperature: {temperature.Value:G15} {temperature.Unit}"),
            FormattableString.Invariant($"Temperature range: {temperatureRange.Value:G15} {temperatureRange.Unit}"),
            FormattableString.Invariant($"Temperature midpoint: {midpoint.Value:G15} {midpoint.Unit}"),
            FormattableString.Invariant($"Level: {combinedLevel.Value:G15} {combinedLevel.Unit}"),
            FormattableString.Invariant($"Information: {payload.Value:G15} {payload.Unit}"),
            FormattableString.Invariant($"Sum: {total.Value:G15} {total.Unit}"),
            FormattableString.Invariant($"Average: {average.Value:G15} {average.Unit}"),
            FormattableString.Invariant(
                $"Metadata: {metadataDistance.Value:G15} {kilometerInfo.Name}"));
    }

    public static Length ParseLength(string text) =>
        Length.Parse(text, CultureInfo.InvariantCulture);
}
