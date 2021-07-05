``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-SDDGCA : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |      StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.416 ns |     0.3249 ns |   0.3039 ns |     15.346 ns |      - |      - |     - |         - |
|         Constructor_SI |    592.250 ns |     6.7421 ns |   6.3066 ns |    593.716 ns | 0.0294 |      - |     - |     201 B |
|             FromMethod |     36.993 ns |     0.7650 ns |   0.7156 ns |     36.654 ns |      - |      - |     - |         - |
|             ToProperty |      9.199 ns |     0.1391 ns |   0.1301 ns |      9.207 ns |      - |      - |     - |         - |
|                     As |      9.396 ns |     0.2243 ns |   0.2303 ns |      9.424 ns |      - |      - |     - |         - |
|                  As_SI |    583.982 ns |    10.7349 ns |  10.0414 ns |    580.192 ns | 0.0298 |      - |     - |     201 B |
|                 ToUnit |     23.387 ns |     0.3622 ns |   0.3211 ns |     23.440 ns |      - |      - |     - |         - |
|              ToUnit_SI |    600.385 ns |    10.3134 ns |   9.6471 ns |    598.338 ns | 0.0291 |      - |     - |     201 B |
|           ToStringTest |  2,191.120 ns |    33.7553 ns |  28.1872 ns |  2,184.809 ns | 0.1892 |      - |     - |    1244 B |
|                  Parse | 64,470.520 ns | 1,153.2419 ns | 963.0092 ns | 64,600.154 ns | 8.3237 | 0.2561 |     - |   54377 B |
|          TryParseValid | 64,443.401 ns |   957.8665 ns | 895.9889 ns | 64,242.553 ns | 8.4012 | 0.2546 |     - |   54352 B |
|        TryParseInvalid | 68,766.901 ns |   816.6949 ns | 681.9772 ns | 68,602.183 ns | 8.2896 | 0.2763 |     - |   53895 B |
|           QuantityFrom |  2,353.061 ns |    46.9521 ns |  93.7684 ns |  2,300.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     21.870 ns |     0.4173 ns |   0.4098 ns |     21.831 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    589.805 ns |    10.3687 ns |   9.6989 ns |    590.079 ns | 0.0296 |      - |     - |     201 B |
|       IQuantity_ToUnit |     33.801 ns |     0.5920 ns |   0.5248 ns |     33.748 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,172.265 ns |    30.0037 ns |  28.0654 ns |  2,178.987 ns | 0.1895 |      - |     - |    1244 B |
