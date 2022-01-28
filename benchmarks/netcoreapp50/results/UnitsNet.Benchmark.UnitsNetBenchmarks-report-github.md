``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-PHKPNH : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |        Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |      8.988 ns |   0.2179 ns |     0.3262 ns |      9.027 ns |      - |     - |     - |         - |
|         Constructor_SI |    308.243 ns |   6.1528 ns |     8.0003 ns |    308.731 ns | 0.0098 |     - |     - |     192 B |
|             FromMethod |     23.210 ns |   0.5007 ns |     0.5960 ns |     23.377 ns |      - |     - |     - |         - |
|             ToProperty |      8.309 ns |   0.2060 ns |     0.3083 ns |      8.387 ns |      - |     - |     - |         - |
|                     As |      8.682 ns |   0.2094 ns |     0.3382 ns |      8.723 ns |      - |     - |     - |         - |
|                  As_SI |    310.515 ns |   6.0822 ns |     9.1035 ns |    310.350 ns | 0.0097 |     - |     - |     192 B |
|                 ToUnit |     15.375 ns |   0.3379 ns |     0.5457 ns |     15.496 ns |      - |     - |     - |         - |
|              ToUnit_SI |    313.878 ns |   6.0823 ns |     5.6894 ns |    313.011 ns | 0.0101 |     - |     - |     192 B |
|           ToStringTest |  1,253.416 ns |  23.8820 ns |    25.5535 ns |  1,259.784 ns | 0.0501 |     - |     - |     944 B |
|                  Parse | 42,531.449 ns | 836.6287 ns | 1,199.8678 ns | 42,725.228 ns | 1.7029 |     - |     - |   33344 B |
|          TryParseValid | 42,972.283 ns | 858.9852 ns | 1,231.9309 ns | 43,063.832 ns | 1.7710 |     - |     - |   33320 B |
|        TryParseInvalid | 45,173.977 ns | 894.7753 ns | 1,543.4434 ns | 45,501.417 ns | 1.7202 |     - |     - |   32928 B |
|           QuantityFrom |  3,150.000 ns |  52.5690 ns |    87.8310 ns |  3,100.000 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     19.302 ns |   0.4184 ns |     0.5440 ns |     19.289 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    313.172 ns |   6.1361 ns |     8.6020 ns |    313.983 ns | 0.0102 |     - |     - |     192 B |
|       IQuantity_ToUnit |     29.749 ns |   0.6820 ns |     1.1395 ns |     29.866 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,229.804 ns |  24.5677 ns |    38.2490 ns |  1,242.935 ns | 0.0492 |     - |     - |     944 B |
