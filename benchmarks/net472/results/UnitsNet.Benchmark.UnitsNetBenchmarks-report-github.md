``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-PYEPHM : .NET Framework 4.8 (4.8.4360.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.453 ns |     0.2822 ns |     0.2640 ns |      - |      - |     - |         - |
|         Constructor_SI |    562.829 ns |     5.9892 ns |     5.3092 ns | 0.0279 |      - |     - |     201 B |
|             FromMethod |     39.769 ns |     0.6168 ns |     0.5770 ns |      - |      - |     - |         - |
|             ToProperty |      8.857 ns |     0.1595 ns |     0.1414 ns |      - |      - |     - |         - |
|                     As |      9.121 ns |     0.2224 ns |     0.2472 ns |      - |      - |     - |         - |
|                  As_SI |    550.494 ns |     7.9613 ns |     7.0575 ns | 0.0284 |      - |     - |     201 B |
|                 ToUnit |     21.850 ns |     0.1499 ns |     0.1170 ns |      - |      - |     - |         - |
|              ToUnit_SI |    623.732 ns |    12.0892 ns |    11.3083 ns | 0.0278 |      - |     - |     201 B |
|           ToStringTest |  2,237.184 ns |    44.1117 ns |    94.0055 ns | 0.1834 |      - |     - |    1244 B |
|                  Parse | 68,403.537 ns | 1,337.7151 ns | 1,785.8113 ns | 8.2383 | 0.2535 |     - |   54376 B |
|          TryParseValid | 67,467.574 ns | 1,199.5045 ns | 1,795.3618 ns | 8.1237 | 0.2621 |     - |   54352 B |
|        TryParseInvalid | 67,919.812 ns | 1,292.7063 ns | 1,488.6825 ns | 8.0259 | 0.2816 |     - |   53895 B |
|           QuantityFrom |  2,432.990 ns |    48.1642 ns |   139.7331 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     21.192 ns |     0.4658 ns |     0.6529 ns | 0.0036 |      - |     - |      24 B |
|        IQuantity_As_SI |    579.854 ns |    11.4270 ns |    14.8584 ns | 0.0272 |      - |     - |     201 B |
|       IQuantity_ToUnit |     33.741 ns |     0.7868 ns |     1.3361 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,148.115 ns |    36.0749 ns |    40.0972 ns | 0.1827 |      - |     - |    1244 B |
