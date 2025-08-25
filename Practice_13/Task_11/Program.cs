using System.Text;

namespace Task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder letters = new StringBuilder();
            StringBuilder digit = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    letters.Append(c);
                }
                else if (char.IsDigit(c))
                {
                    digit.Append(c);
                }
            }

            text = digit.ToString() + letters.ToString();
            Console.WriteLine(text);
        }
    }
}
