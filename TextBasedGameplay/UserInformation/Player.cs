using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.UserInformation
{
    class Player
    {
        public string Name { get; }
        public int Level { get; set; }
        public int MaxLevel { get; }
        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; }
        public int ExperiencePoints { get; set; }
        public int MaxExperiencePoints { get; }
        public int Damage { get; set; }

        public int Gold { get; set; }

        public Player()
        {

        }

        public Player(string name, int level, int maxLevel, int healthPoints, int maxHealthPoints, int experiencePoints, int maxExperiencePoints, int damage, int gold)
        {
            Name = name;
            Level = level;
            MaxLevel = maxLevel;
            HealthPoints = healthPoints;
            MaxHealthPoints = maxHealthPoints;
            ExperiencePoints = experiencePoints;
            MaxExperiencePoints = maxExperiencePoints;
            Damage = damage;
            Gold = gold;
        }

        public string Describe()
        {
            return $"{Name} - lvl {Level}\nHealth points: {HealthPoints}/{MaxHealthPoints}\nExperience points: {ExperiencePoints}/{MaxExperiencePoints}\nDamage: {Damage}\nGold: {Gold}";
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

        public int GainExperience(int gainedPoints)
        {
            ExperiencePoints += gainedPoints;

            if(ExperiencePoints >= MaxExperiencePoints)
            {
                LevelUp();
            }
            return ExperiencePoints;

        }
        public void LevelUp()
        {
            Level++;
            HealthPoints = 200;
            ExperiencePoints = 0;

            Console.WriteLine($"Level up!\nYou're now level {Level} and have {HealthPoints} HP!");
        }

        public int GetGold(int gold)
        {
            Gold += gold;
            return Gold;
        }
    }
}
