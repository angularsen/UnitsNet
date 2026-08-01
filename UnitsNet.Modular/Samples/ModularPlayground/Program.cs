// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Globalization;
using System.Text.Json;
using UnitsNet;
using UnitsNet.Units;

namespace UnitsNet.Modular.Samples.Playground;

internal static class Program
{
    private static readonly CultureInfo Invariant = CultureInfo.InvariantCulture;

    public static void Main()
    {
        Console.WriteLine("Electric delivery-day planner");
        Console.WriteLine("Mixed-unit route inputs, parcel manifest, driving time, and charging plan.");

        // This sample intentionally uses several APIs side by side to illustrate their capabilities.
        // Production code would normally choose the shortest, most natural API for each task instead
        // of exercising every available alternative in one workflow.

        // APIs illustrated: Parse(), TryParse(), Sum(), Average(), As(), GetAbbreviation(), and static Convert().
        // Parse() handles required localized input, while TryParse() avoids exceptions for optional input.
        // Sum() and Average() aggregate mixed units; As() returns only a converted number. Static
        // Convert() is useful when neither the source nor result needs to be a quantity object.
        PrintSection("Read and normalize the route manifest");
        string[] routeInputs = ["48 km", "31 mi", "72 km"];
        Length[] routeLegs = routeInputs
            .Select(text => Length.Parse(text, Invariant))
            .ToArray();

        Length depotDetour = Length.TryParse("12 km", Invariant, out Length parsedDetour)
            ? parsedDetour
            : Length.Zero;
        Length totalRoute = routeLegs
            .Append(depotDetour)
            .Sum(LengthUnit.Kilometer);
        Length averageLeg = routeLegs.Average(LengthUnit.Kilometer);
        double totalRouteMiles = totalRoute.As(LengthUnit.Mile);
        string mileAbbreviation = Length.GetAbbreviation(LengthUnit.Mile, Invariant);

        Console.WriteLine($"Route legs: {string.Join(", ", routeLegs.Select(FormatStoredValue))}");
        Console.WriteLine(
            $"Total:      {totalRoute.ToString("0.0", Invariant)} / " +
            $"{totalRouteMiles.ToString("0.0", Invariant)} {mileAbbreviation}");
        Console.WriteLine($"Average:    {averageLeg.ToString("0.0", Invariant)} per scheduled leg");

        double localSpeedLimitMph = Speed.Convert(
            80,
            SpeedUnit.KilometerPerHour,
            SpeedUnit.MilePerHour);
        Console.WriteLine($"80 km/h local limit = {localSpeedLimitMph.ToString("F1", Invariant)} mph");

        // APIs illustrated: same-quantity addition, cross-quantity division, ToUnit(), and ToString().
        // Ordinary arithmetic preserves the quantity type. Cross-quantity operators produce a different
        // type and are generated only when every participant is selected in ApplicationUnits.cs.
        // ToUnit() retains a strongly typed quantity for subsequent formatting or calculations.
        PrintSection("Estimate the driving day");
        Duration drivingTime = Duration.Parse("4 h", Invariant) + Duration.FromMinutes(25);
        Speed averageSpeed = totalRoute / drivingTime;
        Speed displaySpeed = averageSpeed.ToUnit(SpeedUnit.KilometerPerHour);

        Console.WriteLine($"Driving time:  {drivingTime.ToString("0.0", Invariant)}");
        Console.WriteLine($"Average speed: {displaySpeed.ToString("0.0", Invariant)}");

        // APIs illustrated: cross-quantity multiplication and its inferred division operator.
        // The Power * Duration = Energy relationship handles anchor-unit conversions, so multiplying
        // kW by minutes works directly; dividing Energy by Power yields the corresponding Duration.
        PrintSection("Plan the charging stop");
        Power charger = Power.Parse("150 kW", Invariant);
        Duration chargingWindow = Duration.FromMinutes(22);
        Energy deliveredEnergy = charger * chargingWindow;
        Energy requestedEnergy = Energy.Parse("42 kWh", Invariant);
        Duration timeToAddRequestedEnergy = requestedEnergy / charger;
        Energy displayEnergy = deliveredEnergy.ToUnit(EnergyUnit.KilowattHour);
        Duration displayChargeTime = timeToAddRequestedEnergy.ToUnit(DurationUnit.Minute);

        Console.WriteLine($"Charger:       {charger.ToString("0", Invariant)}");
        Console.WriteLine($"Energy in 22m: {displayEnergy.ToString("0.0", Invariant)}");
        Console.WriteLine($"Time for 42kWh: {displayChargeTime.ToString("0.0", Invariant)}");

        // APIs illustrated: a custom JSON-defined quantity using the same generated API as a built-in.
        // ParcelCount comes from ParcelCount.unitsnet.json and receives parsing, construction,
        // conversion, formatting, and arithmetic without hand-written quantity code.
        PrintSection("Count the cargo with a custom quantity");
        ParcelCount manifest = ParcelCount.Parse("2 doz", Invariant) + ParcelCount.FromParcels(6);
        ParcelCount parcelManifest = manifest.ToUnit(ParcelCountUnit.Parcel);
        ParcelCount dozenManifest = manifest.ToUnit(ParcelCountUnit.Dozen);
        Console.WriteLine(
            $"Manifest: {parcelManifest.ToString("0", Invariant)} " +
            $"({dozenManifest.ToString("0.00", Invariant)})");

        // APIs illustrated: the legacy-shaped Quantity facade, modular registry, and UnitSystem policy.
        // Quantity.From(...) keeps a familiar call shape for configuration-driven code. Unlike legacy
        // UnitsNet, the facade is scoped to the selected module and returns UnitsNet.IQuantity<double>.
        // The modular registry exposes that selected catalog without global mutation.
        PrintSection("Use the modular dynamic API");
        IQuantity<double> configuredDistance = Quantity.From(15, "Length", "Mile");
        var registry = GeneratedQuantityRegistry.Instance;
        IQuantityDescriptor lengthDescriptor = registry.Get("Length");
        double configuredKilometers = registry.Convert(15, "Length", "Mile", "Kilometer");

        string formattedConfiguredDistance = lengthDescriptor.Format(configuredDistance, "0.0", Invariant);
        Console.WriteLine(
            $"Configured leg: {formattedConfiguredDistance} = " +
            $"{configuredKilometers.ToString("F1", Invariant)} km");
        Console.WriteLine($"Selected types: {string.Join(", ", registry.Names.Order())}");

        // Modular unit-system policy is immutable and explicit. It resolves only among units selected
        // by this module instead of changing process-wide UnitsNetSetup defaults at runtime.
        Length siRoute = totalRoute.ToUnit(UnitSystem.SI);
        Console.WriteLine($"SI policy:     {siRoute.ToString("0", Invariant)}");

        // API illustrated: the System.Text.Json converter exposed by the generated registry.
        // It knows the selected concrete types without assembly scanning, keeping serialization
        // friendly to trimming and Native AOT.
        PrintSection("Persist a strongly typed result");
        var jsonOptions = new JsonSerializerOptions { WriteIndented = false };
        jsonOptions.Converters.Add(GeneratedQuantityRegistry.JsonConverter);
        string json = JsonSerializer.Serialize(displayEnergy, jsonOptions);
        Energy restoredEnergy = JsonSerializer.Deserialize<Energy>(json, jsonOptions);

        Console.WriteLine($"JSON:      {json}");
        Console.WriteLine($"Round trip:{restoredEnergy.ToString("0.0", Invariant),10}");

        Console.WriteLine();
        Console.WriteLine("Try editing ApplicationUnits.cs, ParcelCount.unitsnet.json, or this file, then run:");
        Console.WriteLine("  dotnet run");
    }

    private static string FormatStoredValue(Length length) => length.ToString("0.#", Invariant);

    private static void PrintSection(string title)
    {
        Console.WriteLine();
        Console.WriteLine(title);
        Console.WriteLine(new string('-', title.Length));
    }
}
