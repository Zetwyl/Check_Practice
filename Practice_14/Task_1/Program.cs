namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime();
            DateTime date2 = new DateTime();

            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine(new string('=', 10));
                Console.Write($"Date {i}\nВведите год: ");
                int year = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите месяц: ");
                int month = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите день: ");
                int day = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите часы: ");
                int hour = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите минуты: ");
                int minute = Convert.ToInt32(Console.ReadLine());

                if (i == 1)
                {
                    date1 = new DateTime(year, month, day, hour, minute, 0);
                }
                else
                {
                    date2 = new DateTime(year, month, day, hour, minute, 0);
                }
            }
            
            var difference = date1.Subtract(date2);
            int days = difference.Days;
            int hours = difference.Hours;
            int minutes = difference.Minutes;

            Console.WriteLine("\nРазница:");
            Console.WriteLine($"{days} дней, {hours} часов, {minutes} минут");

            Console.WriteLine(new string('=', 10));
            Console.WriteLine("data1: " + date1);
            Console.WriteLine("data2: " + date2);
        }
    }
}
