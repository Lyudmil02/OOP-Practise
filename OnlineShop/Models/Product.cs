using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Models.Products;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => id;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }
                id = value;
            }
        }

        public string Manufacturer
        {
            get => manufacturer;

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }
                manufacturer = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                model = value;
            }
        }

        public virtual decimal Price
        {
            get => price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => overallPerformance;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return String.Format
                (SuccessMessages.ProductToString, $"{OverallPerformance:F2}",
                $"{Price:F2}", GetType().Name, Manufacturer, Model, Id);
        }
    }
}
