using UtilsLibrary;
using Messages;
namespace GameProject
{
    public class BlazquezLauraCode
    {
        public static void Main()
        {
            const int Attemps = 3, Op0 = 0, Op1 = 1;
            int[] option = new int[2];
            int i = 0;

            do
            {
                Console.WriteLine(Consts.Welcome);
                Console.WriteLine(Consts.Menu);
                do
                {
                    option[0] = Convert.ToInt32(Console.ReadLine());
                    i++;
                    if (!Utils.InRangValidation(option[0], Op0, Op1) && i < Attemps)
                        Console.WriteLine(Consts.MsgErrorOption);
                } while (!Utils.InRangValidation(option[0], Op0, Op1) && i < Attemps);

            } while (option[0] == Op1 && Utils.InRangValidation(option[0], Op0, Op1));
            if (option[0] == Op0) Console.WriteLine(Consts.Bye);
            else
            {
                Console.Clear();
                Console.WriteLine(Consts.MsgErrorMenu);
            }
        }
    }
}