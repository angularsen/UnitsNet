``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2452 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-PKOSQU : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.944 ns |     0.2760 ns |     0.6665 ns |     11.830 ns |      - |      - |     - |         - |
|         Constructor_SI |    547.437 ns |    10.9575 ns |    32.3084 ns |    544.007 ns | 0.0282 |      - |     - |     192 B |
|             FromMethod |     29.166 ns |     0.6171 ns |     1.2744 ns |     29.007 ns |      - |      - |     - |         - |
|             ToProperty |      8.229 ns |     0.2064 ns |     0.4616 ns |      8.056 ns |      - |      - |     - |         - |
|                     As |      7.918 ns |     0.2042 ns |     0.3629 ns |      7.836 ns |      - |      - |     - |         - |
|                  As_SI |    565.911 ns |    11.3400 ns |    25.8270 ns |    571.052 ns | 0.0288 |      - |     - |     192 B |
|                 ToUnit |     19.262 ns |     0.4176 ns |     0.6862 ns |     19.310 ns |      - |      - |     - |         - |
|              ToUnit_SI |    590.347 ns |    11.8104 ns |    25.9241 ns |    589.755 ns | 0.0288 |      - |     - |     192 B |
|           ToStringTest |  2,385.883 ns |    47.3890 ns |   130.5232 ns |  2,382.801 ns | 0.1412 |      - |     - |     952 B |
|                  Parse | 80,940.858 ns | 1,613.3351 ns | 4,306.3180 ns | 80,893.741 ns | 6.7405 | 0.1605 |     - |   44816 B |
|          TryParseValid | 77,569.942 ns | 1,634.0476 ns | 4,818.0261 ns | 76,333.162 ns | 6.7481 | 0.1607 |     - |   44792 B |
|        TryParseInvalid | 79,910.516 ns | 1,622.1365 ns | 4,782.9060 ns | 78,577.748 ns | 6.6473 | 0.1704 |     - |   44392 B |
|           QuantityFrom |  2,298.947 ns |    61.7420 ns |   177.1493 ns |  2,300.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     20.803 ns |     0.5089 ns |     1.5004 ns |     20.528 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    585.220 ns |    11.5952 ns |    14.6643 ns |    585.543 ns | 0.0283 |      - |     - |     192 B |
|       IQuantity_ToUnit |     30.459 ns |     0.7103 ns |     0.6297 ns |     30.302 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,223.502 ns |    44.3232 ns |   125.0145 ns |  2,203.035 ns | 0.1436 |      - |     - |     952 B |
