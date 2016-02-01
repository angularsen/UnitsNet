@echo off
SET ROOT=%~dp0..
"C:\Program Files (x86)\MSBuild\14.0\Bin\MsBuild.exe" %ROOT%\Build\tests.msbuild /verbosity:normal /p:Configuration=Release /p:Platform="AnyCPU" /target:CleanAndBuild /p:RestorePackages=false
