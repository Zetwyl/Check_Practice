namespace Task_9
{
    internal class Program
    {
        static double ConvertObjToDouble(object obj)
        {
            return Convert.ToDouble(obj);
        }

        static void Main(string[] args)
        {
            object obj = 1;
            Console.WriteLine(obj.GetType());

            obj = ConvertObjToDouble(obj);
            Console.WriteLine(obj.GetType());
        }
    }
}
