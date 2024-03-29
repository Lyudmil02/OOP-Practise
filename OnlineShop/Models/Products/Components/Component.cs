﻿using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        protected Component
            (int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance,
            int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public int Generation { get; }

        public override string ToString()
        {
            return base.ToString()
                + String.Format(SuccessMessages.ComponentToString, Generation);
        }
    }
}
