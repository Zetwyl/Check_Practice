namespace Task_7
{
    internal class Program
    {
        static string BinaryValue(int number)
        {
            return Convert.ToString(number, 2);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            string binary = BinaryValue(number);
            Console.WriteLine(binary);
        }
    }
}
