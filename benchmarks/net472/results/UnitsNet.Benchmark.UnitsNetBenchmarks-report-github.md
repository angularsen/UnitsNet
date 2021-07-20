``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2029 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.302
  [Host]     : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT
  Job-PALNSV : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.670 ns |   0.0526 ns |   0.0492 ns |     12.657 ns |      - |      - |     - |         - |
|         Constructor_SI |    488.293 ns |   1.3297 ns |   1.2438 ns |    488.000 ns | 0.0293 |      - |     - |     201 B |
|             FromMethod |     29.683 ns |   0.0726 ns |   0.0679 ns |     29.682 ns |      - |      - |     - |         - |
|             ToProperty |      8.740 ns |   0.0312 ns |   0.0292 ns |      8.742 ns |      - |      - |     - |         - |
|                     As |      8.743 ns |   0.0779 ns |   0.0729 ns |      8.715 ns |      - |      - |     - |         - |
|                  As_SI |    494.643 ns |   2.3445 ns |   2.1931 ns |    494.660 ns | 0.0298 |      - |     - |     201 B |
|                 ToUnit |     19.339 ns |   0.0263 ns |   0.0234 ns |     19.329 ns |      - |      - |     - |         - |
|              ToUnit_SI |    500.979 ns |   2.5891 ns |   2.4219 ns |    500.633 ns | 0.0292 |      - |     - |     201 B |
|           ToStringTest |  1,875.205 ns |  13.7810 ns |  12.8908 ns |  1,876.218 ns | 0.1881 |      - |     - |    1244 B |
|                  Parse | 53,270.492 ns | 434.5370 ns | 406.4662 ns | 53,129.810 ns | 8.4016 | 0.3190 |     - |   54377 B |
|          TryParseValid | 52,677.351 ns | 362.3220 ns | 338.9162 ns | 52,658.967 ns | 8.3464 | 0.3130 |     - |   54352 B |
|        TryParseInvalid | 57,158.913 ns | 402.5036 ns | 336.1087 ns | 57,170.112 ns | 8.2551 | 0.3393 |     - |   53895 B |
|           QuantityFrom |  1,853.191 ns |  36.8032 ns |  71.7819 ns |  1,900.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     19.401 ns |   0.2177 ns |   0.2036 ns |     19.314 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    487.252 ns |   1.7425 ns |   1.6299 ns |    487.200 ns | 0.0293 |      - |     - |     201 B |
|       IQuantity_ToUnit |     29.132 ns |   0.2842 ns |   0.2658 ns |     29.191 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,897.840 ns |  18.0161 ns |  16.8522 ns |  1,894.847 ns | 0.1884 |      - |     - |    1244 B |
