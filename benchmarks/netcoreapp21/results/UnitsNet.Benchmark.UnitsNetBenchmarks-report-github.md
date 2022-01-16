``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-KNVEMX : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |       Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.22 ns |     0.162 ns |     0.144 ns |     13.21 ns |      - |      - |     - |         - |
|         Constructor_SI |    637.00 ns |     8.195 ns |     6.843 ns |    636.54 ns | 0.0269 |      - |     - |     192 B |
|             FromMethod |     31.68 ns |     0.434 ns |     0.406 ns |     31.79 ns |      - |      - |     - |         - |
|             ToProperty |     10.27 ns |     0.241 ns |     0.214 ns |     10.28 ns |      - |      - |     - |         - |
|                     As |     10.31 ns |     0.257 ns |     0.306 ns |     10.23 ns |      - |      - |     - |         - |
|                  As_SI |    635.72 ns |    12.596 ns |    14.000 ns |    632.00 ns | 0.0270 |      - |     - |     192 B |
|                 ToUnit |     21.69 ns |     0.390 ns |     0.383 ns |     21.72 ns |      - |      - |     - |         - |
|              ToUnit_SI |    642.40 ns |    10.750 ns |    10.055 ns |    644.49 ns | 0.0272 |      - |     - |     192 B |
|           ToStringTest |  2,670.90 ns |    48.223 ns |    42.749 ns |  2,662.18 ns | 0.1366 |      - |     - |     952 B |
|                  Parse | 74,654.78 ns | 1,491.367 ns | 1,939.198 ns | 74,757.25 ns | 6.7476 | 0.1499 |     - |   44816 B |
|          TryParseValid | 76,175.27 ns | 1,515.080 ns | 1,417.207 ns | 75,745.73 ns | 6.7495 | 0.1534 |     - |   44792 B |
|        TryParseInvalid | 83,773.84 ns | 1,655.535 ns | 2,093.722 ns | 83,823.21 ns | 6.6600 | 0.1665 |     - |   44392 B |
|           QuantityFrom |  2,139.62 ns |    41.318 ns |    86.246 ns |  2,100.00 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     25.65 ns |     0.565 ns |     0.928 ns |     25.53 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    629.49 ns |    10.123 ns |     9.469 ns |    626.72 ns | 0.0271 |      - |     - |     192 B |
|       IQuantity_ToUnit |     33.78 ns |     0.650 ns |     0.608 ns |     33.88 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,688.09 ns |    49.965 ns |    46.738 ns |  2,693.91 ns | 0.1363 |      - |     - |     952 B |
