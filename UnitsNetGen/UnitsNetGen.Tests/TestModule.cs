// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.Tests;

[UnitSet("regex:.*Gram$")]
internal interface GramUnits
{
}

[QuantityDefinition("Fictional.Measurements.HowMuch")]
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
