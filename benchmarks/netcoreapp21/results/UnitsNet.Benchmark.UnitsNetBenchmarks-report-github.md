``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-IUDEDQ : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.280 ns |     0.0953 ns |     0.0796 ns |      - |      - |     - |         - |
|         Constructor_SI |    565.235 ns |     4.5760 ns |     3.8211 ns | 0.0286 |      - |     - |     192 B |
|             FromMethod |     30.163 ns |     0.3116 ns |     0.2763 ns |      - |      - |     - |         - |
|             ToProperty |      9.049 ns |     0.2189 ns |     0.2248 ns |      - |      - |     - |         - |
|                     As |      8.874 ns |     0.2068 ns |     0.1935 ns |      - |      - |     - |         - |
|                  As_SI |    566.851 ns |     3.9249 ns |     3.4793 ns | 0.0281 |      - |     - |     192 B |
|                 ToUnit |     19.818 ns |     0.2261 ns |     0.2115 ns |      - |      - |     - |         - |
|              ToUnit_SI |    588.322 ns |     9.8149 ns |     8.7007 ns | 0.0279 |      - |     - |     192 B |
|           ToStringTest |  2,239.470 ns |    43.6325 ns |    67.9306 ns | 0.1421 |      - |     - |     952 B |
|                  Parse | 75,106.099 ns |   527.0785 ns |   493.0296 ns | 6.7639 | 0.1503 |     - |   44816 B |
|          TryParseValid | 77,732.664 ns |   546.2923 ns |   456.1788 ns | 6.8310 | 0.1485 |     - |   44792 B |
|        TryParseInvalid | 81,112.606 ns | 1,510.8818 ns | 1,483.8880 ns | 6.7476 | 0.1687 |     - |   44392 B |
|           QuantityFrom |  2,331.000 ns |    56.1532 ns |   165.5691 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     20.302 ns |     0.2769 ns |     0.2590 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    567.870 ns |     5.0446 ns |     4.4719 ns | 0.0283 |      - |     - |     192 B |
|       IQuantity_ToUnit |     30.203 ns |     0.3774 ns |     0.3530 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,140.142 ns |    16.0718 ns |    14.2472 ns | 0.1415 |      - |     - |     952 B |
