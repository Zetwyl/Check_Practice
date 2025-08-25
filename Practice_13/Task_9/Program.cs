namespace Task_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (char c = '0'; c <= '9'; c++)
            {
                text = text.Replace(c.ToString(), c.ToString() + " ");
            }

            Console.WriteLine(text);
        }
    }
}
