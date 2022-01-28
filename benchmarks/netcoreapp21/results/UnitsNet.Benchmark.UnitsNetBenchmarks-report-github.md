``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-UEFSML : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.68 ns |     0.315 ns |     0.295 ns |      - |      - |     - |         - |
|         Constructor_SI |    662.95 ns |    13.242 ns |    13.599 ns | 0.0268 |      - |     - |     192 B |
|             FromMethod |     31.54 ns |     0.455 ns |     0.403 ns |      - |      - |     - |         - |
|             ToProperty |     10.95 ns |     0.243 ns |     0.227 ns |      - |      - |     - |         - |
|                     As |     10.98 ns |     0.264 ns |     0.369 ns |      - |      - |     - |         - |
|                  As_SI |    688.34 ns |    12.015 ns |    17.232 ns | 0.0271 |      - |     - |     192 B |
|                 ToUnit |     22.01 ns |     0.431 ns |     0.382 ns |      - |      - |     - |         - |
|              ToUnit_SI |    658.52 ns |     9.914 ns |     9.274 ns | 0.0267 |      - |     - |     192 B |
|           ToStringTest |  2,605.92 ns |    49.934 ns |    49.042 ns | 0.1399 |      - |     - |     952 B |
|                  Parse | 77,325.49 ns | 1,466.760 ns | 2,239.897 ns | 6.8027 | 0.1512 |     - |   44816 B |
|          TryParseValid | 78,333.78 ns | 1,504.475 ns | 2,429.447 ns | 6.6677 | 0.1551 |     - |   44792 B |
|        TryParseInvalid | 84,855.34 ns | 1,694.542 ns | 1,740.170 ns | 6.7103 | 0.1637 |     - |   44392 B |
|           QuantityFrom |  2,691.78 ns |    53.437 ns |   133.076 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     24.73 ns |     0.543 ns |     0.581 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    644.29 ns |    10.593 ns |     8.846 ns | 0.0269 |      - |     - |     192 B |
|       IQuantity_ToUnit |     35.30 ns |     0.660 ns |     0.617 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,654.52 ns |    34.672 ns |    30.736 ns | 0.1403 |      - |     - |     952 B |
