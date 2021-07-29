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

        public Aircraft(string make, string model, VehicleColor color,  double fuelCapacity, int seats)
        {
            Make = make;
            Model = model;
            Color = color;
            FuelCapacity = fuelCapacity;
            Seats = seats;
            _isFlying = false;
            _fuelOnBoard = 0;
        }

        public override bool ReFuel(double liters)
        {
            bool returnVal = false;
            if (liters <= FuelCapacity && liters > 0)
            {
                _fuelOnBoard = liters;
                returnVal = true;
            }

            else
            {
                Console.WriteLine($"Invalid number of liters.");
            }
            return returnVal;
        }

        public bool Fly(float kilometers, int passengers)
        {
            bool returnVal = false;
            if (passengers > 0 && passengers <= Seats)
            {
                _passengers = passengers;
                _fuelOnBoard -= 3.4 * kilometers / 100 * passengers;
                if (_fuelOnBoard < 20)
                {
                    Console.WriteLine("You need to add more fuel before starting this flight");
                }
                else
                {
                    Console.WriteLine($"The {Make} {Model} is flying {kilometers} kilometers.");
                    _isFlying = true;
                    returnVal = true;
                }
            } else
            {
                Console.Write($"Invalid number of passengers. Maximum capacity is {Seats}.");
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
                    Console.Write("You must be flying before you can land");
                }
                returnVal = false;
            }
            return returnVal;
        }
    }
}
