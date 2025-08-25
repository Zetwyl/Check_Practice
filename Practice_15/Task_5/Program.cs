namespace Task_5
{
    internal class Program
    {
        static int Max(int[] arr)
        {
            int max = arr[0];
            foreach (int i in arr)
            {
                max = Math.Max(max, i);
            }
            return max;
        }

        static int Min(int[] arr)
        {
            int min = arr[0];
            foreach (int i in arr)
            {
                min = Math.Min(min, i);
            }
            return min;
        }

        static void Main(string[] args)
        {
            int[] num = { 1, 2, 3 };
            int maxValue = Max(num);
            int minValue = Min(num);

            Console.WriteLine("maxValue: " + maxValue);
            Console.WriteLine("minValue: " + minValue);
        }
    }
}
