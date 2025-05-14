using System;

namespace Classes
{
    internal class Order
    {
        private int _ID;
        private int[] _products = [];
        public Order(int id, int[] products) { 
            _ID = id;
            _products = products;
        }

        public int ID()
        {
            return _ID;
        }

        public int[] Products() { 
        return _products;
        }
    }
}
