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
            int i;

            do
            {
                i = 0;
                Console.Clear();
                Console.WriteLine(Consts.Welcome);
                Console.WriteLine(Consts.Menu);
                do
                {
                    option[0] = Convert.ToInt32(Console.ReadLine());
                    i++;
                    if (!Utils.InRangValidation(option[0], Op0, Op1) && i < Attemps)
                        Console.WriteLine(Consts.MsgErrorOption);
                } while (!Utils.InRangValidation(option[0], Op0, Op1) && i < Attemps);
                i = 0;
                if (option[0] == Op1)
                {
                    Console.Clear();
                    Console.WriteLine(Consts.ChooseDificulty);
                    do
                    {
                        option[1] = Convert.ToInt32(Console.ReadLine());
                        i++;
                        if (!Utils.InRangValidation(option[1], Op1, Op4) && i < Attemps)
                            Console.WriteLine(Consts.MsgErrorOption);
                    } while (!Utils.InRangValidation(option[1], Op1, Op4) && i < Attemps);
                    switch (option[1])
                    {
                        case 1:
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