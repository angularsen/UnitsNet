``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-DMWQEX : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |      8.684 ns |   0.1716 ns |     0.1976 ns |      - |     - |     - |         - |
|         Constructor_SI |    287.342 ns |   5.7576 ns |     7.8811 ns | 0.0100 |     - |     - |     192 B |
|             FromMethod |     22.066 ns |   0.4770 ns |     0.6203 ns |      - |     - |     - |         - |
|             ToProperty |      7.985 ns |   0.1848 ns |     0.1898 ns |      - |     - |     - |         - |
|                     As |      7.628 ns |   0.1727 ns |     0.1616 ns |      - |     - |     - |         - |
|                  As_SI |    294.410 ns |   4.9429 ns |     4.1275 ns | 0.0098 |     - |     - |     192 B |
|                 ToUnit |     14.818 ns |   0.2872 ns |     0.2686 ns |      - |     - |     - |         - |
|              ToUnit_SI |    302.531 ns |   5.9965 ns |     9.1572 ns | 0.0099 |     - |     - |     192 B |
|           ToStringTest |  1,187.623 ns |  23.4785 ns |    42.9318 ns | 0.0488 |     - |     - |     944 B |
|                  Parse | 41,146.905 ns | 820.5255 ns |   767.5200 ns | 1.7095 |     - |     - |   33344 B |
|          TryParseValid | 41,279.210 ns | 819.6572 ns | 1,276.1076 ns | 1.7507 |     - |     - |   33320 B |
|        TryParseInvalid | 43,025.020 ns | 697.5948 ns |   977.9304 ns | 1.6952 |     - |     - |   32928 B |
|           QuantityFrom |  3,612.281 ns |  71.1939 ns |   154.7696 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     17.790 ns |   0.3895 ns |     0.8713 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    296.453 ns |   5.8232 ns |     7.7738 ns | 0.0100 |     - |     - |     192 B |
|       IQuantity_ToUnit |     25.314 ns |   0.5745 ns |     1.1736 ns | 0.0029 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,159.456 ns |  22.7406 ns |    31.8791 ns | 0.0498 |     - |     - |     944 B |
