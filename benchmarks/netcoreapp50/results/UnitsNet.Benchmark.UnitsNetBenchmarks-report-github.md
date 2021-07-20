``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2029 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.302
  [Host]     : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT
  Job-WOMWFS : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |      9.517 ns |   0.0292 ns |   0.0273 ns |      - |     - |     - |         - |
|         Constructor_SI |    318.235 ns |   1.0048 ns |   0.9399 ns | 0.0102 |     - |     - |     192 B |
|             FromMethod |     24.446 ns |   0.0752 ns |   0.0704 ns |      - |     - |     - |         - |
|             ToProperty |      8.563 ns |   0.0202 ns |   0.0169 ns |      - |     - |     - |         - |
|                     As |      9.168 ns |   0.0196 ns |   0.0183 ns |      - |     - |     - |         - |
|                  As_SI |    323.733 ns |   1.6468 ns |   1.5404 ns | 0.0097 |     - |     - |     192 B |
|                 ToUnit |     16.230 ns |   0.0565 ns |   0.0529 ns |      - |     - |     - |         - |
|              ToUnit_SI |    326.650 ns |   1.2683 ns |   1.1863 ns | 0.0098 |     - |     - |     192 B |
|           ToStringTest |  1,219.641 ns |  10.8517 ns |  10.1507 ns | 0.0488 |     - |     - |     944 B |
|                  Parse | 43,204.949 ns | 421.2132 ns | 373.3945 ns | 1.7090 |     - |     - |   33344 B |
|          TryParseValid | 43,730.131 ns | 238.9798 ns | 223.5418 ns | 1.7303 |     - |     - |   33320 B |
|        TryParseInvalid | 46,569.935 ns | 189.7629 ns | 168.2199 ns | 1.6815 |     - |     - |   32928 B |
|           QuantityFrom |  2,820.000 ns |  48.0084 ns |  85.3349 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     20.529 ns |   0.3644 ns |   0.3408 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    323.899 ns |   1.1459 ns |   1.0719 ns | 0.0098 |     - |     - |     192 B |
|       IQuantity_ToUnit |     28.612 ns |   0.3503 ns |   0.3105 ns | 0.0030 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,256.133 ns |   8.0992 ns |   7.5760 ns | 0.0501 |     - |     - |     944 B |
