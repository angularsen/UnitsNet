``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-FDWZNQ : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.090 ns |     0.2672 ns |     0.5864 ns |      - |      - |     - |         - |
|         Constructor_SI |    541.671 ns |    10.6615 ns |    21.0448 ns | 0.0271 |      - |     - |     192 B |
|             FromMethod |     27.609 ns |     0.5899 ns |     1.1644 ns |      - |      - |     - |         - |
|             ToProperty |      8.326 ns |     0.2097 ns |     0.4424 ns |      - |      - |     - |         - |
|                     As |      8.585 ns |     0.2129 ns |     0.3728 ns |      - |      - |     - |         - |
|                  As_SI |    523.242 ns |    10.3935 ns |    24.0885 ns | 0.0265 |      - |     - |     192 B |
|                 ToUnit |     18.164 ns |     0.4077 ns |     0.8510 ns |      - |      - |     - |         - |
|              ToUnit_SI |    554.701 ns |    10.9828 ns |    26.5246 ns | 0.0267 |      - |     - |     192 B |
|           ToStringTest |  2,127.638 ns |    42.5124 ns |   108.2077 ns | 0.1373 |      - |     - |     952 B |
|                  Parse | 73,075.209 ns | 1,392.2739 ns | 1,709.8374 ns | 6.5621 | 0.1427 |     - |   44816 B |
|          TryParseValid | 75,327.195 ns | 1,486.5789 ns | 3,135.6994 ns | 6.6305 | 0.1507 |     - |   44792 B |
|        TryParseInvalid | 77,591.491 ns | 1,528.9377 ns | 2,192.7567 ns | 6.4677 | 0.1658 |     - |   44392 B |
|           QuantityFrom |  2,281.720 ns |    52.2195 ns |   148.1379 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.823 ns |     0.4358 ns |     0.9000 ns | 0.0036 |      - |     - |      24 B |
|        IQuantity_As_SI |    555.441 ns |     9.9520 ns |     9.3091 ns | 0.0268 |      - |     - |     192 B |
|       IQuantity_ToUnit |     27.604 ns |     0.6810 ns |     1.9973 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,993.126 ns |    39.8313 ns |   100.6588 ns | 0.1383 |      - |     - |     952 B |
