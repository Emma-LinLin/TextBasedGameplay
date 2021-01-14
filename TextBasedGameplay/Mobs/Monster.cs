using System;
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
        public int Gold { get; set; }

        public Monster(string name, int healthPoints, int experiencePoints, int damage, int gold)
        {
            Name = name;
            HealthPoints = healthPoints;
            ExperiencePoints = experiencePoints;
            Damage = damage;
            Gold = gold;
        }

        public virtual string Describe()
        {
            return $"A random {Name} appeared!";
        }
        public int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(-2, 2);

            return Damage + damage;
        }
        public int TakeDamage(int damage)
        {
            HealthPoints -= damage;
            return HealthPoints;
        }
        public int GiveExperience()
        {
            Random rnd = new Random();
            int experiencePoints = rnd.Next(-5, 5);

            return ExperiencePoints + experiencePoints;
        }
        public int GiveGold()
        {
            Random rnd = new Random();
            int gold = rnd.Next(-5, 5);

            return Gold + gold;
        }
    }
}
