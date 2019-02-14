MakeProject() {
    # 1. プロジェクト作成
    ProductName=Janken
    EndpointName=${ProductName}.Test
    SlnName=${EndpointName}
    mkdir "${SlnName}"
    cd "${SlnName}"
    dotnet new sln -n "${SlnName}"
#    LibName=${ProductName}
#    dotnet new classlib -n "${LibName}" -f netstandard2.0
#    TestName=${LibName}.Test
    TestName=${EndpointName}
    dotnet new nunit -n "${TestName}"

    # 2. ソリューションにプロジェクトを追加する
    dotnet sln add "${TestName}/${TestName}.csproj"
#    dotnet sln add "${LibName}/${LibName}.csproj"
    dotnet sln add "../../0_Lib/${ProductName}/${ProductName}/${ProductName}.csproj"

    # 3. プロジェクトに追加する
    cd ${TestName}
    # 3-1. テスト用パッケージMoqを追加する
    dotnet add package Moq
#    dotnet add reference "../${LibName}/${LibName}.csproj"
    # 3-2. テスト対象を追加する
    dotnet add reference "../../../0_Lib/${ProductName}/${ProductName}/${ProductName}.csproj"
    cd ..
}
RunTest() {
    # 4. テスト実行
    dotnet test "${TestName}/${TestName}.csproj"
}
echo "========== Make projects =========="
time MakeProject
echo "========== Run tests =========="
time RunTest

