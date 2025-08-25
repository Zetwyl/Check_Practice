namespace Task_23
{
    internal class Program
    {
        static void InsertSpace(ref string text, int interval, int space)
        {
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                result += text[i];
                if ((i + 1) % interval == 0 && i != text.Length - 1)
                {
                    result += new string(' ', space);
                }
            }

            text = result;
        }

        static void Main(string[] args)
        {
            //string text = Console.ReadLine();
            string text = "12345678901234567890123456789012345678901234567890";
            InsertSpace(ref text, 5, 3);
            Console.WriteLine(text);
        }
    }
}
