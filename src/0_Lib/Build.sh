ProductName=Janken
#EndpointName=${ProductName}.Test
EndpointName=${ProductName}
SlnName=${EndpointName}
TestName=${EndpointName}
cd "${SlnName}"
echo "========== Build =========="
time dotnet restore
time dotnet publish -r linux-arm -c Release
#echo "========== Test =========="
#time dotnet test "${TestName}/${TestName}.csproj"
cd ..

