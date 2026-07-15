# 受講者向け演習ヒント

ひな型を動かし終わったら、下の順で拡張してみましょう。

## 課題A: 継承してキャラクターを増やす（未実装パート）

新しいファイル（例: `Archer.cs`）を作り、`Character` を継承します。

1. ソリューションエクスプローラーでプロジェクトを右クリック → **追加 → クラス**
2. 次のような骨格を書く

```csharp
namespace RpgBattle
{
    public class Archer : Character
    {
        public Archer(string name, int maxHp, int attackPower, int defense)
            : base(name, maxHp, attackPower, defense)
        {
        }

        public override void Attack(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            Console.WriteLine($"{Name} は矢を放った！");
            // TODO: ダメージ計算を書いて target.TakeDamage(...) を呼ぶ
        }
    }
}
```

3. `Program.cs` で `new Archer(...)` として登場させる

### アイデア例

- **Archer（弓使い）** … 「矢を放った！」／防御を無視する攻撃など
- **Healer（僧侶）** … 攻撃は弱め。味方回復用のメソッドを追加しても楽しい
- **Thief（盗賊）** … ランダムで「急所を突いた！」と高ダメージ

## 課題B: ポリモーフィズムの Attack をアレンジ

`Warrior` / `Mage` のコメントを参考に、クリティカルや MP 消費などを足してみましょう。

## 課題C: 戦闘ループの拡張

敵の AI（HP が半分以下なら回復）、回復回数の制限などを `Program.cs` に追加できます。
