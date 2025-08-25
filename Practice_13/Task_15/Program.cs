namespace Task_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string temp = "";

            foreach (char c in text)
            {
                char newChar = (char)(c + 3);
                temp += newChar;
            }

            text = temp;
            Console.WriteLine(text);
        }
    }
}
