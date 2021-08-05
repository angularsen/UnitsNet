``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2061 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.302
  [Host]     : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT
  Job-ANPCHL : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.654 ns |   0.0443 ns |   0.0414 ns |     12.661 ns |      - |      - |     - |         - |
|         Constructor_SI |    485.442 ns |   3.2709 ns |   3.0596 ns |    485.313 ns | 0.0290 |      - |     - |     201 B |
|             FromMethod |     29.774 ns |   0.0773 ns |   0.0723 ns |     29.744 ns |      - |      - |     - |         - |
|             ToProperty |      8.725 ns |   0.0369 ns |   0.0345 ns |      8.724 ns |      - |      - |     - |         - |
|                     As |      8.706 ns |   0.0215 ns |   0.0201 ns |      8.715 ns |      - |      - |     - |         - |
|                  As_SI |    482.648 ns |   2.4040 ns |   2.2487 ns |    482.613 ns | 0.0298 |      - |     - |     201 B |
|                 ToUnit |     19.389 ns |   0.0486 ns |   0.0455 ns |     19.399 ns |      - |      - |     - |         - |
|              ToUnit_SI |    486.821 ns |   2.2766 ns |   2.0182 ns |    486.585 ns | 0.0293 |      - |     - |     201 B |
|           ToStringTest |  1,819.026 ns |  10.3587 ns |   9.6895 ns |  1,818.390 ns | 0.1873 |      - |     - |    1244 B |
|                  Parse | 51,618.430 ns | 210.2665 ns | 196.6834 ns | 51,576.442 ns | 8.3991 | 0.3073 |     - |   54377 B |
|          TryParseValid | 51,577.707 ns | 242.9930 ns | 227.2958 ns | 51,541.180 ns | 8.3514 | 0.3093 |     - |   54353 B |
|        TryParseInvalid | 55,751.825 ns | 237.2064 ns | 221.8830 ns | 55,678.420 ns | 8.2442 | 0.3342 |     - |   53895 B |
|           QuantityFrom |  1,754.545 ns |  34.7629 ns |  74.0825 ns |  1,800.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     18.691 ns |   0.0804 ns |   0.0712 ns |     18.709 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    480.527 ns |   2.9429 ns |   2.7528 ns |    480.734 ns | 0.0297 |      - |     - |     201 B |
|       IQuantity_ToUnit |     28.266 ns |   0.1095 ns |   0.0971 ns |     28.267 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,858.012 ns |   4.6856 ns |   4.3829 ns |  1,856.506 ns | 0.1893 |      - |     - |    1244 B |
