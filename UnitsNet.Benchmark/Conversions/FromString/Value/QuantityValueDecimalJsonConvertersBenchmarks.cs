// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Benchmark.Conversions.FromString.Value;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net48)]
public class QuantityValueDecimalJsonConvertersBenchmarks
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
    
    private static readonly JsonSerializerOptions QuantityValueDecimalNotationG29ConverterOptions= CreateQuantityValueDecimalNotationG29ConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueDecimalNotationG29ConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalNotationConverter(29));
        return options;
    }

    private static readonly JsonSerializerOptions QuantityValueMixedNotationConverterOptions= CreateQuantityValueMixedNotationConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueMixedNotationConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueMixedNotationConverter());
        return options;
    }

    private static readonly JsonSerializerOptions QuantityValueDecimalConverterOptions= CreateQuantityValueValueDecimalConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueValueDecimalConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalConverter());
        return options;
    }
    
    [Benchmark(Baseline = false)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueDecimalNotationG29Converter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueDecimalNotationG29ConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueDecimalNotationG29ConverterOptions);
    }
    
    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueDecimalConverter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueDecimalConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueDecimalConverterOptions);
    }
    
    [Benchmark(Baseline = false)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueMixedNotationConverter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueMixedNotationConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueMixedNotationConverterOptions);
    }
}
