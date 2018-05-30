<#
.SYNOPSIS
Generates the C# source code for logarithmic arithmetic operators.

.PARAMETER quantityName
The name of the unit.

.PARAMETER baseUnitFieldName
The name of the backing field used to store the unit's value.

.PARAMETER baseType
The data type of the backing field used to store the unit's value.

.PARAMETER scalingFactor
The scaling factor used in logarithmic calculations. In most cases this is equal to 1.
#>
function GenerateLogarithmicArithmeticOperators([string]$quantityName, [string]$baseUnitFieldName, [string]$baseType, [int]$scalingFactor)
{
    # Most logarithmic operators need a simple scaling factor of 10. However, certain units such as voltage ratio need to
    # use 20 instead of 10.
    $x = 10 * $scalingFactor;

@"

        #region Logarithmic Arithmetic Operators

        // Windows Runtime Component does not allow operator overloads: https://msdn.microsoft.com/en-us/library/br230301.aspx
#if !WINDOWS_UWP
        public static $quantityName operator -($quantityName right)
        {
            return new $quantityName(-right.Value, right.Unit);
        }

        public static $quantityName operator +($quantityName left, $quantityName right)
        {
            // Logarithmic addition
            // Formula: $x*log10(10^(x/$x) + 10^(y/$x))
            return new $quantityName($x*Math.Log10(Math.Pow(10, left.Value/$x) + Math.Pow(10, right.AsBaseNumericType(left.Unit)/$x)), left.Unit);
        }

        public static $quantityName operator -($quantityName left, $quantityName right)
        {
            // Logarithmic subtraction
            // Formula: $x*log10(10^(x/$x) - 10^(y/$x))
            return new $quantityName($x*Math.Log10(Math.Pow(10, left.Value/$x) - Math.Pow(10, right.AsBaseNumericType(left.Unit)/$x)), left.Unit);
        }

        public static $quantityName operator *($baseType left, $quantityName right)
        {
            // Logarithmic multiplication = addition
            return new $quantityName(left + right.Value, right.Unit);
        }

        public static $quantityName operator *($quantityName left, double right)
        {
            // Logarithmic multiplication = addition
            return new $quantityName(left.Value + ($baseType)right, left.Unit);
        }

        public static $quantityName operator /($quantityName left, double right)
        {
            // Logarithmic division = subtraction
            return new $quantityName(left.Value - ($baseType)right, left.Unit);
        }

        public static double operator /($quantityName left, $quantityName right)
        {
            // Logarithmic division = subtraction
            return Convert.ToDouble(left.Value - right.AsBaseNumericType(left.Unit));
        }
#endif

        #endregion
"@;
}
