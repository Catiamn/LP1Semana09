using System;

namespace AnimalKingdom
{
    public class Bat : Animal, ICanFly, IMammal
    {
        public int NumberOfWings => 2;
        public int NumberOfNipples => 2;

        public override string Sound()
        {
            return base.Sound() + "Screech!";
        }

        public string Fly()
        {
            return "The bat can fly!";
        }
    }
}