namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "По мнению исследователей (Иванов, 2020), использование скобок повышает читаемость текста.";
            Console.WriteLine(text);

            int firstIndex = text.IndexOf('(');
            int lastIndex = text.IndexOf(')');
            int count = lastIndex - firstIndex + 1;

            text = text.Remove(firstIndex, count);
            Console.WriteLine(text);
        }
    }
}
