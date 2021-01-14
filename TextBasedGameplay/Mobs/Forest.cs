using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.Mobs
{
    class Forest : Monster
    {
        public string Movement { get; }
        public string Appearence { get; }

        public Forest(string name, int healthPoints, int experiencePoints, int damage, string movement, string appearence) : base (name, healthPoints, experiencePoints, damage)
        {
            Movement = movement;
            Appearence = appearence;
        }

        public override string Describe()
        {
            return $"A {Appearence} creature comes {Movement} towards you.. It's a {Name}! Get ready!";
        }
    }
}
