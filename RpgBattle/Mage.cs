namespace RpgBattle
{
    /// <summary>
    /// 魔法使いクラス —— Character を継承し、Attack をオーバーライドしたもう1つの例です。
    /// Warrior と比較すると、「同じ Attack() でも中身が違う」ことがよく分かります。
    /// </summary>
    public class Mage : Character
    {
        // 【ヒント】魔法使い専用のステータス例
        // public int Mp { get; private set; }
        // → コンストラクタで初期化し、攻撃時に MP を消費する処理を入れると本格的になる

        public Mage(string name, int maxHp, int attackPower, int defense)
            : base(name, maxHp, attackPower, defense)
        {
        }

        /// <summary>
        /// 火の玉による魔法攻撃。攻撃力 × 1.5 のダメージを与える。
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
            // ・MP を消費する（足りなければ「MPが足りない！」と表示）
            // ・ランダムで「氷の矢」「雷撃」など別メッセージを出す
            // ・例:
            //   string[] spells = { "火の玉", "氷の矢", "雷撃" };
            //   string spell = spells[Random.Shared.Next(spells.Length)];
            //   Console.WriteLine($"{Name} は{spell}を放った！");
        }
    }
}
