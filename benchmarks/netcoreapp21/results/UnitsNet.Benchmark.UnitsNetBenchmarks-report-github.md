``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-ORSZXU : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.84 ns |     0.215 ns |     0.191 ns |      - |      - |     - |         - |
|         Constructor_SI |    669.66 ns |    13.178 ns |    14.647 ns | 0.0274 |      - |     - |     192 B |
|             FromMethod |     31.96 ns |     0.448 ns |     0.397 ns |      - |      - |     - |         - |
|             ToProperty |     11.02 ns |     0.212 ns |     0.199 ns |      - |      - |     - |         - |
|                     As |     11.26 ns |     0.274 ns |     0.494 ns |      - |      - |     - |         - |
|                  As_SI |    647.82 ns |    12.913 ns |    21.217 ns | 0.0270 |      - |     - |     192 B |
|                 ToUnit |     22.46 ns |     0.313 ns |     0.278 ns |      - |      - |     - |         - |
|              ToUnit_SI |    675.60 ns |    13.438 ns |    18.838 ns | 0.0269 |      - |     - |     192 B |
|           ToStringTest |  2,541.26 ns |    49.799 ns |    72.995 ns | 0.1374 |      - |     - |     952 B |
|                  Parse | 78,037.60 ns | 1,542.982 ns | 1,715.021 ns | 6.7619 | 0.1537 |     - |   44816 B |
|          TryParseValid | 78,040.10 ns | 1,533.949 ns | 1,575.253 ns | 6.6890 | 0.1520 |     - |   44792 B |
|        TryParseInvalid | 83,338.09 ns | 1,470.291 ns | 1,693.189 ns | 6.6953 | 0.1717 |     - |   44392 B |
|           QuantityFrom |  1,813.98 ns |    79.944 ns |   226.788 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     25.05 ns |     0.523 ns |     0.464 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    643.00 ns |    10.884 ns |    13.367 ns | 0.0274 |      - |     - |     192 B |
|       IQuantity_ToUnit |     35.65 ns |     0.569 ns |     0.532 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,561.30 ns |    50.616 ns |    80.282 ns | 0.1408 |      - |     - |     952 B |
