This project contains all the issues we found so far while trying to update our mono to MonoBleedingEdge
Usage example:

Mac/Linux
```
export MONO_PREFIX=~/unity/lane2/External/MonoBleedingEdge/builds/monodistribution
```

```
./build MonoTests.csproj
./run bin/Debug/MonoTests.exe gdi
```

or just (MONO_PREFIX is still requried):
```
./build_and_run
```


Windows
```
set MONO_PREFIX=C:\unity\lane2\External\MonoBleedingEdge\builds\monodistribution
```

```
build.bat MonoTests.csproj
run.bat bin/Debug/MonoTests.exe gdi
```

or just (MONO_PREFIX is still requried):
```
./build_and_run
```
