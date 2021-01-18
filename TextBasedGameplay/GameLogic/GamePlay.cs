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
        private Player User = new Player();
        private List<Monster> listOfMonsters = new List<Monster>();

        public void Run()
        {
            GenerateMonsters();
            WelcomeScreen();
        }
        
        private void WelcomeScreen()
        {
            Store store = new Store();

            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("Hello and welcome to Hunt\'a\'Monster!");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.Write("Please enter your battle name: ");
            string userName = Console.ReadLine();
            
            User = new Player(userName, 1, 100, 100, 0, 100, 5, 2, 0, 0, 0);

            bool keepRepeating = true;

            while (keepRepeating && User.Level < 10 && User.HealthPoints > 0)
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
                        store.Run(User);
                        break;
                    case 4:
                        Console.WriteLine("Until next time!");
                        keepRepeating = false;
                        break;
                    case 9:
                        TheMotherLode();
                        break;
                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                }

            }
            
        }
        private int ParseUserInput()
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
        private void GoHunting()
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
                int random = rnd.Next(listOfMonsters.Count());
                var generatedMonster = listOfMonsters[random];

                Console.WriteLine(generatedMonster.Describe());
                Console.WriteLine("[Press enter to continue]");
                Console.ReadLine();

                BattleMode(generatedMonster);
            }
        }
        private void BattleMode(Monster generatedMonster)
        {
            generatedMonster.HealthPoints = generatedMonster.MaxHealthPoints;

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

                    //When user get's LevelUp(), the users experience points is reset to 0 and this boosts Monsters to match user Level
                    if (User.ExperiencePoints == 0)
                    {
                        foreach(Monster monster in listOfMonsters)
                        {
                            monster.Boost();
                        }
                    }

                    break;
                }

                int totalArmour = User.Armour + User.EquipArmour;

                damage = generatedMonster.Attack();

                if(damage <= totalArmour)
                {
                    damage = 0;
                }
                else
                {
                    damage -= totalArmour;
                }

                User.TakeDamage(damage);

                Console.WriteLine($"{generatedMonster.Name} attacks! Dealing {damage} in damage!");
                Console.WriteLine($"{User.Name} is down to {User.HealthPoints} HP!");
                Console.WriteLine("[Press enter to continue]");
                Console.ReadLine();

                if(User.HealthPoints <= 0)
                {
                    Console.WriteLine($"You were killed by the {generatedMonster.Name}, you loose :(");
                    break;
                }
            }
        }
        private void ViewPlayerDetails()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine(User.Describe());
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine("[Press enter to continue]");
            Console.ReadLine();
        }
        private void TheMotherLode()
        {
            User.Gold += 500;
            Console.WriteLine();
            Console.WriteLine($"Motherlode! You found a sunken treasure, you've gained 500 gold!\nYou now have {User.Gold} gold");
        }
        private void GenerateMonsters()
        {
            listOfMonsters = new List<Monster>
            {
                new Swamp("Drowner", 30, 30, 50, 4, "gurgelinggurgelinggurg", "swamp", 9),
                new Swamp("Rottner", 30, 30, 50, 4, "screeching", "swamp", 9),
                new Water("Hydra", 30, 30, 50, 4, "ROOAAAAAR!", "water", 9),
                new Water("Siren", 30, 30, 50, 4, "with a witchy laughter", "water", 9),
                new Forest("Ent", 30, 30, 50, 4, "limping", "gnarly looking", 12),
                new Forest("Forest Guardian", 40, 40, 50, 5, "slowly", "tall and crooked looking", 12),
                new Mountain("Minotaur", 40, 40, 50, 5, "lowering it's horns", "stomps it's hooves", 12),
                new Mountain("Yeti", 40, 40, 50, 5, "claps it's gigantic hands", "grins", 12)
            };
        }
    }
}
