// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet.Modular;
using Catalog = UnitsNet.Modular.BuiltIns;

namespace UnitsNet.Modular.Tests;

[UnitSet("regex:.*Byte$")]
internal interface ByteUnitSet
{
}

[QuantityDefinition("Fictional.Measurements.HowMuch")]
internal interface HowMuchSpec
{
}

internal interface RepresentativeProfile :
    IInclude<Catalog.LengthSpec>,
    IInclude<Catalog.AreaSpec>,
    IInclude<Catalog.TemperatureSpec>,
    IInclude<Catalog.TemperatureDeltaSpec>,
    IInclude<Catalog.LevelSpec>,
    IInclude<Catalog.InformationSpec>
{
}

[UnitsNetModule]
internal interface TestUnits :
    IIncludeProfile<RepresentativeProfile>,
    IInclude<Catalog.MassSpec>,
    IInclude<Catalog.DensitySpec>,
    IInclude<Catalog.AccelerationSpec>,
    IInclude<Catalog.ForceSpec>,
    IInclude<Catalog.InformationSpec, ByteUnitSet>,
    IInclude<HowMuchSpec>
{
}
