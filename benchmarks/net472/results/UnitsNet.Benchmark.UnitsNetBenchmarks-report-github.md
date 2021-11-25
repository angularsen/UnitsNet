``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-KBAUEE : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.80 ns |     0.274 ns |     0.256 ns |      - |      - |     - |         - |
|         Constructor_SI |    640.26 ns |     9.622 ns |     9.001 ns | 0.0288 |      - |     - |     201 B |
|             FromMethod |     37.17 ns |     0.394 ns |     0.350 ns |      - |      - |     - |         - |
|             ToProperty |     11.04 ns |     0.212 ns |     0.188 ns |      - |      - |     - |         - |
|                     As |     11.08 ns |     0.235 ns |     0.220 ns |      - |      - |     - |         - |
|                  As_SI |    607.65 ns |    11.995 ns |    20.040 ns | 0.0284 |      - |     - |     201 B |
|                 ToUnit |     24.37 ns |     0.425 ns |     0.377 ns |      - |      - |     - |         - |
|              ToUnit_SI |    636.24 ns |    12.573 ns |    12.911 ns | 0.0291 |      - |     - |     201 B |
|           ToStringTest |  2,235.82 ns |    41.439 ns |    49.330 ns | 0.1816 |      - |     - |    1220 B |
|                  Parse | 68,250.21 ns | 1,265.080 ns | 1,183.356 ns | 8.3026 | 0.2636 |     - |   54377 B |
|          TryParseValid | 66,486.12 ns | 1,319.557 ns | 2,015.103 ns | 8.3146 | 0.2640 |     - |   54352 B |
|        TryParseInvalid | 72,999.89 ns | 1,435.587 ns | 1,653.224 ns | 8.2892 | 0.2718 |     - |   53894 B |
|           QuantityFrom |  2,594.38 ns |    51.716 ns |   143.305 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     22.71 ns |     0.495 ns |     0.725 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    624.32 ns |    12.332 ns |    13.707 ns | 0.0283 |      - |     - |     201 B |
|       IQuantity_ToUnit |     36.88 ns |     0.838 ns |     1.254 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,271.93 ns |    44.677 ns |    69.557 ns | 0.1843 |      - |     - |    1220 B |
