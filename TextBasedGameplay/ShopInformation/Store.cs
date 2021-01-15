using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.ShopInformation
{
    class Store
    {
        public void Run()
        {
            //GenerateItems();
            WelcomeScreen();
        }
        public void WelcomeScreen()
        {
            Console.WriteLine("Welcome warrior! Ye're not from around here are ya'? \n-Ahem, guessing that's none of my concern");

            bool keepReapeating = true;

            while (keepReapeating)
            {
                Console.WriteLine();
                Console.WriteLine("What can I do for ya'?");
                Console.WriteLine("1. Let me browse your goods");
                Console.WriteLine("2. Good bye");

                int userInput = ParseUserInput();

                switch (userInput)
                {
                    case 1:
                        break;
                    case 2:
                        Console.WriteLine("Have a good one!");
                        keepReapeating = false;
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
                    Console.WriteLine("I can't help you with that");
                }

            }
        }
        public void GenerateItems()
        {

        }
    }
}
