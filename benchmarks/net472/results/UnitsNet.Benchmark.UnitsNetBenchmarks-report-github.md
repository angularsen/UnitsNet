``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-SQVEIU : .NET Framework 4.8 (4.8.4470.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.88 ns |     0.329 ns |     0.392 ns |      - |      - |     - |         - |
|         Constructor_SI |    610.62 ns |    11.740 ns |    14.848 ns | 0.0276 |      - |     - |     201 B |
|             FromMethod |     41.67 ns |     0.406 ns |     0.380 ns |      - |      - |     - |         - |
|             ToProperty |    281.76 ns |     4.387 ns |     4.103 ns | 0.0158 |      - |     - |     112 B |
|                     As |    269.45 ns |     5.324 ns |     8.130 ns | 0.0157 |      - |     - |     112 B |
|                  As_SI |    603.14 ns |    11.822 ns |    14.519 ns | 0.0271 |      - |     - |     201 B |
|                 ToUnit |    274.21 ns |     5.086 ns |     7.612 ns | 0.0160 |      - |     - |     112 B |
|              ToUnit_SI |    630.65 ns |    12.256 ns |    18.345 ns | 0.0280 |      - |     - |     201 B |
|           ToStringTest |  2,121.27 ns |    41.983 ns |    61.539 ns | 0.1798 |      - |     - |    1220 B |
|                  Parse | 69,854.38 ns | 1,371.080 ns | 2,214.039 ns | 8.2888 | 0.2810 |     - |   55324 B |
|          TryParseValid | 67,466.76 ns | 1,299.927 ns | 1,596.427 ns | 8.3301 | 0.2563 |     - |   55300 B |
|        TryParseInvalid | 72,952.61 ns | 1,432.101 ns | 1,862.136 ns | 8.1697 | 0.2867 |     - |   54842 B |
|           QuantityFrom |    120.98 ns |     2.492 ns |     3.805 ns | 0.0081 |      - |     - |      56 B |
|           IQuantity_As |    276.83 ns |     5.500 ns |     6.334 ns | 0.0194 |      - |     - |     136 B |
|        IQuantity_As_SI |    605.64 ns |    11.802 ns |    16.154 ns | 0.0280 |      - |     - |     201 B |
|       IQuantity_ToUnit |    305.32 ns |     6.067 ns |     9.623 ns | 0.0244 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,225.86 ns |    37.278 ns |    34.870 ns | 0.1799 |      - |     - |    1220 B |
