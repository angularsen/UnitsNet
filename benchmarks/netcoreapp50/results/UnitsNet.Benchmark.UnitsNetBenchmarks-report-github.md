``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.20348
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-AWGAGU : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|            Constructor |     11.89 ns |     0.154 ns |     0.136 ns |      - |     - |     - |         - |
|         Constructor_SI |    412.04 ns |     5.706 ns |     5.338 ns | 0.0097 |     - |     - |     192 B |
|             FromMethod |     31.34 ns |     0.428 ns |     0.400 ns |      - |     - |     - |         - |
|             ToProperty |    181.40 ns |     2.801 ns |     2.620 ns | 0.0057 |     - |     - |     112 B |
|                     As |    181.90 ns |     3.608 ns |     3.198 ns | 0.0057 |     - |     - |     112 B |
|                  As_SI |    418.94 ns |     5.208 ns |     4.871 ns | 0.0100 |     - |     - |     192 B |
|                 ToUnit |    178.42 ns |     2.361 ns |     2.208 ns | 0.0058 |     - |     - |     112 B |
|              ToUnit_SI |    418.61 ns |     5.956 ns |     5.571 ns | 0.0101 |     - |     - |     192 B |
|           ToStringTest |  1,625.03 ns |    23.468 ns |    21.952 ns | 0.0492 |     - |     - |     944 B |
|                  Parse | 58,367.09 ns | 1,143.530 ns | 1,223.565 ns | 1.8450 |     - |     - |   34760 B |
|          TryParseValid | 57,474.06 ns |   840.759 ns |   786.447 ns | 1.8213 |     - |     - |   34736 B |
|        TryParseInvalid | 62,051.20 ns | 1,042.406 ns | 1,115.363 ns | 1.8275 |     - |     - |   34344 B |
|           QuantityFrom |     87.16 ns |     1.787 ns |     1.835 ns | 0.0030 |     - |     - |      56 B |
|           IQuantity_As |    211.22 ns |     2.727 ns |     2.277 ns | 0.0072 |     - |     - |     136 B |
|        IQuantity_As_SI |    423.51 ns |     8.196 ns |     8.417 ns | 0.0102 |     - |     - |     192 B |
|       IQuantity_ToUnit |    199.32 ns |     2.603 ns |     2.173 ns | 0.0088 |     - |     - |     168 B |
| IQuantity_ToStringTest |  1,667.81 ns |    26.858 ns |    22.427 ns | 0.0504 |     - |     - |     944 B |
