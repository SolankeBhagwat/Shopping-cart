using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public abstract class Discount : EntityBase
    {
        protected internal Discount()
        {
        }

        public Discount(string name)
        {
            Name = name;
        }
        public virtual bool CanBeUsedInJuntionWithOtherDiscounts { get; set; }
        public virtual bool SupercedesOtherDiscounts { get; set; }

        public abstract OrderBase ApplyDiscount();

        public virtual OrderBase OrderBase { get; set; }
        public virtual string Name { get; private set; }
    }
}
