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
                            int[] easyTurns = new int[separatedNames.Length];
                            int[,] easyStats = { { Values.Archer, Values.ArcherHealthMax, Values.ArcherAttackMax, Values.ArcherShieldMax, Values.Cooldown }, 
                                                 { Values.Barbarian, Values.BarbarianHealthMax, Values.BarbarianAttackMax, Values.BarbarianShieldMax, Values.Cooldown }, 
                                                 { Values.Magician, Values.MagicianHealthMax, Values.MagicianAttackMax, Values.MagicianShieldMax, Values.Cooldown }, 
                                                 { Values.Druid, Values.DruidHealthMax, Values.DruidAttackMax, Values.DruidShieldMax, Values.Cooldown } };
                            int[] easyMonsterStats = { Values.MonsterHealthMin, Values.MonsterAttackMin, Values.MonsterShieldMin, Values.KnockOut };
                            do
                            {
                                Utils.PrintRound(separatedNames, easyStats, easyMonsterStats);
                                Utils.TurnsOrder(easyTurns);

                                int action;
                                for (int i = 0; i < easyTurns.Length; i++)
                                {
                                    if (easyStats[easyTurns[i], Values.Health] > 0 && easyMonsterStats[0] > 0)
                                    {
                                        Console.WriteLine(Messages.Action, separatedNames[easyTurns[i]]);
                                        tries = 0;
                                        do
                                        {
                                            action = Convert.ToInt32(Console.ReadLine());
                                            tries++;
                                            if (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps) Console.WriteLine(Messages.MsgErrorOption);
                                            while (!Utils.InRangValidation(easyStats[easyTurns[i], Values.Hability]) && action == Values.Op3 && tries < Values.Attemps)
                                            {
                                                Console.WriteLine(Messages.HabilityUn, easyStats[easyTurns[i], Values.Hability]);
                                                tries++;
                                                action = Convert.ToInt32(Console.ReadLine());
                                            }
                                        } while (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps);

                                        switch (action)
                                        {
                                            case 1:
                                                easyMonsterStats[0] -= Utils.Attack(easyStats, easyMonsterStats, easyTurns[i]);
                                                Console.WriteLine(Messages.MonsterDamage, separatedNames[easyTurns[i]], Utils.Attack(easyStats, easyMonsterStats, easyTurns[i]));
                                                break;
                                            case 2:
                                                easyStats[easyTurns[i], Values.Shield] = Utils.ShieldImprovement(easyStats, easyTurns[i]);
                                                Console.WriteLine(Messages.ShieldImprove, separatedNames[easyTurns[i]], easyStats[easyTurns[i], Values.Shield]);
                                                break;
                                            case 3:
                                                if (Utils.InRangValidation(easyStats[easyTurns[i], Values.Hability]))
                                                {
                                                    switch (easyStats[easyTurns[i], 0])
                                                    {
                                                        case Values.Archer:
                                                            easyStats[easyTurns[i], Values.Hability]--;
                                                            break;
                                                        case Values.Barbarian:
                                                            if (easyStats[easyTurns[i], Values.Shield] != Values.MegaShield)
                                                            {
                                                                easyStats[easyTurns[i], Values.Shield] = Values.MegaShield;
                                                                easyStats[easyTurns[i], Values.Hability]--;
                                                            }
                                                            break;
                                                        case Values.Magician:
                                                            easyMonsterStats[0] -= Values.Attemps * Utils.Attack(easyStats, easyMonsterStats, easyTurns[i]);
                                                            break;
                                                        case Values.Druid:
                                                            for (int j = 0; j < easyStats.GetLength(0); j++)
                                                            {
                                                                switch (easyStats[j, 0])
                                                                {
                                                                    case 0:
                                                                        easyStats[j, Values.Health] = Utils.Heal(easyStats[j, Values.Health], Values.ArcherHealthMax);
                                                                        break;
                                                                    case 1:
                                                                        easyStats[j, Values.Health] = Utils.Heal(easyStats[j, Values.Health], Values.BarbarianHealthMax);
                                                                        break;
                                                                    case 2:
                                                                        easyStats[j, Values.Health] = Utils.Heal(easyStats[j, Values.Health], Values.MagicianHealthMax);
                                                                        break;
                                                                    case 3:
                                                                        easyStats[j, Values.Health] = Utils.Heal(easyStats[j, Values.Health], Values.DruidHealthMax);
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                    }
                                                    Console.WriteLine(Messages.UseHability, separatedNames[easyTurns[i]]);
                                                }
                                                else Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                            default:
                                                Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                        Utils.PrintRound(separatedNames, easyStats, easyMonsterStats);
                                    }
                                }

                                if (easyStats[Values.Archer,Values.Hability] > Values.Cooldown-Values.KnockOut)
                                {
                                    for (int i = 0; i < easyStats.GetLength(0); i++)
                                    {
                                        easyStats[i, Values.Health] -= Utils.Attack(easyStats, easyMonsterStats[1], i);
                                        Console.WriteLine(Messages.MonsterAction, separatedNames[easyStats[i, 0]], Utils.Attack(easyStats, easyMonsterStats[1], i));
                                    }
                                }
                                else
                                    Console.WriteLine(Messages.SleepyMonster);
                                Console.ReadKey();
                                Console.Clear();

                                for (int i = 0; i < easyStats.GetLength(0); i++)
                                {
                                    Utils.HabilitiesBalance(easyStats[i,Values.Hability],Values.Cooldown);
                                }
                                easyMonsterStats[3] = Utils.HabilitiesBalance(easyMonsterStats[3],Values.KnockOut);
                            } while ((easyStats[Values.Archer, Values.Health] > 0 ||
                                      easyStats[Values.Barbarian, Values.Health] > 0 ||
                                      easyStats[Values.Magician, Values.Health] > 0 ||
                                      easyStats[Values.Druid, Values.Health] > 0) && easyMonsterStats[0] > 0);
                            if (easyMonsterStats[0] <= 0)
                                    Console.WriteLine(Messages.Win);
                            else
                                Console.WriteLine(Messages.Defeat);
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

