namespace AnimalKingdom
{
    public class Dog : Animal, IMammal
    {
        public int NumberOfNipples => 8;
        public override string Sound()
        {
            return base.Sound() + "Woof!";
        }
    }
}
