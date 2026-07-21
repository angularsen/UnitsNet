// Licensed under MIT No Attribution, see LICENSE file at the root.

using ConsumerOwned.Domain;
using Fictional.Measurements;

HowMuchDistance allocation = MeasurementService.MeasureAllocation();

Console.WriteLine(allocation.ToUnit(HowMuchDistanceUnit.SomeMeter));
Console.WriteLine($"Shared quantity assembly: {typeof(HowMuchDistance).Assembly.GetName().Name}");
