``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-WTODYE : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.927 ns |   0.0237 ns |   0.0221 ns |      - |      - |     - |         - |
|         Constructor_SI |    531.737 ns |   4.2167 ns |   3.9443 ns | 0.0274 |      - |     - |     192 B |
|             FromMethod |     25.825 ns |   0.0483 ns |   0.0452 ns |      - |      - |     - |         - |
|             ToProperty |      8.736 ns |   0.0259 ns |   0.0242 ns |      - |      - |     - |         - |
|                     As |      8.738 ns |   0.0221 ns |   0.0207 ns |      - |      - |     - |         - |
|                  As_SI |    509.047 ns |   1.9185 ns |   1.7946 ns | 0.0277 |      - |     - |     192 B |
|                 ToUnit |     17.642 ns |   0.0335 ns |   0.0314 ns |      - |      - |     - |         - |
|              ToUnit_SI |    520.912 ns |   2.3053 ns |   2.0436 ns | 0.0276 |      - |     - |     192 B |
|           ToStringTest |  2,171.607 ns |  12.7438 ns |  11.9206 ns | 0.1389 |      - |     - |     952 B |
|                  Parse | 59,176.374 ns | 126.4387 ns | 118.2708 ns | 6.8672 | 0.2368 |     - |   44816 B |
|          TryParseValid | 59,050.486 ns | 126.8113 ns | 112.4149 ns | 6.8582 | 0.2365 |     - |   44792 B |
|        TryParseInvalid | 64,784.810 ns | 177.1748 ns | 165.7294 ns | 6.6907 | 0.2573 |     - |   44392 B |
|           QuantityFrom |  1,720.635 ns |  34.2149 ns |  78.6145 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.145 ns |   0.0823 ns |   0.0770 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    501.188 ns |   2.2470 ns |   2.1019 ns | 0.0280 |      - |     - |     192 B |
|       IQuantity_ToUnit |     26.323 ns |   0.1070 ns |   0.1001 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,953.554 ns |  12.0512 ns |  11.2727 ns | 0.1400 |      - |     - |     952 B |
