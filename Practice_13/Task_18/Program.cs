namespace Task_18
{
    internal class Program
    {
        public static int Check_Ascii_Over_69(string input)
        {
            int count = 0;
            foreach (char symbol in input)
            {
                if (symbol >= 70)
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string inputText = Console.ReadLine();
            int count = Check_Ascii_Over_69(inputText);
            Console.WriteLine($"Количество символов с ASCII-кодом >= 70: {count}");
        }
    }
}
