using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Divisions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class MassDividedByVolumeBenchmarks
{
    private static readonly double MassValue = 1.23;
    private static readonly double VolumeValue = 9.42;

    [Benchmark]
    public Density MassByVolume()
    {
        Density result = default;
        foreach (MassUnit massUnit in Mass.Units)
        {
            var mass = new Mass(MassValue, massUnit);
            foreach (VolumeUnit volumeUnit in Volume.Units)
            {
                var volume = new Volume(VolumeValue, volumeUnit);

                result = mass / volume;
            }
        }

        return result;
    }
}
