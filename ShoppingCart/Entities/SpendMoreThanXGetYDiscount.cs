using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class SpendMoreThanXGetYDiscount : Discount
    {
        protected internal SpendMoreThanXGetYDiscount()
        {
        }

        public SpendMoreThanXGetYDiscount(string name, decimal threshold, decimal discountPercentage)
            : base(name)
        {
            Threshold = threshold;
            DiscountPercentage = discountPercentage;
        }

        public override OrderBase ApplyDiscount()
        {
            // if the total for the cart/order is more than x apply discount
            if (OrderBase.GrossTotal > Threshold)
            {
                // custom processing
                foreach (LineItem lineItem in OrderBase.LineItems)
                {
                    lineItem.DiscountAmount += lineItem.Product.Price * DiscountPercentage;
                    lineItem.AddDiscount(this);
                }
            }
            return OrderBase;
        }

        public virtual decimal Threshold { get; set; }
        public virtual decimal DiscountPercentage { get; set; }
    }

}
