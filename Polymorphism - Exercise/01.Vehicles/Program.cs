using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carLine = Console.ReadLine().Split();
            string[] truckLine = Console.ReadLine().Split();

            Vehicle car = ConsoleFill(carLine);
            Vehicle truck = ConsoleFill(truckLine);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string command = line[0];
                string type = line[1];
                double value = double.Parse(line[2]);

                if (command=="Drive")
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
                        Console.WriteLine($"{type} travelled {value} km");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    
                }
                else if (command== "Refuel")
                {
                    if (type == nameof(Car))
                    {
                        car.Refueled(value);

                    }
                    else if (type == nameof(Truck))
                    {
                        truck.Refueled(value);

                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }

        private static Vehicle ConsoleFill(string[] line)
        {
            Vehicle vehicle = null;
            string type = line[0];
            double fuelQuantity = double.Parse(line[1]);
            double fuelConsumption = double.Parse(line[2]);
            if (type==nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            return vehicle;
        }
    }
}
