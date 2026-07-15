namespace RpgBattle
{
    /// <summary>
    /// 戦士クラス —— Character を継承し、Attack をオーバーライドした例です。
    /// 【学習ポイント②③ 継承・ポリモーフィズム】
    /// ・「: Character」で親の機能を使える
    /// ・override で Attack の中身だけ差し替える → 同じ Attack() 呼び出しでも動きが変わる
    /// </summary>
    public class Warrior : Character
    {
        // 【ヒント】派生クラスだけのフィールド／プロパティを追加してもよい
        // 例: public int CriticalRate { get; private set; }

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
            // ・例:
            //   if (Random.Shared.Next(100) < 20)
            //   {
            //       Console.WriteLine("クリティカルヒット！");
            //       damage *= 2;
            //   }
        }
    }
}
