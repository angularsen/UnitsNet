``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2114 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.400
  [Host]     : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  Job-CECHQX : .NET Core 2.1.30 (CoreCLR 4.6.30411.01, CoreFX 4.6.30411.02), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.933 ns |   0.0321 ns |   0.0300 ns |      - |      - |     - |         - |
|         Constructor_SI |    512.200 ns |   3.4162 ns |   3.1955 ns | 0.0282 |      - |     - |     192 B |
|             FromMethod |     25.463 ns |   0.0502 ns |   0.0469 ns |      - |      - |     - |         - |
|             ToProperty |      8.639 ns |   0.0235 ns |   0.0208 ns |      - |      - |     - |         - |
|                     As |      8.320 ns |   0.0216 ns |   0.0192 ns |      - |      - |     - |         - |
|                  As_SI |    497.551 ns |   2.5161 ns |   2.3535 ns | 0.0280 |      - |     - |     192 B |
|                 ToUnit |     17.703 ns |   0.0447 ns |   0.0418 ns |      - |      - |     - |         - |
|              ToUnit_SI |    509.143 ns |   2.5334 ns |   2.3698 ns | 0.0284 |      - |     - |     192 B |
|           ToStringTest |  2,073.178 ns |  16.5734 ns |  15.5027 ns | 0.1398 |      - |     - |     952 B |
|                  Parse | 59,380.129 ns | 190.5453 ns | 178.2362 ns | 6.7825 | 0.2380 |     - |   44816 B |
|          TryParseValid | 60,449.951 ns | 149.0690 ns | 139.4392 ns | 6.8675 | 0.2410 |     - |   44792 B |
|        TryParseInvalid | 64,970.034 ns | 174.8099 ns | 163.5173 ns | 6.7010 | 0.2577 |     - |   44392 B |
|           QuantityFrom |  1,608.696 ns |  36.2833 ns | 102.3377 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     18.475 ns |   0.0652 ns |   0.0610 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    503.888 ns |   2.4627 ns |   2.1831 ns | 0.0280 |      - |     - |     192 B |
|       IQuantity_ToUnit |     26.432 ns |   0.3164 ns |   0.2805 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,998.596 ns |  12.3748 ns |  11.5754 ns | 0.1425 |      - |     - |     952 B |
