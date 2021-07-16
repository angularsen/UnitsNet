``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2029 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.302
  [Host]     : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT
  Job-UFKUKN : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |       Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.02 ns |     0.088 ns |     0.078 ns |     13.02 ns |      - |      - |     - |         - |
|         Constructor_SI |    602.94 ns |    11.588 ns |    10.840 ns |    600.58 ns | 0.0271 |      - |     - |     192 B |
|             FromMethod |     29.51 ns |     0.584 ns |     0.546 ns |     29.41 ns |      - |      - |     - |         - |
|             ToProperty |     10.30 ns |     0.251 ns |     0.360 ns |     10.36 ns |      - |      - |     - |         - |
|                     As |     10.23 ns |     0.247 ns |     0.312 ns |     10.11 ns |      - |      - |     - |         - |
|                  As_SI |    614.00 ns |    10.686 ns |     9.996 ns |    613.98 ns | 0.0271 |      - |     - |     192 B |
|                 ToUnit |     20.66 ns |     0.234 ns |     0.207 ns |     20.68 ns |      - |      - |     - |         - |
|              ToUnit_SI |    628.64 ns |     6.342 ns |     5.932 ns |    629.15 ns | 0.0278 |      - |     - |     192 B |
|           ToStringTest |  2,436.17 ns |    46.234 ns |    53.243 ns |  2,427.66 ns | 0.1387 |      - |     - |     952 B |
|                  Parse | 69,464.29 ns | 1,360.354 ns | 1,768.844 ns | 69,350.63 ns | 6.7326 | 0.1374 |     - |   44816 B |
|          TryParseValid | 70,667.15 ns |   978.630 ns |   915.411 ns | 70,732.31 ns | 6.8346 | 0.1340 |     - |   44792 B |
|        TryParseInvalid | 73,754.43 ns | 1,390.381 ns | 1,427.819 ns | 73,434.06 ns | 6.6002 | 0.1535 |     - |   44392 B |
|           QuantityFrom |  1,843.59 ns |    36.720 ns |    94.786 ns |  1,800.00 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     22.39 ns |     0.436 ns |     0.408 ns |     22.39 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    589.18 ns |    11.374 ns |    11.680 ns |    592.08 ns | 0.0283 |      - |     - |     192 B |
|       IQuantity_ToUnit |     31.30 ns |     0.695 ns |     0.683 ns |     31.22 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,285.94 ns |    33.029 ns |    30.896 ns |  2,282.80 ns | 0.1394 |      - |     - |     952 B |
