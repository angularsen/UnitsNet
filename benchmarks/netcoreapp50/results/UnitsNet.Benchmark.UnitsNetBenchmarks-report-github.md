``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-FVXTZB : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |      9.528 ns |   0.0283 ns |   0.0251 ns |      - |     - |     - |         - |
|         Constructor_SI |    322.730 ns |   1.1001 ns |   1.0290 ns | 0.0098 |     - |     - |     192 B |
|             FromMethod |     24.457 ns |   0.0496 ns |   0.0464 ns |      - |     - |     - |         - |
|             ToProperty |    159.268 ns |   0.5809 ns |   0.5433 ns | 0.0058 |     - |     - |     112 B |
|                     As |    157.677 ns |   0.9734 ns |   0.9106 ns | 0.0057 |     - |     - |     112 B |
|                  As_SI |    327.096 ns |   1.5373 ns |   1.4380 ns | 0.0098 |     - |     - |     192 B |
|                 ToUnit |    149.612 ns |   0.7218 ns |   0.6752 ns | 0.0060 |     - |     - |     112 B |
|              ToUnit_SI |    329.692 ns |   1.2485 ns |   1.1678 ns | 0.0100 |     - |     - |     192 B |
|           ToStringTest |  1,312.649 ns |   9.3259 ns |   8.7235 ns | 0.0496 |     - |     - |     944 B |
|                  Parse | 44,273.703 ns | 292.9154 ns | 244.5976 ns | 1.7595 |     - |     - |   33344 B |
|          TryParseValid | 44,846.124 ns | 179.6666 ns | 140.2719 ns | 1.7792 |     - |     - |   33320 B |
|        TryParseInvalid | 48,127.832 ns | 285.6496 ns | 253.2210 ns | 1.7376 |     - |     - |   32928 B |
|           QuantityFrom |     71.718 ns |   0.2569 ns |   0.2277 ns | 0.0029 |     - |     - |      56 B |
|           IQuantity_As |    160.993 ns |   0.2861 ns |   0.2537 ns | 0.0072 |     - |     - |     136 B |
|        IQuantity_As_SI |    325.132 ns |   0.9641 ns |   0.9018 ns | 0.0098 |     - |     - |     192 B |
|       IQuantity_ToUnit |    169.394 ns |   0.9726 ns |   0.9098 ns | 0.0090 |     - |     - |     168 B |
| IQuantity_ToStringTest |  1,334.430 ns |   8.3414 ns |   6.9654 ns | 0.0504 |     - |     - |     944 B |
