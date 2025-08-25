namespace Task_4
{
    internal class Program
    {
        static bool LeepYear(int year)
        {
            bool leepYear = DateTime.IsLeapYear(year);

            if (leepYear)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int year = 2020;
            bool isLeap = LeepYear(year);
            Console.WriteLine("Високосный год? - " + isLeap);
        }
    }
}
