namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "По мнению исследователей использование скобок повышает читаемость текста";
            Console.Write("Введите слово для поиска: ");
            string input = Console.ReadLine();
            int count = 0;

            string[] array = text.Split();

            foreach (string s in array)
            {
                if (s == input)
                {
                    count++;
                }
            }

            Console.WriteLine($"{count} раз в тексте встречается заданное слово ");
        }
    }
}
