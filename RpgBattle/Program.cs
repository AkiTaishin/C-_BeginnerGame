namespace RpgBattle
{
    /// <summary>
    /// ターン制 RPG バトルのメインプログラムです。
    /// 【学習ポイント④ 戦闘ループ】
    /// while で「どちらかの HP が 0 になるまで」ターンを繰り返し、
    /// プレイヤーの入力（戦う / 逃げる / 回復する）を受け付けます。
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("   ターン制 RPG バトル ひな型");
            Console.WriteLine("=================================");
            Console.WriteLine();

            // ---------- キャラクター生成 ----------
            // Character 型の変数に Warrior / Mage を入れることで、ポリモーフィズムが活きる
            Character player = new Warrior("勇者", 50, 12, 3);
            Character enemy = new Mage("スライム魔術師", 40, 10, 1);

            // 【ヒント・課題】敵や味方を差し替えてみよう
            // ・player を Mage にする、enemy を Warrior にする
            // ・自分で作った Archer / Healer などをここに new する
            // 例: Character player = new Archer("弓使いアリス", 45, 14, 2);

            Console.WriteLine("戦いが始まった！");
            player.ShowStatus();
            enemy.ShowStatus();
            Console.WriteLine();

            bool fled = false;
            int turn = 1;

            // ---------- 戦闘ループ ----------
            // 条件: 両者とも生存中、かつ逃げていない → ターンを繰り返す
            while (player.IsAlive && enemy.IsAlive && !fled)
            {
                Console.WriteLine($"----- ターン {turn} -----");
                player.ShowStatus();
                enemy.ShowStatus();
                Console.WriteLine();

                // ----- プレイヤーの行動選択 -----
                Console.WriteLine("どうする？");
                Console.WriteLine("  1. 戦う");
                Console.WriteLine("  2. 回復する");
                Console.WriteLine("  3. 逃げる");
                Console.Write("番号を入力して Enter > ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        // Attack は Warrior / Mage など実際の型の override が呼ばれる（ポリモーフィズム）
                        player.Attack(enemy);
                        break;

                    case "2":
                        // 簡易ポーション：固定値で回復
                        player.Heal(15);
                        // 【ヒント】回復量をランダムにする、回数制限を付ける、なども追加できる
                        break;

                    case "3":
                        // 50% の確率で逃走成功
                        if (Random.Shared.Next(100) < 50)
                        {
                            Console.WriteLine($"{player.Name} はうまく逃げ切った！");
                            fled = true;
                        }
                        else
                        {
                            Console.WriteLine($"{player.Name} は逃げられなかった…！");
                        }
                        break;

                    default:
                        Console.WriteLine("正しい番号（1〜3）を入力してください。このターンは様子を見ます。");
                        break;
                }

                // 逃げ成功、または敵が倒れたら敵の反撃はスキップ
                if (fled || !enemy.IsAlive)
                {
                    Console.WriteLine();
                    turn++;
                    continue;
                }

                // ----- 敵の行動（シンプルに攻撃のみ） -----
                Console.WriteLine();
                enemy.Attack(player);

                // 【ヒント・課題】敵の AI を少し賢くしてみよう
                // ・敵の HP が半分以下なら回復を優先する
                // if (enemy.Hp < enemy.MaxHp / 2) { enemy.Heal(8); } else { enemy.Attack(player); }

                Console.WriteLine();
                turn++;
            }

            // ---------- 勝敗判定 ----------
            Console.WriteLine("=================================");
            if (fled)
            {
                Console.WriteLine("戦闘を離脱した…");
            }
            else if (player.IsAlive)
            {
                Console.WriteLine($"{enemy.Name} をたおした！ 勝利！");
            }
            else
            {
                Console.WriteLine($"{player.Name} はたおれてしまった… 敗北…");
            }
            Console.WriteLine("=================================");

            Console.WriteLine();
            Console.WriteLine("Enter キーで終了します…");
            Console.ReadLine();
        }
    }
}
