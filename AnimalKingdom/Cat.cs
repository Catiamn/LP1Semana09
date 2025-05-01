namespace AnimalKingdom
{
    public class Cat : Animal
    {
        public int NumberOfNipples => 2;
        
        public override string Sound()
        {
            return base.Sound() + "Miau";
        }

    }
}
