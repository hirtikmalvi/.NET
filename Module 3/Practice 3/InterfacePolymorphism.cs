using System;

namespace Practice_3
{
	interface IDiscount
	{
		double ApplyDiscount();
	}
    public class RegularCustomer : IDiscount
    {
        public double ApplyDiscount()
        {
            return 0;
        }
    }
    public class PremiumCustomer
    {
        double DiscountRate { get; set; }
        public double ApplyDiscount()
        {
            return 0;
        }
    }
}
