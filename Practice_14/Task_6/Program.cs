namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            var year = dateTime.Year + 1;
            DateTime newYear = new DateTime(year, 1, 1);
            var difference = newYear - dateTime;

            Console.WriteLine($"{difference.Days} дней осталось до следующего Нового года от текущей даты.");
        }
    }
}
