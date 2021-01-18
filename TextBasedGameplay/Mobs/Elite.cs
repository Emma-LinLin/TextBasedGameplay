using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.Mobs
{
    class Elite : Monster
    {
        public string Movement { get; }
        public string Appearence { get; }

        public Elite(string name, int healthPoints, int maxHealthPoints, int experiencePoints, int damage, string movement, string appearence, int gold) : base(name, healthPoints, maxHealthPoints, experiencePoints, damage, gold)
        {
            Movement = movement;
            Appearence = appearence;
        }

        public override string Describe()
        {
            return $"*ELITE* It's a {Name}! The {Appearence} creature moves {Movement} towards you! Get ready!";
        }
    }
}
