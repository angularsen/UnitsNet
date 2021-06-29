``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-STOSEB : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|            Constructor |     11.57 ns |     0.190 ns |     0.177 ns |      - |     - |     - |         - |
|         Constructor_SI |    380.72 ns |     2.748 ns |     2.436 ns | 0.0100 |     - |     - |     192 B |
|             FromMethod |     29.35 ns |     0.313 ns |     0.261 ns |      - |     - |     - |         - |
|             ToProperty |     10.46 ns |     0.096 ns |     0.080 ns |      - |     - |     - |         - |
|                     As |     11.08 ns |     0.084 ns |     0.074 ns |      - |     - |     - |         - |
|                  As_SI |    381.26 ns |     5.473 ns |     5.119 ns | 0.0098 |     - |     - |     192 B |
|                 ToUnit |     19.61 ns |     0.156 ns |     0.138 ns |      - |     - |     - |         - |
|              ToUnit_SI |    391.87 ns |     3.115 ns |     2.913 ns | 0.0103 |     - |     - |     192 B |
|           ToStringTest |  1,481.70 ns |    21.747 ns |    20.342 ns | 0.0480 |     - |     - |     944 B |
|                  Parse | 52,545.75 ns | 1,039.102 ns | 1,236.977 ns | 1.7531 |     - |     - |   33344 B |
|          TryParseValid | 52,437.38 ns |   419.569 ns |   392.465 ns | 1.7773 |     - |     - |   33321 B |
|        TryParseInvalid | 57,366.04 ns |   992.131 ns |   928.040 ns | 1.7117 |     - |     - |   32928 B |
|           QuantityFrom |  3,436.00 ns |    67.806 ns |   171.354 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     25.54 ns |     0.229 ns |     0.203 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    394.37 ns |     2.883 ns |     2.556 ns | 0.0097 |     - |     - |     192 B |
|       IQuantity_ToUnit |     36.53 ns |     0.398 ns |     0.353 ns | 0.0029 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,501.67 ns |    28.744 ns |    25.481 ns | 0.0478 |     - |     - |     944 B |
