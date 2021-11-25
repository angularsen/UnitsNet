``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-JMXGYP : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     13.027 ns |     0.2717 ns |     0.2408 ns |      - |      - |     - |         - |
|         Constructor_SI |    611.038 ns |     7.5735 ns |     6.7137 ns | 0.0270 |      - |     - |     192 B |
|             FromMethod |     30.930 ns |     0.4446 ns |     0.4159 ns |      - |      - |     - |         - |
|             ToProperty |      9.907 ns |     0.1378 ns |     0.1221 ns |      - |      - |     - |         - |
|                     As |     10.007 ns |     0.2425 ns |     0.2150 ns |      - |      - |     - |         - |
|                  As_SI |    611.659 ns |    12.2649 ns |    12.0458 ns | 0.0276 |      - |     - |     192 B |
|                 ToUnit |     20.723 ns |     0.1883 ns |     0.1573 ns |      - |      - |     - |         - |
|              ToUnit_SI |    626.682 ns |    12.0169 ns |    11.8022 ns | 0.0275 |      - |     - |     192 B |
|           ToStringTest |  2,850.609 ns |    54.3031 ns |    55.7653 ns | 0.1385 |      - |     - |     952 B |
|                  Parse | 72,302.084 ns | 1,389.0245 ns | 1,426.4259 ns | 6.7451 | 0.1435 |     - |   44816 B |
|          TryParseValid | 71,061.043 ns | 1,414.6592 ns | 1,513.6695 ns | 6.7998 | 0.1417 |     - |   44792 B |
|        TryParseInvalid | 79,769.193 ns | 1,573.6328 ns | 1,394.9845 ns | 6.6225 | 0.1577 |     - |   44392 B |
|           QuantityFrom |  2,294.681 ns |    61.9721 ns |   176.8099 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     24.483 ns |     0.5285 ns |     0.6872 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    613.578 ns |    12.0226 ns |    14.7649 ns | 0.0274 |      - |     - |     192 B |
|       IQuantity_ToUnit |     32.743 ns |     0.7525 ns |     1.1716 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,476.057 ns |    46.9184 ns |    48.1817 ns | 0.1387 |      - |     - |     952 B |
