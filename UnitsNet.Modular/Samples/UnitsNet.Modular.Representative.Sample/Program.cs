// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet;
using UnitsNet.Modular;
using UnitsNet.Units;
using Catalog = UnitsNet.Modular.BuiltIns;

namespace UnitsNet.Modular.Representative.Sample;

[UnitsNetModule]
internal interface RepresentativeUnits :
    IInclude<Catalog.LengthSpec>,
    IInclude<Catalog.AreaSpec>,
    IInclude<Catalog.TemperatureSpec>,
    IInclude<Catalog.TemperatureDeltaSpec>,
    IInclude<Catalog.LevelSpec>,
    IInclude<Catalog.InformationSpec>
{
}

internal static class Program
{
    public static void Main()
    {
        Length distance = Length.FromKilometers(1.2);
        Area floor = Length.FromMeters(2) * Length.FromMeters(3);
        Temperature room = Temperature.FromDegreesCelsius(21.5);
        TemperatureDelta adjustment = TemperatureDelta.FromDegreesCelsius(2);
        Level combined = Level.FromDecibels(10) + Level.FromDecibels(10);
        Information payload = Information.FromKibibytes(2);

        Console.WriteLine($"Distance: {distance}");
        Console.WriteLine($"Floor: {floor}");
        Console.WriteLine($"Room: {room.ToUnit(TemperatureUnit.DegreeFahrenheit)}");
        Console.WriteLine($"Adjusted room: {(room + adjustment).ToUnit(TemperatureUnit.DegreeCelsius)}");
        Console.WriteLine($"Combined level: {combined}");
        Console.WriteLine($"Payload: {payload.ToUnit(InformationUnit.Bit)}");
    }
}
