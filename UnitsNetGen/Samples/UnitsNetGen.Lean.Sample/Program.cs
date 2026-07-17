// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen;
using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.Lean.Sample;

[UnitSet("*Gram")]
internal interface GramUnits
{
}

[UnitsNetModule]
internal interface LeanUnits :
    IInclude<Catalog.Length>,
    IInclude<Catalog.Mass, GramUnits>
{
}

internal static class Program
{
    public static void Main()
    {
        Length parsed = Length.Parse("2.5 km");
        Mass payload = Mass.FromMilligrams(750_000);

        Console.WriteLine($"{parsed} = {parsed.Meters} m");
        Console.WriteLine($"{payload} = {payload.Grams} g");
        Console.WriteLine($"Generated quantities: {typeof(Length).Name}, {typeof(Mass).Name}");
        Console.WriteLine($"Generated mass units: {string.Join(", ", Enum.GetNames<MassUnit>())}");
    }
}
