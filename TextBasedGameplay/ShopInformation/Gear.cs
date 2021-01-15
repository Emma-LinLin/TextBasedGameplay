using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.ShopInformation
{
    class Gear : Items
    {
        public int Armour { get; }
        public Gear(string name, int price, int armour): base(name, price)
        {
            Armour = armour;
        }
        public override string Describe()
        {
            return $"Gear: {Name} - Costs: {Price} gold\nArmour: +{Armour}";
        }
    }
}
