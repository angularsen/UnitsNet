``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2061 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.400
  [Host]     : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  Job-RGEGXD : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |      9.522 ns |   0.0291 ns |   0.0272 ns |      - |     - |     - |         - |
|         Constructor_SI |    319.843 ns |   1.2037 ns |   1.1259 ns | 0.0097 |     - |     - |     192 B |
|             FromMethod |     24.423 ns |   0.0675 ns |   0.0632 ns |      - |     - |     - |         - |
|             ToProperty |      8.592 ns |   0.0258 ns |   0.0229 ns |      - |     - |     - |         - |
|                     As |      9.162 ns |   0.0245 ns |   0.0230 ns |      - |     - |     - |         - |
|                  As_SI |    318.104 ns |   0.6346 ns |   0.5625 ns | 0.0097 |     - |     - |     192 B |
|                 ToUnit |     16.260 ns |   0.0346 ns |   0.0324 ns |      - |     - |     - |         - |
|              ToUnit_SI |    326.907 ns |   0.6120 ns |   0.5725 ns | 0.0098 |     - |     - |     192 B |
|           ToStringTest |  1,328.070 ns |   8.1422 ns |   7.6162 ns | 0.0503 |     - |     - |     944 B |
|                  Parse | 44,878.377 ns | 184.4566 ns | 163.5160 ns | 1.7082 |     - |     - |   33345 B |
|          TryParseValid | 44,680.706 ns | 242.0782 ns | 226.4401 ns | 1.6957 |     - |     - |   33320 B |
|        TryParseInvalid | 47,633.599 ns | 167.5416 ns | 148.5213 ns | 1.6943 |     - |     - |   32928 B |
|           QuantityFrom |  2,705.556 ns |  50.7910 ns | 107.1354 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     21.380 ns |   0.0749 ns |   0.0700 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    322.171 ns |   0.4884 ns |   0.4329 ns | 0.0098 |     - |     - |     192 B |
|       IQuantity_ToUnit |     31.749 ns |   0.2447 ns |   0.2289 ns | 0.0029 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,332.254 ns |   6.0027 ns |   5.6149 ns | 0.0483 |     - |     - |     944 B |
