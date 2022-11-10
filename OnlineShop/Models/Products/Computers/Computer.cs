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
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        private decimal price;

        public Computer
            (int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
            this.price = price;
        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (Components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + Components.Average(x => x.OverallPerformance);
            }
        }

        public override decimal Price
        {
            get
            {
                return price + Components.Sum(x => x.Price) + Peripherals.Sum(x => x.Price);
            }
        }

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                var excMsg = String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, GetType().Name, Id);
                throw new ArgumentException(excMsg);
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                var excMsg = String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id);
                throw new ArgumentException(excMsg);
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (components.Count == 0 || component == null)
            {
                var excMsg = String.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id);
                throw new ArgumentException(excMsg);
            }
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripherals.Count == 0 || peripheral == null)
            {
                var excMsg = String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id);
                throw new ArgumentException(excMsg);
            }
            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(" " + String.Format(SuccessMessages.ComputerComponentsToString, Components.Count));
            foreach (var item in components)
            {
                sb.AppendLine("  " + item);
            }
            if (Peripherals.Count != 0)
            {
                sb.AppendLine(" " + String.Format(SuccessMessages.ComputerPeripheralsToString, peripherals.Count, $"{peripherals.Average(x => x.OverallPerformance):F2}"));
                foreach (var item in peripherals)
                {
                    sb.AppendLine("  " + item);
                }
            }
            else
            {
                sb.AppendLine(" " + String.Format(SuccessMessages.ComputerPeripheralsToString, Peripherals.Count, $"{0:0.00}"));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
