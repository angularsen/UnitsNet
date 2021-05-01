``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-VEMBYU : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.402 ns |     0.2336 ns |     0.2185 ns |     10.504 ns |      - |      - |     - |         - |
|         Constructor_SI |    346.288 ns |     6.8888 ns |     8.7121 ns |    346.127 ns | 0.0116 |      - |     - |     192 B |
|             FromMethod |     28.416 ns |     0.5101 ns |     0.4771 ns |     28.380 ns |      - |      - |     - |         - |
|             ToProperty |      8.483 ns |     0.2024 ns |     0.1893 ns |      8.496 ns |      - |      - |     - |         - |
|                     As |      9.349 ns |     0.1922 ns |     0.1704 ns |      9.280 ns |      - |      - |     - |         - |
|                  As_SI |    338.506 ns |     6.7728 ns |     7.5279 ns |    336.945 ns | 0.0116 |      - |     - |     192 B |
|                 ToUnit |     17.865 ns |     0.3594 ns |     0.3362 ns |     17.745 ns |      - |      - |     - |         - |
|              ToUnit_SI |    341.914 ns |     6.7461 ns |     7.7689 ns |    341.144 ns | 0.0118 |      - |     - |     192 B |
|           ToStringTest |  1,390.191 ns |    27.7747 ns |    47.1636 ns |  1,373.510 ns | 0.0583 |      - |     - |     944 B |
|                  Parse | 47,677.928 ns |   923.8017 ns | 1,099.7202 ns | 47,469.258 ns | 2.0557 | 0.0934 |     - |   33344 B |
|          TryParseValid | 47,900.090 ns |   786.1415 ns |   735.3572 ns | 47,936.818 ns | 2.0635 | 0.0983 |     - |   33320 B |
|        TryParseInvalid | 52,116.804 ns | 1,020.5219 ns | 1,175.2346 ns | 51,692.323 ns | 2.0665 |      - |     - |   32928 B |
|           QuantityFrom |  3,459.740 ns |    68.8198 ns |   176.4114 ns |  3,400.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     17.407 ns |     0.3119 ns |     0.2765 ns |     17.423 ns | 0.0015 |      - |     - |      24 B |
|        IQuantity_As_SI |    335.059 ns |     6.5588 ns |     8.2948 ns |    333.037 ns | 0.0120 |      - |     - |     192 B |
|       IQuantity_ToUnit |     27.197 ns |     0.5600 ns |     0.6666 ns |     26.970 ns | 0.0036 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,444.008 ns |    25.4393 ns |    24.9848 ns |  1,450.499 ns | 0.0580 |      - |     - |     944 B |
