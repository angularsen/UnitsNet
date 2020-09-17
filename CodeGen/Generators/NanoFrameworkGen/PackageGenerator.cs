using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGen.Generators.NanoFrameworkGen
{
    class PackageGenerator : GeneratorBase
    {
        public override string Generate()
        {
            Writer.W($@"
<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""nanoFramework.CoreLibrary"" version=""1.7.3"" targetFramework=""netnanoframework10"" />
</packages>");

            return Writer.ToString();
        }
    }
}
