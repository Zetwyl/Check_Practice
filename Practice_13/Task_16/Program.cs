namespace Task_16
{
    internal class Program
    {
        static int SumMultipleOfThree(string text)
        {
            int sum = 0;

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    int digit = Convert.ToInt32(c.ToString());
                    if (digit % 3 == 0)
                    {
                        sum += digit;
                    }
                }
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1 line: ");
            string a = Console.ReadLine();

            Console.WriteLine("2 line: ");
            string b = Console.ReadLine();

            Console.WriteLine("3 line: ");
            string c = Console.ReadLine();

            int sumA = SumMultipleOfThree(a);
            int sumB = SumMultipleOfThree(b);
            int sumC = SumMultipleOfThree(c);

            Console.WriteLine(sumA);
            Console.WriteLine(sumB);
            Console.WriteLine(sumC);
        }
    }
}
