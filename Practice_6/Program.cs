using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6
{
    internal class Program
    {
        // Задача 1
        private static void Task_1()
        {
            try
            {
                Console.Write("Введите целое число A: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Введите целое число B: ");
                int b = int.Parse(Console.ReadLine());

                if (a == 0)
                {
                    if (b == 0)
                    {
                        Console.WriteLine("x - любое целое число");
                    }
                    else
                    {
                        Console.WriteLine("Решения нет");
                    }
                }
                else
                {
                    if (b % a != 0)
                    {
                        Console.WriteLine("Решения нет");
                    }
                    else
                    {
                        int x = b / a;
                        Console.WriteLine($"Решение: x = {x}");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введено не целое число");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }


        // задача 2
        private static void ProcessNumber(int number)
        {
            if (number % 2 == 0)
                throw new ArithmeticException("Число четное");
            else
                throw new OverflowException("Число нечетное");
        }

        private static void Task_2()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите число (не число для завершения): ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    ProcessNumber(a);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите целое число");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }


        // задача 3
        public class CharException : Exception
        {
            public char[] letters { get; }
            public CharException(int size)
            {
                letters = new char[size];

                for (int i = 0; i < size; i++)
                {
                    letters[i] = (char)('A' + i);
                }
            }
        }

        public static void Task_3()
        {
            try
            {
                throw new CharException(3);

            }
            catch (CharException ex)
            {
                Console.WriteLine(new string(ex.letters));
            }
        }

        static void Main(string[] args)
        {
            Task_1();
            Task_2();
            Task_3();
        }
    }
}
