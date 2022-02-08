``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-ZXKEBL : .NET Framework 4.8 (4.8.4470.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.30 ns |     0.171 ns |     0.160 ns |      - |      - |     - |         - |
|         Constructor_SI |    612.25 ns |     6.385 ns |     5.972 ns | 0.0284 |      - |     - |     201 B |
|             FromMethod |     35.68 ns |     0.299 ns |     0.280 ns |      - |      - |     - |         - |
|             ToProperty |    284.92 ns |     1.996 ns |     1.667 ns | 0.0164 |      - |     - |     112 B |
|                     As |    278.80 ns |     2.909 ns |     2.722 ns | 0.0166 |      - |     - |     112 B |
|                  As_SI |    595.61 ns |     7.396 ns |     6.556 ns | 0.0286 |      - |     - |     201 B |
|                 ToUnit |    280.61 ns |     4.895 ns |     4.579 ns | 0.0162 |      - |     - |     112 B |
|              ToUnit_SI |    626.78 ns |     4.475 ns |     3.967 ns | 0.0288 |      - |     - |     201 B |
|           ToStringTest |  2,317.51 ns |    25.885 ns |    24.213 ns | 0.1842 |      - |     - |    1220 B |
|                  Parse | 67,600.84 ns | 1,249.535 ns | 1,168.816 ns | 8.3477 | 0.2650 |     - |   54377 B |
|          TryParseValid | 65,102.58 ns | 1,072.912 ns |   951.109 ns | 8.3748 | 0.2617 |     - |   54353 B |
|        TryParseInvalid | 72,112.09 ns |   947.559 ns |   886.347 ns | 8.2024 | 0.2780 |     - |   53895 B |
|           QuantityFrom |    116.21 ns |     1.179 ns |     1.045 ns | 0.0083 |      - |     - |      56 B |
|           IQuantity_As |    292.79 ns |     2.324 ns |     2.060 ns | 0.0204 |      - |     - |     136 B |
|        IQuantity_As_SI |    598.33 ns |     5.956 ns |     5.571 ns | 0.0287 |      - |     - |     201 B |
|       IQuantity_ToUnit |    315.88 ns |     4.737 ns |     4.431 ns | 0.0252 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,317.28 ns |    17.517 ns |    15.528 ns | 0.1809 |      - |     - |    1220 B |
