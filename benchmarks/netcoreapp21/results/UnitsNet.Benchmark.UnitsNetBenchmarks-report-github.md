``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-RJRIDB : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.78 ns |     0.253 ns |     0.582 ns |      - |      - |     - |         - |
|         Constructor_SI |    483.21 ns |     6.067 ns |     4.737 ns | 0.0269 |      - |     - |     192 B |
|             FromMethod |     29.24 ns |     0.622 ns |     1.692 ns |      - |      - |     - |         - |
|             ToProperty |    229.91 ns |     5.375 ns |    15.763 ns | 0.0161 |      - |     - |     112 B |
|                     As |    236.55 ns |     4.770 ns |     7.970 ns | 0.0164 |      - |     - |     112 B |
|                  As_SI |    637.63 ns |    12.674 ns |    14.595 ns | 0.0256 |      - |     - |     192 B |
|                 ToUnit |    221.06 ns |     4.404 ns |     8.795 ns | 0.0159 |      - |     - |     112 B |
|              ToUnit_SI |    625.38 ns |    12.538 ns |    13.936 ns | 0.0261 |      - |     - |     192 B |
|           ToStringTest |  2,353.92 ns |    29.951 ns |    25.010 ns | 0.1333 |      - |     - |     952 B |
|                  Parse | 74,799.45 ns | 1,476.582 ns | 3,302.587 ns | 6.6885 | 0.1365 |     - |   44816 B |
|          TryParseValid | 71,503.51 ns | 1,386.043 ns | 1,649.985 ns | 6.5471 | 0.1423 |     - |   44792 B |
|        TryParseInvalid | 75,927.31 ns | 1,515.401 ns | 3,630.803 ns | 6.5240 | 0.1517 |     - |   44392 B |
|           QuantityFrom |    105.57 ns |     2.099 ns |     3.994 ns | 0.0082 |      - |     - |      56 B |
|           IQuantity_As |    245.88 ns |     4.894 ns |     8.177 ns | 0.0199 |      - |     - |     136 B |
|        IQuantity_As_SI |    552.80 ns |    11.058 ns |    24.503 ns | 0.0262 |      - |     - |     192 B |
|       IQuantity_ToUnit |    228.53 ns |     5.178 ns |    15.267 ns | 0.0253 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,146.15 ns |    42.304 ns |    93.743 ns | 0.1382 |      - |     - |     952 B |
