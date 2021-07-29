using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Your_Garage.Vehicles
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public int Mileage { get; set; }
        public double Mpg { get; set; }
        public bool IsElectric;
        
        double _operationCost;
        double _kwhMile;
        double _costKWH;

        public Car ( string year, string make, string model, bool isElectric)
        {
            Make = make;
            Model = model;
            Year = year;
            Mileage = 0;
            IsElectric = isElectric;
            _operationCost = 0;
            _kwhMile = 0;
            _costKWH = 0;
        }

        public Car ( string year, string make, string model, bool isElectric, int mileage) : this(year, make, model, isElectric)
        {
            Mileage = mileage;
        }
        public Car ( string year, string make, string model, bool isElectric, int mileage, double mpg) : this(year, make, model, isElectric, mileage)
            
        {
            Mpg = mpg;
        }

        public void Drive(int miles)
        {
            if (IsElectric && (_kwhMile > 0 && _costKWH > 0))
            {
                Console.WriteLine($"               Driving the {Make} {miles} miles.\n");
                Mileage += miles;
                _operationCost += miles * _kwhMile * _costKWH;
            }
            else
            {
                Console.WriteLine("Enter the mpg for this vehicle");
            }
        }
        public void Drive(int miles, double costPerUnit)
        {
            if (!IsElectric)
            {
                Console.WriteLine($"               Driving the {Make} {miles} miles.\n");
                Mileage += miles;
                _operationCost += (miles / Mpg) * costPerUnit;
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

        public void Status()
        {
            string output = $"               {Year } {Make} {Model}\n" +
                            $"               Mileage: {Mileage}\n" +
                            $"               Total Operating Cost: ${_operationCost,0:F2}\n";

            Console.WriteLine(output);
        }
    }
}
