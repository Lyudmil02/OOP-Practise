namespace OnlineShop.Models.Products
{
    public interface IProduct
    {
        public int Id { get; }

        public string Manufacturer { get; }

        public string Model { get; }

        public decimal Price { get; }

        public double OverallPerformance { get; }

    }
}
