``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2029 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.302
  [Host]     : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT
  Job-MZSMUU : .NET Core 5.0.8 (CoreCLR 5.0.821.31504, CoreFX 5.0.821.31504), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50  IterationTime=500.0000 ms  

```
|                 Method |          Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|------------:|------------:|-------:|------:|------:|----------:|
|            Constructor |     11.743 ns |   0.1793 ns |   0.1677 ns |      - |     - |     - |         - |
|         Constructor_SI |    385.063 ns |   4.5704 ns |   4.2752 ns | 0.0100 |     - |     - |     192 B |
|             FromMethod |     30.145 ns |   0.5799 ns |   0.5141 ns |      - |     - |     - |         - |
|             ToProperty |      9.946 ns |   0.1238 ns |   0.1158 ns |      - |     - |     - |         - |
|                     As |     11.188 ns |   0.1644 ns |   0.1538 ns |      - |     - |     - |         - |
|                  As_SI |    371.939 ns |   5.9078 ns |   5.2372 ns | 0.0097 |     - |     - |     192 B |
|                 ToUnit |     20.147 ns |   0.2953 ns |   0.2762 ns |      - |     - |     - |         - |
|              ToUnit_SI |    395.485 ns |   5.1539 ns |   4.8210 ns | 0.0102 |     - |     - |     192 B |
|           ToStringTest |  1,434.963 ns |  23.5803 ns |  25.2306 ns | 0.0481 |     - |     - |     944 B |
|                  Parse | 50,764.023 ns | 427.5405 ns | 379.0035 ns | 1.7229 |     - |     - |   33344 B |
|          TryParseValid | 50,848.244 ns | 350.6925 ns | 328.0379 ns | 1.7407 |     - |     - |   33320 B |
|        TryParseInvalid | 54,939.780 ns | 760.8228 ns | 674.4496 ns | 1.7490 |     - |     - |   32928 B |
|           QuantityFrom |  3,188.679 ns |  59.1687 ns | 123.5070 ns |      - |     - |     - |      56 B |
|           IQuantity_As |     24.015 ns |   0.5162 ns |   0.5301 ns | 0.0013 |     - |     - |      24 B |
|        IQuantity_As_SI |    380.113 ns |   3.4064 ns |   3.1864 ns | 0.0100 |     - |     - |     192 B |
|       IQuantity_ToUnit |     32.358 ns |   0.7376 ns |   0.6899 ns | 0.0029 |     - |     - |      56 B |
| IQuantity_ToStringTest |  1,455.399 ns |  24.1613 ns |  22.6005 ns | 0.0487 |     - |     - |     944 B |
