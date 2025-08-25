using System.Text;

namespace Task_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder(text);

            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] >= '0' && sb[i] <= '9')
                {
                    if (sb[i] != '9')
                    {
                        sb[i]++;
                    }
                    else
                    {
                        sb[i] = '0';
                    }
                }
            }

            string result = sb.ToString();
            Console.WriteLine(result);
        }
    }
}
