namespace AnimalKingdom
{
    public class Cat : Animal, IMammal
    {
        public int NumberOfNipples => 6;
        
        public override string Sound()
        {
            return base.Sound() + "Miau";
        }

    }
}
