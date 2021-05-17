``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-RRPWJQ : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.724 ns |     0.3373 ns |     0.3313 ns |      - |      - |     - |         - |
|         Constructor_SI |    549.247 ns |     7.5089 ns |     6.2703 ns | 0.0292 |      - |     - |     201 B |
|             FromMethod |     33.547 ns |     0.4232 ns |     0.3751 ns |      - |      - |     - |         - |
|             ToProperty |     10.092 ns |     0.1982 ns |     0.1854 ns |      - |      - |     - |         - |
|                     As |      9.900 ns |     0.1787 ns |     0.1584 ns |      - |      - |     - |         - |
|                  As_SI |    559.384 ns |     9.5261 ns |     8.9107 ns | 0.0290 |      - |     - |     201 B |
|                 ToUnit |     22.208 ns |     0.2671 ns |     0.2498 ns |      - |      - |     - |         - |
|              ToUnit_SI |    563.000 ns |    11.1394 ns |    10.4198 ns | 0.0291 |      - |     - |     201 B |
|           ToStringTest |  2,100.525 ns |    41.3882 ns |    38.7145 ns | 0.1864 |      - |     - |    1244 B |
|                  Parse | 57,730.125 ns |   726.4445 ns |   606.6141 ns | 8.3927 | 0.3449 |     - |   54377 B |
|          TryParseValid | 61,640.218 ns | 1,229.8227 ns | 2,054.7575 ns | 8.4073 | 0.3503 |     - |   54352 B |
|        TryParseInvalid | 64,102.558 ns |   846.7874 ns |   792.0855 ns | 8.2130 | 0.2649 |     - |   53894 B |
|           QuantityFrom |  2,115.190 ns |    42.2763 ns |   109.8818 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     21.998 ns |     0.4498 ns |     0.3987 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    562.041 ns |     9.3529 ns |     8.2911 ns | 0.0292 |      - |     - |     201 B |
|       IQuantity_ToUnit |     33.306 ns |     0.7493 ns |     0.7009 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,140.635 ns |    41.6732 ns |    38.9811 ns | 0.1875 |      - |     - |    1244 B |
