``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-NAJGBQ : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.45 ns |     0.232 ns |     0.217 ns |      - |      - |     - |         - |
|         Constructor_SI |    649.66 ns |    12.771 ns |    15.202 ns | 0.0269 |      - |     - |     192 B |
|             FromMethod |     31.91 ns |     0.678 ns |     0.634 ns |      - |      - |     - |         - |
|             ToProperty |     10.32 ns |     0.253 ns |     0.248 ns |      - |      - |     - |         - |
|                     As |     10.36 ns |     0.181 ns |     0.169 ns |      - |      - |     - |         - |
|                  As_SI |    664.66 ns |    13.048 ns |    13.961 ns | 0.0269 |      - |     - |     192 B |
|                 ToUnit |     21.61 ns |     0.269 ns |     0.239 ns |      - |      - |     - |         - |
|              ToUnit_SI |    638.59 ns |    12.810 ns |    11.983 ns | 0.0270 |      - |     - |     192 B |
|           ToStringTest |  2,632.48 ns |    34.995 ns |    31.022 ns | 0.1405 |      - |     - |     952 B |
|                  Parse | 75,680.28 ns | 1,487.437 ns | 2,085.179 ns | 6.7261 | 0.1462 |     - |   44816 B |
|          TryParseValid | 74,845.03 ns | 1,475.942 ns | 2,069.065 ns | 6.8111 | 0.1548 |     - |   44792 B |
|        TryParseInvalid | 82,503.06 ns | 1,610.249 ns | 1,977.530 ns | 6.7204 | 0.1680 |     - |   44392 B |
|           QuantityFrom |  2,316.48 ns |    57.075 ns |   160.044 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     24.56 ns |     0.543 ns |     0.604 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    623.05 ns |    12.311 ns |    11.515 ns | 0.0270 |      - |     - |     192 B |
|       IQuantity_ToUnit |     32.82 ns |     0.708 ns |     0.696 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,632.95 ns |    52.092 ns |    46.178 ns | 0.1367 |      - |     - |     952 B |
