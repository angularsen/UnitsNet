using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Multiplications;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class VolumeTimesDensityBenchmarks
{
    private static readonly double DensityValue = 1.23;
    private static readonly double VolumeValue = 9.42;

    [Benchmark(Baseline = true)]
    public Mass VolumeTimesDensity()
    {
        Mass result = default;
        foreach (VolumeUnit volumeUnit in Volume.Units)
        {
            var volume = new Volume(VolumeValue, volumeUnit);
            foreach (DensityUnit densityUnit in Density.Units)
            {
                var density = new Density(DensityValue, densityUnit);

                result = volume * density;
            }
        }

        return result;
    }
    
    [Benchmark(Baseline = false)]
    public Mass DensityTimesVolume()
    {
        Mass result = default;
        foreach (VolumeUnit volumeUnit in Volume.Units)
        {
            var volume = new Volume(VolumeValue, volumeUnit);
            foreach (DensityUnit densityUnit in Density.Units)
            {
                var density = new Density(DensityValue, densityUnit);

                result = density * volume;
            }
        }

        return result;
    }
}
