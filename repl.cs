//css_args /ac;           - interpret as auto-class (classless) script

// C#7 support
//css_args -provider:%CSSCRIPT_DIR%\lib\CSSRoslynProvider.dll
//css_ref %CSSCRIPT_DIR%\lib\Bin\Roslyn\System.ValueTuple.dll

//css_ref tmp\UnitsNet.dll
using System;
using UnitsNet;

void main(string[] args)
{

    Console.WriteLine("Mass: " + Mass.Parse("1 short tn"));
    Console.WriteLine("Mass: " + Mass.FromShortTons(1).ToString("a1"));
    Console.WriteLine("Mass: " + Mass.Parse("1 ST"));
    Console.WriteLine("Mass: " + Mass.Parse("1 st"));
    Console.WriteLine("Mass: " + Mass.Parse("1 St"));
}
