``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-QDCPFZ : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |         Mean |        Error |       StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-------------:|-------------:|-------:|------:|------:|----------:|
|            Constructor |     10.88 ns |     0.249 ns |     0.245 ns |      - |     - |     - |         - |
|         Constructor_SI |    373.32 ns |     7.043 ns |     7.536 ns | 0.0069 |     - |     - |     192 B |
|             FromMethod |     32.82 ns |     0.693 ns |     1.037 ns |      - |     - |     - |         - |
|             ToProperty |    174.56 ns |     3.458 ns |     3.235 ns | 0.0041 |     - |     - |     112 B |
|                     As |    166.64 ns |     2.674 ns |     2.233 ns | 0.0042 |     - |     - |     112 B |
|                  As_SI |    377.03 ns |     7.591 ns |    12.683 ns | 0.0067 |     - |     - |     192 B |
|                 ToUnit |    163.17 ns |     3.201 ns |     3.558 ns | 0.0042 |     - |     - |     112 B |
|              ToUnit_SI |    378.34 ns |     7.560 ns |    13.041 ns | 0.0071 |     - |     - |     192 B |
|           ToStringTest |  1,480.82 ns |    19.761 ns |    17.517 ns | 0.0343 |     - |     - |     944 B |
|                  Parse | 54,415.99 ns | 1,049.361 ns |   981.573 ns | 1.2458 |     - |     - |   34760 B |
|          TryParseValid | 53,519.55 ns | 1,045.801 ns | 1,499.857 ns | 1.2394 |     - |     - |   34736 B |
|        TryParseInvalid | 58,664.46 ns | 1,167.081 ns | 1,344.012 ns | 1.2537 |     - |     - |   34344 B |
|           QuantityFrom |     82.25 ns |     1.674 ns |     1.928 ns | 0.0021 |     - |     - |      56 B |
|           IQuantity_As |    182.93 ns |     3.562 ns |     6.863 ns | 0.0051 |     - |     - |     136 B |
|        IQuantity_As_SI |    380.78 ns |     7.606 ns |     9.341 ns | 0.0066 |     - |     - |     192 B |
|       IQuantity_ToUnit |    180.53 ns |     3.723 ns |     8.479 ns | 0.0063 |     - |     - |     168 B |
| IQuantity_ToStringTest |  1,469.71 ns |    28.915 ns |    27.047 ns | 0.0343 |     - |     - |     944 B |
