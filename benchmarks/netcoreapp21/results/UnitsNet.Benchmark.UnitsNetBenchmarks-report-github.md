``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-JPTBRP : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.374 ns |     0.2450 ns |     0.5115 ns |     10.361 ns |      - |      - |     - |         - |
|         Constructor_SI |    505.581 ns |    10.1375 ns |    18.5371 ns |    506.609 ns | 0.0281 |      - |     - |     192 B |
|             FromMethod |     24.536 ns |     0.5223 ns |     1.0062 ns |     24.628 ns |      - |      - |     - |         - |
|             ToProperty |      8.219 ns |     0.2038 ns |     0.4343 ns |      8.228 ns |      - |      - |     - |         - |
|                     As |      8.793 ns |     0.2089 ns |     0.3126 ns |      8.934 ns |      - |      - |     - |         - |
|                  As_SI |    497.884 ns |     9.9944 ns |    17.5043 ns |    502.426 ns | 0.0284 |      - |     - |     192 B |
|                 ToUnit |     16.882 ns |     0.3744 ns |     0.7122 ns |     16.900 ns |      - |      - |     - |         - |
|              ToUnit_SI |    503.313 ns |    10.0777 ns |    22.7471 ns |    508.750 ns | 0.0280 |      - |     - |     192 B |
|           ToStringTest |  1,999.525 ns |    39.9437 ns |    94.1519 ns |  2,018.075 ns | 0.1425 |      - |     - |     952 B |
|                  Parse | 60,491.282 ns | 1,194.7227 ns | 2,358.2660 ns | 61,352.128 ns | 6.8102 | 0.2432 |     - |   44816 B |
|          TryParseValid | 60,123.315 ns | 1,198.4987 ns | 2,579.8949 ns | 61,117.510 ns | 6.8667 | 0.2543 |     - |   44792 B |
|        TryParseInvalid | 63,953.452 ns | 1,267.4895 ns | 2,962.7157 ns | 64,348.789 ns | 6.6763 | 0.2618 |     - |   44392 B |
|           QuantityFrom |  1,608.421 ns |    43.0368 ns |   123.4807 ns |  1,600.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     18.789 ns |     0.4184 ns |     1.0497 ns |     18.769 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    493.611 ns |     9.8070 ns |    19.5856 ns |    496.942 ns | 0.0284 |      - |     - |     192 B |
|       IQuantity_ToUnit |     28.451 ns |     0.6495 ns |     1.5809 ns |     28.620 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,012.879 ns |    40.1359 ns |    89.7697 ns |  2,003.296 ns | 0.1406 |      - |     - |     952 B |
