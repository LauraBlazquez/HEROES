using UtilsLibrary;
using Messages;

namespace GameProject
{
    public class BlazquezLauraCode
    {
        public static void Main()
        {
            const int Attemps = 3, Op0 = 0, Op1 = 1, Op4 = 4;
            int[] option = new int[2];
            int tries;
            string names, skip;
            string[] separatedNames = new string[4];
            do
            {
                tries = 0;
                Console.Clear();
                Console.WriteLine(Consts.Welcome);
                Console.WriteLine(Consts.Menu);
                do
                {
                    option[0] = Convert.ToInt32(Console.ReadLine());
                    tries++;
                    if (!Utils.InRangValidation(option[0], Op0, Op1) && tries < Attemps)
                        Console.WriteLine(Consts.MsgErrorOption);
                } while (!Utils.InRangValidation(option[0], Op0, Op1) && tries < Attemps);

                tries = 0;
                if (option[0] == Op1)
                {
                    Console.Clear();
                    Console.WriteLine(Consts.ChooseDificulty);
                    do
                    {
                        option[1] = Convert.ToInt32(Console.ReadLine());
                        tries++;
                        if (!Utils.InRangValidation(option[1], Op1, Op4) && tries < Attemps)
                            Console.WriteLine(Consts.MsgErrorOption);
                    } while (!Utils.InRangValidation(option[1], Op1, Op4) && tries < Attemps);

                    Console.Clear();
                    Console.WriteLine(Consts.NamesMsg);
                    do
                    {
                        names = Console.ReadLine();
                        separatedNames = names.Split(',');
                        if (Utils.ValidNames(separatedNames)) Console.WriteLine(Consts.NamesError);
                    } while (Utils.ValidNames(separatedNames));
                    Console.WriteLine(Consts.Begin);

                    Console.Clear();
                    Console.WriteLine(Consts.SkipTutorial);
                    skip = Console.ReadLine();
                    switch (skip)
                    {
                        case "y":
                        case "Y":
                            {
                                Console.Clear();
                                Console.WriteLine(Consts.Tutorial, separatedNames[0], separatedNames[1].Trim(), separatedNames[2].Trim(), separatedNames[3].Trim());
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
                            int[,] stats = { { 2000, 300, 35, 5 }, { 3750, 250, 45, 5 }, { 1500, 400, 35, 5 }, { 2500, 120, 40, 5 } };
                            int[] monsterStats = { 7000, 300, 20 };
                            int archerHealth = stats[0, 0], barbarianHealth = stats[1, 0], magicianHealth = stats[2, 0], druidHealth = stats[3, 0];
                            int barbarianShield = stats[1, 2];
                            do
                            {
                                Utils.PrintRound(separatedNames, stats, monsterStats);
                                Utils.TurnsOrder(ref turns);

                                for (int i = 0; i < turns.Length; i++)
                                {
                                    Console.WriteLine(turns[i]);
                                }

                                //Utils.Round(turns, ref stats, separatedNames);
                            } while ((stats[0, 0] > 0 || stats[1, 0] > 0 || stats[2, 0] > 0 || stats[3, 0] > 0) && monsterStats[0] > 0);

                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                }
            } while (option[0] == Op1 && Utils.InRangValidation(option[1], Op1, Op4));
            if (option[0] == Op0) Console.WriteLine(Consts.Bye);
            else
            {
                Console.Clear();
                Console.WriteLine(Consts.MsgErrorMenu);
            }
        }
    }
}

