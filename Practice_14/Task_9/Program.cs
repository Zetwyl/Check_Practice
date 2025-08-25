namespace Task_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime utcNow = DateTime.UtcNow;
            Console.WriteLine($"Текущее UTC время: {utcNow}");

            DateTime localFromUtc = utcNow.ToLocalTime();
            Console.WriteLine($"Конвертируем UTC в локальное время: {localFromUtc}");

            DateTime utcFromLocal = localFromUtc.ToUniversalTime();
            Console.WriteLine($"Конвертируем локальное в UTC время: {utcFromLocal}");
        }
    }
}
