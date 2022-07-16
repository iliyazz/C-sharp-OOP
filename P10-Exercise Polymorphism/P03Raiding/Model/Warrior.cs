namespace P03Raiding.Model
{
    using Global;
    using Enum;

    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = (int)HeroPower.Warror;
        }
        public override int Power
        {
            get
            {
                return base.Power;
            }
            protected set
            {
                base.Power = value;
            }
        }
        public override string CastAbility()
        {
            return string.Format(Constants.StringOvverideRogueAndWarrior, GetType().Name, Name, Power);
        }
    }
}
