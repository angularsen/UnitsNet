``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-ZYOBEG : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.500 ns |     0.2833 ns |     0.5390 ns |     12.784 ns |      - |      - |     - |         - |
|         Constructor_SI |    491.233 ns |     9.8584 ns |    22.0496 ns |    504.045 ns | 0.0298 |      - |     - |     201 B |
|             FromMethod |     27.754 ns |     0.5918 ns |     1.4738 ns |     27.357 ns |      - |      - |     - |         - |
|             ToProperty |      8.313 ns |     0.2038 ns |     0.4764 ns |      8.468 ns |      - |      - |     - |         - |
|                     As |      8.246 ns |     0.2023 ns |     0.4730 ns |      8.109 ns |      - |      - |     - |         - |
|                  As_SI |    487.894 ns |     9.6262 ns |    19.2246 ns |    499.089 ns | 0.0296 |      - |     - |     201 B |
|                 ToUnit |     19.103 ns |     0.4178 ns |     0.7847 ns |     19.485 ns |      - |      - |     - |         - |
|              ToUnit_SI |    494.977 ns |     9.9344 ns |    20.9551 ns |    503.908 ns | 0.0296 |      - |     - |     201 B |
|           ToStringTest |  2,035.605 ns |    42.1353 ns |   114.6321 ns |  2,056.935 ns | 0.1845 |      - |     - |    1220 B |
|                  Parse | 51,412.823 ns | 1,018.7585 ns | 2,499.0320 ns | 51,301.072 ns | 8.3583 | 0.3215 |     - |   54376 B |
|          TryParseValid | 53,755.971 ns |   559.3140 ns |   523.1826 ns | 53,913.391 ns | 8.3568 | 0.3021 |     - |   54352 B |
|        TryParseInvalid | 56,544.142 ns | 1,128.7948 ns | 2,593.5937 ns | 57,669.114 ns | 8.3106 | 0.3415 |     - |   53894 B |
|           QuantityFrom |  1,955.932 ns |    38.6492 ns |    85.6440 ns |  1,900.000 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     17.754 ns |     0.3873 ns |     0.8582 ns |     17.934 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    464.131 ns |     9.3129 ns |    21.5840 ns |    459.440 ns | 0.0293 |      - |     - |     201 B |
|       IQuantity_ToUnit |     28.621 ns |     0.6681 ns |     1.8624 ns |     28.517 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,125.734 ns |    41.9949 ns |    58.8710 ns |  2,143.928 ns | 0.1823 |      - |     - |    1220 B |
