namespace Task_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();

            string textFirst = text.Substring(0, text.Length - 1);
            string textLast = text.Substring(text.Length - 1, 1);
            text = textLast + textFirst;
            Console.WriteLine(text);
        }
    }
}
