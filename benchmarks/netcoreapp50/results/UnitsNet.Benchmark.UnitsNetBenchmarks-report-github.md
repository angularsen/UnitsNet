``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.401
  [Host]     : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT
  Job-HMVHCK : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.044 ns |     0.2635 ns |     0.2706 ns |      - |     - |     - |         - |
|         Constructor_SI |    380.196 ns |     7.6224 ns |    10.1757 ns | 0.0068 |     - |     - |     192 B |
|             FromMethod |     29.897 ns |     0.6335 ns |     0.7295 ns |      - |     - |     - |         - |
|             ToProperty |      9.326 ns |     0.2216 ns |     0.2176 ns |      - |     - |     - |         - |
|                     As |      8.951 ns |     0.2233 ns |     0.2089 ns |      - |     - |     - |         - |
|                  As_SI |    356.469 ns |     5.5792 ns |     4.6589 ns | 0.0072 |     - |     - |     192 B |
|                 ToUnit |     19.026 ns |     0.3955 ns |     0.3699 ns |      - |     - |     - |         - |
|              ToUnit_SI |    398.708 ns |     7.8694 ns |     9.3680 ns | 0.0070 |     - |     - |     192 B |
|           ToStringTest |  1,435.568 ns |    28.5629 ns |    38.1306 ns | 0.0339 |     - |     - |     944 B |
|                  Parse | 52,775.725 ns | 1,044.0977 ns | 1,025.4436 ns | 1.2580 |     - |     - |   33344 B |
|          TryParseValid | 55,840.354 ns | 1,091.6979 ns | 1,565.6805 ns | 1.1809 |     - |     - |   33320 B |
|        TryParseInvalid | 57,618.138 ns | 1,147.8072 ns | 1,609.0654 ns | 1.2031 |     - |     - |   32928 B |
|           QuantityFrom |  3,977.083 ns |   104.5817 ns |   301.7420 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     22.012 ns |     0.4884 ns |     0.9293 ns | 0.0009 |     - |     - |      24 B |
|        IQuantity_As_SI |    370.468 ns |     7.4796 ns |     6.9965 ns | 0.0068 |     - |     - |     192 B |
|       IQuantity_ToUnit |     33.506 ns |     0.7636 ns |     1.3963 ns | 0.0021 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,501.088 ns |    29.5765 ns |    44.2688 ns | 0.0348 |     - |     - |     944 B |
