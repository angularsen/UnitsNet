``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-DIYPBT : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.40 ns |     0.338 ns |     0.362 ns |      - |      - |     - |         - |
|         Constructor_SI |    650.02 ns |    13.028 ns |    11.549 ns | 0.0285 |      - |     - |     201 B |
|             FromMethod |     35.77 ns |     0.449 ns |     0.420 ns |      - |      - |     - |         - |
|             ToProperty |     10.71 ns |     0.228 ns |     0.213 ns |      - |      - |     - |         - |
|                     As |     10.48 ns |     0.135 ns |     0.120 ns |      - |      - |     - |         - |
|                  As_SI |    626.44 ns |    12.381 ns |    12.160 ns | 0.0283 |      - |     - |     201 B |
|                 ToUnit |     23.52 ns |     0.324 ns |     0.303 ns |      - |      - |     - |         - |
|              ToUnit_SI |    648.48 ns |     9.050 ns |     7.066 ns | 0.0289 |      - |     - |     201 B |
|           ToStringTest |  2,378.75 ns |    44.224 ns |    41.367 ns | 0.1833 |      - |     - |    1220 B |
|                  Parse | 64,463.12 ns | 1,263.890 ns | 1,930.094 ns | 8.3386 | 0.2527 |     - |   54377 B |
|          TryParseValid | 66,011.24 ns | 1,304.669 ns | 2,450.484 ns | 8.2927 | 0.2633 |     - |   54352 B |
|        TryParseInvalid | 73,321.06 ns | 1,445.423 ns | 2,374.872 ns | 8.1487 | 0.2859 |     - |   53895 B |
|           QuantityFrom |  2,752.04 ns |    73.051 ns |   213.092 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     23.72 ns |     0.522 ns |     0.827 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    633.72 ns |    12.438 ns |    12.773 ns | 0.0291 |      - |     - |     201 B |
|       IQuantity_ToUnit |     38.83 ns |     0.889 ns |     2.130 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,280.82 ns |    43.741 ns |    50.372 ns | 0.1841 |      - |     - |    1220 B |
