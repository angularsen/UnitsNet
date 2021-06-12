``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-UEKCCC : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.372 ns |     0.2390 ns |     0.2235 ns |      - |     - |     - |         - |
|         Constructor_SI |    388.651 ns |     7.8197 ns |    14.2988 ns | 0.0098 |     - |     - |     192 B |
|             FromMethod |     30.756 ns |     0.4071 ns |     0.3808 ns |      - |     - |     - |         - |
|             ToProperty |      9.763 ns |     0.1584 ns |     0.1482 ns |      - |     - |     - |         - |
|                     As |     10.137 ns |     0.1992 ns |     0.1663 ns |      - |     - |     - |         - |
|                  As_SI |    388.891 ns |     7.0191 ns |     6.2223 ns | 0.0096 |     - |     - |     192 B |
|                 ToUnit |     20.121 ns |     0.2452 ns |     0.2293 ns |      - |     - |     - |         - |
|              ToUnit_SI |    403.535 ns |     6.0201 ns |     5.6312 ns | 0.0097 |     - |     - |     192 B |
|           ToStringTest |  1,620.868 ns |    28.7572 ns |    28.2434 ns | 0.0485 |     - |     - |     944 B |
|                  Parse | 53,630.760 ns | 1,010.5409 ns | 1,081.2674 ns | 1.6965 |     - |     - |   33344 B |
|          TryParseValid | 54,644.361 ns |   894.1153 ns |   836.3560 ns | 1.7264 |     - |     - |   33320 B |
|        TryParseInvalid | 56,918.383 ns | 1,043.3802 ns |   975.9785 ns | 1.7222 |     - |     - |   32928 B |
|           QuantityFrom |  3,470.909 ns |    68.5809 ns |   146.1515 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     26.006 ns |     0.5651 ns |     0.5803 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    390.157 ns |     4.1203 ns |     3.8542 ns | 0.0102 |     - |     - |     192 B |
|       IQuantity_ToUnit |     36.766 ns |     0.8473 ns |     1.0716 ns | 0.0029 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,599.864 ns |    24.0596 ns |    21.3282 ns | 0.0483 |     - |     - |     944 B |
