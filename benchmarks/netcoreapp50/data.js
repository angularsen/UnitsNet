window.BENCHMARK_DATA = {
  "lastUpdate": 1619833917417,
  "repoUrl": "https://github.com/angularsen/UnitsNet",
  "entries": {
    "UnitsNet Benchmarks (netcoreapp50)": [
      {
        "commit": {
          "author": {
            "email": "lipchev@gmail.com",
            "name": "lipchev",
            "username": "lipchev"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "0f39bec5fb0843821cfe0835a93260ba816da6c2",
          "message": "Merge pull request #923 from lipchev/benchmark-workflows\n\nAdding benchmark workflows",
          "timestamp": "2021-05-01T00:41:21+03:00",
          "tree_id": "629160691b70e08113bd3e3f2feb12f119eee6f4",
          "url": "https://github.com/angularsen/UnitsNet/commit/0f39bec5fb0843821cfe0835a93260ba816da6c2"
        },
        "date": 1619819496219,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.885047153752135,
            "unit": "ns",
            "range": "± 0.1279005844703242"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 304.2678550705392,
            "unit": "ns",
            "range": "± 5.739269560621526"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 26.615457671535115,
            "unit": "ns",
            "range": "± 0.5291188278799794"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.083759633573635,
            "unit": "ns",
            "range": "± 0.28470191530837824"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.122832398258808,
            "unit": "ns",
            "range": "± 0.21884402458261967"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 317.23194326596405,
            "unit": "ns",
            "range": "± 8.269648655251215"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.40352550669787,
            "unit": "ns",
            "range": "± 0.3089460710460945"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 319.0624164763596,
            "unit": "ns",
            "range": "± 5.796288965207915"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1268.8808274687522,
            "unit": "ns",
            "range": "± 27.641243459940373"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 47973.86506893408,
            "unit": "ns",
            "range": "± 1372.2166447749137"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 46413.37747159346,
            "unit": "ns",
            "range": "± 1385.2277205478667"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 49298.78860201056,
            "unit": "ns",
            "range": "± 1207.8375818796487"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3021.7391304347825,
            "unit": "ns",
            "range": "± 144.3744775568763"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 17.396978477026224,
            "unit": "ns",
            "range": "± 0.6765852917614826"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 314.01685304991435,
            "unit": "ns",
            "range": "± 4.562115015057172"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 25.816514621951274,
            "unit": "ns",
            "range": "± 0.8739300796931313"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1319.6720618241718,
            "unit": "ns",
            "range": "± 34.212040173306804"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "lipchev@gmail.com",
            "name": "lipchev",
            "username": "lipchev"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "3bca803d0beb9c6e5da35b250d25c3aa09ddc807",
          "message": "Update continious-benchmarking.yml\n\nworkflow should only run on the main repository",
          "timestamp": "2021-05-01T04:23:34+03:00",
          "tree_id": "ffa3044720f9f19dd674ab3048f42b98ae2cc121",
          "url": "https://github.com/angularsen/UnitsNet/commit/3bca803d0beb9c6e5da35b250d25c3aa09ddc807"
        },
        "date": 1619832795337,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.33915919237482,
            "unit": "ns",
            "range": "± 0.19323028047495727"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 377.26550978819256,
            "unit": "ns",
            "range": "± 5.832529521038225"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.772950476337297,
            "unit": "ns",
            "range": "± 0.1640976639765854"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.605083755544106,
            "unit": "ns",
            "range": "± 0.097895620112851"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.68936346644049,
            "unit": "ns",
            "range": "± 0.22380441197986542"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 409.88524978578664,
            "unit": "ns",
            "range": "± 6.405245614500245"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.74912814828224,
            "unit": "ns",
            "range": "± 0.30434565979227635"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 386.1884259634781,
            "unit": "ns",
            "range": "± 4.9600659207547455"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1624.068956458365,
            "unit": "ns",
            "range": "± 23.042770066181784"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 55940.53800391679,
            "unit": "ns",
            "range": "± 853.8567030451263"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 57506.724463849576,
            "unit": "ns",
            "range": "± 1580.9457299644826"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 59684.31748010925,
            "unit": "ns",
            "range": "± 1104.6458443048296"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3631.5789473684213,
            "unit": "ns",
            "range": "± 207.44810060757055"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.29736679970541,
            "unit": "ns",
            "range": "± 0.25942542929537965"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 394.63783343656115,
            "unit": "ns",
            "range": "± 3.800871076057208"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 36.84306421981306,
            "unit": "ns",
            "range": "± 0.5656533968342595"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1587.2271114262217,
            "unit": "ns",
            "range": "± 13.588795049323732"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "lipchev@gmail.com",
            "name": "lipchev",
            "username": "lipchev"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "3bca803d0beb9c6e5da35b250d25c3aa09ddc807",
          "message": "Update continious-benchmarking.yml\n\nworkflow should only run on the main repository",
          "timestamp": "2021-05-01T04:23:34+03:00",
          "tree_id": "ffa3044720f9f19dd674ab3048f42b98ae2cc121",
          "url": "https://github.com/angularsen/UnitsNet/commit/3bca803d0beb9c6e5da35b250d25c3aa09ddc807"
        },
        "date": 1619833916474,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.402326869007927,
            "unit": "ns",
            "range": "± 0.21848329112947398"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 346.28835276617457,
            "unit": "ns",
            "range": "± 8.71206458331903"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 28.41606209295486,
            "unit": "ns",
            "range": "± 0.477117112823249"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.482921102091002,
            "unit": "ns",
            "range": "± 0.189347699468908"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.349365769750463,
            "unit": "ns",
            "range": "± 0.17041017304792552"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 338.5062966377745,
            "unit": "ns",
            "range": "± 7.527893937192902"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 17.8653571280346,
            "unit": "ns",
            "range": "± 0.33620948606329737"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 341.91384559215487,
            "unit": "ns",
            "range": "± 7.768854768585348"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1390.1907582778426,
            "unit": "ns",
            "range": "± 47.163624729087296"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 47677.928469089005,
            "unit": "ns",
            "range": "± 1099.720234771359"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 47900.09039992139,
            "unit": "ns",
            "range": "± 735.3572006478812"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 52116.8040917545,
            "unit": "ns",
            "range": "± 1175.2345584029472"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3459.7402597402597,
            "unit": "ns",
            "range": "± 176.4114063173893"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 17.406650192152533,
            "unit": "ns",
            "range": "± 0.2765059777869785"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 335.0586283968701,
            "unit": "ns",
            "range": "± 8.294823524899801"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 27.196551484572453,
            "unit": "ns",
            "range": "± 0.6666195096165197"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1444.0084290987907,
            "unit": "ns",
            "range": "± 24.98483026092894"
          }
        ]
      }
    ]
  }
}