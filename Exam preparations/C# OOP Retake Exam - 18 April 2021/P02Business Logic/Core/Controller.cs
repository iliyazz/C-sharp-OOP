namespace Easter.Core
{
    using System;
    using Contracts;
    using Models.Bunnies;
    using Models.Bunnies.Contracts;
    using Models.Dyes;
    using Models.Dyes.Contracts;
    using Models.Eggs;
    using Models.Eggs.Contracts;
    using Repositories;
    using Utilities.Messages;
    using System.Linq;
    using System.Text;
    using Models.Workshops;
    using Models.Workshops.Contracts;

    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if(bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            Dye dye = new Dye(power);
            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);

        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var bunniesWithEnergyOver50 = bunnies.Models.Where(e => e.Energy >= 50).OrderByDescending(e => e.Energy).ToList();
            if (bunniesWithEnergyOver50.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = eggs.FindByName(eggName);
            IWorkshop workshop = new Workshop();

            foreach (var bunny in bunniesWithEnergyOver50)
            {
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            return egg.IsDone()
                    ? string.Format(OutputMessages.EggIsDone, eggName)
                    : string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Count(x => x.IsDone())} eggs are done!")
            .AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}")
                .AppendLine($"Energy: {bunny.Energy}")
                .AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
