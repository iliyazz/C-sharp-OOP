﻿namespace WarCroft.Entities.Items
{
    using Characters.Contracts;

    public class FirePotion : Item
    {
        public  FirePotion()
            :base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;
        }
    }
}
