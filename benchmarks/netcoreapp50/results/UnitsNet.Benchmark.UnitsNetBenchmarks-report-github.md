``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-ZTKCUQ : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|-------:|------:|----------:|
|            Constructor |      9.621 ns |   0.1416 ns |   0.1325 ns |      - |      - |     - |         - |
|         Constructor_SI |    325.596 ns |   6.4468 ns |   7.9172 ns | 0.0121 |      - |     - |     192 B |
|             FromMethod |     26.933 ns |   0.4649 ns |   0.4121 ns |      - |      - |     - |         - |
|             ToProperty |      8.455 ns |   0.1351 ns |   0.1264 ns |      - |      - |     - |         - |
|                     As |      8.453 ns |   0.0847 ns |   0.0661 ns |      - |      - |     - |         - |
|                  As_SI |    299.324 ns |   5.0757 ns |   6.0423 ns | 0.0119 |      - |     - |     192 B |
|                 ToUnit |     16.899 ns |   0.2349 ns |   0.2082 ns |      - |      - |     - |         - |
|              ToUnit_SI |    321.535 ns |   4.8438 ns |   4.5309 ns | 0.0118 |      - |     - |     192 B |
|           ToStringTest |  1,245.977 ns |  24.7623 ns |  50.5829 ns | 0.0584 |      - |     - |     944 B |
|                  Parse | 44,617.112 ns | 880.5381 ns | 780.5741 ns | 2.0873 | 0.0870 |     - |   33344 B |
|          TryParseValid | 45,948.077 ns | 903.5245 ns | 800.9509 ns | 2.0951 | 0.0911 |     - |   33321 B |
|        TryParseInvalid | 48,847.497 ns | 535.7908 ns | 474.9646 ns | 2.0359 | 0.0969 |     - |   32929 B |
|           QuantityFrom |  4,122.785 ns |  82.4146 ns | 214.2066 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     16.478 ns |   0.3653 ns |   0.3238 ns | 0.0015 |      - |     - |      24 B |
|        IQuantity_As_SI |    315.833 ns |   3.4009 ns |   2.8399 ns | 0.0119 |      - |     - |     192 B |
|       IQuantity_ToUnit |     25.417 ns |   0.3781 ns |   0.3157 ns | 0.0035 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,254.279 ns |  22.4047 ns |  26.6712 ns | 0.0595 |      - |     - |     944 B |
