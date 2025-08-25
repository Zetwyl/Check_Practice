using System.Text;

namespace Task_24
{
    internal class Program
    {
        static void ReplaceWord(ref string text, string A1, string A2)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == A1)
                    words[i] = A2;

                if (i > 0)
                    sb.Append(' ');

                sb.Append(words[i]);
            }

            text = sb.ToString();
        }

        static void Main(string[] args)
        {
            string text = "Кот лежит рядом с котёнком и смотрит на другого котёнка";
            Console.WriteLine($"Before: {text}");

            ReplaceWord(ref text, "Кот", "Котёнок");

            Console.WriteLine($"After: {text}");
        }
    }
}
