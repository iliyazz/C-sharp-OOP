namespace P03Raiding.Model
{
    using Global;
    using Enum;
    
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = (int)HeroPower.Druide;
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
            return string.Format(Constants.StringOvverideDruidAndPaladin, GetType().Name, Name, Power);
        }
    }
}
