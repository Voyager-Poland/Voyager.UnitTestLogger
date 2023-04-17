$version='1.0.2'
dotnet build -c Release   /property:Version=$version
dotnet pack -c Release /property:Version=$version

$ostatniPakiet = (gci .\src\Voyager.UnitTestLogger\bin\Release\*.nupkg | select -last 1).Name
$sciezka = ".\src\Voyager.UnitTestLogger\bin\Release\$ostatniPakiet"

dotnet nuget push "$sciezka" -s Voyager-Poland
