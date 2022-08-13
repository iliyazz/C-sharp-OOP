namespace OnlineShop.Models.Products.Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common.Constants;
    using Components;
    using Peripherals;

    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;


        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override decimal Price => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                return  base.OverallPerformance + components.Average(x => x.OverallPerformance);
            }
        }

        public IReadOnlyCollection<IComponent> Components => components;
        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;
        public void AddComponent(IComponent component)
        {

            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,
                    GetType().Name, Id));
            }
            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.All(x => x.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, componentType,
                    GetType().Name, Id));
            }

            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(component);
            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.All(p => p.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    this.GetType().Name, this.Id));
            }

            var peripheral = peripherals.First(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
            .AppendLine($" Components ({components.Count}):");
            foreach (var component in Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }
            double peripheralOvPerf = peripherals.Count == 0 ? 0 : peripherals.Average(p => p.OverallPerformance);
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripheralOvPerf:f2}):");
            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
