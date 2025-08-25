namespace Task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Твой день рождения\n");
            Console.Write($"Введите год: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите месяц: ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите день: ");
            int day = Convert.ToInt32(Console.ReadLine());

            DateTime date = DateTime.Now;
            DateTime birthday = new DateTime(year, month, day);
            
            var ageYear = date.Year - birthday.Year;
            var ageMonth = date.Month - birthday.Month;
            var ageDay = date.Day - birthday.Day;

            if (ageDay < 0)
            {
                int prevMonth = (date.Month == 1) ? 12 : date.Month - 1;
                int prevYear = (date.Month == 1) ? date.Year - 1 : date.Year;

                ageDay += DateTime.DaysInMonth(prevYear, prevMonth);
                ageMonth--;
            }

            if (ageMonth < 0)
            {
                ageMonth += 12;
                ageYear--;
            }

            Console.WriteLine($"\nТвой возраст:\n{ageYear} лет, {ageMonth} месяцев, {ageDay} дней");
        }
    }
}
