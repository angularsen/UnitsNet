// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen.Generation;

namespace Fictional.Measurements;

[QuantityDefinition("HowMuch", "Some")]
[UnitDefinition("Some", "Some", "sm", 1)]
[UnitDefinition("Lots", "Lots", "lots", 2)]
[UnitDefinition("Tons", "Tons", "tons", 20)]
public interface HowMuchDefinition
{
}

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchDefinition>
{
}

internal static class Program
{
    public static void Main()
    {
        HowMuch amount = HowMuch.Parse("10 tons");
        Console.WriteLine($"{amount} = {amount.Lots} lots = {amount.Some} sm");
        Console.WriteLine($"Generated in custom namespace: {typeof(HowMuch).FullName}");
    }
}
