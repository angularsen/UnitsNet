@echo off
SET ROOT=%~dp0..
set LogDir=%ROOT%\Artifacts\Logs
set TestsBinDir=%ROOT%\Artifacts\Bin\Tests\AnyCPU_Release
mkdir %LogDir%

%ROOT%\Tools\NUnit\nunit-console.exe "%TestsBinDir%\UnitsNet.Tests.dll" /framework="net-4.0" /xml:%LogDir%\UnitsNet.Tests.xml