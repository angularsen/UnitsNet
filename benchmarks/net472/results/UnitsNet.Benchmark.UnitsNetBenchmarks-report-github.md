``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-KCNFHO : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.124 ns |     0.2089 ns |     0.1954 ns |      - |      - |     - |         - |
|         Constructor_SI |    585.462 ns |    10.0814 ns |     9.4302 ns | 0.0296 |      - |     - |     201 B |
|             FromMethod |     38.066 ns |     0.6366 ns |     0.5955 ns |      - |      - |     - |         - |
|             ToProperty |      9.242 ns |     0.1078 ns |     0.1009 ns |      - |      - |     - |         - |
|                     As |      9.331 ns |     0.1950 ns |     0.1824 ns |      - |      - |     - |         - |
|                  As_SI |    583.359 ns |     5.2520 ns |     4.9128 ns | 0.0292 |      - |     - |     201 B |
|                 ToUnit |     23.244 ns |     0.4496 ns |     0.3985 ns |      - |      - |     - |         - |
|              ToUnit_SI |    596.902 ns |    10.1287 ns |     9.4744 ns | 0.0296 |      - |     - |     201 B |
|           ToStringTest |  2,176.724 ns |    34.4572 ns |    30.5454 ns | 0.1835 |      - |     - |    1220 B |
|                  Parse | 67,223.709 ns | 1,147.8019 ns | 1,073.6546 ns | 8.3428 | 0.2828 |     - |   54377 B |
|          TryParseValid | 68,638.398 ns | 1,175.6761 ns | 1,099.7281 ns | 8.3390 | 0.2734 |     - |   54352 B |
|        TryParseInvalid | 70,284.957 ns | 1,195.8041 ns | 1,060.0492 ns | 8.2907 | 0.2764 |     - |   53895 B |
|           QuantityFrom |  2,779.381 ns |    63.3110 ns |   183.6767 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     20.705 ns |     0.3691 ns |     0.3453 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    580.285 ns |     8.8715 ns |     8.2984 ns | 0.0294 |      - |     - |     201 B |
|       IQuantity_ToUnit |     35.078 ns |     0.8000 ns |     0.7483 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,219.074 ns |    29.6780 ns |    27.7608 ns | 0.1863 |      - |     - |    1220 B |
