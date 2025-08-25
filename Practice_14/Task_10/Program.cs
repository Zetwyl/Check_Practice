namespace Task_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Таймер");
            Console.Write("Введите количество секунд: ");
            int seconds = Convert.ToInt32(Console.ReadLine());

            while (seconds > 0)
            {
                Console.WriteLine(seconds);
                Thread.Sleep(1000);
                seconds--;
            }

            Console.WriteLine("END");
        }
    }
}
