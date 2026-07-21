// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen;
using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.Representative.Sample;

[UnitsNetModule]
internal interface RepresentativeUnits :
    IInclude<Catalog.Length>,
    IInclude<Catalog.Area>,
    IInclude<Catalog.Temperature>,
    IInclude<Catalog.Level>,
    IInclude<Catalog.Information>
{
}

internal static class Program
{
    public static void Main()
    {
        Length distance = Length.FromKilometers(1.2);
        Area floor = Length.FromMeters(2) * Length.FromMeters(3);
        Temperature room = Temperature.FromDegreesCelsius(21.5);
        Level combined = Level.FromDecibels(10) + Level.FromDecibels(10);
        Information payload = Information.FromKibibytes(2);

        Console.WriteLine($"Distance: {distance}");
        Console.WriteLine($"Floor: {floor}");
        Console.WriteLine($"Room: {room.ToUnit(TemperatureUnit.DegreeFahrenheit)}");
        Console.WriteLine($"Combined level: {combined}");
        Console.WriteLine($"Payload: {payload.ToUnit(InformationUnit.Bit)}");
    }
}
