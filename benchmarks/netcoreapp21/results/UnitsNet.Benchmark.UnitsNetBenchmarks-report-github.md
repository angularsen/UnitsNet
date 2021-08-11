``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2061 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.400
  [Host]     : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  Job-EMMFQG : .NET Core 2.1.29 (CoreCLR 4.6.30321.06, CoreFX 4.6.30322.04), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.798 ns |     0.2447 ns |     0.2512 ns |      - |      - |     - |         - |
|         Constructor_SI |    557.599 ns |    11.1761 ns |    19.2781 ns | 0.0271 |      - |     - |     192 B |
|             FromMethod |     28.686 ns |     0.6161 ns |     0.9408 ns |      - |      - |     - |         - |
|             ToProperty |      8.616 ns |     0.2107 ns |     0.2954 ns |      - |      - |     - |         - |
|                     As |      8.469 ns |     0.2130 ns |     0.3055 ns |      - |      - |     - |         - |
|                  As_SI |    585.285 ns |    11.7164 ns |    25.7178 ns | 0.0265 |      - |     - |     192 B |
|                 ToUnit |     18.525 ns |     0.4124 ns |     0.7223 ns |      - |      - |     - |         - |
|              ToUnit_SI |    608.183 ns |    11.4233 ns |    10.6853 ns | 0.0262 |      - |     - |     192 B |
|           ToStringTest |  2,021.798 ns |    40.2448 ns |    63.8324 ns | 0.1379 |      - |     - |     952 B |
|                  Parse | 67,169.842 ns | 1,214.3756 ns | 1,995.2539 ns | 6.5781 | 0.2631 |     - |   44816 B |
|          TryParseValid | 71,027.690 ns | 1,391.1876 ns | 2,362.3422 ns | 6.6649 | 0.1307 |     - |   44792 B |
|        TryParseInvalid | 73,821.204 ns | 1,446.8370 ns | 2,377.1947 ns | 6.5789 | 0.1495 |     - |   44392 B |
|           QuantityFrom |  1,923.656 ns |    42.3511 ns |   120.1429 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.745 ns |     0.4354 ns |     0.8070 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    541.131 ns |    10.6352 ns |    13.8287 ns | 0.0271 |      - |     - |     192 B |
|       IQuantity_ToUnit |     30.135 ns |     0.6860 ns |     1.0268 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,038.449 ns |    40.6708 ns |    92.6280 ns | 0.1385 |      - |     - |     952 B |
