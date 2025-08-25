using System.Text;

namespace Task_26
{
    internal class Program
    {
        static void DeleteSpace(ref string text)
        {
            StringBuilder sb = new StringBuilder();

            bool space = false;

            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!space)
                    {
                        sb.Append(' ');
                        space = true;
                    }
                }
                else
                {
                    sb.Append(c);
                    space = false;
                }
            }

            text = sb.ToString().Trim();
        }

        static void Main(string[] args)
        {
            string text = "               a      b        c        d      e     f         ";
            DeleteSpace(ref text);
            Console.WriteLine(text);
        }
    }
}
