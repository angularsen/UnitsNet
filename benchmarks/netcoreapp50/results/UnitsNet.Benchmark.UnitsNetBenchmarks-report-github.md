``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-UEUVXJ : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|------:|------:|----------:|
|            Constructor |     11.647 ns |     0.2778 ns |     0.3803 ns |      - |     - |     - |         - |
|         Constructor_SI |    393.553 ns |     7.7807 ns |    12.9999 ns | 0.0071 |     - |     - |     192 B |
|             FromMethod |     31.064 ns |     0.6093 ns |     0.7483 ns |      - |     - |     - |         - |
|             ToProperty |      9.358 ns |     0.2183 ns |     0.2042 ns |      - |     - |     - |         - |
|                     As |      9.300 ns |     0.2248 ns |     0.2208 ns |      - |     - |     - |         - |
|                  As_SI |    389.418 ns |     7.7398 ns |    11.5846 ns | 0.0069 |     - |     - |     192 B |
|                 ToUnit |     19.776 ns |     0.2432 ns |     0.2156 ns |      - |     - |     - |         - |
|              ToUnit_SI |    409.444 ns |     8.0899 ns |    10.5191 ns | 0.0072 |     - |     - |     192 B |
|           ToStringTest |  1,540.484 ns |    30.3721 ns |    57.7860 ns | 0.0346 |     - |     - |     944 B |
|                  Parse | 54,785.851 ns | 1,058.1267 ns | 1,448.3758 ns | 1.2400 |     - |     - |   33344 B |
|          TryParseValid | 56,808.964 ns | 1,117.9759 ns | 1,805.3227 ns | 1.2556 |     - |     - |   33320 B |
|        TryParseInvalid | 60,123.197 ns | 1,184.3373 ns | 1,772.6603 ns | 1.1975 |     - |     - |   32928 B |
|           QuantityFrom |  4,298.718 ns |    85.4911 ns |   220.6799 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     20.622 ns |     0.4175 ns |     0.3486 ns | 0.0009 |     - |     - |      24 B |
|        IQuantity_As_SI |    391.085 ns |     7.8424 ns |     8.0535 ns | 0.0070 |     - |     - |     192 B |
|       IQuantity_ToUnit |     34.783 ns |     0.8121 ns |     2.3302 ns | 0.0021 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,582.084 ns |    31.2339 ns |    53.0375 ns | 0.0358 |     - |     - |     944 B |
