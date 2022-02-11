``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-GMONMZ : .NET Framework 4.8 (4.8.4470.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |       Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.72 ns |     0.268 ns |     0.611 ns |     11.55 ns |      - |      - |     - |         - |
|         Constructor_SI |    501.19 ns |     9.960 ns |    26.239 ns |    516.03 ns | 0.0298 |      - |     - |     201 B |
|             FromMethod |     27.80 ns |     0.593 ns |     1.432 ns |     27.49 ns |      - |      - |     - |         - |
|             ToProperty |    241.92 ns |     4.846 ns |    12.067 ns |    245.25 ns | 0.0170 |      - |     - |     112 B |
|                     As |    209.04 ns |     4.084 ns |     5.452 ns |    209.37 ns | 0.0167 |      - |     - |     112 B |
|                  As_SI |    443.31 ns |     8.738 ns |     7.746 ns |    442.19 ns | 0.0295 |      - |     - |     201 B |
|                 ToUnit |    196.58 ns |     2.553 ns |     2.731 ns |    195.71 ns | 0.0170 |      - |     - |     112 B |
|              ToUnit_SI |    460.62 ns |     7.645 ns |     6.384 ns |    461.51 ns | 0.0294 |      - |     - |     201 B |
|           ToStringTest |  1,766.42 ns |    35.081 ns |    90.556 ns |  1,729.82 ns | 0.1848 |      - |     - |    1220 B |
|                  Parse | 50,343.52 ns |   974.672 ns |   864.021 ns | 50,087.11 ns | 8.9091 | 0.3108 |     - |   57393 B |
|          TryParseValid | 50,401.33 ns |   425.521 ns |   355.330 ns | 50,417.55 ns | 8.8505 | 0.3052 |     - |   57369 B |
|        TryParseInvalid | 59,387.58 ns | 1,174.912 ns | 2,746.318 ns | 59,550.96 ns | 8.7993 | 0.3342 |     - |   56911 B |
|           QuantityFrom |     81.37 ns |     1.344 ns |     1.122 ns |     81.59 ns | 0.0085 |      - |     - |      56 B |
|           IQuantity_As |    208.53 ns |     4.051 ns |     4.160 ns |    207.30 ns | 0.0207 |      - |     - |     136 B |
|        IQuantity_As_SI |    467.07 ns |     9.295 ns |    23.147 ns |    461.72 ns | 0.0296 |      - |     - |     201 B |
|       IQuantity_ToUnit |    208.76 ns |     3.754 ns |     3.511 ns |    207.91 ns | 0.0256 |      - |     - |     168 B |
| IQuantity_ToStringTest |  1,712.29 ns |    33.986 ns |    74.600 ns |  1,684.59 ns | 0.1850 |      - |     - |    1220 B |
