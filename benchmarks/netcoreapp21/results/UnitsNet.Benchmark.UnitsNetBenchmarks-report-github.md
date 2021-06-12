``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-XACVUN : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.39 ns |     0.315 ns |     0.337 ns |      - |      - |     - |         - |
|         Constructor_SI |    654.01 ns |     9.220 ns |     8.624 ns | 0.0275 |      - |     - |     192 B |
|             FromMethod |     31.71 ns |     0.570 ns |     0.533 ns |      - |      - |     - |         - |
|             ToProperty |     10.91 ns |     0.171 ns |     0.151 ns |      - |      - |     - |         - |
|                     As |     10.77 ns |     0.135 ns |     0.105 ns |      - |      - |     - |         - |
|                  As_SI |    638.79 ns |    12.396 ns |    12.730 ns | 0.0271 |      - |     - |     192 B |
|                 ToUnit |     21.89 ns |     0.284 ns |     0.252 ns |      - |      - |     - |         - |
|              ToUnit_SI |    671.91 ns |    12.378 ns |    14.735 ns | 0.0276 |      - |     - |     192 B |
|           ToStringTest |  2,754.18 ns |    53.738 ns |    55.185 ns | 0.1396 |      - |     - |     952 B |
|                  Parse | 76,803.96 ns | 1,523.763 ns | 1,630.409 ns | 6.8171 | 0.1515 |     - |   44816 B |
|          TryParseValid | 76,756.01 ns | 1,290.511 ns | 1,434.399 ns | 6.7966 | 0.1510 |     - |   44792 B |
|        TryParseInvalid | 82,521.92 ns | 1,636.198 ns | 1,680.254 ns | 6.7265 | 0.1602 |     - |   44392 B |
|           QuantityFrom |  1,945.05 ns |    62.961 ns |   176.549 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     24.99 ns |     0.399 ns |     0.373 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    642.45 ns |    10.485 ns |     9.808 ns | 0.0270 |      - |     - |     192 B |
|       IQuantity_ToUnit |     35.66 ns |     0.812 ns |     0.936 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,641.42 ns |    41.148 ns |    38.490 ns | 0.1389 |      - |     - |     952 B |
