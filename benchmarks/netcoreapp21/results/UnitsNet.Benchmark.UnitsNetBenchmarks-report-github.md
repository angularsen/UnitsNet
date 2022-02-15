``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.20348
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-OFLQYM : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.97 ns |     0.033 ns |     0.029 ns |      - |      - |     - |         - |
|         Constructor_SI |    559.05 ns |     7.997 ns |     7.481 ns | 0.0276 |      - |     - |     192 B |
|             FromMethod |     25.65 ns |     0.188 ns |     0.176 ns |      - |      - |     - |         - |
|             ToProperty |    183.98 ns |     1.301 ns |     1.217 ns | 0.0168 |      - |     - |     112 B |
|                     As |    182.70 ns |     2.388 ns |     2.234 ns | 0.0169 |      - |     - |     112 B |
|                  As_SI |    542.99 ns |     3.111 ns |     2.598 ns | 0.0278 |      - |     - |     192 B |
|                 ToUnit |    187.03 ns |     2.208 ns |     2.065 ns | 0.0169 |      - |     - |     112 B |
|              ToUnit_SI |    547.11 ns |     5.412 ns |     5.062 ns | 0.0283 |      - |     - |     192 B |
|           ToStringTest |  2,084.03 ns |    24.163 ns |    22.602 ns | 0.1412 |      - |     - |     952 B |
|                  Parse | 64,708.33 ns |   531.944 ns |   497.580 ns | 7.1952 | 0.2570 |     - |   47008 B |
|          TryParseValid | 64,106.49 ns |   428.146 ns |   400.488 ns | 7.1887 | 0.2567 |     - |   46984 B |
|        TryParseInvalid | 70,870.35 ns | 1,380.638 ns | 1,477.268 ns | 7.0254 | 0.2810 |     - |   46584 B |
|           QuantityFrom |     87.65 ns |     0.695 ns |     0.650 ns | 0.0085 |      - |     - |      56 B |
|           IQuantity_As |    190.61 ns |     2.179 ns |     1.931 ns | 0.0205 |      - |     - |     136 B |
|        IQuantity_As_SI |    545.57 ns |     5.374 ns |     4.764 ns | 0.0282 |      - |     - |     192 B |
|       IQuantity_ToUnit |    197.28 ns |     2.688 ns |     2.514 ns | 0.0258 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,097.74 ns |    33.050 ns |    30.915 ns | 0.1411 |      - |     - |     952 B |
