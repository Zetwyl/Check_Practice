using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        public class Animal { }
        public class Bird : Animal { }
        public class Mammals : Animal { }
        public class Reptiles : Animal { }

        delegate T CovaDel<out T>();
        delegate void ContraDel<in T>(T obj);
        delegate TResult AnimalDel<in T, out TResult>(T animal);

        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>()
            {
                new Mammals(),
                new Reptiles(),
                new Bird()
            };

            CovaDel<Mammals> getMammals = () => new Mammals();
            CovaDel<Animal> getAnimal1 = getMammals;
            Animal animal = getAnimal1();

            ContraDel<Animal> getAnimal2 = (Animal a) => Console.WriteLine(a.GetType().Name);
            ContraDel<Reptiles> getReptiles = getAnimal2;
            getReptiles(new Reptiles());

            AnimalDel<Animal, Bird> Animal1 = (Animal a) => new Bird();
            AnimalDel<Reptiles, Animal> Animal2 = Animal1;
            Animal animal3 = Animal2(new Reptiles());
            Console.WriteLine(animal3.GetType().Name);
        }
    }
}
