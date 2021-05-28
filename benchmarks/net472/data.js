window.BENCHMARK_DATA = {
  "lastUpdate": 1622239524520,
  "repoUrl": "https://github.com/angularsen/UnitsNet",
  "entries": {
    "UnitsNet Benchmarks (net472)": [
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
        "date": 1619819544145,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 16.104053877815726,
            "unit": "ns",
            "range": "± 0.4665971830243125"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 639.2482603092783,
            "unit": "ns",
            "range": "± 15.53192928307264"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 38.75285224139871,
            "unit": "ns",
            "range": "± 0.6444642015269129"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.494940581903196,
            "unit": "ns",
            "range": "± 0.22727719952946074"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.296642594761172,
            "unit": "ns",
            "range": "± 0.2599475749673262"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 639.9775848965467,
            "unit": "ns",
            "range": "± 21.24305822229252"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 24.635977453299496,
            "unit": "ns",
            "range": "± 0.4621274827749784"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 647.1772397597704,
            "unit": "ns",
            "range": "± 12.290126555894139"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2363.825843666931,
            "unit": "ns",
            "range": "± 68.06082520458534"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 74037.06123214452,
            "unit": "ns",
            "range": "± 1824.3333340746565"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 73595.05242947867,
            "unit": "ns",
            "range": "± 1726.3649651339215"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 77885.88588002707,
            "unit": "ns",
            "range": "± 1971.8459078098117"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2814.4329896907216,
            "unit": "ns",
            "range": "± 191.4798132972341"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.321361856780346,
            "unit": "ns",
            "range": "± 0.6022867724253932"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 641.7277766407423,
            "unit": "ns",
            "range": "± 10.89961360456673"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 38.44490495213574,
            "unit": "ns",
            "range": "± 1.047720754859349"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2415.4515213861387,
            "unit": "ns",
            "range": "± 48.92455015899322"
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
        "date": 1619832844690,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.053468574888194,
            "unit": "ns",
            "range": "± 0.1371659692432721"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 612.2115277120159,
            "unit": "ns",
            "range": "± 7.314884291422373"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 37.51916676161037,
            "unit": "ns",
            "range": "± 0.3290172004694769"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.138118078210884,
            "unit": "ns",
            "range": "± 0.10490172470139317"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.195209816888939,
            "unit": "ns",
            "range": "± 0.11962416161661983"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 602.8006194679043,
            "unit": "ns",
            "range": "± 7.078217774092053"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.026098693685025,
            "unit": "ns",
            "range": "± 0.16588520297028858"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 620.972902209284,
            "unit": "ns",
            "range": "± 12.086205728525595"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2555.227765653113,
            "unit": "ns",
            "range": "± 64.95265535062335"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 73624.31473151532,
            "unit": "ns",
            "range": "± 1369.6129667106836"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 73961.98079461978,
            "unit": "ns",
            "range": "± 717.1881564600592"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 77686.18374868375,
            "unit": "ns",
            "range": "± 513.9345666370139"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2450.6849315068494,
            "unit": "ns",
            "range": "± 109.44720654172457"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 24.80424508547659,
            "unit": "ns",
            "range": "± 0.5274553215105569"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 599.1048332442443,
            "unit": "ns",
            "range": "± 7.661196829983116"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 39.30622334385681,
            "unit": "ns",
            "range": "± 1.1591911913576736"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2486.52560531666,
            "unit": "ns",
            "range": "± 51.73828001448342"
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
        "date": 1619833960266,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 14.330246655803112,
            "unit": "ns",
            "range": "± 0.22080513486910258"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 550.9459350467793,
            "unit": "ns",
            "range": "± 5.309906568407245"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 38.91712979045187,
            "unit": "ns",
            "range": "± 0.43220810836209844"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.15313597392531,
            "unit": "ns",
            "range": "± 0.1678060339312448"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.16206048076485,
            "unit": "ns",
            "range": "± 0.2557934679849112"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 555.09000449547,
            "unit": "ns",
            "range": "± 12.37266118265786"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 24.020095736017968,
            "unit": "ns",
            "range": "± 0.5059905626321808"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 594.9274253103501,
            "unit": "ns",
            "range": "± 16.454603784476845"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1960.6610545575127,
            "unit": "ns",
            "range": "± 29.17749568577539"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 62882.15762435785,
            "unit": "ns",
            "range": "± 1162.1875610731747"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 62467.91530069328,
            "unit": "ns",
            "range": "± 1443.8117227159764"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 66127.42290389881,
            "unit": "ns",
            "range": "± 1160.06532138677"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2444.0860215053763,
            "unit": "ns",
            "range": "± 172.86735653283904"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.0710499414648,
            "unit": "ns",
            "range": "± 0.23706719793813316"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 558.5104695275887,
            "unit": "ns",
            "range": "± 12.175024928903985"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.8869987126048,
            "unit": "ns",
            "range": "± 0.49476053120656566"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1996.6758499171644,
            "unit": "ns",
            "range": "± 31.14525268657382"
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
        "date": 1620423167353,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.658534777713845,
            "unit": "ns",
            "range": "± 0.03882681849720259"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 486.49094177467913,
            "unit": "ns",
            "range": "± 4.141105289267068"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.838633139974444,
            "unit": "ns",
            "range": "± 0.09166503018709592"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.669304908453936,
            "unit": "ns",
            "range": "± 0.04133831514423069"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.689072439718693,
            "unit": "ns",
            "range": "± 0.03987754821922755"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 485.0517570445823,
            "unit": "ns",
            "range": "± 3.2142674458310716"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.384925934152676,
            "unit": "ns",
            "range": "± 0.04886237779690313"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 496.50588374664363,
            "unit": "ns",
            "range": "± 3.057574699498298"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1745.2817367587586,
            "unit": "ns",
            "range": "± 5.1909044580158055"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 51588.30490623446,
            "unit": "ns",
            "range": "± 184.3874571142659"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 52079.59426229508,
            "unit": "ns",
            "range": "± 245.7362585699607"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 56249.724545555924,
            "unit": "ns",
            "range": "± 231.45915629055563"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1617.948717948718,
            "unit": "ns",
            "range": "± 55.591531311668746"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.53186563689645,
            "unit": "ns",
            "range": "± 0.09475612011031961"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 482.05552610241375,
            "unit": "ns",
            "range": "± 1.911062690290555"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 28.504908192127953,
            "unit": "ns",
            "range": "± 0.2244506132389502"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1803.1921237896154,
            "unit": "ns",
            "range": "± 8.410224142639922"
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
        "date": 1621253356826,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 14.723681757729398,
            "unit": "ns",
            "range": "± 0.3313098194653935"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 549.2474433730542,
            "unit": "ns",
            "range": "± 6.2702986817941975"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 33.54716283782833,
            "unit": "ns",
            "range": "± 0.3751299338024245"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.092365493368298,
            "unit": "ns",
            "range": "± 0.18538540367469197"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.899911670396591,
            "unit": "ns",
            "range": "± 0.1584275198119223"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 559.384455319985,
            "unit": "ns",
            "range": "± 8.910700441988267"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 22.20820366028907,
            "unit": "ns",
            "range": "± 0.24981103148779088"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 563.0002622301666,
            "unit": "ns",
            "range": "± 10.419818231808495"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2100.5254837357843,
            "unit": "ns",
            "range": "± 38.71452430350208"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 57730.12540460231,
            "unit": "ns",
            "range": "± 606.6140906185233"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 61640.217772069125,
            "unit": "ns",
            "range": "± 2054.757456552628"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 64102.55751313641,
            "unit": "ns",
            "range": "± 792.0854976874995"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2115.1898734177216,
            "unit": "ns",
            "range": "± 109.88176348885048"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.99838652645628,
            "unit": "ns",
            "range": "± 0.39870020644743065"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 562.0413834848629,
            "unit": "ns",
            "range": "± 8.291115026575998"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.306465401885276,
            "unit": "ns",
            "range": "± 0.7009160606306594"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2140.6347010847303,
            "unit": "ns",
            "range": "± 38.98109732883614"
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
        "date": 1621590486404,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.641381466545301,
            "unit": "ns",
            "range": "± 0.02563914082091724"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 491.436940886648,
            "unit": "ns",
            "range": "± 3.156855982114209"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.48010223559612,
            "unit": "ns",
            "range": "± 0.07091583672330061"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.67696017196383,
            "unit": "ns",
            "range": "± 0.03920427377564806"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.675413836217079,
            "unit": "ns",
            "range": "± 0.036592375811305485"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 478.96095262366646,
            "unit": "ns",
            "range": "± 4.965909837850831"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.368347045577064,
            "unit": "ns",
            "range": "± 0.03349514255005014"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 570.2267051745325,
            "unit": "ns",
            "range": "± 1.242922578492853"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1751.551177385023,
            "unit": "ns",
            "range": "± 9.420439040590281"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 52855.11219147345,
            "unit": "ns",
            "range": "± 176.01739914389032"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 54215.42745776665,
            "unit": "ns",
            "range": "± 129.4187083541623"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 58602.442074004604,
            "unit": "ns",
            "range": "± 253.87699212494823"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1625.9259259259259,
            "unit": "ns",
            "range": "± 67.80990406090491"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.12388752621331,
            "unit": "ns",
            "range": "± 0.09905540220404788"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 474.8843879723665,
            "unit": "ns",
            "range": "± 3.362319993078054"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 26.817236873576128,
            "unit": "ns",
            "range": "± 0.0848530690350929"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1982.039267690721,
            "unit": "ns",
            "range": "± 10.431917653285504"
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
        "date": 1621630680890,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 13.902746102101354,
            "unit": "ns",
            "range": "± 0.43615780552308314"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 542.7707033521177,
            "unit": "ns",
            "range": "± 13.659230940474934"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 33.37674255613641,
            "unit": "ns",
            "range": "± 1.098185686871103"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.784051065687871,
            "unit": "ns",
            "range": "± 0.33392997430022375"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.057092774165062,
            "unit": "ns",
            "range": "± 0.47919069197254444"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 562.2914616033606,
            "unit": "ns",
            "range": "± 14.457490944519638"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 21.507889149920626,
            "unit": "ns",
            "range": "± 0.5602800640699573"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 521.8376930130356,
            "unit": "ns",
            "range": "± 7.775795196991084"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1926.2569817420351,
            "unit": "ns",
            "range": "± 52.73032514710164"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 54280.765483276664,
            "unit": "ns",
            "range": "± 1307.5875912057581"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 57946.52113130444,
            "unit": "ns",
            "range": "± 1722.7293199871942"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 60033.53652082413,
            "unit": "ns",
            "range": "± 1331.0892719893598"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2231.313131313131,
            "unit": "ns",
            "range": "± 174.17236633047173"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.536034673101902,
            "unit": "ns",
            "range": "± 0.5537503665399608"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 548.6948221578201,
            "unit": "ns",
            "range": "± 6.897455856797485"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.894969612891046,
            "unit": "ns",
            "range": "± 0.8352035918856535"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2028.6208704672272,
            "unit": "ns",
            "range": "± 49.10813890231726"
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
        "date": 1622239523453,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.05536551489347,
            "unit": "ns",
            "range": "± 0.34427743306182157"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 463.3853956022328,
            "unit": "ns",
            "range": "± 15.15881702748676"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 28.451910511350142,
            "unit": "ns",
            "range": "± 0.809161403803301"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.201640732234459,
            "unit": "ns",
            "range": "± 0.33854945236944134"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.481700571263218,
            "unit": "ns",
            "range": "± 0.26293884295432274"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 461.614756598151,
            "unit": "ns",
            "range": "± 14.886251966136546"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 18.489933576865734,
            "unit": "ns",
            "range": "± 0.6686270245276118"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 480.0059406786453,
            "unit": "ns",
            "range": "± 15.147094275860963"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1718.7149324888119,
            "unit": "ns",
            "range": "± 43.43378343493361"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 50914.94351192155,
            "unit": "ns",
            "range": "± 1433.3549049309272"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 50660.774294060386,
            "unit": "ns",
            "range": "± 1746.7791228837145"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 55029.81109799292,
            "unit": "ns",
            "range": "± 1806.1853912587565"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1608.860759493671,
            "unit": "ns",
            "range": "± 83.49708027709944"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 17.526310144853642,
            "unit": "ns",
            "range": "± 0.47141337196824656"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 457.88849780031006,
            "unit": "ns",
            "range": "± 14.42184047820167"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 26.375857476516593,
            "unit": "ns",
            "range": "± 0.47252671799513957"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1787.4325288763448,
            "unit": "ns",
            "range": "± 51.71889296742068"
          }
        ]
      }
    ]
  }
}