``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-HPLFJP : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.569 ns |     0.0463 ns |     0.0361 ns |     12.563 ns |      - |      - |     - |         - |
|         Constructor_SI |    508.453 ns |     6.9966 ns |     6.2023 ns |    506.315 ns | 0.0295 |      - |     - |     201 B |
|             FromMethod |     28.956 ns |     0.6118 ns |     1.2636 ns |     29.755 ns |      - |      - |     - |         - |
|             ToProperty |      8.640 ns |     0.0230 ns |     0.0179 ns |      8.636 ns |      - |      - |     - |         - |
|                     As |      8.662 ns |     0.0536 ns |     0.0475 ns |      8.659 ns |      - |      - |     - |         - |
|                  As_SI |    476.306 ns |     9.4653 ns |    19.9656 ns |    483.588 ns | 0.0295 |      - |     - |     201 B |
|                 ToUnit |     19.048 ns |     0.4196 ns |     0.6151 ns |     19.271 ns |      - |      - |     - |         - |
|              ToUnit_SI |    500.130 ns |    10.1111 ns |    17.4412 ns |    505.896 ns | 0.0296 |      - |     - |     201 B |
|           ToStringTest |  1,744.387 ns |     9.3756 ns |     8.3112 ns |  1,744.364 ns | 0.1860 |      - |     - |    1220 B |
|                  Parse | 52,220.051 ns |   549.0814 ns |   428.6867 ns | 52,146.297 ns | 8.3994 | 0.2863 |     - |   54376 B |
|          TryParseValid | 51,681.883 ns | 1,020.4882 ns | 1,175.1958 ns | 52,046.799 ns | 8.4034 | 0.3112 |     - |   54352 B |
|        TryParseInvalid | 56,793.006 ns |   504.7568 ns |   472.1498 ns | 56,613.542 ns | 8.3352 | 0.3425 |     - |   53895 B |
|           QuantityFrom |  2,180.435 ns |    47.9545 ns |   135.2565 ns |  2,200.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     17.345 ns |     0.3885 ns |     1.0831 ns |     17.746 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    484.721 ns |     2.4639 ns |     2.1842 ns |    484.738 ns | 0.0299 |      - |     - |     201 B |
|       IQuantity_ToUnit |     28.698 ns |     0.6453 ns |     0.8161 ns |     28.917 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,694.077 ns |    33.7633 ns |    93.5579 ns |  1,679.746 ns | 0.1834 |      - |     - |    1220 B |
