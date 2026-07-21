// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Globalization;
using UnitsNet;
using UnitsNet.Units;

namespace UnitsNetGen.Compatibility;

public static class CompatibilityScenario
{
    public static string Run()
    {
        global::UnitsNet.IQuantity<LengthUnit> distanceContract = Length.FromKilometers(1.5);
        Length distance = (Length)distanceContract.ToUnit(LengthUnit.Meter);
        Area area = Length.FromMeters(2) * Length.FromMeters(3);
        Temperature temperature = Temperature.FromDegreesCelsius(21.5)
            .ToUnit(TemperatureUnit.DegreeFahrenheit);
        Level combinedLevel = Level.FromDecibels(10) + Level.FromDecibels(10);
        Information payload = Information.FromKibibytes(2).ToUnit(InformationUnit.Bit);

        return string.Join(
            Environment.NewLine,
            FormattableString.Invariant($"Length: {distance.Value:R} {distance.Unit}"),
            FormattableString.Invariant($"Area: {area.Value:R} {area.Unit}"),
            FormattableString.Invariant($"Temperature: {temperature.Value:R} {temperature.Unit}"),
            FormattableString.Invariant($"Level: {combinedLevel.Value:R} {combinedLevel.Unit}"),
            FormattableString.Invariant($"Information: {payload.Value:R} {payload.Unit}"),
            DescribeCoreContract(distance));
    }

    public static Length ParseLength(string text) =>
        Length.Parse(text, CultureInfo.InvariantCulture);

    private static string DescribeCoreContract(UnitsNet.Core.IQuantity<double> quantity) =>
        FormattableString.Invariant(
            $"Core: {quantity.QuantityId}={quantity.BaseValue:R} {quantity.UnitName}");
}
