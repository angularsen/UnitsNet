``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-DSUFSC : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.80 ns |     0.237 ns |     0.198 ns |      - |      - |     - |         - |
|         Constructor_SI |    627.57 ns |    10.597 ns |     9.913 ns | 0.0260 |      - |     - |     192 B |
|             FromMethod |     36.76 ns |     0.608 ns |     0.569 ns |      - |      - |     - |         - |
|             ToProperty |    234.73 ns |     4.533 ns |     4.851 ns | 0.0162 |      - |     - |     112 B |
|                     As |    237.92 ns |     4.190 ns |     3.920 ns | 0.0159 |      - |     - |     112 B |
|                  As_SI |    632.11 ns |    12.322 ns |    18.816 ns | 0.0266 |      - |     - |     192 B |
|                 ToUnit |    224.91 ns |     3.255 ns |     2.718 ns | 0.0159 |      - |     - |     112 B |
|              ToUnit_SI |    594.15 ns |    10.057 ns |     8.915 ns | 0.0256 |      - |     - |     192 B |
|           ToStringTest |  2,141.72 ns |    42.644 ns |    58.372 ns | 0.1376 |      - |     - |     952 B |
|                  Parse | 72,520.20 ns | 1,439.866 ns | 2,283.781 ns | 6.6180 | 0.1379 |     - |   44816 B |
|          TryParseValid | 73,971.38 ns | 1,213.181 ns | 1,444.206 ns | 6.5416 | 0.1454 |     - |   44792 B |
|        TryParseInvalid | 78,797.99 ns | 1,534.097 ns | 2,296.164 ns | 6.5238 | 0.1553 |     - |   44392 B |
|           QuantityFrom |    107.48 ns |     2.192 ns |     2.251 ns | 0.0081 |      - |     - |      56 B |
|           IQuantity_As |    226.19 ns |     4.402 ns |     4.520 ns | 0.0197 |      - |     - |     136 B |
|        IQuantity_As_SI |    587.81 ns |     7.446 ns |     6.965 ns | 0.0254 |      - |     - |     192 B |
|       IQuantity_ToUnit |    238.81 ns |     4.493 ns |    11.759 ns | 0.0247 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,130.93 ns |    31.165 ns |    26.024 ns | 0.1352 |      - |     - |     952 B |
