using System;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carLine = Console.ReadLine().Split();
            string[] truckLine = Console.ReadLine().Split();
            string[] busLine = Console.ReadLine().Split();

            Vehicle car = ConsoleFill(carLine);
            Vehicle truck = ConsoleFill(truckLine);
            Vehicle bus = ConsoleFill(busLine);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string command = line[0];
                string type = line[1];
                double value = double.Parse(line[2]);
                if (command == "DriveEmpty")
                {
                    try
                    {
                        ((Bus)bus).TurnOff();
                        bus.Drive(value);
                        Console.WriteLine($"{type} travelled {value} km");

                    }
                    catch (Exception e )
                    {
                        Console.WriteLine(e.Message);
                    }
                   
                }
                else if (command == "Drive")
                {
                    try
                    {
                        if (type == nameof(Car))
                        {
                            car.Drive(value);

                        }
                        else if (type == nameof(Truck))
                        {
                            truck.Drive(value);

                        }
                        else if (type == nameof(Bus))
                        {

                            ((Bus)bus).TurnOn();
                            bus.Drive(value);
                            ((Bus)bus).TurnOff();

                        }
                        Console.WriteLine($"{type} travelled {value} km");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                else if (command == "Refuel")
                {
                    try
                    {
                        if (type == nameof(Car))
                        {
                            car.Refueled(value);

                        }
                        else if (type == nameof(Truck))
                        {
                            truck.Refueled(value);

                        }
                        else if (type == nameof(Bus))
                        {
                            bus.Refueled(value);

                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private static Vehicle ConsoleFill(string[] line)
        {
            Vehicle vehicle = null;
            string type = line[0];
            double fuelQuantity = double.Parse(line[1]);
            double fuelConsumption = double.Parse(line[2]);
            double fuelTank = double.Parse(line[3]);
            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, fuelTank);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, fuelTank);
            }
            else if (type == nameof(Bus))
            {

                vehicle = new Bus(fuelQuantity, fuelConsumption, fuelTank);

            }
            return vehicle;
        }
    }
}
