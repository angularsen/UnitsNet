``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-JWPGSH : .NET Framework 4.8 (4.8.4470.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |      Error |     StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------:|-------:|------:|----------:|
|            Constructor |     12.64 ns |   0.039 ns |   0.037 ns |      - |      - |     - |         - |
|         Constructor_SI |    481.91 ns |   1.897 ns |   1.774 ns | 0.0300 |      - |     - |     201 B |
|             FromMethod |     39.72 ns |   0.822 ns |   1.040 ns |      - |      - |     - |         - |
|             ToProperty |    236.02 ns |   0.972 ns |   0.909 ns | 0.0168 |      - |     - |     112 B |
|                     As |    235.06 ns |   0.901 ns |   0.842 ns | 0.0166 |      - |     - |     112 B |
|                  As_SI |    485.39 ns |   2.533 ns |   2.369 ns | 0.0290 |      - |     - |     201 B |
|                 ToUnit |    224.86 ns |   0.844 ns |   0.789 ns | 0.0168 |      - |     - |     112 B |
|              ToUnit_SI |    491.65 ns |   1.499 ns |   1.402 ns | 0.0295 |      - |     - |     201 B |
|           ToStringTest |  1,801.06 ns |   7.131 ns |   6.671 ns | 0.1832 |      - |     - |    1220 B |
|                  Parse | 54,492.86 ns | 286.760 ns | 268.235 ns | 8.3951 | 0.3271 |     - |   54376 B |
|          TryParseValid | 54,799.27 ns | 156.704 ns | 146.581 ns | 8.3951 | 0.3271 |     - |   54352 B |
|        TryParseInvalid | 58,218.96 ns | 230.662 ns | 215.761 ns | 8.3256 | 0.3469 |     - |   53895 B |
|           QuantityFrom |     96.36 ns |   0.374 ns |   0.350 ns | 0.0085 |      - |     - |      56 B |
|           IQuantity_As |    241.91 ns |   0.907 ns |   0.848 ns | 0.0205 |      - |     - |     136 B |
|        IQuantity_As_SI |    482.64 ns |   6.080 ns |   5.687 ns | 0.0290 |      - |     - |     201 B |
|       IQuantity_ToUnit |    238.67 ns |   1.121 ns |   0.994 ns | 0.0257 |      - |     - |     168 B |
| IQuantity_ToStringTest |  1,828.08 ns |   6.669 ns |   5.912 ns | 0.1852 |      - |     - |    1220 B |
