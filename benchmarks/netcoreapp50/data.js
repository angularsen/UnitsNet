window.BENCHMARK_DATA = {
  "lastUpdate": 1644354994385,
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
          "id": "ca757677c49699a1f9a8358df8889efdc2d190c3",
          "message": "UnitsNet: 4.104.0",
          "timestamp": "2021-11-15T11:20:41+01:00",
          "tree_id": "86881d619917fa1293f5316e32ec14d534f39644",
          "url": "https://github.com/angularsen/UnitsNet/commit/ca757677c49699a1f9a8358df8889efdc2d190c3"
        },
        "date": 1636972339943,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.713097440006816,
            "unit": "ns",
            "range": "± 0.17968764378773394"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 396.8602372762034,
            "unit": "ns",
            "range": "± 8.159656272157504"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.303584037940002,
            "unit": "ns",
            "range": "± 0.5370529217010676"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.025598737511771,
            "unit": "ns",
            "range": "± 0.10995310654679696"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 11.27426664053755,
            "unit": "ns",
            "range": "± 0.23605097501783492"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 399.0010068527705,
            "unit": "ns",
            "range": "± 9.912166907037415"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.997972259553578,
            "unit": "ns",
            "range": "± 0.23496291919610776"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 416.80638179698326,
            "unit": "ns",
            "range": "± 6.743087703909335"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1618.970039840268,
            "unit": "ns",
            "range": "± 28.442957212474195"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 56057.36154417223,
            "unit": "ns",
            "range": "± 766.2875169117658"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 53811.77162330805,
            "unit": "ns",
            "range": "± 1294.0082368189069"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 59205.82727272727,
            "unit": "ns",
            "range": "± 1017.0400731755616"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 4265.517241379311,
            "unit": "ns",
            "range": "± 186.8968419264517"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 25.006684285028754,
            "unit": "ns",
            "range": "± 0.4386278468596825"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 400.75494679283304,
            "unit": "ns",
            "range": "± 3.991561211355444"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 36.08257685264889,
            "unit": "ns",
            "range": "± 0.6439979199687952"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1617.134258772423,
            "unit": "ns",
            "range": "± 26.933877135927183"
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
          "id": "041c0f452a6f3fd067b7927b33d6c7a9d28a0dfd",
          "message": "UnitsNet: 4.105.0",
          "timestamp": "2021-11-22T18:08:28+01:00",
          "tree_id": "a8735f5745c20e48fad922651370c0f1912feb7c",
          "url": "https://github.com/angularsen/UnitsNet/commit/041c0f452a6f3fd067b7927b33d6c7a9d28a0dfd"
        },
        "date": 1637601521860,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.647123056765285,
            "unit": "ns",
            "range": "± 0.3803183452281631"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 393.5529485520342,
            "unit": "ns",
            "range": "± 12.999879359277227"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.063543810611236,
            "unit": "ns",
            "range": "± 0.7483238856697767"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.357602805423825,
            "unit": "ns",
            "range": "± 0.2041623536268952"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.300287624675864,
            "unit": "ns",
            "range": "± 0.22075173046654326"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 389.41768759023194,
            "unit": "ns",
            "range": "± 11.584569166698707"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.77596290390766,
            "unit": "ns",
            "range": "± 0.2155820565672716"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 409.44432451120343,
            "unit": "ns",
            "range": "± 10.519138122136736"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1540.4839822638128,
            "unit": "ns",
            "range": "± 57.78601599553383"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 54785.8514780226,
            "unit": "ns",
            "range": "± 1448.3757891183252"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 56808.96419291379,
            "unit": "ns",
            "range": "± 1805.3227456335565"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 60123.19682273581,
            "unit": "ns",
            "range": "± 1772.6603496697003"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 4298.717948717948,
            "unit": "ns",
            "range": "± 220.6799349728781"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.621732376973096,
            "unit": "ns",
            "range": "± 0.34860364307125974"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 391.0853347849214,
            "unit": "ns",
            "range": "± 8.053534099134213"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 34.78301934417337,
            "unit": "ns",
            "range": "± 2.330191268532185"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1582.0836231950016,
            "unit": "ns",
            "range": "± 53.037488830307765"
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
          "id": "463f970fa801d3603013922ce50ee6e718fbdc9f",
          "message": "UnitsNet: 4.106.0",
          "timestamp": "2021-11-23T23:20:56+01:00",
          "tree_id": "a332c1fae10a93c71a7f3cd313989f7fc1571b50",
          "url": "https://github.com/angularsen/UnitsNet/commit/463f970fa801d3603013922ce50ee6e718fbdc9f"
        },
        "date": 1637706547515,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.620777332344131,
            "unit": "ns",
            "range": "± 0.13245049458448716"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 325.596123050512,
            "unit": "ns",
            "range": "± 7.917207597746909"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 26.933473247899457,
            "unit": "ns",
            "range": "± 0.4121227823764104"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.455136602330828,
            "unit": "ns",
            "range": "± 0.12641924311602515"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.452998295649982,
            "unit": "ns",
            "range": "± 0.06614002547286948"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 299.3237657988989,
            "unit": "ns",
            "range": "± 6.042258437745029"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.898956239921667,
            "unit": "ns",
            "range": "± 0.20820023212472472"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 321.5352819154439,
            "unit": "ns",
            "range": "± 4.530876307401342"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1245.9772630984996,
            "unit": "ns",
            "range": "± 50.58286610330385"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 44617.11167159506,
            "unit": "ns",
            "range": "± 780.5740732109587"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 45948.07667282616,
            "unit": "ns",
            "range": "± 800.9509009741018"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 48847.4967107541,
            "unit": "ns",
            "range": "± 474.96459880074923"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 4122.784810126583,
            "unit": "ns",
            "range": "± 214.20656642512844"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 16.478043638328426,
            "unit": "ns",
            "range": "± 0.32380268176118127"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 315.8330436939495,
            "unit": "ns",
            "range": "± 2.8399191056925357"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 25.416699228891545,
            "unit": "ns",
            "range": "± 0.31574059562067214"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1254.2792415439035,
            "unit": "ns",
            "range": "± 26.671231381604944"
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
          "id": "cbbaf4782a0af1d1726f63a215d480de6f0cd87a",
          "message": "UnitsNet: 4.107.0",
          "timestamp": "2021-11-23T23:22:58+01:00",
          "tree_id": "7524e92f9a30dc6a876b29ec061262d5d4bb6615",
          "url": "https://github.com/angularsen/UnitsNet/commit/cbbaf4782a0af1d1726f63a215d480de6f0cd87a"
        },
        "date": 1637706762979,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 8.874583567645331,
            "unit": "ns",
            "range": "± 0.5829577205221311"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 297.43501217798377,
            "unit": "ns",
            "range": "± 5.613813106970538"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 22.275379910150303,
            "unit": "ns",
            "range": "± 0.6571737859923011"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 7.8228676276181055,
            "unit": "ns",
            "range": "± 0.17860159472006953"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.095969644252596,
            "unit": "ns",
            "range": "± 0.034028438076172056"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 289.6664658786165,
            "unit": "ns",
            "range": "± 1.4271487078133105"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 14.547206464001205,
            "unit": "ns",
            "range": "± 0.2835147078118654"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 292.169043157324,
            "unit": "ns",
            "range": "± 1.2840775857703763"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1302.8873729573977,
            "unit": "ns",
            "range": "± 55.218028748829"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 39357.54994810065,
            "unit": "ns",
            "range": "± 859.7329829756534"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 41472.721169581986,
            "unit": "ns",
            "range": "± 1534.8131408522952"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 43938.214514749896,
            "unit": "ns",
            "range": "± 840.0302790907374"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3488.4615384615386,
            "unit": "ns",
            "range": "± 177.99808056076526"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.465705659401895,
            "unit": "ns",
            "range": "± 1.1173453479483255"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 325.64705322159335,
            "unit": "ns",
            "range": "± 10.723261444630655"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 24.68790287934802,
            "unit": "ns",
            "range": "± 0.4656965449478203"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1178.989352924555,
            "unit": "ns",
            "range": "± 26.987880293970477"
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
          "id": "604244bbcc2e08866fb8c8d7a898039f16bd87eb",
          "message": "UnitsNet: 4.108.0",
          "timestamp": "2021-11-25T23:00:50+01:00",
          "tree_id": "a4b00c29e1f6afdf28dfe6f773d06de4bd97b869",
          "url": "https://github.com/angularsen/UnitsNet/commit/604244bbcc2e08866fb8c8d7a898039f16bd87eb"
        },
        "date": 1637878265157,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.031456779342168,
            "unit": "ns",
            "range": "± 0.3210000863392103"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 383.6146443451482,
            "unit": "ns",
            "range": "± 6.849873275185803"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 28.094937746446828,
            "unit": "ns",
            "range": "± 0.6409201955800077"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.871421393237048,
            "unit": "ns",
            "range": "± 0.29503148359546577"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.350348181136207,
            "unit": "ns",
            "range": "± 0.34445789983716035"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 371.589961088121,
            "unit": "ns",
            "range": "± 13.086573085327585"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.640701418864968,
            "unit": "ns",
            "range": "± 0.571892204308478"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 381.8331818755726,
            "unit": "ns",
            "range": "± 12.184000460724075"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1445.7793611917764,
            "unit": "ns",
            "range": "± 44.1467027631867"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 49571.16990619862,
            "unit": "ns",
            "range": "± 1172.055540732504"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 51397.99361179361,
            "unit": "ns",
            "range": "± 2294.9433360099706"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 54614.32221484723,
            "unit": "ns",
            "range": "± 1391.6161665522811"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3954.7368421052633,
            "unit": "ns",
            "range": "± 225.39252807785323"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.745952459765228,
            "unit": "ns",
            "range": "± 0.848035082840527"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 390.2421692225719,
            "unit": "ns",
            "range": "± 7.593661481668749"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 34.6589744890233,
            "unit": "ns",
            "range": "± 1.479899800225659"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1470.6889372730075,
            "unit": "ns",
            "range": "± 41.62641399721694"
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
          "id": "9799a1b3aa9c5cfc6ede322350ce2cbfcaee1a74",
          "message": "UnitsNet: 4.109.0",
          "timestamp": "2021-12-01T23:20:56+01:00",
          "tree_id": "92361a8ae9f407e57ce54d24b421f7ba44b026ba",
          "url": "https://github.com/angularsen/UnitsNet/commit/9799a1b3aa9c5cfc6ede322350ce2cbfcaee1a74"
        },
        "date": 1638398026898,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.09441543185662,
            "unit": "ns",
            "range": "± 0.37395321626710104"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 414.1620646312135,
            "unit": "ns",
            "range": "± 14.755823576353533"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.041350142624776,
            "unit": "ns",
            "range": "± 0.675698297484401"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.749473842336247,
            "unit": "ns",
            "range": "± 0.19353904979534717"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.071906231931498,
            "unit": "ns",
            "range": "± 0.16569759868434955"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 374.870857488342,
            "unit": "ns",
            "range": "± 8.326096930837316"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.5907114270833,
            "unit": "ns",
            "range": "± 0.4385343454371513"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 392.59301619709163,
            "unit": "ns",
            "range": "± 15.19913847527779"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1630.9880684154543,
            "unit": "ns",
            "range": "± 25.881878129766864"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 55384.66505011146,
            "unit": "ns",
            "range": "± 1839.0027418722325"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 55990.7248542543,
            "unit": "ns",
            "range": "± 1401.3636928368485"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 61543.95306859209,
            "unit": "ns",
            "range": "± 2285.860683519704"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 4279.569892473119,
            "unit": "ns",
            "range": "± 308.4178207029584"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.794790369767796,
            "unit": "ns",
            "range": "± 1.258602967766755"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 364.2922465335325,
            "unit": "ns",
            "range": "± 19.227440072943537"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 34.03843678515503,
            "unit": "ns",
            "range": "± 3.2592383951673796"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1646.5121409921671,
            "unit": "ns",
            "range": "± 88.98089106641063"
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
          "id": "6f865f3bd9418f3b681a1f9f91d31b35eb2ae696",
          "message": "UnitsNet: 4.110.0",
          "timestamp": "2021-12-07T15:48:12+01:00",
          "tree_id": "f21b4e1d2aae896af7ec6785c6e90c19040e1808",
          "url": "https://github.com/angularsen/UnitsNet/commit/6f865f3bd9418f3b681a1f9f91d31b35eb2ae696"
        },
        "date": 1638889696624,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.374078463528033,
            "unit": "ns",
            "range": "± 0.1818676412536632"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 410.36522087661115,
            "unit": "ns",
            "range": "± 14.15984057737315"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.259244664139047,
            "unit": "ns",
            "range": "± 1.2795980105760836"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.812204161649243,
            "unit": "ns",
            "range": "± 0.5332791220716117"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.516268776929843,
            "unit": "ns",
            "range": "± 0.33706834601343477"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 394.54330182095526,
            "unit": "ns",
            "range": "± 13.405574268665381"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.932601413798203,
            "unit": "ns",
            "range": "± 0.8135779470739006"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 395.8956497371676,
            "unit": "ns",
            "range": "± 20.321320579838474"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1714.6969726598447,
            "unit": "ns",
            "range": "± 52.23248733118777"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 57073.550936345775,
            "unit": "ns",
            "range": "± 2604.482847225178"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 56442.36615794576,
            "unit": "ns",
            "range": "± 2188.852314182352"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 61856.08066229115,
            "unit": "ns",
            "range": "± 1996.935217981805"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 4231.914893617021,
            "unit": "ns",
            "range": "± 266.0797705424522"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 23.868591687528255,
            "unit": "ns",
            "range": "± 0.9559257731707017"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 391.983302102733,
            "unit": "ns",
            "range": "± 17.352380555275502"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 36.658740651589575,
            "unit": "ns",
            "range": "± 3.7142602310490958"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1682.7767216100417,
            "unit": "ns",
            "range": "± 92.047385702863"
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
          "id": "19c0fa957faebc4ca39bdd25d2a43df3bde81b0c",
          "message": "UnitsNet: 4.111.0",
          "timestamp": "2021-12-30T14:33:18+01:00",
          "tree_id": "4290f00b7eedd3c0844ddbb85ccbffef2ad375c5",
          "url": "https://github.com/angularsen/UnitsNet/commit/19c0fa957faebc4ca39bdd25d2a43df3bde81b0c"
        },
        "date": 1640871987913,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.51718231038551,
            "unit": "ns",
            "range": "± 0.019407301529979604"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 329.53329658468346,
            "unit": "ns",
            "range": "± 1.0439581744957416"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.46984649122807,
            "unit": "ns",
            "range": "± 0.08527778218911408"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.706695829122943,
            "unit": "ns",
            "range": "± 0.018947726033518467"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.197011079890254,
            "unit": "ns",
            "range": "± 0.030010295088755676"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 318.5454449163489,
            "unit": "ns",
            "range": "± 0.8321537389119444"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.247445236399304,
            "unit": "ns",
            "range": "± 0.038649523883897"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 337.6730590796353,
            "unit": "ns",
            "range": "± 2.4624033635231997"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1293.2841815296817,
            "unit": "ns",
            "range": "± 13.068846451695244"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 44834.77341651504,
            "unit": "ns",
            "range": "± 364.02400811170173"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 44929.90639208345,
            "unit": "ns",
            "range": "± 361.9852448588734"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 48022.511072597736,
            "unit": "ns",
            "range": "± 195.4830331157991"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3482.1428571428573,
            "unit": "ns",
            "range": "± 147.84161409137423"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.084745772731807,
            "unit": "ns",
            "range": "± 0.21945999541856154"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 330.8434782223639,
            "unit": "ns",
            "range": "± 0.8666805152870428"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.9174046533985,
            "unit": "ns",
            "range": "± 0.493755127649733"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1304.0086885975243,
            "unit": "ns",
            "range": "± 11.981618076465612"
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
          "id": "9517e77f4db722e4a81eaab9234faf701d50098c",
          "message": "UnitsNet: 4.112.0",
          "timestamp": "2021-12-31T11:56:28+01:00",
          "tree_id": "a481bd27a6fb898efd934017a12d54af6b65b0e7",
          "url": "https://github.com/angularsen/UnitsNet/commit/9517e77f4db722e4a81eaab9234faf701d50098c"
        },
        "date": 1640948777884,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.50742618190071,
            "unit": "ns",
            "range": "± 0.02311051555053278"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 311.5315854782317,
            "unit": "ns",
            "range": "± 3.4741475006615667"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.452702284851163,
            "unit": "ns",
            "range": "± 0.0662536258515166"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.697480779340538,
            "unit": "ns",
            "range": "± 0.031774452220886436"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.16099948434042,
            "unit": "ns",
            "range": "± 0.02474127572962714"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 310.05904324882033,
            "unit": "ns",
            "range": "± 3.7000303083230586"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.27123282755677,
            "unit": "ns",
            "range": "± 0.038889499002429585"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 326.2808035231911,
            "unit": "ns",
            "range": "± 1.2784821889783649"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1238.399751858367,
            "unit": "ns",
            "range": "± 13.05139326680252"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 43489.163509835285,
            "unit": "ns",
            "range": "± 397.7827496248364"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 44233.90285054614,
            "unit": "ns",
            "range": "± 491.69157248673764"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 47176.87869106398,
            "unit": "ns",
            "range": "± 303.2977246752304"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3403.7735849056603,
            "unit": "ns",
            "range": "± 132.95786514610185"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.822430838389753,
            "unit": "ns",
            "range": "± 0.18356281559931412"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 323.7756578130176,
            "unit": "ns",
            "range": "± 1.1320915517526398"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.14955685247941,
            "unit": "ns",
            "range": "± 0.8582045780648362"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1291.5494601097034,
            "unit": "ns",
            "range": "± 6.3776476615822935"
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
          "id": "cece3f33b4178cfc741b12e3ffe6c90f02bc7ff3",
          "message": "UnitsNet: 4.113.0",
          "timestamp": "2022-01-16T14:20:46+01:00",
          "tree_id": "c07f982f2294501c2269b20aafe0079601c3ac3b",
          "url": "https://github.com/angularsen/UnitsNet/commit/cece3f33b4178cfc741b12e3ffe6c90f02bc7ff3"
        },
        "date": 1642339806815,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.524579404322907,
            "unit": "ns",
            "range": "± 0.036686215733986505"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 324.9036672183118,
            "unit": "ns",
            "range": "± 0.9011556909140234"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.47247953483549,
            "unit": "ns",
            "range": "± 0.052169784503158755"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.698651179875815,
            "unit": "ns",
            "range": "± 0.01814184150508508"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.176474928084243,
            "unit": "ns",
            "range": "± 0.016087434358736996"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 326.4737243686446,
            "unit": "ns",
            "range": "± 0.5240549047900214"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.25469096003994,
            "unit": "ns",
            "range": "± 0.033945129464889805"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 337.72088429620635,
            "unit": "ns",
            "range": "± 0.9343953285235526"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1363.3120452468436,
            "unit": "ns",
            "range": "± 7.977871052227944"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 45435.30137981118,
            "unit": "ns",
            "range": "± 394.02509315216315"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 45827.74970136911,
            "unit": "ns",
            "range": "± 94.49446140365484"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 48445.156015457826,
            "unit": "ns",
            "range": "± 208.57437841255182"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3596.153846153846,
            "unit": "ns",
            "range": "± 146.81125465958306"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.633080173794916,
            "unit": "ns",
            "range": "± 0.15194645011360805"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 329.79931474622265,
            "unit": "ns",
            "range": "± 1.0781943513871308"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.835975332669296,
            "unit": "ns",
            "range": "± 0.12368140220196436"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1325.288551881112,
            "unit": "ns",
            "range": "± 7.9104398797203"
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
          "id": "2c3cb93cffd453a296a64ed0eadc5d02e35a4836",
          "message": "UnitsNet: 4.114.0",
          "timestamp": "2022-01-18T00:16:43+01:00",
          "tree_id": "74ebf3209c87a855e5ee6265cf0c14fb85eeeec0",
          "url": "https://github.com/angularsen/UnitsNet/commit/2c3cb93cffd453a296a64ed0eadc5d02e35a4836"
        },
        "date": 1642462218665,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.852431131096777,
            "unit": "ns",
            "range": "± 0.2564776623710288"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 406.47148878620226,
            "unit": "ns",
            "range": "± 11.407472749756852"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 31.27215174555285,
            "unit": "ns",
            "range": "± 0.5947390937644551"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.889644954541199,
            "unit": "ns",
            "range": "± 0.24755926356680427"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 11.50848162725418,
            "unit": "ns",
            "range": "± 0.2412186166181615"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 406.4101394146023,
            "unit": "ns",
            "range": "± 9.057732442635084"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 20.513515098708325,
            "unit": "ns",
            "range": "± 0.4882515827098168"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 413.8655128700385,
            "unit": "ns",
            "range": "± 5.3103619896977525"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1667.3814798108883,
            "unit": "ns",
            "range": "± 43.19976872316747"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 55306.80317692379,
            "unit": "ns",
            "range": "± 1896.0771509218566"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 56574.03093086474,
            "unit": "ns",
            "range": "± 1665.9782699570778"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 58072.22669209976,
            "unit": "ns",
            "range": "± 1364.5276696902665"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 4075,
            "unit": "ns",
            "range": "± 144.5594545418455"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.902936322339407,
            "unit": "ns",
            "range": "± 1.0252423113792664"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 405.75641099224396,
            "unit": "ns",
            "range": "± 8.621183426738119"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 38.460311011542565,
            "unit": "ns",
            "range": "± 1.9165493298746292"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1665.3159712400584,
            "unit": "ns",
            "range": "± 44.22131461550021"
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
          "id": "f3d3b8c1777cc8a22abd4176fb91d1ef13e5e954",
          "message": "Deprecate more usage of QuantityType (#1019)",
          "timestamp": "2022-01-26T21:14:06+01:00",
          "tree_id": "688a91d28cc1634b1488f9b34a293c4bf496bbb2",
          "url": "https://github.com/angularsen/UnitsNet/commit/f3d3b8c1777cc8a22abd4176fb91d1ef13e5e954"
        },
        "date": 1643229695591,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.133669128466641,
            "unit": "ns",
            "range": "± 0.13889658574696878"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 367.52025918231493,
            "unit": "ns",
            "range": "± 9.217356709332547"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 30.967211638792765,
            "unit": "ns",
            "range": "± 0.5070183828437235"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.286035923039234,
            "unit": "ns",
            "range": "± 0.3030331340231108"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.338486793106222,
            "unit": "ns",
            "range": "± 0.37510233196281795"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 386.6647651676583,
            "unit": "ns",
            "range": "± 6.074307830491962"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.89110479952463,
            "unit": "ns",
            "range": "± 0.20526064673425548"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 406.7021525262938,
            "unit": "ns",
            "range": "± 3.615935200893283"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1570.0648849114655,
            "unit": "ns",
            "range": "± 35.40235395000681"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 56047.9342564449,
            "unit": "ns",
            "range": "± 1005.3814539341324"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 56478.962475580964,
            "unit": "ns",
            "range": "± 1152.7181297044165"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 59676.99205137241,
            "unit": "ns",
            "range": "± 1068.2866872486754"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3985.8585858585857,
            "unit": "ns",
            "range": "± 340.7704658714201"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.635729678979192,
            "unit": "ns",
            "range": "± 0.38721726863276784"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 372.8326600490167,
            "unit": "ns",
            "range": "± 5.904473376823125"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 31.256098465152842,
            "unit": "ns",
            "range": "± 0.6368009535351664"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1594.897513154321,
            "unit": "ns",
            "range": "± 34.264358417969405"
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
          "id": "1d26388f6713da6a179178f1f0a0fa15a72802c4",
          "message": "UnitsNet: 4.115.0",
          "timestamp": "2022-01-26T22:24:53+01:00",
          "tree_id": "826cfb1f15ac583ee2fbec88316b7d912d5e2369",
          "url": "https://github.com/angularsen/UnitsNet/commit/1d26388f6713da6a179178f1f0a0fa15a72802c4"
        },
        "date": 1643233350443,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 8.54693167113489,
            "unit": "ns",
            "range": "± 0.29625694861664126"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 281.9930966999004,
            "unit": "ns",
            "range": "± 1.6205982172931563"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 21.520657827347094,
            "unit": "ns",
            "range": "± 0.11677625320694529"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 7.775213172790837,
            "unit": "ns",
            "range": "± 0.09544082532023428"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 7.497131538763746,
            "unit": "ns",
            "range": "± 0.05955473884707464"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 279.61384636496706,
            "unit": "ns",
            "range": "± 5.1912337872172065"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 14.36477551399486,
            "unit": "ns",
            "range": "± 0.05291272563893346"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 287.8463568778555,
            "unit": "ns",
            "range": "± 2.3786625941128636"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1104.8059653541022,
            "unit": "ns",
            "range": "± 17.038751633544976"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 38948.94411890168,
            "unit": "ns",
            "range": "± 1256.7787099960724"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 38619.52402806005,
            "unit": "ns",
            "range": "± 552.5329913559286"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 40834.60226964217,
            "unit": "ns",
            "range": "± 324.4925715302347"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3287.0967741935483,
            "unit": "ns",
            "range": "± 148.7476363969723"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 16.727984318317546,
            "unit": "ns",
            "range": "± 0.35857842562106695"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 286.82152689236983,
            "unit": "ns",
            "range": "± 6.71859597812303"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 23.837946445565134,
            "unit": "ns",
            "range": "± 0.4184357033184554"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1126.190880693542,
            "unit": "ns",
            "range": "± 14.902910321354438"
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
          "id": "fa983e226f47f4377bb2cf57371c65ec77743c16",
          "message": "Move default unit converter registration to quantity types (#1018)\n\nRef #1016 \r\n\r\nInstead of a huge single method in UnitConverter, it is split up into a static method per quanitity type.",
          "timestamp": "2022-01-26T22:24:33+01:00",
          "tree_id": "2d6e58fdb244eb59e91e62e2dda3bffe386857d7",
          "url": "https://github.com/angularsen/UnitsNet/commit/fa983e226f47f4377bb2cf57371c65ec77743c16"
        },
        "date": 1643233482794,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.141480503932657,
            "unit": "ns",
            "range": "± 0.31607305667427005"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 320.9316403892784,
            "unit": "ns",
            "range": "± 11.499898188288048"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 23.55358858080476,
            "unit": "ns",
            "range": "± 0.42218938780540477"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.423118401070138,
            "unit": "ns",
            "range": "± 0.2385833691800945"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.052697500222402,
            "unit": "ns",
            "range": "± 0.2875524538501116"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 312.563438213013,
            "unit": "ns",
            "range": "± 9.332690622519095"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 15.773622966479149,
            "unit": "ns",
            "range": "± 0.34587641902095956"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 317.86820607428854,
            "unit": "ns",
            "range": "± 9.145653538743515"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1217.1427368973689,
            "unit": "ns",
            "range": "± 41.95947639438175"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 40850.521659383936,
            "unit": "ns",
            "range": "± 1374.730472215977"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 41291.775297567496,
            "unit": "ns",
            "range": "± 1467.7500330706744"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 43769.99601270028,
            "unit": "ns",
            "range": "± 1253.1098880863742"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3520.8333333333335,
            "unit": "ns",
            "range": "± 88.36272412331317"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 17.923047392653743,
            "unit": "ns",
            "range": "± 0.3430791145397489"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 309.4791657006489,
            "unit": "ns",
            "range": "± 9.338560262416031"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 25.452826800374535,
            "unit": "ns",
            "range": "± 0.732569204769066"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1196.9464439812648,
            "unit": "ns",
            "range": "± 24.298446128189685"
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
          "id": "f33c63d837f8cb8792e9c3ea51b310a984db9f20",
          "message": "Remove duplicate QuantityInfo constructor setters (#1020)",
          "timestamp": "2022-01-28T13:06:48+01:00",
          "tree_id": "07e0c8a95208e1fd2a729f345000c65d9d8add2f",
          "url": "https://github.com/angularsen/UnitsNet/commit/f33c63d837f8cb8792e9c3ea51b310a984db9f20"
        },
        "date": 1643372268281,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.501987719798146,
            "unit": "ns",
            "range": "± 0.03027340048591305"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 332.06507748040707,
            "unit": "ns",
            "range": "± 1.0683541271638246"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.378970925252638,
            "unit": "ns",
            "range": "± 0.04122231931369407"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.739501908409242,
            "unit": "ns",
            "range": "± 0.021826338734636668"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.792546698781662,
            "unit": "ns",
            "range": "± 0.02758691003727355"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 339.4859639210696,
            "unit": "ns",
            "range": "± 0.935880741555526"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 16.2344961489351,
            "unit": "ns",
            "range": "± 0.042699652458674686"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 328.8409811249769,
            "unit": "ns",
            "range": "± 1.543683236517365"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1277.8189745698085,
            "unit": "ns",
            "range": "± 12.861893070424252"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 44501.670935264505,
            "unit": "ns",
            "range": "± 334.53968448012057"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 44260.91702671723,
            "unit": "ns",
            "range": "± 346.60229298042344"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 47244.98528713812,
            "unit": "ns",
            "range": "± 413.0759521712978"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3503.3333333333335,
            "unit": "ns",
            "range": "± 154.0049159095052"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.064392484903866,
            "unit": "ns",
            "range": "± 0.18455024195394756"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 322.4696757912094,
            "unit": "ns",
            "range": "± 1.3293796887788505"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 30.52123987179267,
            "unit": "ns",
            "range": "± 0.5410382369712176"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1300.69561718848,
            "unit": "ns",
            "range": "± 9.488364782817355"
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
          "id": "e341c81e3c758b674d7310f2c4b4f85c88c77a5e",
          "message": "UnitsNet: 4.116.0",
          "timestamp": "2022-01-28T20:25:51+01:00",
          "tree_id": "8a314b036542bb52be4e62f35c29e7d0c102c4fc",
          "url": "https://github.com/angularsen/UnitsNet/commit/e341c81e3c758b674d7310f2c4b4f85c88c77a5e"
        },
        "date": 1643398799470,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 8.988075464026887,
            "unit": "ns",
            "range": "± 0.32620679579334166"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 308.24256696406604,
            "unit": "ns",
            "range": "± 8.000322244264588"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 23.210392242530787,
            "unit": "ns",
            "range": "± 0.5960096416770105"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.308972553079963,
            "unit": "ns",
            "range": "± 0.30834234285384077"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.681671332357332,
            "unit": "ns",
            "range": "± 0.3381877246725936"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 310.51527858928165,
            "unit": "ns",
            "range": "± 9.103546491198989"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 15.374941458615002,
            "unit": "ns",
            "range": "± 0.5456507337390197"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 313.8778900879904,
            "unit": "ns",
            "range": "± 5.689354262475625"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1253.4163810014077,
            "unit": "ns",
            "range": "± 25.55352205901862"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 42531.44894483974,
            "unit": "ns",
            "range": "± 1199.867832233879"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 42972.28339932449,
            "unit": "ns",
            "range": "± 1231.9308610424093"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 45173.97727001977,
            "unit": "ns",
            "range": "± 1543.4434116238435"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 3150,
            "unit": "ns",
            "range": "± 87.83100656536799"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.302405701107926,
            "unit": "ns",
            "range": "± 0.5439909019734129"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 313.17210281257525,
            "unit": "ns",
            "range": "± 8.602007501988172"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 29.74920538182548,
            "unit": "ns",
            "range": "± 1.1395401311539952"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1229.8039179489347,
            "unit": "ns",
            "range": "± 38.248967174338155"
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
          "id": "e5aba5b75aaf0cc85ced1425dce0670f861b8eee",
          "message": "Use UnitConverter to do conversion functions and allow basic extensibility (#1023)",
          "timestamp": "2022-02-08T21:31:50+01:00",
          "tree_id": "a3823ab65405efdd3f826bc50cd3dbe78acd9d55",
          "url": "https://github.com/angularsen/UnitsNet/commit/e5aba5b75aaf0cc85ced1425dce0670f861b8eee"
        },
        "date": 1644352983950,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 9.52822853704421,
            "unit": "ns",
            "range": "± 0.025090253899023952"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 322.7295429950886,
            "unit": "ns",
            "range": "± 1.029040341661038"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 24.457248058454166,
            "unit": "ns",
            "range": "± 0.04644239541111441"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 159.2675245780961,
            "unit": "ns",
            "range": "± 0.5433470807691423"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 157.67732568478706,
            "unit": "ns",
            "range": "± 0.9105617038717335"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 327.095648582764,
            "unit": "ns",
            "range": "± 1.438014189649949"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 149.6124216813756,
            "unit": "ns",
            "range": "± 0.675176064938718"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 329.6921629877179,
            "unit": "ns",
            "range": "± 1.1678354257311108"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1312.6490581522623,
            "unit": "ns",
            "range": "± 8.723494052786021"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 44273.702553275,
            "unit": "ns",
            "range": "± 244.5976415021368"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 44846.12356551908,
            "unit": "ns",
            "range": "± 140.2718908630166"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 48127.831561237304,
            "unit": "ns",
            "range": "± 253.220969831624"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 71.71828730824943,
            "unit": "ns",
            "range": "± 0.22773300532381832"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 160.9926981226055,
            "unit": "ns",
            "range": "± 0.2536573782335105"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 325.1316638512627,
            "unit": "ns",
            "range": "± 0.9018420067181974"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 169.39405896531517,
            "unit": "ns",
            "range": "± 0.9097505369040623"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1334.4304067267803,
            "unit": "ns",
            "range": "± 6.965447949048769"
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
          "id": "eca113941a4be67e007416a83e72b62325cd4026",
          "message": "UnitsNet: 4.117.0",
          "timestamp": "2022-02-08T22:00:02+01:00",
          "tree_id": "abe2046d230f5705fcff7f775a81661ff8dc1c38",
          "url": "https://github.com/angularsen/UnitsNet/commit/eca113941a4be67e007416a83e72b62325cd4026"
        },
        "date": 1644354993843,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 11.4882151671146,
            "unit": "ns",
            "range": "± 0.07991330131235544"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 386.2027953537969,
            "unit": "ns",
            "range": "± 3.3959357678677136"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.32754300230918,
            "unit": "ns",
            "range": "± 0.16820265435873993"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 181.08148128261936,
            "unit": "ns",
            "range": "± 1.3771034799078874"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 203.64845306767413,
            "unit": "ns",
            "range": "± 2.0429515145635304"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 380.4477664471268,
            "unit": "ns",
            "range": "± 2.353734450148467"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 168.21721045838572,
            "unit": "ns",
            "range": "± 1.081222403018922"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 384.1352006935734,
            "unit": "ns",
            "range": "± 2.79895546588798"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1626.593942030209,
            "unit": "ns",
            "range": "± 11.570204787984816"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 53846.145235564996,
            "unit": "ns",
            "range": "± 636.2127428337262"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 53080.38447971782,
            "unit": "ns",
            "range": "± 737.6786915822416"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 57509.669744992956,
            "unit": "ns",
            "range": "± 573.6852530043998"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 86.05272504714682,
            "unit": "ns",
            "range": "± 0.7946161887047621"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 200.91140911079435,
            "unit": "ns",
            "range": "± 3.2227571406383544"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 380.2453318145654,
            "unit": "ns",
            "range": "± 2.189199014628911"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 201.73312206962848,
            "unit": "ns",
            "range": "± 1.0513190785468447"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1532.4210369927152,
            "unit": "ns",
            "range": "± 24.464675520739085"
          }
        ]
      }
    ]
  }
}