namespace Task_2
{
    internal class Program
    {
        static void RoundNumber(double value)
        {
            double up = Math.Ceiling(value);
            double down = Math.Floor(value);

            Console.WriteLine($"Округл вверх: {up}");
            Console.WriteLine($"Округл вниз: {down}");
        }

        static void Main(string[] args)
        {
            double num = 5.5;
            RoundNumber(num);
        }
    }
}
