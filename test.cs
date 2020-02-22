//css_args /ac;           - interpret as auto-class (classless) script

// C#7 support
//css_args -provider:%CSSCRIPT_DIR%\lib\CSSRoslynProvider.dll
//css_ref %CSSCRIPT_DIR%\lib\Bin\Roslyn\System.ValueTuple.dll

//css_ref ..\Artifacts\UnitsNet\net40\UnitsNet.dll
using System;

void main(string[] args)
{
    Console.WriteLine($"Length: {UnitsNet.Length.FromMeters(1).ToString()}");
}
