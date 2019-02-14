ProductName=Janken
EndpointName=${ProductName}.Console
SlnName=${EndpointName}
AppName=${EndpointName}
cd "${SlnName}"
echo "========== Build =========="
Configuration=Release
Runtime=linux-arm
Framework=netcoreapp2.2
time dotnet restore
#time dotnet publish -c ${Configuration} -f ${Framework} -r ${Runtime}
#time dotnet publish -c ${Configuration} -r ${Runtime}
time dotnet publish -r ${Runtime}
#echo "========== Test =========="
#time dotnet test "${AppName}/${AppName}.csproj"
echo "========== Run =========="
#"${AppName}/bin/${Configuration}/${Framework}/${Runtime}/${AppName}"
"${AppName}/bin/${Configuration}/${Framework}/${Runtime}/${AppName}"
cd ..

