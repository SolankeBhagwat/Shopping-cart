using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Entities;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Can_Add_Items_To_An_Order();
            Console.ReadKey();
        }

        public void Can_Add_Items_To_Cart()
        {
            var cart = LoadCart();

            // display the cart contents
            foreach (LineItem lineItem in cart.LineItems)
            {
                Console.WriteLine("Product: {0}\t Price: {1:c}\t Quantity: {2} \t Subtotal: {4:c} \t Discount: {3:c} \t| Discounts Applied: {5}", lineItem.Product.Name, lineItem.Product.Price, lineItem.Quantity, lineItem.DiscountAmount, lineItem.Subtotal, lineItem.Discounts.Count);
            }
        }
        
        public void Can_Add_Items_To_An_Order()
        {
            // create the cart
            Order order = new Order(new Member("Chev"));

            // add items to the cart
            Product hat = new Product("Cap", 110m);
            order.AddLineItem(hat, 5);

            Product race = new Product("Ticket", 90m);
            order.AddLineItem(race, 1);

            // add discounts
            Discount percentageOff = new PercentageOffDiscount("10% off all items", 0.10m);
            percentageOff.CanBeUsedInJuntionWithOtherDiscounts = false;
            order.AddDiscount(percentageOff);

            Discount spendXgetY = new SpendMoreThanXGetYDiscount("Spend more than R100 get 10% off", 100m, 0.1m);
            spendXgetY.SupercedesOtherDiscounts = true;
            order.AddDiscount(spendXgetY);

            Discount buyXGetY = new BuyXGetYFree("Buy 4 hats get 2 hat free", new List<Product> { hat }, 4, 2);
            buyXGetY.CanBeUsedInJuntionWithOtherDiscounts = false;
            buyXGetY.SupercedesOtherDiscounts = true;
            order.AddDiscount(buyXGetY);

            // display the cart contents
            foreach (LineItem lineItem in order.LineItems)
            {
                Console.WriteLine("Product: {0}\t Price: {1:c}\t Quantity: {2} \t Subtotal: {4:c} \t Discount: {3:c} \t| Discounts Applied: {5}", lineItem.Product.Name, lineItem.Product.Price, lineItem.Quantity, lineItem.DiscountAmount, lineItem.Subtotal, lineItem.Discounts.Count);
            }
        }
        
        public void Can_Process_A_Cart_Into_An_Order()
        {
            Cart cart = LoadCart();

            Order order = ProcessCartToOrder(cart);

            // display the cart contents
            foreach (LineItem lineItem in order.LineItems)
            {
                Console.WriteLine("Product: {0}\t Price: {1:c}\t Quantity: {2} \t Subtotal: {4:c} \t Discount: {3:c} \t| Discounts Applied: {5}", lineItem.Product.Name, lineItem.Product.Price, lineItem.Quantity, lineItem.DiscountAmount, lineItem.Subtotal, lineItem.Discounts.Count);
            }
        }

        private static Cart LoadCart()
        {
            // create the cart
            Cart cart = new Cart(new Member("Chev"));

            // add items to the cart
            Product hat = new Product("Cap", 110m);
            cart.AddLineItem(hat, 5);

            var race = new Product("Ticket", 90m);
            cart.AddLineItem(race, 1);

            // add discounts
            Discount percentageOff = new PercentageOffDiscount("10% off all items", 0.10m);
            percentageOff.CanBeUsedInJuntionWithOtherDiscounts = false;
            cart.AddDiscount(percentageOff);

            Discount spendXgetY = new SpendMoreThanXGetYDiscount("Spend more than R100 get 10% off", 100m, 0.1m);
            spendXgetY.SupercedesOtherDiscounts = true;
            cart.AddDiscount(spendXgetY);

            Discount buyXGetY = new BuyXGetYFree("Buy 4 hats get 2 hat free", new List<Product> { hat }, 4, 2)
            {
                CanBeUsedInJuntionWithOtherDiscounts = false,
                SupercedesOtherDiscounts = true
            };
            cart.AddDiscount(buyXGetY);

            return cart;
        }

        private static Order ProcessCartToOrder(Cart cart)
        {
            Order order = new Order(cart.Member);
            foreach (LineItem lineItem in cart.LineItems)
            {
                order.AddLineItem(lineItem.Product, lineItem.Quantity);
                foreach (Discount discount in lineItem.Discounts)
                {
                    order.AddDiscount(discount);
                }
            }
            return order;
        }
    }
}
