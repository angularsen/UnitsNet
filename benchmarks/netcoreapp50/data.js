window.BENCHMARK_DATA = {
  "lastUpdate": 1623921624437,
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
      }
    ]
  }
}