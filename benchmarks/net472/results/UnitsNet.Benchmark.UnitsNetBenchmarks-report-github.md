``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.401
  [Host]     : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT
  Job-ODDNIP : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.363 ns |     0.2727 ns |     0.2551 ns |      - |      - |     - |         - |
|         Constructor_SI |    607.483 ns |    10.1193 ns |     9.4656 ns | 0.0275 |      - |     - |     201 B |
|             FromMethod |     38.184 ns |     0.6680 ns |     0.6248 ns |      - |      - |     - |         - |
|             ToProperty |     10.127 ns |     0.2338 ns |     0.2187 ns |      - |      - |     - |         - |
|                     As |      9.950 ns |     0.1239 ns |     0.1098 ns |      - |      - |     - |         - |
|                  As_SI |    612.650 ns |     8.1736 ns |     6.8253 ns | 0.0279 |      - |     - |     201 B |
|                 ToUnit |     23.550 ns |     0.3405 ns |     0.3185 ns |      - |      - |     - |         - |
|              ToUnit_SI |    629.668 ns |    12.2861 ns |    12.6170 ns | 0.0271 |      - |     - |     201 B |
|           ToStringTest |  2,403.460 ns |    44.4211 ns |    41.5515 ns | 0.1785 |      - |     - |    1220 B |
|                  Parse | 67,958.523 ns | 1,092.9784 ns | 1,169.4746 ns | 8.1182 | 0.2662 |     - |   54377 B |
|          TryParseValid | 66,349.333 ns |   888.6590 ns |   831.2522 ns | 8.1506 | 0.2811 |     - |   54352 B |
|        TryParseInvalid | 71,435.368 ns | 1,010.6284 ns |   945.3424 ns | 8.0782 | 0.2834 |     - |   53895 B |
|           QuantityFrom |  2,836.458 ns |    60.9970 ns |   175.9903 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     21.729 ns |     0.3669 ns |     0.3064 ns | 0.0036 |      - |     - |      24 B |
|        IQuantity_As_SI |    625.750 ns |     6.3734 ns |     5.6498 ns | 0.0266 |      - |     - |     201 B |
|       IQuantity_ToUnit |     37.423 ns |     0.4386 ns |     0.4102 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,353.035 ns |    41.9708 ns |    39.2595 ns | 0.1774 |      - |     - |    1220 B |
