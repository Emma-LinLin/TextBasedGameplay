﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.Mobs
{
    class Water : Monster
    {
        public string Sound { get; }
        public string Habitat { get; }

        public Water(string name, int healthPoints, int maxHealthPoints, int experiencePoints, int damage, string sound, string habitat, int gold) : base(name, healthPoints, maxHealthPoints, experiencePoints, damage, gold)
        {
            Sound = sound;
            Habitat = habitat;
        }

        public override string Describe()
        {
            return $"A {Name} emerges from the {Habitat}! Making the most terrifying sound {Sound}. It's heading your way!";
        }
    }
}
