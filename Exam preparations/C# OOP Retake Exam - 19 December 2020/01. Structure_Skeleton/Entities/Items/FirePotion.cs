namespace WarCroft.Entities.Items
{
    using System.Buffers.Text;
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
            //If the character’s health drops to zero, the character dies (IsAlive  false).
        }
    }
}
