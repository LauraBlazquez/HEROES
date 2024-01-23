using Constants;
namespace UtilsLibrary
{
    public class Utils
    {
        public static bool InRangValidation(int option, int begin, int end)
        {
            return option >= begin && option <= end;
        }

        public static bool InRangValidation(int hability)
        {
            return hability == Values.Cooldown;
        }

        public static bool ValidNames(string[] names)
        {
            return names.Length < Values.NecessaryLength || names.Length > Values.NecessaryLength;
        }

        //public static void OrderPrintByHealth(int[,] stats)
        //{
        //    for (int i = 0; i < stats.GetLength(0) - 1; i++)
        //    {
        //        for (int j = i + 1; j < stats.GetLength(0); j++)
        //        {
        //            if (stats[i, 1] < stats[j, 1])
        //            {
        //                for (int k = 0; k < stats.GetLength(1); k++)
        //                {
        //                    int aux = stats[i, k];
        //                    stats[i, k] = stats[j, k];
        //                    stats[j, k] = aux;
        //                }
        //            }
        //        }
        //    }
        //}

        public static void PrintRound(string[] names, int[,] stats, int[] monsterStats)
        {
            //OrderPrintByHealth(stats);
            for (int i = 0; i < stats.GetLength(0); i++)
            {
                if (stats[i, Values.Health] > 0)
                {
                    switch (stats[i,0])
                    {
                        case Values.Archer:
                            Console.WriteLine(Messages.Archer, names[Values.Archer], stats[i, Values.Health], stats[i, Values.Attack], stats[i, Values.Shield]);
                            break;
                        case Values.Barbarian:
                            Console.WriteLine(Messages.Barbarian, names[Values.Barbarian], stats[i, Values.Health], stats[i, Values.Attack], stats[i, Values.Shield]);
                            break;
                        case Values.Magician:
                            Console.WriteLine(Messages.Magician, names[Values.Magician], stats[i, Values.Health], stats[i, Values.Attack], stats[i, Values.Shield]);
                            break;
                        case Values.Druid:
                            Console.WriteLine(Messages.Druid, names[Values.Druid], stats[i, Values.Health], stats[i, Values.Attack], stats[i, Values.Shield]);
                            break;
                    }
                }
                else
                    Console.WriteLine(Messages.DeadWarrior);
            }
            if (monsterStats[0] > 0)
            {
                Console.WriteLine(Messages.Monster);
                Console.WriteLine(Messages.MonsterStats, monsterStats[0], monsterStats[1], monsterStats[2]);
            }
            else if (monsterStats[3] > Values.Cooldown - Values.KnockOut)
                Console.WriteLine(Messages.SleepyMonster);
            else
                Console.WriteLine(Messages.DeadMonster);
        }

        public static void TurnsOrder(int[] turns)
        {
            for (int i = 0; i < turns.Length; i++)
            {
                turns[i] = Random(turns.Length);
                int j = 0;

                while (j < i)
                {
                    if (turns[i] == turns[j])
                    {
                        turns[i] = Random(turns.Length);
                        j = 0;
                    }
                    else j++;
                }
            }
        }

        public static int Random(int max)
        {
            var random = new Random();
            return random.Next(max);
        }

        public static int Attack(int[,] stats, int[] monsterStats, int character)
        {
            int result;
            if (Random(Values.Critical) == Values.Critical)
            {
                result = Values.Double * (stats[character, Values.Attack] - (stats[character, Values.Attack] * monsterStats[2] / Values.Percent));
                Console.WriteLine(Messages.Critical,result);
                return result;
            }
            if (Random(Values.Percent) == Values.AttackFail)
            {
                Console.WriteLine(Messages.AttackFailed);
                return 0;
            }
            return stats[character, Values.Attack] - (stats[character, Values.Attack] * monsterStats[2] / Values.Percent);

        }

        public static int Attack(int[,] stats, int monsterAttack, int i)
        {
            return monsterAttack - (monsterAttack * stats[i,Values.Shield] / Values.Percent);
        }

        public static int ShieldImprovement(int[,] stats, int character)
        {
            return stats[character, Values.Shield] *= Values.Double;
        }
        
        public static int Heal(int health, int healthMax)
        {
            if (health + Values.Enchant > healthMax)
                return healthMax;
            if (health > 0)
                return health += Values.Enchant;  
            return 0;
        }

        public static int HabilitiesBalance(int stat, int max)
        {
            if (stat != max && stat != 0)
                return stat-1;
            if (stat == 0)
                return Values.Cooldown;
            else
                return stat;
        }

    }
}