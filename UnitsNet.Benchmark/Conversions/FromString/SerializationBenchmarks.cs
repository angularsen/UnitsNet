using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Serialization.SystemTextJson;
using UnitsNet.Serialization.SystemTextJson.Unit;
using UnitsNet.Serialization.SystemTextJson.Value;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.FromString;

[JsonSourceGenerationOptions(Converters = [typeof(JsonQuantityConverter), typeof(QuantityValueFractionalNotationConverter)])]
[JsonSerializable(typeof(Mass))]
public partial class DefaultEnumConverterJsonContext : JsonSerializerContext
{
}

[JsonSourceGenerationOptions(Converters = [typeof(JsonQuantityConverter), typeof(UnitTypeAndNameConverter), typeof(QuantityValueFractionalNotationConverter)])]
[JsonSerializable(typeof(Mass))]
public partial class UnitTypeAndNameJsonContext : JsonSerializerContext
{
}

[JsonSourceGenerationOptions(Converters = [typeof(JsonQuantityConverter), typeof(AbbreviatedUnitConverter), typeof(QuantityValueFractionalNotationConverter)])]
[JsonSerializable(typeof(Mass))]
public partial class AbbreviatedUnitJsonContext : JsonSerializerContext
{
}

// [JsonSourceGenerationOptions(Converters = [typeof(AbbreviatedQuantityConverter<Mass, MassUnit>)])]
[JsonSourceGenerationOptions(Converters = [typeof(AbbreviatedQuantityConverter)])]
[JsonSerializable(typeof(Mass))]
public partial class AbbreviatedQuantityJsonContext : JsonSerializerContext
{
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
// [DryJob(RuntimeMoniker.Net80)]
public class MassSerializationBenchmarks
{
    
    public const int NbIterations = 1000;
    // public const int NbIterations = 1;

    private static Mass[] TestMasses =
    [
        Mass.Zero, new Mass(0, MassUnit.Gram), new Mass(42, MassUnit.Gram), new Mass(42, MassUnit.Kilogram), new Mass(123.45m, MassUnit.Milligram)
    ];
    // private static Volume[] TestVolumes =
    // [
    //     Volume.Zero, new Volume(0, VolumeUnit.Milliliter), new Volume(42, VolumeUnit.Milliliter), new Volume(42, VolumeUnit.CubicMeter), new Volume(123.45m, VolumeUnit.Microliter)
    // ];
    //
    // public record TestObject(Mass[] Masses, Volume[] Volumes);
    //
    // private static TestObject Values = new(TestMasses, TestVolumes);

    [GlobalSetup]
    public void Setup()
    {
        var _ = Mass.Zero.ToString("G", CultureInfo.InvariantCulture);
    }
    
