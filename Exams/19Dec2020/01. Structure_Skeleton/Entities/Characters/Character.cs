using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double health;
        private double armor;
        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }
        public bool IsAlive { get; set; } = true;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }
        public double BaseHealth { get; private set; }
        public double Health
        {
            get => this.health;
            set
            {
                if (value > 0 && value <= this.BaseHealth)
                {

                    this.health = value;
                }
            }
        }
        public double BaseArmor { get; private set; }
        public double AbilityPoints { get; private set; }
        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value > 0)
                {

                    this.armor = value;
                }
            }
        }
        public IBag Bag { get; private set; }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            if (this.armor >= hitPoints)
            {
                armor -= hitPoints;
            }
            else if (this.armor < hitPoints)
            {
                hitPoints -= armor;
                armor = 0;
                if (this.health > hitPoints)
                {
                    health -= hitPoints;
                }
                else
                {
                    IsAlive = false;
                    this.health = 0;
                }
            }
        }
        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);

        }
    }
}