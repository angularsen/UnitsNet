``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-VIZKKF : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.959 ns |   0.0341 ns |   0.0319 ns |     10.948 ns |      - |      - |     - |         - |
|         Constructor_SI |    506.477 ns |   1.8628 ns |   1.6514 ns |    506.355 ns | 0.0283 |      - |     - |     192 B |
|             FromMethod |     25.830 ns |   0.0590 ns |   0.0552 ns |     25.833 ns |      - |      - |     - |         - |
|             ToProperty |      8.350 ns |   0.0332 ns |   0.0310 ns |      8.349 ns |      - |      - |     - |         - |
|                     As |      8.350 ns |   0.0264 ns |   0.0247 ns |      8.349 ns |      - |      - |     - |         - |
|                  As_SI |    506.314 ns |   3.0692 ns |   2.7207 ns |    505.977 ns | 0.0283 |      - |     - |     192 B |
|                 ToUnit |     17.662 ns |   0.0428 ns |   0.0400 ns |     17.665 ns |      - |      - |     - |         - |
|              ToUnit_SI |    517.202 ns |   2.2512 ns |   1.9957 ns |    517.474 ns | 0.0280 |      - |     - |     192 B |
|           ToStringTest |  2,118.130 ns |  11.8809 ns |  11.1134 ns |  2,116.215 ns | 0.1418 |      - |     - |     952 B |
|                  Parse | 59,985.223 ns | 233.9846 ns | 182.6798 ns | 59,982.657 ns | 6.7633 | 0.2415 |     - |   44816 B |
|          TryParseValid | 60,580.079 ns | 204.8295 ns | 171.0419 ns | 60,536.879 ns | 6.8002 | 0.2429 |     - |   44792 B |
|        TryParseInvalid | 65,803.859 ns | 212.2955 ns | 198.5813 ns | 65,824.136 ns | 6.7008 | 0.2628 |     - |   44392 B |
|           QuantityFrom |  1,930.357 ns |  38.5324 ns |  82.9450 ns |  1,900.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.059 ns |   0.1488 ns |   0.1319 ns |     19.027 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    507.304 ns |   2.6345 ns |   2.4643 ns |    507.299 ns | 0.0284 |      - |     - |     192 B |
|       IQuantity_ToUnit |     25.571 ns |   0.0951 ns |   0.0890 ns |     25.587 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,085.149 ns |   9.9387 ns |   9.2967 ns |  2,088.630 ns | 0.1400 |      - |     - |     952 B |
