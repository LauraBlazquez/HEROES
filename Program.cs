using UtilsLibrary;
using Constants;

namespace GameProject
{
    public class BlazquezLauraCode
    {
        public static void Main()
        {
            int[] option = new int[2];
            int tries;
            string names, skip;
            string[] separatedNames = new string[4];
            do
            {
                tries = 0;
                Console.Clear();
                Console.WriteLine(Messages.Welcome);
                Console.WriteLine(Messages.Menu);
                do
                {
                    option[0] = Convert.ToInt32(Console.ReadLine());
                    tries++;
                    if (!Utils.InRangValidation(option[0], Values.Op0, Values.Op1) && tries < Values.Attemps)
                        Console.WriteLine(Messages.MsgErrorOption);
                } while (!Utils.InRangValidation(option[0], Values.Op0, Values.Op1) && tries < Values.Attemps);

                tries = 0;
                if (option[0] == Values.Op1)
                {
                    Console.Clear();
                    Console.WriteLine(Messages.ChooseDificulty);
                    do
                    {
                        option[1] = Convert.ToInt32(Console.ReadLine());
                        tries++;
                        if (!Utils.InRangValidation(option[1], Values.Op1, Values.Op4) && tries < Values.Attemps)
                            Console.WriteLine(Messages.MsgErrorOption);
                    } while (!Utils.InRangValidation(option[1], Values.Op1, Values.Op4) && tries < Values.Attemps);

                    Console.Clear();
                    Console.WriteLine(Messages.NamesMsg);
                    do
                    {
                        names = Console.ReadLine();
                        separatedNames = names.Split(',');
                        if (Utils.ValidNames(separatedNames)) Console.WriteLine(Messages.NamesError);
                    } while (Utils.ValidNames(separatedNames));
                    Console.WriteLine(Messages.Begin);

                    Console.Clear();
                    Console.WriteLine(Messages.SkipTutorial);
                    skip = Console.ReadLine();
                    switch (skip)
                    {
                        case "y":
                        case "Y":
                            {
                                Console.Clear();
                                Console.WriteLine(Messages.Tutorial, separatedNames[0], separatedNames[1].Trim(), separatedNames[2].Trim(), separatedNames[3].Trim());
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        default:
                            Console.Clear();
                            break;
                    }

                    switch (option[1])
                    {
                        case 1:
                            int[] turns = new int[separatedNames.Length];
                            int[,] stats = { { Values.Archer, Values.ArcherHealthMax, Values.ArcherAttackMax, Values.ArcherShieldMax, Values.Cooldown }, 
                                             { Values.Barbarian, Values.BarbarianHealthMax, Values.BarbarianAttackMax, Values.BarbarianShieldMax, Values.Cooldown }, 
                                             { Values.Magician, Values.MagicianHealthMax, Values.MagicianAttackMax, Values.MagicianShieldMax, Values.Cooldown }, 
                                             { Values.Druid, Values.DruidHealthMax, Values.DruidAttackMax, Values.MagicianShieldMax, Values.Cooldown } };
                            int[] monsterStats = { Values.MonsterHealthMin, Values.MonsterAttackMin, Values.MonsterShieldMin, Values.KnockOut };
                            do
                            {
                                Utils.PrintRound(separatedNames, stats, monsterStats);
                                Utils.TurnsOrder(turns);

                                int action;
                                for (int i = 0; i < turns.Length; i++)
                                {
                                    if (stats[turns[i], Values.Health] > 0 && monsterStats[0] > 0)
                                    {
                                        Console.WriteLine(Messages.Action, names[turns[i]]);
                                        tries = 0;
                                        do
                                        {
                                            action = Convert.ToInt32(Console.ReadLine());
                                            tries++;
                                            if (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps) Console.WriteLine(Messages.MsgErrorOption);
                                            while (Utils.InRangValidation(stats[turns[i], Values.Hability]) && action == Values.Op3 && tries < Values.Attemps)
                                            {
                                                Console.WriteLine(Messages.HabilityUn, stats[turns[i], Values.Hability]);
                                                tries++;
                                                action = Convert.ToInt32(Console.ReadLine());
                                            }
                                        } while (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps);

                                        switch (action)
                                        {
                                            case 1:
                                                monsterStats[0] -= Utils.Attack(stats, monsterStats, turns[i]);
                                                Console.WriteLine(Messages.MonsterDamage, names[turns[i]], Utils.Attack(stats, monsterStats, turns[i]));
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                stats[turns[i], Values.Shield] = Utils.ShieldImprovement(stats, turns[i]);
                                                Console.WriteLine(Messages.ShieldImprove, names[turns[i]], stats[turns[i], Values.Shield]);
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                if (Utils.InRangValidation(stats[turns[i], Values.Hability]))
                                                {
                                                    switch (stats[turns[i], 0])
                                                    {
                                                        case Values.Archer:
                                                            stats[turns[i], Values.Hability]--;
                                                            break;
                                                        case Values.Barbarian:
                                                            stats[turns[i], Values.Shield] = Values.MegaShield;
                                                            stats[turns[i], Values.Hability]--;
                                                            break;
                                                        case Values.Magician:
                                                            monsterStats[0] -= Values.Attemps * Utils.Attack(stats, monsterStats, turns[i]);
                                                            break;
                                                        case Values.Druid:
                                                            for (int j = 0; j < stats.GetLength(0); i++)
                                                            {
                                                                switch (stats[j, 0])
                                                                {
                                                                    case 0:
                                                                        Utils.Heal(stats[j, Values.Health], Values.ArcherHealthMax);
                                                                        break;
                                                                    case 1:
                                                                        Utils.Heal(stats[j, Values.Health], Values.BarbarianHealthMax);
                                                                        break;
                                                                    case 2:
                                                                        Utils.Heal(stats[j, Values.Health], Values.MagicianHealthMax);
                                                                        break;
                                                                    case 3:
                                                                        Utils.Heal(stats[j, Values.Health], Values.DruidHealthMax);
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                    }
                                                    Console.WriteLine(Messages.UseHability, names[turns[i]]);
                                                }
                                                else Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                            default:
                                                Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                        }
                                    }
                                }

                                Utils.HabilitiesBalance(stats);
                                Utils.KnockOut(monsterStats);
                            } while ((stats[Values.Archer, Values.Health] > 0 || 
                                      stats[Values.Barbarian, Values.Health] > 0 || 
                                      stats[Values.Magician, Values.Health] > 0 || 
                                      stats[Values.Druid, Values.Health] > 0) && monsterStats[0] > 0);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                }
            } while (option[0] == Values.Op1 && Utils.InRangValidation(option[1], Values.Op1, Values.Op4));
            if (option[0] == Values.Op0) Console.WriteLine(Messages.Bye);
            else
            {
                Console.Clear();
                Console.WriteLine(Messages.MsgErrorMenu);
            }
        }
    }
}

