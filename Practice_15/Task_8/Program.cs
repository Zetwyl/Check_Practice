namespace Task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ввелите дату (Пример: 2025-05-26): ");
            DateTime a = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine(a);
        }
    }
}
