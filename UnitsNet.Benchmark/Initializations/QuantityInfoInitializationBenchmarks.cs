// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Initializations;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class QuantityInfoInitializationBenchmarks
{
    [Params(1000)]
    public int NbIterations { get; set; }

    [Benchmark(Baseline = true)]
    public void CreateDefaultMass()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            var quantityInfo = Mass.MassInfo.CreateDefault();
        }
    }

    [Benchmark]
    public void CreateDefaultVolume()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            var quantityInfo = Volume.VolumeInfo.CreateDefault();
        }
    }

    [Benchmark]
    public void CreateDefaultVolumeFlow()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            var quantityInfo = VolumeFlow.VolumeFlowInfo.CreateDefault();
        }
    }
}
