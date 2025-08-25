namespace Task_5
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

            Console.Write("Введите часы: ");
            int hour = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите минуты: ");
            int minute = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите секунды: ");
            int second = Convert.ToInt32(Console.ReadLine());

            date = new DateTime(year, month, day, hour, minute, second);
            Console.WriteLine(date.ToString("dd.MM.yyyy"));
            Console.WriteLine(date.ToString("MM'/'dd'/'yyyy"));
            Console.WriteLine(date.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
