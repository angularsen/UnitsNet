// Licensed under MIT No Attribution, see LICENSE file at the root.

using Fictional.Measurements.Definitions;
using UnitsNetGen.Generation;

namespace ConsumerOwned.Units;

[UnitsNetModule]
internal interface ApplicationUnits :
    IInclude<UnitsNetGen.BuiltIns.Length>,
    IInclude<HowMuchDefinition>,
    IInclude<HowMuchDistanceDefinition>;
