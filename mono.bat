REM @echo off

set MONO=%MONO_PREFIX%/bin/mono
set MONO_PATH=%MONO_PREFIX%lib/mono/4.5
echo %MONO_PATH%
"%MONO%" %*
exit /b %ERRORLEVEL%