ProductName=Janken
EndpointName=${ProductName}.Test
SlnName=${EndpointName}
TestName=${EndpointName}
cd "${SlnName}"
echo "========== Test =========="
time dotnet test "${TestName}/${TestName}.csproj"
