namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Math.Random - такого метода нету
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next(1, 101));
            }
        }
    }
}
