// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet.Modular;
using Catalog = UnitsNet.Modular.BuiltIns;

namespace MyApplication.Units;

[UnitsNetModule]
internal interface ApplicationUnits :
    IInclude<Catalog.LengthSpec>,
    IInclude<Catalog.DurationSpec>,
    IInclude<Catalog.SpeedSpec>;
