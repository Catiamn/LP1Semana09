using System;

namespace PlayerManager1
{
    public class PlayerManager
    {
        private Player[] players;
        private int playerCount = 0;
        private const int maxPlayers = 100; // maximum number of players

        public PlayerManager()
        {
            players = new Player[maxPlayers];
        }

        public void AddPlayer(string name, int score)
        {
            if (playerCount < maxPlayers)
            {
                players[playerCount] = new Player(name, score);
                playerCount++;
            }
            else
            {
                Console.WriteLine("Player limit reached. Cannot add more players.");
            }
        }
    }
}