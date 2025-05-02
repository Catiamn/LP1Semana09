using System;
using System.Collections.Generic;

namespace PlayerManager2
{
    public class PlayerManager
    {
        private List<Player> players;

        public PlayerManager()
        {
            players = new List<Player>();
        }

        public void AddPlayer(string name, int score)
        {
            players.Add(new Player(name, score));
            Console.WriteLine($"\nPlayer {name} added!\n");
        }

        public IEnumerable<Player> GetPlayers()
        {
            foreach (Player player in players)
            {
                yield return player;
            }
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        public IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player player in players)
            {
                if (player.Score > minScore)
                {
                    yield return player; // use yield return to return each player one by one
                }
            }
        }
    }
}