    [Benchmark(Baseline = true)]
    public void RoundTripWithDefaultEnumConverterJsonContext()
    {
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, DefaultEnumConverterJsonContext.Default.Mass);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<Mass>(json, DefaultEnumConverterJsonContext.Default.Mass);
                // Console.Out.WriteLine("json = {0}", json);
                if (mass != deserializedMass)
                {
                    throw new InvalidDataException();
                }
            }
        }
    }

    [Benchmark(Baseline = false)]
    public void RoundTripWithUnitTypeAndNameJsonContext()
    {
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, UnitTypeAndNameJsonContext.Default.Mass);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<Mass>(json, UnitTypeAndNameJsonContext.Default.Mass);
                // Console.Out.WriteLine("json = {0}", json);
                if (mass != deserializedMass)
                {
                    throw new InvalidDataException();
                }
            }
        }
    }

    [Benchmark(Baseline = false)]
    public void RoundTripWithAbbreviatedUnitJsonContext()
    {
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, AbbreviatedUnitJsonContext.Default.Mass);
                // Console.Out.WriteLine("json = {0}", json);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<Mass>(json, AbbreviatedUnitJsonContext.Default.Mass);
                if (mass != deserializedMass)
                {
                    throw new InvalidDataException();
                }
            }
        }
    }
    
    [Benchmark(Baseline = false)]
    public void RoundTripWithAbbreviatedQuantityJsonContext()
    {
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, AbbreviatedUnitJsonContext.Default.Mass);
                // Console.Out.WriteLine("json = {0}", json);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<Mass>(json, AbbreviatedUnitJsonContext.Default.Mass);
                if (mass != deserializedMass)
                {
                    throw new InvalidDataException();
                }
            }
        }
    }
    
    [Benchmark(Baseline = false)]
    public void RoundTripWithJsonConverterWithUnitTypeAndNameConverter()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonQuantityConverter());
        options.Converters.Add(new UnitTypeAndNameConverter());
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, options);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<Mass>(json, options);
                if (mass != deserializedMass)
                {
                    throw new InvalidDataException();
                }
            }
        }
    }
    
    [Benchmark(Baseline = false)]
    public void RoundTripWithJsonQuantityConverterAndAbbreviatedUnitConverter()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonQuantityConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, options);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<Mass>(json, options);
                if (mass != deserializedMass)
                {
                    throw new InvalidDataException();
                }
            }
        }
    }

    [Benchmark(Baseline = false)]
    public void RoundTripWithAbbreviatedQuantityConverter()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedQuantityConverter());
        
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, options);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<Mass>(json, options);
                if (mass != deserializedMass)
                {
                    throw new InvalidDataException();
                }
            }
        }
    }

}


[JsonSourceGenerationOptions(Converters = [typeof(QuantityValueMixedNotationConverter), typeof(AbbreviatedInterfaceQuantityWithAvailableValueConverter)])]
[JsonSerializable(typeof(Mass))]
public partial class AbbreviatedInterfaceQuantityJsonContext : JsonSerializerContext
{
}

[MemoryDiagnoser]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net48)]
// [DryJob(RuntimeMoniker.Net48)]
// [SimpleJob(RuntimeMoniker.Net90)]
// [DryJob(RuntimeMoniker.Net80)]
public class InterfaceQuantitySerializationBenchmarks
{

    public const int NbIterations = 1000;
    // public const int NbIterations = 1;

    private static IQuantity[] TestMasses =
    [
        Mass.Zero, new Mass(0, MassUnit.Gram), new Mass(42, MassUnit.Gram), new Mass(42, MassUnit.Kilogram), new Mass(123.45m, MassUnit.Milligram)
    ];

    [Benchmark(Baseline = false)]
    public void RoundTripWithAbbreviatedInterfaceQuantityConverter()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueMixedNotationConverter.Default);
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithAvailableValueConverter());
        
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, options);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<IQuantity>(json, options);
                // if (!Equals(mass, deserializedMass))
                // {
                //     throw new InvalidDataException();
                // }
            }
        }
    }

    [Benchmark(Baseline = true)]
    public void RoundTripWithAbbreviatedInterfaceQuantityConverterWithValueConverter()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));
        
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, options);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<IQuantity>(json, options);
                // if (!Equals(mass, deserializedMass))
                // {
                //     throw new InvalidDataException();
                // }
            }
        }
    }

    [Benchmark(Baseline = false)]
    public void RoundTripWithAbbreviatedUnitJsonContext()
    {
        for (int i = 0; i < NbIterations; i++)
        {
            foreach (var mass in TestMasses)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(mass, AbbreviatedInterfaceQuantityJsonContext.Default.IQuantity);
                // Console.Out.WriteLine("json = {0}", json);
                var deserializedMass = System.Text.Json.JsonSerializer.Deserialize<IQuantity>(json, AbbreviatedInterfaceQuantityJsonContext.Default.IQuantity);
                // if (!Equals(mass, deserializedMass))
                // {
                //     throw new InvalidDataException();
                // }
            }
        }
    }
}
