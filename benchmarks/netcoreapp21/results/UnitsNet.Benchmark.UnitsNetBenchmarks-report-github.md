``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-ZUMCGY : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |       Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.47 ns |     0.226 ns |     0.324 ns |     10.40 ns |      - |      - |     - |         - |
|         Constructor_SI |    503.68 ns |    10.024 ns |     9.377 ns |    502.68 ns | 0.0269 |      - |     - |     192 B |
|             FromMethod |     29.25 ns |     0.617 ns |     0.885 ns |     29.36 ns |      - |      - |     - |         - |
|             ToProperty |    190.32 ns |     3.828 ns |     5.960 ns |    189.96 ns | 0.0162 |      - |     - |     112 B |
|                     As |    183.64 ns |     3.635 ns |     5.972 ns |    183.85 ns | 0.0163 |      - |     - |     112 B |
|                  As_SI |    507.20 ns |     9.804 ns |    10.490 ns |    507.15 ns | 0.0271 |      - |     - |     192 B |
|                 ToUnit |    199.36 ns |     3.982 ns |    11.166 ns |    202.66 ns | 0.0166 |      - |     - |     112 B |
|              ToUnit_SI |    545.87 ns |    10.923 ns |    15.312 ns |    539.78 ns | 0.0265 |      - |     - |     192 B |
|           ToStringTest |  1,951.13 ns |    37.775 ns |    54.176 ns |  1,947.00 ns | 0.1368 |      - |     - |     952 B |
|                  Parse | 67,663.26 ns | 1,350.171 ns | 1,658.131 ns | 67,355.05 ns | 6.9949 | 0.1372 |     - |   47008 B |
|          TryParseValid | 65,913.11 ns | 1,280.904 ns | 1,475.091 ns | 66,103.62 ns | 7.0189 | 0.2649 |     - |   46984 B |
|        TryParseInvalid | 70,280.09 ns | 1,400.892 ns | 1,310.395 ns | 70,027.93 ns | 6.9492 | 0.2725 |     - |   46584 B |
|           QuantityFrom |     94.34 ns |     1.938 ns |     2.307 ns |     94.27 ns | 0.0082 |      - |     - |      56 B |
|           IQuantity_As |    191.40 ns |     3.646 ns |     3.744 ns |    192.13 ns | 0.0203 |      - |     - |     136 B |
|        IQuantity_As_SI |    694.60 ns |    13.783 ns |    12.893 ns |    694.70 ns | 0.0259 |      - |     - |     192 B |
|       IQuantity_ToUnit |    192.21 ns |     3.497 ns |     3.100 ns |    192.01 ns | 0.0253 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,036.57 ns |    40.341 ns |    71.706 ns |  2,050.28 ns | 0.1380 |      - |     - |     952 B |
