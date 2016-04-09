@echo off
SET ROOT=%~dp0..
set LogDir=%ROOT%\Artifacts\Logs
set TestsBinDir=%ROOT%\Artifacts\Bin\Tests\AnyCPU_Release
mkdir %LogDir%

%ROOT%\Tools\NUnit\nunit-console.exe "%TestsBinDir%\UnitsNet.Tests.dll" /framework="net-4.5" /xml:%LogDir%\UnitsNet.Tests.xml
if %errorlevel% neq 0 exit /b %errorlevel%

%ROOT%\Tools\NUnit\nunit-console.exe "%TestsBinDir%\UnitsNet.WindowsRuntimeComponent.Tests.dll" /framework="net-4.5" /xml:%LogDir%\UnitsNet.WindowsRuntimeComponent.Tests.xml
if %errorlevel% neq 0 exit /b %errorlevel%

%ROOT%\Tools\NUnit\nunit-console.exe "%TestsBinDir%\UnitsNet.Serialization.JsonNet.Tests.dll" /framework="net-4.5" /xml:%LogDir%\UnitsNet.Serialization.JsonNet.Tests.xml
if %errorlevel% neq 0 exit /b %errorlevel%