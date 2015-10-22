# DaddyCool => daddyCool
function ToCamelCase($str)
{
    return $str.Substring(0,1).ToLowerInvariant() + $str.Substring(1);
}

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
                "Kilo" { "k", "1e3d"; break; }
                "Hecto" { "h", "1e2d"; break; }
                "Deca" { "da", "1e1d"; break; }
                "Deci" { "d", "1e-1d"; break; }
                "Centi" { "c", "1e-2d"; break; }
                "Milli" { "m", "1e-3d"; break; }
                "Micro" { "μ", "1e-6d"; break; }
                "Nano" { "n", "1e-9d"; break; }

                # Optimization, move less frequently used prefixes to the end
                "Pico" { "p", "1e-12d"; break; }
                "Femto" { "f", "1e-15d"; break; }
                "Atto" { "a", "1e-18d"; break; }
                "Zepto" { "z", "1e-21d"; break; }
                "Yocto" { "y", "1e-24d"; break; }

                "Yotta" { "Y", "1e24d"; break; }
                "Zetta" { "Z", "1e21d"; break; }
                "Exa" { "E", "1e18d"; break; }
                "Peta" { "P", "1e15d"; break; }
                "Tera" { "T", "1e12d"; break; }
                "Giga" { "G", "1e9d"; break; }
                "Mega" { "M", "1e6d"; break; }

                # Binary prefixes
                "Kibi" { "Ki", "1024d"; break; }
                "Mebi" { "Mi", "(1024d * 1024)"; break; }
                "Gibi" { "Gi", "(1024d * 1024 * 1024)"; break; }
                "Tebi" { "Ti", "(1024d * 1024 * 1024 * 1024)"; break; }
                "Pebi" { "Pi", "(1024d * 1024 * 1024 * 1024 * 1024)"; break; }
                "Exbi" { "Ei", "(1024d * 1024 * 1024 * 1024 * 1024 * 1024)"; break; }
            }            
            
            $prefixAbbreviation = $prefixInfo[0];
            $prefixFactor = $prefixInfo[1];

            $u = New-Object PsObject -Property @{ 
                SingularName=$prefix + $(ToCamelCase $unit.SingularName); 
                PluralName=$prefix + $(ToCamelCase $unit.PluralName);
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
    
    foreach ($u in $units) {
        # Use decimal for internal calculations if base type is not double, such as for long or int.
        if ($unitClass.BaseType -ne "double") {
            $u.FromUnitToBaseFunc = $u.FromUnitToBaseFunc -replace "m", "d";
            $u.FromBaseToUnitFunc = $u.FromBaseToUnitFunc -replace "d", "m";
        }
        
        # Convert to/from double for other base types
        if ($unitClass.BaseType -eq "decimal") {
            $u.FromUnitToBaseFunc = "Convert.ToDecimal($($u.FromUnitToBaseFunc))";
            $u.FromBaseToUnitFunc = "Convert.ToDouble($($u.FromBaseToUnitFunc))";
        } else { 
            if ($unitClass.BaseType -eq "long") {
              $u.FromUnitToBaseFunc = "Convert.ToInt64($($u.FromUnitToBaseFunc))";
              $u.FromBaseToUnitFunc = "Convert.ToDouble($($u.FromBaseToUnitFunc))";
            }
        }
    }
    
    return $units | sort SingularName;
}

function GenerateUnitClass($unitClass)
{
    Write-Host "Generate unit for: " + $unitClass.Name;    
    
    $outFileName = "$PSScriptRoot/../GeneratedCode/UnitClasses/$($unitClass.Name).g.cs";
    GenerateUnitClassSourceCode $unitClass | Out-File -Encoding "UTF8" $outFileName
}

function GenerateUnitTestBaseClass($unitClass)
{
    Write-Host "Generate test base for: " + $unitClass.Name;    
    
    $outFileName = "$PSScriptRoot/../../UnitsNet.Tests/GeneratedCode/$($unitClass.Name)TestsBase.g.cs";
    GenerateUnitTestBaseClassSourceCode $unitClass | Out-File -Encoding "UTF8" $outFileName
}

function GenerateUnitTestClassIfNotExists($unitClass)
{
    $outFileName = "$PSScriptRoot/../../UnitsNet.Tests/CustomCode/$($unitClass.Name)Tests.cs";
    if (Test-Path $outFileName) 
    {
        return;
    } 
    else 
    {
        Write-Host "Generate test placeholder for: " + $unitClass.Name;
        GenerateUnitTestPlaceholderSourceCode $unitClass | Out-File -Encoding "UTF8" $outFileName
    }
}

function GenerateUnitEnum($unitClass)
{
    Write-Host "Generate unit enum for: " + $unitClass.Name;

    $outDir = "$PSScriptRoot/../GeneratedCode/Enums";
    $outFileName = "$outDir/$($unitClass.Name)Unit.g.cs";
    
    New-Item -ItemType Directory -Force -Path $outDir; # Make sure directory exists
    
    $result = GenerateUnitEnumSourceCode $unitClass;
    $result | Out-File -Encoding "UTF8" $outFileName;
}

function GenerateUnitSystemDefault($unitClasses)
{
    Write-Host "Generate UnitSystem.Default.g.cs.";

    $outDir = "$PSScriptRoot/../GeneratedCode";
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
. "$PSScriptRoot/Include-GenerateUnitTestPlaceholderSourceCode.ps1"

$templatesDir = "$PSScriptRoot/UnitDefinitions";
$unitClasses = @();

get-childitem -path $templatesDir -filter "*.json" | % {
    $templateFile = $_.FullName
    $json = (Get-Content $templateFile | Out-String)
    $unitClass = $json | ConvertFrom-Json

    # Set default values
    if (!$unitClass.BaseType) {
        $unitClass | Add-Member BaseType "double";
    }
    # 'Logarithmic' is optional in the .json file and assumed to be false if not specified
    if (!$unitClass.Logarithmic) {
        $unitClass | Add-Member Logarithmic "False"
    }
    if (!$unitClass.LogarithmicScalingFactor) {
        $unitClass | Add-Member LogarithmicScalingFactor "1"
    }
  
    # Expand unit prefixes into units
    $unitClass.Units = GetUnits $unitClass;
    
    GenerateUnitClass $unitClass
    GenerateUnitEnum $unitClass
    GenerateUnitTestBaseClass $unitClass
    GenerateUnitTestClassIfNotExists $unitClass
    
    $unitClasses += $unitClass;
}

GenerateUnitSystemDefault $unitClasses