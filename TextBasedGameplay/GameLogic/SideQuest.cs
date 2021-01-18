using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TextBasedGameplay.Mobs;
using TextBasedGameplay.UserInformation;

namespace TextBasedGameplay.GameLogic
{
    class SideQuest
    {
        private List<Monster> listOfRareMonsters = new List<Monster>();
        private Player user;
        private GamePlay game = new GamePlay();

        /// <summary>
        /// Runs the in game side quest sequence.
        /// </summary>
        public void Run(Player User)
        {
            user = User;

            Loading();
            GenerateRareMonsters();
            WelcomeScreen();
        }
        private void WelcomeScreen()
        {
            Console.WriteLine();
            Console.WriteLine("You've been walking through the forest, suddenly you come across a small village..");
            Console.WriteLine();
            Console.WriteLine("Villager: \"Hey warrior! Come here, I have a job for you!");
            Console.WriteLine("We've had trouble with some of our miners, they told me that they found a silver vein up the mountains..");
            Console.WriteLine("They ventured out 5 days ago, haven't seen them since, could you take a look?\"");
            Console.WriteLine();
            Console.WriteLine($"[Recommended Level for this quest is 5+, you're currently on Level: {user.Level}]");
            
            bool keepRepeating = true;

            while (keepRepeating && user.HealthPoints > 0)
            {
                Console.WriteLine("[Enter [Yes] to continue, enter [No] to quit]");
                string userChoice = Console.ReadLine().Trim().ToLower();

                switch (userChoice)
                {
                    case "yes":
                        Console.WriteLine();
                        Console.WriteLine($"{user.Name}: \"Sure, I could take a look.\"");
                        keepRepeating = GoAdventuring();
                        break;
                    case "no":
                        Console.WriteLine($"{user.Name}: \"Another time maybe.. cya!\"");
                        keepRepeating = false;
                        break;
                    default:
                        Console.WriteLine("[Not a valid option]");
                        break;
                }
            }
            
        }
        private bool GoAdventuring()
        {
            int gold = 50;

            Console.WriteLine("Villager: \"Thank you! Just follow the road up a head, the base of the mountain is to your left, can't miss it!\"");
            Console.WriteLine();
            Console.WriteLine("You followed the small crooked road as the villager described, soon enough you come across the miners camp.");
            Console.WriteLine("Looks like they ventured up the mountain just a couple of days ago. You've decided to follow their footsteps..");
            Console.WriteLine("[Press enter to continue]");
            Console.ReadLine();
            Loading();

            Console.WriteLine("You're now at the entrance of the mine, 5 steps in and you hear a blood chilling scream!");

            Random rnd = new Random();
            int random = rnd.Next(listOfRareMonsters.Count());
            var generatedMonster = listOfRareMonsters[random];

            Console.WriteLine(generatedMonster.Describe());
            Console.WriteLine("[Press enter to continue]");
            Console.ReadLine();

            game.BattleMode(user, generatedMonster);

            if(user.HealthPoints > 0)
            {
                Console.WriteLine("You return to the village to talk to the villager and to tell him what happened");
                Console.WriteLine();
                Loading();
                Console.WriteLine();
                Console.WriteLine($"{user.Name}: \"There seems to have been a {generatedMonster.Name} guarding the mine, they must've died.\"");
                Console.WriteLine($"Villager: \"I guessed as much, thank you for telling me.. almost forgot! Here's {gold} gold for your troubles\"");

                user.GetGold(gold);
                Console.WriteLine($"You now have {user.Gold} gold!");
                Console.WriteLine("[Press enter to continue]");
                Console.ReadLine();
            }
            
            return false;
        }
        private void Loading()
        {
            Console.WriteLine();
            Console.Write("Loading");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write(".");
            Console.WriteLine();
        }
        private void GenerateRareMonsters()
        {
            listOfRareMonsters = new List<Monster>
            {
                new Rare("Ice troll", 140, 140, 60, 15, "limping","hunched over", 100),
                new Rare("Efreti", 140, 140, 60, 15, "fast","fiery red", 100),
                new Rare("Ghoul", 140, 140, 60, 15, "quickly","nightmare looking", 100)
            };
        }
    }
}
