set LogDir=%CD%\..\Artifacts\Logs
set TestsBinDir=%CD%\..\Artifacts\Bin\Tests\AnyCPU_Release
mkdir %LogDir%

..\Tools\NUnit\nunit-console.exe "%TestsBinDir%\net35\UnitsNet.Tests.net35.dll" /framework="net-4.0" /xml:%LogDir%\UnitsNet.Tests.net35.xml