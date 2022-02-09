``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-PZTXPI : .NET Framework 4.8 (4.8.4470.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |      Error |     StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------:|-------:|------:|----------:|
|            Constructor |     12.61 ns |   0.046 ns |   0.043 ns |      - |      - |     - |         - |
|         Constructor_SI |    512.79 ns |   1.507 ns |   1.336 ns | 0.0296 |      - |     - |     201 B |
|             FromMethod |     29.59 ns |   0.099 ns |   0.093 ns |      - |      - |     - |         - |
|             ToProperty |    231.51 ns |   0.687 ns |   0.643 ns | 0.0168 |      - |     - |     112 B |
|                     As |    233.23 ns |   1.014 ns |   0.948 ns | 0.0166 |      - |     - |     112 B |
|                  As_SI |    502.58 ns |   1.296 ns |   1.212 ns | 0.0292 |      - |     - |     201 B |
|                 ToUnit |    232.02 ns |   2.598 ns |   2.430 ns | 0.0168 |      - |     - |     112 B |
|              ToUnit_SI |    497.57 ns |   6.540 ns |   6.117 ns | 0.0295 |      - |     - |     201 B |
|           ToStringTest |  1,874.77 ns |  24.022 ns |  21.295 ns | 0.1863 |      - |     - |    1220 B |
|                  Parse | 56,942.39 ns | 583.078 ns | 545.411 ns | 8.3891 | 0.3401 |     - |   54377 B |
|          TryParseValid | 56,375.24 ns | 253.330 ns | 224.571 ns | 8.3134 | 0.3416 |     - |   54352 B |
|        TryParseInvalid | 60,907.60 ns | 260.598 ns | 231.013 ns | 8.3028 | 0.2442 |     - |   53895 B |
|           QuantityFrom |     92.13 ns |   1.086 ns |   1.016 ns | 0.0085 |      - |     - |      56 B |
|           IQuantity_As |    230.94 ns |   1.347 ns |   1.260 ns | 0.0207 |      - |     - |     136 B |
|        IQuantity_As_SI |    481.95 ns |   5.501 ns |   5.145 ns | 0.0295 |      - |     - |     201 B |
|       IQuantity_ToUnit |    242.15 ns |   1.244 ns |   1.163 ns | 0.0257 |      - |     - |     168 B |
| IQuantity_ToStringTest |  1,855.74 ns |   6.341 ns |   5.621 ns | 0.1833 |      - |     - |    1220 B |
