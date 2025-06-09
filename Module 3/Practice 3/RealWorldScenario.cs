using System;

namespace Practice_3
{
    class Payment
    {
        virtual public void ProcessPayment()
        {
            Console.WriteLine("Payment Processing...");
        }
    }
    class CreditCardPayment: Payment
    {
        override public void ProcessPayment()
        {
            Console.WriteLine("Credit Card Payment Processing...");
        }
    }
    class UPIPayment : Payment
    {
        override public void ProcessPayment()
        {
            Console.WriteLine("UPI Payment Processing...");
        }
    }
    
}
