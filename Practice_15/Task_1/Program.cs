namespace Task_1
{
    internal class Program
    {
        static double FindHypotenuse(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        static void Main(string[] args)
        {
            double a = 10;
            double b = 5;
            double c = FindHypotenuse(a, b);
            Console.WriteLine(c);
        }
    }
}
