``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-LDOEXY : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.26 ns |     0.252 ns |     0.210 ns |      - |      - |     - |         - |
|         Constructor_SI |    562.72 ns |    10.866 ns |    12.077 ns | 0.0294 |      - |     - |     201 B |
|             FromMethod |     35.11 ns |     0.471 ns |     0.440 ns |      - |      - |     - |         - |
|             ToProperty |     10.03 ns |     0.242 ns |     0.237 ns |      - |      - |     - |         - |
|                     As |     10.32 ns |     0.231 ns |     0.216 ns |      - |      - |     - |         - |
|                  As_SI |    554.22 ns |     8.958 ns |     8.380 ns | 0.0294 |      - |     - |     201 B |
|                 ToUnit |     22.29 ns |     0.277 ns |     0.231 ns |      - |      - |     - |         - |
|              ToUnit_SI |    567.85 ns |     8.204 ns |     7.674 ns | 0.0291 |      - |     - |     201 B |
|           ToStringTest |  2,270.90 ns |    36.446 ns |    34.092 ns | 0.1821 |      - |     - |    1220 B |
|                  Parse | 65,838.55 ns | 1,254.022 ns | 1,341.789 ns | 8.3455 | 0.2649 |     - |   54377 B |
|          TryParseValid | 63,534.62 ns | 1,043.864 ns |   925.358 ns | 8.2504 | 0.2619 |     - |   54353 B |
|        TryParseInvalid | 67,043.62 ns |   662.508 ns |   553.224 ns | 8.2744 | 0.2669 |     - |   53895 B |
|           QuantityFrom |  2,578.95 ns |    51.236 ns |   111.382 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     20.62 ns |     0.444 ns |     0.545 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    569.99 ns |    11.327 ns |    10.595 ns | 0.0296 |      - |     - |     201 B |
|       IQuantity_ToUnit |     32.54 ns |     0.734 ns |     0.786 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,277.85 ns |    45.393 ns |    40.239 ns | 0.1832 |      - |     - |    1220 B |
