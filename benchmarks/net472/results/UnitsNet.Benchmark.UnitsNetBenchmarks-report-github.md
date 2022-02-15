``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.20348
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-CGERLY : .NET Framework 4.8 (4.8.4470.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.90 ns |     0.335 ns |     0.359 ns |      - |      - |     - |         - |
|         Constructor_SI |    597.89 ns |    11.544 ns |    10.799 ns | 0.0291 |      - |     - |     201 B |
|             FromMethod |     33.85 ns |     0.693 ns |     0.824 ns |      - |      - |     - |         - |
|             ToProperty |    269.51 ns |     4.588 ns |     4.291 ns | 0.0167 |      - |     - |     112 B |
|                     As |    249.39 ns |     4.855 ns |     5.962 ns | 0.0167 |      - |     - |     112 B |
|                  As_SI |    608.56 ns |    11.748 ns |    16.081 ns | 0.0294 |      - |     - |     201 B |
|                 ToUnit |    268.12 ns |     5.383 ns |     6.808 ns | 0.0166 |      - |     - |     112 B |
|              ToUnit_SI |    615.58 ns |    12.089 ns |    15.289 ns | 0.0295 |      - |     - |     201 B |
|           ToStringTest |  2,076.26 ns |    32.737 ns |    32.152 ns | 0.1848 |      - |     - |    1220 B |
|                  Parse | 68,812.58 ns | 1,227.279 ns | 1,679.913 ns | 8.7903 | 0.2791 |     - |   57393 B |
|          TryParseValid | 70,458.00 ns | 1,372.978 ns | 1,686.140 ns | 8.8045 | 0.2751 |     - |   57369 B |
|        TryParseInvalid | 74,843.48 ns | 1,466.524 ns | 2,195.023 ns | 8.7100 | 0.3003 |     - |   56912 B |
|           QuantityFrom |    102.53 ns |     2.092 ns |     2.570 ns | 0.0083 |      - |     - |      56 B |
|           IQuantity_As |    266.76 ns |     5.043 ns |     7.233 ns | 0.0206 |      - |     - |     136 B |
|        IQuantity_As_SI |    610.89 ns |    11.587 ns |    10.271 ns | 0.0287 |      - |     - |     201 B |
|       IQuantity_ToUnit |    263.61 ns |     5.362 ns |     6.782 ns | 0.0255 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,281.39 ns |    45.569 ns |    89.949 ns | 0.1817 |      - |     - |    1220 B |
