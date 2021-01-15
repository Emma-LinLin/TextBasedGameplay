using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.ShopInformation
{
    class Item
    {
        public string Name { get; }
        public int Price { get; }
        public int Gold { get; set; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public virtual string Describe()
        {
            return $"Item: {Name}\nPrice: {Price}";
        }

        public int GetGold(int gold)
        {
            Gold += gold;
            return Gold;
        }

    }
}
