``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-HIRQUR : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |      9.525 ns |   0.0392 ns |   0.0367 ns |      - |     - |     - |         - |
|         Constructor_SI |    324.904 ns |   0.9634 ns |   0.9012 ns | 0.0098 |     - |     - |     192 B |
|             FromMethod |     24.472 ns |   0.0558 ns |   0.0522 ns |      - |     - |     - |         - |
|             ToProperty |      8.699 ns |   0.0194 ns |   0.0181 ns |      - |     - |     - |         - |
|                     As |      9.176 ns |   0.0172 ns |   0.0161 ns |      - |     - |     - |         - |
|                  As_SI |    326.474 ns |   0.5602 ns |   0.5241 ns | 0.0098 |     - |     - |     192 B |
|                 ToUnit |     16.255 ns |   0.0363 ns |   0.0339 ns |      - |     - |     - |         - |
|              ToUnit_SI |    337.721 ns |   0.9989 ns |   0.9344 ns | 0.0102 |     - |     - |     192 B |
|           ToStringTest |  1,363.312 ns |   8.5288 ns |   7.9779 ns | 0.0485 |     - |     - |     944 B |
|                  Parse | 45,435.301 ns | 421.2367 ns | 394.0251 ns | 1.7248 |     - |     - |   33345 B |
|          TryParseValid | 45,827.750 ns | 101.0203 ns |  94.4945 ns | 1.7458 |     - |     - |   33320 B |
|        TryParseInvalid | 48,445.156 ns | 222.9787 ns | 208.5744 ns | 1.7246 |     - |     - |   32928 B |
|           QuantityFrom |  3,596.154 ns |  71.0891 ns | 146.8113 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     20.633 ns |   0.1820 ns |   0.1519 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    329.799 ns |   1.1527 ns |   1.0782 ns | 0.0099 |     - |     - |     192 B |
|       IQuantity_ToUnit |     31.836 ns |   0.1322 ns |   0.1237 ns | 0.0029 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,325.289 ns |   8.9235 ns |   7.9104 ns | 0.0503 |     - |     - |     944 B |
