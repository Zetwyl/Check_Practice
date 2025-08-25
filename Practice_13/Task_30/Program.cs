using static System.Net.Mime.MediaTypeNames;

namespace Task_30
{
    internal class Program
    {
        static string RemoveChar(string text, char charToRemove)
        {
            return text.Replace(charToRemove.ToString(), "");
        }

        static void Main(string[] args)
        {
            string sentence = "Предложение, содержащее буквы р и с.";
            string result = RemoveChar(sentence, 'р');
            result = RemoveChar(result, 'с');
            Console.WriteLine(result);
        }
    }
}
