using System;
using System.Collections.Generic;
using System.Text;
using TextBasedGameplay.UserInformation;

namespace TextBasedGameplay.GameLogic
{
    class GamePlay
    {
        static Player User = new Player();

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

        }
        public void ViewPlayerDetails()
        {
            Console.WriteLine(User.Describe());
            Console.WriteLine("[Press enter to continue]");
            Console.ReadLine();
        }
    }
}
