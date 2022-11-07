using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = 3.50m;

        private const double CoffeeMilliliters = 50;

        public Coffee(string name, double caffeine)
            :base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
