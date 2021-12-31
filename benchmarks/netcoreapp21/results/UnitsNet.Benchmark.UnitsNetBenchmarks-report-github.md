``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-VOIRJM : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.882 ns |     0.2746 ns |     0.4663 ns |      - |      - |     - |         - |
|         Constructor_SI |    579.347 ns |    11.4120 ns |    20.2849 ns | 0.0277 |      - |     - |     192 B |
|             FromMethod |     28.295 ns |     0.5972 ns |     1.1069 ns |      - |      - |     - |         - |
|             ToProperty |      9.045 ns |     0.2280 ns |     0.4111 ns |      - |      - |     - |         - |
|                     As |      8.716 ns |     0.2137 ns |     0.2099 ns |      - |      - |     - |         - |
|                  As_SI |    557.790 ns |    11.1126 ns |    20.3200 ns | 0.0278 |      - |     - |     192 B |
|                 ToUnit |     20.164 ns |     0.4431 ns |     0.4741 ns |      - |      - |     - |         - |
|              ToUnit_SI |    552.626 ns |    10.9242 ns |    16.6824 ns | 0.0278 |      - |     - |     192 B |
|           ToStringTest |  2,123.379 ns |    35.7125 ns |    35.0744 ns | 0.1399 |      - |     - |     952 B |
|                  Parse | 62,451.796 ns | 1,221.8481 ns | 1,020.2985 ns | 6.8384 | 0.2442 |     - |   44816 B |
|          TryParseValid | 62,181.745 ns | 1,167.7013 ns | 1,092.2685 ns | 6.7525 | 0.2501 |     - |   44792 B |
|        TryParseInvalid | 69,473.084 ns | 1,387.7197 ns | 2,640.2809 ns | 6.7150 | 0.2686 |     - |   44392 B |
|           QuantityFrom |  1,964.894 ns |    62.2572 ns |   177.6232 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     21.301 ns |     0.4615 ns |     0.4091 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    560.177 ns |    10.8599 ns |    10.1584 ns | 0.0273 |      - |     - |     192 B |
|       IQuantity_ToUnit |     27.339 ns |     0.6341 ns |     0.9872 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,132.593 ns |    41.4359 ns |    46.0559 ns | 0.1398 |      - |     - |     952 B |
