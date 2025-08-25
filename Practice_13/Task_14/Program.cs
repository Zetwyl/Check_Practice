namespace Task_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                if ((i+1) % 5 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
