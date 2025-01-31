using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Architectured.Entities
{
    public class Order
    {
        private int Code { get; set; }
        // public PaymentType? PaymentType { get; set }
        private string ProductName { get; set; }
        private decimal TotalPrice { get; set; }
        private IPayment PaymentContract { get; set; }

        public Order(string productName, decimal totalPrice)
        {
            Random generatedNumber = new();

            Code = generatedNumber.Next(1000, 9999);
            ProductName = productName;
            TotalPrice = totalPrice;
        }

        public void SetPaymentMethod(IPayment ipayment)
        {
            PaymentContract = ipayment;
        }

        public void ConcludePayment()
        {
            if (PaymentContract is null)
            {
                System.Console.WriteLine("Houve um erro ao selectionar a forma de pagamento!");
                return;
            }

            PaymentContract.Pay(TotalPrice);
        }
    }

    // public enum PaymentType : int
    // {
    //     Credito,
    //     Debito,
    //     Boleto,
    //     Pix
    // };
}