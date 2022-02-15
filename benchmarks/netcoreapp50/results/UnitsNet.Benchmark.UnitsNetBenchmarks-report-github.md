``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.20348
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-GNBUPT : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |         StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|---------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |      9.043 ns |     0.2158 ns |      0.5171 ns |      9.110 ns |      - |      - |     - |         - |
|         Constructor_SI |    330.767 ns |     6.6180 ns |     10.3034 ns |    335.269 ns | 0.0100 |      - |     - |     192 B |
|             FromMethod |     23.449 ns |     0.5029 ns |      0.7829 ns |     23.300 ns |      - |      - |     - |         - |
|             ToProperty |    150.348 ns |     3.0351 ns |      5.6257 ns |    152.501 ns | 0.0059 |      - |     - |     112 B |
|                     As |    146.625 ns |     2.9567 ns |      3.0363 ns |    147.532 ns | 0.0057 |      - |     - |     112 B |
|                  As_SI |    331.544 ns |     6.6314 ns |      9.5106 ns |    334.402 ns | 0.0097 |      - |     - |     192 B |
|                 ToUnit |    139.002 ns |     2.7463 ns |      4.4347 ns |    138.484 ns | 0.0058 |      - |     - |     112 B |
|              ToUnit_SI |    335.751 ns |     6.7456 ns |     12.5035 ns |    340.562 ns | 0.0103 |      - |     - |     192 B |
|           ToStringTest |  1,219.602 ns |    24.3496 ns |     48.0636 ns |  1,217.210 ns | 0.0501 |      - |     - |     944 B |
|                  Parse | 54,090.197 ns | 4,390.0690 ns | 12,806.0374 ns | 46,237.365 ns | 1.8174 | 0.0865 |     - |   34760 B |
|          TryParseValid | 44,835.987 ns |   887.3638 ns |  1,355.0982 ns | 44,939.134 ns | 1.8118 |      - |     - |   34736 B |
|        TryParseInvalid | 48,201.040 ns |   944.1895 ns |  1,323.6218 ns | 48,941.282 ns | 1.7604 |      - |     - |   34344 B |
|           QuantityFrom |     68.807 ns |     1.4401 ns |      1.5409 ns |     69.416 ns | 0.0029 |      - |     - |      56 B |
|           IQuantity_As |    164.357 ns |     3.3184 ns |      5.0676 ns |    165.685 ns | 0.0070 |      - |     - |     136 B |
|        IQuantity_As_SI |    300.454 ns |     2.4554 ns |      2.2968 ns |    300.449 ns | 0.0098 |      - |     - |     192 B |
|       IQuantity_ToUnit |    152.114 ns |     2.9872 ns |      2.7942 ns |    151.387 ns | 0.0089 |      - |     - |     168 B |
| IQuantity_ToStringTest |  1,138.102 ns |    18.1146 ns |     23.5541 ns |  1,129.958 ns | 0.0504 |      - |     - |     944 B |
