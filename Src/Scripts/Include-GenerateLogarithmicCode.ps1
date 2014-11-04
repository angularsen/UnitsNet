# Generates arithmetic operators code for logarithmic units
function GenerateUnitClassSourceCode([string]$className, [string]$baseUnitFieldName, [string]$baseType, [int]$scalingFactor)
{
    # Most logarithmic operators need a simple scaling factor of 10. However, certain units such as voltage ratio need to
    # use 20 instead of 10.
    $x = 10 * $scalingFactor;
    
@"

        #region Arithmetic Operators

        public static $className operator -($className right)
        {
            return new $className(-right.$baseUnitFieldName);
        }

        public static $className operator +($className left, $className right)
        {
            // $x*log10(10^(x/$x) + 10^(y/$x)) -- logarithmic addition
            return new $className($x*Math.Log10(Math.Pow(10, left.$baseUnitFieldName/$x) + Math.Pow(10, right.$baseUnitFieldName/$x)));
        }

        public static $className operator -($className left, $className right)
        {
            // $x*log10(10^(x/$x) - 10^(y/$x)) -- logarithmic subtraction
            return new $className($x*Math.Log10(Math.Pow(10, left.$baseUnitFieldName/$x) - Math.Pow(10, right.$baseUnitFieldName/$x)));
        }

        public static $className operator *($baseType left, $className right)
        {
            // Logarithmic multiplication = addition
            return new $className(left + right.$baseUnitFieldName);
        }

        public static $className operator *($className left, double right)
        {
            // Logarithmic multiplication = addition
            return new $className(left.$baseUnitFieldName + ($baseType)right);
        }

        public static $className operator /($className left, double right)
        {
            // Logarithmic division = subtraction
            return new $className(left.$baseUnitFieldName - ($baseType)right);
        }

        public static double operator /($className left, $className right)
        {
            // Logarithmic division = subtraction
            return Convert.ToDouble(left.$baseUnitFieldName - right.$baseUnitFieldName);
        }

        #endregion
"@;
}

function GenerateTestBaseClassSourceCode([string]$className, [string]$baseUnitPluralName, $unit, [int]$scalingFactor)
{
@"
        [Test]
        public void ArithmeticOperators()
        {
            $className v = $className.From$baseUnitPluralName(40);
            Assert.AreEqual(-40, -v.$baseUnitPluralName, $($unit.PluralName)Tolerance);
            Assert.AreEqual($scalingFactor*23.3491145, ($className.From$baseUnitPluralName(50)-v).$baseUnitPluralName, $($unit.PluralName)Tolerance);
            Assert.AreEqual($scalingFactor*23.0102995, (v + v).$baseUnitPluralName, $($unit.PluralName)Tolerance);
            Assert.AreEqual(50, (v*10).$baseUnitPluralName, $($unit.PluralName)Tolerance);
            Assert.AreEqual(50, (10*v).$baseUnitPluralName, $($unit.PluralName)Tolerance);
            Assert.AreEqual(35, (v/5).$baseUnitPluralName, $($unit.PluralName)Tolerance);
            Assert.AreEqual(35, v/$className.From$baseUnitPluralName(5), $($unit.PluralName)Tolerance);
        }
"@;
}