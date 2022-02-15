``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.20348
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-NLQZDR : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|            Constructor |     11.31 ns |     0.263 ns |     0.282 ns |      - |     - |     - |         - |
|         Constructor_SI |    384.67 ns |     7.493 ns |     8.629 ns | 0.0101 |     - |     - |     192 B |
|             FromMethod |     28.12 ns |     0.336 ns |     0.297 ns |      - |     - |     - |         - |
|             ToProperty |    172.36 ns |     3.395 ns |     3.909 ns | 0.0057 |     - |     - |     112 B |
|                     As |    174.81 ns |     3.408 ns |     4.057 ns | 0.0059 |     - |     - |     112 B |
|                  As_SI |    389.03 ns |     4.240 ns |     3.966 ns | 0.0099 |     - |     - |     192 B |
|                 ToUnit |    167.51 ns |     3.398 ns |     4.874 ns | 0.0059 |     - |     - |     112 B |
|              ToUnit_SI |    398.79 ns |     6.840 ns |     6.398 ns | 0.0097 |     - |     - |     192 B |
|           ToStringTest |  1,406.41 ns |    19.950 ns |    17.685 ns | 0.0503 |     - |     - |     944 B |
|                  Parse | 50,802.62 ns |   985.537 ns |   921.872 ns | 1.7778 |     - |     - |   34761 B |
|          TryParseValid | 51,710.86 ns |   962.545 ns |   945.348 ns | 1.7986 |     - |     - |   34736 B |
|        TryParseInvalid | 55,932.43 ns | 1,107.680 ns | 1,360.331 ns | 1.8079 |     - |     - |   34344 B |
|           QuantityFrom |     79.69 ns |     1.661 ns |     2.485 ns | 0.0030 |     - |     - |      56 B |
|           IQuantity_As |    181.61 ns |     3.641 ns |     5.668 ns | 0.0072 |     - |     - |     136 B |
|        IQuantity_As_SI |    390.28 ns |     7.338 ns |     6.864 ns | 0.0097 |     - |     - |     192 B |
|       IQuantity_ToUnit |    181.26 ns |     3.725 ns |     5.799 ns | 0.0088 |     - |     - |     168 B |
| IQuantity_ToStringTest |  1,488.35 ns |    27.867 ns |    26.067 ns | 0.0505 |     - |     - |     944 B |
