namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "По мнению исследователей использование скобок повышает читаемость текста.";
            Console.WriteLine(text);

            text = text.Replace(" ", ", ");

            Console.WriteLine(text);
        }
    }
}
