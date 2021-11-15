``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-GGPNIN : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|            Constructor |     11.71 ns |     0.192 ns |     0.180 ns |      - |     - |     - |         - |
|         Constructor_SI |    396.86 ns |     7.946 ns |     8.160 ns | 0.0096 |     - |     - |     192 B |
|             FromMethod |     30.30 ns |     0.574 ns |     0.537 ns |      - |     - |     - |         - |
|             ToProperty |     10.03 ns |     0.124 ns |     0.110 ns |      - |     - |     - |         - |
|                     As |     11.27 ns |     0.252 ns |     0.236 ns |      - |     - |     - |         - |
|                  As_SI |    399.00 ns |     7.838 ns |     9.912 ns | 0.0098 |     - |     - |     192 B |
|                 ToUnit |     20.00 ns |     0.251 ns |     0.235 ns |      - |     - |     - |         - |
|              ToUnit_SI |    416.81 ns |     8.075 ns |     6.743 ns | 0.0099 |     - |     - |     192 B |
|           ToStringTest |  1,618.97 ns |    32.085 ns |    28.443 ns | 0.0487 |     - |     - |     944 B |
|                  Parse | 56,057.36 ns |   819.208 ns |   766.288 ns | 1.7817 |     - |     - |   33344 B |
|          TryParseValid | 53,811.77 ns | 1,053.676 ns | 1,294.008 ns | 1.6895 |     - |     - |   33320 B |
|        TryParseInvalid | 59,205.83 ns | 1,087.278 ns | 1,017.040 ns | 1.7045 |     - |     - |   32928 B |
|           QuantityFrom |  4,265.52 ns |    85.146 ns |   186.897 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     25.01 ns |     0.469 ns |     0.439 ns | 0.0012 |     - |     - |      24 B |
|        IQuantity_As_SI |    400.75 ns |     4.267 ns |     3.992 ns | 0.0099 |     - |     - |     192 B |
|       IQuantity_ToUnit |     36.08 ns |     0.688 ns |     0.644 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,617.13 ns |    30.383 ns |    26.934 ns | 0.0476 |     - |     - |     944 B |
