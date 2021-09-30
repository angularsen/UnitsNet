``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.401
  [Host]     : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT
  Job-AKYQJB : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.929 ns |     0.2246 ns |     0.2101 ns |     11.957 ns |      - |      - |     - |         - |
|         Constructor_SI |    578.995 ns |    11.5735 ns |    10.2596 ns |    577.773 ns | 0.0263 |      - |     - |     192 B |
|             FromMethod |     30.668 ns |     0.5718 ns |     0.5069 ns |     30.641 ns |      - |      - |     - |         - |
|             ToProperty |      8.889 ns |     0.1958 ns |     0.1832 ns |      8.944 ns |      - |      - |     - |         - |
|                     As |      8.998 ns |     0.1998 ns |     0.1869 ns |      9.032 ns |      - |      - |     - |         - |
|                  As_SI |    569.917 ns |    11.1061 ns |    10.3887 ns |    569.320 ns | 0.0267 |      - |     - |     192 B |
|                 ToUnit |     19.197 ns |     0.3818 ns |     0.3571 ns |     19.166 ns |      - |      - |     - |         - |
|              ToUnit_SI |    583.936 ns |     8.1861 ns |     7.2568 ns |    581.148 ns | 0.0263 |      - |     - |     192 B |
|           ToStringTest |  2,160.826 ns |    28.8637 ns |    25.5869 ns |  2,150.875 ns | 0.1337 |      - |     - |     952 B |
|                  Parse | 76,525.092 ns | 1,506.5249 ns | 1,958.9080 ns | 76,314.764 ns | 6.6017 | 0.1500 |     - |   44816 B |
|          TryParseValid | 78,002.433 ns | 1,439.7493 ns | 1,346.7424 ns | 77,933.081 ns | 6.5161 | 0.1515 |     - |   44792 B |
|        TryParseInvalid | 78,659.051 ns | 1,399.6034 ns | 1,611.7853 ns | 78,173.537 ns | 6.4845 | 0.1544 |     - |   44392 B |
|           QuantityFrom |  2,268.889 ns |    53.4104 ns |   148.8868 ns |  2,200.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     20.424 ns |     0.4167 ns |     0.3694 ns |     20.394 ns | 0.0036 |      - |     - |      24 B |
|        IQuantity_As_SI |    574.361 ns |     9.3316 ns |    16.8269 ns |    569.946 ns | 0.0264 |      - |     - |     192 B |
|       IQuantity_ToUnit |     31.311 ns |     0.7317 ns |     0.6845 ns |     31.370 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,194.019 ns |    42.3961 ns |    39.6574 ns |  2,170.143 ns | 0.1354 |      - |     - |     952 B |
