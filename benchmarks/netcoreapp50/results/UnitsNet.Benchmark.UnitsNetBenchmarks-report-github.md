``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.300
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-GEXAJV : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     10.676 ns |     0.2552 ns |     0.3578 ns |      - |     - |     - |         - |
|         Constructor_SI |    363.709 ns |     7.0982 ns |     8.7172 ns | 0.0073 |     - |     - |     192 B |
|             FromMethod |     32.385 ns |     0.6776 ns |     0.7803 ns |      - |     - |     - |         - |
|             ToProperty |      9.153 ns |     0.2267 ns |     0.2784 ns |      - |     - |     - |         - |
|                     As |      9.102 ns |     0.2292 ns |     0.3060 ns |      - |     - |     - |         - |
|                  As_SI |    374.911 ns |     7.5280 ns |    11.4960 ns | 0.0068 |     - |     - |     192 B |
|                 ToUnit |     18.732 ns |     0.4058 ns |     0.3796 ns |      - |     - |     - |         - |
|              ToUnit_SI |    369.479 ns |     6.5696 ns |     6.7465 ns | 0.0073 |     - |     - |     192 B |
|           ToStringTest |  1,566.389 ns |    30.7605 ns |    30.2109 ns | 0.0352 |     - |     - |     944 B |
|                  Parse | 54,070.959 ns | 1,072.5085 ns | 1,503.5071 ns | 1.2610 |     - |     - |   33344 B |
|          TryParseValid | 53,821.801 ns | 1,064.6625 ns | 1,749.2711 ns | 1.2031 |     - |     - |   33320 B |
|        TryParseInvalid | 59,183.828 ns | 1,163.7870 ns | 1,553.6222 ns | 1.1765 |     - |     - |   32928 B |
|           QuantityFrom |  3,520.408 ns |    95.4456 ns |   278.4194 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     21.118 ns |     0.4657 ns |     0.8398 ns | 0.0009 |     - |     - |      24 B |
|        IQuantity_As_SI |    374.905 ns |     7.5523 ns |    10.3377 ns | 0.0069 |     - |     - |     192 B |
|       IQuantity_ToUnit |     32.666 ns |     0.7405 ns |     2.1484 ns | 0.0021 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,541.506 ns |    30.6340 ns |    28.6550 ns | 0.0356 |     - |     - |     944 B |
