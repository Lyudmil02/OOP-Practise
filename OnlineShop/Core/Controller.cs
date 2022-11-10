using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IPeripheral> peripherals;
        private readonly List<IComponent> components;

        public Controller()
        {
            computers = new List<IComputer>();
            peripherals = new List<IPeripheral>();
            components = new List<IComponent>();
        }

        public string AddComponent
            (int computerId, int id, string componentType, string manufacturer,
            string model, decimal price, double overallPerformance, int generation)
        {
            DoesComputerExist(computerId);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent component = null;
            if (ComponentType.CentralProcessingUnit.ToString() == componentType)
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (ComponentType.Motherboard.ToString() == componentType)
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (ComponentType.PowerSupply.ToString() == componentType)
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (ComponentType.RandomAccessMemory.ToString() == componentType)
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (ComponentType.SolidStateDrive.ToString() == componentType)
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (ComponentType.VideoCard.ToString() == componentType)
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            computer.AddComponent(component);
            components.Add(component);
            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer
            (string computerType, int id, string manufacturer,
            string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                var excMsg = ExceptionMessages.ExistingComputerId;
                throw new ArgumentException(excMsg);
            }
            IComputer computer = null;
            if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral
            (int computerId, int id, string peripheralType, string manufacturer,
            string model, decimal price, double overallPerformance, string connectionType)
        {
            DoesComputerExist(computerId);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IPeripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var topComputer = computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();

            if (topComputer == null)
            {
                var excMsg = String.Format(ExceptionMessages.CanNotBuyComputer, budget);
                throw new ArgumentException(excMsg);
            }
            computers.Remove(topComputer);
            return topComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            DoesComputerExist(id);

            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            DoesComputerExist(id);
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            DoesComputerExist(computerId);

            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            var component = components.FirstOrDefault(x => x.GetType().Name == componentType);

            computer.RemoveComponent(componentType);
            components.Remove(component);
            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            DoesComputerExist(computerId);

            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            var peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private void DoesComputerExist(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
