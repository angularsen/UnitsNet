``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-TFCAKZ : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |      9.501 ns |   0.0309 ns |   0.0289 ns |      - |     - |     - |         - |
|         Constructor_SI |    316.548 ns |   0.9454 ns |   0.7894 ns | 0.0102 |     - |     - |     192 B |
|             FromMethod |     24.436 ns |   0.1201 ns |   0.1065 ns |      - |     - |     - |         - |
|             ToProperty |      8.688 ns |   0.0285 ns |   0.0266 ns |      - |     - |     - |         - |
|                     As |      8.420 ns |   0.0336 ns |   0.0298 ns |      - |     - |     - |         - |
|                  As_SI |    318.160 ns |   2.0650 ns |   1.9316 ns | 0.0096 |     - |     - |     192 B |
|                 ToUnit |     16.337 ns |   0.0296 ns |   0.0262 ns |      - |     - |     - |         - |
|              ToUnit_SI |    323.766 ns |   1.0471 ns |   0.9283 ns | 0.0098 |     - |     - |     192 B |
|           ToStringTest |  1,305.505 ns |  11.6138 ns |  10.2953 ns | 0.0497 |     - |     - |     944 B |
|                  Parse | 43,400.375 ns | 316.7505 ns | 280.7910 ns | 1.7303 |     - |     - |   33344 B |
|          TryParseValid | 44,637.118 ns | 545.5983 ns | 510.3530 ns | 1.7654 |     - |     - |   33320 B |
|        TryParseInvalid | 48,049.735 ns | 253.6419 ns | 237.2568 ns | 1.7075 |     - |     - |   32929 B |
|           QuantityFrom |  2,800.000 ns |  55.5737 ns |  97.3329 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     21.308 ns |   0.1491 ns |   0.1322 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    323.828 ns |   1.8025 ns |   1.5979 ns | 0.0098 |     - |     - |     192 B |
|       IQuantity_ToUnit |     30.417 ns |   0.5051 ns |   0.4478 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,331.744 ns |   7.4785 ns |   6.6295 ns | 0.0479 |     - |     - |     944 B |
