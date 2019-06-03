using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Entities
{
    public abstract class OrderBase : EntityBase
    {
        private IList<LineItem> _LineItems = new List<LineItem>();
        private IList<Discount> _Discounts = new List<Discount>();

        protected internal OrderBase()
        {
        }

        protected OrderBase(Member member)
        {
            Member = member;
            DateCreated = DateTime.Now;
        }

        public virtual Member Member { get; set; }

        public LineItem AddLineItem(Product product, int quantity)
        {
            LineItem lineItem = new LineItem(this, product, quantity);
            _LineItems.Add(lineItem);
            return lineItem;
        }

        public void AddDiscount(Discount discount)
        {
            discount.OrderBase = this;
            discount.ApplyDiscount();
            _Discounts.Add(discount);
        }

        public virtual decimal GrossTotal
        {
            get
            {
                return LineItems
                    .Sum(x => x.Product.Price * x.Quantity);
            }
        }

        public virtual DateTime DateCreated { get; private set; }

        public IList<LineItem> LineItems
        {
            get
            {
                return _LineItems;
            }
        }
    }
}