using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.Mobs
{
    class Mountain : Monster
    {
        public string Movement { get; }
        public string Appearence { get; }

        public Mountain(string name, int healthPoints, int maxHealthPoints, int experiencePoints, int damage, string movement, string appearence, int gold) : base(name, healthPoints, maxHealthPoints, experiencePoints, damage, gold)
        {
            Movement = movement;
            Appearence = appearence;
        }

        public override string Describe()
        {
            return $"A {Name} comes barreling towards you! The creature {Movement} and {Appearence}!";
        }
    }
}
