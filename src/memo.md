# 構成

アプリ環境|開発環境|SDK|概要
----------|--------|---|----
`1_Test`|dotnet|.NET Core 2.2|ClassLib(.NET Standard) + NUnit(.NET Core)
`2_1_Console_Core`|dotnet|.NET Core 2.2|ClassLib(.NET Standard) + ClassLib(.NET Core) + ConsoleApp(.NET Core)
`2_2_Console_Mono`|MonoDevelop|MONO 5.18.0|ClassLib(.NET Standard) + ClassLib(.NET Framework) + ConsoleApp(.NET Framework)
`3_Eto`|MonoDevelop|MONO 5.18.0|ClassLib(.NET Standard) + Eto(.NET Standard) + Eto.Desktop(.NET Framework)

## なぜ開発環境を分けるのか

　LinuxでC#を開発する環境には`MONO`か`.NET Core`が選択できる。しかし様々な制約によりプロジェクトを分ける必要がある。

* ラズパイでMonoDevelopのNUnitプロジェクトを実行したらメモリ不足になる
    * dotnetならNUnitを実行できた
        * 単体テストはMonoDevelopでなくdotnetで開発する
* Linuxで.NET Frameworkライブラリを使うにはMONOのみ可
    * Eto.Formsは.NET Frameworkを使っている
        * Eto.FormsアプリはMonoDevelopで開発する


