namespace Task_27
{
    internal class Program
    {
        static void ReplaceSymbol(ref string text, char oldSymbol, char newSymbol)
        {
            text = text.Replace(oldSymbol, newSymbol);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1 line: ");
            string a = Console.ReadLine();

            Console.WriteLine("2 line: ");
            string b = Console.ReadLine();

            Console.WriteLine("3 line: ");
            string c = Console.ReadLine();

            // русская буква 'с' заменяется на русскую 'о'
            ReplaceSymbol(ref a, 'с', 'о');
            ReplaceSymbol(ref b, 'с', 'о');
            ReplaceSymbol(ref c, 'с', 'о');

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}
