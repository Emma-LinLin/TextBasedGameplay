using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.Mobs
{
    class Mountain : Monster
    {
        public string Movement { get; }
        public string Appearence { get; }

        public Mountain(string name, int healthPoints, int experiencePoints, int damage, string movement, string appearence) : base(name, healthPoints, experiencePoints, damage)
        {
            Movement = movement;
            Appearence = appearence;
        }

        public override string Describe()
        {
            return $"A {Name} comes barreling towards you! The creature {Movement} and charges!";
        }
    }
}
