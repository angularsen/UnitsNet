``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-KVYBEP : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.659 ns |     0.0553 ns |     0.0517 ns |     12.685 ns |      - |      - |     - |         - |
|         Constructor_SI |    507.526 ns |     6.9376 ns |     6.4895 ns |    509.827 ns | 0.0298 |      - |     - |     201 B |
|             FromMethod |     29.844 ns |     0.0633 ns |     0.0592 ns |     29.844 ns |      - |      - |     - |         - |
|             ToProperty |      8.485 ns |     0.0252 ns |     0.0236 ns |      8.492 ns |      - |      - |     - |         - |
|                     As |      8.485 ns |     0.0357 ns |     0.0334 ns |      8.484 ns |      - |      - |     - |         - |
|                  As_SI |    484.199 ns |     4.2880 ns |     4.0110 ns |    483.190 ns | 0.0299 |      - |     - |     201 B |
|                 ToUnit |     19.394 ns |     0.0397 ns |     0.0371 ns |     19.395 ns |      - |      - |     - |         - |
|              ToUnit_SI |    503.322 ns |     2.3428 ns |     2.0768 ns |    503.655 ns | 0.0292 |      - |     - |     201 B |
|           ToStringTest |  1,748.398 ns |     5.7968 ns |     5.4224 ns |  1,747.657 ns | 0.1860 |      - |     - |    1220 B |
|                  Parse | 52,696.592 ns |   750.2578 ns |   626.4993 ns | 52,703.039 ns | 8.3087 | 0.3415 |     - |   54376 B |
|          TryParseValid | 52,053.440 ns |   125.9395 ns |   117.8038 ns | 52,033.495 ns | 8.4115 | 0.3235 |     - |   54352 B |
|        TryParseInvalid | 59,347.787 ns | 1,070.5932 ns | 1,001.4336 ns | 59,398.084 ns | 8.2295 | 0.3527 |     - |   53895 B |
|           QuantityFrom |  2,236.364 ns |    44.6053 ns |    83.7796 ns |  2,200.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     17.645 ns |     0.3713 ns |     0.5083 ns |     17.401 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    481.398 ns |     1.8996 ns |     1.5863 ns |    480.922 ns | 0.0299 |      - |     - |     201 B |
|       IQuantity_ToUnit |     28.567 ns |     0.2279 ns |     0.2020 ns |     28.563 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,782.385 ns |    13.5020 ns |    12.6298 ns |  1,776.793 ns | 0.1839 |      - |     - |    1220 B |
