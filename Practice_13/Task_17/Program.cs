namespace Task_17
{
    internal class Program
    {
        static int Sum(string text)
        {
            int sum = 0;
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    int digit = Convert.ToInt32(c.ToString());
                    sum += digit;
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

            int sumA = Sum(a);
            int sumB = Sum(b);

            Console.WriteLine(sumA);
            Console.WriteLine(sumB);
        }
    }
}
