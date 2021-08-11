``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2061 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.400
  [Host]     : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  Job-MVYFAD : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.201 ns |     0.3221 ns |     0.3013 ns |      - |      - |     - |         - |
|         Constructor_SI |    611.984 ns |    12.2490 ns |    15.9272 ns | 0.0277 |      - |     - |     201 B |
|             FromMethod |     41.852 ns |     0.8691 ns |     0.8129 ns |      - |      - |     - |         - |
|             ToProperty |      9.493 ns |     0.1559 ns |     0.1458 ns |      - |      - |     - |         - |
|                     As |      9.681 ns |     0.2388 ns |     0.2555 ns |      - |      - |     - |         - |
|                  As_SI |    615.450 ns |    12.1762 ns |    17.8477 ns | 0.0281 |      - |     - |     201 B |
|                 ToUnit |     23.207 ns |     0.2754 ns |     0.2300 ns |      - |      - |     - |         - |
|              ToUnit_SI |    614.333 ns |    11.7871 ns |    12.1045 ns | 0.0271 |      - |     - |     201 B |
|           ToStringTest |  2,378.930 ns |    47.1773 ns |   128.3492 ns | 0.1782 |      - |     - |    1220 B |
|                  Parse | 65,707.468 ns | 1,313.4264 ns | 1,841.2404 ns | 8.1873 | 0.2559 |     - |   54377 B |
|          TryParseValid | 67,949.991 ns | 1,334.1220 ns | 1,482.8731 ns | 8.1676 | 0.2635 |     - |   54352 B |
|        TryParseInvalid | 75,613.034 ns | 1,509.3893 ns | 1,962.6325 ns | 7.9988 | 0.3076 |     - |   53896 B |
|           QuantityFrom |  2,530.303 ns |    45.2481 ns |   106.6550 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     22.205 ns |     0.4310 ns |     0.4032 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    609.189 ns |    11.6877 ns |    11.4789 ns | 0.0271 |      - |     - |     201 B |
|       IQuantity_ToUnit |     34.210 ns |     0.7853 ns |     0.9645 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,279.669 ns |    45.7681 ns |   134.9483 ns | 0.1754 |      - |     - |    1220 B |
