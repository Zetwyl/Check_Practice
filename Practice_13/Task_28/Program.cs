using System.Text;

namespace Task_28
{
    internal class Program
    {
        static void InsertExclamation(ref string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                    sb.Append('!');
                }
                else
                {
                    sb.Append(c);
                }
            }

            text = sb.ToString();
        }

        static void InsertSpace(ref string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                    sb.Append(' ');
                }
                else
                {
                    sb.Append(c);
                }
            }

            text = sb.ToString();
        }

        static void Main(string[] args)
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"line {i}: ");
                string input = Console.ReadLine();

                string tmp1 = input;
                InsertExclamation(ref tmp1);
                Console.WriteLine($"After InsertExclamation: {tmp1}");

                string tmp2 = input;
                InsertSpace(ref tmp2);
                Console.WriteLine($"After InsertSpace: {tmp2}");

                Console.WriteLine();
            }
        }
    }
}
