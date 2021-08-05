``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2061 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.302
  [Host]     : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT
  Job-RWYZOB : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.977 ns |     0.0440 ns |     0.0412 ns |     10.976 ns |      - |      - |     - |         - |
|         Constructor_SI |    533.328 ns |     1.1780 ns |     0.9837 ns |    533.454 ns | 0.0278 |      - |     - |     192 B |
|             FromMethod |     25.464 ns |     0.1011 ns |     0.0897 ns |     25.447 ns |      - |      - |     - |         - |
|             ToProperty |      8.202 ns |     0.0255 ns |     0.0239 ns |      8.202 ns |      - |      - |     - |         - |
|                     As |      8.201 ns |     0.0245 ns |     0.0229 ns |      8.195 ns |      - |      - |     - |         - |
|                  As_SI |    518.310 ns |     6.9283 ns |     6.4807 ns |    520.974 ns | 0.0281 |      - |     - |     192 B |
|                 ToUnit |     17.673 ns |     0.0448 ns |     0.0419 ns |     17.679 ns |      - |      - |     - |         - |
|              ToUnit_SI |    548.060 ns |     5.4178 ns |     5.0678 ns |    549.547 ns | 0.0274 |      - |     - |     192 B |
|           ToStringTest |  2,079.924 ns |    11.4351 ns |    10.6964 ns |  2,080.006 ns | 0.1409 |      - |     - |     952 B |
|                  Parse | 62,349.929 ns |   307.0599 ns |   272.2006 ns | 62,376.606 ns | 6.8733 | 0.2499 |     - |   44816 B |
|          TryParseValid | 62,153.173 ns | 1,219.1578 ns | 1,497.2353 ns | 62,663.674 ns | 6.8681 | 0.2498 |     - |   44792 B |
|        TryParseInvalid | 69,171.926 ns |   340.8703 ns |   318.8503 ns | 69,166.392 ns | 6.6936 | 0.1395 |     - |   44392 B |
|           QuantityFrom |  1,357.143 ns |    39.1174 ns |   109.6893 ns |  1,300.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.587 ns |     0.4323 ns |     0.9024 ns |     19.630 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    527.391 ns |     1.2705 ns |     1.1885 ns |    527.187 ns | 0.0279 |      - |     - |     192 B |
|       IQuantity_ToUnit |     29.009 ns |     0.6503 ns |     1.0501 ns |     29.048 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,059.726 ns |     8.6775 ns |     8.1169 ns |  2,059.445 ns | 0.1412 |      - |     - |     952 B |
