@echo off
SET MONO=%MONO_PREFIX%/bin/mono.exe
SET LD_LIBRARY_PATH=%MONO_PREFIX%/lib

%MONO% %MONO_PREFIX%/lib/mono/4.5/xbuild.exe %*
