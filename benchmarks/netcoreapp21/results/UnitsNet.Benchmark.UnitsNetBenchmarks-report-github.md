``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-JLBRUV : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.878 ns |     0.2834 ns |     0.4154 ns |      - |      - |     - |         - |
|         Constructor_SI |    600.010 ns |    11.8123 ns |    20.0582 ns | 0.0261 |      - |     - |     192 B |
|             FromMethod |     32.947 ns |     0.6854 ns |     0.6076 ns |      - |      - |     - |         - |
|             ToProperty |      9.311 ns |     0.2229 ns |     0.2289 ns |      - |      - |     - |         - |
|                     As |      9.293 ns |     0.2298 ns |     0.2988 ns |      - |      - |     - |         - |
|                  As_SI |    583.515 ns |    11.6674 ns |    21.9142 ns | 0.0263 |      - |     - |     192 B |
|                 ToUnit |     19.395 ns |     0.3917 ns |     0.5982 ns |      - |      - |     - |         - |
|              ToUnit_SI |    606.589 ns |     9.6343 ns |     9.0120 ns | 0.0265 |      - |     - |     192 B |
|           ToStringTest |  2,166.615 ns |    42.9454 ns |    77.4394 ns | 0.1331 |      - |     - |     952 B |
|                  Parse | 75,556.795 ns | 1,496.4183 ns | 2,458.6582 ns | 6.6125 | 0.1378 |     - |   44816 B |
|          TryParseValid | 75,679.955 ns | 1,487.5846 ns | 2,444.1441 ns | 6.5243 | 0.1483 |     - |   44792 B |
|        TryParseInvalid | 81,410.804 ns | 1,607.4529 ns | 2,939.3186 ns | 6.5579 | 0.1525 |     - |   44392 B |
|           QuantityFrom |  2,491.489 ns |    56.4604 ns |   161.0847 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     20.045 ns |     0.4482 ns |     0.4796 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    586.031 ns |    11.5395 ns |    23.8310 ns | 0.0260 |      - |     - |     192 B |
|       IQuantity_ToUnit |     32.524 ns |     0.7460 ns |     1.2257 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,188.981 ns |    43.1737 ns |    51.3953 ns | 0.1361 |      - |     - |     952 B |
