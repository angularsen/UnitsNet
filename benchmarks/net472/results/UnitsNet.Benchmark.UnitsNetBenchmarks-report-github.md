``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2452 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-SDYEES : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.622 ns |   0.0315 ns |   0.0295 ns |     12.626 ns |      - |      - |     - |         - |
|         Constructor_SI |    500.659 ns |   1.6615 ns |   1.5542 ns |    500.792 ns | 0.0298 |      - |     - |     201 B |
|             FromMethod |     29.926 ns |   0.0971 ns |   0.0908 ns |     29.921 ns |      - |      - |     - |         - |
|             ToProperty |      8.484 ns |   0.0237 ns |   0.0222 ns |      8.487 ns |      - |      - |     - |         - |
|                     As |      8.484 ns |   0.0321 ns |   0.0300 ns |      8.477 ns |      - |      - |     - |         - |
|                  As_SI |    475.758 ns |   2.3272 ns |   2.1769 ns |    475.601 ns | 0.0296 |      - |     - |     201 B |
|                 ToUnit |     19.352 ns |   0.0607 ns |   0.0568 ns |     19.348 ns |      - |      - |     - |         - |
|              ToUnit_SI |    502.380 ns |   2.0245 ns |   1.8937 ns |    502.360 ns | 0.0295 |      - |     - |     201 B |
|           ToStringTest |  1,800.187 ns |   8.8156 ns |   8.2461 ns |  1,800.175 ns | 0.1854 |      - |     - |    1220 B |
|                  Parse | 52,437.317 ns | 212.1084 ns | 177.1201 ns | 52,459.539 ns | 8.3770 | 0.3141 |     - |   54376 B |
|          TryParseValid | 52,221.180 ns | 169.1921 ns | 141.2831 ns | 52,234.637 ns | 8.3638 | 0.3136 |     - |   54353 B |
|        TryParseInvalid | 56,365.362 ns | 198.9397 ns | 186.0883 ns | 56,326.232 ns | 8.3099 | 0.3369 |     - |   53895 B |
|           QuantityFrom |  2,345.455 ns |  39.7963 ns | 102.0132 ns |  2,300.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     17.452 ns |   0.0553 ns |   0.0490 ns |     17.459 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    555.114 ns |   7.5362 ns |   7.0493 ns |    555.641 ns | 0.0293 |      - |     - |     201 B |
|       IQuantity_ToUnit |     27.650 ns |   0.1161 ns |   0.1086 ns |     27.687 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,833.760 ns |  12.6427 ns |  11.8260 ns |  1,833.110 ns | 0.1843 |      - |     - |    1220 B |
