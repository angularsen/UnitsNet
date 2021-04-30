``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-FPVTWN : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |      9.885 ns |   0.1443 ns |     0.1279 ns |      - |      - |     - |         - |
|         Constructor_SI |    304.268 ns |   5.8437 ns |     5.7393 ns | 0.0120 |      - |     - |     192 B |
|             FromMethod |     26.615 ns |   0.5387 ns |     0.5291 ns |      - |      - |     - |         - |
|             ToProperty |      8.084 ns |   0.1985 ns |     0.2847 ns |      - |      - |     - |         - |
|                     As |      8.123 ns |   0.1969 ns |     0.2188 ns |      - |      - |     - |         - |
|                  As_SI |    317.232 ns |   6.3599 ns |     8.2696 ns | 0.0121 |      - |     - |     192 B |
|                 ToUnit |     17.404 ns |   0.3700 ns |     0.3089 ns |      - |      - |     - |         - |
|              ToUnit_SI |    319.062 ns |   6.1966 ns |     5.7963 ns | 0.0121 |      - |     - |     192 B |
|           ToStringTest |  1,268.881 ns |  24.0024 ns |    27.6412 ns | 0.0587 |      - |     - |     944 B |
|                  Parse | 47,973.865 ns | 956.8019 ns | 1,372.2166 ns | 2.0653 | 0.0939 |     - |   33344 B |
|          TryParseValid | 46,413.377 ns | 925.4886 ns | 1,385.2277 ns | 2.0578 | 0.0895 |     - |   33320 B |
|        TryParseInvalid | 49,298.789 ns | 983.5092 ns | 1,207.8376 ns | 2.0883 |      - |     - |   32928 B |
|           QuantityFrom |  3,021.739 ns |  59.7796 ns |   144.3745 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     17.397 ns |   0.3806 ns |     0.6766 ns | 0.0015 |      - |     - |      24 B |
|        IQuantity_As_SI |    314.017 ns |   5.1464 ns |     4.5621 ns | 0.0120 |      - |     - |     192 B |
|       IQuantity_ToUnit |     25.817 ns |   0.6094 ns |     0.8739 ns | 0.0035 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,319.672 ns |  26.3112 ns |    34.2120 ns | 0.0590 |      - |     - |     944 B |
