``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  Job-LRFHSH : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.330 ns |     0.2491 ns |     0.2208 ns |      - |      - |     - |         - |
|         Constructor_SI |    550.946 ns |     5.6766 ns |     5.3099 ns | 0.0280 |      - |     - |     201 B |
|             FromMethod |     38.917 ns |     0.5176 ns |     0.4322 ns |      - |      - |     - |         - |
|             ToProperty |      9.153 ns |     0.1893 ns |     0.1678 ns |      - |      - |     - |         - |
|                     As |      9.162 ns |     0.2221 ns |     0.2558 ns |      - |      - |     - |         - |
|                  As_SI |    555.090 ns |    11.1315 ns |    12.3727 ns | 0.0274 |      - |     - |     201 B |
|                 ToUnit |     24.020 ns |     0.4927 ns |     0.5060 ns |      - |      - |     - |         - |
|              ToUnit_SI |    594.927 ns |    11.4733 ns |    16.4546 ns | 0.0280 |      - |     - |     201 B |
|           ToStringTest |  1,960.661 ns |    31.1925 ns |    29.1775 ns | 0.1848 |      - |     - |    1244 B |
|                  Parse | 62,882.158 ns | 1,242.4490 ns | 1,162.1876 ns | 8.1443 | 0.2506 |     - |   54377 B |
|          TryParseValid | 62,467.915 ns | 1,141.6421 ns | 1,443.8117 ns | 8.1582 | 0.2472 |     - |   54353 B |
|        TryParseInvalid | 66,127.423 ns | 1,181.1684 ns | 1,160.0653 ns | 8.0845 | 0.2608 |     - |   53895 B |
|           QuantityFrom |  2,444.086 ns |    60.9367 ns |   172.8674 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     21.071 ns |     0.2839 ns |     0.2371 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    558.510 ns |    10.9537 ns |    12.1750 ns | 0.0280 |      - |     - |     201 B |
|       IQuantity_ToUnit |     32.887 ns |     0.5581 ns |     0.4948 ns | 0.0086 |      - |     - |      56 B |
| IQuantity_ToStringTest |  1,996.676 ns |    33.2962 ns |    31.1453 ns | 0.1839 |      - |     - |    1244 B |
