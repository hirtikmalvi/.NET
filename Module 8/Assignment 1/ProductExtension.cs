using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public static class ProductExtension
    {
        public static bool IsInStock(this Product product)
        {
            return product.Stock > 0;
        }
    }
}
