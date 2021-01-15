using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.ShopInformation
{
    class Weapons : Items
    {
        public int Damage { get; }
        public Weapons(string name, int price, int damage): base(name, price)
        {
            Damage = damage;
        }
        public override string Describe()
        {
            return $"Weapon: {Name} - Costs: {Price} gold\nDamage: +{Damage}";
        }
    }
}
