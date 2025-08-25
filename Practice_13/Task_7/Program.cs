namespace Task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (char c = 'F'; c <= 'K'; c++)
            {
                text = text.Replace(c.ToString(), "");
            }

            Console.WriteLine(text);
        }
    }
}
