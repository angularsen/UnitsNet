``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-PGCIYD : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.374 ns |     0.2052 ns |     0.1819 ns |      - |     - |     - |         - |
|         Constructor_SI |    410.365 ns |     8.2088 ns |    14.1598 ns | 0.0067 |     - |     - |     192 B |
|             FromMethod |     31.259 ns |     0.6642 ns |     1.2796 ns |      - |     - |     - |         - |
|             ToProperty |      8.812 ns |     0.2262 ns |     0.5333 ns |      - |     - |     - |         - |
|                     As |      9.516 ns |     0.2350 ns |     0.3371 ns |      - |     - |     - |         - |
|                  As_SI |    394.543 ns |     7.7716 ns |    13.4056 ns | 0.0066 |     - |     - |     192 B |
|                 ToUnit |     19.933 ns |     0.4332 ns |     0.8136 ns |      - |     - |     - |         - |
|              ToUnit_SI |    395.896 ns |     7.9275 ns |    20.3213 ns | 0.0066 |     - |     - |     192 B |
|           ToStringTest |  1,714.697 ns |    33.5495 ns |    52.2325 ns | 0.0337 |     - |     - |     944 B |
|                  Parse | 57,073.551 ns | 1,123.7592 ns | 2,604.4828 ns | 1.2696 |     - |     - |   33344 B |
|          TryParseValid | 56,442.366 ns | 1,108.8959 ns | 2,188.8523 ns | 1.2299 |     - |     - |   33320 B |
|        TryParseInvalid | 61,856.081 ns | 1,175.9988 ns | 1,996.9352 ns | 1.2396 |     - |     - |   32928 B |
|           QuantityFrom |  4,231.915 ns |    93.2613 ns |   266.0798 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     23.869 ns |     0.5228 ns |     0.9559 ns | 0.0009 |     - |     - |      24 B |
|        IQuantity_As_SI |    391.983 ns |     7.9053 ns |    17.3524 ns | 0.0067 |     - |     - |     192 B |
|       IQuantity_ToUnit |     36.659 ns |     1.2597 ns |     3.7143 ns | 0.0021 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,682.777 ns |    33.4196 ns |    92.0474 ns | 0.0340 |     - |     - |     944 B |
