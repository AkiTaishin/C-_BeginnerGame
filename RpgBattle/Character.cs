namespace RpgBattle;

/// <summary>
/// すべてのキャラクターの「親」となる基底クラスです。
/// 【学習ポイント① カプセル化】
/// ・HP や攻撃力などのデータは private / protected で外部から直接書き換えられないようにする
/// ・変更は TakeDamage / Heal などのメソッド経由で行う（ルールを1か所に集められる）
/// </summary>
public class Character
{
    // ========== フィールド（データ本体） ==========
    // private / protected にすることで、外部から = で勝手に書き換えられないようにしています（カプセル化）

    private string _name;
    private int _maxHp;
    private int _hp;
    private int _attackPower;
    private int _defense;

    // 【ヒント・課題】ステータスを増やしてみよう
    // ・例: private int _mp;（魔法ポイント）、private int _speed;（素早さ）
    // ・追加したら、コンストラクタで初期化し、必要ならプロパティやメソッドも用意する
    // ・Heal のように「回復アイテムの所持数」などを private で持つのも良い練習になる


    // ========== プロパティ（外部から安全に読む窓口） ==========
    // get だけ公開し、set は非公開（または protected）にすることで「外からは読むだけ」にしています

    public string Name => _name;
    public int MaxHp => _maxHp;
    public int Hp => _hp;
    public int AttackPower => _attackPower;
    public int Defense => _defense;

    /// <summary>HP が 1 以上なら生存中</summary>
    public bool IsAlive => _hp > 0;

    // 【ヒント】プロパティを追加する場合の例
    // public int Mp => _mp;
    // public bool CanUseMagic => _mp >= 5;


    /// <summary>
    /// キャラクターを生成するコンストラクタ
    /// </summary>
    public Character(string name, int maxHp, int attackPower, int defense)
    {
        _name = name;
        _maxHp = Math.Max(1, maxHp);
        _hp = _maxHp;
        _attackPower = Math.Max(0, attackPower);
        _defense = Math.Max(0, defense);
    }


    // ========== メソッド（振る舞い） ==========

    /// <summary>
    /// ダメージを受ける。防御力を差し引いた値だけ HP が減る。
    /// HP は 0 未満にならないよう制限している。
    /// </summary>
    public virtual void TakeDamage(int rawDamage)
    {
        int actualDamage = Math.Max(1, rawDamage - _defense); // 最低1ダメージ
        _hp = Math.Max(0, _hp - actualDamage);
        Console.WriteLine($"{_name} は {actualDamage} のダメージを受けた！（残りHP: {_hp}/{_maxHp}）");
    }

    /// <summary>
    /// HP を回復する。最大 HP を超えないよう制限している。
    /// </summary>
    public virtual void Heal(int amount)
    {
        int before = _hp;
        _hp = Math.Min(_maxHp, _hp + amount);
        int healed = _hp - before;
        Console.WriteLine($"{_name} は HP を {healed} 回復した！（残りHP: {_hp}/{_maxHp}）");
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

        Console.WriteLine($"{_name} の攻撃！");
        target.TakeDamage(_attackPower);
    }

    /// <summary>
    /// ステータスを1行で表示する
    /// </summary>
    public virtual void ShowStatus()
    {
        Console.WriteLine($"[{_name}] HP: {_hp}/{_maxHp}  攻撃: {_attackPower}  防御: {_defense}");
    }

    // 【ヒント・課題】メソッドを追加してみよう
    // ・Defend() … 次のターンだけ防御力を上げる
    // ・IsCritical() … 一定確率でクリティカル判定を返す
    // ・RestoreMp(int amount) … MP を回復する（MP フィールドを追加した場合）
    //
    // 【注意】フィールドを外から直接いじらず、必ずメソッド経由で変更する習慣をつけよう
}
