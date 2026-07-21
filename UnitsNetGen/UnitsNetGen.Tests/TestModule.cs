// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.Tests;

[UnitSet("regex:.*Byte$")]
internal interface ByteUnits
{
}

[QuantityDefinition("Fictional.Measurements.HowMuch")]
internal interface HowMuchDefinition
{
}

internal interface RepresentativeProfile :
    IInclude<Catalog.Length>,
    IInclude<Catalog.Area>,
    IInclude<Catalog.Temperature>,
    IInclude<Catalog.Level>,
    IInclude<Catalog.Information>
{
}

[UnitsNetModule]
internal interface TestUnits :
    IIncludeProfile<RepresentativeProfile>,
    IInclude<Catalog.Information, ByteUnits>,
    IInclude<HowMuchDefinition>
{
}
