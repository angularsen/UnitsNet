// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.Tests;

[UnitSet("*Gram")]
internal interface GramUnits
{
}

[QuantityDefinition("HowMuch", "Some", Namespace = "Fictional.Measurements")]
[UnitDefinition("Some", "Some", "sm", 1)]
[UnitDefinition("Lots", "Lots", "lots", 2)]
[UnitDefinition("Tons", "Tons", "tons", 20)]
internal interface HowMuchDefinition
{
}

[UnitsNetModule]
internal interface TestUnits :
    IInclude<Catalog.Length>,
    IInclude<Catalog.Mass, GramUnits>,
    IInclude<Catalog.Duration>,
    IInclude<Catalog.Area>,
    IInclude<Catalog.Speed>,
    IInclude<Catalog.Acceleration>,
    IInclude<Catalog.Force>,
    IInclude<Catalog.Pressure>,
    IInclude<Catalog.Energy>,
    IInclude<Catalog.Power>,
    IInclude<HowMuchDefinition>
{
}
