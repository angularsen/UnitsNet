``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-IUEWTI : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.357 ns |     0.2848 ns |     0.5689 ns |      - |      - |     - |         - |
|         Constructor_SI |    505.843 ns |     2.6069 ns |     2.3110 ns | 0.0294 |      - |     - |     201 B |
|             FromMethod |     29.507 ns |     0.0560 ns |     0.0524 ns |      - |      - |     - |         - |
|             ToProperty |      8.518 ns |     0.2007 ns |     0.2061 ns |      - |      - |     - |         - |
|                     As |      8.651 ns |     0.0232 ns |     0.0217 ns |      - |      - |     - |         - |
|                  As_SI |    488.265 ns |     3.2246 ns |     3.0163 ns | 0.0293 |      - |     - |     201 B |
|                 ToUnit |     19.648 ns |     0.3236 ns |     0.2869 ns |      - |      - |     - |         - |
|              ToUnit_SI |    497.815 ns |     9.8598 ns |    20.1410 ns | 0.0294 |      - |     - |     201 B |
|           ToStringTest |  1,771.897 ns |     7.6187 ns |     7.1265 ns | 0.1837 |      - |     - |    1220 B |
|                  Parse | 57,813.725 ns |   513.2146 ns |   480.0612 ns | 8.3848 | 0.3494 |     - |   54376 B |
|          TryParseValid | 57,343.705 ns |   426.4956 ns |   398.9442 ns | 8.4005 | 0.3406 |     - |   54352 B |
|        TryParseInvalid | 60,766.540 ns | 1,177.7182 ns | 1,689.0483 ns | 8.2866 | 0.2437 |     - |   53895 B |
|           QuantityFrom |  2,200.000 ns |    42.9629 ns |    80.6947 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     17.458 ns |     0.3855 ns |     0.8543 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    489.401 ns |     4.1889 ns |     3.9183 ns | 0.0291 |      - |     - |     201 B |
|       IQuantity_ToUnit |     28.912 ns |     0.1638 ns |     0.1532 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,814.912 ns |    23.3595 ns |    21.8505 ns | 0.1859 |      - |     - |    1220 B |
