# クラス設計

クラス|概要
------|----
Hands.cs|✊✋✌の手を管理する
HandMaker.cs|どの手を出すか決める
Rule.cs|勝敗判定（じゃんけんの三すくみ）
Message.cs|ゲームで表示する文字を管理する
IWriter.cs|アプリ種別ごとの描画処理用インタフェース
Game.cs|ゲーム全体の流れを定義するフレームワーク

## Game

　ゲーム全体の流れは先に実装しておきたい。でも、アプリの種類ごとに実装の詳細は分けたい。

```
class Game {
    private Hands hands;
s    private RuleVsNpc rule;
    public IWriter Writer { get; set; } // ConsoleWriter, EtoTextAreaWriter

    public Game() {
        this.hands = new Hands();
        this.rule = new RuleVsNpc();
        this.writer = new ConsoleWriter();
    }
    public void Play() {
        this.Writer.Start(message.Start());
        Hands.Types player = this.hands.Random();
        Hands.Types npc = this.hands.Random();
        this.Writer.Hand(message.Hand(player, npc));
        this.Writer.Judge(message.Judge(rule.Judge(player, npc)));
    }
}
```

　出力の実装用インタフェース。

```
public interface IWriter {
    public void Start(string message);
    public void Hand(string message);
    public void Judge(string message);
}
```

ConsoleApp

```
class ConsoleWriter : IWriter
    public void Start(string message) {
        System.Console.WriteLine(message);
    }
    public void Hand(string message) {
        System.Console.WriteLine(message);
    }
    public void Judge(string message) {
        System.Console.WriteLine(message);
    }
}
```
```
using Janken

    public void Main() {
        Game game = new Game();
        game.Writer = new ConsoleWriter();
        game.Play();
    }
```

EtoApp

```
class EtoTextAreaWriter : IWriter
    private TextArea textArea;
    public EtoTextAreaWriter(TextArea textArea) {
        this.textArea = textArea;
    }
    public void Start(string message) {
        this.textArea.Text += message + "\n";
    }
    public void Hand(string message) {
        this.textArea.Text += message + "\n";
    }
    public void Judge(string message) {
        this.textArea.Text += message + "\n";
    }
}
```
```
using Janken
    private TextArea textArea;
    public void Main() {
        this.textArea = new TextArea();
        Game game = new Game();
        game.Writer = new EtoTextAreaWriter(this.textArea);
        game.Play();
    }
```

