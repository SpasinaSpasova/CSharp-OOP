using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Item> pool;
        private List<Character> party;
        public WarController()
        {
            pool = new List<Item>();
            party = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character = null;
            if (characterType != "Priest" && characterType != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            party.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            if (itemName != "HealthPotion" && itemName != "FirePotion")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));

            }
            Item item = null;
            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            pool.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            if (!party.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));

            }
            Character character = party.FirstOrDefault(x => x.Name == characterName);
            Item lastItem = pool[pool.Count - 1];
            character.Bag.AddItem(lastItem);
            pool.RemoveAt(pool.Count - 1);
            return string.Format(SuccessMessages.PickUpItem, characterName, lastItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = party.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            Item current = character.Bag.GetItem(itemName);
            character.UseItem(current);
            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            party = party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in party)
            {
                if (item.IsAlive)
                {
                    sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: Alive");
                }
                else
                {
                    sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: Dead");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            if (!party.Any(x=>x.Name==attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (!party.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            Character attacker = party.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);
            if (attacker.GetType().Name!="Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }
            Warrior attackerWarrior = (Warrior)attacker;
            attackerWarrior.Attack(receiver);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            if (!party.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (!party.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }
            Character healer = party.FirstOrDefault(x => x.Name == healerName);
            Character receiver = party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }
            Priest priest = (Priest)healer;
            priest.Heal(receiver);
            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
