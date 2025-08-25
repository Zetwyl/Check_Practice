namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Котенок Васька уютно свернулся на коврике";
            string[] words = text.Split(' ');
            double count = 0;
            char ch = 'К';

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0)
                {
                    continue;
                }

                if (words[i][0] == ch)
                {
                    count++;
                }
            }

            double percentage = count / words.Length * 100;
            Console.WriteLine($"{percentage:F2}%");
        }
    }
}
