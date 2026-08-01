// Licensed under MIT No Attribution, see LICENSE file at the root.

using Fictional.Measurements.Definitions;
using UnitsNet.Modular;

namespace SharedUnitsLibrarySample.Units;

[UnitsNetModule]
internal interface ApplicationUnits :
    IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>,
    IInclude<HowMuchSpec>,
    IInclude<HowMuchDistanceSpec>;
