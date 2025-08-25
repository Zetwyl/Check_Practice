namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello world!";
            bool containsOtherChars = false;

            foreach (char c in text)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    containsOtherChars = true;
                    break;
                }
            }

            if (containsOtherChars)
            {
                Console.WriteLine("Текст содержит символы, отличные от букв и пробела.");
            }
            else
            {
                Console.WriteLine("Строка содержит только буквы и пробелы.");
            }
        }
    }
}
