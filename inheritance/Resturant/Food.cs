﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams)
            :base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams { get; set; }

    }
}
