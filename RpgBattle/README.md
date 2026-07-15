# RPGバトルひな型（C#・オブジェクト指向学習用）

コンソール（CUI）で動くターン制 RPG バトルの学習用ひな型です。  
**カプセル化・継承・ポリモーフィズム**を体感しながら、約5時間程度の演習で拡張できます。

## 必要な環境

| ツール | 対応 |
|--------|------|
| **Visual Studio 2026**（推奨） | .NET デスクトップ開発 / .NET 10 |
| Visual Studio 2017 / Express | **非対応** |

ターゲットは **`net10.0`** です。

## 開き方（Visual Studio 2026）

1. リポジトリ直下の [`RpgBattle.sln`](../RpgBattle.sln) をダブルクリックして開く  
2. ソリューションエクスプローラーに `Character.cs` / `Warrior.cs` / `Mage.cs` / `Program.cs` が **1つずつ** 見えることを確認  
3. **ビルド → ソリューションのリビルド**  
4. **Ctrl+F5** で実行（`1` 戦う / `2` 回復 / `3` 逃げる）

## 「'Character._name' と 'Character._name' 間があいまいです」(CS0229)

同じメンバー名どうしであいまいになるのは、**同じソースが二重に取り込まれている**ときです。

よくある原因:

- `Character - コピー.cs` / `Character (1).cs` など退避コピーが同じフォルダに残っている  
- 古い Visual Studio が `.csproj` を壊し、同じ `.cs` を2回コンパイルしている  
- `bin` / `obj` / `.vs` の古いキャッシュが残っている  

対処手順:

1. Visual Studio を閉じる  
2. フォルダ `RpgBattle/bin`・`RpgBattle/obj`・リポジトリの `.vs` を削除する  
3. `RpgBattle` 内に「コピー」「(1)」付きの `.cs` があれば削除する  
4. Git で変更を破棄し、最新の `RpgBattle.csproj` に戻す  
5. **`RpgBattle.sln`（リポジトリ直下）** を開き直してリビルドする  

このひな型の `.csproj` は、ソースを1ファイルずつ明示指定しており、コピー文件はビルドに入りません。

## コマンドライン

```bash
dotnet build RpgBattle.sln
dotnet run --project RpgBattle/RpgBattle.csproj
```

## ファイル構成

| ファイル | 内容 | 受講者の作業 |
|----------|------|--------------|
| `Character.cs` | 基底クラス（カプセル化済み） | ステータスやメソッドの追加 |
| `Warrior.cs` | 戦士（Attack の override 例） | クリティカルなどのアレンジ |
| `Mage.cs` | 魔法使い（Attack の override 例） | MP 消費などのアレンジ |
| `Program.cs` | 戦闘ループ | 敵 AI やキャラ差し替え |
| `EXERCISES.md` | 継承でキャラを増やす課題 | 新規クラスの追加実装 |

## 学習の進め方

1. 動かして「剣での攻撃」「火の玉」の違いを確認する  
2. `Character.cs` でカプセル化（`private set`）を読む  
3. [`EXERCISES.md`](EXERCISES.md) に沿って派生クラスを追加する  
4. `Attack` の override をアレンジする  
5. 戦闘ループを拡張する  
