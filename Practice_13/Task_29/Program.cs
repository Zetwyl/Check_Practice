namespace Task_29
{
    internal class Program
    {
        public static string RemoveSpaces(string text)
        {
            return text.Replace(" ", "_");
        }

        static void Main(string[] args)
        {
            string text = "один два три";
            Console.WriteLine(text);

            text = RemoveSpaces(text);

            Console.WriteLine(text);
        }
    }
}
