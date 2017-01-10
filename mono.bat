@echo off
set MONO=%MONO_PREFIX%/bin/mono
set MONO_PATH=%MONO_PREFIX%lib/mono/4.5

"%MONO%" %*

exit /b %ERRORLEVEL%
