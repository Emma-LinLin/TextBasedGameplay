﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.Mobs
{
    class Monster
    {
        public string Name { get; }
        public int HealthPoints { get; set; }
        public int ExperiencePoints { get; set; }
        public int Damage { get; set; }

        public Monster(string name, int healthPoints, int experiencePoints, int damage)
        {
            Name = name;
            HealthPoints = healthPoints;
            ExperiencePoints = experiencePoints;
            Damage = damage;
        }

        public virtual string Describe()
        {
            return $"A random {Name} appeared!";
        }
    }
}
