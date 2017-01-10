@echo off
for /l %%x in (1, 1, 20) do (
  call build.bat /t:clean MonoTests.csproj > NUL
  call build.bat MonoTests.csproj > NUL

  call run.bat bin/Debug/MonoTests.exe embedded
)
