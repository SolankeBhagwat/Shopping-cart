using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class LineItem : EntityBase
    {
        private IList<Discount> _Discounts = new List<Discount>();

        protected internal LineItem()
        {
        }

        public LineItem(OrderBase order, Product product, int quantity)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
        }

        public virtual void AddDiscount(Discount discount)
        {
            _Discounts.Add(discount);
        }

        public virtual OrderBase Order { get; private set; }
        public virtual Product Product { get; private set; }
        public virtual int Quantity { get; private set; }
        public virtual decimal DiscountAmount { get; set; }

        public virtual decimal Subtotal
        {
            get { return (Product.Price * Quantity) - DiscountAmount; }
        }

        public virtual IList<Discount> Discounts
        {
            get { return _Discounts.ToList().AsReadOnly(); }
        }
    }

}
