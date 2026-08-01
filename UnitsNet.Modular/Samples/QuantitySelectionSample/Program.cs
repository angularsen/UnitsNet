// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet;
using UnitsNet.Modular;
using UnitsNet.Units;
using Catalog = UnitsNet.Modular.BuiltIns;

namespace UnitsNet.Modular.Samples.QuantitySelection;

[UnitSet("regex:.*Meter$")]
internal interface MeterUnitSet
{
}

[UnitSet("regex:.*Byte$")]
internal interface ByteUnitSet
{
}

[UnitsNetModule]
internal interface SelectedUnits :
    IInclude<Catalog.LengthSpec, MeterUnitSet>,
    IInclude<Catalog.InformationSpec, ByteUnitSet>
{
}

internal static class Program
{
    public static void Main()
    {
        Length parsed = Length.Parse("2.5 km");
        Information payload = Information.FromKibibytes(2);

        Console.WriteLine($"{parsed} = {parsed.ToUnit(LengthUnit.Meter)}");
        Console.WriteLine($"{payload} = {payload.ToUnit(InformationUnit.Bit)}");
        Console.WriteLine($"Generated quantities: {nameof(Length)}, {nameof(Information)}");
        Console.WriteLine($"Generated length units: {string.Join(", ", Enum.GetNames<LengthUnit>())}");
    }
}
