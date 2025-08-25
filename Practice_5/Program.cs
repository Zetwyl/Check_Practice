using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5
{
    internal class Program
    {

        // Задача 1
        public class GetValue<T>
        {
            private T _value;

            public T Value
            {
                get => _value;
                set => _value = value;
            }
        }

        // Задача 2
        public static T FindMax<T>(T[] array) where T : IComparable<T>
        {
            T max = array[0];
            foreach (T item in array)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }


        // Задача 3
        public class Combined<T>
        {
            public T[] items;

            public Combined(T[] values)
            {
                items = values;
            }

            public static Combined<T> operator +(Combined<T> a, Combined<T> b)
            {
                T[] combined = new T[a.items.Length + b.items.Length];

                int position = 0;
                foreach (T item in a.items)
                {
                    combined[position] = item;
                    position++;
                }

                foreach (T item in b.items)
                {
                    combined[position] = item;
                    position++;
                }

                return new Combined<T>(combined);
            }
        }

        // Задача 4
        public class Array<T>
        {
            private T[] items = new T[0];

            public void Add(T item)
            {
                T[] newItems = new T[items.Length + 1];

                for (int i = 0; i < items.Length; i++)
                {
                    newItems[i] = items[i];
                }

                newItems[newItems.Length - 1] = item;

                items = newItems;
            }

            public void Remove(int index)
            {
                T[] newItems = new T[items.Length - 1];
                int newArrayIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (i != index)
                    {
                        newItems[newArrayIndex] = items[i];
                        newArrayIndex++;
                    }
                }

                items = newItems;
            }

            public T Get(int index) => items[index];

            public int Length() => items.Length;

            public void Print()
            {
                foreach (var item in items)
                {
                    Console.Write(item + " ");
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine('\n' + "=== task 1 ===");
            var num = new GetValue<int>();
            num.Value = 10;
            Console.WriteLine(num.Value);


            Console.WriteLine('\n' + "=== task 2 ===");
            int[] numbers = { 1, 5, 3, 9, 2 };
            string[] words = { "apple", "orange", "banana", "pear" };
            int maxNumber = FindMax(numbers);
            string maxWord = FindMax(words);
            Console.WriteLine($"Максимальное число: {maxNumber}");
            Console.WriteLine($"Максимальное слово: {maxWord}");


            Console.WriteLine('\n' + "=== task 3 ===");
            Combined<int> combo1 = new Combined<int>(new[] { 1, 2, 3 });
            Combined<int> combo2 = new Combined<int>(new[] { 4, 5, 6 });
            Combined<int> result = combo1 + combo2;
            Console.Write("Result: ");
            foreach (var item in result.items)
            {
                Console.Write($"{item} ");
            }


            Console.WriteLine("\n\n" + "=== task 4 ===");
            Console.WriteLine("1) int");
            var intArray = new Array<int>();
            Console.WriteLine("Length: " + intArray.Length());
            Console.Write("Array: ");
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            intArray.Print();
            Console.WriteLine("\nLength: " + intArray.Length());
            Console.WriteLine("Length before delete: " + intArray.Length());
            intArray.Remove(0);
            Console.WriteLine("Length after delete: " + intArray.Length());
            Console.Write("Array: ");
            intArray.Print();
            Console.WriteLine("\nGet (index 1): " + intArray.Get(1));

            Console.WriteLine("\n2) String");
            var strArray = new Array<string>();
            Console.WriteLine("Length: " + strArray.Length());
            Console.Write("Array: ");
            strArray.Add("one");
            strArray.Add("two");
            strArray.Add("rhree");
            strArray.Print();
            Console.WriteLine("\nLength: " + strArray.Length());
            Console.WriteLine("Length before delete " + strArray.Length());
            strArray.Remove(0);
            Console.WriteLine("Length after delete " + strArray.Length());
            Console.WriteLine("Get (index 1): " + strArray.Get(1));
        }
    }
}
