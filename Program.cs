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
                            int[,] stats = { { 2000, 300, 35, 5 }, { 3750, 250, 45, 5 }, { 1500, 400, 35, 5 }, { 2500, 120, 40, 5 } };
                            int[] monsterStats = { 7000, 300, 20 };
                            int[] maxHealths = { stats [0, 0], stats [1, 0], stats [2, 0], stats [3, 0] };
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

