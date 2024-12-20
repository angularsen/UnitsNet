// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.Relations;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class InverseOperationBenchmarks
{
    private static readonly double Value = 123.456;

    // new (typeof(Area), typeof(ReciprocalArea)),
    // new (typeof(Density), typeof(SpecificVolume)),
    // new (typeof(ElectricConductivity), typeof(ElectricResistivity)),
    // new (typeof(Length), typeof(ReciprocalLength)),
    
    [Params(typeof(Area), typeof(Length))]
    public Type TypeToTest { get; set; }
    
    
    [Benchmark(Baseline = true)]
    public IQuantity ConvertWithoutInverse()
    {
        IQuantity result = default;
        if (TypeToTest == typeof(Area))
        {
            foreach (AreaUnit fromUnit in Area.Units)
            {
                var quantity = Area.From(Value, fromUnit);
                result = quantity.Inverse();
            }
            
            foreach (ReciprocalAreaUnit fromUnit in ReciprocalArea.Units)
            {
                var quantity = ReciprocalArea.From(Value, fromUnit);
                result = quantity.Inverse();
            }
        }
        else if (TypeToTest == typeof(Length))
        {
            foreach (LengthUnit fromUnit in Length.Units)
            {
                var quantity = Length.From(Value, fromUnit);
                result = quantity.Inverse();
            }
            
            foreach (ReciprocalLengthUnit fromUnit in ReciprocalLength.Units)
            {
                var quantity = ReciprocalLength.From(Value, fromUnit);
                result = quantity.Inverse();
            }
        }

        return result;
    }

}
