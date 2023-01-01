namespace CodeGen.Generators.NanoFrameworkGen
{
    class PropertyGenerator : GeneratorBase
    {
        private readonly string _version;

        public PropertyGenerator(string version)
        {
            _version = version;
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.W($@"using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(""UnitsNet"")]
[assembly: AssemblyDescription(""Get all the common units of measurement and the conversions between them. It is light-weight and thoroughly tested."")]
[assembly: AssemblyConfiguration("""")]
[assembly: AssemblyCompany(""Andreas Gullberg Larsen"")]
[assembly: AssemblyProduct(""nanoFramework UnitsNet"")]
[assembly: AssemblyCopyright(""Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com)."")]
[assembly: AssemblyTrademark("""")]
[assembly: AssemblyCulture("""")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
[assembly: AssemblyVersion(""{_version}"")]
[assembly: AssemblyFileVersion(""{_version}"")]

//////////////////////////////////////////////////
// This assembly doens't require native support //
[assembly: AssemblyNativeVersion(""0.0.0.0"")]
//////////////////////////////////////////////////
");
            return Writer.ToString();
        }
    }
}
