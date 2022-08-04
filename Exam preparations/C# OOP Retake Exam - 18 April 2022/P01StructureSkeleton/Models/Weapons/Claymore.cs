namespace Heroes.Models.Weapons
{
    using Contracts;

    public class Claymore : Weapon, IWeapon
    {
        public Claymore(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}
