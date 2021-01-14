using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.Mobs
{
    class Swamp : Monster
    {
        public string Sound { get; }
        public string Habitat { get; }

        public Swamp(string name, int healthPoints, int experiencePoints, int damage, string sound, string habitat) : base (name, healthPoints, experiencePoints, damage)
        {
            Sound = sound;
            Habitat = habitat;
        }

        public override string Describe()
        {
            return $"A {Name} appeared! It crawls out of the {Habitat} and roars {Sound}... it charges";
        }
    }
}
