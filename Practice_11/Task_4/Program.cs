namespace Task_4
{
    internal class Program
    {
        class Task_4
        {
            private int[] array;
            private int arrayIndex;
            private bool firstRead = true;

            public Task_4(int[] array)
            {
                this.array = array;
            }

            public int Current
            {
                get
                {
                    if (firstRead)
                    {
                        firstRead = false;
                    }
                    else
                    {
                        arrayIndex++;

                        if (arrayIndex >= array.Length)
                        {
                            arrayIndex = 0;
                        }
                    }
                    return array[arrayIndex];
                }
                set
                {
                    array[arrayIndex] = value;
                }
            }
        }

        static void Main(string[] args)
        {
            int[] data = { 1, 2, 3, 4, 5 };
            Task_4 task = new Task_4(data);

            Console.WriteLine(task.Current);
            task.Current = 10;
            Console.WriteLine(task.Current);
            Console.WriteLine(task.Current);
            Console.WriteLine(task.Current);
            Console.WriteLine(task.Current);

            Console.WriteLine(task.Current);
            Console.WriteLine(task.Current);
            Console.WriteLine(task.Current);
            Console.WriteLine(task.Current);
            Console.WriteLine(task.Current);
        }
    }
}
