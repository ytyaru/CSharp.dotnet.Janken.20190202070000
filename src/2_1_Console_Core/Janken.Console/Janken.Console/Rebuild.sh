ProductName=Janken
EndpointName=${ProductName}.Console
AppName=${EndpointName}
dotnet restore
dotnet publish -r linux-arm
"${AppName}/bin/Debug/netcoreapp2.2/linux-arm/${AppName}"

