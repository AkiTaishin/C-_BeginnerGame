namespace RpgBattle
{
    /// <summary>
    /// すべてのキャラクターの「親」となる基底クラスです。
    /// 【学習ポイント① カプセル化】
    /// ・HP や攻撃力などのデータは private set で外部から直接書き換えられないようにする
    /// ・変更は TakeDamage / Heal などのメソッド経由で行う（ルールを1か所に集められる）
    /// </summary>
    public class Character
    {
        // ========== プロパティ（外部から安全に読む窓口） ==========
        // get は公開、set は private … 外からは読むだけ、書き換えるのはこのクラスの中だけ

        public string Name { get; private set; }
        public int MaxHp { get; private set; }
        public int Hp { get; private set; }
        public int AttackPower { get; private set; }
        public int Defense { get; private set; }

        /// <summary>HP が 1 以上なら生存中</summary>
        public bool IsAlive => Hp > 0;

        // 【ヒント・課題】ステータスを増やしてみよう
        // 例:
        //   public int Mp { get; private set; }
        //   public int Speed { get; private set; }
        // 追加したら、コンストラクタで初期化し、必要ならメソッドも用意する


        /// <summary>
        /// キャラクターを生成するコンストラクタ
        /// </summary>
        public Character(string name, int maxHp, int attackPower, int defense)
        {
            Name = name;
            MaxHp = Math.Max(1, maxHp);
            Hp = MaxHp;
            AttackPower = Math.Max(0, attackPower);
            Defense = Math.Max(0, defense);
        }


        // ========== メソッド（振る舞い） ==========

        /// <summary>
        /// ダメージを受ける。防御力を差し引いた値だけ HP が減る。
        /// HP は 0 未満にならないよう制限している。
        /// </summary>
        public virtual void TakeDamage(int rawDamage)
        {
            int actualDamage = Math.Max(1, rawDamage - Defense); // 最低1ダメージ
            Hp = Math.Max(0, Hp - actualDamage);
            Console.WriteLine($"{Name} は {actualDamage} のダメージを受けた！（残りHP: {Hp}/{MaxHp}）");
        }

        /// <summary>
        /// HP を回復する。最大 HP を超えないよう制限している。
        /// </summary>
        public virtual void Heal(int amount)
        {
            int before = Hp;
            Hp = Math.Min(MaxHp, Hp + amount);
            int healed = Hp - before;
            Console.WriteLine($"{Name} は HP を {healed} 回復した！（残りHP: {Hp}/{MaxHp}）");
        }

        /// <summary>
        /// 基本の攻撃。派生クラスで override して、メッセージやダメージ計算を変えられる（ポリモーフィズム）。
        /// </summary>
        public virtual void Attack(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            Console.WriteLine($"{Name} の攻撃！");
            target.TakeDamage(AttackPower);
        }

        /// <summary>
        /// ステータスを1行で表示する
        /// </summary>
        public virtual void ShowStatus()
        {
            Console.WriteLine($"[{Name}] HP: {Hp}/{MaxHp}  攻撃: {AttackPower}  防御: {Defense}");
        }

        // 【ヒント・課題】メソッドを追加してみよう
        // ・Defend() … 次のターンだけ防御力を上げる
        // ・一定確率でクリティカル判定をする
        //
        // 【注意】プロパティを外側から直接いじろうとせず、必ずメソッド経由で変更する習慣をつけよう
    }
}
