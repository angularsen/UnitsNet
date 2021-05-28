``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1935 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.300
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  Job-KXUAVV : .NET Core 2.1.28 (CoreCLR 4.6.30015.01, CoreFX 4.6.30015.01), X64 RyuJIT

Runtime=.NET Core 2.1  Toolchain=netcoreapp21  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |        Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     10.931 ns |     0.0774 ns |     0.0724 ns |     10.947 ns |      - |      - |     - |         - |
|         Constructor_SI |    524.491 ns |    10.4604 ns |    17.1867 ns |    529.948 ns | 0.0278 |      - |     - |     192 B |
|             FromMethod |     25.388 ns |     0.2568 ns |     0.2145 ns |     25.478 ns |      - |      - |     - |         - |
|             ToProperty |      8.561 ns |     0.2135 ns |     0.3849 ns |      8.748 ns |      - |      - |     - |         - |
|                     As |      8.756 ns |     0.0212 ns |     0.0198 ns |      8.760 ns |      - |      - |     - |         - |
|                  As_SI |    509.694 ns |    10.0462 ns |    18.8692 ns |    519.379 ns | 0.0286 |      - |     - |     192 B |
|                 ToUnit |     17.652 ns |     0.1454 ns |     0.1289 ns |     17.683 ns |      - |      - |     - |         - |
|              ToUnit_SI |    514.710 ns |    10.2416 ns |    18.9834 ns |    525.442 ns | 0.0283 |      - |     - |     192 B |
|           ToStringTest |  2,041.786 ns |    40.8064 ns |    83.3566 ns |  2,086.554 ns | 0.1430 |      - |     - |     952 B |
|                  Parse | 60,146.867 ns | 1,201.1054 ns | 1,335.0255 ns | 60,528.001 ns | 6.8847 | 0.2151 |     - |   44816 B |
|          TryParseValid | 60,355.836 ns | 1,152.4876 ns | 1,078.0376 ns | 60,580.101 ns | 6.8493 | 0.2403 |     - |   44792 B |
|        TryParseInvalid | 64,423.253 ns | 1,271.3953 ns | 2,625.6517 ns | 65,707.989 ns | 6.7345 | 0.2641 |     - |   44392 B |
|           QuantityFrom |  1,307.778 ns |    43.4316 ns |   121.0699 ns |  1,300.000 ns |      - |      - |     - |      56 B |
|           IQuantity_As |     17.802 ns |     0.3972 ns |     1.0603 ns |     17.897 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    514.556 ns |    10.3217 ns |    19.3866 ns |    519.940 ns | 0.0278 |      - |     - |     192 B |
|       IQuantity_ToUnit |     26.958 ns |     0.1135 ns |     0.1006 ns |     26.965 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,047.611 ns |    39.4989 ns |    55.3720 ns |  2,060.142 ns | 0.1404 |      - |     - |     952 B |
