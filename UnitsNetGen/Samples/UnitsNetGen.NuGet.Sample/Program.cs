// Licensed under MIT No Attribution, see LICENSE file at the root.

using NuGetConsumer.Measurements;
using UnitsNetGen;
using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.NuGet.Sample;

[QuantityDefinition("NuGetConsumer.Measurements.HowMuch")]
internal interface HowMuchDefinition;

[UnitsNetModule]
internal interface ConsumerUnits : IInclude<Catalog.Length>, IInclude<HowMuchDefinition>;

internal static class Program
{
    public static void Main()
    {
        Length distance = Length.FromKilometers(2);
        HowMuch amount = HowMuch.Parse("10 lots");

        Console.WriteLine($"{distance} = {distance.ToUnit(LengthUnit.Meter)}");
        Console.WriteLine($"{amount} = {amount.ToUnit(HowMuchUnit.Some)}");
    }
}
