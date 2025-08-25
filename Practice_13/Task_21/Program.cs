using System.Text;

namespace Task_21
{
    internal class Program
    {
        static void ReverseText(ref string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = text.Length - 1; i > -1; i--)
            {
                sb.Append(text[i]);
            }
            text = sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Ввод: ");
            string text = Console.ReadLine();

            ReverseText(ref text);
            Console.WriteLine($"Вывод: {text}");
        }
    }
}
