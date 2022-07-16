namespace P03Raiding.Model
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;

        }
        public string Name { get; private set; }
        public virtual int Power { get; protected set; }
        public abstract string CastAbility();
        //{
        //    return null;
        //}


    }
}
