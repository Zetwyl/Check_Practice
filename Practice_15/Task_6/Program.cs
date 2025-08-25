namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Ввод: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Вывод: " + a);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Вывод: " + ex.Message);
            } 
        }
    }
}
