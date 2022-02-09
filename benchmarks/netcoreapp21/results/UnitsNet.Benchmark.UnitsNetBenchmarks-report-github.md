``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-BSTWZI : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.04 ns |     0.275 ns |     0.243 ns |      - |      - |     - |         - |
|         Constructor_SI |    672.02 ns |     9.052 ns |     8.467 ns | 0.0274 |      - |     - |     192 B |
|             FromMethod |     32.98 ns |     0.536 ns |     0.502 ns |      - |      - |     - |         - |
|             ToProperty |    240.74 ns |     4.861 ns |     7.126 ns | 0.0167 |      - |     - |     112 B |
|                     As |    240.22 ns |     3.433 ns |     3.211 ns | 0.0164 |      - |     - |     112 B |
|                  As_SI |    670.68 ns |     7.124 ns |     5.949 ns | 0.0268 |      - |     - |     192 B |
|                 ToUnit |    247.32 ns |     2.413 ns |     2.257 ns | 0.0165 |      - |     - |     112 B |
|              ToUnit_SI |    698.54 ns |     8.130 ns |     7.604 ns | 0.0277 |      - |     - |     192 B |
|           ToStringTest |  2,853.30 ns |    39.021 ns |    36.500 ns | 0.1391 |      - |     - |     952 B |
|                  Parse | 81,570.28 ns |   922.276 ns |   817.574 ns | 6.7982 | 0.1658 |     - |   45624 B |
|          TryParseValid | 81,317.63 ns | 1,493.308 ns | 1,597.823 ns | 6.8785 | 0.1638 |     - |   45600 B |
|        TryParseInvalid | 84,711.34 ns | 1,643.019 ns | 1,955.897 ns | 6.6920 | 0.1809 |     - |   45200 B |
|           QuantityFrom |    108.82 ns |     1.158 ns |     1.083 ns | 0.0084 |      - |     - |      56 B |
|           IQuantity_As |    240.16 ns |     2.739 ns |     2.428 ns | 0.0203 |      - |     - |     136 B |
|        IQuantity_As_SI |    648.00 ns |     8.736 ns |     8.172 ns | 0.0270 |      - |     - |     192 B |
|       IQuantity_ToUnit |    244.92 ns |     4.740 ns |     5.459 ns | 0.0257 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,713.44 ns |    50.194 ns |    46.951 ns | 0.1366 |      - |     - |     952 B |
