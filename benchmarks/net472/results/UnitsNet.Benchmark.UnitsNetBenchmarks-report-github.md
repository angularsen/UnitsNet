``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-HOETJB : .NET Framework 4.8 (4.8.4390.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |      Error |     StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------:|-------:|------:|----------:|
|            Constructor |     15.29 ns |   0.295 ns |   0.276 ns |      - |      - |     - |         - |
|         Constructor_SI |    573.39 ns |   4.744 ns |   3.962 ns | 0.0286 |      - |     - |     201 B |
|             FromMethod |     35.59 ns |   0.393 ns |   0.368 ns |      - |      - |     - |         - |
|             ToProperty |     10.52 ns |   0.115 ns |   0.107 ns |      - |      - |     - |         - |
|                     As |     10.47 ns |   0.115 ns |   0.108 ns |      - |      - |     - |         - |
|                  As_SI |    569.41 ns |   4.477 ns |   4.187 ns | 0.0286 |      - |     - |     201 B |
|                 ToUnit |     23.32 ns |   0.222 ns |   0.207 ns |      - |      - |     - |         - |
|              ToUnit_SI |    585.57 ns |   5.995 ns |   5.608 ns | 0.0294 |      - |     - |     201 B |
|           ToStringTest |  2,103.53 ns |  21.618 ns |  20.221 ns | 0.1868 |      - |     - |    1244 B |
|                  Parse | 62,448.75 ns | 696.697 ns | 651.691 ns | 8.3844 | 0.2503 |     - |   54377 B |
|          TryParseValid | 61,856.61 ns | 657.020 ns | 614.577 ns | 8.3395 | 0.2453 |     - |   54353 B |
|        TryParseInvalid | 66,251.50 ns | 574.201 ns | 537.108 ns | 8.1956 | 0.2644 |     - |   53895 B |
|           QuantityFrom |  2,201.54 ns |  43.768 ns | 102.305 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     21.88 ns |   0.261 ns |   0.244 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    575.81 ns |   6.571 ns |   5.825 ns | 0.0286 |      - |     - |     201 B |
|       IQuantity_ToUnit |     32.86 ns |   0.300 ns |   0.281 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,144.80 ns |  28.068 ns |  26.255 ns | 0.1873 |      - |     - |    1244 B |
