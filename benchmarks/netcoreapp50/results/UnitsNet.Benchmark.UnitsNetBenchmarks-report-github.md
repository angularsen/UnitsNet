``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-MUILDG : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |      8.875 ns |   0.2130 ns |     0.5830 ns |      8.656 ns |      - |      - |     - |         - |
|         Constructor_SI |    297.435 ns |   5.7159 ns |     5.6138 ns |    295.104 ns | 0.0101 |      - |     - |     192 B |
|             FromMethod |     22.275 ns |   0.4801 ns |     0.6572 ns |     22.271 ns |      - |      - |     - |         - |
|             ToProperty |      7.823 ns |   0.1909 ns |     0.1786 ns |      7.753 ns |      - |      - |     - |         - |
|                     As |      8.096 ns |   0.0384 ns |     0.0340 ns |      8.091 ns |      - |      - |     - |         - |
|                  As_SI |    289.666 ns |   1.8280 ns |     1.4271 ns |    289.639 ns | 0.0097 |      - |     - |     192 B |
|                 ToUnit |     14.547 ns |   0.3198 ns |     0.2835 ns |     14.446 ns |      - |      - |     - |         - |
|              ToUnit_SI |    292.169 ns |   1.3728 ns |     1.2841 ns |    291.992 ns | 0.0101 |      - |     - |     192 B |
|           ToStringTest |  1,302.887 ns |  25.9108 ns |    55.2180 ns |  1,330.033 ns | 0.0494 |      - |     - |     944 B |
|                  Parse | 39,357.550 ns | 773.4908 ns |   859.7330 ns | 39,040.682 ns | 1.7581 | 0.0764 |     - |   33344 B |
|          TryParseValid | 41,472.721 ns | 828.0335 ns | 1,534.8131 ns | 41,141.745 ns | 1.7572 | 0.0837 |     - |   33320 B |
|        TryParseInvalid | 43,938.215 ns | 855.3115 ns |   840.0303 ns | 43,930.333 ns | 1.7101 |      - |     - |   32928 B |
|           QuantityFrom |  3,488.462 ns |  68.9562 ns |   177.9981 ns |  3,500.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     19.466 ns |   0.4241 ns |     1.1173 ns |     19.461 ns | 0.0013 |      - |     - |      24 B |
|        IQuantity_As_SI |    325.647 ns |   6.5265 ns |    10.7233 ns |    325.244 ns | 0.0102 |      - |     - |     192 B |
|       IQuantity_ToUnit |     24.688 ns |   0.4742 ns |     0.4657 ns |     24.701 ns | 0.0030 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,178.989 ns |  23.4351 ns |    26.9879 ns |  1,180.063 ns | 0.0497 |      - |     - |     944 B |
