namespace ShoppingCart.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}