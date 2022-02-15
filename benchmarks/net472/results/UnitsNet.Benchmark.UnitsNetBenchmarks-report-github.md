``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.20348
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-SKDAJB : .NET Framework 4.8 (4.8.4470.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.76 ns |     0.345 ns |     0.323 ns |      - |      - |     - |         - |
|         Constructor_SI |    651.79 ns |    11.935 ns |    10.580 ns | 0.0293 |      - |     - |     201 B |
|             FromMethod |     36.17 ns |     0.763 ns |     0.816 ns |      - |      - |     - |         - |
|             ToProperty |    283.68 ns |     5.514 ns |     6.129 ns | 0.0167 |      - |     - |     112 B |
|                     As |    284.74 ns |     3.822 ns |     3.388 ns | 0.0167 |      - |     - |     112 B |
|                  As_SI |    639.94 ns |    12.715 ns |    13.057 ns | 0.0290 |      - |     - |     201 B |
|                 ToUnit |    277.02 ns |     5.457 ns |     4.838 ns | 0.0163 |      - |     - |     112 B |
|              ToUnit_SI |    643.39 ns |    10.471 ns |     9.795 ns | 0.0291 |      - |     - |     201 B |
|           ToStringTest |  2,298.19 ns |    12.509 ns |     9.766 ns | 0.1846 |      - |     - |    1220 B |
|                  Parse | 74,372.29 ns | 1,453.413 ns | 1,889.848 ns | 8.7602 | 0.2970 |     - |   57393 B |
|          TryParseValid | 74,012.66 ns | 1,480.238 ns | 2,215.550 ns | 8.8168 | 0.2844 |     - |   57370 B |
|        TryParseInvalid | 77,641.61 ns | 1,391.517 ns | 1,301.626 ns | 8.6038 | 0.3019 |     - |   56912 B |
|           QuantityFrom |    114.89 ns |     1.758 ns |     1.558 ns | 0.0082 |      - |     - |      56 B |
|           IQuantity_As |    309.62 ns |     5.785 ns |     5.411 ns | 0.0200 |      - |     - |     136 B |
|        IQuantity_As_SI |    626.35 ns |    11.583 ns |    10.835 ns | 0.0287 |      - |     - |     201 B |
|       IQuantity_ToUnit |    307.20 ns |     6.160 ns |     9.029 ns | 0.0253 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,335.39 ns |    36.574 ns |    32.422 ns | 0.1813 |      - |     - |    1220 B |
