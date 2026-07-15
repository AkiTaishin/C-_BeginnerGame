namespace RpgBattle;

/// <summary>
/// 魔法使いクラス —— Character を継承し、Attack をオーバーライドしたもう1つの例です。
/// Warrior と比較すると、「同じ Attack() でも中身が違う」ことがよく分かります。
/// </summary>
public class Mage : Character
{
    // 【ヒント】魔法使い専用のステータス例
    // private int _mp;
    // private int _magicPower;
    // → コンストラクタで初期化し、攻撃時に MP を消費する処理を入れると本格的になる

    public Mage(string name, int maxHp, int attackPower, int defense)
        : base(name, maxHp, attackPower, defense)
    {
    }

    /// <summary>
    /// 火の玉による魔法攻撃。攻撃力 × 1.5 のダメージを与える（代わりにHPは低めに設定するのがおすすめ）。
    /// </summary>
    public override void Attack(Character target)
    {
        if (!IsAlive)
        {
            return;
        }

        Console.WriteLine($"{Name} は火の玉を放った！");
        int damage = (int)(AttackPower * 1.5);
        target.TakeDamage(damage);

        // 【ヒント・課題】魔法攻撃をアレンジしてみよう
        // ・MP を消費する（足りなければ「MPが足りない！」と表示して通常攻撃にフォールバック）
        // ・敵の防御力を半分だけしか考慮しない強力魔法にする
        // ・ランダムで「氷の矢」「雷撃」など別メッセージを出すとバリエーションが増える
        //
        // 例（疑似コード）:
        // string[] spells = { "火の玉", "氷の矢", "雷撃" };
        // string spell = spells[new Random().Next(spells.Length)];
        // Console.WriteLine($"{Name} は{spell}を放った！");
    }
}
