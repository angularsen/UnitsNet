window.BENCHMARK_DATA = {
  "lastUpdate": 1636704889209,
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
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "7c7cfcfc9e955244a8417d52fbdebbb19570f850",
          "message": "UnitsNet: 4.90.0",
          "timestamp": "2021-05-07T23:23:03+02:00",
          "tree_id": "89daec8f877fa5ad23a94d168fdda1cc669e3e3c",
          "url": "https://github.com/angularsen/UnitsNet/commit/7c7cfcfc9e955244a8417d52fbdebbb19570f850"
        },
        "date": 1620423119043,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.172509116826445,
            "unit": "ns",
            "range": "± 0.1857166932127674"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 371.42847688137624,
            "unit": "ns",
            "range": "± 3.703748253885589"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 28.599327050143607,
            "unit": "ns",
            "range": "± 0.2941603783629173"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.865231459524551,
            "unit": "ns",
            "range": "± 0.14718051348888364"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.914580338141098,
            "unit": "ns",
            "range": "± 0.1734225993199503"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 361.3986400917853,
            "unit": "ns",
            "range": "± 5.757275244508883"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.91509711460368,
            "unit": "ns",
            "range": "± 0.2438385226564378"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 377.4151108316238,
            "unit": "ns",
            "range": "± 4.351719835203201"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1519.4980011062444,
            "unit": "ns",
            "range": "± 48.108422604501335"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 47313.21747668139,
            "unit": "ns",
            "range": "± 762.5884835167649"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 47997.5150729188,
            "unit": "ns",
            "range": "± 1121.277830928795"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 51234.25619312436,
            "unit": "ns",
            "range": "± 948.0754116148437"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2711.1111111111113,
            "unit": "ns",
            "range": "± 279.53638326550816"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.475993483832934,
            "unit": "ns",
            "range": "± 0.2837188578573721"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 347.1937362214295,
            "unit": "ns",
            "range": "± 11.112112109719344"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 28.55715994174552,
            "unit": "ns",
            "range": "± 1.3018049168006407"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1398.809356988434,
            "unit": "ns",
            "range": "± 45.78908505589839"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "9bc3f8d7606f2f9f3b04da4b7a55f639456ef73d",
          "message": "UnitsNet: 4.91.0",
          "timestamp": "2021-05-17T13:58:40+02:00",
          "tree_id": "4ac74e829091aacf70960da873093b36f28f95f6",
          "url": "https://github.com/angularsen/UnitsNet/commit/9bc3f8d7606f2f9f3b04da4b7a55f639456ef73d"
        },
        "date": 1621253304194,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.926704694259058,
            "unit": "ns",
            "range": "± 0.17389265027638198"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 405.7879289037511,
            "unit": "ns",
            "range": "± 8.63124207352224"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.68711480905888,
            "unit": "ns",
            "range": "± 0.4988926569848098"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.807105318552809,
            "unit": "ns",
            "range": "± 0.19635953865762099"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.480266136543346,
            "unit": "ns",
            "range": "± 0.25272476211322303"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 387.21469228829034,
            "unit": "ns",
            "range": "± 9.273870714374377"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.248107004484357,
            "unit": "ns",
            "range": "± 0.276327368385079"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 405.26114760296855,
            "unit": "ns",
            "range": "± 4.366182992007887"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1598.7187999270861,
            "unit": "ns",
            "range": "± 24.640159315621833"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 54702.332729669455,
            "unit": "ns",
            "range": "± 1140.5088638687655"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 56151.016451078685,
            "unit": "ns",
            "range": "± 1604.6518852940255"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 57059.765461398856,
            "unit": "ns",
            "range": "± 682.7638943865926"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3580,
            "unit": "ns",
            "range": "± 268.06182655712627"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 26.42402789795223,
            "unit": "ns",
            "range": "± 0.519088178139987"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 398.48080044691795,
            "unit": "ns",
            "range": "± 6.560534920159444"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 39.590851706709984,
            "unit": "ns",
            "range": "± 0.5759926595494396"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1656.5517128345173,
            "unit": "ns",
            "range": "± 32.972532329664475"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "08752bc5d9b3b519a301572155d8683be9550188",
          "message": "UnitsNet: 4.92.0",
          "timestamp": "2021-05-21T11:35:59+02:00",
          "tree_id": "486a17363fc0e3ccf1fae277ae71fe9c5a312067",
          "url": "https://github.com/angularsen/UnitsNet/commit/08752bc5d9b3b519a301572155d8683be9550188"
        },
        "date": 1621590426898,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.975507432731558,
            "unit": "ns",
            "range": "± 0.5501684617165903"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 311.70237964107037,
            "unit": "ns",
            "range": "± 6.528920330820788"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.907491472503573,
            "unit": "ns",
            "range": "± 0.917876526522211"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.65624268486125,
            "unit": "ns",
            "range": "± 0.2802641022495865"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.485613369903708,
            "unit": "ns",
            "range": "± 0.24882298382418772"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 312.9609619793179,
            "unit": "ns",
            "range": "± 9.916047350601964"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.269123244304186,
            "unit": "ns",
            "range": "± 0.30944670159568866"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 322.35963793982665,
            "unit": "ns",
            "range": "± 10.735510678290277"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1329.5437526059616,
            "unit": "ns",
            "range": "± 71.796092288763"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 44430.95132055648,
            "unit": "ns",
            "range": "± 2449.0662084662995"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 48779.33097568067,
            "unit": "ns",
            "range": "± 1229.2101116661433"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 52483.757421543676,
            "unit": "ns",
            "range": "± 1249.0699823159543"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3175.7894736842104,
            "unit": "ns",
            "range": "± 196.6289244505272"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 23.113480842119063,
            "unit": "ns",
            "range": "± 0.6432935292437244"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 348.7067604624619,
            "unit": "ns",
            "range": "± 8.802801673228258"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.787585082471786,
            "unit": "ns",
            "range": "± 1.260568581966445"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1419.6170137605993,
            "unit": "ns",
            "range": "± 32.245009355336094"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "3941f35a258d7c670d8c56f64c77af7be305be27",
          "message": "UnitsNet: 4.92.1",
          "timestamp": "2021-05-21T22:47:40+02:00",
          "tree_id": "6cebb087590ad5d68218b8696c216ac8f8c0bd33",
          "url": "https://github.com/angularsen/UnitsNet/commit/3941f35a258d7c670d8c56f64c77af7be305be27"
        },
        "date": 1621630633612,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.762680241292953,
            "unit": "ns",
            "range": "± 0.20550809181165872"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 357.01058461954756,
            "unit": "ns",
            "range": "± 7.1372006102422185"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 27.486653866660795,
            "unit": "ns",
            "range": "± 0.7052374461982513"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.647265403940736,
            "unit": "ns",
            "range": "± 0.24436965649841216"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.451381249992513,
            "unit": "ns",
            "range": "± 0.37808977348743045"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 352.64469239020053,
            "unit": "ns",
            "range": "± 7.042236169148197"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.38293341795825,
            "unit": "ns",
            "range": "± 0.46674607936234946"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 362.7273380916743,
            "unit": "ns",
            "range": "± 4.288199546059645"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1397.4641789615885,
            "unit": "ns",
            "range": "± 29.75552361395467"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 48715.93186192505,
            "unit": "ns",
            "range": "± 1344.0692611435604"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 48514.316516971056,
            "unit": "ns",
            "range": "± 731.7191485092964"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 52370.13808379282,
            "unit": "ns",
            "range": "± 1266.8476377098445"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3025.252525252525,
            "unit": "ns",
            "range": "± 307.17389688453596"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 23.033440630109205,
            "unit": "ns",
            "range": "± 0.896450941779016"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 369.11621711161166,
            "unit": "ns",
            "range": "± 10.590952065043025"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.9822614871802,
            "unit": "ns",
            "range": "± 1.0210152128935626"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1500.3819564952305,
            "unit": "ns",
            "range": "± 32.72735001771904"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "59d980c098795945fd5a11ea4bd695934ecc9bd4",
          "message": "UnitsNet: 4.93.0",
          "timestamp": "2021-05-28T23:53:04+02:00",
          "tree_id": "bff33bbf617580f8bacaa25fff56a132320a766e",
          "url": "https://github.com/angularsen/UnitsNet/commit/59d980c098795945fd5a11ea4bd695934ecc9bd4"
        },
        "date": 1622239473809,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.67573923825837,
            "unit": "ns",
            "range": "± 0.35781860473110194"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 363.70947739315466,
            "unit": "ns",
            "range": "± 8.717185704805988"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 32.384510642973325,
            "unit": "ns",
            "range": "± 0.7803121403714632"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.152670511770445,
            "unit": "ns",
            "range": "± 0.2783672364255557"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.102242709151618,
            "unit": "ns",
            "range": "± 0.30595107872281124"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 374.91092687041606,
            "unit": "ns",
            "range": "± 11.495975699067264"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.73176636863918,
            "unit": "ns",
            "range": "± 0.37962250709027917"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 369.47923280432315,
            "unit": "ns",
            "range": "± 6.746534446742487"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1566.3889259511227,
            "unit": "ns",
            "range": "± 30.210937392415666"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 54070.95924213409,
            "unit": "ns",
            "range": "± 1503.507076345057"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 53821.80090936079,
            "unit": "ns",
            "range": "± 1749.2710635202277"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 59183.82776470588,
            "unit": "ns",
            "range": "± 1553.6221840237286"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3520.408163265306,
            "unit": "ns",
            "range": "± 278.41939131182534"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.118320739102444,
            "unit": "ns",
            "range": "± 0.8397931421675153"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 374.90466838128816,
            "unit": "ns",
            "range": "± 10.337720049776458"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.666121621582846,
            "unit": "ns",
            "range": "± 2.1483628875607232"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1541.505681593691,
            "unit": "ns",
            "range": "± 28.65504607704"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "38e1415d8404c3d652568699906718e082568c2b",
          "message": "UnitsNet: 4.94.0",
          "timestamp": "2021-06-13T01:17:49+02:00",
          "tree_id": "4020015118dd7a840bfe802e245c9bc826055aa6",
          "url": "https://github.com/angularsen/UnitsNet/commit/38e1415d8404c3d652568699906718e082568c2b"
        },
        "date": 1623540460837,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.37214187323394,
            "unit": "ns",
            "range": "± 0.22352535300148096"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 388.6505520763111,
            "unit": "ns",
            "range": "± 14.298763443448218"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.755760437195118,
            "unit": "ns",
            "range": "± 0.3808392349072397"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.762806045726311,
            "unit": "ns",
            "range": "± 0.14818839858203828"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.137036837556018,
            "unit": "ns",
            "range": "± 0.16630334715522074"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 388.89109309471866,
            "unit": "ns",
            "range": "± 6.222279923816166"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.121063272839802,
            "unit": "ns",
            "range": "± 0.22933734423906857"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 403.5347565620441,
            "unit": "ns",
            "range": "± 5.631162086819011"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1620.8675131787456,
            "unit": "ns",
            "range": "± 28.24344242947749"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 53630.76025872123,
            "unit": "ns",
            "range": "± 1081.2674164452987"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 54644.36052366566,
            "unit": "ns",
            "range": "± 836.3560460054458"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 56918.38346727899,
            "unit": "ns",
            "range": "± 975.9784707859387"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3470.909090909091,
            "unit": "ns",
            "range": "± 146.15152876473567"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 26.005834388033282,
            "unit": "ns",
            "range": "± 0.5802771671534331"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 390.15664909600844,
            "unit": "ns",
            "range": "± 3.8541504147582817"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 36.7658502925853,
            "unit": "ns",
            "range": "± 1.0716203600957175"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1599.8643641869908,
            "unit": "ns",
            "range": "± 21.328176286612226"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "34bd90c7cebc8aa4f4199b2445c05c6358fdf7c2",
          "message": "UnitsNet: 4.95.0",
          "timestamp": "2021-06-17T11:07:10+02:00",
          "tree_id": "d912f5cb02ea934078da5e6ea0049e66c2f004b8",
          "url": "https://github.com/angularsen/UnitsNet/commit/34bd90c7cebc8aa4f4199b2445c05c6358fdf7c2"
        },
        "date": 1623921623688,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.501217368296448,
            "unit": "ns",
            "range": "± 0.028902339227663488"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 316.5483539135129,
            "unit": "ns",
            "range": "± 0.7894344243074861"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.435834537229862,
            "unit": "ns",
            "range": "± 0.10647759614937029"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.68842081288387,
            "unit": "ns",
            "range": "± 0.026627183274155086"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.420377857719249,
            "unit": "ns",
            "range": "± 0.029784763850915955"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 318.16023274863426,
            "unit": "ns",
            "range": "± 1.9316131499760043"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.33674562051792,
            "unit": "ns",
            "range": "± 0.02622882280732247"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 323.7656550610381,
            "unit": "ns",
            "range": "± 0.9282596198746801"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1305.5045045213396,
            "unit": "ns",
            "range": "± 10.295292828324644"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 43400.375094237024,
            "unit": "ns",
            "range": "± 280.79103939412875"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 44637.118309942045,
            "unit": "ns",
            "range": "± 510.35299257987356"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 48049.7350281414,
            "unit": "ns",
            "range": "± 237.25681538760827"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2800,
            "unit": "ns",
            "range": "± 97.33285267845751"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.30787083614761,
            "unit": "ns",
            "range": "± 0.1321785146027516"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 323.82810407801935,
            "unit": "ns",
            "range": "± 1.597857600782717"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.416656328808067,
            "unit": "ns",
            "range": "± 0.44778008561927973"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1331.743966415444,
            "unit": "ns",
            "range": "± 6.6294737851957795"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "2582139041e7eb82b95f5e363affcaff7d2abd3f",
          "message": "UnitsNet: 4.97.0",
          "timestamp": "2021-06-29T23:19:22+02:00",
          "tree_id": "bc66711be2e9540b9acf3bdf6cc9b7aa344237e6",
          "url": "https://github.com/angularsen/UnitsNet/commit/2582139041e7eb82b95f5e363affcaff7d2abd3f"
        },
        "date": 1625002231994,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.568108509375664,
            "unit": "ns",
            "range": "± 0.1772690017988108"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 380.71825775948656,
            "unit": "ns",
            "range": "± 2.4363520808965924"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.35435535637709,
            "unit": "ns",
            "range": "± 0.2610086388867241"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.461637171265746,
            "unit": "ns",
            "range": "± 0.0798915784868106"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 11.08250736400062,
            "unit": "ns",
            "range": "± 0.07436526331036988"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 381.2647178853116,
            "unit": "ns",
            "range": "± 5.1191764463257625"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.60890248245845,
            "unit": "ns",
            "range": "± 0.13813119703352464"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 391.8662615740741,
            "unit": "ns",
            "range": "± 2.913405681028316"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1481.7016420440011,
            "unit": "ns",
            "range": "± 20.342250646479755"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 52545.75347309183,
            "unit": "ns",
            "range": "± 1236.9774661457332"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 52437.37515246559,
            "unit": "ns",
            "range": "± 392.4646843630304"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 57366.042070828116,
            "unit": "ns",
            "range": "± 928.0398483602684"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3436,
            "unit": "ns",
            "range": "± 171.35390909507188"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 25.54062243485526,
            "unit": "ns",
            "range": "± 0.20276101503067395"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 394.3696350291258,
            "unit": "ns",
            "range": "± 2.5555347572747973"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 36.52702134505222,
            "unit": "ns",
            "range": "± 0.35304920172419846"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1501.6704771518077,
            "unit": "ns",
            "range": "± 25.480519694969153"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "d36819b1e689f0ac73a8f6e8d457481a9d98dbe4",
          "message": "UnitsNet: 4.97.1",
          "timestamp": "2021-07-05T18:04:35+02:00",
          "tree_id": "262bcc2d69f8d20357dc30ce152c1b42bb72eabb",
          "url": "https://github.com/angularsen/UnitsNet/commit/d36819b1e689f0ac73a8f6e8d457481a9d98dbe4"
        },
        "date": 1625501820020,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 10.726292593615664,
            "unit": "ns",
            "range": "± 0.3635316230584295"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 335.27059504890656,
            "unit": "ns",
            "range": "± 8.384497786573835"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 28.06202133465722,
            "unit": "ns",
            "range": "± 0.6951946655189181"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.399046937219243,
            "unit": "ns",
            "range": "± 0.13851186356982903"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.610084021979633,
            "unit": "ns",
            "range": "± 0.30770442862212405"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 352.43885210419137,
            "unit": "ns",
            "range": "± 8.175420627610418"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.47907264494389,
            "unit": "ns",
            "range": "± 0.541123596872777"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 358.2409627953747,
            "unit": "ns",
            "range": "± 11.42587271473287"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1361.2425707837892,
            "unit": "ns",
            "range": "± 30.69161505308309"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 49979.246216030275,
            "unit": "ns",
            "range": "± 1395.6520939679701"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 51777.52377205063,
            "unit": "ns",
            "range": "± 1455.1505050330434"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 53782.50552287338,
            "unit": "ns",
            "range": "± 669.8109310774347"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3515.8536585365855,
            "unit": "ns",
            "range": "± 178.79536008778027"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.79683903356794,
            "unit": "ns",
            "range": "± 0.4826790779335878"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 342.0366774972949,
            "unit": "ns",
            "range": "± 5.66156007313657"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 29.91828962904491,
            "unit": "ns",
            "range": "± 1.5281564458149113"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1368.2662514503154,
            "unit": "ns",
            "range": "± 51.960236790948585"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "0202c0785db605ecb6f27a53bf574060f6c73461",
          "message": "JsonNet: 4.4.0",
          "timestamp": "2021-07-16T11:45:01+02:00",
          "tree_id": "3af160975622947fe4a0b2ead992f25b5bb014df",
          "url": "https://github.com/angularsen/UnitsNet/commit/0202c0785db605ecb6f27a53bf574060f6c73461"
        },
        "date": 1626429194829,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.743372582740015,
            "unit": "ns",
            "range": "± 0.16769159937280256"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 385.0627302096837,
            "unit": "ns",
            "range": "± 4.275173882919899"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.145123791688775,
            "unit": "ns",
            "range": "± 0.5140652101938497"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.945624203174798,
            "unit": "ns",
            "range": "± 0.11584137495690819"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 11.188143755280134,
            "unit": "ns",
            "range": "± 0.15378069434821984"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 371.93912413062117,
            "unit": "ns",
            "range": "± 5.237150750098371"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.147092439374678,
            "unit": "ns",
            "range": "± 0.27622294184836166"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 395.4852635922573,
            "unit": "ns",
            "range": "± 4.820984573833685"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1434.963455834556,
            "unit": "ns",
            "range": "± 25.230634482955463"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 50764.022933588145,
            "unit": "ns",
            "range": "± 379.00349086783945"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 50848.24356611373,
            "unit": "ns",
            "range": "± 328.03793736390975"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 54939.779967518276,
            "unit": "ns",
            "range": "± 674.4495565578056"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3188.6792452830186,
            "unit": "ns",
            "range": "± 123.50704956287777"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.014855842672517,
            "unit": "ns",
            "range": "± 0.5301208698377549"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 380.11260267705796,
            "unit": "ns",
            "range": "± 3.1863764211212176"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.35834425945674,
            "unit": "ns",
            "range": "± 0.6899075496390147"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1455.3990747420614,
            "unit": "ns",
            "range": "± 22.600524128590685"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "e263703d96fffce76cf5e665b2faece8684749a2",
          "message": "UnitsNet: 4.99.0",
          "timestamp": "2021-07-20T20:19:53+02:00",
          "tree_id": "da9711566d60004e73759d23781bac5c30fd2b5b",
          "url": "https://github.com/angularsen/UnitsNet/commit/e263703d96fffce76cf5e665b2faece8684749a2"
        },
        "date": 1626805696734,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.51729210447864,
            "unit": "ns",
            "range": "± 0.027273462313026842"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 318.2345652136797,
            "unit": "ns",
            "range": "± 0.9398727160896666"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.446089627080358,
            "unit": "ns",
            "range": "± 0.07038590463554226"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.562983498361579,
            "unit": "ns",
            "range": "± 0.016906438147605903"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.167845311364244,
            "unit": "ns",
            "range": "± 0.018348859959358536"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 323.73301438801616,
            "unit": "ns",
            "range": "± 1.5404051020648963"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.230044245986754,
            "unit": "ns",
            "range": "± 0.05289160357543689"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 326.64966865854586,
            "unit": "ns",
            "range": "± 1.1863284311713689"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1219.6412499114845,
            "unit": "ns",
            "range": "± 10.150723006830718"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 43204.9492804043,
            "unit": "ns",
            "range": "± 373.3944958868301"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 43730.1306341379,
            "unit": "ns",
            "range": "± 223.5418298756701"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 46569.934609995325,
            "unit": "ns",
            "range": "± 168.2199005948011"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2820,
            "unit": "ns",
            "range": "± 85.33493588238807"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.52864769970885,
            "unit": "ns",
            "range": "± 0.3408416813166958"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 323.898917896132,
            "unit": "ns",
            "range": "± 1.0718678163005817"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 28.61176033006509,
            "unit": "ns",
            "range": "± 0.31053464776766165"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1256.132753891818,
            "unit": "ns",
            "range": "± 7.5760344248153775"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "d35c7edea067a9fd3f94952d8e1305dee05df1c4",
          "message": "UnitsNet: 4.100.0",
          "timestamp": "2021-08-06T00:39:36+02:00",
          "tree_id": "e6a8c8630a1981bcafcc21db4f69ac4290507cf5",
          "url": "https://github.com/angularsen/UnitsNet/commit/d35c7edea067a9fd3f94952d8e1305dee05df1c4"
        },
        "date": 1628203669213,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.51764584906505,
            "unit": "ns",
            "range": "± 0.02621114278240196"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 323.4704923666508,
            "unit": "ns",
            "range": "± 1.384952374399113"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.50344674284371,
            "unit": "ns",
            "range": "± 0.05828297602724347"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.693689169552067,
            "unit": "ns",
            "range": "± 0.016026171809579073"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.157597187343198,
            "unit": "ns",
            "range": "± 0.021118581934271772"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 315.70781523300053,
            "unit": "ns",
            "range": "± 1.2731736686806796"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.239304558450197,
            "unit": "ns",
            "range": "± 0.035563231657789456"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 322.77840788564316,
            "unit": "ns",
            "range": "± 1.4681607279171003"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1273.49657344579,
            "unit": "ns",
            "range": "± 12.63250588909446"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 43261.875518197674,
            "unit": "ns",
            "range": "± 384.04081020114984"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 43985.643964852025,
            "unit": "ns",
            "range": "± 243.00784593311633"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 46921.29179800977,
            "unit": "ns",
            "range": "± 438.6165773053191"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2739.3939393939395,
            "unit": "ns",
            "range": "± 86.38357026727482"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.889716713556606,
            "unit": "ns",
            "range": "± 0.2327412607846068"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 321.17626808226436,
            "unit": "ns",
            "range": "± 1.223348114013606"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 29.771021340829808,
            "unit": "ns",
            "range": "± 0.6789554922588164"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1222.9057675633446,
            "unit": "ns",
            "range": "± 11.331591658066717"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "tristan.milnthorp@ansys.com",
            "name": "Tristan Milnthorp",
            "username": "tmilnthorp"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "8e603bf21a96e968efe30046bc7e3a62c68bcbb3",
          "message": "Only reference System.ValueTuple in net40 (#960)",
          "timestamp": "2021-08-11T21:53:02+02:00",
          "tree_id": "bc1328bc7d11d4bbd992c55677e3cdabfa3cd16b",
          "url": "https://github.com/angularsen/UnitsNet/commit/8e603bf21a96e968efe30046bc7e3a62c68bcbb3"
        },
        "date": 1628712245511,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.521707091239655,
            "unit": "ns",
            "range": "± 0.027188902890488004"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 319.84307577338586,
            "unit": "ns",
            "range": "± 1.1259057131834642"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.423225693013798,
            "unit": "ns",
            "range": "± 0.06317983439450635"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.592372587182128,
            "unit": "ns",
            "range": "± 0.022865762718449735"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.161559736312778,
            "unit": "ns",
            "range": "± 0.022959604302610126"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 318.1036305937482,
            "unit": "ns",
            "range": "± 0.5625268530287885"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.260287097787224,
            "unit": "ns",
            "range": "± 0.032411044516018735"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 326.90721136208793,
            "unit": "ns",
            "range": "± 0.5724920551438626"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1328.069697338505,
            "unit": "ns",
            "range": "± 7.616191578525887"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 44878.37685105508,
            "unit": "ns",
            "range": "± 163.515984923392"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 44680.70623233675,
            "unit": "ns",
            "range": "± 226.4400887672253"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 47633.59912865748,
            "unit": "ns",
            "range": "± 148.52125358613077"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2705.5555555555557,
            "unit": "ns",
            "range": "± 107.13536960959082"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.38032761944667,
            "unit": "ns",
            "range": "± 0.07002406465176435"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 322.17104651595145,
            "unit": "ns",
            "range": "± 0.4329290007862577"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.749232728687637,
            "unit": "ns",
            "range": "± 0.22890731599569344"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1332.2538120633967,
            "unit": "ns",
            "range": "± 5.6149381917322945"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "f8b54550ec941357a75bc5d906542d255350156d",
          "message": "UnitsNet: 4.102.0",
          "timestamp": "2021-09-03T17:12:38+02:00",
          "tree_id": "78beb8d8cb6d6470322558367b67a2dc492278eb",
          "url": "https://github.com/angularsen/UnitsNet/commit/f8b54550ec941357a75bc5d906542d255350156d"
        },
        "date": 1630682524171,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.523674972767655,
            "unit": "ns",
            "range": "± 0.02888035265839506"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 319.82453197712147,
            "unit": "ns",
            "range": "± 6.712260762286444"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.465728550348842,
            "unit": "ns",
            "range": "± 0.8184772172003502"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.58789724211654,
            "unit": "ns",
            "range": "± 0.03118652699228775"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.409900365688776,
            "unit": "ns",
            "range": "± 0.03135972771002982"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 319.1211089793573,
            "unit": "ns",
            "range": "± 0.6412798649020753"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.22080352709337,
            "unit": "ns",
            "range": "± 0.03956997230028066"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 326.3285359138725,
            "unit": "ns",
            "range": "± 1.9487804957705832"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1311.463676196534,
            "unit": "ns",
            "range": "± 29.42145534523374"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 43895.707514736074,
            "unit": "ns",
            "range": "± 1409.0931676980802"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 44818.13676841818,
            "unit": "ns",
            "range": "± 303.4552497164756"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 47645.79365079366,
            "unit": "ns",
            "range": "± 768.2188262638408"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2544.4444444444443,
            "unit": "ns",
            "range": "± 96.66144186507019"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.201428935976814,
            "unit": "ns",
            "range": "± 0.11604267897093011"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 319.85498444102046,
            "unit": "ns",
            "range": "± 6.461710257312621"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.650064912718864,
            "unit": "ns",
            "range": "± 0.2557349048137043"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1339.4938886147286,
            "unit": "ns",
            "range": "± 32.71110675772667"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "888061fa75c75106e82ba268d0a16c4bbf61d366",
          "message": "Revert unintentional change to fix compile error",
          "timestamp": "2021-09-30T22:53:33+02:00",
          "tree_id": "fa4ae4810f31759b18cd6852fc39ea8c38f0430a",
          "url": "https://github.com/angularsen/UnitsNet/commit/888061fa75c75106e82ba268d0a16c4bbf61d366"
        },
        "date": 1633035765564,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.043772306701314,
            "unit": "ns",
            "range": "± 0.27061388363237143"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 380.19626314208466,
            "unit": "ns",
            "range": "± 10.175652227986768"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.896764343166872,
            "unit": "ns",
            "range": "± 0.7295431733581983"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.32631635375053,
            "unit": "ns",
            "range": "± 0.21763084755979448"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.950547605962363,
            "unit": "ns",
            "range": "± 0.2089072718362323"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 356.4688002444955,
            "unit": "ns",
            "range": "± 4.658920219492589"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.026400092654118,
            "unit": "ns",
            "range": "± 0.36993358306426843"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 398.7083920593003,
            "unit": "ns",
            "range": "± 9.367999249366479"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1435.567594439015,
            "unit": "ns",
            "range": "± 38.13059282488733"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 52775.72549748399,
            "unit": "ns",
            "range": "± 1025.4435501919927"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 55840.354267310766,
            "unit": "ns",
            "range": "± 1565.6805315510421"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 57618.13754322176,
            "unit": "ns",
            "range": "± 1609.0654036395072"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3977.0833333333335,
            "unit": "ns",
            "range": "± 301.7420183104022"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.011624162405134,
            "unit": "ns",
            "range": "± 0.9292555691326505"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 370.4683598532444,
            "unit": "ns",
            "range": "± 6.996465176105469"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.50648057141177,
            "unit": "ns",
            "range": "± 1.396250753571679"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1501.0875815932568,
            "unit": "ns",
            "range": "± 44.268778348380984"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "committer": {
            "email": "andreas.larsen84@gmail.com",
            "name": "Andreas Gullberg Larsen",
            "username": "angularsen"
          },
          "distinct": true,
          "id": "6be7065e62b3a48ee75be8f7d14edf3fe6287910",
          "message": "UnitsNet: 4.103.0",
          "timestamp": "2021-11-12T09:05:57+01:00",
          "tree_id": "2d7786f04db8e557609b8e51947bf838afa0699b",
          "url": "https://github.com/angularsen/UnitsNet/commit/6be7065e62b3a48ee75be8f7d14edf3fe6287910"
        },
        "date": 1636704832273,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.532332434495066,
            "unit": "ns",
            "range": "± 0.022485054336140745"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 342.16719607142585,
            "unit": "ns",
            "range": "± 1.4178002748823"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.48900427256514,
            "unit": "ns",
            "range": "± 0.0697895079822069"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.594342216268366,
            "unit": "ns",
            "range": "± 0.025307583993058026"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.157732257415697,
            "unit": "ns",
            "range": "± 0.020029881918266722"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 317.21994984960406,
            "unit": "ns",
            "range": "± 1.5566808430489814"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.24449937034029,
            "unit": "ns",
            "range": "± 0.035261452410014237"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 322.35040420034994,
            "unit": "ns",
            "range": "± 2.2946296875730474"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1243.6996403148373,
            "unit": "ns",
            "range": "± 7.301063992640489"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 42942.99905958793,
            "unit": "ns",
            "range": "± 398.0682105170202"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 43496.88383492933,
            "unit": "ns",
            "range": "± 717.3023332628258"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 46868.98920575693,
            "unit": "ns",
            "range": "± 382.2934679031479"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3667.3076923076924,
            "unit": "ns",
            "range": "± 150.45180825212717"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.725253554418718,
            "unit": "ns",
            "range": "± 0.6213267357475099"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 339.5507243616948,
            "unit": "ns",
            "range": "± 2.554018355222024"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 26.61123295997782,
            "unit": "ns",
            "range": "± 0.5962784756241776"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1271.442961432783,
            "unit": "ns",
            "range": "± 15.851715630535821"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "efortin76@gmail.com",
            "name": "Étienne Fortin",
            "username": "ebfortin"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "24e8e28bb5db3365875d1ec3815538d614028dcb",
          "message": "Add Duration.JulianYear (#978)\n\nCo-authored-by: Andreas Gullberg Larsen <andreas.larsen84@gmail.com>",
          "timestamp": "2021-11-12T09:05:20+01:00",
          "tree_id": "c2698667dd0247627ad664de729a67fd3f0eb6de",
          "url": "https://github.com/angularsen/UnitsNet/commit/24e8e28bb5db3365875d1ec3815538d614028dcb"
        },
        "date": 1636704888455,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 8.683895296943003,
            "unit": "ns",
            "range": "± 0.1976363107561934"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 287.3421274123548,
            "unit": "ns",
            "range": "± 7.881111157478387"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 22.065779514235146,
            "unit": "ns",
            "range": "± 0.6202561517510565"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 7.9852241886626665,
            "unit": "ns",
            "range": "± 0.18981070537199848"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 7.628224279115748,
            "unit": "ns",
            "range": "± 0.1615791353350079"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 294.41015374458317,
            "unit": "ns",
            "range": "± 4.127503732950118"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 14.818012489936246,
            "unit": "ns",
            "range": "± 0.2686443309656667"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 302.5308140527065,
            "unit": "ns",
            "range": "± 9.157231006902117"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1187.6227095673942,
            "unit": "ns",
            "range": "± 42.93182355346332"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 41146.90491696516,
            "unit": "ns",
            "range": "± 767.5200392443322"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 41279.20956648603,
            "unit": "ns",
            "range": "± 1276.1075896571194"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 43025.02015755941,
            "unit": "ns",
            "range": "± 977.9304179712655"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3612.280701754386,
            "unit": "ns",
            "range": "± 154.76961615644416"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 17.79022498170559,
            "unit": "ns",
            "range": "± 0.8712729654907325"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 296.4533600330926,
            "unit": "ns",
            "range": "± 7.773757343655928"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 25.314491149144516,
            "unit": "ns",
            "range": "± 1.1736220227695866"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1159.4560196199773,
            "unit": "ns",
            "range": "± 31.879093046798157"
          }
        ]
      }
    ]
  }
}