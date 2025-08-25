namespace Task_25
{
    internal class Program
    {
        static void ReplaceSymbol(ref string text, char oldSymbol, char newSymbol)
        {
            text = text.Replace(oldSymbol, newSymbol);
        }

        static void Main(string[] args)
        {
            string text = "Hello";
            Console.WriteLine(text);

            ReplaceSymbol(ref text, 'l', 'r');

            Console.WriteLine(text);
        }
    }
}
