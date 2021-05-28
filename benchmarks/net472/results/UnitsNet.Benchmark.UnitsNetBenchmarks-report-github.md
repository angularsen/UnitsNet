``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.300
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-NFFPLU : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.055 ns |     0.2722 ns |     0.3443 ns |      - |      - |     - |         - |
|         Constructor_SI |    463.385 ns |     9.2261 ns |    15.1588 ns | 0.0293 |      - |     - |     201 B |
|             FromMethod |     28.452 ns |     0.6061 ns |     0.8092 ns |      - |      - |     - |         - |
|             ToProperty |      8.202 ns |     0.2026 ns |     0.3385 ns |      - |      - |     - |         - |
|                     As |      8.482 ns |     0.2079 ns |     0.2629 ns |      - |      - |     - |         - |
|                  As_SI |    461.615 ns |     9.2186 ns |    14.8863 ns | 0.0298 |      - |     - |     201 B |
|                 ToUnit |     18.490 ns |     0.4002 ns |     0.6686 ns |      - |      - |     - |         - |
|              ToUnit_SI |    480.006 ns |     9.3801 ns |    15.1471 ns | 0.0296 |      - |     - |     201 B |
|           ToStringTest |  1,718.715 ns |    34.3437 ns |    43.4338 ns | 0.1903 |      - |     - |    1244 B |
|                  Parse | 50,914.944 ns |   999.4316 ns | 1,433.3549 ns | 8.4531 | 0.2818 |     - |   54377 B |
|          TryParseValid | 50,660.774 ns |   997.3506 ns | 1,746.7791 ns | 8.4051 | 0.3038 |     - |   54352 B |
|        TryParseInvalid | 55,029.811 ns | 1,081.0462 ns | 1,806.1854 ns | 8.2645 | 0.3220 |     - |   53894 B |
|           QuantityFrom |  1,608.861 ns |    32.1250 ns |    83.4971 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     17.526 ns |     0.3728 ns |     0.4714 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    457.888 ns |     9.0926 ns |    14.4218 ns | 0.0298 |      - |     - |     201 B |
|       IQuantity_ToUnit |     26.376 ns |     0.5330 ns |     0.4725 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,787.433 ns |    35.2840 ns |    51.7189 ns | 0.1897 |      - |     - |    1244 B |
