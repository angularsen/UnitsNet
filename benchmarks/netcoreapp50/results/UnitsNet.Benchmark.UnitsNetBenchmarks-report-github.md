``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-WXCMHT : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |      9.507 ns |   0.0261 ns |   0.0231 ns |      - |     - |     - |         - |
|         Constructor_SI |    311.532 ns |   3.7141 ns |   3.4741 ns | 0.0100 |     - |     - |     192 B |
|             FromMethod |     24.453 ns |   0.0708 ns |   0.0663 ns |      - |     - |     - |         - |
|             ToProperty |      8.697 ns |   0.0340 ns |   0.0318 ns |      - |     - |     - |         - |
|                     As |      9.161 ns |   0.0264 ns |   0.0247 ns |      - |     - |     - |         - |
|                  As_SI |    310.059 ns |   3.9556 ns |   3.7000 ns | 0.0099 |     - |     - |     192 B |
|                 ToUnit |     16.271 ns |   0.0439 ns |   0.0389 ns |      - |     - |     - |         - |
|              ToUnit_SI |    326.281 ns |   1.3668 ns |   1.2785 ns | 0.0098 |     - |     - |     192 B |
|           ToStringTest |  1,238.400 ns |  13.9527 ns |  13.0514 ns | 0.0498 |     - |     - |     944 B |
|                  Parse | 43,489.164 ns | 425.2539 ns | 397.7827 ns | 1.7678 |     - |     - |   33344 B |
|          TryParseValid | 44,233.903 ns | 525.6481 ns | 491.6916 ns | 1.7760 |     - |     - |   33320 B |
|        TryParseInvalid | 47,176.879 ns | 324.2437 ns | 303.2977 ns | 1.7427 |     - |     - |   32928 B |
|           QuantityFrom |  3,403.774 ns |  63.6963 ns | 132.9579 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     19.822 ns |   0.2071 ns |   0.1836 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    323.776 ns |   1.2103 ns |   1.1321 ns | 0.0097 |     - |     - |     192 B |
|       IQuantity_ToUnit |     30.150 ns |   0.6786 ns |   0.8582 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,291.549 ns |   7.1944 ns |   6.3776 ns | 0.0493 |     - |     - |     944 B |
