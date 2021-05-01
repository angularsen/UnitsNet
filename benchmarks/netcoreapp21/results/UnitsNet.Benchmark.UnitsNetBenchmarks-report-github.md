``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-CABZMB : .NET Core 2.1.27 (CoreCLR 4.6.29916.01, CoreFX 4.6.29916.03), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.22 ns |     0.164 ns |     0.154 ns |      - |      - |     - |         - |
|         Constructor_SI |    649.00 ns |     8.577 ns |     7.603 ns | 0.0274 |      - |     - |     192 B |
|             FromMethod |     30.96 ns |     0.491 ns |     0.436 ns |      - |      - |     - |         - |
|             ToProperty |     10.62 ns |     0.136 ns |     0.127 ns |      - |      - |     - |         - |
|                     As |     10.55 ns |     0.133 ns |     0.124 ns |      - |      - |     - |         - |
|                  As_SI |    648.78 ns |     7.060 ns |     6.604 ns | 0.0271 |      - |     - |     192 B |
|                 ToUnit |     21.45 ns |     0.174 ns |     0.154 ns |      - |      - |     - |         - |
|              ToUnit_SI |    632.09 ns |     7.949 ns |     7.436 ns | 0.0279 |      - |     - |     192 B |
|           ToStringTest |  2,514.50 ns |    44.766 ns |    41.874 ns | 0.1370 |      - |     - |     952 B |
|                  Parse | 72,305.63 ns |   793.438 ns |   662.557 ns | 6.7753 | 0.1442 |     - |   44816 B |
|          TryParseValid | 72,910.42 ns |   897.046 ns |   839.097 ns | 6.7095 | 0.1428 |     - |   44792 B |
|        TryParseInvalid | 79,902.99 ns | 1,552.210 ns | 1,451.938 ns | 6.5906 | 0.1607 |     - |   44392 B |
|           QuantityFrom |  2,012.50 ns |    38.821 ns |    89.974 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     24.23 ns |     0.450 ns |     0.421 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    623.63 ns |     5.126 ns |     4.795 ns | 0.0272 |      - |     - |     192 B |
|       IQuantity_ToUnit |     32.77 ns |     0.338 ns |     0.299 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,438.73 ns |    19.599 ns |    18.332 ns | 0.1372 |      - |     - |     952 B |
