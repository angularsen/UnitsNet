``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-JPPDRU : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |       Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|            Constructor |     11.93 ns |     0.186 ns |     0.174 ns |     11.89 ns |      - |     - |     - |         - |
|         Constructor_SI |    405.79 ns |     7.765 ns |     8.631 ns |    406.06 ns | 0.0096 |     - |     - |     192 B |
|             FromMethod |     30.69 ns |     0.533 ns |     0.499 ns |     30.83 ns |      - |     - |     - |         - |
|             ToProperty |     10.81 ns |     0.210 ns |     0.196 ns |     10.82 ns |      - |     - |     - |         - |
|                     As |     10.48 ns |     0.257 ns |     0.253 ns |     10.42 ns |      - |     - |     - |         - |
|                  As_SI |    387.21 ns |     7.790 ns |     9.274 ns |    385.18 ns | 0.0100 |     - |     - |     192 B |
|                 ToUnit |     20.25 ns |     0.295 ns |     0.276 ns |     20.19 ns |      - |     - |     - |         - |
|              ToUnit_SI |    405.26 ns |     4.668 ns |     4.366 ns |    404.03 ns | 0.0099 |     - |     - |     192 B |
|           ToStringTest |  1,598.72 ns |    26.342 ns |    24.640 ns |  1,587.75 ns | 0.0483 |     - |     - |     944 B |
|                  Parse | 54,702.33 ns | 1,065.907 ns | 1,140.509 ns | 54,395.85 ns | 1.7740 |     - |     - |   33344 B |
|          TryParseValid | 56,151.02 ns | 1,094.737 ns | 1,604.652 ns | 55,617.11 ns | 1.7504 |     - |     - |   33320 B |
|        TryParseInvalid | 57,059.77 ns |   817.637 ns |   682.764 ns | 56,968.59 ns | 1.7015 |     - |     - |   32928 B |
|           QuantityFrom |  3,580.00 ns |    99.151 ns |   268.062 ns |  3,500.00 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     26.42 ns |     0.555 ns |     0.519 ns |     26.42 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    398.48 ns |     7.014 ns |     6.561 ns |    398.44 ns | 0.0095 |     - |     - |     192 B |
|       IQuantity_ToUnit |     39.59 ns |     0.650 ns |     0.576 ns |     39.40 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,656.55 ns |    32.108 ns |    32.973 ns |  1,653.82 ns | 0.0480 |     - |     - |     944 B |
