using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters)
            :base(name, price)
        {

        }

        public double Millilitres { get; set; }
    }
}
