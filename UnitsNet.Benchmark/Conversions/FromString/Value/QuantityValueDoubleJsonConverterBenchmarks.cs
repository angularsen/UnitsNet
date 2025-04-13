using System.Collections.Generic;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Benchmark.Conversions.FromString.Value;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net48)]
public class QuantityValueDoubleJsonConverterBenchmarks
{
    public static IEnumerable<QuantityValue> TestValues => [
        42,
        123456789,
        12.345m,
        9187654321.23m,
        0.42m,
        0.000012345m,
        QuantityValue.FromTerms(3_450_000, 100_000),
        QuantityValue.FromTerms(50, 600),
    ];

    private static readonly JsonSerializerOptions QuantityValueDecimalNotationG17ConverterOptions= CreateQuantityValueDecimalNotationG17ConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueDecimalNotationG17ConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        return options;
    }

    private static readonly JsonSerializerOptions QuantityValueMixedNotationConverterOptions= CreateQuantityValueMixedNotationConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueMixedNotationConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueMixedNotationConverter());
        return options;
    }

    private static readonly JsonSerializerOptions QuantityValueDoubleConverterOptions= CreateQuantityValueValueDoubleConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueValueDoubleConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDoubleConverter());
        return options;
    }
    
    [Benchmark(Baseline = false)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueDecimalNotationG17Converter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueDecimalNotationG17ConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueDecimalNotationG17ConverterOptions);
    }
    
    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueDoubleConverter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueDoubleConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueDoubleConverterOptions);
    }
    
    [Benchmark(Baseline = false)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueMixedNotationConverter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueMixedNotationConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueMixedNotationConverterOptions);
    }
}
