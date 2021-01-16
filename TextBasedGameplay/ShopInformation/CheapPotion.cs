using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.ShopInformation
{
    class CheapPotion : Item
    {
        private int HealthPoints { get; }
        private CheapPotion(string name, int price, int healthPoints) : base(name, price)
        {
            HealthPoints = healthPoints;
        }
        public override string Describe()
        {
            return $"{Name} - Costs: {Price} gold\n Heals: {HealthPoints}% of your max health";
        }
    }
}
