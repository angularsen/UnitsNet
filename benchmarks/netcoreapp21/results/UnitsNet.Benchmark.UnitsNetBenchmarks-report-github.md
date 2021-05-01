``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-UPAIGI : .NET Core 2.1.27 (CoreCLR 4.6.29916.01, CoreFX 4.6.29916.03), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.939 ns |     0.2681 ns |     0.2633 ns |     11.861 ns |      - |      - |     - |         - |
|         Constructor_SI |    558.517 ns |    11.1889 ns |    11.4902 ns |    557.893 ns | 0.0268 |      - |     - |     192 B |
|             FromMethod |     29.875 ns |     0.5333 ns |     0.4989 ns |     29.749 ns |      - |      - |     - |         - |
|             ToProperty |      8.595 ns |     0.1671 ns |     0.1563 ns |      8.552 ns |      - |      - |     - |         - |
|                     As |      8.517 ns |     0.1321 ns |     0.1103 ns |      8.557 ns |      - |      - |     - |         - |
|                  As_SI |    551.869 ns |     7.8012 ns |     6.9155 ns |    552.642 ns | 0.0267 |      - |     - |     192 B |
|                 ToUnit |     18.770 ns |     0.4075 ns |     0.4002 ns |     18.696 ns |      - |      - |     - |         - |
|              ToUnit_SI |    582.321 ns |     4.6199 ns |     3.8579 ns |    582.931 ns | 0.0262 |      - |     - |     192 B |
|           ToStringTest |  2,122.634 ns |    37.8361 ns |    35.3919 ns |  2,113.109 ns | 0.1379 |      - |     - |     952 B |
|                  Parse | 70,155.616 ns | 1,351.7348 ns | 1,264.4136 ns | 70,178.610 ns | 6.5943 | 0.1374 |     - |   44816 B |
|          TryParseValid | 69,258.555 ns | 1,055.6076 ns |   881.4801 ns | 68,974.644 ns | 6.5661 | 0.1397 |     - |   44792 B |
|        TryParseInvalid | 75,529.047 ns | 1,039.0043 ns |   867.6157 ns | 75,559.430 ns | 6.5292 | 0.1484 |     - |   44392 B |
|           QuantityFrom |  1,861.856 ns |    64.5701 ns |   187.3295 ns |  1,800.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.869 ns |     0.3393 ns |     0.2833 ns |     19.768 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    562.629 ns |     9.2457 ns |     8.6484 ns |    564.321 ns | 0.0266 |      - |     - |     192 B |
|       IQuantity_ToUnit |     31.259 ns |     0.7160 ns |     0.7032 ns |     31.271 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,144.682 ns |    28.4199 ns |    26.5840 ns |  2,146.102 ns | 0.1364 |      - |     - |     952 B |
