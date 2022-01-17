``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-DWFBKQ : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.920 ns |   0.0324 ns |   0.0303 ns |      - |      - |     - |         - |
|         Constructor_SI |    514.073 ns |   1.9631 ns |   1.8363 ns | 0.0277 |      - |     - |     192 B |
|             FromMethod |     25.444 ns |   0.0616 ns |   0.0576 ns |      - |      - |     - |         - |
|             ToProperty |      8.330 ns |   0.0298 ns |   0.0278 ns |      - |      - |     - |         - |
|                     As |      8.331 ns |   0.0105 ns |   0.0093 ns |      - |      - |     - |         - |
|                  As_SI |    505.395 ns |   2.3234 ns |   2.0596 ns | 0.0281 |      - |     - |     192 B |
|                 ToUnit |     17.640 ns |   0.0425 ns |   0.0398 ns |      - |      - |     - |         - |
|              ToUnit_SI |    522.951 ns |   3.0069 ns |   2.8127 ns | 0.0283 |      - |     - |     192 B |
|           ToStringTest |  2,291.360 ns |  10.6855 ns |   9.9953 ns | 0.1377 |      - |     - |     952 B |
|                  Parse | 59,656.655 ns | 262.6590 ns | 232.8403 ns | 6.8206 | 0.2393 |     - |   44816 B |
|          TryParseValid | 60,385.684 ns | 336.8456 ns | 315.0856 ns | 6.8313 | 0.2397 |     - |   44792 B |
|        TryParseInvalid | 65,620.383 ns | 280.4501 ns | 262.3332 ns | 6.7956 | 0.2614 |     - |   44392 B |
|           QuantityFrom |  1,810.526 ns |  37.8648 ns | 108.6412 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.686 ns |   0.1168 ns |   0.1093 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    504.892 ns |   1.4569 ns |   1.2915 ns | 0.0275 |      - |     - |     192 B |
|       IQuantity_ToUnit |     26.367 ns |   0.1302 ns |   0.1154 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,318.157 ns |  11.8397 ns |  10.4956 ns | 0.1379 |      - |     - |     952 B |
