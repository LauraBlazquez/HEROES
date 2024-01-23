namespace UtilsLibrary
{
    public class Utils
    {
        public static bool InRangValidation(int option, int begin, int end)
        {
            return option >= begin && option <= end;
        }
        public static bool ValidNames(string[] names)
        {
            int length = 4;
            return names.Length < length || names.Length > length;
        }
    }
}