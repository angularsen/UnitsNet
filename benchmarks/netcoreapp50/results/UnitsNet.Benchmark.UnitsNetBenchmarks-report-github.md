``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-ROIQNO : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |      9.517 ns |   0.0207 ns |   0.0194 ns |      - |     - |     - |         - |
|         Constructor_SI |    329.533 ns |   1.1161 ns |   1.0440 ns | 0.0100 |     - |     - |     192 B |
|             FromMethod |     24.470 ns |   0.0912 ns |   0.0853 ns |      - |     - |     - |         - |
|             ToProperty |      8.707 ns |   0.0214 ns |   0.0189 ns |      - |     - |     - |         - |
|                     As |      9.197 ns |   0.0321 ns |   0.0300 ns |      - |     - |     - |         - |
|                  As_SI |    318.545 ns |   0.8896 ns |   0.8322 ns | 0.0097 |     - |     - |     192 B |
|                 ToUnit |     16.247 ns |   0.0413 ns |   0.0386 ns |      - |     - |     - |         - |
|              ToUnit_SI |    337.673 ns |   2.6325 ns |   2.4624 ns | 0.0100 |     - |     - |     192 B |
|           ToStringTest |  1,293.284 ns |  13.9714 ns |  13.0688 ns | 0.0485 |     - |     - |     944 B |
|                  Parse | 44,834.773 ns | 389.1637 ns | 364.0240 ns | 1.7330 |     - |     - |   33345 B |
|          TryParseValid | 44,929.906 ns | 386.9842 ns | 361.9852 ns | 1.6939 |     - |     - |   33320 B |
|        TryParseInvalid | 48,022.511 ns | 220.5175 ns | 195.4830 ns | 1.7331 |     - |     - |   32929 B |
|           QuantityFrom |  3,482.143 ns |  68.6803 ns | 147.8416 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     20.085 ns |   0.2346 ns |   0.2195 ns | 0.0012 |     - |     - |      24 B |
|        IQuantity_As_SI |    330.843 ns |   0.9265 ns |   0.8667 ns | 0.0100 |     - |     - |     192 B |
|       IQuantity_ToUnit |     30.917 ns |   0.5279 ns |   0.4938 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,304.009 ns |  12.8091 ns |  11.9816 ns | 0.0497 |     - |     - |     944 B |
