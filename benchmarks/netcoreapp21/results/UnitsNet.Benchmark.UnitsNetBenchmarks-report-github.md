``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2029 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.302
  [Host]     : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT
  Job-KFZJNW : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.438 ns |   0.2385 ns |   0.3264 ns |      - |      - |     - |         - |
|         Constructor_SI |    511.221 ns |  10.1948 ns |  14.9433 ns | 0.0277 |      - |     - |     192 B |
|             FromMethod |     24.754 ns |   0.5155 ns |   0.6331 ns |      - |      - |     - |         - |
|             ToProperty |      7.911 ns |   0.1926 ns |   0.1977 ns |      - |      - |     - |         - |
|                     As |      7.814 ns |   0.1958 ns |   0.2931 ns |      - |      - |     - |         - |
|                  As_SI |    540.917 ns |  10.8290 ns |  13.2990 ns | 0.0278 |      - |     - |     192 B |
|                 ToUnit |     17.675 ns |   0.0500 ns |   0.0467 ns |      - |      - |     - |         - |
|              ToUnit_SI |    554.675 ns |   1.5250 ns |   1.3519 ns | 0.0278 |      - |     - |     192 B |
|           ToStringTest |  2,026.222 ns |  16.1310 ns |  15.0890 ns | 0.1422 |      - |     - |     952 B |
|                  Parse | 63,233.364 ns | 881.5057 ns | 781.4318 ns | 6.8598 | 0.2541 |     - |   44816 B |
|          TryParseValid | 64,374.902 ns | 708.4234 ns | 662.6597 ns | 6.8194 | 0.2573 |     - |   44792 B |
|        TryParseInvalid | 69,073.631 ns | 604.3001 ns | 565.2627 ns | 6.6464 | 0.1385 |     - |   44392 B |
|           QuantityFrom |  1,606.250 ns |  39.5377 ns | 114.0752 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     20.478 ns |   0.3653 ns |   0.3417 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    524.679 ns |   1.7932 ns |   1.5896 ns | 0.0281 |      - |     - |     192 B |
|       IQuantity_ToUnit |     28.815 ns |   0.6333 ns |   0.7039 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,056.813 ns |   8.8920 ns |   8.3176 ns | 0.1425 |      - |     - |     952 B |
