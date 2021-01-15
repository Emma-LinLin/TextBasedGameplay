using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextBasedGameplay.Mobs;
using TextBasedGameplay.ShopInformation;
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
            Store store = new Store();

            Console.WriteLine("Hello and welcome to Hunt\'a\'Monster!");
            Console.WriteLine();
            Console.Write("Please enter your battle name: ");
            string userName = Console.ReadLine();
            
            User = new Player(userName, 1, 10, 200, 200, 0, 100, 10, 0);

            bool keepRepeating = true;

            while (keepRepeating)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Hunt monsters!");
                Console.WriteLine("2. View player stats");
                Console.WriteLine("3. Visit the nearest merchant");
                Console.WriteLine("4. Exit game");

                int userInput = ParseUserInput();

                switch (userInput)
                {
                    case 1:
                        GoHunting();
                        break;
                    case 2:
                        ViewPlayerDetails();
                        break;
                    case 3:
                        store.Run();
                        break;
                    case 4:
                        Console.WriteLine("Until next time!");
                        keepRepeating = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                }

            }
            
        }
        public int ParseUserInput()
        {
            int userInput;

            while (true)
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    return userInput;
                }
                catch (Exception)
                {
                    Console.WriteLine("Only numbers please! Try again");
                }

            }
        }
        public void GoHunting()
        {
            Random rnd = new Random();
            int rollForAdventure = rnd.Next(1, 11);

            if(rollForAdventure == 10)
            {
                Console.WriteLine("You're looking around, but there's nothing but trees here. Better head home again I guess.");
                Console.WriteLine("[Press enter to continue]");
                Console.ReadLine();
            }
            else
            {
                int r = rnd.Next(listOfMonsters.Count());
                var generatedMonster = listOfMonsters[r];

                Console.WriteLine(generatedMonster.Describe());
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();

                BattleMode(generatedMonster);
            }
        }
        public void BattleMode(Monster generatedMonster)
        {
            generatedMonster.HealthPoints = 50;

            while (true)
            {
                int damage = User.Attack();
                generatedMonster.TakeDamage(damage);

                Console.WriteLine($"{User.Name} Attacks! Dealing {damage} in damage,\n{generatedMonster.Name} is down to {generatedMonster.HealthPoints} HP!");
                Console.WriteLine("[Press enter to continue]");
                Console.ReadLine();

                if (generatedMonster.HealthPoints <= 0)
                {
                    int gainedPoints = generatedMonster.GiveExperience();
                    int gold = generatedMonster.GiveGold();
                    Console.WriteLine($"The {generatedMonster.Name} is dead, you've gained {gainedPoints} EXP and {gold} gold!");

                    User.GainExperience(gainedPoints);
                    User.GetGold(gold);
                    break;
                }

                damage = generatedMonster.Attack();
                User.TakeDamage(damage);

                Console.WriteLine($"{generatedMonster.Name} attacks! Dealing {damage} in damage,\n{User.Name} is down to {User.HealthPoints} HP!");
                Console.WriteLine("[Press enter to continue]");
                Console.ReadLine();

                if(User.HealthPoints <= 0)
                {
                    Console.WriteLine($"You were killed by the {generatedMonster.Name}");
                    break;
                }
            }
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
                new Swamp("Drowner", 50, 30, 7, "gurgelinggurgelinggurg", "swamp", 20),
                new Swamp("Rottner", 50, 30, 9, "screeching", "swamp", 20),
                new Water("Hydra", 50, 30, 9, "ROOAAAAAR!", "water", 30),
                new Water("Siren", 50, 30, 7, "with a witchy laughter", "water", 30),
                new Forest("Ent", 50, 30, 9, "limping", "gnarly looking", 40),
                new Forest("Forest Guardian", 50, 40, 9, "slowly", "tall and crooked looking", 40),
                new Mountain("Minotaur", 50, 40, 9, "lowering it's horns", "stomps it's hooves", 40),
                new Mountain("Yeti", 50, 40, 7, "claps it's gigantic hands", "grins", 40)
            };
        }
    }
}
