using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGameplay.UserInformation
{
    class Player
    {
        public string Name { get; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        public int ExperiencePoints { get; set; }
        public int MaxExperiencePoints { get; }
        public int Damage { get; set; }
        public int Gold { get; set; }
        public int Armour { get; set; }
        public int EquipDamage { get; set; }
        public int EquipArmour { get; set; }

        public Player()
        {

        }

        public Player(string name, int level, int healthPoints, int maxHealthPoints, int experiencePoints, int maxExperiencePoints, int damage, int armour, int gold, int equipDamage, int equipArmour)
        {
            Name = name;
            Level = level;
            HealthPoints = healthPoints;
            MaxHealthPoints = maxHealthPoints;
            ExperiencePoints = experiencePoints;
            MaxExperiencePoints = maxExperiencePoints;
            Damage = damage;
            Armour = armour;
            Gold = gold;
            EquipDamage = equipDamage;
            EquipArmour = equipArmour;
        }

        public string Describe()
        {
            return $"{Name} - lvl {Level}\nHealth points: {HealthPoints}/{MaxHealthPoints}\nExperience points: {ExperiencePoints}/{MaxExperiencePoints}\nDamage: {Damage}\nArmour: {Armour}\nGold: {Gold}\nEquipment: +{EquipDamage} damage, +{EquipArmour} armour";
        }

        public int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(-2, 2);

            damage += EquipDamage;

            return Damage + damage;
        }
        public int TakeDamage(int damage)
        {
            damage -= Armour + EquipArmour;

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
            Damage++;
            MaxHealthPoints += 10;
            HealthPoints = MaxHealthPoints;
            ExperiencePoints = 0;

            if(Level == 10)
            {
                Console.WriteLine($"Congratulations, you're now level {Level} you've won the game!");
            }
            else
            {
                Console.WriteLine($"Level up!\nYou're now level {Level}!\nYour Damage has increased to {Damage} and {HealthPoints}/{MaxHealthPoints} HP!");
            }
        }

        public int GetGold(int gold)
        {
            Gold += gold;
            return Gold;
        }

        public int GiveGold(int gold)
        {
            Gold -= gold;
            return Gold;
        }
    }
}
