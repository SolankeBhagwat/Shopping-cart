using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class Member : EntityBase
    {
        protected internal Member()
        {
        }

        public Member(string name)
        {
            Name = name;
        }

        public virtual string Name { get; set; }
    }
}
