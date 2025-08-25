namespace Task_19
{
    internal class Program
    {
        static void InsertWords(ref string text, char ch, int count)
        {
            for (int i = 0; i < count; i++)
            {
                text += ch;
            }
        }

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine("Before: " + text);

            InsertWords(ref text, '*', 3);

            Console.WriteLine("After: " + text);
        }
    }
}
