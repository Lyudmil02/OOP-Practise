using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant
{
    public class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams)
            :base(name, price, grams)
        {

        }
    }
}
