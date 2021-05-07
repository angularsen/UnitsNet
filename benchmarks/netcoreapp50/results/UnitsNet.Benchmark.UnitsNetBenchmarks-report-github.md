``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-UTFZOC : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.173 ns |   0.1985 ns |     0.1857 ns |      - |     - |     - |         - |
|         Constructor_SI |    371.428 ns |   3.9595 ns |     3.7037 ns | 0.0096 |     - |     - |     192 B |
|             FromMethod |     28.599 ns |   0.3523 ns |     0.2942 ns |      - |     - |     - |         - |
|             ToProperty |      9.865 ns |   0.1573 ns |     0.1472 ns |      - |     - |     - |         - |
|                     As |      9.915 ns |   0.1854 ns |     0.1734 ns |      - |     - |     - |         - |
|                  As_SI |    361.399 ns |   6.1549 ns |     5.7573 ns | 0.0097 |     - |     - |     192 B |
|                 ToUnit |     18.915 ns |   0.2751 ns |     0.2438 ns |      - |     - |     - |         - |
|              ToUnit_SI |    377.415 ns |   4.6523 ns |     4.3517 ns | 0.0099 |     - |     - |     192 B |
|           ToStringTest |  1,519.498 ns |  30.3312 ns |    48.1084 ns | 0.0491 |     - |     - |     944 B |
|                  Parse | 47,313.217 ns | 815.2533 ns |   762.5885 ns | 1.7673 |     - |     - |   33344 B |
|          TryParseValid | 47,997.515 ns | 941.9108 ns | 1,121.2778 ns | 1.7200 |     - |     - |   33320 B |
|        TryParseInvalid | 51,234.256 ns | 965.3221 ns |   948.0754 ns | 1.7189 |     - |     - |   32929 B |
|           QuantityFrom |  2,711.111 ns |  95.3130 ns |   279.5364 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     21.476 ns |   0.3201 ns |     0.2837 ns | 0.0012 |     - |     - |      24 B |
|        IQuantity_As_SI |    347.194 ns |   7.0059 ns |    11.1121 ns | 0.0100 |     - |     - |     192 B |
|       IQuantity_ToUnit |     28.557 ns |   0.6595 ns |     1.3018 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,398.809 ns |  27.8687 ns |    45.7891 ns | 0.0491 |     - |     - |     944 B |
