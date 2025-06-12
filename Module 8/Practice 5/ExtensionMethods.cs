using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice_5
{
    public static class ExtensionMethods
    {
        public static bool isValidEmail(this string email)
        {
            return email.Contains("@gmail.com") || email.Contains("@co.in");
        }

        public static double AveragePrice(this List<Product> products)
        {
            double average = 0;
            foreach (var p in products)
            {
                average += p.Amount;
            }
            return average / products.Count;
        }
    }
}
