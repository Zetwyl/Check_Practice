namespace Task_8
{
    internal class Program
    {
        static bool IsValidDate(int year, int month, int day)
        {
            try
            {
                DateTime dateTime = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите год: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите месяц: ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите день: ");
            int day = Convert.ToInt32(Console.ReadLine());

            if (IsValidDate(year, month, day))
            {
                Console.WriteLine($"{day:D2}.{month:D2}.{year} - валидная");
            }
            else
            {
                Console.WriteLine($"{day:D2}.{month:D2}.{year} - невалидная");
            }
        }
    }
}
