using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.Interface
{
    interface IDamage
    {
        public int Damage { get; set; }
        public int HealthPoints { get; set; }

        int Attack();
        int TakeDamage(int damage);
    }
}
