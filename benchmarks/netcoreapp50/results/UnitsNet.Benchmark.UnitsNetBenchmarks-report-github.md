``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-DUSKJR : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.031 ns |     0.2345 ns |     0.3210 ns |      - |     - |     - |         - |
|         Constructor_SI |    383.615 ns |     7.3229 ns |     6.8499 ns | 0.0098 |     - |     - |     192 B |
|             FromMethod |     28.095 ns |     0.5766 ns |     0.6409 ns |      - |     - |     - |         - |
|             ToProperty |      9.871 ns |     0.2402 ns |     0.2950 ns |      - |     - |     - |         - |
|                     As |     10.350 ns |     0.2580 ns |     0.3445 ns |      - |     - |     - |         - |
|                  As_SI |    371.590 ns |     7.4720 ns |    13.0866 ns | 0.0097 |     - |     - |     192 B |
|                 ToUnit |     18.641 ns |     0.4080 ns |     0.5719 ns |      - |     - |     - |         - |
|              ToUnit_SI |    381.833 ns |     7.6817 ns |    12.1840 ns | 0.0096 |     - |     - |     192 B |
|           ToStringTest |  1,445.779 ns |    28.3559 ns |    44.1467 ns | 0.0476 |     - |     - |     944 B |
|                  Parse | 49,571.170 ns |   877.9631 ns | 1,172.0555 ns | 1.7406 |     - |     - |   33344 B |
|          TryParseValid | 51,397.994 ns | 1,026.0659 ns | 2,294.9433 ns | 1.7690 |     - |     - |   33320 B |
|        TryParseInvalid | 54,614.322 ns | 1,016.6604 ns | 1,391.6162 ns | 1.6634 |     - |     - |   32928 B |
|           QuantityFrom |  3,954.737 ns |    78.5562 ns |   225.3925 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     22.746 ns |     0.4916 ns |     0.8480 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    390.242 ns |     7.7318 ns |     7.5937 ns | 0.0100 |     - |     - |     192 B |
|       IQuantity_ToUnit |     34.659 ns |     0.7879 ns |     1.4799 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,470.689 ns |    29.0247 ns |    41.6264 ns | 0.0500 |     - |     - |     944 B |
