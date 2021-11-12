``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.403
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  Job-XAJWFU : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|-------:|------:|----------:|
|            Constructor |     12.599 ns |   0.0378 ns |   0.0335 ns |      - |      - |     - |         - |
|         Constructor_SI |    490.411 ns |   2.0527 ns |   1.8197 ns | 0.0295 |      - |     - |     201 B |
|             FromMethod |     29.515 ns |   0.0738 ns |   0.0690 ns |      - |      - |     - |         - |
|             ToProperty |      8.648 ns |   0.0328 ns |   0.0307 ns |      - |      - |     - |         - |
|                     As |      8.646 ns |   0.0270 ns |   0.0252 ns |      - |      - |     - |         - |
|                  As_SI |    487.869 ns |   3.7682 ns |   3.3404 ns | 0.0293 |      - |     - |     201 B |
|                 ToUnit |     19.285 ns |   0.0466 ns |   0.0436 ns |      - |      - |     - |         - |
|              ToUnit_SI |    501.220 ns |   3.0123 ns |   2.6703 ns | 0.0290 |      - |     - |     201 B |
|           ToStringTest |  1,942.218 ns |  10.8852 ns |   8.4985 ns | 0.1829 |      - |     - |    1220 B |
|                  Parse | 51,798.869 ns | 225.8537 ns | 211.2637 ns | 8.3877 | 0.3107 |     - |   54377 B |
|          TryParseValid | 51,676.246 ns | 207.9666 ns | 194.5321 ns | 8.3764 | 0.3102 |     - |   54352 B |
|        TryParseInvalid | 54,518.191 ns | 189.7395 ns | 158.4411 ns | 8.3078 | 0.3279 |     - |   53895 B |
|           QuantityFrom |  2,200.000 ns |  43.8857 ns | 109.2906 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     18.059 ns |   0.0866 ns |   0.0768 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    478.790 ns |   1.6779 ns |   1.5696 ns | 0.0290 |      - |     - |     201 B |
|       IQuantity_ToUnit |     29.145 ns |   0.2803 ns |   0.2622 ns | 0.0088 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,795.633 ns |   7.5384 ns |   7.0515 ns | 0.1840 |      - |     - |    1220 B |
