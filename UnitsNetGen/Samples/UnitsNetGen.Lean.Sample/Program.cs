// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen;
using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.Lean.Sample;

[UnitSet("regex:.*Gram$")]
internal interface GramUnits
{
}

[QuantityDefinition("UnitsNetGen.Length")]
internal interface LengthDefinition
{
}

[UnitsNetModule]
internal interface LeanUnits :
    IInclude<LengthDefinition>,
    IInclude<Catalog.Mass, GramUnits>
{
}

internal static class Program
{
    public static void Main()
    {
        Length parsed = Length.Parse("2.5 km");
        Mass payload = Mass.FromMilligrams(750_000);

        Console.WriteLine($"{parsed} = {parsed.ToUnit(LengthUnit.Meter)}");
        Console.WriteLine($"{payload} = {payload.ToUnit(MassUnit.Gram)}");
        Console.WriteLine($"Generated quantities: {typeof(Length).Name}, {typeof(Mass).Name}");
        Console.WriteLine($"Generated mass units: {string.Join(", ", Enum.GetNames<MassUnit>())}");
    }
}
