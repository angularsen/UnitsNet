@echo off
SET ROOT=%~dp0..
%WinDir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe %ROOT%\Build\tests.msbuild /verbosity:normal /p:Configuration=Release /p:Platform="AnyCPU" /target:CleanAndBuild /p:RestorePackages=false
