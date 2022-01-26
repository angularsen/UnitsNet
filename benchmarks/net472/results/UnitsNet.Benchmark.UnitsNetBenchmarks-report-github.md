``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2452 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-GPTFLH : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     15.394 ns |     0.2418 ns |     0.2144 ns |     15.354 ns |      - |      - |     - |         - |
|         Constructor_SI |    661.879 ns |    12.8181 ns |    13.1632 ns |    662.239 ns | 0.0275 |      - |     - |     201 B |
|             FromMethod |     38.436 ns |     0.3948 ns |     0.3500 ns |     38.429 ns |      - |      - |     - |         - |
|             ToProperty |      9.814 ns |     0.1922 ns |     0.1605 ns |      9.845 ns |      - |      - |     - |         - |
|                     As |      9.830 ns |     0.1604 ns |     0.1422 ns |      9.792 ns |      - |      - |     - |         - |
|                  As_SI |    636.873 ns |     6.8314 ns |     6.0558 ns |    636.029 ns | 0.0268 |      - |     - |     201 B |
|                 ToUnit |     23.535 ns |     0.3035 ns |     0.2690 ns |     23.407 ns |      - |      - |     - |         - |
|              ToUnit_SI |    681.522 ns |     9.5139 ns |     8.8993 ns |    682.053 ns | 0.0268 |      - |     - |     201 B |
|           ToStringTest |  2,257.862 ns |    43.6218 ns |    42.8425 ns |  2,256.393 ns | 0.1785 |      - |     - |    1220 B |
|                  Parse | 73,485.040 ns | 1,343.1381 ns | 1,256.3722 ns | 73,531.765 ns | 8.0911 | 0.2997 |     - |   54376 B |
|          TryParseValid | 80,199.144 ns | 1,596.7194 ns | 2,754.2624 ns | 79,982.479 ns | 8.0891 | 0.3053 |     - |   54352 B |
|        TryParseInvalid | 86,825.316 ns | 1,605.8157 ns | 2,936.3248 ns | 86,944.348 ns | 7.8673 | 0.1710 |     - |   53895 B |
|           QuantityFrom |  2,921.591 ns |   118.2517 ns |   325.6996 ns |  2,800.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     25.204 ns |     0.5520 ns |     1.4830 ns |     24.930 ns | 0.0036 |      - |     - |      24 B |
|        IQuantity_As_SI |    658.232 ns |     9.8317 ns |     9.1966 ns |    656.858 ns | 0.0275 |      - |     - |     201 B |
|       IQuantity_ToUnit |     41.829 ns |     0.9793 ns |     2.8721 ns |     41.131 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,390.904 ns |    46.0708 ns |    49.2953 ns |  2,377.873 ns | 0.1775 |      - |     - |    1220 B |
