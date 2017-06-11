@echo off
powershell -ExecutionPolicy Bypass -NoProfile -File %~dp0\Build\build.ps1
