namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime();

            Console.Write($"Введите год: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите месяц: ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите день: ");
            int day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите на сколько дней увеличить дату: ");
            int IncreaseTheDays = Convert.ToInt32(Console.ReadLine());

            date = new DateTime(year, month, day);
            Console.WriteLine(date.AddDays(IncreaseTheDays));
        }
    }
}
