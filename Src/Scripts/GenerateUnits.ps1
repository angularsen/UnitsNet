function GetUnits($unitClass)
{
    $units = @();
    
    foreach ($unit in $unitClass.Units)
    {
        $units += $unit;
        $prefixIndex = 0;
        foreach ($prefix in $unit.Prefixes)
        {
            $prefixInfo = switch ($prefix)
            {
                "Kilo" { "k", "1e3"; break; }
                "Hecto" { "h", "1e2"; break; }
                "Deca" { "da", "1e1"; break; }
                "Deci" { "d", "1e-1"; break; }
                "Centi" { "c", "1e-2"; break; }
                "Milli" { "m", "1e-3"; break; }
                "Micro" { "μ", "1e-6"; break; }
                "Nano" { "n", "1e-9"; break; }

                # Optimization, move less frequently used prefixes to the end
                "Pico" { "p", "1e-12"; break; }
                "Femto" { "f", "1e-15"; break; }
                "Atto" { "a", "1e-18"; break; }
                "Zepto" { "z", "1e-21"; break; }
                "Yocto" { "y", "1e-24"; break; }

                "Yotta" { "Y", "1e24"; break; }
                "Zetta" { "Z", "1e21"; break; }
                "Exa" { "E", "1e18"; break; }
                "Peta" { "P", "1e15"; break; }
                "Tera" { "T", "1e12"; break; }
                "Giga" { "G", "1e9"; break; }
                "Mega" { "M", "1e6"; break; }

            }
            
            $prefixAbbreviation = $prefixInfo[0];
            $prefixFactor = $prefixInfo[1];
            
            $u = New-Object PsObject -Property @{ 
                SingularName=$prefix+$unit.SingularName.ToLowerInvariant(); 
                PluralName=$prefix+$unit.PluralName.ToLowerInvariant();
                FromUnitToBaseFunc="("+$unit.FromUnitToBaseFunc+") * $prefixFactor";
                FromBaseToUnitFunc="("+$unit.FromBaseToUnitFunc+") / $prefixFactor";
                Localization=$unit.Localization | % { 
                    $abbrev = $prefixAbbreviation + $_.Abbreviations[0];
                    if ($_.AbbreviationsWithPrefixes) {
                        $abbrev = $_.AbbreviationsWithPrefixes[$prefixIndex++];
                    }
                    
                New-Object PsObject -Property @{
                    Culture=$_.Culture;
                    Abbreviations= $abbrev;
                }};
            }
            
            $units += $u;
        }
    }
    
    return $units | sort SingularName;
}

function GenerateUnitClass($unitClass)
{
    Write-Host "Generate unit for: " + $unitClass.Name;    
    
    $outFileName = "$PSScriptRoot/../UnitsNet/GeneratedCode/UnitClasses/$($unitClass.Name).g.cs";
    GenerateUnitClassSourceCode $unitClass | Out-File -Encoding "UTF8" $outFileName
}

function GenerateUnitTestBaseClass($unitClass)
{
    Write-Host "Generate test for: " + $unitClass.Name;    
    
    $outFileName = "$PSScriptRoot/../../Tests/GeneratedCode/$($unitClass.Name)TestsBase.g.cs";
    GenerateUnitTestBaseClassSourceCode $unitClass | Out-File -Encoding "UTF8" $outFileName
}

function GenerateUnitEnum($unitClass)
{
    Write-Host "Generate unit enum for: " + $unitClass.Name;

    $outDir = "$PSScriptRoot/../UnitsNet/GeneratedCode/Enums";
    $outFileName = "$outDir/$($unitClass.Name)Unit.g.cs";
    
    New-Item -ItemType Directory -Force -Path $outDir; # Make sure directory exists
    
    $result = GenerateUnitEnumSourceCode $unitClass;
    $result | Out-File -Encoding "UTF8" $outFileName;
}

function GenerateUnitSystemDefault($unitClasses)
{
    Write-Host "Generate UnitSystem.Default.g.cs.";

    $outDir = "$PSScriptRoot/../UnitsNet/GeneratedCode";
    $outFileName = "$outDir/UnitSystem.Default.g.cs";

    New-Item -ItemType Directory -Force -Path $outDir; # Make sure directory exists
    
    $result = GenerateUnitSystemDefaultSourceCode $unitClasses;
    $result | Out-File -Encoding "UTF8" $outFileName;
}



# Load external generator functions with same name as file
. "$PSScriptRoot/Include-GenerateUnitSystemDefaultSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitClassSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitEnumSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitTestBaseClassSourceCode.ps1"

$templatesDir = "$PSScriptRoot/UnitDefinitions";
$unitClasses = @();

get-childitem -path $templatesDir -filter "*.json" | % {
    $templateFile = $_.FullName
    $json = (Get-Content $templateFile | Out-String)
    $unitClass = $json | ConvertFrom-Json

    # Expand unit prefixes into units
    $unitClass.Units = GetUnits $unitClass;
    
    GenerateUnitClass $unitClass
    GenerateUnitEnum $unitClass
    GenerateUnitTestBaseClass $unitClass
    
    $unitClasses += $unitClass;
}

GenerateUnitSystemDefault $unitClasses