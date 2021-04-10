using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public override double OverallPerformance
        {
            get
            {
                if (components.Count==0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + components.Average(c => c.OverallPerformance);
            }
        }
        public override decimal Price
        {
            get
            {
                return base.Price + components.Sum(c => c.Price) + peripherals.Sum(x => x.Price);
            }
        }
        public IReadOnlyCollection<IComponent> Components => this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (components.Any(x=>x.GetType().Name==component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component == null || components.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral==null||peripherals.Count==0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            peripherals.Remove(peripheral);
            return peripheral;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(String.Format(SuccessMessages.ComputerComponentsToString, this.components.Count));
            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            double value = 0;
            if (this.peripherals.Any())
            {
                value = this.peripherals.Average(x => x.OverallPerformance);

            }
            else
            {
                value = 0;
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({value:f2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
