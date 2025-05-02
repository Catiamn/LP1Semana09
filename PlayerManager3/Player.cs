using System;

namespace PlayerManager3
{
    public class Player
    {
        //readonly, no use of set;
        public string Name { get; }
        public int Score { get; }


        //constructor, aka same name as class, no return type
        public Player(string name, int score)
        {
            Name = name;  //no need for "this." because no other variable with the same name
            Score = score;
        }

        // readable output of the Player object
        public override string ToString()
        {
            return $"Name: {Name}, Score: {Score}";
        }
    }
}