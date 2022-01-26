``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2452 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-OISAZA : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |      8.547 ns |   0.1620 ns |     0.2963 ns |      8.411 ns |      - |      - |     - |         - |
|         Constructor_SI |    281.993 ns |   2.0757 ns |     1.6206 ns |    281.733 ns | 0.0101 |      - |     - |     192 B |
|             FromMethod |     21.521 ns |   0.1496 ns |     0.1168 ns |     21.497 ns |      - |      - |     - |         - |
|             ToProperty |      7.775 ns |   0.1143 ns |     0.0954 ns |      7.740 ns |      - |      - |     - |         - |
|                     As |      7.497 ns |   0.0763 ns |     0.0596 ns |      7.486 ns |      - |      - |     - |         - |
|                  As_SI |    279.614 ns |   5.2857 ns |     5.1912 ns |    278.424 ns | 0.0098 |      - |     - |     192 B |
|                 ToUnit |     14.365 ns |   0.0634 ns |     0.0529 ns |     14.372 ns |      - |      - |     - |         - |
|              ToUnit_SI |    287.846 ns |   2.8485 ns |     2.3787 ns |    287.518 ns | 0.0099 |      - |     - |     192 B |
|           ToStringTest |  1,104.806 ns |  18.2155 ns |    17.0388 ns |  1,102.754 ns | 0.0489 |      - |     - |     944 B |
|                  Parse | 38,948.944 ns | 764.9159 ns | 1,256.7787 ns | 38,583.105 ns | 1.7287 |      - |     - |   33344 B |
|          TryParseValid | 38,619.524 ns | 623.2930 ns |   552.5330 ns | 38,522.246 ns | 1.7592 | 0.0765 |     - |   33320 B |
|        TryParseInvalid | 40,834.602 ns | 346.9022 ns |   324.4926 ns | 40,789.616 ns | 1.7104 |      - |     - |   32928 B |
|           QuantityFrom |  3,287.097 ns |  65.3116 ns |   148.7476 ns |  3,300.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     16.728 ns |   0.3651 ns |     0.3586 ns |     16.650 ns | 0.0013 |      - |     - |      24 B |
|        IQuantity_As_SI |    286.822 ns |   5.1670 ns |     6.7186 ns |    285.139 ns | 0.0102 |      - |     - |     192 B |
|       IQuantity_ToUnit |     23.838 ns |   0.4473 ns |     0.4184 ns |     23.806 ns | 0.0030 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,126.191 ns |  15.9321 ns |    14.9029 ns |  1,124.942 ns | 0.0497 |      - |     - |     944 B |
