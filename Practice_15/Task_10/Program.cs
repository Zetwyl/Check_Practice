namespace Task_10
{
    internal class Program
    {
        static bool StringToBoolean(string str)
        {
            if (str == "1") return true;
            if (str == "0") return false;

            return Convert.ToBoolean(str);
        }

        static void Main(string[] args)
        {
            string StrTrue = "True";
            string StrFalse = "False";
            string StrOne = "1";
            string StrZero = "0";

            bool BoolTrue = StringToBoolean(StrTrue);
            bool BoolFalse = StringToBoolean(StrFalse);
            bool BoolOne = StringToBoolean(StrOne);
            bool BoolZero = StringToBoolean(StrZero);

            Console.WriteLine(BoolTrue);
            Console.WriteLine(BoolFalse);
            Console.WriteLine(BoolOne);
            Console.WriteLine(BoolZero);
        }
    }
}
