namespace WarCroft.Entities.Items
{
    using Characters.Contracts;

    public class HealthPotion : Item
    {
        public HealthPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.Health += 20;
            base.AffectCharacter(character);
            //The character’s health gets decreased by 20 points. If the character’s health drops to zero, the character dies (IsAlive  false).
        }
    }
}
