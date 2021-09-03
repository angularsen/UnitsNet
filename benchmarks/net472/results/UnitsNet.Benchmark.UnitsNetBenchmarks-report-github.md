``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2114 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.400
  [Host]     : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  Job-KFEKQR : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.318 ns |     0.3114 ns |     0.2913 ns |      - |      - |     - |         - |
|         Constructor_SI |    616.239 ns |    10.3970 ns |     9.7253 ns | 0.0269 |      - |     - |     201 B |
|             FromMethod |     41.589 ns |     0.5777 ns |     0.5404 ns |      - |      - |     - |         - |
|             ToProperty |      9.577 ns |     0.2369 ns |     0.2216 ns |      - |      - |     - |         - |
|                     As |      9.795 ns |     0.1824 ns |     0.1706 ns |      - |      - |     - |         - |
|                  As_SI |    598.881 ns |    11.7887 ns |    11.5781 ns | 0.0275 |      - |     - |     201 B |
|                 ToUnit |     22.572 ns |     0.3915 ns |     0.3470 ns |      - |      - |     - |         - |
|              ToUnit_SI |    609.087 ns |     9.7289 ns |     8.6244 ns | 0.0272 |      - |     - |     201 B |
|           ToStringTest |  2,327.955 ns |    45.4447 ns |    46.6683 ns | 0.1779 |      - |     - |    1220 B |
|                  Parse | 65,886.492 ns | 1,286.3197 ns | 1,672.5790 ns | 8.1290 | 0.2540 |     - |   54377 B |
|          TryParseValid | 62,975.736 ns | 1,244.7015 ns | 1,331.8166 ns | 8.2289 | 0.2532 |     - |   54353 B |
|        TryParseInvalid | 68,842.463 ns | 1,356.6192 ns | 2,151.7418 ns | 8.1343 | 0.2582 |     - |   53895 B |
|           QuantityFrom |  2,622.680 ns |    67.5785 ns |   196.0576 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     22.693 ns |     0.3930 ns |     0.3676 ns | 0.0036 |      - |     - |      24 B |
|        IQuantity_As_SI |    591.786 ns |    10.8947 ns |    10.1909 ns | 0.0278 |      - |     - |     201 B |
|       IQuantity_ToUnit |     33.739 ns |     0.7492 ns |     0.6256 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,367.212 ns |    38.0068 ns |    40.6668 ns | 0.1769 |      - |     - |    1220 B |
