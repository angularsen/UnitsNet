# Set Write-Output used by Include- files to UTF8 encoding to fix copyright character
[Console]::OutputEncoding = [Text.UTF8Encoding]::UTF8
$OutputEncoding = [Text.UTF8Encoding]::UTF8

# DaddyCool => daddyCool
function ToCamelCase($str)
{
    return $str.Substring(0,1).ToLowerInvariant() + $str.Substring(1)
}


function GenerateQuantity($quantity, $outDir)
{
    $outFileName = "$outDir/../../../Common/GeneratedCode/Quantities/$($quantity.Name).Common.g.cs"
    GenerateQuantitySourceCodeCommon $quantity | Out-File -Encoding "UTF8" $outFileName | Out-Null
    if (!$?) {
        exit 1
    }
    Write-Host -NoNewline "quantity common(OK) "

    $outFileName = "$outDir/$($quantity.Name).NetFramework.g.cs"
    GenerateQuantitySourceCodeNetFramework $quantity | Out-File -Encoding "UTF8" $outFileName | Out-Null
    if (!$?) {
        exit 1
    }
    Write-Host -NoNewline "quantity .NET(OK) "

    $outFileName = "$outDir/../../../UnitsNet.WindowsRuntimeComponent/GeneratedCode/Quantities/$($quantity.Name).WindowsRuntimeComponent.g.cs"
    GenerateQuantitySourceCodeWindowsRuntimeComponent $quantity | Out-File -Encoding "UTF8" $outFileName | Out-Null
    if (!$?) {
        exit 1
    }
    Write-Host -NoNewline "quantity WRC(OK) "
}

function GenerateUnitTestBaseClass($quantity, $outDir)
{
    $outFileName = "$outDir/$($quantity.Name)TestsBase.g.cs"
    GenerateUnitTestBaseClassSourceCode $quantity | Out-File -Encoding "UTF8" $outFileName | Out-Null
    if (!$?) {
        exit 1
    }
    Write-Host -NoNewline "test base(OK) "
}

function GenerateUnitTestClassIfNotExists($quantity, $outDir)
{
    Write-Host -NoNewline "test stub"
    $outFileName = "$outDir/$($quantity.Name)Tests.cs"
    if (Test-Path $outFileName)
    {
        Write-Host -NoNewline "(skip) "
        return
    }
    else
    {
        GenerateUnitTestPlaceholderSourceCode $quantity | Out-File -Encoding "UTF8" $outFileName | Out-Null
        if (!$?) {
            exit 1
        }
        Write-Host -NoNewline "(OK) "
    }
}

function GenerateUnitType($quantity, $outDir)
{
    $outFileName = "$outDir/$($quantity.Name)Unit.g.cs"

    GenerateUnitTypeSourceCode $quantity | Out-File -Encoding "UTF8" -Force $outFileName | Out-Null
    if (!$?) {
        exit 1
    }
    Write-Host -NoNewline "unit(OK) "
}

function GenerateUnitSystemDefault($quantities, $outDir)
{
    Write-Host -NoNewline "UnitAbbreviationsCache.g.cs: "
    $outFileName = "$outDir/UnitAbbreviationsCache.g.cs"

    GenerateUnitSystemDefaultSourceCode $quantities | Out-File -Encoding "UTF8" -Force $outFileName | Out-Null
    if (!$?) {
        Write-Host "(error) "
        exit 1
    }
    Write-Host "(OK) "
}

function GenerateQuantityType($quantities, $outDir)
{
    Write-Host -NoNewline "QuantityType.g.cs: "
    $outFileName = "$outDir/QuantityType.g.cs"

    GenerateQuantityTypeSourceCode $quantities | Out-File -Encoding "UTF8" -Force $outFileName | Out-Null
    if (!$?) {
        Write-Host "(error) "
        exit 1
    }
    Write-Host "(OK) "
}

function EnsureDirExists([String] $dirPath) {
    New-Item -ItemType Directory -Force -Path $dirPath | Out-Null
    if (!$?) {
        exit 1
    }
}

function Set-DefaultValues {
    param ([Parameter(Mandatory = $true, ValueFromPipeline=$true)] $quantity)
    PROCESS {
        if (!$quantity.BaseType) {
            $quantity | Add-Member BaseType "double"
        }
        if ($quantity.GenerateArithmetic -eq $null) {
            $quantity | Add-Member GenerateArithmetic $true
        }
        # 'Logarithmic' is optional in the .json file and assumed to be false if not specified
        if (!$quantity.Logarithmic) {
            $quantity | Add-Member Logarithmic $false
        }
        elseif (!$quantity.LogarithmicScalingFactor) {
            $quantity | Add-Member LogarithmicScalingFactor 1
        }
        return $quantity
    }
}

function Set-ConversionFunctions
{
    param ([Parameter(Mandatory = $true, ValueFromPipeline=$true)] $quantity)
    PROCESS {
        foreach ($u in $quantity.Units) {

            # Use decimal for internal calculations if base type is not double, such as for long or int.
            if ($quantity.BaseType -eq "decimal") {
                $u.FromUnitToBaseFunc = $u.FromUnitToBaseFunc -replace "d", "m"
                $u.FromBaseToUnitFunc = $u.FromBaseToUnitFunc -replace "d", "m"
            }

            # Convert to/from double for other base types
            $u.FromUnitToBaseFunc = "$($u.FromUnitToBaseFunc)"
            $u.FromBaseToUnitFunc = "$($u.FromBaseToUnitFunc)"
        }
        return $quantity
    }
}

