using System;
using System.Collections.Generic;
using Your_Garage.Vehicles;

namespace Your_Garage
{

    class Program
    {
        static void runAircraft()
        {
            List<Aircraft> aircraftList = new List<Aircraft>();

            Console.WriteLine("Hello World!");
            Aircraft cessna150 = new Aircraft("Cessna", "150 Aerobat", "1985", VehicleColor.Red, 26.0, 2);
            cessna150.ReFuel(25.1);
            Aircraft cessnaSkyHawk = new Aircraft("Cessna", "Skyhawk", "2020", VehicleColor.Blue, 53.0, 4);
            cessnaSkyHawk.ReFuel(48.0);
            Aircraft cessnaSkyLane = new Aircraft("Cessna", "SkyLane", "2020", VehicleColor.Blue, 87.0, 4);
            cessnaSkyLane.ReFuel(81);
            aircraftList.Add(cessna150);
            aircraftList.Add(cessnaSkyHawk);
            aircraftList.Add(cessnaSkyLane);

            Random random = new Random();

            foreach(var aircraft in aircraftList)
            {
                aircraft.Fly(random.Next(10, 250), 2);
            }

        }

        static void runCars(){
            List<Car> carList = new List<Car>();

            Car bmwe30 = new Car("1987", "BMW", "325iS", false, 12.8);
            bmwe30.ReFuel(9.0);
            carList.Add(bmwe30);
            Car focus = new Car("2013", "Ford", "Focus Electric", true, 0, 44000, 0, 76);
            focus.ReFuel(88);
            focus.SetElectricCost(.31, .11);
            carList.Add(focus);

            Random random = new Random();

            foreach (var carItem in carList)
            {
                if (carItem.IsElectric)
                {
                    carItem.Drive(random.Next(10, 200));
                }
                else
                {
                    carItem.Drive(random.Next(10, 200), 3.56);
                }
            }
        }
        static void Main(string[] args)
        {
            runAircraft();
            runCars();
        }
    }
}
