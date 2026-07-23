using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Debug;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Initializations;

[MemoryDiagnoser]
// [SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class QuantityDisplayBenchmarksConversions
{
    // [Params(1000)]
    [Params(1)]
    public int NbIterations { get; set; }

    public VolumeFlow Quantity { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithQuantities([VolumeFlow.Info]));
        Quantity = VolumeFlow.From(42, VolumeFlowUnit.LiterPerHour);
    }
    
    [Benchmark(Baseline = false)]
    public void CreateWithIQuantity()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            var quantityInfo = new QuantityDebugProxy(Quantity);
            var name = quantityInfo.Quantity.ToString();
            var unit = quantityInfo.Unit.ToString();
            var unitAbbreviation = quantityInfo.UnitAbbreviation.ToString();
            var value = quantityInfo.Value.ToString("G");
            var format = quantityInfo.ValueFormats.ToString();
            
            foreach (var quantityUnitConversion in quantityInfo.Quantity.UnitConversions)
            {
                foreach (var unitConversion in quantityUnitConversion.Unit.UnitConversions)
                {
                    var quantityDisplay = unitConversion.Quantity;  
                    // name = quantityDisplay.Quantity.ToString();
                    // unit = quantityDisplay.Unit.ToString();
                    // unitAbbreviation = quantityDisplay.UnitAbbreviation.ToString();
                    // value = quantityDisplay.Value.ToString("G");
                    // format = quantityDisplay.ValueFormats.ToString();
                }
                // foreach (var unitConversion in quantityUnitConversion.UnitAbbreviation.DefaultAbbreviations)
                // {
                //     var quantityDisplay = unitConversion.Quantity;
                //     // name = quantityDisplay.Quantity.ToString();
                //     // unit = quantityDisplay.Unit.ToString();
                //     // unitAbbreviation = quantityDisplay.UnitAbbreviation.ToString();
                //     // value = quantityDisplay.Value.ToString("G");
                //     // format = quantityDisplay.ValueFormats.ToString();
                // }
            }
            
            foreach (var quantityUnitConversion in quantityInfo.Unit.UnitConversions)
            {
                foreach (var unitConversion in quantityUnitConversion.Quantity.Unit.UnitConversions)
                {
                    var quantityDisplay = unitConversion.Quantity;
                    // name = quantityDisplay.Quantity.ToString();
                    // unit = quantityDisplay.Unit.ToString();
                    // unitAbbreviation = quantityDisplay.UnitAbbreviation.ToString();
                    // value = quantityDisplay.Value.ToString("G");
                    // format = quantityDisplay.ValueFormats.ToString();
                }
                // foreach (var unitConversion in quantityUnitConversion.Quantity.UnitAbbreviation.DefaultAbbreviations)
                // {
                //     var quantityDisplay = unitConversion.Quantity;
                //     // name = quantityDisplay.Quantity.ToString();
                //     // unit = quantityDisplay.Unit.ToString();
                //     // unitAbbreviation = quantityDisplay.UnitAbbreviation.ToString();
                //     // value = quantityDisplay.Value.ToString("G");
                //     // format = quantityDisplay.ValueFormats.ToString();
                // }
            }
            
            // foreach (var quantityUnitConversion in quantityInfo.UnitAbbreviation.DefaultAbbreviations)
            // {
            //     foreach (var unitConversion in quantityUnitConversion.Quantity.Unit.UnitConversions)
            //     {
            //         var quantityDisplay = unitConversion.Quantity;
            //         // name = quantityDisplay.Quantity.ToString();
            //         // unit = quantityDisplay.Unit.ToString();
            //         // unitAbbreviation = quantityDisplay.UnitAbbreviation.ToString();
            //         // value = quantityDisplay.Value.ToString("G");
            //         // format = quantityDisplay.ValueFormats.ToString();
            //     }
            //     foreach (var unitConversion in quantityUnitConversion.Quantity.UnitAbbreviation.DefaultAbbreviations)
            //     {
            //         var quantityDisplay = unitConversion.Quantity;
            //         // name = quantityDisplay.Quantity.ToString();
            //         // unit = quantityDisplay.Unit.ToString();
            //         // unitAbbreviation = quantityDisplay.UnitAbbreviation.ToString();
            //         // value = quantityDisplay.Value.ToString("G");
            //         // format = quantityDisplay.ValueFormats.ToString();
            //     }
            // }

        }
    }
}
