``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-HDNXHX : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |      9.507 ns |   0.0362 ns |     0.0339 ns |      9.497 ns |      - |      - |     - |         - |
|         Constructor_SI |    312.002 ns |   6.2102 ns |    12.5450 ns |    319.485 ns | 0.0096 |      - |     - |     192 B |
|             FromMethod |     24.776 ns |   0.5170 ns |     0.7578 ns |     25.049 ns |      - |      - |     - |         - |
|             ToProperty |    151.350 ns |   3.0368 ns |     4.8167 ns |    153.201 ns | 0.0059 |      - |     - |     112 B |
|                     As |    151.729 ns |   3.0142 ns |     2.6720 ns |    152.622 ns | 0.0057 |      - |     - |     112 B |
|                  As_SI |    327.073 ns |   6.2143 ns |     5.8129 ns |    328.346 ns | 0.0099 |      - |     - |     192 B |
|                 ToUnit |    143.984 ns |   2.8623 ns |     2.8111 ns |    144.349 ns | 0.0060 |      - |     - |     112 B |
|              ToUnit_SI |    337.509 ns |   6.7464 ns |     8.0311 ns |    339.934 ns | 0.0101 |      - |     - |     192 B |
|           ToStringTest |  1,332.938 ns |   6.9826 ns |     5.8308 ns |  1,332.181 ns | 0.0500 |      - |     - |     944 B |
|                  Parse | 43,522.788 ns | 853.0455 ns | 1,353.0206 ns | 44,053.460 ns | 1.7473 |      - |     - |   33344 B |
|          TryParseValid | 43,727.089 ns | 872.8194 ns | 1,409.4406 ns | 44,046.482 ns | 1.7488 | 0.0833 |     - |   33320 B |
|        TryParseInvalid | 46,885.882 ns | 932.7737 ns | 1,396.1318 ns | 47,380.274 ns | 1.7270 |      - |     - |   32928 B |
|           QuantityFrom |     69.354 ns |   1.4678 ns |     2.8279 ns |     70.651 ns | 0.0029 |      - |     - |      56 B |
|           IQuantity_As |    157.856 ns |   3.1753 ns |     7.0362 ns |    161.553 ns | 0.0071 |      - |     - |     136 B |
|        IQuantity_As_SI |    321.644 ns |   3.5761 ns |     3.3451 ns |    322.109 ns | 0.0102 |      - |     - |     192 B |
|       IQuantity_ToUnit |    167.279 ns |   1.9368 ns |     1.8117 ns |    167.224 ns | 0.0087 |      - |     - |     168 B |
| IQuantity_ToStringTest |  1,388.789 ns |  26.8560 ns |    34.9204 ns |  1,397.436 ns | 0.0502 |      - |     - |     944 B |
