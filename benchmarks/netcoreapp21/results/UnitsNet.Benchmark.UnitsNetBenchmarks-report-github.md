``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-XPLWIH : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.647 ns |     0.2063 ns |     0.1930 ns |      - |      - |     - |         - |
|         Constructor_SI |    596.132 ns |     8.4767 ns |     7.0785 ns | 0.0284 |      - |     - |     192 B |
|             FromMethod |     31.523 ns |     0.6515 ns |     0.6094 ns |      - |      - |     - |         - |
|             ToProperty |      8.934 ns |     0.1002 ns |     0.0837 ns |      - |      - |     - |         - |
|                     As |      8.911 ns |     0.1608 ns |     0.1504 ns |      - |      - |     - |         - |
|                  As_SI |    602.474 ns |     4.9470 ns |     4.1310 ns | 0.0284 |      - |     - |     192 B |
|                 ToUnit |     20.402 ns |     0.2857 ns |     0.2673 ns |      - |      - |     - |         - |
|              ToUnit_SI |    615.992 ns |     8.7093 ns |     7.2727 ns | 0.0277 |      - |     - |     192 B |
|           ToStringTest |  2,367.053 ns |    45.8594 ns |    57.9975 ns | 0.1429 |      - |     - |     952 B |
|                  Parse | 88,266.526 ns | 1,714.3649 ns | 1,603.6180 ns | 6.7364 | 0.1773 |     - |   44816 B |
|          TryParseValid | 87,428.893 ns | 1,354.0005 ns | 1,266.5329 ns | 6.7288 | 0.1725 |     - |   44792 B |
|        TryParseInvalid | 92,722.974 ns | 1,739.6442 ns | 1,786.4865 ns | 6.7327 | 0.1870 |     - |   44392 B |
|           QuantityFrom |  2,387.629 ns |    63.1778 ns |   183.2904 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     21.014 ns |     0.3764 ns |     0.3337 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    688.580 ns |     9.6078 ns |     8.9872 ns | 0.0274 |      - |     - |     192 B |
|       IQuantity_ToUnit |     31.603 ns |     0.7199 ns |     0.7071 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,562.928 ns |    45.9453 ns |    42.9772 ns | 0.1390 |      - |     - |     952 B |
