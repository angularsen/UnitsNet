``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-SRFLCU : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.327 ns |     0.2916 ns |     0.3892 ns |      - |      - |     - |         - |
|         Constructor_SI |    603.810 ns |    12.0969 ns |    17.7315 ns | 0.0278 |      - |     - |     192 B |
|             FromMethod |     29.183 ns |     0.4671 ns |     0.4141 ns |      - |      - |     - |         - |
|             ToProperty |      9.607 ns |     0.2367 ns |     0.2630 ns |      - |      - |     - |         - |
|                     As |      9.525 ns |     0.2318 ns |     0.2846 ns |      - |      - |     - |         - |
|                  As_SI |    591.884 ns |    10.9078 ns |    10.2031 ns | 0.0280 |      - |     - |     192 B |
|                 ToUnit |     20.799 ns |     0.3697 ns |     0.3458 ns |      - |      - |     - |         - |
|              ToUnit_SI |    600.900 ns |    11.5591 ns |    13.7603 ns | 0.0271 |      - |     - |     192 B |
|           ToStringTest |  2,362.483 ns |    45.5762 ns |    65.3640 ns | 0.1381 |      - |     - |     952 B |
|                  Parse | 68,835.448 ns | 1,107.6241 ns | 1,036.0722 ns | 6.8390 | 0.1368 |     - |   44816 B |
|          TryParseValid | 70,740.654 ns | 1,391.4842 ns | 1,546.6310 ns | 6.8027 | 0.1361 |     - |   44792 B |
|        TryParseInvalid | 75,144.468 ns | 1,042.4443 ns |   924.0998 ns | 6.6536 | 0.1512 |     - |   44392 B |
|           QuantityFrom |  2,204.651 ns |    53.4616 ns |   145.4462 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     23.359 ns |     0.4172 ns |     0.3698 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    591.755 ns |    11.8619 ns |    12.1813 ns | 0.0281 |      - |     - |     192 B |
|       IQuantity_ToUnit |     31.190 ns |     0.7190 ns |     0.8831 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,314.136 ns |    45.3765 ns |    44.5658 ns | 0.1402 |      - |     - |     952 B |
