@echo off
set MONO=%MONO_PREFIX%/bin/mono.exe
set LD_LIBRARY_PATH=%MONO_PREFIX%/lib
set MONO_PATH=%MONO_PREFIX%/mono/4.5
set MONO_CFG_DIR=%MONO_PREFIX%/etc

%MONO% %*
