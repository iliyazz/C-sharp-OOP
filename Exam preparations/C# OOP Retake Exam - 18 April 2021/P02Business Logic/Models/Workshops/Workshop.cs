namespace Easter.Models.Workshops
{
    using System.Linq;
    using Bunnies.Contracts;
    using Contracts;
    using Dyes;
    using Dyes.Contracts;
    using Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {
            
        }
        public void Color(IEgg egg, IBunny bunny)
        {
            while ((bunny.Energy > 0) && (bunny.Dyes.Count > 0) && (!egg.IsDone()))
            {
                IDye dye = bunny.Dyes.First();
                bunny.Work();
                dye.Use();
                egg.GetColored();
                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                }
            }
        }
    }
}
