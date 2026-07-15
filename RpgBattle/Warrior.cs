namespace RpgBattle;

/// <summary>
/// 戦士クラス —— Character を継承し、Attack をオーバーライドした例です。
/// 【学習ポイント②③ 継承・ポリモーフィズム】
/// ・「: Character」で親のフィールドやメソッドを使える
/// ・override で Attack の中身だけ差し替える → 同じ Attack() 呼び出しでも動きが変わる
/// </summary>
public class Warrior : Character
{
    // 【ヒント】派生クラスだけのフィールドを追加してもよい
    // 例: private int _criticalRate;（クリティカル発生率）

    public Warrior(string name, int maxHp, int attackPower, int defense)
        : base(name, maxHp, attackPower, defense) // 親のコンストラクタに渡す
    {
    }

    /// <summary>
    /// 剣での物理攻撃。攻撃力 × 1.2 のダメージを与える。
    /// </summary>
    public override void Attack(Character target)
    {
        if (!IsAlive)
        {
            return;
        }

        Console.WriteLine($"{Name} の剣での攻撃！");
        int damage = (int)(AttackPower * 1.2);
        target.TakeDamage(damage);

        // 【ヒント・課題】攻撃をアレンジしてみよう
        // ・ランダムでクリティカルヒット（ダメージ2倍）を発生させる
        // ・Random rnd = new Random(); if (rnd.Next(100) < 20) { ... }
        // ・コンソールに「クリティカルヒット！」と表示すると分かりやすい
    }
}

// ============================================================================
// 【課題：継承してキャラクターを増やす】※ここは受講者が実装するパートです
/**
 * 下のコメントアウト例を参考に、新しいクラスファイル（例: Archer.cs / Healer.cs）を作ってみよう。
 *
 * --- 手順のヒント ---
 * 1. 新しい .cs ファイルを作成する（クラス名はファイル名と同じにすると分かりやすい）
 * 2. public class ○○ : Character  と書いて Character を継承する
 * 3. コンストラクタで base(name, maxHp, attackPower, defense) を呼び出す
 * 4. Attack を override して、その職業らしいメッセージとダメージ計算を書く
 * 5. Program.cs で new ○○(...) として登場させる
 *
 * --- アイデア例 ---
 * ・Archer（弓使い）… 「〇〇は矢を放った！」 攻撃力はそのまま、防御を無視する特殊攻撃など
 * ・Healer（僧侶）… 「〇〇は杖で叩いた！」 攻撃は弱め。別メソッド HealAlly を追加しても楽しい
 * ・Thief（盗賊）… 低めの攻撃力だが、ランダムで「急所を突いた！」と高ダメージ
 *
 * --- ひな型メモ（コピーして使う）---
 *
 * namespace RpgBattle;
 *
 * public class Archer : Character
 * {
 *     public Archer(string name, int maxHp, int attackPower, int defense)
 *         : base(name, maxHp, attackPower, defense)
 *     {
 *     }
 *
 *     public override void Attack(Character target)
 *     {
 *         if (!IsAlive) return;
 *         Console.WriteLine($"{Name} は矢を放った！");
 *         // TODO: ダメージ計算を書いて target.TakeDamage(...) を呼ぶ
 *     }
 * }
 */
// ============================================================================
