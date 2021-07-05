``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1999 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.301
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  Job-YPWHWJ : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.726 ns |   0.2480 ns |     0.3635 ns |      - |      - |     - |         - |
|         Constructor_SI |    335.271 ns |   6.6297 ns |     8.3845 ns | 0.0119 |      - |     - |     192 B |
|             FromMethod |     28.062 ns |   0.5497 ns |     0.6952 ns |      - |      - |     - |         - |
|             ToProperty |      8.399 ns |   0.1563 ns |     0.1385 ns |      - |      - |     - |         - |
|                     As |      8.610 ns |   0.2146 ns |     0.3077 ns |      - |      - |     - |         - |
|                  As_SI |    352.439 ns |   7.0992 ns |     8.1754 ns | 0.0120 |      - |     - |     192 B |
|                 ToUnit |     18.479 ns |   0.4053 ns |     0.5411 ns |      - |      - |     - |         - |
|              ToUnit_SI |    358.241 ns |   7.0757 ns |    11.4259 ns | 0.0121 |      - |     - |     192 B |
|           ToStringTest |  1,361.243 ns |  25.7820 ns |    30.6916 ns | 0.0584 |      - |     - |     944 B |
|                  Parse | 49,979.246 ns | 995.5714 ns | 1,395.6521 ns | 2.0317 | 0.0967 |     - |   33344 B |
|          TryParseValid | 51,777.524 ns | 972.2049 ns | 1,455.1505 ns | 2.0657 |      - |     - |   33320 B |
|        TryParseInvalid | 53,782.506 ns | 802.1253 ns |   669.8109 ns | 2.0437 |      - |     - |   32928 B |
|           QuantityFrom |  3,515.854 ns |  67.4227 ns |   178.7954 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     18.797 ns |   0.4191 ns |     0.4827 ns | 0.0015 |      - |     - |      24 B |
|        IQuantity_As_SI |    342.037 ns |   6.3866 ns |     5.6616 ns | 0.0119 |      - |     - |     192 B |
|       IQuantity_ToUnit |     29.918 ns |   0.6896 ns |     1.5282 ns | 0.0035 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,368.266 ns |  27.3101 ns |    51.9602 ns | 0.0597 |      - |     - |     944 B |
