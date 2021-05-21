``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-SKXGNE : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.641 ns |   0.0289 ns |   0.0256 ns |     12.642 ns |      - |      - |     - |         - |
|         Constructor_SI |    491.437 ns |   3.3749 ns |   3.1569 ns |    492.054 ns | 0.0294 |      - |     - |     201 B |
|             FromMethod |     29.480 ns |   0.0758 ns |   0.0709 ns |     29.501 ns |      - |      - |     - |         - |
|             ToProperty |      8.677 ns |   0.0419 ns |   0.0392 ns |      8.669 ns |      - |      - |     - |         - |
|                     As |      8.675 ns |   0.0391 ns |   0.0366 ns |      8.674 ns |      - |      - |     - |         - |
|                  As_SI |    478.961 ns |   5.3089 ns |   4.9659 ns |    478.369 ns | 0.0299 |      - |     - |     201 B |
|                 ToUnit |     19.368 ns |   0.0358 ns |   0.0335 ns |     19.376 ns |      - |      - |     - |         - |
|              ToUnit_SI |    570.227 ns |   1.5920 ns |   1.2429 ns |    570.591 ns | 0.0285 |      - |     - |     201 B |
|           ToStringTest |  1,751.551 ns |  10.0710 ns |   9.4204 ns |  1,751.924 ns | 0.1898 |      - |     - |    1244 B |
|                  Parse | 52,855.112 ns | 198.5590 ns | 176.0174 ns | 52,809.649 ns | 8.3770 | 0.3141 |     - |   54376 B |
|          TryParseValid | 54,215.427 ns | 154.9841 ns | 129.4187 ns | 54,253.718 ns | 8.4089 | 0.3276 |     - |   54352 B |
|        TryParseInvalid | 58,602.442 ns | 271.4099 ns | 253.8770 ns | 58,577.142 ns | 8.3226 | 0.3517 |     - |   53895 B |
|           QuantityFrom |  1,625.926 ns |  32.1475 ns |  67.8099 ns |  1,600.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     18.124 ns |   0.1117 ns |   0.0991 ns |     18.129 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    474.884 ns |   3.5945 ns |   3.3623 ns |    473.148 ns | 0.0297 |      - |     - |     201 B |
|       IQuantity_ToUnit |     26.817 ns |   0.1016 ns |   0.0849 ns |     26.785 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,982.039 ns |  11.1524 ns |  10.4319 ns |  1,981.357 ns | 0.1894 |      - |     - |    1244 B |
