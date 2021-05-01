``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-NZUFSV : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.053 ns |     0.1547 ns |     0.1372 ns |     15.039 ns |      - |      - |     - |         - |
|         Constructor_SI |    612.212 ns |     7.8201 ns |     7.3149 ns |    614.429 ns | 0.0296 |      - |     - |     201 B |
|             FromMethod |     37.519 ns |     0.3517 ns |     0.3290 ns |     37.489 ns |      - |      - |     - |         - |
|             ToProperty |      9.138 ns |     0.1121 ns |     0.1049 ns |      9.132 ns |      - |      - |     - |         - |
|                     As |      9.195 ns |     0.1349 ns |     0.1196 ns |      9.209 ns |      - |      - |     - |         - |
|                  As_SI |    602.801 ns |     7.5670 ns |     7.0782 ns |    602.441 ns | 0.0297 |      - |     - |     201 B |
|                 ToUnit |     23.026 ns |     0.1871 ns |     0.1659 ns |     22.984 ns |      - |      - |     - |         - |
|              ToUnit_SI |    620.973 ns |    10.4951 ns |    12.0862 ns |    617.205 ns | 0.0294 |      - |     - |     201 B |
|           ToStringTest |  2,555.228 ns |    49.9527 ns |    64.9527 ns |  2,541.845 ns | 0.1882 |      - |     - |    1244 B |
|                  Parse | 73,624.315 ns | 1,394.5280 ns | 1,369.6130 ns | 73,867.620 ns | 8.2935 | 0.2811 |     - |   54377 B |
|          TryParseValid | 73,961.981 ns |   858.8614 ns |   717.1882 ns | 74,092.299 ns | 8.3614 | 0.2934 |     - |   54352 B |
|        TryParseInvalid | 77,686.184 ns |   579.7515 ns |   513.9346 ns | 77,641.877 ns | 8.2924 | 0.3071 |     - |   53894 B |
|           QuantityFrom |  2,450.685 ns |    43.9486 ns |   109.4472 ns |  2,400.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     24.804 ns |     0.5371 ns |     0.5275 ns |     24.909 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    599.105 ns |     8.1903 ns |     7.6612 ns |    596.890 ns | 0.0298 |      - |     - |     201 B |
|       IQuantity_ToUnit |     39.306 ns |     0.8915 ns |     1.1592 ns |     39.320 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,486.526 ns |    42.1291 ns |    51.7383 ns |  2,481.309 ns | 0.1885 |      - |     - |    1244 B |
