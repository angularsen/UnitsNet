// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet.Modular;
using Catalog = UnitsNet.Modular.BuiltIns;

namespace UnitsNet.Modular.Playground;

// Change these lists and rebuild to control exactly which unit enum members are generated.
[UnitSet("Meter", "Kilometer", "Mile")]
internal interface PlaygroundLengthUnits;

[UnitSet("Second", "Minute", "Hour")]
internal interface PlaygroundDurationUnits;

[UnitSet("MeterPerSecond", "KilometerPerHour", "MilePerHour")]
internal interface PlaygroundSpeedUnits;

// The semantic ID connects this authoring type to GameScore.unitsnet.json.
[QuantitySpec("UnitsNet.Modular.Playground.GameScore")]
internal interface GameScoreSpec;

// Add or remove selections here, then rebuild. Only these quantities are generated.
[UnitsNetModule]
internal interface PlaygroundUnits :
    IInclude<Catalog.LengthSpec, PlaygroundLengthUnits>,
    IInclude<Catalog.DurationSpec, PlaygroundDurationUnits>,
    IInclude<Catalog.SpeedSpec, PlaygroundSpeedUnits>,
    IInclude<GameScoreSpec>;
