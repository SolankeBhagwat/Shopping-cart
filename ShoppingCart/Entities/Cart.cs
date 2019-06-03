namespace ShoppingCart.Entities
{
    public class Cart : OrderBase
    {
        protected internal Cart()
        {
        }

        public Cart(Member member)
            : base(member)
        {
        }
    }
}