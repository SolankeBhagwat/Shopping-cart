namespace ShoppingCart.Entities
{
    public class Order : OrderBase
    {
        protected internal Order()
        {
        }

        public Order(Member member)
            : base(member)
        {
        }
    }
}