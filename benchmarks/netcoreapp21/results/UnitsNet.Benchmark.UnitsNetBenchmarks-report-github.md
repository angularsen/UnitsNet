``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-ISUMEL : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.989 ns |     0.2209 ns |     0.1958 ns |     11.932 ns |      - |      - |     - |         - |
|         Constructor_SI |    552.707 ns |     9.5751 ns |    10.2452 ns |    552.092 ns | 0.0286 |      - |     - |     192 B |
|             FromMethod |     30.170 ns |     0.6384 ns |     0.7096 ns |     29.867 ns |      - |      - |     - |         - |
|             ToProperty |      8.946 ns |     0.2230 ns |     0.2900 ns |      8.914 ns |      - |      - |     - |         - |
|                     As |      8.489 ns |     0.2063 ns |     0.1723 ns |      8.478 ns |      - |      - |     - |         - |
|                  As_SI |    560.583 ns |    11.0021 ns |    22.7213 ns |    551.658 ns | 0.0288 |      - |     - |     192 B |
|                 ToUnit |     18.782 ns |     0.3326 ns |     0.2949 ns |     18.716 ns |      - |      - |     - |         - |
|              ToUnit_SI |    555.249 ns |     7.9359 ns |     7.4232 ns |    556.818 ns | 0.0286 |      - |     - |     192 B |
|           ToStringTest |  2,104.253 ns |    41.7698 ns |    72.0509 ns |  2,079.731 ns | 0.1429 |      - |     - |     952 B |
|                  Parse | 70,705.147 ns | 1,336.3111 ns | 1,312.4362 ns | 70,979.866 ns | 6.8578 | 0.1372 |     - |   44816 B |
|          TryParseValid | 75,365.043 ns | 1,415.7306 ns | 1,324.2753 ns | 75,447.166 ns | 6.7832 | 0.1507 |     - |   44792 B |
|        TryParseInvalid | 80,761.973 ns | 1,593.6664 ns | 1,897.1464 ns | 80,316.220 ns | 6.6634 | 0.1625 |     - |   44392 B |
|           QuantityFrom |  2,307.692 ns |    57.3139 ns |   160.7142 ns |  2,300.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.939 ns |     0.4392 ns |     0.6299 ns |     19.768 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    575.816 ns |     6.8134 ns |     6.0399 ns |    574.340 ns | 0.0287 |      - |     - |     192 B |
|       IQuantity_ToUnit |     29.769 ns |     0.7031 ns |     0.9142 ns |     29.505 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,040.205 ns |    37.2083 ns |    34.8047 ns |  2,036.693 ns | 0.1436 |      - |     - |     952 B |
