// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen;
using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.Lean.Sample;

[UnitSet("regex:.*Meter$")]
internal interface MeterUnits
{
}

[UnitSet("regex:.*Byte$")]
internal interface ByteUnits
{
}

[UnitsNetModule]
internal interface LeanUnits :
    IInclude<Catalog.Length, MeterUnits>,
    IInclude<Catalog.Information, ByteUnits>
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
        Console.WriteLine($"Generated quantities: {typeof(Length).Name}, {typeof(Information).Name}");
        Console.WriteLine($"Generated length units: {string.Join(", ", Enum.GetNames<LengthUnit>())}");
    }
}