function Add-PrefixUnits {
    param ([Parameter(Mandatory = $true, ValueFromPipeline=$true)] $quantity)
    PROCESS {
        $prefixUnits = @()

        foreach ($unit in $quantity.Units)
        {
            $prefixIndex = 0
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
                    "Micro" { "µ", "1e-6d"; break; }
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

                $prefixAbbreviation = $prefixInfo[0]
                $prefixFactor = $prefixInfo[1]

                $prefixUnit = New-Object PsObject -Property @{
                    SingularName=$prefix + $(ToCamelCase $unit.SingularName)
                    PluralName=$prefix + $(ToCamelCase $unit.PluralName)
                    FromUnitToBaseFunc="("+$unit.FromUnitToBaseFunc+") * $prefixFactor"
                    FromBaseToUnitFunc="("+$unit.FromBaseToUnitFunc+") / $prefixFactor"
                    Localization=$unit.Localization | % {
                        $abbrev = $prefixAbbreviation + $_.Abbreviations[0]
                        if ($_.AbbreviationsWithPrefixes) {
                            $abbrev = $_.AbbreviationsWithPrefixes[$prefixIndex]
                        }

                    New-Object PsObject -Property @{
                        Culture=$_.Culture
                        Abbreviations= $abbrev
                    }}
                }

                # Append prefix unit
                $prefixUnits += $prefixUnit
                $prefixIndex++;
            } # foreach prefixes
        } # foreach units

    $quantity.Units += $prefixUnits
    return $quantity
    }
}

function Set-UnitsOrderedByName {
    param ([Parameter(Mandatory = $true, ValueFromPipeline=$true)] $quantity)
    PROCESS {
        $quantity.Units = ($quantity.Units | sort SingularName)
        return $quantity
    }
}

function Add-InheritedUnits($quantity, $quantities) {

    foreach ($inheritFromQuantityName in $quantity.InheritUnitsFrom) {
        $inheritFromQuantity = $quantities | Where { $_.Name -eq $inheritFromQuantityName } | Select -First 1
        $quantity.Units += $inheritFromQuantity.Units

        Write-Host -NoNewline "(inherit $inheritFromQuantityName) "
    }
}

# Load external generator functions with same name as file
. "$PSScriptRoot/Include-GenerateTemplates.ps1"
. "$PSScriptRoot/Include-GenerateLogarithmicCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitSystemDefaultSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateQuantityTypeSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateQuantitySourceCodeCommon.ps1"
. "$PSScriptRoot/Include-GenerateQuantitySourceCodeNetFramework.ps1"
. "$PSScriptRoot/Include-GenerateQuantitySourceCodeWindowsRuntimeComponent.ps1"
. "$PSScriptRoot/Include-GenerateUnitTypeSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitTestBaseClassSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitTestPlaceholderSourceCode.ps1"

EnsureDirExists ($quantityDir = "$PSScriptRoot/../GeneratedCode/Quantities")
EnsureDirExists ($unitEnumDir = "$PSScriptRoot/../GeneratedCode/Units")
EnsureDirExists ($unitSystemDir = "$PSScriptRoot/../GeneratedCode")
EnsureDirExists ($testsDir = "$PSScriptRoot/../../UnitsNet.Tests/GeneratedCode")
EnsureDirExists ($testsCustomCodeDir = "$PSScriptRoot/../../UnitsNet.Tests/CustomCode")

$templatesDir = "$PSScriptRoot/../../Common/UnitDefinitions"
$pad = 25

# Parse unit definitions from .json files and populate properties
$quantities = Get-ChildItem -Path $templatesDir -filter "*.json" `
    | %{(Get-Content $_.FullName -Encoding "UTF8" | Out-String)} `
    | ConvertFrom-Json `
    | Set-DefaultValues `
    | Add-PrefixUnits `
    | Set-ConversionFunctions `
    | Set-UnitsOrderedByName

foreach ($quantity in $quantities) {
    Write-Host -NoNewline "$($quantity.Name):".PadRight($pad)

    Add-InheritedUnits $quantity $quantities

    GenerateQuantity $quantity $quantityDir
    GenerateUnitType $quantity $unitEnumDir
    GenerateUnitTestBaseClass $quantity $testsDir
    GenerateUnitTestClassIfNotExists $quantity $testsCustomCodeDir

    Write-Host ""
}

Write-Host ""
GenerateUnitSystemDefault $quantities $unitSystemDir
GenerateQuantityType $quantities $unitSystemDir

$unitCount = ($quantities | %{$_.Units.Count} | Measure -Sum).Sum

Write-Host "`n`n"
Write-Host -Foreground Yellow "Summary: $unitCount units in $($quantities.Count) quantities".PadRight($pad)
Write-Host "`n`n"
exit 0
