// Licensed under MIT No Attribution, see LICENSE file at the root.

using Fictional.Measurements;

HowMuch amount = HowMuch.Parse("10 tons");
HowMuch magnitude = HowMuch.FromMagnitudes(3);

Console.WriteLine($"{amount} = {amount.ToUnit(HowMuchUnit.Lots)} = {amount.ToUnit(HowMuchUnit.Some)}");
Console.WriteLine($"{magnitude} = {magnitude.ToUnit(HowMuchUnit.Some)}");
Console.WriteLine($"Generated in custom namespace: {typeof(HowMuch).FullName}");
