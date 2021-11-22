``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-CKRFTN : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |      Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-----------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.09 ns |   0.126 ns |     0.118 ns |      - |      - |     - |         - |
|         Constructor_SI |    654.43 ns |  10.212 ns |     9.053 ns | 0.0279 |      - |     - |     201 B |
|             FromMethod |     35.99 ns |   0.440 ns |     0.411 ns |      - |      - |     - |         - |
|             ToProperty |     10.44 ns |   0.151 ns |     0.142 ns |      - |      - |     - |         - |
|                     As |     10.46 ns |   0.114 ns |     0.107 ns |      - |      - |     - |         - |
|                  As_SI |    627.11 ns |   5.385 ns |     5.037 ns | 0.0290 |      - |     - |     201 B |
|                 ToUnit |     22.92 ns |   0.470 ns |     0.462 ns |      - |      - |     - |         - |
|              ToUnit_SI |    654.23 ns |  12.862 ns |    13.209 ns | 0.0290 |      - |     - |     201 B |
|           ToStringTest |  2,237.47 ns |  31.106 ns |    29.097 ns | 0.1847 |      - |     - |    1220 B |
|                  Parse | 63,363.23 ns | 737.313 ns |   653.609 ns | 8.3155 | 0.2520 |     - |   54377 B |
|          TryParseValid | 63,151.26 ns | 961.243 ns |   899.147 ns | 8.3591 | 0.2572 |     - |   54353 B |
|        TryParseInvalid | 65,973.10 ns | 896.733 ns | 1,342.187 ns | 8.1890 | 0.2685 |     - |   53894 B |
|           QuantityFrom |  2,522.73 ns |  50.371 ns |   138.736 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     22.03 ns |   0.302 ns |     0.283 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    650.24 ns |   8.135 ns |     7.610 ns | 0.0285 |      - |     - |     201 B |
|       IQuantity_ToUnit |     35.08 ns |   0.420 ns |     0.393 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,227.39 ns |  27.446 ns |    25.673 ns | 0.1845 |      - |     - |    1220 B |
