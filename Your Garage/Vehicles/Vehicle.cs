using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Your_Garage.Vehicles
{
    abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public VehicleColor Color { get; set; }
        public int Seats { get; set; }
        public abstract bool ReFuel(double amount);


    }
}
