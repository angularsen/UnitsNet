``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-UAMGUR : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.89 ns |     0.280 ns |     0.411 ns |      - |      - |     - |         - |
|         Constructor_SI |    553.35 ns |    11.046 ns |    11.819 ns | 0.0287 |      - |     - |     192 B |
|             FromMethod |     30.80 ns |     0.625 ns |     0.614 ns |      - |      - |     - |         - |
|             ToProperty |    215.06 ns |     3.876 ns |     3.625 ns | 0.0171 |      - |     - |     112 B |
|                     As |    232.77 ns |     4.504 ns |     4.625 ns | 0.0169 |      - |     - |     112 B |
|                  As_SI |    574.79 ns |    11.502 ns |    24.760 ns | 0.0287 |      - |     - |     192 B |
|                 ToUnit |    208.53 ns |     3.987 ns |     4.747 ns | 0.0170 |      - |     - |     112 B |
|              ToUnit_SI |    575.88 ns |    11.311 ns |    18.584 ns | 0.0282 |      - |     - |     192 B |
|           ToStringTest |  2,422.35 ns |    44.470 ns |    41.597 ns | 0.1429 |      - |     - |     952 B |
|                  Parse | 72,062.94 ns | 1,335.190 ns | 1,248.938 ns | 6.9051 | 0.1381 |     - |   44816 B |
|          TryParseValid | 72,693.70 ns | 1,227.353 ns | 1,313.254 ns | 6.7792 | 0.1442 |     - |   44792 B |
|        TryParseInvalid | 79,314.59 ns | 1,269.410 ns | 1,187.407 ns | 6.7167 | 0.1562 |     - |   44392 B |
|           QuantityFrom |    110.45 ns |     1.481 ns |     1.385 ns | 0.0084 |      - |     - |      56 B |
|           IQuantity_As |    229.65 ns |     4.128 ns |     3.659 ns | 0.0206 |      - |     - |     136 B |
|        IQuantity_As_SI |    547.06 ns |    10.398 ns |     9.726 ns | 0.0281 |      - |     - |     192 B |
|       IQuantity_ToUnit |    230.14 ns |     4.705 ns |     6.282 ns | 0.0257 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,472.85 ns |    36.791 ns |    32.614 ns | 0.1403 |      - |     - |     952 B |
