// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen;
using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.AllSi.Sample;

[UnitsNetModule]
internal interface AllSiUnits :
    IInclude<Catalog.Length>,
    IInclude<Catalog.Mass>,
    IInclude<Catalog.Duration>,
    IInclude<Catalog.Area>,
    IInclude<Catalog.Speed>,
    IInclude<Catalog.Acceleration>,
    IInclude<Catalog.Force>,
    IInclude<Catalog.Pressure>,
    IInclude<Catalog.Energy>,
    IInclude<Catalog.Power>
{
}

internal static class Program
{
    public static void Main()
    {
        Length distance = Length.FromKilometers(1.2);
        Duration duration = Duration.FromMinutes(1);
        Speed speed = distance / duration;
        Acceleration acceleration = speed / Duration.FromSeconds(10);
        Force force = Mass.FromKilograms(1500) * acceleration;
        Pressure pressure = force / (Length.FromMeters(2) * Length.FromMeters(3));
        Energy energy = force * Length.FromMeters(5);
        Power power = energy / Duration.FromSeconds(30);

        Console.WriteLine($"Distance: {distance}");
        Console.WriteLine($"Speed: {speed.ToUnit(SpeedUnit.KilometerPerHour)}");
        Console.WriteLine($"Force: {force}");
        Console.WriteLine($"Pressure: {pressure.ToUnit(PressureUnit.Kilopascal)}");
        Console.WriteLine($"Power: {power.ToUnit(PowerUnit.Kilowatt)}");
    }
}
