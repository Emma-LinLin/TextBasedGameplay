using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.ShopInformation
{
    class DefenseAmulet : Item
    {
        public int Armour { get; }
        public DefenseAmulet(string name, int price, int armour) : base(name, price)
        {
            Armour = armour;
        }
        public override string Describe()
        {
            return $"{Name} - Costs: {Price} gold\nArmour: +{Armour}";
        }
    }
}
