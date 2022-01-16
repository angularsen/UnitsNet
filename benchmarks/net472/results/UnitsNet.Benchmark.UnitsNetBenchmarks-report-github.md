``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=5.0.404
  [Host]     : .NET Core 5.0.13 (CoreCLR 5.0.1321.56516, CoreFX 5.0.1321.56516), X64 RyuJIT
  Job-VGVYSW : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET 4.7.2  Toolchain=net472  IterationTime=500.0000 ms  

```
|                 Method |          Mean |         Error |        StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |--------------:|--------------:|--------------:|-------:|-------:|------:|----------:|
|            Constructor |     14.965 ns |     0.1301 ns |     0.1086 ns |      - |      - |     - |         - |
|         Constructor_SI |    608.953 ns |     3.8398 ns |     3.4039 ns | 0.0292 |      - |     - |     201 B |
|             FromMethod |     35.655 ns |     0.3539 ns |     0.3311 ns |      - |      - |     - |         - |
|             ToProperty |      9.938 ns |     0.2224 ns |     0.2081 ns |      - |      - |     - |         - |
|                     As |     10.222 ns |     0.2515 ns |     0.2583 ns |      - |      - |     - |         - |
|                  As_SI |    549.297 ns |    10.7836 ns |    18.3115 ns | 0.0295 |      - |     - |     201 B |
|                 ToUnit |     23.015 ns |     0.3784 ns |     0.3540 ns |      - |      - |     - |         - |
|              ToUnit_SI |    609.737 ns |    10.0084 ns |     8.3575 ns | 0.0292 |      - |     - |     201 B |
|           ToStringTest |  2,152.028 ns |    36.2271 ns |    35.5799 ns | 0.1816 |      - |     - |    1220 B |
|                  Parse | 62,969.657 ns | 1,245.7535 ns | 1,575.4794 ns | 8.3099 | 0.2557 |     - |   54377 B |
|          TryParseValid | 64,481.764 ns | 1,247.3452 ns | 1,105.7391 ns | 8.2751 | 0.2586 |     - |   54352 B |
|        TryParseInvalid | 67,755.006 ns |   787.2284 ns |   697.8575 ns | 8.2976 | 0.2677 |     - |   53895 B |
|           QuantityFrom |  2,676.812 ns |    53.2082 ns |   128.5038 ns |      - |      - |     - |    8192 B |
|           IQuantity_As |     21.585 ns |     0.4312 ns |     0.3823 ns | 0.0037 |      - |     - |      24 B |
|        IQuantity_As_SI |    596.181 ns |     6.1788 ns |     5.4774 ns | 0.0284 |      - |     - |     201 B |
|       IQuantity_ToUnit |     35.215 ns |     0.8035 ns |     0.9868 ns | 0.0087 |      - |     - |      56 B |
| IQuantity_ToStringTest |  2,162.344 ns |    24.2804 ns |    20.2752 ns | 0.1842 |      - |     - |    1220 B |
