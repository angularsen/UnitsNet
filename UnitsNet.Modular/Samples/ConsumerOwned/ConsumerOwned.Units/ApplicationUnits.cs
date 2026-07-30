// Licensed under MIT No Attribution, see LICENSE file at the root.

using Fictional.Measurements.Definitions;
using UnitsNet.Modular;

namespace ConsumerOwned.Units;

[UnitsNetModule]
internal interface ApplicationUnits :
    IInclude<UnitsNet.Modular.BuiltIns.Length>,
    IInclude<HowMuchDefinition>,
    IInclude<HowMuchDistanceDefinition>;
