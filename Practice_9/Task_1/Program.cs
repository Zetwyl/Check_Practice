using System;

namespace Task_1
{
    internal class Program
    {
        abstract class Base
        {
            protected int[] Array;

            public Base(int length)
            {
                Array = new int[length];
            }

            public abstract void Print();
            public int Length => Array.Length;

            public int this[int index]
            {
                get => Array[index];
                set => Array[index] = value;
            }
        }

        class Derived : Base
        {
            public Derived(int length) : base(length) { }
            public override void Print()
            {
                foreach (int arr in Array)
                {
                    Console.WriteLine(arr);
                }

            }
        }

        static void Main(string[] args)
        {
            Derived mem = new Derived(3);
            mem.Print();
        }
    }
}
