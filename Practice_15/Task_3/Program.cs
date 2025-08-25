namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double degrees = 5;
            double radians = degrees * Math.PI / 180;

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);
            double tan = Math.Tan(radians);

            Console.WriteLine($"sin {degrees} градусов в радианах: " + sin);
            Console.WriteLine($"cos {degrees} градусов в радианах: " + cos);
            Console.WriteLine($"tan {degrees} градусов в радианах: " + tan);
        }
    }
}
