// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Benchmark.Conversions.FromString.Value;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class BigIntegerSerializationBenchmarks
{
    private static readonly JsonSerializerOptions SpanOptions = CreateSpanOptions();

    // private static BigInteger Value = BigInteger.Parse("123456789012345678901234567890", CultureInfo.InvariantCulture);
    // [Params("\"42\"", "\"123456789012345678901234567890\"", "\"12345\\u0034\\u0035\"")]
    [Params("42", "123456789012345678901234567890")]
    public string Value { get; set; }

    private static JsonSerializerOptions CreateSpanOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new BigIntegerConverter());
        return options;
    }

    [Benchmark(Baseline = true)]
    public BigInteger DeserializeFromSpan()
    {
        return JsonSerializer.Deserialize<BigInteger>(Value, SpanOptions);
    }
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net48)]
public class StringInterpolationBenchmarks
{
    // private readonly BigInteger Numerator = BigInteger.Parse("123456789012345678901234567890");
    // private readonly BigInteger Denominator = 5678901234567890;
    private readonly BigInteger Denominator = 1;
    private readonly BigInteger Numerator = 3;


    [Benchmark(Baseline = true)]
    public int StringInterpolation()
    {
        var stringValue = $"{Numerator}/{Denominator}";
        return stringValue.Length;
    }

    [Benchmark]
    public int CharacterAddition()
    {
        var stringValue = Numerator.ToString() + '/' + Denominator;
        return stringValue.Length;
    }

    [Benchmark]
    public int SpanConcatenation()
    {
#if NET
        Span<char> charBuffer = stackalloc char[512];
        int numeratorCharsWritten;
        while (!Numerator.TryFormat(charBuffer, out numeratorCharsWritten, provider: NumberFormatInfo.InvariantInfo))
        {
            charBuffer = new char[charBuffer.Length * 2];
        }

        charBuffer[numeratorCharsWritten] = '.';

        int denominatorCharsWritten;
        while (!Denominator.TryFormat(charBuffer[(numeratorCharsWritten + 1)..], out denominatorCharsWritten, provider: NumberFormatInfo.InvariantInfo))
        {
            var extendedBuffer = new char[charBuffer.Length * 2];
            charBuffer.CopyTo(extendedBuffer);
            charBuffer = extendedBuffer;
        }
        
        return numeratorCharsWritten + denominatorCharsWritten + 1;
#else
        var numeratorString = Numerator.ToString();
        var denominatorString = Denominator.ToString();
        Span<char> charBuffer = stackalloc char[numeratorString.Length + denominatorString.Length + 1];
        numeratorString.AsSpan().CopyTo(charBuffer);
        charBuffer[numeratorString.Length] = '.';
        denominatorString.AsSpan().CopyTo(charBuffer.Slice(numeratorString.Length + 1));
        return numeratorString.Length + denominatorString.Length + 1;
#endif
    }
}
