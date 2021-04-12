using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace CodeGen.Generators.NanoFrameworkGen
{
    class PackageGenerator : GeneratorBase
    {
        string _mscorlibVersion;

        public PackageGenerator()
        {
            // get latest version of .NET nanoFramework mscorlib
            ILogger logger = NullLogger.Instance;
            CancellationToken cancellationToken = CancellationToken.None;

            SourceCacheContext cache = new SourceCacheContext();
            SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
            FindPackageByIdResource resource = repository.GetResourceAsync<FindPackageByIdResource>().Result;

            IEnumerable<NuGetVersion> versions = resource.GetAllVersionsAsync(
                "nanoFramework.CoreLibrary",
                cache,
                logger,
                cancellationToken).Result;

            // including preview
            _mscorlibVersion = versions.Where(v => v.IsPrerelease).OrderByDescending(v => v.Version).First().ToNormalizedString();

            // stable only
            _mscorlibVersion = versions.OrderByDescending(v => v.Version).First().ToNormalizedString();
        }

        public override string Generate()
        {

            Writer.W($@"
<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""nanoFramework.CoreLibrary"" version=""{_mscorlibVersion}"" targetFramework=""netnanoframework10"" />
</packages>");

            return Writer.ToString();
        }
    }
}
