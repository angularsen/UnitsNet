``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-NZNTLK : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.849 ns |     0.3353 ns |     0.4118 ns |      - |      - |     - |         - |
|         Constructor_SI |    594.808 ns |    11.1998 ns |    17.4367 ns | 0.0281 |      - |     - |     201 B |
|             FromMethod |     37.650 ns |     0.5576 ns |     0.5216 ns |      - |      - |     - |         - |
|             ToProperty |      9.098 ns |     0.1323 ns |     0.1238 ns |      - |      - |     - |         - |
|                     As |      9.059 ns |     0.0998 ns |     0.0885 ns |      - |      - |     - |         - |
|                  As_SI |    563.127 ns |    10.3651 ns |     9.1884 ns | 0.0278 |      - |     - |     201 B |
|                 ToUnit |     22.458 ns |     0.3964 ns |     0.3708 ns |      - |      - |     - |         - |
|              ToUnit_SI |    579.804 ns |     9.2800 ns |     8.6805 ns | 0.0278 |      - |     - |     201 B |
|           ToStringTest |  2,109.976 ns |    41.3806 ns |    52.3332 ns | 0.1781 |      - |     - |    1220 B |
|                  Parse | 64,768.480 ns | 1,260.3847 ns | 1,451.4609 ns | 8.2125 | 0.2566 |     - |   54377 B |
|          TryParseValid | 64,282.175 ns | 1,223.0620 ns | 1,144.0530 ns | 8.2351 | 0.2534 |     - |   54353 B |
|        TryParseInvalid | 67,337.335 ns | 1,287.4426 ns | 1,322.1088 ns | 8.0344 | 0.2770 |     - |   53895 B |
|           QuantityFrom |  2,654.082 ns |    69.9910 ns |   204.1671 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     21.146 ns |     0.4076 ns |     0.3813 ns | 0.0036 |      - |     - |      24 B |
|        IQuantity_As_SI |    582.086 ns |    11.5312 ns |    14.1613 ns | 0.0270 |      - |     - |     201 B |
|       IQuantity_ToUnit |     34.817 ns |     0.7574 ns |     0.7085 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,122.040 ns |    41.9951 ns |    53.1104 ns | 0.1785 |      - |     - |    1220 B |
