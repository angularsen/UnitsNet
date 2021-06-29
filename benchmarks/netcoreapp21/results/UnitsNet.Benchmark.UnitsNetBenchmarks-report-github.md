``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-VTIKSD : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.628 ns |     0.2084 ns |     0.1949 ns |     10.658 ns |      - |      - |     - |         - |
|         Constructor_SI |    505.938 ns |    10.0319 ns |    15.6184 ns |    507.447 ns | 0.0282 |      - |     - |     192 B |
|             FromMethod |     24.371 ns |     0.5159 ns |     0.6525 ns |     24.283 ns |      - |      - |     - |         - |
|             ToProperty |      8.243 ns |     0.1928 ns |     0.2368 ns |      8.318 ns |      - |      - |     - |         - |
|                     As |      8.602 ns |     0.2048 ns |     0.2438 ns |      8.680 ns |      - |      - |     - |         - |
|                  As_SI |    489.868 ns |     9.8062 ns |    13.0910 ns |    493.801 ns | 0.0283 |      - |     - |     192 B |
|                 ToUnit |     17.161 ns |     0.3706 ns |     0.3466 ns |     17.380 ns |      - |      - |     - |         - |
|              ToUnit_SI |    502.464 ns |     9.0995 ns |     8.5116 ns |    501.635 ns | 0.0277 |      - |     - |     192 B |
|           ToStringTest |  2,163.245 ns |    43.1329 ns |    74.4021 ns |  2,181.252 ns | 0.1412 |      - |     - |     952 B |
|                  Parse | 58,569.947 ns | 1,147.5436 ns | 1,608.6959 ns | 58,822.717 ns | 6.8163 | 0.2350 |     - |   44816 B |
|          TryParseValid | 59,550.572 ns |   930.9184 ns |   870.7816 ns | 59,811.884 ns | 6.8582 | 0.2365 |     - |   44792 B |
|        TryParseInvalid | 63,988.704 ns | 1,265.9966 ns | 1,690.0690 ns | 63,928.854 ns | 6.7131 | 0.2533 |     - |   44392 B |
|           QuantityFrom |  1,438.462 ns |    28.5143 ns |    79.9573 ns |  1,400.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     18.388 ns |     0.4040 ns |     0.4809 ns |     18.434 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    492.460 ns |     9.2246 ns |    16.6339 ns |    492.647 ns | 0.0280 |      - |     - |     192 B |
|       IQuantity_ToUnit |     26.484 ns |     0.6009 ns |     0.6679 ns |     26.582 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,214.879 ns |    43.1845 ns |    65.9472 ns |  2,218.508 ns | 0.1404 |      - |     - |     952 B |
