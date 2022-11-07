using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;

        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption 
        {
            get
            {
                return DefaultFuelConsumption;
            }
        }

        public virtual void Drive(double kilometres)
        {
            this.Fuel -= kilometres * this.FuelConsumption;
        }
    }
}
