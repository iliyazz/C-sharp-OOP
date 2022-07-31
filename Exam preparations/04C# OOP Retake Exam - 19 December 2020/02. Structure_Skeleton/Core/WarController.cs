using System;

namespace WarCroft.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Constants;
    using Entities.Characters;
    using Entities.Characters.Contracts;
    using Entities.Items;

    public class WarController
	{
		private readonly List<Character> characters; 
		private readonly List<Item> items;

		public WarController()
		{
            this.characters = new List<Character>();
            this.items = new List<Item>();
		}

		public string JoinParty(string[] args)
        {
            string characterType = args[0];
			string name = args[1];
            Character character = null;
            if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
			else if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
			this.characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;
            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if(itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidItem, itemName));
            }
            this.items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (!items.Any()) 
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            Item item = this.items.LastOrDefault();
            this.items.Remove(item);
            character.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

		public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = this.characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
		{
            var sb = new StringBuilder();
            foreach (var item in characters
                         .OrderByDescending(x => x.IsAlive)
                         .ThenByDescending(x => x.Health))
            {
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, item.Name, item.Health, item.BaseHealth, item.Armor, item.BaseArmor, (item.IsAlive ? "Alive" : "Dead")));
            }
            return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
            string receiverName = args[1];
            Character attacker = this.characters.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (!(attacker is IAttacker))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            ((IAttacker)attacker).Attack(receiver);

            string result = string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);
            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + string.Format(SuccessMessages.AttackKillsCharacter, receiverName);
            }

            return result;
        }

        public string Heal(string[] args)
		{
			string healerName = args[0];
            string receiverName = args[1];
            Character healer = this.characters.FirstOrDefault(x => x.Name == healerName);
            Character receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (!(healer is IHealer))
            {
                throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healerName);
            }

            ((IHealer)healer).Heal(receiver); 
            return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
        }
	}
}
