namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Текст 0123 с 456 цифрами 789";

            for (char c = '0'; c <= '9'; c++)
            {
                text = text.Replace(c.ToString(), "");
            }

            Console.WriteLine(text);
        }
    }
}
