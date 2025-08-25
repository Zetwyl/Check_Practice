namespace Task_22
{
    internal class Program
    {
        static void lineLength(string text, int k)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (i % k == 0 && i != 0)
                {
                    Console.WriteLine();
                }
                Console.Write(text[i]);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Ввод: ");
            string text = Console.ReadLine();
            lineLength(text, 5);
        }
    }
}
