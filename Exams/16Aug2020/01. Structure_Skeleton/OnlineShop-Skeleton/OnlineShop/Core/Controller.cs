using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component = null;
            ComputerExist(computerId);
            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);

            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            var comp = computers.FirstOrDefault(x => x.Id == computerId);
            comp.AddComponent(component);
            components.Add(component);
            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {

            IComputer computer = null;
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);

            }
            if (computerType != "Laptop" && computerType != "DesktopComputer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            
            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);

            }
            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral = null;
            ComputerExist(computerId);
            if (peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
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
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            var comp = computers.FirstOrDefault(x => x.Id == computerId);
            comp.AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers.OrderByDescending(x => x.OverallPerformance).Where(x => x.Price <= budget).FirstOrDefault();
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(computer);
            return computer.ToString();

        }

        public string BuyComputer(int id)
        {
            ComputerExist(id);

            IComputer comp = computers.FirstOrDefault(x => x.Id == id);
            computers.Remove(comp);
            return comp.ToString();
        }

        public string GetComputerData(int id)
        {
            ComputerExist(id);

            IComputer comp = computers.FirstOrDefault(x => x.Id == id);
            return comp.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            ComputerExist(computerId);

            IComputer comp = computers.FirstOrDefault(x => x.Id == computerId);
            var component = comp.RemoveComponent(componentType);
            components.Remove(component);
            return string.Format(SuccessMessages.RemovedComponent, component.GetType().Name, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ComputerExist(computerId);

            IComputer comp = computers.FirstOrDefault(x => x.Id == computerId);
            var per = comp.RemovePeripheral(peripheralType);
            peripherals.Remove(per);
            return string.Format(SuccessMessages.RemovedPeripheral, per.GetType().Name, per.Id);
        }
        private void ComputerExist(int id)
        {
            if (!computers.Any(x=>x.Id==id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
