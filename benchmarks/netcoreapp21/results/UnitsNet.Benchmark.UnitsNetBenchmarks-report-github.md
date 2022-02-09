``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2458 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.405
  [Host]     : .NET Core 5.0.14 (CoreCLR 5.0.1422.5710, CoreFX 5.0.1422.5710), X64 RyuJIT
  Job-IZQUWR : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |         Mean |      Error |     StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------:|-------:|------:|----------:|
|            Constructor |     10.99 ns |   0.030 ns |   0.028 ns |      - |      - |     - |         - |
|         Constructor_SI |    520.85 ns |   2.987 ns |   2.794 ns | 0.0278 |      - |     - |     192 B |
|             FromMethod |     25.44 ns |   0.074 ns |   0.069 ns |      - |      - |     - |         - |
|             ToProperty |    184.56 ns |   1.382 ns |   1.293 ns | 0.0168 |      - |     - |     112 B |
|                     As |    180.02 ns |   0.725 ns |   0.678 ns | 0.0169 |      - |     - |     112 B |
|                  As_SI |    514.67 ns |   2.256 ns |   2.110 ns | 0.0277 |      - |     - |     192 B |
|                 ToUnit |    179.69 ns |   1.146 ns |   1.072 ns | 0.0169 |      - |     - |     112 B |
|              ToUnit_SI |    517.57 ns |   3.093 ns |   2.894 ns | 0.0279 |      - |     - |     192 B |
|           ToStringTest |  2,293.32 ns |  12.242 ns |  11.451 ns | 0.1379 |      - |     - |     952 B |
|                  Parse | 61,140.58 ns | 227.005 ns | 212.340 ns | 6.8627 | 0.2451 |     - |   44816 B |
|          TryParseValid | 60,847.60 ns | 419.357 ns | 392.267 ns | 6.8552 | 0.2448 |     - |   44792 B |
|        TryParseInvalid | 66,427.71 ns | 236.308 ns | 221.043 ns | 6.7238 | 0.2637 |     - |   44392 B |
|           QuantityFrom |     88.29 ns |   0.460 ns |   0.430 ns | 0.0084 |      - |     - |      56 B |
|           IQuantity_As |    199.55 ns |   1.099 ns |   1.028 ns | 0.0207 |      - |     - |     136 B |
|        IQuantity_As_SI |    515.50 ns |   1.272 ns |   1.128 ns | 0.0280 |      - |     - |     192 B |
|       IQuantity_ToUnit |    205.30 ns |   0.710 ns |   0.629 ns | 0.0257 |      - |     - |     168 B |
| IQuantity_ToStringTest |  2,178.95 ns |  15.051 ns |  14.079 ns | 0.1404 |      - |     - |     952 B |
