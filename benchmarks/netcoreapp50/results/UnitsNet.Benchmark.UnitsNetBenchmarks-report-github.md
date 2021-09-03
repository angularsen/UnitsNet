``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2114 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.400
  [Host]     : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  Job-MZOSKU : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |        Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |      9.524 ns |   0.0326 ns |     0.0289 ns |      9.520 ns |      - |     - |     - |         - |
|         Constructor_SI |    319.825 ns |   6.2732 ns |     6.7123 ns |    322.565 ns | 0.0098 |     - |     - |     192 B |
|             FromMethod |     24.466 ns |   0.5160 ns |     0.8185 ns |     24.768 ns |      - |     - |     - |         - |
|             ToProperty |      8.588 ns |   0.0352 ns |     0.0312 ns |      8.591 ns |      - |     - |     - |         - |
|                     As |      8.410 ns |   0.0335 ns |     0.0314 ns |      8.415 ns |      - |     - |     - |         - |
|                  As_SI |    319.121 ns |   0.6856 ns |     0.6413 ns |    319.240 ns | 0.0103 |     - |     - |     192 B |
|                 ToUnit |     16.221 ns |   0.0474 ns |     0.0396 ns |     16.211 ns |      - |     - |     - |         - |
|              ToUnit_SI |    326.329 ns |   2.4961 ns |     1.9488 ns |    326.627 ns | 0.0098 |     - |     - |     192 B |
|           ToStringTest |  1,311.464 ns |  25.5483 ns |    29.4215 ns |  1,320.121 ns | 0.0499 |     - |     - |     944 B |
|                  Parse | 43,895.708 ns | 872.6042 ns | 1,409.0932 ns | 44,428.750 ns | 1.6954 |     - |     - |   33344 B |
|          TryParseValid | 44,818.137 ns | 363.3998 ns |   303.4552 ns | 44,767.149 ns | 1.7318 |     - |     - |   33320 B |
|        TryParseInvalid | 47,645.794 ns | 866.6006 ns |   768.2188 ns | 47,750.945 ns | 1.7094 |     - |     - |   32928 B |
|           QuantityFrom |  2,544.444 ns |  50.8048 ns |    96.6614 ns |  2,500.000 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     21.201 ns |   0.1309 ns |     0.1160 ns |     21.213 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    319.855 ns |   6.2923 ns |     6.4617 ns |    322.876 ns | 0.0099 |     - |     - |     192 B |
|       IQuantity_ToUnit |     31.650 ns |   0.2734 ns |     0.2557 ns |     31.599 ns | 0.0029 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,339.494 ns |  26.6358 ns |    32.7111 ns |  1,348.677 ns | 0.0498 |     - |     - |     944 B |
