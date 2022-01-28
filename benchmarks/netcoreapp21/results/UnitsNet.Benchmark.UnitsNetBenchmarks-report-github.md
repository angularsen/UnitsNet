``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-FTMXYJ : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.896 ns |     0.1687 ns |     0.1578 ns |     10.883 ns |      - |      - |     - |         - |
|         Constructor_SI |    502.209 ns |    10.0408 ns |    14.7177 ns |    501.606 ns | 0.0284 |      - |     - |     192 B |
|             FromMethod |     24.753 ns |     0.5093 ns |     0.6623 ns |     24.960 ns |      - |      - |     - |         - |
|             ToProperty |      8.367 ns |     0.2039 ns |     0.3349 ns |      8.394 ns |      - |      - |     - |         - |
|                     As |      8.469 ns |     0.2042 ns |     0.2655 ns |      8.494 ns |      - |      - |     - |         - |
|                  As_SI |    487.432 ns |     9.7051 ns |    14.5262 ns |    489.272 ns | 0.0286 |      - |     - |     192 B |
|                 ToUnit |     16.763 ns |     0.3707 ns |     0.4820 ns |     16.756 ns |      - |      - |     - |         - |
|              ToUnit_SI |    506.357 ns |    10.1538 ns |    14.8833 ns |    509.064 ns | 0.0278 |      - |     - |     192 B |
|           ToStringTest |  1,939.563 ns |    38.0605 ns |    60.3680 ns |  1,947.660 ns | 0.1402 |      - |     - |     952 B |
|                  Parse | 59,363.938 ns | 1,166.1427 ns | 1,197.5427 ns | 59,390.842 ns | 6.8364 | 0.2357 |     - |   44816 B |
|          TryParseValid | 58,483.972 ns | 1,158.5423 ns | 1,769.2164 ns | 59,143.762 ns | 6.8216 | 0.2312 |     - |   44792 B |
|        TryParseInvalid | 63,079.192 ns | 1,240.1616 ns | 1,523.0298 ns | 63,106.419 ns | 6.7967 | 0.2517 |     - |   44392 B |
|           QuantityFrom |  2,040.741 ns |    40.6868 ns |    85.8224 ns |  2,100.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     18.533 ns |     0.4080 ns |     0.6588 ns |     18.622 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    484.447 ns |     9.5079 ns |    13.6359 ns |    485.289 ns | 0.0278 |      - |     - |     192 B |
|       IQuantity_ToUnit |     25.968 ns |     0.6057 ns |     0.8879 ns |     26.223 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,909.187 ns |    36.7931 ns |    52.7675 ns |  1,916.984 ns | 0.1426 |      - |     - |     952 B |
