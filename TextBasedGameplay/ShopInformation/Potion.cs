using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.ShopInformation
{
    class Potion : Item
    {
        public int HealthPoints { get; }
        public Potion(string name, int price, int healthPoints):base(name, price)
        {
            HealthPoints = healthPoints;
        }
        public override string Describe()
        {
            return $"{Name} - Costs: {Price} gold\n Heals: {HealthPoints}% of your max health";
        }
    }
}
