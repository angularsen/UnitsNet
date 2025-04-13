using System.Collections.Generic;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Benchmark.Conversions.FromString.Value;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net48)]
public class QuantityValueFractionalNotationConverterBenchmarksPi
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
        QuantityValue.PI,
    ];

    private static readonly JsonSerializerOptions QuantityValueFractionalNotationConverterOptions = CreateQuantityValueFractionalNotationConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueFractionalNotationConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        return options;
    }

    private static readonly JsonSerializerOptions QuantityValueFractionalNotationReducingConverterOptions = CreateQuantityValueFractionalNotationReducingConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueFractionalNotationReducingConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueFractionalNotationConverter.Reducing);
        return options;
    }

    private static readonly JsonSerializerOptions QuantityValueMixedNotationConverterOptions= CreateQuantityValueMixedNotationConverterOptions();
    private static JsonSerializerOptions CreateQuantityValueMixedNotationConverterOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueMixedNotationConverter.Default);
        return options;
    }
    
    // // private static BigInteger Value = BigInteger.Parse("123456789012345678901234567890", CultureInfo.InvariantCulture);
    // // [Params("\"42\"", "\"123456789012345678901234567890\"", "\"12345\\u0034\\u0035\"")]
    // [Params("""{"N":42,"D":10}""", """{"N":12345678901234567890123456789,"D":10000000}""")]
    // public string Value { get; set; }
    //
    // private static readonly JsonSerializerOptions ConverterOptions = CreateConverterOptions();
    // private static JsonSerializerOptions CreateConverterOptions()
    // {
    //     var options = new JsonSerializerOptions();
    //     options.Converters.Add(new QuantityValueFractionalNotationConverter());
    //     return options;
    // }
    //
    // [Benchmark(Baseline = true)]
    // public QuantityValue DeserializeWithConverter()
    // {
    //     return System.Text.Json.JsonSerializer.Deserialize<QuantityValue>(Value, ConverterOptions);
    // }
    
    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueFractionalNotationConverter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueFractionalNotationConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueFractionalNotationConverterOptions);
    }
    
    [Benchmark(Baseline = false)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueFractionalNotationReducingConverter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueFractionalNotationReducingConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueFractionalNotationReducingConverterOptions);
    }
    
    [Benchmark(Baseline = false)]
    [ArgumentsSource(nameof(TestValues))]
    public QuantityValue RoundTripWithQuantityValueMixedNotationConverter(QuantityValue value)
    {
        var json = JsonSerializer.Serialize(value, QuantityValueMixedNotationConverterOptions);
        return JsonSerializer.Deserialize<QuantityValue>(json, QuantityValueMixedNotationConverterOptions);
    }
}
