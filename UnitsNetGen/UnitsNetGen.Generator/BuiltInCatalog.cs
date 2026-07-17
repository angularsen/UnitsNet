// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace UnitsNetGen.Generator;

internal static class BuiltInCatalog
{
    private static readonly IReadOnlyDictionary<string, QuantityDefinition> Definitions =
        new Dictionary<string, QuantityDefinition>(StringComparer.Ordinal)
        {
            ["Length"] = Quantity("Length", "Meter",
                Unit("Meter", "Meters", "m", 1),
                Unit("Millimeter", "Millimeters", "mm", 1e-3),
                Unit("Centimeter", "Centimeters", "cm", 1e-2),
                Unit("Kilometer", "Kilometers", "km", 1e3)),
            ["Mass"] = Quantity("Mass", "Kilogram",
                Unit("Kilogram", "Kilograms", "kg", 1),
                Unit("Gram", "Grams", "g", 1e-3),
                Unit("Milligram", "Milligrams", "mg", 1e-6),
                Unit("Pound", "Pounds", "lb", 0.45359237)),
            ["Duration"] = Quantity("Duration", "Second",
                Unit("Second", "Seconds", "s", 1),
                Unit("Millisecond", "Milliseconds", "ms", 1e-3),
                Unit("Minute", "Minutes", "min", 60),
                Unit("Hour", "Hours", "h", 3600)),
            ["Area"] = Quantity("Area", "SquareMeter",
                Unit("SquareMeter", "SquareMeters", "m²", 1),
                Unit("SquareCentimeter", "SquareCentimeters", "cm²", 1e-4),
                Unit("SquareKilometer", "SquareKilometers", "km²", 1e6)),
            ["Speed"] = Quantity("Speed", "MeterPerSecond",
                Unit("MeterPerSecond", "MetersPerSecond", "m/s", 1),
                Unit("KilometerPerHour", "KilometersPerHour", "km/h", 1.0 / 3.6)),
            ["Acceleration"] = Quantity("Acceleration", "MeterPerSecondSquared",
                Unit("MeterPerSecondSquared", "MetersPerSecondSquared", "m/s²", 1),
                Unit("StandardGravity", "StandardGravity", "g₀", 9.80665)),
            ["Force"] = Quantity("Force", "Newton",
                Unit("Newton", "Newtons", "N", 1),
                Unit("Kilonewton", "Kilonewtons", "kN", 1e3)),
            ["Pressure"] = Quantity("Pressure", "Pascal",
                Unit("Pascal", "Pascals", "Pa", 1),
                Unit("Kilopascal", "Kilopascals", "kPa", 1e3),
                Unit("Bar", "Bars", "bar", 1e5)),
            ["Energy"] = Quantity("Energy", "Joule",
                Unit("Joule", "Joules", "J", 1),
                Unit("Kilojoule", "Kilojoules", "kJ", 1e3)),
            ["Power"] = Quantity("Power", "Watt",
                Unit("Watt", "Watts", "W", 1),
                Unit("Kilowatt", "Kilowatts", "kW", 1e3)),
        };

    public static bool TryGet(string name, out QuantityDefinition definition)
        => Definitions.TryGetValue(name, out definition!);

    private static QuantityDefinition Quantity(string name, string baseUnit, params UnitDefinition[] units)
        => new QuantityDefinition(name, "UnitsNetGen", baseUnit, units);

    private static UnitDefinition Unit(string singularName, string pluralName, string abbreviation, double scaleToBase)
    {
        string scale = scaleToBase.ToString("R", CultureInfo.InvariantCulture);
        string toBase = scaleToBase == 1 ? "x" : $"x * {scale}";
        string fromBase = scaleToBase == 1 ? "x" : $"x / {scale}";
        return new UnitDefinition(
            singularName,
            pluralName,
            toBase,
            fromBase,
            new[] { new UnitLocalizationDefinition("en-US", new[] { abbreviation }) });
    }
}
