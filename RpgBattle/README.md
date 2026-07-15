# RPGバトルひな型（C#・オブジェクト指向学習用）

コンソール（CUI）で動くターン制 RPG バトルの学習用ひな型です。  
**カプセル化・継承・ポリモーフィズム**を体感しながら、約5時間程度の演習で拡張できます。

## 必要な環境

| ツール | 対応 |
|--------|------|
| **Visual Studio 2026**（推奨） | .NET 10 コンソール開発 |
| Visual Studio 2022 | .NET 8/10 ワークロードが入っていれば可（要 TFM 合わせ） |
| Visual Studio 2017 / Express | **非対応**（クラスが表示されない・ビルド失敗の原因） |
| コマンドライン | .NET 10 SDK（`dotnet --list-sdks` で確認） |

このプロジェクトのターゲットは **`net10.0`** です（VS2026 既定の .NET 10 でエラーなく開けるようにしています）。

## Visual Studio 2026 での開き方

1. 以前に VS2017 などで開いていた場合は、まずローカルの変更を捨ててリポジトリを最新にする  
2. [`RpgBattle.sln`](RpgBattle.sln) をダブルクリックして開く（フォルダ全体ではなく **.sln** を開く）  
3. ソリューションエクスプローラーに `Character.cs` / `Warrior.cs` / `Mage.cs` / `Program.cs` が見えることを確認  
4. **ビルド → ソリューションのビルド**（Ctrl+Shift+B）  
5. **デバッグなしで開始**（Ctrl+F5）で実行  

メニューで `1`（戦う） / `2`（回復する） / `3`（逃げる） を入力します。

### 「クラスファイルが出ない」「参照だけ赤い」とき

多くの場合、古い Visual Studio がプロジェクトを別形式に変換した残骸です。

1. Visual Studio を閉じる  
2. `RpgBattle/bin` と `RpgBattle/obj` フォルダを削除する  
3. Git で `RpgBattle` をリポジトリの状態に戻す（変更の破棄）  
4. **Visual Studio 2026** で `RpgBattle.sln` をもう一度開く  

## コマンドライン

```bash
cd RpgBattle
dotnet restore
dotnet build
dotnet run
```

## ファイル構成

| ファイル | 内容 | 受講者の作業 |
|----------|------|--------------|
| `Character.cs` | 基底クラス（カプセル化済み） | ステータスやメソッドの追加 |
| `Warrior.cs` | 戦士（Attack の override 例） | クリティカルなどのアレンジ |
| `Mage.cs` | 魔法使い（Attack の override 例） | MP 消費などのアレンジ |
| `Program.cs` | 戦闘ループ | 敵 AI やキャラ差し替え |
| `EXERCISES.md` | 継承でキャラを増やす課題の手順 | ここを見ながら追加実装 |

## 学習の進め方（おすすめ順）

1. **動かして理解** — Ctrl+F5 で戦い、「剣での攻撃」「火の玉」の違いを確認する  
2. **カプセル化** — `Character.cs` の `private set` と `TakeDamage` / `Heal` を読む  
3. **継承でキャラ増加** — [`EXERCISES.md`](EXERCISES.md) に沿って `Archer` などを新規作成（※課題パートは未実装）  
4. **ポリモーフィズム** — `player.Attack(enemy)` が実際の型に応じて分岐することを確認する  
5. **戦闘ループ拡張** — 敵 AI や回復制限などを足す  

## 最初から動く内容

- 勇者（Warrior） vs スライム魔術師（Mage）のターン制バトル  
- 戦う / 回復する / 逃げる（50%成功）  
- HP が 0 になるまでループし、勝敗を表示  
