namespace AnimalKingdom
{
    public class Bee : Animal, ICanFly
    {
        public int NumberOfWings => 2;

        public int NumberOfLegs => 6;

        public override string Sound()
        {
            return base.Sound() + "Buzz buzz";
        }
    }
}