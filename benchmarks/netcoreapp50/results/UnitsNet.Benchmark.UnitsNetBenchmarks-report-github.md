``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-ELPSXY : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |      9.502 ns |   0.0324 ns |   0.0303 ns |      - |     - |     - |         - |
|         Constructor_SI |    332.065 ns |   1.1421 ns |   1.0684 ns | 0.0100 |     - |     - |     192 B |
|             FromMethod |     24.379 ns |   0.0441 ns |   0.0412 ns |      - |     - |     - |         - |
|             ToProperty |      8.740 ns |   0.0233 ns |   0.0218 ns |      - |     - |     - |         - |
|                     As |      8.793 ns |   0.0295 ns |   0.0276 ns |      - |     - |     - |         - |
|                  As_SI |    339.486 ns |   1.0005 ns |   0.9359 ns | 0.0096 |     - |     - |     192 B |
|                 ToUnit |     16.234 ns |   0.0456 ns |   0.0427 ns |      - |     - |     - |         - |
|              ToUnit_SI |    328.841 ns |   1.6503 ns |   1.5437 ns | 0.0100 |     - |     - |     192 B |
|           ToStringTest |  1,277.819 ns |  13.7501 ns |  12.8619 ns | 0.0504 |     - |     - |     944 B |
|                  Parse | 44,501.671 ns | 357.6432 ns | 334.5397 ns | 1.7663 |     - |     - |   33345 B |
|          TryParseValid | 44,260.917 ns | 370.5389 ns | 346.6023 ns | 1.7635 |     - |     - |   33321 B |
|        TryParseInvalid | 47,244.985 ns | 441.6032 ns | 413.0760 ns | 1.7086 |     - |     - |   32928 B |
|           QuantityFrom |  3,503.333 ns |  68.8554 ns | 154.0049 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     20.064 ns |   0.1973 ns |   0.1846 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    322.470 ns |   1.4212 ns |   1.3294 ns | 0.0097 |     - |     - |     192 B |
|       IQuantity_ToUnit |     30.521 ns |   0.5784 ns |   0.5410 ns | 0.0029 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,300.696 ns |  10.1436 ns |   9.4884 ns | 0.0496 |     - |     - |     944 B |
