namespace UtilsLibrary
{
    public class Utils
    {
        public static bool InRangValidation(int option, int begin, int end)
        {
            return option >= begin && option <= end;
        }

    }
}