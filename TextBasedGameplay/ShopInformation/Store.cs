﻿using System;
using System.Collections.Generic;
using System.Text;
using TextBasedGameplay.Interface;
using TextBasedGameplay.UserInformation;

namespace TextBasedGameplay.ShopInformation
{
    class Store
    {
        private static List<Item> listOfItems = new List<Item>();
        private Player user;
        /// <summary>
        /// Runs the in game Store sequence where you can buy goods to update User damage, armour etc.
        /// </summary>
        public void Run(Player User)
        {
            user = User;

            GenerateItems();
            WelcomeScreen();
        }
        private void WelcomeScreen()
        {
            Console.WriteLine("Merchant: \"Welcome warrior! Ye're not from around here are ya'? \n-Ahem, guessing that's none of my concern\"");
            StoreMeny();
        }
        /// <summary>
        /// Will keep repeating until the user decides to quit.
        /// </summary>
        private void StoreMeny()
        {
            bool keepReapeating = true;

            while (keepReapeating)
            {
                Console.WriteLine();
                Console.WriteLine("Merchant: \"What can I do for ya'?\"");
                Console.WriteLine("1. Let me browse your goods");
                Console.WriteLine("2. Can you craft something for me?");
                Console.WriteLine("3. Good bye");

                int userInput = ParseUserInput();

                switch (userInput)
                {
                    case 1:
                        BrowseGoods();
                        break;
                    case 2:
                        CraftItem();
                        break;
                    case 3:
                        Console.WriteLine("Merchant: \"Have a good one!\"");
                        keepReapeating = false;
                        break;
                    default:
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
                    Console.WriteLine("Merchant: \"Can't really help you with that, mate. Just pick a number!\"");
                }

            }
        }
        /// <summary>
        /// Shows all items in listOfItems being able to choose if wanting to make a purchase or not. 
        /// </summary>
        private void BrowseGoods()
        {
            int index = 0;

            foreach(var item in listOfItems)
            {
                Console.WriteLine();
                Console.WriteLine($"{index + 1}.{item.Describe()}");
                Console.WriteLine("-----------------------------------");
                index++;
            }
            Console.WriteLine();
            Console.WriteLine("Merchant: \"Somethin' ya find interesting?\"");
            Console.WriteLine();
            Console.WriteLine($"You're checking your pocket, you currently have {user.Gold} gold.");
            Console.WriteLine("[Enter [Yes] to purchase, enter [No] to quit]");
            string userChoice = Console.ReadLine().Trim().ToLower();

            switch (userChoice)
            {
                case "yes":
                    PurchaseItem();
                    break;
                case "no":
                    Console.WriteLine();
                    Console.WriteLine("Merchant: \"Your loss lad!\"");
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }
        }
        /// <summary>
        /// Asks user to select which item they would like to buy. If user don't have enough gold they wont be able to purchase.
        /// </summary>
        private void PurchaseItem()
        {
            Console.WriteLine("Merchant: \"Great! Which one would ya' like? Pick a number!\"");
            int index = ParseUserInput();
            index -= 1;

            Item selectedItem = listOfItems[index];

            if(user.Gold < selectedItem.Price)
            {
                Console.WriteLine("Merchant: \"Seems like ya' don't have enough coin, lad.\"");
            }
            else
            {
                user.GiveGold(selectedItem.Price);
                Console.WriteLine($"You bought the {selectedItem.Name}!");
                Console.WriteLine($"You now have {user.Gold} gold.");

                Equip(selectedItem);
            }
        }
        /// <summary>
        /// When the selected item is bought, it's features(+damage, +armour) will be added to the users details.
        /// </summary>
        private void Equip(Item selectedItem)
        {
            if(selectedItem is Weapon)
            {
                user.EquipDamage = ((Weapon)selectedItem).Damage;
            }
            else if (selectedItem is Gear)
            {
                user.EquipArmour = ((Gear)selectedItem).Armour;
            }
            else if(selectedItem is StrengthAmulet)
            {
                user.EquipDamage = ((StrengthAmulet)selectedItem).Damage;
            }
            else if(selectedItem is DefenseAmulet)
            {
                user.EquipArmour = ((DefenseAmulet)selectedItem).Armour;
            }
            else if(selectedItem is Potion) 
            {
                user.HealthPoints = user.MaxHealthPoints;
            }
            //CheapPotion is 50/50 when using. If the users health points is below 50% of max health, the potion will add 50% of max to the users health points.
            //If the users health points is more than 50% of max, it will drain health points to be exactly 50% of max. 
            else if(selectedItem is CheapPotion)
            {
                int healthPoints = user.MaxHealthPoints / 2;

                if(user.HealthPoints > healthPoints)
                {
                    user.HealthPoints = healthPoints;
                    Console.WriteLine($"You drank the potion, you now have {user.HealthPoints}/{user.MaxHealthPoints}!?");
                    Console.WriteLine();
                    Console.WriteLine("Merchant: \"Hahaha, ya' get what ya' pay for lad! The nearest herbalist is an old drunk!\"");
                    Console.WriteLine();
                }
                else
                {
                    user.HealthPoints += healthPoints;
                    Console.WriteLine($"You dank the potion, you now have {user.HealthPoints}/{user.MaxHealthPoints}!");
                }
            }
        }
        /// <summary>
        /// Dialogue between User and Merchant
        /// </summary>
        private void CraftItem()
        {
            Console.WriteLine("Merchant: \"Ay, I do some blacksmithin'. What did ya' have in mind?\"");
            Console.WriteLine("1. I need some armour");
            Console.WriteLine("2. I need a weapon");

            int userChoice = ParseUserInput();

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("A warriors chestplate - Costs: An absurd amount of gold");
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine("Armour: 100\nStamina: 86\nBlock: 78%\nBlinding enemy: 100%, too much bling");
                    Console.WriteLine("[Press enter to continue]");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Ancient sword of Giants - Costs: An absurd amount of gold");
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine("Damage: 1000\nFire Damage: 86%\nPiercing Damage: 78%\nAmaze enemy: 100%, it's gigantic");
                    Console.WriteLine("[Press enter to continue]");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Can't do that mate.");
                    break;
            }

            Console.WriteLine($"You dont have that amount of gold, you currently have {user.Gold} gold");
            Console.WriteLine("Merchant: \"Sod off!\"");

        }
        /// <summary>
        /// Method generates all items and adds them to listOfItems.
        /// </summary>
        private void GenerateItems()
        {
            listOfItems = new List<Item>
            {
                new Weapon("Wooden Sword", 150, 2),
                new Weapon("BlingBling Axe", 300, 10),
                new Weapon("Not'that'Amazing Sword", 200, 5),
                new Gear("Leather Helmet", 150, 4),
                new Gear("Sparkling Chestplate", 300, 10),
                new DefenseAmulet("Defense Amulet", 100, 2),
                new DefenseAmulet("Advanced Defense Amulet", 200, 5),
                new StrengthAmulet("Strength Amulet", 100, 2),
                new StrengthAmulet("Advanced Strength Amulet", 200, 5),
                new Potion("Health potion", 100, 100),
                new CheapPotion("Sketchy health potion", 30, 50)
            };
        }
    }
}
