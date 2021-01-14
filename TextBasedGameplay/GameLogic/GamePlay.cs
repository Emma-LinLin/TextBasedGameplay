using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextBasedGameplay.Mobs;
using TextBasedGameplay.UserInformation;

namespace TextBasedGameplay.GameLogic
{
    class GamePlay
    {
        static Player User = new Player();
        static List<Monster> listOfMonsters = new List<Monster>();

        public void Run()
        {
            GenerateMonsters();
            WelcomeScreen();
        }
        
        public void WelcomeScreen()
        {
            Console.WriteLine("Hello and welcome to Hunt\'a\'Monster!");
            Console.WriteLine();
            Console.Write("Please enter your battle name: ");
            string userName = Console.ReadLine();
            
            User = new Player(userName, 1, 10, 200, 200, 0, 100, 10);

            bool keepRepeating = true;

            while (keepRepeating)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Hunt monsters!");
                Console.WriteLine("2. View player stats");
                Console.WriteLine("3. Exit game");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        GoHunting();
                        break;
                    case 2:
                        ViewPlayerDetails();
                        break;
                    case 3:
                        Console.WriteLine("Until next time!");
                        keepRepeating = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                }

            }
            
        }
        public void GoHunting()
        {
            Random rnd = new Random();
            int r = rnd.Next(listOfMonsters.Count());
            var generatedMonster = listOfMonsters[r];

            Console.WriteLine(generatedMonster.Describe());
        }
        public void ViewPlayerDetails()
        {
            Console.WriteLine(User.Describe());
            Console.WriteLine("[Press enter to continue]");
            Console.ReadLine();
        }
        public void GenerateMonsters()
        {
            listOfMonsters = new List<Monster>
            {
                new Swamp("Drowner", 50, 30, 7, "gurgelinggurgelinggurg", "swamp"),
                new Swamp("Rottner", 50, 30, 9, "screeching", "swamp"),
                new Water("Hydra", 50, 30, 9, "ROOAAAAAR!", "water"),
                new Water("Siren", 50, 30, 7, "with a witchy laughter", "water"),
                new Forest("Ent", 50, 30, 9, "limping", "gnarly looking"),
                new Forest("Forest Guardian", 50, 40, 9, "slowly", "tall and crooked looking"),
                new Mountain("Minotaur", 50, 40, 9, "lowering it's horns", "stomps it's hooves"),
                new Mountain("Yeti", 50, 40, 7, "claps it's gigantic hands", "grins")
            };
        }
    }
}
