using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerManager4 
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        private PlayerManager playerManager;

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
            playerManager = new PlayerManager();
            playerManager.AddPlayer("Best player ever", 100);
            playerManager.AddPlayer("An even better player", 500);
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {
            string option;

            //main menu loop
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
                        ListPlayers(playerManager.GetPlayers(), "score");
                        break;
                    case "3":
                        ListPlayers(playerManager.GetPlayers(), "nameAsc");
                        break;
                    case "4":
                        ListPlayers(playerManager.GetPlayers(), "nameDesc");
                        break;
                    case "5":
                        Console.WriteLine("Quitting the program :(");
                        continue;
                    default:
                        Console.Error.WriteLine("We don't recognize that option! Sorry! D: ");
                        break;
                }
                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

            } while (option != "5");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Player listing program\n");
            Console.WriteLine("1. Insert a new player");
            Console.WriteLine("2. List players by score (default is descending)");
            Console.WriteLine("3. List players by name (ascending)");
            Console.WriteLine("4. List players by name (descending)");
            Console.WriteLine("5. Quit the program :O \n");
            Console.WriteLine(">>> Press 1, 2, 3, 4 or 5 <<<\n"); 
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
                playerManager.AddPlayer(name, score);
            }
            else
            {
                Console.Error.WriteLine("Doesn't seem like a valid score :/ \n");
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
        private static void ListPlayers(IEnumerable<Player> playersToList, string orderBy)
        {
            IEnumerable<Player> sortedPlayers;

            switch (orderBy)
            {
                case "nameAsc":
                    sortedPlayers = playersToList.OrderBy(player => player, new CompareByName(true));
                    break;
                case "nameDesc":
                    sortedPlayers = playersToList.OrderBy(player => player, new CompareByName(false));
                    break;
                default: // default is descending
                    sortedPlayers = playersToList.OrderByDescending(player => player.Score);
                    break;
            }

            // show players 
            Console.WriteLine("\nList of players:\n");
            foreach (Player player in sortedPlayers)
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
            // Ask the user for the minimum score
            Console.Write("Enter minimum score: ");
            string minScoreStr = Console.ReadLine();

            if (int.TryParse(minScoreStr, out int minScore))
            {
                IEnumerable<Player> playersWithScoreGreaterThan = playerManager.GetPlayersWithScoreGreaterThan(minScore);
                ListPlayers(playersWithScoreGreaterThan, "score");
            }
            else
            {
                Console.Error.WriteLine("\n>>> Invalid score! <<<\n");
            }
        }
    }
}