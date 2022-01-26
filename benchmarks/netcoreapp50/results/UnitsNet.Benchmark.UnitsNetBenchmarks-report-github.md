``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2452 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-XQDZPY : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.134 ns |     0.1567 ns |     0.1389 ns |      - |     - |     - |         - |
|         Constructor_SI |    367.520 ns |     7.2883 ns |     9.2174 ns | 0.0121 |     - |     - |     192 B |
|             FromMethod |     30.967 ns |     0.5420 ns |     0.5070 ns |      - |     - |     - |         - |
|             ToProperty |      9.286 ns |     0.2331 ns |     0.3030 ns |      - |     - |     - |         - |
|                     As |     10.338 ns |     0.2409 ns |     0.3751 ns |      - |     - |     - |         - |
|                  As_SI |    386.665 ns |     7.2742 ns |     6.0743 ns | 0.0116 |     - |     - |     192 B |
|                 ToUnit |     19.891 ns |     0.2194 ns |     0.2053 ns |      - |     - |     - |         - |
|              ToUnit_SI |    406.702 ns |     4.0790 ns |     3.6159 ns | 0.0120 |     - |     - |     192 B |
|           ToStringTest |  1,570.065 ns |    30.7418 ns |    35.4024 ns | 0.0574 |     - |     - |     944 B |
|                  Parse | 56,047.934 ns | 1,074.8138 ns | 1,005.3815 ns | 2.0263 |     - |     - |   33345 B |
|          TryParseValid | 56,478.962 ns | 1,077.3179 ns | 1,152.7181 ns | 2.0494 |     - |     - |   33320 B |
|        TryParseInvalid | 59,676.992 ns | 1,142.0633 ns | 1,068.2867 ns | 1.9969 |     - |     - |   32928 B |
|           QuantityFrom |  3,985.859 ns |   116.1918 ns |   340.7705 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     20.636 ns |     0.4140 ns |     0.3872 ns | 0.0015 |     - |     - |      24 B |
|        IQuantity_As_SI |    372.833 ns |     6.3122 ns |     5.9045 ns | 0.0119 |     - |     - |     192 B |
|       IQuantity_ToUnit |     31.256 ns |     0.7184 ns |     0.6368 ns | 0.0035 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,594.898 ns |    29.7537 ns |    34.2644 ns | 0.0600 |     - |     - |     944 B |
