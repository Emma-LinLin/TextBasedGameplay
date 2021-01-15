using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.ShopInformation
{
    class StrengthAmulet : Item
    {
        public int Damage { get; }
        public StrengthAmulet(string name, int price, int damage) : base(name, price)
        {
            Damage = damage;
        }

        public override string Describe()
        {
            return $"{Name} - Costs: {Price} gold\nDamage: +{Damage}";
        }
    }
}
