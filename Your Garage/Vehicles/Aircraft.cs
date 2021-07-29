using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Your_Garage;

namespace Your_Garage.Vehicles
{
    class Aircraft : Vehicle
    {
        public double FuelCapacity { get; set; }

        double _fuelOnBoard;
        bool _isFlying;
        int _passengers;

        public Aircraft(string make, string model, string year, VehicleColor color,  double fuelCapacity, int seats)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            FuelCapacity = fuelCapacity;
            Seats = seats;
            _isFlying = false;
            _fuelOnBoard = 0;
        }

        public override bool ReFuel(double gallons)
        {
            bool returnVal = false;
            if (gallons <= FuelCapacity && gallons > 0)
            {
                _fuelOnBoard = gallons;
                returnVal = true;
            }

            else
            {
                Console.WriteLine($"               Invalid number of liters.");
            }
            return returnVal;
        }

        public bool Fly(float miles, int passengers)
        {
            bool returnVal = false;
            if (passengers > 0 && passengers <= Seats)
            {
                _passengers = passengers;
                double fuelNeeded = miles / 12.3;
                if (_fuelOnBoard < fuelNeeded)
                {
                    Console.WriteLine("               You need to add more fuel before starting this flight");
                }
                else
                {
                    Console.WriteLine($"               The {Make} {Model} is flying {miles} miles.");
                    _isFlying = true;
                    returnVal = true;
                }
            } else
            {
                Console.Write($"               Invalid number of passengers. Maximum capacity is {Seats}.");
            }
            return returnVal;
        }
        public bool Land(bool message)
        {
            bool returnVal = false;
            if (_isFlying)
            {
                returnVal = true;
                _passengers = 0;
            }
            else
            {
                if (message == true)
                {
                    Console.Write("               You must be flying before you can land");
                }
                returnVal = false;
            }
            return returnVal;
        }
    }
}
