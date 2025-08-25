using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_5
{
    internal class Program
    {
        public class Task_5
        {
            private int _value;

            public int Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    if (value >= 0)
                    {
                        _value = value;
                    }
                    else
                    {
                        throw new ArgumentException("Число должно быть не отрицательным");
                    }
                }
            }
            public Task_5(int value)
            {
                _value = value;
            }

            public int this[int category]
            {
                set
                {
                    int newDigit = value % 10;
                    int multiplier = 1;

                    for (int i = 0; i < category; i++)
                    {
                        multiplier *= 10;
                    }

                    int higher = _value / (multiplier * 10);
                    int lower = _value % multiplier;

                    _value = higher * (multiplier * 10)
                        + newDigit * multiplier
                        + lower;
                }
            }
        }
        static void Main(string[] args)
        {
            var num = new Task_5(0);
            num.Value = 1234;
            Console.WriteLine(num.Value);

            try
            {
                num.Value = -5;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(num.Value);
            num[0] = 9;
            Console.WriteLine(num.Value);
            num[1] = 9;
            Console.WriteLine(num.Value);
            num[2] = 9;
            Console.WriteLine(num.Value);
            num[3] = 9;
            Console.WriteLine(num.Value);
        }
    }
}
