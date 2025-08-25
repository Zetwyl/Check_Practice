using System;

namespace Task_2
{
    internal class Program
    {
        public abstract class Base
        {
            protected int A_field;
            protected int B_field;

            public Base(int a, int b)
            {
                A_field = a;
                B_field = b;
            }

            public abstract int this[int index] { get; set; }

        }

        public interface IInterface
        {
            int method1(int num);
        }

        public class NewClass : Base, IInterface
        {
            public NewClass(int a, int b) : base(a, b) { }

            public override int this[int index]
            {
                get
                {
                    if (index % 2 == 0)
                    {
                        return A_field;
                    }
                    else
                    {
                        return B_field;
                    }
                }
                set
                {
                    if (index % 2 == 0)
                    {
                        A_field = value;
                    }
                    else
                    {
                        B_field = value;
                    }
                }
            }

            public int method1(int num) => (A_field + B_field) * num;
        }

        static void Main(string[] args)
        {
            NewClass obj = new NewClass(5, 5);

            Console.WriteLine($"Поля до изменения: A_field = {obj[0]}, B_field = {obj[1]}");
            Console.WriteLine($"Результат method1(2): {obj.method1(2)}");
        }
    }
}
