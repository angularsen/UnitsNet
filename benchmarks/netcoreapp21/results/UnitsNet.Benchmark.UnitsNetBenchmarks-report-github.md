``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.20348
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-WJDBMX : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.47 ns |     0.241 ns |     0.416 ns |      - |      - |     - |         - |
|         Constructor_SI |    517.48 ns |    10.214 ns |    17.344 ns | 0.0279 |      - |     - |     192 B |
|             FromMethod |     24.16 ns |     0.512 ns |     1.010 ns |      - |      - |     - |         - |
|             ToProperty |    174.60 ns |     3.420 ns |     3.659 ns | 0.0169 |      - |     - |     112 B |
|                     As |    171.99 ns |     3.429 ns |     5.237 ns | 0.0170 |      - |     - |     112 B |
|                  As_SI |    514.50 ns |    10.189 ns |    13.947 ns | 0.0278 |      - |     - |     192 B |
|                 ToUnit |    169.91 ns |     3.295 ns |     4.168 ns | 0.0169 |      - |     - |     112 B |
|              ToUnit_SI |    509.88 ns |    10.012 ns |    17.796 ns | 0.0275 |      - |     - |     192 B |
|           ToStringTest |  2,006.10 ns |    40.025 ns |    47.647 ns | 0.1411 |      - |     - |     952 B |
|                  Parse | 61,414.74 ns | 1,221.811 ns | 1,712.808 ns | 7.1811 | 0.2434 |     - |   47008 B |
|          TryParseValid | 62,148.42 ns | 1,196.356 ns | 1,174.982 ns | 7.1352 | 0.2378 |     - |   46984 B |
|        TryParseInvalid | 67,641.99 ns | 1,341.179 ns | 1,647.088 ns | 7.1184 | 0.2738 |     - |   46584 B |
|           QuantityFrom |     84.52 ns |     1.327 ns |     1.242 ns | 0.0085 |      - |     - |      56 B |
|           IQuantity_As |    186.92 ns |     3.702 ns |     4.814 ns | 0.0207 |      - |     - |     136 B |
|        IQuantity_As_SI |    519.31 ns |     9.643 ns |     9.020 ns | 0.0279 |      - |     - |     192 B |
|       IQuantity_ToUnit |    185.09 ns |     3.716 ns |     5.209 ns | 0.0258 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,020.96 ns |    39.068 ns |    43.424 ns | 0.1410 |      - |     - |     952 B |
