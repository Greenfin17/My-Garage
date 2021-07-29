using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Your_Garage.Vehicles
{
    class Car : Vehicle
    {

        public int Mileage { get; set; }
        public double Mpg { get; set; }
        public double FuelCapacity;
        public bool IsElectric;
        
        double _operationCost;
        double _kwhMile;
        double _costKWH;
        double _percentCharge;
        int _range;
        double _fuelOnBoard;

        public Car ( string year, string make, string model, bool isElectric, double fuelCapacity)
        {
            Make = make;
            Model = model;
            Year = year;
            Mileage = 0;
            IsElectric = isElectric;
            if (IsElectric)
            {
                FuelCapacity = 0;
            }
            else
            {
                FuelCapacity = fuelCapacity;
            }
            _operationCost = 0;
            _kwhMile = 0;
            _costKWH = 0;
            _percentCharge = 0;
            _fuelOnBoard = 0;
        }

        public Car ( string year, string make, string model, bool isElectric, double fuelCapacity, int mileage) : this(year, make, model, isElectric, fuelCapacity)
        {
            Mileage = mileage;
        }
        public Car ( string year, string make, string model, bool isElectric, double fuelCapacity, int mileage, double mpg) : this(year, make, model, isElectric, fuelCapacity, mileage)
        {
            Mpg = mpg;
        }
        public Car ( string year, string make, string model, bool isElectric, double fuelCapacity, int mileage, double mpg, int range) : this(year, make, model, isElectric, fuelCapacity, mileage, mpg)
        {
            _range = range;
        }

        // Electric version of Drive
        public void Drive(int miles)
        {
            if (IsElectric && (_kwhMile > 0 && _costKWH > 0)) 
            {
                Console.WriteLine($"               Attempting to drive the {Make} {miles} miles.\n");
                if (_percentCharge > 10 && miles < _percentCharge / 100 * _range)
                {
                    Console.WriteLine($"               Driving the {Make} {miles} miles.\n");
                    Mileage += miles;
                    _operationCost += miles * _kwhMile * _costKWH;
                } else if (miles > _range)
                {
                    Console.WriteLine($"Miles exceeds vehicle range. Charge your car.");
                } else
                {
                    Console.WriteLine($"You need to charge the vehicle for this trip");
                }
            
            }
            else
            {
                Console.WriteLine("Enter the mpg for this vehicle as the second parameter.");
            }
        }
        // ICE version of Drive, enter the cost / gallon
        public void Drive(int miles, double costPerGallon)
        {
            if (!IsElectric)
            {
                Console.WriteLine($"               Driving the {Make} {miles} miles.\n");
                Mileage += miles;
                _operationCost += (miles / Mpg) * costPerGallon;
            } else
            {
                Console.WriteLine("Enter the miles driven only for this vehicle");
            }
        }
        public void Repair(double cost)
        {
            Console.WriteLine($"               Reparing the {Make}");
            Console.WriteLine($"               This repair cost {cost,5:F2}\n");
            _operationCost += cost;
        }

        public void SetElectricCost(double kwhMile, double costKwh)
        {
            Console.WriteLine($"               The {Make} uses {kwhMile} killowatts / mile");
            Console.WriteLine($"               The cost per mile is ${costKwh * kwhMile}.");
            _kwhMile = kwhMile;
            _costKWH = costKwh;
        }

        public override bool ReFuel(double amount)
        {
            bool returnVal = false;
            if(!IsElectric)
            { 
                if (amount > 0 && amount <= FuelCapacity)
                {
                    _fuelOnBoard += amount;
                    Console.WriteLine($"               Adding {amount} gallons of fuel");
                    returnVal = true;
                }
            }
            else if (amount > 0)
            {
                _percentCharge += amount;
                if (_percentCharge > 100)
                {
                    _percentCharge = 100;
                    returnVal = true;
                }
                Console.WriteLine($"               The {Make} {Model} is at {_percentCharge}% charge.");
            }
            return returnVal;

        }

        public void Status()
        {
            string output = $"               {Year } {Make} {Model}\n" +
                            $"               Mileage: {Mileage}\n" +
                            $"               Total Operating Cost: ${_operationCost,0:F2}\n";

            Console.WriteLine(output);
        }
    }
}
