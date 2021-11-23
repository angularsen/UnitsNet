window.BENCHMARK_DATA = {
  "lastUpdate": 1637706815927,
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
        "date": 1623540504465,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 14.452972416724101,
            "unit": "ns",
            "range": "± 0.26399423821543555"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 562.8288488402624,
            "unit": "ns",
            "range": "± 5.309229634149608"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 39.76880578253893,
            "unit": "ns",
            "range": "± 0.5769558202390557"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.857239889195238,
            "unit": "ns",
            "range": "± 0.14139080842182344"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.120900452378818,
            "unit": "ns",
            "range": "± 0.24715011636807926"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 550.4939937217429,
            "unit": "ns",
            "range": "± 7.057493144261651"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 21.850143645786392,
            "unit": "ns",
            "range": "± 0.11702214081995281"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 623.7324599517669,
            "unit": "ns",
            "range": "± 11.308278815547625"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2237.183608924709,
            "unit": "ns",
            "range": "± 94.00553126709367"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 68403.53662864385,
            "unit": "ns",
            "range": "± 1785.81129602048"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 67467.57381201957,
            "unit": "ns",
            "range": "± 1795.361790039207"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 67919.81202478176,
            "unit": "ns",
            "range": "± 1488.6824766251796"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2432.9896907216494,
            "unit": "ns",
            "range": "± 139.733115769354"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.19204795150822,
            "unit": "ns",
            "range": "± 0.6529286342790376"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 579.8537964998812,
            "unit": "ns",
            "range": "± 14.858366911927655"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.740707349488076,
            "unit": "ns",
            "range": "± 1.3361093066581786"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2148.1152615921446,
            "unit": "ns",
            "range": "± 40.09715556813683"
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
        "date": 1623921702229,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 14.53941953934438,
            "unit": "ns",
            "range": "± 0.32633253517897987"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 588.5112329815648,
            "unit": "ns",
            "range": "± 9.02810424494294"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 35.71315567358996,
            "unit": "ns",
            "range": "± 0.40889474998073244"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.507564543893494,
            "unit": "ns",
            "range": "± 0.1321850485156565"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.319209555434893,
            "unit": "ns",
            "range": "± 0.2575292638598296"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 575.8464258577261,
            "unit": "ns",
            "range": "± 16.36351496350648"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.26165264285001,
            "unit": "ns",
            "range": "± 0.09818728091838311"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 619.7830209882894,
            "unit": "ns",
            "range": "± 7.567444973219102"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2303.643024133961,
            "unit": "ns",
            "range": "± 70.75214354661277"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 66070.22786372251,
            "unit": "ns",
            "range": "± 1042.9500058181331"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 60476.07177263969,
            "unit": "ns",
            "range": "± 1477.8208760678863"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 69915.79198663111,
            "unit": "ns",
            "range": "± 2497.23897210262"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2001.0416666666667,
            "unit": "ns",
            "range": "± 273.5708478108181"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.209049690912476,
            "unit": "ns",
            "range": "± 0.6416073094245506"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 589.4387627099388,
            "unit": "ns",
            "range": "± 12.883516538371099"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.379172390749936,
            "unit": "ns",
            "range": "± 1.3489981849948938"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2152.6412075643066,
            "unit": "ns",
            "range": "± 19.860303817909774"
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
        "date": 1625002280331,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.287727140674933,
            "unit": "ns",
            "range": "± 0.2760327313074423"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 573.3876663085754,
            "unit": "ns",
            "range": "± 3.961636680252784"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 35.592397690824875,
            "unit": "ns",
            "range": "± 0.36781549750786446"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.522007035321257,
            "unit": "ns",
            "range": "± 0.10734474701630503"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.470345617885586,
            "unit": "ns",
            "range": "± 0.10787213397448812"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 569.4107331296015,
            "unit": "ns",
            "range": "± 4.187336510723832"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.320237699191363,
            "unit": "ns",
            "range": "± 0.20726596487853624"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 585.5710155573136,
            "unit": "ns",
            "range": "± 5.607679030241108"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2103.5303381297554,
            "unit": "ns",
            "range": "± 20.221251024199372"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 62448.75234638968,
            "unit": "ns",
            "range": "± 651.6907596089635"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 61856.60534706893,
            "unit": "ns",
            "range": "± 614.5772985488541"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 66251.50121172065,
            "unit": "ns",
            "range": "± 537.1077713366293"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2201.5384615384614,
            "unit": "ns",
            "range": "± 102.30516191202746"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.883949244603173,
            "unit": "ns",
            "range": "± 0.2441184921658876"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 575.8141001269911,
            "unit": "ns",
            "range": "± 5.824835951943436"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.86436725666443,
            "unit": "ns",
            "range": "± 0.28060098235142045"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2144.798511878158,
            "unit": "ns",
            "range": "± 26.25520314916047"
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
        "date": 1625501863982,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.41628580470632,
            "unit": "ns",
            "range": "± 0.3039249168414122"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 592.2501382057128,
            "unit": "ns",
            "range": "± 6.306576358867936"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 36.99251938434479,
            "unit": "ns",
            "range": "± 0.7155950496222014"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.199101225153584,
            "unit": "ns",
            "range": "± 0.13012954264831594"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.396495163392736,
            "unit": "ns",
            "range": "± 0.23031425990115478"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 583.9824506730705,
            "unit": "ns",
            "range": "± 10.04142656110079"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.38717783693405,
            "unit": "ns",
            "range": "± 0.3210804063094475"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 600.385038876834,
            "unit": "ns",
            "range": "± 9.647132349462856"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2191.1198622091356,
            "unit": "ns",
            "range": "± 28.18721404853691"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 64470.52020843799,
            "unit": "ns",
            "range": "± 963.0092339361082"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 64443.40122199593,
            "unit": "ns",
            "range": "± 895.988906954993"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 68766.90118392247,
            "unit": "ns",
            "range": "± 681.9772215723634"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2353.061224489796,
            "unit": "ns",
            "range": "± 93.76842222626296"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.86950214822936,
            "unit": "ns",
            "range": "± 0.4098140814658568"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 589.8048391175168,
            "unit": "ns",
            "range": "± 9.698931603729292"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.800528349389616,
            "unit": "ns",
            "range": "± 0.5248182865736123"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2172.26515719369,
            "unit": "ns",
            "range": "± 28.065446665805595"
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
        "date": 1626429247149,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.32623178237783,
            "unit": "ns",
            "range": "± 0.12880915065217838"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 587.1109713901762,
            "unit": "ns",
            "range": "± 5.957041132864807"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 35.19307159463944,
            "unit": "ns",
            "range": "± 0.3735715832895045"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.34661932438708,
            "unit": "ns",
            "range": "± 0.07394265316776133"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.300734902406377,
            "unit": "ns",
            "range": "± 0.12017480399216297"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 582.4212542520987,
            "unit": "ns",
            "range": "± 5.895011764335456"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.3390501107146,
            "unit": "ns",
            "range": "± 0.15263351560481114"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 605.2209958503558,
            "unit": "ns",
            "range": "± 4.1243864262948104"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2127.5683030942246,
            "unit": "ns",
            "range": "± 30.100061074552507"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 61991.532562482615,
            "unit": "ns",
            "range": "± 773.5319429380016"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 63402.600598323006,
            "unit": "ns",
            "range": "± 1123.6968849116895"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 67062.35576053536,
            "unit": "ns",
            "range": "± 815.529235808124"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1948.4848484848485,
            "unit": "ns",
            "range": "± 80.84633903975207"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 23.346270337213305,
            "unit": "ns",
            "range": "± 0.24668491361538442"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 590.9475934877099,
            "unit": "ns",
            "range": "± 8.331094834337959"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 35.31079230002227,
            "unit": "ns",
            "range": "± 0.6676173914462398"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2152.3514532686404,
            "unit": "ns",
            "range": "± 19.98115354058831"
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
        "date": 1626805751094,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.66987854701825,
            "unit": "ns",
            "range": "± 0.04921311778748886"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 488.29268308584597,
            "unit": "ns",
            "range": "± 1.2438411679208423"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.68259630727149,
            "unit": "ns",
            "range": "± 0.06791978301729977"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.740037542560394,
            "unit": "ns",
            "range": "± 0.029206794515397864"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.743074871862047,
            "unit": "ns",
            "range": "± 0.07285905229317598"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 494.6433578201438,
            "unit": "ns",
            "range": "± 2.1930759305206893"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.338862834042946,
            "unit": "ns",
            "range": "± 0.023350960484900596"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 500.978918973996,
            "unit": "ns",
            "range": "± 2.4218684239982875"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1875.2046519675323,
            "unit": "ns",
            "range": "± 12.890791163552379"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 53270.492396043825,
            "unit": "ns",
            "range": "± 406.46617602924425"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 52677.35141714484,
            "unit": "ns",
            "range": "± 338.91620759664505"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 57158.91317774162,
            "unit": "ns",
            "range": "± 336.1087222138654"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1853.1914893617022,
            "unit": "ns",
            "range": "± 71.78186712348443"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 19.401047772349745,
            "unit": "ns",
            "range": "± 0.20359036035382783"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 487.2522177797215,
            "unit": "ns",
            "range": "± 1.6299401039785377"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 29.132409250369676,
            "unit": "ns",
            "range": "± 0.2658007651573355"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1897.84005779076,
            "unit": "ns",
            "range": "± 16.852225350654102"
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
        "date": 1628203710423,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.654000886708324,
            "unit": "ns",
            "range": "± 0.04139244148412386"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 485.4415671422155,
            "unit": "ns",
            "range": "± 3.0596109163170344"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.77401092767837,
            "unit": "ns",
            "range": "± 0.07227617721674887"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.724559217846926,
            "unit": "ns",
            "range": "± 0.03451785537758591"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.706181667925827,
            "unit": "ns",
            "range": "± 0.020111069748729806"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 482.6481529876559,
            "unit": "ns",
            "range": "± 2.248692825534253"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.388883624311617,
            "unit": "ns",
            "range": "± 0.04550597930154389"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 486.8211873944851,
            "unit": "ns",
            "range": "± 2.0181654469504346"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1819.025893395395,
            "unit": "ns",
            "range": "± 9.689489279875875"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 51618.43012735157,
            "unit": "ns",
            "range": "± 196.6833994226355"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 51577.70698010104,
            "unit": "ns",
            "range": "± 227.2958036364912"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 55751.82486631016,
            "unit": "ns",
            "range": "± 221.88304746491897"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 1754.5454545454545,
            "unit": "ns",
            "range": "± 74.08249110427843"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.69098854395661,
            "unit": "ns",
            "range": "± 0.07123614250023233"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 480.52653250394525,
            "unit": "ns",
            "range": "± 2.752810433028316"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 28.2662245190481,
            "unit": "ns",
            "range": "± 0.09705441071104172"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1858.0122145978917,
            "unit": "ns",
            "range": "± 4.382904033773109"
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
        "date": 1628712290631,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.200501458105256,
            "unit": "ns",
            "range": "± 0.30130257790180826"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 611.983677284229,
            "unit": "ns",
            "range": "± 15.927151811374829"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 41.8516046328326,
            "unit": "ns",
            "range": "± 0.812910261925969"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.493005738470194,
            "unit": "ns",
            "range": "± 0.14582543211780646"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.680689561701028,
            "unit": "ns",
            "range": "± 0.25548489405453984"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 615.4500500720094,
            "unit": "ns",
            "range": "± 17.847723649159676"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.206827170454467,
            "unit": "ns",
            "range": "± 0.22996651169642626"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 614.3329303610656,
            "unit": "ns",
            "range": "± 12.104474288717796"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2378.9298361045494,
            "unit": "ns",
            "range": "± 128.34923048481338"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 65707.46758015531,
            "unit": "ns",
            "range": "± 1841.240362769867"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 67949.99133322702,
            "unit": "ns",
            "range": "± 1482.8730895071246"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 75613.03389222172,
            "unit": "ns",
            "range": "± 1962.6324548201903"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2530.3030303030305,
            "unit": "ns",
            "range": "± 106.65501101819534"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.205477454160935,
            "unit": "ns",
            "range": "± 0.4031846526533237"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 609.1887468496913,
            "unit": "ns",
            "range": "± 11.47885054031009"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 34.209605864698354,
            "unit": "ns",
            "range": "± 0.9644632106228338"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2279.6687093633345,
            "unit": "ns",
            "range": "± 134.9483175981249"
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
        "date": 1630682565906,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.318220395323111,
            "unit": "ns",
            "range": "± 0.29125719936748834"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 616.2386906975076,
            "unit": "ns",
            "range": "± 9.72533238440639"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 41.58927446865167,
            "unit": "ns",
            "range": "± 0.5404113262575918"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.576583594053295,
            "unit": "ns",
            "range": "± 0.22155905619073066"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.794653114350808,
            "unit": "ns",
            "range": "± 0.1705880617151338"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 598.8805435654532,
            "unit": "ns",
            "range": "± 11.578075100733091"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 22.571765539688023,
            "unit": "ns",
            "range": "± 0.34703290491425026"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 609.0870302847854,
            "unit": "ns",
            "range": "± 8.624435624102688"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2327.9545589722243,
            "unit": "ns",
            "range": "± 46.66830978334475"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 65886.4923366781,
            "unit": "ns",
            "range": "± 1672.5789862097588"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 62975.736028470536,
            "unit": "ns",
            "range": "± 1331.8166342908892"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 68842.46336835105,
            "unit": "ns",
            "range": "± 2151.7417956355957"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2622.680412371134,
            "unit": "ns",
            "range": "± 196.05757797943323"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.69339062189549,
            "unit": "ns",
            "range": "± 0.367609885492641"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 591.7857363164745,
            "unit": "ns",
            "range": "± 10.190922089799537"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.73938058130573,
            "unit": "ns",
            "range": "± 0.6256471898589276"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2367.212186630263,
            "unit": "ns",
            "range": "± 40.66684784076919"
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
        "date": 1633035810622,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.362926239471891,
            "unit": "ns",
            "range": "± 0.25510785103410355"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 607.4827955701088,
            "unit": "ns",
            "range": "± 9.465617324166907"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 38.18447883745307,
            "unit": "ns",
            "range": "± 0.6248271999785393"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.126814181986669,
            "unit": "ns",
            "range": "± 0.21865145263955157"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.949722386488997,
            "unit": "ns",
            "range": "± 0.10983897653063375"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 612.6501242020652,
            "unit": "ns",
            "range": "± 6.825321638687531"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.549710708561847,
            "unit": "ns",
            "range": "± 0.31846708637289467"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 629.6683034916093,
            "unit": "ns",
            "range": "± 12.616961740848653"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2403.460226792308,
            "unit": "ns",
            "range": "± 41.55149867867419"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 67958.52334900778,
            "unit": "ns",
            "range": "± 1169.474594909999"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 66349.33295859097,
            "unit": "ns",
            "range": "± 831.2521782402831"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 71435.36753590326,
            "unit": "ns",
            "range": "± 945.3423863247092"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2836.4583333333335,
            "unit": "ns",
            "range": "± 175.99030575374957"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.72910303791467,
            "unit": "ns",
            "range": "± 0.3063606491225068"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 625.7500590876006,
            "unit": "ns",
            "range": "± 5.649815674994577"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 37.422920651956744,
            "unit": "ns",
            "range": "± 0.4102424717205751"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2353.0349902761573,
            "unit": "ns",
            "range": "± 39.25952004882754"
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
        "date": 1636704883774,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 12.59897015860629,
            "unit": "ns",
            "range": "± 0.033508745941930276"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 490.41053618135237,
            "unit": "ns",
            "range": "± 1.8197064473183562"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 29.51466206366924,
            "unit": "ns",
            "range": "± 0.06903699088069025"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.647659752054539,
            "unit": "ns",
            "range": "± 0.030662315477488444"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.646199480993827,
            "unit": "ns",
            "range": "± 0.02521459189042249"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 487.8686473692188,
            "unit": "ns",
            "range": "± 3.3403738784139207"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 19.28476897829839,
            "unit": "ns",
            "range": "± 0.04358222741219979"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 501.2203209576842,
            "unit": "ns",
            "range": "± 2.6703421100948"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 1942.218258879574,
            "unit": "ns",
            "range": "± 8.498465412232537"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 51798.86921404163,
            "unit": "ns",
            "range": "± 211.26372439009575"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 51676.246122026896,
            "unit": "ns",
            "range": "± 194.53206816220822"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 54518.19145000169,
            "unit": "ns",
            "range": "± 158.44106916406213"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2200,
            "unit": "ns",
            "range": "± 109.29064207170002"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 18.058792238409968,
            "unit": "ns",
            "range": "± 0.07681181631449972"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 478.7895718749193,
            "unit": "ns",
            "range": "± 1.5695545181250383"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 29.14464726981282,
            "unit": "ns",
            "range": "± 0.2622085891597364"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1795.6330052804487,
            "unit": "ns",
            "range": "± 7.051452108504715"
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
        "date": 1636704938762,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 14.84897499866089,
            "unit": "ns",
            "range": "± 0.41176487623928315"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 594.8083470934046,
            "unit": "ns",
            "range": "± 17.436685980123944"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 37.65040277905225,
            "unit": "ns",
            "range": "± 0.5215561206742653"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.097552896930896,
            "unit": "ns",
            "range": "± 0.12378657033937572"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.05861045681724,
            "unit": "ns",
            "range": "± 0.08849235946369174"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 563.126578755054,
            "unit": "ns",
            "range": "± 9.188355197687269"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 22.45842689573279,
            "unit": "ns",
            "range": "± 0.37077427440513133"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 579.8037194873126,
            "unit": "ns",
            "range": "± 8.68048500291433"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2109.975864915545,
            "unit": "ns",
            "range": "± 52.33324573506083"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 64768.480046195305,
            "unit": "ns",
            "range": "± 1451.4609022030772"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 64282.17492292749,
            "unit": "ns",
            "range": "± 1144.0529757792817"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 67337.33529982154,
            "unit": "ns",
            "range": "± 1322.1087709105161"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2654.081632653061,
            "unit": "ns",
            "range": "± 204.16708709529328"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 21.146230934293442,
            "unit": "ns",
            "range": "± 0.3813005048539362"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 582.0858699292289,
            "unit": "ns",
            "range": "± 14.161292193539618"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 34.81715822973569,
            "unit": "ns",
            "range": "± 0.7084740065195541"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2122.040249390399,
            "unit": "ns",
            "range": "± 53.11036437465623"
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
        "date": 1636972395218,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 14.280510150159472,
            "unit": "ns",
            "range": "± 0.25733372352452444"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 543.186502299919,
            "unit": "ns",
            "range": "± 9.06107499681426"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 36.85631515067542,
            "unit": "ns",
            "range": "± 1.3378975499400567"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 8.76200113234844,
            "unit": "ns",
            "range": "± 0.6832960589971817"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 8.370881442609441,
            "unit": "ns",
            "range": "± 0.16268715273598075"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 529.8109986621153,
            "unit": "ns",
            "range": "± 17.901784087643826"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 22.26427441319211,
            "unit": "ns",
            "range": "± 1.00714301573665"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 570.6379719229668,
            "unit": "ns",
            "range": "± 11.976304065525552"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2069.8552577118126,
            "unit": "ns",
            "range": "± 50.658229497198235"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 61583.063059934706,
            "unit": "ns",
            "range": "± 2425.739259338083"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 59425.9465905076,
            "unit": "ns",
            "range": "± 1127.8008177958775"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 63770.737469719395,
            "unit": "ns",
            "range": "± 1728.428249800569"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2818.0851063829787,
            "unit": "ns",
            "range": "± 185.47397345600393"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.117178162982096,
            "unit": "ns",
            "range": "± 0.6103719013756381"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 573.5164938451932,
            "unit": "ns",
            "range": "± 21.179754879627232"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 33.19790762847712,
            "unit": "ns",
            "range": "± 1.255742954875297"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 1894.4458662215284,
            "unit": "ns",
            "range": "± 44.6516067696102"
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
        "date": 1637601580248,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.08567217792072,
            "unit": "ns",
            "range": "± 0.11794495268748166"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 654.4345098748616,
            "unit": "ns",
            "range": "± 9.052613489508206"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 35.98581579244781,
            "unit": "ns",
            "range": "± 0.4114733694178682"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.439654190325077,
            "unit": "ns",
            "range": "± 0.141628641691951"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.457464960288581,
            "unit": "ns",
            "range": "± 0.10703551387289624"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 627.1123947216715,
            "unit": "ns",
            "range": "± 5.036891346590434"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 22.918790070565723,
            "unit": "ns",
            "range": "± 0.4616507513702664"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 654.22903697822,
            "unit": "ns",
            "range": "± 13.20856916714931"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2237.471975090924,
            "unit": "ns",
            "range": "± 29.09674059328481"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 63363.22647995824,
            "unit": "ns",
            "range": "± 653.608932109433"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 63151.25857338821,
            "unit": "ns",
            "range": "± 899.1470081520432"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 65973.09974493219,
            "unit": "ns",
            "range": "± 1342.1872541685477"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2522.7272727272725,
            "unit": "ns",
            "range": "± 138.73589623028826"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 22.03387296869081,
            "unit": "ns",
            "range": "± 0.28270995455233006"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 650.2371565360761,
            "unit": "ns",
            "range": "± 7.609631239007481"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 35.07650930995716,
            "unit": "ns",
            "range": "± 0.39304274544160017"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2227.3929533930523,
            "unit": "ns",
            "range": "± 25.672546058008685"
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
        "date": 1637706604206,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 14.256165018610556,
            "unit": "ns",
            "range": "± 0.21028307358807896"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 562.7193935978597,
            "unit": "ns",
            "range": "± 12.077373247678272"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 35.10872832255074,
            "unit": "ns",
            "range": "± 0.4404943482214929"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 10.025093413273286,
            "unit": "ns",
            "range": "± 0.2373760778245105"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 10.323953758421746,
            "unit": "ns",
            "range": "± 0.21582813713815407"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 554.2192735073638,
            "unit": "ns",
            "range": "± 8.379661971914803"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 22.290905162375275,
            "unit": "ns",
            "range": "± 0.2314372567909056"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 567.8476111657869,
            "unit": "ns",
            "range": "± 7.674200955865372"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2270.896696723374,
            "unit": "ns",
            "range": "± 34.091900821008835"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 65838.5510958037,
            "unit": "ns",
            "range": "± 1341.7891655008755"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 63534.61516874952,
            "unit": "ns",
            "range": "± 925.3584645817025"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 67043.61917276637,
            "unit": "ns",
            "range": "± 553.2244806449675"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2578.9473684210525,
            "unit": "ns",
            "range": "± 111.38229229816551"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.623457996826616,
            "unit": "ns",
            "range": "± 0.5449957022692282"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 569.9917221929978,
            "unit": "ns",
            "range": "± 10.595396529616016"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 32.53920762656806,
            "unit": "ns",
            "range": "± 0.7855900525698372"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2277.853718376827,
            "unit": "ns",
            "range": "± 40.239323485206974"
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
        "date": 1637706814768,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor",
            "value": 15.124097574491158,
            "unit": "ns",
            "range": "± 0.19536976754710833"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Constructor_SI",
            "value": 585.4618394068465,
            "unit": "ns",
            "range": "± 9.43016773420767"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.FromMethod",
            "value": 38.066459119535956,
            "unit": "ns",
            "range": "± 0.5955100079045899"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToProperty",
            "value": 9.242355423695084,
            "unit": "ns",
            "range": "± 0.10085003060925536"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As",
            "value": 9.331150781662181,
            "unit": "ns",
            "range": "± 0.18244023026910072"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.As_SI",
            "value": 583.3588311591363,
            "unit": "ns",
            "range": "± 4.9127662349587595"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit",
            "value": 23.244427245225406,
            "unit": "ns",
            "range": "± 0.3985170176480909"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToUnit_SI",
            "value": 596.9021059512305,
            "unit": "ns",
            "range": "± 9.474387958072505"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.ToStringTest",
            "value": 2176.7239893973656,
            "unit": "ns",
            "range": "± 30.54544168808035"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.Parse",
            "value": 67223.70946455505,
            "unit": "ns",
            "range": "± 1073.654604463416"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseValid",
            "value": 68638.3978127136,
            "unit": "ns",
            "range": "± 1099.728119783079"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.TryParseInvalid",
            "value": 70284.95726327009,
            "unit": "ns",
            "range": "± 1060.0491713720698"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.QuantityFrom",
            "value": 2779.381443298969,
            "unit": "ns",
            "range": "± 183.67665448298482"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As",
            "value": 20.705304696656306,
            "unit": "ns",
            "range": "± 0.3452900868195735"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_As_SI",
            "value": 580.2848383290657,
            "unit": "ns",
            "range": "± 8.298445695648057"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToUnit",
            "value": 35.07821452459088,
            "unit": "ns",
            "range": "± 0.7482992029908043"
          },
          {
            "name": "UnitsNet.Benchmark.UnitsNetBenchmarks.IQuantity_ToStringTest",
            "value": 2219.0744990404173,
            "unit": "ns",
            "range": "± 27.76083128116791"
          }
        ]
      }
    ]
  }
}