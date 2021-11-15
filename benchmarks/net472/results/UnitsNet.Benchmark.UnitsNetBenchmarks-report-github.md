``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-GMNLFV : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.281 ns |     0.2751 ns |     0.2573 ns |     14.318 ns |      - |      - |     - |         - |
|         Constructor_SI |    543.187 ns |    10.8510 ns |     9.0611 ns |    541.940 ns | 0.0282 |      - |     - |     201 B |
|             FromMethod |     36.856 ns |     0.7756 ns |     1.3379 ns |     36.795 ns |      - |      - |     - |         - |
|             ToProperty |      8.762 ns |     0.2317 ns |     0.6833 ns |      8.538 ns |      - |      - |     - |         - |
|                     As |      8.371 ns |     0.1739 ns |     0.1627 ns |      8.389 ns |      - |      - |     - |         - |
|                  As_SI |    529.811 ns |    10.5424 ns |    17.9018 ns |    526.286 ns | 0.0278 |      - |     - |     201 B |
|                 ToUnit |     22.264 ns |     0.4825 ns |     1.0071 ns |     22.114 ns |      - |      - |     - |         - |
|              ToUnit_SI |    570.638 ns |    10.3997 ns |    11.9763 ns |    570.306 ns | 0.0274 |      - |     - |     201 B |
|           ToStringTest |  2,069.855 ns |    40.0562 ns |    50.6582 ns |  2,081.549 ns | 0.1796 |      - |     - |    1220 B |
|                  Parse | 61,583.063 ns | 1,214.6259 ns | 2,425.7393 ns | 61,171.232 ns | 8.1429 | 0.2431 |     - |   54377 B |
|          TryParseValid | 59,425.947 ns | 1,148.3170 ns | 1,127.8008 ns | 59,495.737 ns | 8.2440 | 0.3533 |     - |   54352 B |
|        TryParseInvalid | 63,770.737 ns | 1,131.8328 ns | 1,728.4282 ns | 63,410.417 ns | 8.1653 | 0.2474 |     - |   53895 B |
|           QuantityFrom |  2,818.085 ns |    65.0089 ns |   185.4740 ns |  2,800.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     20.117 ns |     0.4078 ns |     0.6104 ns |     19.970 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    573.516 ns |    11.4265 ns |    21.1798 ns |    567.565 ns | 0.0279 |      - |     - |     201 B |
|       IQuantity_ToUnit |     33.198 ns |     0.7516 ns |     1.2557 ns |     33.488 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,894.446 ns |    36.3586 ns |    44.6516 ns |  1,903.650 ns | 0.1808 |      - |     - |    1220 B |
