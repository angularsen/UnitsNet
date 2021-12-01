``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-CXITLR : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.094 ns |     0.2668 ns |     0.3740 ns |      - |     - |     - |         - |
|         Constructor_SI |    414.162 ns |     8.3015 ns |    14.7558 ns | 0.0069 |     - |     - |     192 B |
|             FromMethod |     31.041 ns |     0.5867 ns |     0.6757 ns |      - |     - |     - |         - |
|             ToProperty |      8.749 ns |     0.2069 ns |     0.1935 ns |      - |     - |     - |         - |
|                     As |      9.072 ns |     0.1869 ns |     0.1657 ns |      - |     - |     - |         - |
|                  As_SI |    374.871 ns |     7.2300 ns |     8.3261 ns | 0.0072 |     - |     - |     192 B |
|                 ToUnit |     19.591 ns |     0.4270 ns |     0.4385 ns |      - |     - |     - |         - |
|              ToUnit_SI |    392.593 ns |     7.8889 ns |    15.1991 ns | 0.0069 |     - |     - |     192 B |
|           ToStringTest |  1,630.988 ns |    27.6693 ns |    25.8819 ns | 0.0340 |     - |     - |     944 B |
|                  Parse | 55,384.665 ns | 1,066.1189 ns | 1,839.0027 ns | 1.2071 |     - |     - |   33344 B |
|          TryParseValid | 55,990.725 ns | 1,077.7379 ns | 1,401.3637 ns | 1.2176 |     - |     - |   33320 B |
|        TryParseInvalid | 61,543.953 ns | 1,217.0211 ns | 2,285.8607 ns | 1.1646 |     - |     - |   32928 B |
|           QuantityFrom |  4,279.570 ns |   108.7190 ns |   308.4178 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     22.795 ns |     0.5054 ns |     1.2586 ns | 0.0009 |     - |     - |      24 B |
|        IQuantity_As_SI |    364.292 ns |     7.2986 ns |    19.2274 ns | 0.0071 |     - |     - |     192 B |
|       IQuantity_ToUnit |     34.038 ns |     1.1054 ns |     3.2592 ns | 0.0021 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,646.512 ns |    32.9125 ns |    88.9809 ns | 0.0359 |     - |     - |     944 B |
