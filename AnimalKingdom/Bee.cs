using System;

namespace AnimalKingdom

{
    public class Bee : Animal, ICanFly
    {
        public int NumberOfWings => 2;
        public override string Sound()
        {
            return base.Sound() + "Buzz buzz";
        }

        public string Fly()
        {
            return "The bee can fly!";
        }
    }
}