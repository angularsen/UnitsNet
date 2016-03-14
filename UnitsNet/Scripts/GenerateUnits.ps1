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

function GenerateUnitClass($unitClass, $outDir)
{
    $outFileName = "$outDir/$($unitClass.Name).g.cs";
    GenerateUnitClassSourceCode $unitClass | Out-File -Encoding "UTF8" $outFileName | Out-Null
	if (!$?) {
		exit 1
	}
	Write-Host -NoNewline "class(OK) "
}

function GenerateUnitTestBaseClass($unitClass, $outDir)
{
    $outFileName = "$outDir/$($unitClass.Name)TestsBase.g.cs";
    GenerateUnitTestBaseClassSourceCode $unitClass | Out-File -Encoding "UTF8" $outFileName | Out-Null
	if (!$?) {
		exit 1
	}
	Write-Host -NoNewline "test base(OK) "
}

function GenerateUnitTestClassIfNotExists($unitClass, $outDir)
{
	Write-Host -NoNewline "test stub"
    $outFileName = "$outDir/$($unitClass.Name)Tests.cs";
    if (Test-Path $outFileName)
    {
		Write-Host -NoNewline "(skip) "
        return;
    }
    else
    {
        GenerateUnitTestPlaceholderSourceCode $unitClass | Out-File -Encoding "UTF8" $outFileName | Out-Null
		if (!$?) {
			exit 1
		}
		Write-Host -NoNewline "(OK) "
    }
}

function GenerateUnitEnum($unitClass, $outDir)
{
    $outFileName = "$outDir/$($unitClass.Name)Unit.g.cs";

    GenerateUnitEnumSourceCode $unitClass | Out-File -Encoding "UTF8" -Force $outFileName | Out-Null;
	if (!$?) {
		exit 1
	}
	Write-Host -NoNewline "enum(OK) "
}

function GenerateUnitSystemDefault($unitClasses, $outDir)
{
    Write-Host -NoNewline "UnitSystem.Default.g.cs: "; 
    $outFileName = "$outDir/UnitSystem.Default.g.cs";

    GenerateUnitSystemDefaultSourceCode $unitClasses | Out-File -Encoding "UTF8" -Force $outFileName | Out-Null;
	if (!$?) {
		Write-Host "(error) "
		exit 1
	}
	Write-Host "(OK) "
}

function EnsureDirExists([String] $dirPath) {
    New-Item -ItemType Directory -Force -Path $dirPath | Out-Null;
	if (!$?) {
		exit 1
	}
}

# Load external generator functions with same name as file
. "$PSScriptRoot/Include-GenerateTemplates.ps1"
. "$PSScriptRoot/Include-GenerateLogarithmicCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitSystemDefaultSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitClassSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitEnumSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitTestBaseClassSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitTestPlaceholderSourceCode.ps1"

EnsureDirExists ($unitClassDir = "$PSScriptRoot/../GeneratedCode/UnitClasses")
EnsureDirExists ($unitEnumDir = "$PSScriptRoot/../GeneratedCode/Enums")
EnsureDirExists ($unitSystemDir = "$PSScriptRoot/../GeneratedCode")
EnsureDirExists ($testsDir = "$PSScriptRoot/../../UnitsNet.Tests/GeneratedCode")
EnsureDirExists ($testsCustomCodeDir = "$PSScriptRoot/../../UnitsNet.Tests/CustomCode")

$templatesDir = "$PSScriptRoot/UnitDefinitions"
$unitClasses = @();

$pad = 25
$unitCounter = 0;
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
	$unitCounter += $unitClass.Units.Count

	Write-Host -NoNewline "$($unitClass.Name):".PadRight($pad)
    GenerateUnitClass $unitClass $unitClassDir
    GenerateUnitEnum $unitClass $unitEnumDir
    GenerateUnitTestBaseClass $unitClass $testsDir
    GenerateUnitTestClassIfNotExists $unitClass $testsCustomCodeDir

    $unitClasses += $unitClass;
	Write-Host ""
}

Write-Host ""
GenerateUnitSystemDefault $unitClasses $unitSystemDir

Write-Host ""
Write-Host ""
Write-Host "Summary: $($unitCounter) units in $($unitClasses.Count) classes".PadRight($pad)