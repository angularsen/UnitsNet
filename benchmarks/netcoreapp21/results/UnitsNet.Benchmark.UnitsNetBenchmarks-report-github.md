``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-AIAMLH : .NET Core 2.1.27 (CoreCLR 4.6.29916.01, CoreFX 4.6.29916.03), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.733 ns |     0.1851 ns |     0.1731 ns |      - |      - |     - |         - |
|         Constructor_SI |    591.672 ns |     9.5001 ns |     8.4216 ns | 0.0278 |      - |     - |     192 B |
|             FromMethod |     31.380 ns |     0.4771 ns |     0.4463 ns |      - |      - |     - |         - |
|             ToProperty |      9.051 ns |     0.1270 ns |     0.1126 ns |      - |      - |     - |         - |
|                     As |      9.144 ns |     0.1523 ns |     0.1424 ns |      - |      - |     - |         - |
|                  As_SI |    599.620 ns |     9.5297 ns |     8.4478 ns | 0.0276 |      - |     - |     192 B |
|                 ToUnit |     20.620 ns |     0.3989 ns |     0.3536 ns |      - |      - |     - |         - |
|              ToUnit_SI |    606.209 ns |     9.1719 ns |     8.1307 ns | 0.0281 |      - |     - |     192 B |
|           ToStringTest |  2,593.110 ns |    46.4604 ns |    66.6320 ns | 0.1424 |      - |     - |     952 B |
|                  Parse | 88,210.724 ns | 1,725.4970 ns | 3,324.4469 ns | 6.8146 | 0.1747 |     - |   44816 B |
|          TryParseValid | 81,969.277 ns | 1,583.6886 ns | 2,465.6123 ns | 6.8208 | 0.1664 |     - |   44792 B |
|        TryParseInvalid | 85,788.112 ns | 1,621.5949 ns | 1,592.6230 ns | 6.6643 | 0.1801 |     - |   44392 B |
|           QuantityFrom |  2,485.057 ns |    49.6794 ns |   135.9965 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.979 ns |     0.4175 ns |     0.3701 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    593.423 ns |     9.3626 ns |     8.2997 ns | 0.0283 |      - |     - |     192 B |
|       IQuantity_ToUnit |     30.592 ns |     0.6718 ns |     0.5955 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,394.959 ns |    47.6829 ns |    51.0202 ns | 0.1422 |      - |     - |     952 B |
