``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-LZQJWG : .NET Framework 4.8 (4.8.4470.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.60 ns |     0.247 ns |     0.231 ns |      - |      - |     - |         - |
|         Constructor_SI |    607.93 ns |    11.682 ns |    10.927 ns | 0.0293 |      - |     - |     201 B |
|             FromMethod |     36.38 ns |     0.673 ns |     0.629 ns |      - |      - |     - |         - |
|             ToProperty |    293.18 ns |     5.863 ns |     5.484 ns | 0.0165 |      - |     - |     112 B |
|                     As |    298.13 ns |     5.986 ns |     6.893 ns | 0.0161 |      - |     - |     112 B |
|                  As_SI |    618.70 ns |    12.407 ns |    13.275 ns | 0.0284 |      - |     - |     201 B |
|                 ToUnit |    293.85 ns |     5.840 ns |     8.918 ns | 0.0162 |      - |     - |     112 B |
|              ToUnit_SI |    646.03 ns |    12.442 ns |    12.777 ns | 0.0286 |      - |     - |     201 B |
|           ToStringTest |  2,422.35 ns |    46.736 ns |    43.717 ns | 0.1828 |      - |     - |    1220 B |
|                  Parse | 68,528.95 ns | 1,338.667 ns | 1,962.201 ns | 8.3610 | 0.2654 |     - |   54377 B |
|          TryParseValid | 70,240.99 ns | 1,317.916 ns | 1,232.779 ns | 8.2589 | 0.2708 |     - |   54352 B |
|        TryParseInvalid | 73,492.22 ns | 1,051.731 ns |   932.332 ns | 8.1931 | 0.2926 |     - |   53894 B |
|           QuantityFrom |    122.88 ns |     2.192 ns |     2.050 ns | 0.0084 |      - |     - |      56 B |
|           IQuantity_As |    306.61 ns |     4.830 ns |     4.518 ns | 0.0204 |      - |     - |     136 B |
|        IQuantity_As_SI |    613.49 ns |    12.298 ns |    11.504 ns | 0.0284 |      - |     - |     201 B |
|       IQuantity_ToUnit |    315.92 ns |     6.323 ns |     6.766 ns | 0.0250 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,362.03 ns |    37.314 ns |    33.078 ns | 0.1816 |      - |     - |    1220 B |
