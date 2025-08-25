namespace Task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "12344";
            bool result = false;

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == '4' && text[i + 1] == '4')
                {
                    result = true;
		            break;
                }
            }

            if (result)
            {
                Console.WriteLine("Во введенной строке имеются следующие подряд две \"4\".");
            }
            else
            {
                Console.WriteLine("Во введенной строке НЕ имеются следующие подряд две \"4\".");
            }
        }
    }
}
