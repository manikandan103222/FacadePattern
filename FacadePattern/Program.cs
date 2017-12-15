/**
 * Author: Manikandan. M
 * Description: Sample Program for Facade Pattern
 */
using System;
namespace FacadePattern
{
    /// <summary>
    /// sub system 1
    /// </summary>
    public class Stock
    {
        public string checkStock(string orderId)
        {
            return (orderId != "") ? "available" : "not avilable";
        }
    }

    /// <summary>
    /// sub system 2
    /// </summary>
    public class Card
    {
        public string addOrder(string orderId)
        {
            return "order added successfully";
        }
        public string removeOrder(string orderId)
        {
            return "order removed successfully";
        }

        public string checkOutOrder(string orderId)
        {
            return "order checkout successfully";
        }
    }

    /// <summary>
    /// sub system 3
    /// </summary>
    public class Payment
    {
        public string checkPayment(string paymentDetails)
        {
            return (paymentDetails != "") ? "valid payment" : "not valid payment";
        }

        public string deductPayment(string orderId)
        {
            return (orderId != "") ? "payment deducted successfully" : "payment not deducted. check from your order";
        }
    }

    /// <summary>
    /// order facade
    /// </summary>
    public class OrderFacade
    {
        private Stock stock;
        private Card card;
        private Payment payment;

        public OrderFacade()
        {
            stock = new Stock();
            card = new Card();
            payment = new Payment();
        }

        public string checkStockAvailability(string orderId)
        {
            string checkStockAvailability = stock.checkStock(orderId);
            return checkStockAvailability;
        }

        public string addToCard(string orderId)
        {
            return card.addOrder(orderId);
        }

        public string removeFromCard(string orderId)
        {
            return card.removeOrder(orderId);
        }

        public string checkoutOrderFromCard(string orderId)
        {
            return card.checkOutOrder(orderId);
        }

        public void placeOrder(string orderId)
        {
            string paymentValidationStatus = payment.checkPayment(orderId);
            Console.WriteLine(string.Format("\npayment validation status: {0}", paymentValidationStatus));
            string deductPaymentStatus = payment.deductPayment(orderId);
            Console.WriteLine(string.Format("\npayment deduct status: {0}", deductPaymentStatus));
        }

    }

    /// <summary>
    /// client
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------Facade Pattern-------------------------------------");
            OrderFacade order = new OrderFacade();
            string orderId = "radio123"; //sample order id for this example
            string orderStatus = order.checkStockAvailability(orderId);
            if (orderStatus == "available")
            {
                Console.WriteLine(string.Format("\nstock status: {0}", orderStatus));
                Console.WriteLine(string.Format("\nadd card status: {0}", order.addToCard(orderId)));
                Console.WriteLine(string.Format("\ncheckout order from card status: {0}", order.checkoutOrderFromCard(orderId)));
                order.placeOrder(orderId);
            } else
            {
                Console.WriteLine(string.Format("\nstock status: {0}", orderStatus));
            }
            Console.Write("\nPress any key to exist...");
            Console.ReadKey();
        }
    }
}
