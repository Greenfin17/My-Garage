using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Your_Garage.Vehicles
{
    class Watercraft
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public double Horsepower { get; set; }
        public double FuelCapacity { get; set; }
        public int Seats { get; set; }
        public VehicleColor Color { get; set; }

        double _fuelOnBoard;

        public Watercraft(string make, string model, double fuelCapacity, double horsepower, int seats, VehicleColor color)
        {
            Make = make;
            Model = model;
            FuelCapacity = fuelCapacity;
            Horsepower = horsepower;
            Seats = seats;
            Color = color;
            _fuelOnBoard = 0;
        }

        public bool ReFuel(double gallons)
        {
            bool returnVal = false;
            if (gallons <= FuelCapacity && gallons > 0)
            {
                _fuelOnBoard = gallons;
                returnVal = true;
            }
            else
            {
                Console.WriteLine($"Invalid number of liters.");
            }
            return returnVal;
        }

        public bool Drive(float hours, int passengers)
        {
            bool returnVal = false;
            double fuelConsumption;
            if (passengers > 0 && passengers <= Seats)
            {
                fuelConsumption = Horsepower / 10 * hours;
                if (fuelConsumption > _fuelOnBoard + 5)
                {
                    Console.WriteLine("You need to add more fuel before starting this trip");
                }
                else
                {
                    Console.WriteLine($"The {Make} {Model} is traveling for {hours} hours.");
                    _fuelOnBoard -= fuelConsumption;
                    returnVal = true;
                }
            }
            else
            {
                Console.Write($"Invalid number of passengers. Maximum capacity is {Seats}.");
            }
            return returnVal;

        }
    }
}
