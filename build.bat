set nuget=
if "%nuget%" == "" (
    set nuget=nuget
)

%nuget% pack "HabitRPG.Client.nuspec" -NoPackageAnalysis -OutputDirectory $buildArtifactsDirectory