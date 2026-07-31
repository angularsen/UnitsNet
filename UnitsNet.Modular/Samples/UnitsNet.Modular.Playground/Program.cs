// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet;
using UnitsNet.Units;

namespace UnitsNet.Modular.Playground;

internal static class Program
{
    public static void Main()
    {
        // These types and their relationship operator are generated from the built-in selections.
        Length route = Length.FromKilometers(5);
        Duration elapsed = Duration.FromMinutes(24);
        Speed averageSpeed = route / elapsed;

        Console.WriteLine($"{route} in {elapsed} = {averageSpeed.ToUnit(SpeedUnit.KilometerPerHour)}");

        // This type is generated from GameScore.unitsnet.json in this project.
        GameScore score = GameScore.FromDozens(2) + GameScore.FromPoints(6);
        Console.WriteLine($"{score.ToUnit(GameScoreUnit.Point)} = {score.ToUnit(GameScoreUnit.Dozen)}");

        Console.WriteLine();
        Console.WriteLine("Try editing ApplicationUnits.cs, GameScore.unitsnet.json, or this file, then run:");
        Console.WriteLine("  dotnet run");
    }
}
