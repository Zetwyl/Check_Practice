namespace Task_6
{
    internal class Program
    {
        public class Task_6
        {
            string[] array;

            public Task_6(string[] array)
            {
                this.array = array;
            }

            public string this[int index]
            {
                get
                {
                    // Циклическая перестановка индекса
                    while (index >= array.Length)
                        index -= array.Length;
                    while (index < 0)
                        index += array.Length;

                    return array[index];
                }
                set
                {
                    // Циклическая перестановка индекса
                    while (index >= array.Length)
                        index -= array.Length;
                    while (index < 0)
                        index += array.Length;

                    array[index] = value;
                }
            }

            public char this[int stringIndex, int charIndex]
            {
                get
                {
                    // Циклическая перестановка индекса строки
                    while (stringIndex >= array.Length)
                        stringIndex -= array.Length;
                    while (stringIndex < 0)
                        stringIndex += array.Length;

                    string str = array[stringIndex];

                    while (charIndex < 0)
                        charIndex += str.Length;
                    while (charIndex >= str.Length)
                        charIndex -= str.Length;

                    return str[charIndex];
                }
            }
        }

        static void Main(string[] args)
        {
            string[] array = { "abc", "def"};
            Task_6 task = new Task_6(array);

            Console.WriteLine("\nРабота индексаторов:");
            Console.WriteLine(task[0]);
            Console.WriteLine(task[3]);
            task[1] = "xyz";
            Console.WriteLine(task[1]);

            Console.WriteLine(task[0, 1]);
            Console.WriteLine(task[1, 2]);
            Console.WriteLine(task[2, 5]);
            Console.WriteLine(task[4, -1]);
        }
    }
}
