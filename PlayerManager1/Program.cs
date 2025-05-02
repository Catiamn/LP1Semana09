using System;
using System.Collections.Generic;

namespace PlayerManager1 // >>> Change to PlayerManager2 for exercise 4 <<< //
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {

            Program prog = new Program();
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {

            string option;

            //loop
            do
            {
                ShowMenu();
                option = Console.ReadLine();


                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        Console.WriteLine("Quitting the program :(");
                        continue;
                    default:
                        Console.Error.WriteLine("We don't recognize that option! Sorry! D: ");
                        break;
                }

                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

                
            } while (option != "4");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Player listing program\n");
            Console.WriteLine("1. Insert a new player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List players with score greater than a given value");
            Console.WriteLine("4. Quit the program\n");
            Console.WriteLine(">>> Press 1, 2, 3 or 4 <<<\n"); 
            Console.Write("Please choose an option: ");
            
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            //ask user for player name and score
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();
            Console.Write("Enter player score: ");
            string scoreStr = Console.ReadLine();

            
            if (int.TryParse(scoreStr, out int score))
            {
                // creates a new player and adds to the list
                Player newPlayer = new Player(name, score);
                playerList.Add(newPlayer);
                Console.WriteLine($"\n>>> Player {name} added! <<<\n");
            }
            else
            {
                Console.Error.WriteLine("\n>>> Invalid score! <<<\n");
            }
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            // show players 
            Console.WriteLine("\nList of players:\n");
            foreach (Player player in playersToList)
            {
                Console.WriteLine(player.ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            // score value
            Console.Write("Enter minimum score: ");
            string minScoreStr = Console.ReadLine();

            if (int.TryParse(minScoreStr, out int minScore))
            {                
                IEnumerable<Player> playersWithScoreGreaterThan = GetPlayersWithScoreGreaterThan(minScore);

                //list the players
                ListPlayers(playersWithScoreGreaterThan);
            }
            else
            {
                Console.Error.WriteLine("\n>>> Invalid score! <<<\n");
            }
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {

            List<Player> playersWithScoreGreaterThan = new List<Player>();

            foreach (Player player in playerList)
            {
                if (player.Score > minScore)
                {
                    playersWithScoreGreaterThan.Add(player);
                }
            }
            return playersWithScoreGreaterThan;
        }
    }
}