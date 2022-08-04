namespace Heroes.Models.Weapons
{
    using Contracts;

    public class Mace : Weapon, IWeapon
    {
        public Mace(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}
