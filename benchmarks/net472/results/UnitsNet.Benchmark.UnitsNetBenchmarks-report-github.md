``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2452 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-LSQDKD : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.118 ns |   0.0434 ns |   0.0363 ns |     11.106 ns |      - |      - |     - |         - |
|         Constructor_SI |    462.582 ns |   4.0179 ns |   3.5617 ns |    463.176 ns | 0.0300 |      - |     - |     201 B |
|             FromMethod |     26.545 ns |   0.1060 ns |   0.0991 ns |     26.545 ns |      - |      - |     - |         - |
|             ToProperty |      7.536 ns |   0.0465 ns |   0.0435 ns |      7.530 ns |      - |      - |     - |         - |
|                     As |      7.533 ns |   0.0476 ns |   0.0446 ns |      7.520 ns |      - |      - |     - |         - |
|                  As_SI |    427.265 ns |   5.0220 ns |   4.6976 ns |    426.054 ns | 0.0299 |      - |     - |     201 B |
|                 ToUnit |     17.120 ns |   0.0859 ns |   0.0804 ns |     17.118 ns |      - |      - |     - |         - |
|              ToUnit_SI |    454.732 ns |   2.7526 ns |   2.5747 ns |    454.544 ns | 0.0297 |      - |     - |     201 B |
|           ToStringTest |  1,584.812 ns |  10.0447 ns |   9.3958 ns |  1,584.235 ns | 0.1857 |      - |     - |    1220 B |
|                  Parse | 47,796.999 ns | 307.0887 ns | 287.2510 ns | 47,838.256 ns | 8.4089 | 0.2834 |     - |   54377 B |
|          TryParseValid | 55,020.577 ns | 229.6944 ns | 203.6181 ns | 55,038.250 ns | 8.3572 | 0.3299 |     - |   54352 B |
|        TryParseInvalid | 58,744.380 ns | 275.6040 ns | 257.8002 ns | 58,756.181 ns | 8.2499 | 0.3536 |     - |   53895 B |
|           QuantityFrom |  2,216.484 ns |  88.9985 ns | 249.5613 ns |  2,100.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     19.114 ns |   0.1004 ns |   0.0890 ns |     19.119 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    454.329 ns |   1.0769 ns |   0.8992 ns |    454.332 ns | 0.0292 |      - |     - |     201 B |
|       IQuantity_ToUnit |     32.843 ns |   0.4197 ns |   0.3926 ns |     32.863 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,913.432 ns |  10.7142 ns |  10.0221 ns |  1,910.617 ns | 0.1828 |      - |     - |    1220 B |
