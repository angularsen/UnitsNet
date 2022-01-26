``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2452 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-PBXXOZ : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     11.555 ns |     0.2629 ns |     0.2459 ns |     11.581 ns |      - |      - |     - |         - |
|         Constructor_SI |    554.929 ns |    11.1144 ns |    23.6857 ns |    555.307 ns | 0.0281 |      - |     - |     192 B |
|             FromMethod |     28.791 ns |     0.6157 ns |     1.2437 ns |     28.376 ns |      - |      - |     - |         - |
|             ToProperty |      8.207 ns |     0.1563 ns |     0.1386 ns |      8.180 ns |      - |      - |     - |         - |
|                     As |      8.389 ns |     0.2089 ns |     0.3547 ns |      8.271 ns |      - |      - |     - |         - |
|                  As_SI |    548.716 ns |    10.6954 ns |    23.9217 ns |    537.754 ns | 0.0284 |      - |     - |     192 B |
|                 ToUnit |     18.995 ns |     0.4132 ns |     0.5373 ns |     18.924 ns |      - |      - |     - |         - |
|              ToUnit_SI |    631.095 ns |    11.7338 ns |    24.7505 ns |    632.582 ns | 0.0282 |      - |     - |     192 B |
|           ToStringTest |  2,291.830 ns |    41.8272 ns |    39.1252 ns |  2,278.529 ns | 0.1427 |      - |     - |     952 B |
|                  Parse | 80,492.754 ns | 1,595.1423 ns | 1,958.9779 ns | 80,132.286 ns | 6.7484 | 0.1776 |     - |   44816 B |
|          TryParseValid | 80,448.334 ns | 1,579.9904 ns | 2,364.8552 ns | 79,802.339 ns | 6.7952 | 0.1580 |     - |   44792 B |
|        TryParseInvalid | 88,038.905 ns | 1,698.5468 ns | 2,489.7078 ns | 88,060.491 ns | 6.7173 | 0.1768 |     - |   44392 B |
|           QuantityFrom |  2,479.381 ns |    57.3627 ns |   166.4195 ns |  2,500.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     20.189 ns |     0.3770 ns |     0.3527 ns |     20.168 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    599.418 ns |     7.4421 ns |     6.9614 ns |    599.503 ns | 0.0287 |      - |     - |     192 B |
|       IQuantity_ToUnit |     31.669 ns |     0.6014 ns |     0.5626 ns |     31.539 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,243.067 ns |    41.9541 ns |    39.2439 ns |  2,236.750 ns | 0.1432 |      - |     - |     952 B |
