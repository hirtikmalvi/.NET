using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public static class OrderExtension
    {
        public static decimal CalculateTotal(this Order order, Product product, Customer customer)
        {
            decimal total = order.Quantity * product.Price;

            total = customer.IsPremium ? total * 0.9m : total;
            return total;
        }
    }
}
