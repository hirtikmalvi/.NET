using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public static class ShippingExtension
    {
        public static decimal ApplyShippingCost(this ShippingInfo shippingInfo)
        {
            return shippingInfo.ShippingMethod switch
            {
                "Standard" => 5.0m,
                "Express" => 10.0m,
                "Free Shipping" => 0.0m,
                "Courier" => 15.0m,
                "Drone Delivery" => 25.0m,
                _ => 7.0m
            };
        }
    }
}
