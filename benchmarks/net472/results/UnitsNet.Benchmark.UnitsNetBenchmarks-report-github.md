``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-UZUGFJ : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.585 ns |   0.0410 ns |   0.0384 ns |      - |      - |     - |         - |
|         Constructor_SI |    496.671 ns |   2.6166 ns |   2.4476 ns | 0.0291 |      - |     - |     201 B |
|             FromMethod |     29.517 ns |   0.0849 ns |   0.0794 ns |      - |      - |     - |         - |
|             ToProperty |      8.648 ns |   0.0199 ns |   0.0186 ns |      - |      - |     - |         - |
|                     As |      8.496 ns |   0.2072 ns |   0.2544 ns |      - |      - |     - |         - |
|                  As_SI |    478.112 ns |   9.2551 ns |  11.0175 ns | 0.0298 |      - |     - |     201 B |
|                 ToUnit |     19.283 ns |   0.0516 ns |   0.0482 ns |      - |      - |     - |         - |
|              ToUnit_SI |    486.602 ns |   9.4933 ns |  10.1577 ns | 0.0296 |      - |     - |     201 B |
|           ToStringTest |  1,781.209 ns |   8.7701 ns |   8.2036 ns | 0.1849 |      - |     - |    1220 B |
|                  Parse | 52,575.701 ns | 432.1916 ns | 383.1266 ns | 8.3682 | 0.3138 |     - |   54377 B |
|          TryParseValid | 51,919.746 ns | 282.1755 ns | 263.9471 ns | 8.3782 | 0.3103 |     - |   54352 B |
|        TryParseInvalid | 57,113.314 ns | 361.0659 ns | 337.7413 ns | 8.2477 | 0.3389 |     - |   53895 B |
|           QuantityFrom |  2,220.455 ns |  43.8431 ns |  82.3479 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     17.566 ns |   0.0912 ns |   0.0853 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    481.406 ns |   1.7831 ns |   1.5807 ns | 0.0299 |      - |     - |     201 B |
|       IQuantity_ToUnit |     28.878 ns |   0.1367 ns |   0.1142 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,844.559 ns |   6.6287 ns |   6.2005 ns | 0.1834 |      - |     - |    1220 B |
