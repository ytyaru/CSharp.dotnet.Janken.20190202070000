# dotnet publish

　`dotnet publish`は実行ファイルを作成するコマンドである。

パラメータ|パラメータ値の例|説明
----------|----------------|----
`-r`|`linux-arm`|実行環境（指定したCPUに対応した実行バイナリファイルを作成する）
`-f`|`netcoreapp2.2`|フレームワーク（.NET用フレームワーク。`netstandard2.0`, `net4.6.1`等がある）
`-c`|`Debug`|デフォルトは`Debug`。他には`Release`がある。なぜか出力ディレクトリにファイルサイズの差が無かった

　`-f`や`-c`を指定すると失敗する。特に必要がないため今の所は以下のコマンドを実行することにする。

```bash
dotnet publish -r linux-arm
```

