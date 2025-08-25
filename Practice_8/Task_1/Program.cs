using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        public class Animal { }
        public class Dog : Animal { }
        public class Cat : Animal { }

        delegate T Func<out T>();
        delegate void Action<in T>(T animal);

        static void Main(string[] args)
        {
            Func<Dog> GetDog = () => new Dog();
            Func<Animal> getDog = GetDog;
            Animal animal = getDog();

            Action<Animal> getAnimal = (a) => Console.WriteLine(a.GetType().Name);
            Action<Cat> cat = getAnimal;
            cat(new Cat());
        }
    }
}
