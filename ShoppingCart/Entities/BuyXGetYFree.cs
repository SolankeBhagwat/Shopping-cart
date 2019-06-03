using System.Collections.Generic;

namespace ShoppingCart.Entities
{
    public class BuyXGetYFree : Discount
    {
        protected internal BuyXGetYFree()
        {
        }

        public BuyXGetYFree(string name, IList<Product> applicableProducts, int x, int y)
            : base(name)
        {
            ApplicableProducts = applicableProducts;
            X = x;
            Y = y;
        }

        public override OrderBase ApplyDiscount()
        {
            foreach (LineItem lineItem in OrderBase.LineItems)
            {
                if (ApplicableProducts.Contains(lineItem.Product) && lineItem.Quantity > X)
                {
                    lineItem.DiscountAmount += ((lineItem.Quantity / X) * Y) * lineItem.Product.Price;
                    lineItem.AddDiscount(this);
                }
            }
            return OrderBase;
        }

        public virtual IList<Product> ApplicableProducts { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
    }
}