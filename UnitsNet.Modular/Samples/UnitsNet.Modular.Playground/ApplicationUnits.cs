// Licensed under MIT No Attribution, see LICENSE file at the root.

using Catalog = UnitsNet.Modular.BuiltIns;

namespace UnitsNet.Modular.Playground;

// Change these lists and rebuild to control exactly which unit enum members are generated.
[UnitSet("Meter", "Kilometer", "Mile")]
internal interface PlaygroundLengthUnits;

[UnitSet("Second", "Minute", "Hour")]
internal interface PlaygroundDurationUnits;

[UnitSet("MeterPerSecond", "KilometerPerHour", "MilePerHour")]
internal interface PlaygroundSpeedUnits;

[UnitSet("Joule", "KilowattHour")]
internal interface PlaygroundEnergyUnits;

[UnitSet("Watt", "Kilowatt")]
internal interface PlaygroundPowerUnits;

// The semantic ID connects this authoring type to ParcelCount.unitsnet.json.
[QuantitySpec("UnitsNet.Modular.Playground.ParcelCount")]
internal interface ParcelCountSpec;

// Add or remove selections here, then rebuild. Only these quantities are generated.
[UnitsNetModule]
internal interface PlaygroundUnits :
    IInclude<Catalog.LengthSpec, PlaygroundLengthUnits>,
    IInclude<Catalog.DurationSpec, PlaygroundDurationUnits>,
    IInclude<Catalog.SpeedSpec, PlaygroundSpeedUnits>,
    IInclude<Catalog.EnergySpec, PlaygroundEnergyUnits>,
    IInclude<Catalog.PowerSpec, PlaygroundPowerUnits>,
    IInclude<ParcelCountSpec>;
