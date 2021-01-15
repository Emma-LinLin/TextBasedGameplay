using System;
using System.Collections.Generic;
using System.Text;
using TextBasedGameplay.UserInformation;

namespace TextBasedGameplay.ShopInformation
{
    class Store
    {
        static List<Item> listOfItems = new List<Item>();
        private Player user;
        public void Run(Player User)
        {
            user = User;

            GenerateItems();
            WelcomeScreen();
        }
        public void WelcomeScreen()
        {
            Console.WriteLine("Merchant: \"Welcome warrior! Ye're not from around here are ya'?\" \n\"-Ahem, guessing that's none of my concern\"");
            StoreMeny();
        }
        public void StoreMeny()
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
                    Console.WriteLine("Merchant: \"Can't really help you with that, mate. Just pick a number!\"");
                }

            }
        }
        public void BrowseGoods()
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
                    break;
                default:
                    break;
            }
        }
        public void PurchaseItem()
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
        public void Equip(Item selectedItem)
        {
            if(selectedItem is Weapon)
            {
                user.Damage = 10;
                user.Damage += ((Weapon)selectedItem).Damage;
            }
            else if(selectedItem is Gear)
            {
                user.Armour = 0;
                user.Armour += ((Gear)selectedItem).Armour;
            }
        }
        public void CraftItem()
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
                    Console.WriteLine("Damage: 1000\nFire Damage: 86%\nPiercing Damage: 78%\nAmaze enemy: 100%, can't even lift it");
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
        public void GenerateItems()
        {
            listOfItems = new List<Item>
            {
                new Weapon("Wooden Sword", 100, 2),
                new Weapon("Bling bling Axe", 200, 10),
                new Weapon("Mehhh Sword", 150, 5),
                new Gear("Leather Helmet", 150, 4),
                new Gear("Sparkling Chestplate", 200, 10)
            };
        }
    }
}
