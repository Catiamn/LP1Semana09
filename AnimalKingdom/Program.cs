using System;

namespace AnimalKingdom
{
    class Program
    {
        static void Main(string[] args)
        {

            //array de animais 
            Animal[] zoo = { new Dog(), new Cat(), new Bat(), new Bee()};
            foreach (Animal animal in zoo)
            {
                Console.WriteLine(animal.Sound());

                if (animal is ICanFly flyingAnimal)
                {
                    Console.WriteLine(flyingAnimal.Fly());
                }
                if (animal is IMammal mammal)
                {
                    Console.WriteLine($"Number of Nipples: {mammal.NumberOfNipples}");
                }
            }
        }
        
    }
}