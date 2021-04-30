``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-RHHELZ : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     16.10 ns |     0.369 ns |     0.467 ns |      - |      - |     - |         - |
|         Constructor_SI |    639.25 ns |    12.281 ns |    15.532 ns | 0.0271 |      - |     - |     201 B |
|             FromMethod |     38.75 ns |     0.727 ns |     0.644 ns |      - |      - |     - |         - |
|             ToProperty |     10.49 ns |     0.243 ns |     0.227 ns |      - |      - |     - |         - |
|                     As |     10.30 ns |     0.243 ns |     0.260 ns |      - |      - |     - |         - |
|                  As_SI |    639.98 ns |    12.714 ns |    21.243 ns | 0.0274 |      - |     - |     201 B |
|                 ToUnit |     24.64 ns |     0.494 ns |     0.462 ns |      - |      - |     - |         - |
|              ToUnit_SI |    647.18 ns |    12.514 ns |    12.290 ns | 0.0271 |      - |     - |     201 B |
|           ToStringTest |  2,363.83 ns |    46.433 ns |    68.061 ns | 0.1806 |      - |     - |    1244 B |
|                  Parse | 74,037.06 ns | 1,442.526 ns | 1,824.333 ns | 8.0518 | 0.2876 |     - |   54377 B |
|          TryParseValid | 73,595.05 ns | 1,450.204 ns | 1,726.365 ns | 8.1229 | 0.2954 |     - |   54352 B |
|        TryParseInvalid | 77,885.89 ns | 1,516.475 ns | 1,971.846 ns | 7.9600 | 0.3122 |     - |   53895 B |
|           QuantityFrom |  2,814.43 ns |    66.001 ns |   191.480 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     24.32 ns |     0.523 ns |     0.602 ns | 0.0036 |      - |     - |      24 B |
|        IQuantity_As_SI |    641.73 ns |    11.652 ns |    10.900 ns | 0.0269 |      - |     - |     201 B |
|       IQuantity_ToUnit |     38.44 ns |     0.853 ns |     1.048 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,415.45 ns |    41.098 ns |    48.925 ns | 0.1795 |      - |     - |    1244 B |
