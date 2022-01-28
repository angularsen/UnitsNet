``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-DLPHHG : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.721 ns |     0.2670 ns |     0.5514 ns |     11.539 ns |      - |      - |     - |         - |
|         Constructor_SI |    456.662 ns |     8.0528 ns |    11.5491 ns |    452.391 ns | 0.0300 |      - |     - |     201 B |
|             FromMethod |     27.529 ns |     0.5834 ns |     1.4201 ns |     26.950 ns |      - |      - |     - |         - |
|             ToProperty |      7.927 ns |     0.1934 ns |     0.4205 ns |      7.869 ns |      - |      - |     - |         - |
|                     As |      7.535 ns |     0.0687 ns |     0.0642 ns |      7.537 ns |      - |      - |     - |         - |
|                  As_SI |    449.929 ns |     8.9101 ns |     7.4404 ns |    449.219 ns | 0.0301 |      - |     - |     201 B |
|                 ToUnit |     17.673 ns |     0.3841 ns |     0.5385 ns |     17.463 ns |      - |      - |     - |         - |
|              ToUnit_SI |    487.728 ns |     9.7265 ns |    22.9266 ns |    482.559 ns | 0.0291 |      - |     - |     201 B |
|           ToStringTest |  1,715.806 ns |    34.2990 ns |   100.5931 ns |  1,706.999 ns | 0.1855 |      - |     - |    1220 B |
|                  Parse | 49,033.686 ns |   965.4169 ns | 1,690.8498 ns | 48,476.085 ns | 8.4099 | 0.2900 |     - |   54377 B |
|          TryParseValid | 51,141.767 ns | 1,012.3008 ns | 2,405.8400 ns | 50,500.820 ns | 8.3880 | 0.2892 |     - |   54352 B |
|        TryParseInvalid | 55,074.923 ns | 1,085.7917 ns | 2,450.8128 ns | 53,946.317 ns | 8.2690 | 0.3264 |     - |   53895 B |
|           QuantityFrom |  2,065.385 ns |    40.5521 ns |    83.7471 ns |  2,100.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     17.715 ns |     0.3876 ns |     0.5433 ns |     17.468 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    473.452 ns |     9.4371 ns |    20.1113 ns |    467.353 ns | 0.0301 |      - |     - |     201 B |
|       IQuantity_ToUnit |     26.388 ns |     0.6007 ns |     0.5619 ns |     26.177 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,649.482 ns |    31.9673 ns |    44.8137 ns |  1,628.706 ns | 0.1861 |      - |     - |    1220 B |
