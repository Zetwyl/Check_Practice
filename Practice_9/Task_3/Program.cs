namespace Task_3
{
    internal class Program
    {
        public abstract class BaseClass
        {
            public abstract int Num { get; set; }
            public abstract int this[int index] { get; set; }
            public abstract void BaseMethod();
        }

        public interface INumberOne
        {
            int Num { get; set; }
            int this[int index] { get; set; }
            void BaseMethod();
        }
        public interface INumberTwo
        {
            int Num { get; set; }
            int this[int index] { get; set; }
            void BaseMethod();
        }

        public class NewClass : BaseClass, INumberOne, INumberTwo
        {
            private int num;
            private int[] array = new int[10];

            public override int Num
            {
                get => num;
                set => num = value;
            }

            public override int this[int index]
            {
                get => array[index];
                set => array[index] = value;
            }

            public override void BaseMethod() => Console.WriteLine("BaseClass");

            int INumberOne.Num
            {
                get => num + 1;
                set => num = value - 1;
            }

            int INumberTwo.Num
            {
                get => num;
                set => num = value;
            }

            int INumberOne.this[int index]
            {
                get => array[index] + 1;
                set => array[index] = value - 1;
            }
            int INumberTwo.this[int index]
            {
                get => array[index];
                set => array[index] = value;
            }

            void INumberOne.BaseMethod() => Console.WriteLine("INumberOne");
            void INumberTwo.BaseMethod() => Console.WriteLine("INumberTwo");
        }

        static void Main(string[] args)
        {
            NewClass baseClass = new NewClass();
            INumberOne i1 = baseClass;
            INumberTwo i2 = baseClass;

            baseClass.Num = 10;
            Console.WriteLine($"-------\nСвойство: {baseClass.Num}");
            baseClass[0] = 15;
            Console.WriteLine($"Индексатор[0]: {baseClass[0]}");
            Console.Write("Метод: ");
            baseClass.BaseMethod();

            i1.Num = 15;
            Console.WriteLine($"-------\nСвойство: {i1.Num}");
            i1[1] = 20;
            Console.WriteLine($"Индексатор[1]: {i1[1]}");
            Console.Write("Метод: ");
            i1.BaseMethod();

            i2.Num = 20;
            Console.WriteLine($"-------\nСвойство: {i2.Num}");
            i2[2] = 25;
            Console.WriteLine($"Индексатор[2]: {i2[2]}");
            Console.Write("Метод: ");
            i2.BaseMethod();
        }
    }
}
