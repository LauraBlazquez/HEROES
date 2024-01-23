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
                                if (easyStats[Values.Archer, Values.Hability] > Values.Cooldown - Values.KnockOut)
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
                                    Utils.HabilitiesBalance(easyStats[i, Values.Hability], Values.Cooldown);
                                }
                                easyMonsterStats[3] = Utils.HabilitiesBalance(easyMonsterStats[3], Values.KnockOut);
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
                            int[] hardTurns = new int[separatedNames.Length];
                            int[,] hardStats = { { Values.Archer, Values.ArcherHealthMin, Values.ArcherAttackMin, Values.ArcherShieldMin, Values.Cooldown },
                     { Values.Barbarian, Values.BarbarianHealthMin, Values.BarbarianAttackMin, Values.BarbarianShieldMin, Values.Cooldown },
                     { Values.Magician, Values.MagicianHealthMin, Values.MagicianAttackMin, Values.MagicianShieldMin, Values.Cooldown },
                     { Values.Druid, Values.DruidHealthMin, Values.DruidAttackMin, Values.DruidShieldMin, Values.Cooldown } };
                            int[] hardMonsterStats = { Values.MonsterHealthMax, Values.MonsterAttackMax, Values.MonsterShieldMax, Values.KnockOut };
                            do
                            {
                                Utils.PrintRound(separatedNames, hardStats, hardMonsterStats);
                                Utils.TurnsOrder(hardTurns);

                                int action;
                                for (int i = 0; i < hardTurns.Length; i++)
                                {
                                    if (hardStats[hardTurns[i], Values.Health] > 0 && hardMonsterStats[0] > 0)
                                    {
                                        Console.WriteLine(Messages.Action, separatedNames[hardTurns[i]]);
                                        tries = 0;
                                        do
                                        {
                                            action = Convert.ToInt32(Console.ReadLine());
                                            tries++;
                                            if (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps) Console.WriteLine(Messages.MsgErrorOption);
                                            while (!Utils.InRangValidation(hardStats[hardTurns[i], Values.Hability]) && action == Values.Op3 && tries < Values.Attemps)
                                            {
                                                Console.WriteLine(Messages.HabilityUn, hardStats[hardTurns[i], Values.Hability]);
                                                tries++;
                                                action = Convert.ToInt32(Console.ReadLine());
                                            }
                                        } while (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps);

                                        switch (action)
                                        {
                                            case 1:
                                                hardMonsterStats[0] -= Utils.Attack(hardStats, hardMonsterStats, hardTurns[i]);
                                                Console.WriteLine(Messages.MonsterDamage, separatedNames[hardTurns[i]], Utils.Attack(hardStats, hardMonsterStats, hardTurns[i]));
                                                break;
                                            case 2:
                                                hardStats[hardTurns[i], Values.Shield] = Utils.ShieldImprovement(hardStats, hardTurns[i]);
                                                Console.WriteLine(Messages.ShieldImprove, separatedNames[hardTurns[i]], hardStats[hardTurns[i], Values.Shield]);
                                                break;
                                            case 3:
                                                if (Utils.InRangValidation(hardStats[hardTurns[i], Values.Hability]))
                                                {
                                                    switch (hardStats[hardTurns[i], 0])
                                                    {
                                                        case Values.Archer:
                                                            hardStats[hardTurns[i], Values.Hability]--;
                                                            break;
                                                        case Values.Barbarian:
                                                            if (hardStats[hardTurns[i], Values.Shield] != Values.MegaShield)
                                                            {
                                                                hardStats[hardTurns[i], Values.Shield] = Values.MegaShield;
                                                                hardStats[hardTurns[i], Values.Hability]--;
                                                            }
                                                            break;
                                                        case Values.Magician:
                                                            hardMonsterStats[0] -= Values.Attemps * Utils.Attack(hardStats, hardMonsterStats, hardTurns[i]);
                                                            break;
                                                        case Values.Druid:
                                                            for (int j = 0; j < hardStats.GetLength(0); j++)
                                                            {
                                                                switch (hardStats[j, 0])
                                                                {
                                                                    case 0:
                                                                        hardStats[j, Values.Health] = Utils.Heal(hardStats[j, Values.Health], Values.ArcherHealthMin);
                                                                        break;
                                                                    case 1:
                                                                        hardStats[j, Values.Health] = Utils.Heal(hardStats[j, Values.Health], Values.BarbarianHealthMin);
                                                                        break;
                                                                    case 2:
                                                                        hardStats[j, Values.Health] = Utils.Heal(hardStats[j, Values.Health], Values.MagicianHealthMin);
                                                                        break;
                                                                    case 3:
                                                                        hardStats[j, Values.Health] = Utils.Heal(hardStats[j, Values.Health], Values.DruidHealthMin);
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                    }
                                                    Console.WriteLine(Messages.UseHability, separatedNames[hardTurns[i]]);
                                                }
                                                else Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                            default:
                                                Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                        Utils.PrintRound(separatedNames, hardStats, hardMonsterStats);
                                    }
                                }
                                if (hardStats[Values.Archer, Values.Hability] > Values.Cooldown - Values.KnockOut)
                                {
                                    for (int i = 0; i < hardStats.GetLength(0); i++)
                                    {
                                        hardStats[i, Values.Health] -= Utils.Attack(hardStats, hardMonsterStats[1], i);
                                        Console.WriteLine(Messages.MonsterAction, separatedNames[hardStats[i, 0]], Utils.Attack(hardStats, hardMonsterStats[1], i));
                                    }
                                }
                                else
                                    Console.WriteLine(Messages.SleepyMonster);
                                Console.ReadKey();
                                Console.Clear();


                                for (int i = 0; i < hardStats.GetLength(0); i++)
                                {
                                    Utils.HabilitiesBalance(hardStats[i, Values.Hability], Values.Cooldown);
                                }
                                hardMonsterStats[3] = Utils.HabilitiesBalance(hardMonsterStats[3], Values.KnockOut);
                            } while ((hardStats[Values.Archer, Values.Health] > 0 ||
                                      hardStats[Values.Barbarian, Values.Health] > 0 ||
                                      hardStats[Values.Magician, Values.Health] > 0 ||
                                      hardStats[Values.Druid, Values.Health] > 0) && hardMonsterStats[0] > 0);
                            if (hardMonsterStats[0] <= 0)
                                Console.WriteLine(Messages.Win);
                            else
                                Console.WriteLine(Messages.Defeat);
                            break;
                        case 3:
                            int[] userTurns = new int[separatedNames.Length];
                            int[,] userStats = { { Values.Archer, 0, 0, 0, Values.Cooldown },
                     { Values.Barbarian, 0, 0, 0, Values.Cooldown },
                     { Values.Magician, 0, 0, 0, Values.Cooldown },
                     { Values.Druid, 0, 0, 0, Values.Cooldown } };
                            int[] userMonsterStats = { 0, 0, 0, Values.KnockOut };
                            //for (int i = 0; i < separatedNames.Length; i++)
                            //{
                            //    for (int j = 1; j < separatedNames.Length; j++)
                            //    {
                            //        do
                            //        {
                            //            userStats[i, j] = Convert.ToInt32(Console.ReadLine());
                            //            tries++;
                            //            if (!Utils.InRangValidation(userStats[i, j], Values.Op1, Values.Op4) && tries < Values.Attemps)
                            //                Console.WriteLine(Messages.MsgErrorOption);
                            //        } while (!Utils.InRangValidation(option[1], Values.Op1, Values.Op4) && tries < Values.Attemps);
                            //    }
                            //} Tendria que hacer la comprobación con los valores límite, pero teniendo la matriz de variables tengo que ir una por una, no encuntra la forma de refactorizar.
                            do
                            {
                                Utils.PrintRound(separatedNames, userStats, userMonsterStats);
                                Utils.TurnsOrder(userTurns);

                                int action;
                                for (int i = 0; i < userTurns.Length; i++)
                                {
                                    if (userStats[userTurns[i], Values.Health] > 0 && userMonsterStats[0] > 0)
                                    {
                                        Console.WriteLine(Messages.Action, separatedNames[userTurns[i]]);
                                        tries = 0;
                                        do
                                        {
                                            action = Convert.ToInt32(Console.ReadLine());
                                            tries++;
                                            if (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps) Console.WriteLine(Messages.MsgErrorOption);
                                            while (Utils.InRangValidation(userStats[userTurns[i], Values.Hability]) && action == Values.Op3 && tries < Values.Attemps)
                                            {
                                                Console.WriteLine(Messages.HabilityUn, userStats[userTurns[i], Values.Hability]);
                                                tries++;
                                                action = Convert.ToInt32(Console.ReadLine());
                                            }
                                        } while (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps);

                                        switch (action)
                                        {
                                            case 1:
                                                userMonsterStats[0] -= Utils.Attack(userStats, userMonsterStats, userTurns[i]);
                                                Console.WriteLine(Messages.MonsterDamage, separatedNames[userTurns[i]], Utils.Attack(userStats, userMonsterStats, userTurns[i]));
                                                break;
                                            case 2:
                                                userStats[userTurns[i], Values.Shield] = Utils.ShieldImprovement(userStats, userTurns[i]);
                                                Console.WriteLine(Messages.ShieldImprove, separatedNames[userTurns[i]], userStats[userTurns[i], Values.Shield]);
                                                break;
                                            case 3:
                                                if (Utils.InRangValidation(userStats[userTurns[i], Values.Hability]))
                                                {
                                                    switch (userStats[userTurns[i], 0])
                                                    {
                                                        case Values.Archer:
                                                            userStats[userTurns[i], Values.Hability]--;
                                                            break;
                                                        case Values.Barbarian:
                                                            if (userStats[userTurns[i], Values.Shield] != Values.MegaShield)
                                                            {
                                                                userStats[userTurns[i], Values.Shield] = Values.MegaShield;
                                                                userStats[userTurns[i], Values.Hability]--;
                                                            }
                                                            break;
                                                        case Values.Magician:
                                                            userMonsterStats[0] -= Values.Attemps * Utils.Attack(userStats, userMonsterStats, userTurns[i]);
                                                            break;
                                                        case Values.Druid:
                                                            for (int j = 0; j < userStats.GetLength(0); i++)
                                                            {
                                                                switch (userStats[j, 0])
                                                                {
                                                                    case 0:
                                                                        userStats[j, Values.Health] = Utils.Heal(userStats[j, Values.Health], Values.ArcherHealthMax);
                                                                        break;
                                                                    case 1:
                                                                        userStats[j, Values.Health] = Utils.Heal(userStats[j, Values.Health], Values.BarbarianHealthMax);
                                                                        break;
                                                                    case 2:
                                                                        userStats[j, Values.Health] = Utils.Heal(userStats[j, Values.Health], Values.MagicianHealthMax);
                                                                        break;
                                                                    case 3:
                                                                        userStats[j, Values.Health] = Utils.Heal(userStats[j, Values.Health], Values.DruidHealthMax);
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                    }
                                                    Console.WriteLine(Messages.UseHability, separatedNames[userTurns[i]]);
                                                }
                                                else Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                            default:
                                                Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                        Utils.PrintRound(separatedNames, userStats, userMonsterStats);
                                    }
                                }

                                for (int i = 0; i < userStats.GetLength(0); i++)
                                {

                                    userStats[i, Values.Health] -= Utils.Attack(userStats, userMonsterStats[3], i);
                                    Console.WriteLine(Messages.MonsterAction, separatedNames[userStats[i, 0]], userStats[i, Values.Health]);
                                }


                                for (int i = 0; i < userStats.GetLength(0); i++)
                                {
                                    Utils.HabilitiesBalance(userStats[i, Values.Hability], Values.Cooldown);
                                }
                                userMonsterStats[3] = Utils.HabilitiesBalance(userMonsterStats[3], Values.KnockOut);
                            } while ((userStats[Values.Archer, Values.Health] > 0 ||
                                      userStats[Values.Barbarian, Values.Health] > 0 ||
                                      userStats[Values.Magician, Values.Health] > 0 ||
                                      userStats[Values.Druid, Values.Health] > 0) && userMonsterStats[0] > 0);
                            if (userMonsterStats[0] <= 0)
                                Console.WriteLine(Messages.Win);
                            else
                                Console.WriteLine(Messages.Defeat);
                            break;
                        case 4:
                            int[] randomTurns = new int[separatedNames.Length];
                            int[,] randomStats = { { Values.Archer, 0, 0, 0, Values.Cooldown },
                       { Values.Barbarian, 0, 0, 0, Values.Cooldown },
                       { Values.Magician, 0, 0, 0, Values.Cooldown },
                       { Values.Druid, 0, 0, 0, Values.Cooldown } };
                            int[] randomMonsterStats = { 0, 0, 0, Values.KnockOut };
                            //for (int i = 0; i < separatedNames.Length; i++)
                            //{
                            //    for (int j = 1; j < separatedNames.Length; j++)
                            //    {
                            //        do
                            //        {
                            //            userStats[i, j] = Convert.ToInt32(Console.ReadLine());
                            //            tries++;
                            //            if (!Utils.InRangValidation(userStats[i, j], Values.Op1, Values.Op4) && tries < Values.Attemps)
                            //                Console.WriteLine(Messages.MsgErrorOption);
                            //        } while (!Utils.InRangValidation(option[1], Values.Op1, Values.Op4) && tries < Values.Attemps);
                            //    }
                            //} Tendria que hacer la comprobación con los valores límite, pero teniendo la matriz de variables tengo que ir una por una, no encuntra la forma de refactorizar.
                            do
                            {
                                Utils.PrintRound(separatedNames, randomStats, randomMonsterStats);
                                Utils.TurnsOrder(randomTurns);

                                int action;
                                for (int i = 0; i < randomTurns.Length; i++)
                                {
                                    if (randomStats[randomTurns[i], Values.Health] > 0 && randomMonsterStats[0] > 0)
                                    {
                                        Console.WriteLine(Messages.Action, separatedNames[randomTurns[i]]);
                                        tries = 0;
                                        do
                                        {
                                            action = Convert.ToInt32(Console.ReadLine());
                                            tries++;
                                            if (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps) Console.WriteLine(Messages.MsgErrorOption);
                                            while (Utils.InRangValidation(randomStats[randomTurns[i], Values.Hability]) && action == Values.Op3 && tries < Values.Attemps)
                                            {
                                                Console.WriteLine(Messages.HabilityUn, randomStats[randomTurns[i], Values.Hability]);
                                                tries++;
                                                action = Convert.ToInt32(Console.ReadLine());
                                            }
                                        } while (!Utils.InRangValidation(action, Values.Op1, Values.Op3) && tries < Values.Attemps);

                                        switch (action)
                                        {
                                            case 1:
                                                randomMonsterStats[0] -= Utils.Attack(randomStats, randomMonsterStats, randomTurns[i]);
                                                Console.WriteLine(Messages.MonsterDamage, separatedNames[randomTurns[i]], Utils.Attack(randomStats, randomMonsterStats, randomTurns[i]));
                                                break;
                                            case 2:
                                                randomStats[randomTurns[i], Values.Shield] = Utils.ShieldImprovement(randomStats, randomTurns[i]);
                                                Console.WriteLine(Messages.ShieldImprove, separatedNames[randomTurns[i]], randomStats[randomTurns[i], Values.Shield]);
                                                break;
                                            case 3:
                                                if (Utils.InRangValidation(randomStats[randomTurns[i], Values.Hability]))
                                                {
                                                    switch (randomStats[randomTurns[i], 0])
                                                    {
                                                        case Values.Archer:
                                                            randomStats[randomTurns[i], Values.Hability]--;
                                                            break;
                                                        case Values.Barbarian:
                                                            if (randomStats[randomTurns[i], Values.Shield] != Values.MegaShield)
                                                            {
                                                                randomStats[randomTurns[i], Values.Shield] = Values.MegaShield;
                                                                randomStats[randomTurns[i], Values.Hability]--;
                                                            }
                                                            break;
                                                        case Values.Magician:
                                                            randomMonsterStats[0] -= Values.Attemps * Utils.Attack(randomStats, randomMonsterStats, randomTurns[i]);
                                                            break;
                                                        case Values.Druid:
                                                            for (int j = 0; j < randomStats.GetLength(0); i++)
                                                            {
                                                                switch (randomStats[j, 0])
                                                                {
                                                                    case 0:
                                                                        randomStats[j, Values.Health] = Utils.Heal(randomStats[j, Values.Health], Values.ArcherHealthMax);
                                                                        break;
                                                                    case 1:
                                                                        randomStats[j, Values.Health] = Utils.Heal(randomStats[j, Values.Health], Values.BarbarianHealthMax);
                                                                        break;
                                                                    case 2:
                                                                        randomStats[j, Values.Health] = Utils.Heal(randomStats[j, Values.Health], Values.MagicianHealthMax);
                                                                        break;
                                                                    case 3:
                                                                        randomStats[j, Values.Health] = Utils.Heal(randomStats[j, Values.Health], Values.DruidHealthMax);
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                    }
                                                    Console.WriteLine(Messages.UseHability, separatedNames[randomTurns[i]]);
                                                }
                                                else Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                            default:
                                                Console.WriteLine(Messages.ErrorBattleOption);
                                                break;
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                        Utils.PrintRound(separatedNames, randomStats, randomMonsterStats);
                                    }
                                }

                                for (int i = 0; i < randomStats.GetLength(0); i++)
                                {

                                    randomStats[i, Values.Health] -= Utils.Attack(randomStats, randomMonsterStats[3], i);
                                    Console.WriteLine(Messages.MonsterAction, separatedNames[randomStats[i, 0]], randomStats[i, Values.Health]);
                                }


                                for (int i = 0; i < randomStats.GetLength(0); i++)
                                {
                                    Utils.HabilitiesBalance(randomStats[i, Values.Hability], Values.Cooldown);
                                }
                                randomMonsterStats[3] = Utils.HabilitiesBalance(randomMonsterStats[3], Values.KnockOut);
                            } while ((randomStats[Values.Archer, Values.Health] > 0 ||
                                      randomStats[Values.Barbarian, Values.Health] > 0 ||
                                      randomStats[Values.Magician, Values.Health] > 0 ||
                                      randomStats[Values.Druid, Values.Health] > 0) && randomMonsterStats[0] > 0);
                            if (randomMonsterStats[0] <= 0)
                                Console.WriteLine(Messages.Win);
                            else
                                Console.WriteLine(Messages.Defeat);
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