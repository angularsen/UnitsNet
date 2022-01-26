``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2452 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-PKODTS : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.493 ns |     0.2483 ns |     0.6410 ns |     10.470 ns |      - |      - |     - |         - |
|         Constructor_SI |    522.521 ns |    10.4616 ns |    21.8373 ns |    518.972 ns | 0.0282 |      - |     - |     192 B |
|             FromMethod |     24.250 ns |     0.5237 ns |     1.2946 ns |     24.074 ns |      - |      - |     - |         - |
|             ToProperty |      8.044 ns |     0.1972 ns |     0.4982 ns |      8.007 ns |      - |      - |     - |         - |
|                     As |      7.836 ns |     0.1955 ns |     0.5219 ns |      7.836 ns |      - |      - |     - |         - |
|                  As_SI |    525.566 ns |    10.5367 ns |    22.2255 ns |    529.956 ns | 0.0279 |      - |     - |     192 B |
|                 ToUnit |     16.796 ns |     0.3706 ns |     0.8365 ns |     16.655 ns |      - |      - |     - |         - |
|              ToUnit_SI |    544.571 ns |    10.8576 ns |    24.7282 ns |    544.679 ns | 0.0278 |      - |     - |     192 B |
|           ToStringTest |  2,147.242 ns |    42.5796 ns |    99.5284 ns |  2,177.222 ns | 0.1428 |      - |     - |     952 B |
|                  Parse | 65,851.831 ns | 1,309.8545 ns | 3,138.3277 ns | 66,556.257 ns | 6.7506 | 0.2596 |     - |   44816 B |
|          TryParseValid | 65,991.489 ns | 1,308.5822 ns | 3,109.9840 ns | 65,968.069 ns | 6.7859 | 0.2468 |     - |   44792 B |
|        TryParseInvalid | 70,648.100 ns | 1,394.8211 ns | 3,550.2650 ns | 70,384.751 ns | 6.6803 | 0.1363 |     - |   44392 B |
|           QuantityFrom |  2,263.529 ns |   130.2551 ns |   352.1522 ns |  2,200.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     21.574 ns |     0.4713 ns |     1.0246 ns |     21.444 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    504.674 ns |    10.0864 ns |    22.7666 ns |    499.696 ns | 0.0282 |      - |     - |     192 B |
|       IQuantity_ToUnit |     33.086 ns |     0.7394 ns |     1.6539 ns |     33.813 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,135.942 ns |    42.2852 ns |   101.3126 ns |  2,156.963 ns | 0.1411 |      - |     - |     952 B |
