namespace ShoppingCart.Entities
{
    public class PercentageOffDiscount : Discount
    {
        protected internal PercentageOffDiscount()
        {
        }

        public PercentageOffDiscount(string name, decimal discountPercentage)
            : base(name)
        {
            DiscountPercentage = discountPercentage;
        }

        public override OrderBase ApplyDiscount()
        {
            // custom processing
            foreach (LineItem lineItem in OrderBase.LineItems)
            {
                lineItem.DiscountAmount = lineItem.Product.Price * DiscountPercentage;
                lineItem.AddDiscount(this);
            }
            return OrderBase;
        }

        public virtual decimal DiscountPercentage { get; set; }
    }
}