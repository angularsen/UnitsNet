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
            FormattableString.Invariant($"Average: {average.Value:R} {average.Unit}"));
    }

    public static Length ParseLength(string text) =>
        Length.Parse(text, CultureInfo.InvariantCulture);
}
