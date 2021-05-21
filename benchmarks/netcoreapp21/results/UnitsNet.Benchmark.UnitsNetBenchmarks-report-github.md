``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-EEWJON : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |       Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.16 ns |     0.140 ns |     0.124 ns |     13.15 ns |      - |      - |     - |         - |
|         Constructor_SI |    661.35 ns |     9.136 ns |     8.099 ns |    660.95 ns | 0.0279 |      - |     - |     192 B |
|             FromMethod |     31.52 ns |     0.651 ns |     0.639 ns |     31.32 ns |      - |      - |     - |         - |
|             ToProperty |     10.62 ns |     0.221 ns |     0.196 ns |     10.56 ns |      - |      - |     - |         - |
|                     As |     10.53 ns |     0.085 ns |     0.075 ns |     10.52 ns |      - |      - |     - |         - |
|                  As_SI |    632.62 ns |    12.030 ns |    11.815 ns |    634.92 ns | 0.0276 |      - |     - |     192 B |
|                 ToUnit |     21.67 ns |     0.392 ns |     0.367 ns |     21.67 ns |      - |      - |     - |         - |
|              ToUnit_SI |    624.22 ns |    10.142 ns |     9.487 ns |    622.87 ns | 0.0269 |      - |     - |     192 B |
|           ToStringTest |  2,454.89 ns |    34.503 ns |    32.274 ns |  2,463.04 ns | 0.1390 |      - |     - |     952 B |
|                  Parse | 71,926.58 ns | 1,367.442 ns | 1,627.843 ns | 71,739.64 ns | 6.7355 | 0.1433 |     - |   44816 B |
|          TryParseValid | 70,878.78 ns | 1,066.785 ns |   890.814 ns | 70,737.26 ns | 6.7018 | 0.1426 |     - |   44792 B |
|        TryParseInvalid | 80,455.42 ns | 1,602.795 ns | 1,781.502 ns | 80,366.70 ns | 6.6529 | 0.1584 |     - |   44392 B |
|           QuantityFrom |  2,056.18 ns |    50.146 ns |   138.953 ns |  2,000.00 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     23.60 ns |     0.468 ns |     0.438 ns |     23.56 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    634.81 ns |     9.185 ns |     7.670 ns |    634.01 ns | 0.0275 |      - |     - |     192 B |
|       IQuantity_ToUnit |     34.05 ns |     0.789 ns |     0.969 ns |     34.17 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,523.50 ns |    25.887 ns |    22.948 ns |  2,521.48 ns | 0.1366 |      - |     - |     952 B |
