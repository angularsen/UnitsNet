``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-SGQFQE : .NET Core 2.1.27 (CoreCLR 4.6.29916.01, CoreFX 4.6.29916.03), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.52 ns |     0.212 ns |     0.188 ns |      - |      - |     - |         - |
|         Constructor_SI |    655.82 ns |     9.929 ns |     9.287 ns | 0.0273 |      - |     - |     192 B |
|             FromMethod |     31.41 ns |     0.320 ns |     0.283 ns |      - |      - |     - |         - |
|             ToProperty |     10.23 ns |     0.154 ns |     0.129 ns |      - |      - |     - |         - |
|                     As |     10.20 ns |     0.138 ns |     0.129 ns |      - |      - |     - |         - |
|                  As_SI |    629.28 ns |    12.482 ns |    11.676 ns | 0.0274 |      - |     - |     192 B |
|                 ToUnit |     21.92 ns |     0.315 ns |     0.279 ns |      - |      - |     - |         - |
|              ToUnit_SI |    659.46 ns |    12.555 ns |    14.946 ns | 0.0273 |      - |     - |     192 B |
|           ToStringTest |  2,611.08 ns |    34.040 ns |    31.841 ns | 0.1412 |      - |     - |     952 B |
|                  Parse | 74,784.81 ns | 1,473.736 ns | 1,967.395 ns | 6.6930 | 0.1521 |     - |   44816 B |
|          TryParseValid | 73,889.31 ns | 1,359.359 ns | 1,271.545 ns | 6.6697 | 0.1516 |     - |   44792 B |
|        TryParseInvalid | 79,668.51 ns | 1,192.637 ns | 1,115.594 ns | 6.6044 | 0.1611 |     - |   44392 B |
|           QuantityFrom |  1,871.28 ns |    54.061 ns |   154.239 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     23.43 ns |     0.513 ns |     0.526 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    640.55 ns |     8.711 ns |     8.148 ns | 0.0273 |      - |     - |     192 B |
|       IQuantity_ToUnit |     33.51 ns |     0.538 ns |     0.477 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,594.40 ns |    39.495 ns |    35.011 ns | 0.1380 |      - |     - |     952 B |
